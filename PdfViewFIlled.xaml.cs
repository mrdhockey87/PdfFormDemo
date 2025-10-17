using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
using PdfFormDemo.Models;
using PdfFormFramework.Printing;
using System.Diagnostics;
using System.Threading;

namespace PdfFormDemo;

public partial class PdfViewFilled : ContentPage
{
    private readonly IFileSaver fileSaver;
    private PdfFormData PdfFormData;
    public PdfViewFilled(PdfFormData pdfFormData)
    {
        InitializeComponent();
        PdfFormData = pdfFormData;
        // Initialize FileSaver (no DI required)
        fileSaver = FileSaver.Default;

    }
    private async void Page_Loaded(object? sender, EventArgs e)
    {
        Debug.WriteLine("Page loaded");
        await Task.Delay(1000); // Longer delay to ensure UI is fully rendered
        await LoadPdfFormAsync();
    }

    private async Task LoadPdfFormAsync()
    {
        try
        {
            Debug.WriteLine("Loading PDF form");

            string fileName = "demo_form.pdf.gz"; // Update with your actual filename
            string? pdfPath = await LocatePdfFileAsync(fileName);

            if (pdfPath == null)
            {
                await DisplayAlert("Error", $"Cannot find PDF file: {fileName}", "OK");
                return;
            }

            Debug.WriteLine($"Loading PDF from path: {pdfPath}");

            // Load the PDF with our model data - this will pre-fill the form
            await FormView.LoadPdfGz(pdfPath, PdfFormData);

            Debug.WriteLine("PDF loaded successfully");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error loading PDF: {ex.Message}");
            Debug.WriteLine(ex.StackTrace);
            await DisplayAlert("Error", $"Failed to load PDF: {ex.Message}", "OK");
        }
    }

    private async Task<string?> LocatePdfFileAsync(string fileName)
    {
        // Try multiple possible locations for the PDF file
        List<string> possibleLocations = new()
        {
            fileName,
            Path.Combine(FileSystem.AppDataDirectory, fileName),
            Path.Combine(FileSystem.CacheDirectory, fileName),
            Path.Combine("Resources", "Raw", fileName),
            Path.Combine(AppContext.BaseDirectory, fileName)
        };

        foreach (var path in possibleLocations)
        {
            Debug.WriteLine($"Checking for PDF at: {path}");
            if (File.Exists(path))
            {
                Debug.WriteLine($"Found PDF at: {path}");
                return path;
            }
        }

        // If not found in standard locations, try to copy from app resources
        try
        {
            string targetPath = Path.Combine(FileSystem.CacheDirectory, fileName);
            Debug.WriteLine($"Extracting PDF to: {targetPath}");

            using var stream = await FileSystem.OpenAppPackageFileAsync(fileName);
            using var fileStream = File.Create(targetPath);
            await stream.CopyToAsync(fileStream);

            Debug.WriteLine($"Extracted PDF to: {targetPath}");
            return targetPath;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error extracting PDF: {ex.Message}");
        }

        return null;
    }
    // not part of the codebase
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        var savedPath = await FormView.SaveAsAsync(
            async (defaultName, stream, ct) =>
            {
                // Ensure stream at start (safety)
                if (stream.CanSeek) stream.Position = 0;

                var result = await fileSaver.SaveAsync(defaultName, stream, ct);

                if (result.IsSuccessful)
                {
                    await Toast.Make($"The file was saved to: {result.FilePath}").Show(ct);
                }
                else
                {
                    var msg = result.Exception?.Message ?? "Cancelled";
                    await Toast.Make($"Save failed: {msg}").Show(ct);
                }

                return result.IsSuccessful ? result.FilePath : null;
            },
            formName: "EnrollmentForm");

        await DisplayAlert(savedPath is not null ? "Success" : "Cancelled",
            savedPath is not null ? $"Saved to:\n{savedPath}" : "Save was cancelled.", "OK");
    }
    private async void OnPrintClicked(object sender, EventArgs e)
    {
        try
        {
            var pdfPath = FormView.CurrentPdfPath; // <- filled/view copy path
            if (string.IsNullOrEmpty(pdfPath) || !File.Exists(pdfPath))
            {
                await DisplayAlert("Print", "No filled PDF available yet.", "OK");
                return;
            }
            await PdfPrinterHelper.PrintOrEmailAsync(pdfPath);

            // Or use the built-in print/share
            /*
            var ok = await FormView.PrintAsync();
            if (!ok)
                await DisplayAlert("Print", "The OS did not present a print/share UI.", "OK");*/
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error printing: {ex.Message}");
            await DisplayAlert("Error", $"Failed to print: {ex.Message}", "OK");
        }
    }

    private async void OnUpdateFormClicked(object sender, EventArgs e)
    {
        try
        {
            var updatedModel = new PdfFormData
            {
                FirstName = "Jane",
                LastName = "Smith",
                Address1 = "456 Oak Ave",
                City = "Los Angeles",
                ZipCode = "90001",
                DrivingLicense = false,
                English = true
            };

            await FormView.FillFormWithModelAsync(updatedModel);
            await DisplayAlert("Success", "Form updated", "OK");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating form: {ex.Message}");
            await DisplayAlert("Error", $"Failed to update form: {ex.Message}", "OK");
        }
    }
}
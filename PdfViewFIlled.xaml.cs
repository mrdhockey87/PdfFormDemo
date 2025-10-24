#nullable enable
using PdfFormFramework.Services;
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
    private PdfFormData? PdfFormData;          // allow null => display-only
    private string? _incomingPath;             // path supplied by the app (.pdf or .pdf.gz)

    public PdfViewFilled(PdfFormData pdfFormData)
    {
        InitializeComponent();
        PdfFormData = pdfFormData;
        fileSaver = FileSaver.Default;
    }

    // New: open a PDF from the app (pass .pdf.gz or .pdf). Pass null for display-only
    public PdfViewFilled(string appPdfPath, PdfFormData? pdfFormData = null)
    {
        InitializeComponent();
        _incomingPath = appPdfPath;
        PdfFormData = pdfFormData; // null => display-only
        fileSaver = FileSaver.Default;
    }

    private async void Page_Loaded(object sender, EventArgs e)
    {
        Debug.WriteLine("Page loaded");
        await LoadingOverlay.ShowAsync();
        await LoadPdfFormAsync();
    }

    private async Task LoadPdfFormAsync()
    {
        Exception? error = null;

        try
        {
            if (!string.IsNullOrWhiteSpace(_incomingPath))
            {
                // Use the app-supplied file (.pdf.gz or .pdf)
                await FormView.LoadFromAppAsync(_incomingPath, PdfFormData);
                Debug.WriteLine("PDF loaded from app path");
                return;
            }

            // Fallback: locate default resource inside the demo app
            string fileName = "demo_form.pdf.gz";
            string? path = await LocatePdfFileAsync(fileName);
            if (path is null)
            {
                await LoadingOverlay.Hide();
                await DisplayAlert("Error", $"Cannot find PDF file: {fileName}", "OK");
                return;
            }

            // Model present => fill; otherwise display as-is
            await FormView.LoadPdfGz(path, PdfFormData);
            Debug.WriteLine("PDF loaded successfully");
        }
        catch (Exception ex)
        {
            error = ex;
            Debug.WriteLine($"Error loading PDF: {ex.Message}");
            Debug.WriteLine(ex.StackTrace);
        }
        finally
        {
            await LoadingOverlay.Hide();
        }

        if (error is not null)
            await DisplayAlert("Error", $"Failed to load PDF: {error.Message}", "OK");
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
    private async void OnSaveDataClicked(object sender, EventArgs e)
    {
        //could add logic to save form data from the form if needed
        await DisplayAlert("Data", $"Saved Data Clicked", "OK");
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
    private async void OnEmailFormClicked(object sender, EventArgs e)
    {
        if(string.IsNullOrEmpty(FormView.CurrentPdfPath) || !File.Exists(FormView.CurrentPdfPath))
        {
            await DisplayAlert("Email", "No filled PDF available yet.", "OK");
            return;
        }
       await PdfPrinterHelper.PromptAndEmailAsync(FormView.CurrentPdfPath);
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
}
using PdfFormDemo.Models;
using System.Diagnostics;

namespace PdfFormDemo;

public partial class PdfViewFIlled : ContentPage
{
	private PdfFormData applicationForm;
	public PdfViewFIlled()
	{
		InitializeComponent();
		applicationForm = new PdfFormData();
    }
    private async void MainPage_Loaded(object? sender, EventArgs e)
    {
        Debug.WriteLine("MainPage loaded");
        await Task.Delay(1000); // Longer delay to ensure UI is fully rendered
        await LoadPdfFormAsync();
    }

    private async Task LoadPdfFormAsync()
    {
        try
        {
            Debug.WriteLine("Loading PDF form");

            var model = new PdfFormData
            {
                FirstName = "John",
                LastName = "Doe",
                Address1 = "123 Main St",
                HouseNumber = "222B",
                City = "New York",
                ZipCode = "10001",
                SelectedCountry = "France",
               // Gender = "Male",
                DrivingLicense = true,
                English = true,
                //FavouriteColor = "Red"  // Try exact match case
                                    //FavouriteColor = "blue" // Try lowercase
                                    //FavouriteColor = "BLUE" // Try uppercase
                                    // Add other properties as needed
            };

            // Find the PDF file using multiple search paths
            string fileName = "demo_form.pdf.gz"; // Update with your actual filename
            string? pdfPath = await LocatePdfFileAsync(fileName);

            if (pdfPath == null)
            {
                await DisplayAlert("Error", $"Cannot find PDF file: {fileName}", "OK");
                return;
            }

            Debug.WriteLine($"Loading PDF from path: {pdfPath}");

            // Load the PDF with our model data - this will pre-fill the form
            await FormView.LoadPdfGz(pdfPath, model);

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
            // Try to extract from embedded resources
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

    private void OnSaveClicked(object sender, EventArgs e)
    {
        try
        {
            FormView.SaveModelData();
            DisplayAlert("Success", "Form data saved", "OK");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error saving data: {ex.Message}");
            DisplayAlert("Error", $"Failed to save data: {ex.Message}", "OK");
        }
    }

    private async void OnPrintClicked(object sender, EventArgs e)
    {
        try
        {

            var modelTwo = new PdfFormData
            {
                FirstName = "Tom",
                LastName = "Thumb",
                Address1 = "3223 Main St",
                HouseNumber = "11A",
                City = "New York",
                ZipCode = "10001",
                //Gender = 0,
                DrivingLicense = true,
                English = true,
                //FavouriteColor = 7  // Try exact match case
                                    //FavouriteColor = "blue" // Try lowercase
                                    //FavouriteColor = "BLUE" // Try uppercase
                                    // Add other properties as needed
            };

            // Update the PDF with the new data
            await FormView.FillFormWithModelAsync(modelTwo);
            //FormView.PrintForm();
            DisplayAlert("Success", "Form sent to printer", "OK");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error printing: {ex.Message}");
            DisplayAlert("Error", $"Failed to print: {ex.Message}", "OK");
        }
    }

    private async void OnUpdateFormClicked(object sender, EventArgs e)
    {
        try
        {
            // Example: Update the model with new data
            var updatedModel = new PdfFormData
            {
                FirstName = "Jane",
                LastName = "Smith",
                Address1 = "456 Oak Ave",
                City = "Los Angeles",
                ZipCode = "90001",
                DrivingLicense = false,
                English = true
                // Add other properties as needed
            };

            // Update the PDF with the new data
            await FormView.FillFormWithModelAsync(updatedModel);
            DisplayAlert("Success", "Form updated", "OK");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating form: {ex.Message}");
            DisplayAlert("Error", $"Failed to update form: {ex.Message}", "OK");
        }
    }
}
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic.FileIO;
using PdfFormDemo.Enums;
using PdfFormDemo.Extensions;
using System.Collections.ObjectModel;

namespace PdfFormDemo.Models;

public partial class PdfFormData : ObservableObject
{
    [ObservableProperty]
    private string _firstName = "";
    [ObservableProperty]
    private string _lastName = "";
    [ObservableProperty]
    private string _address1 = "";
    [ObservableProperty]
    private string _houseNumber = "";
    [ObservableProperty]
    private string _address2 = "";
    [ObservableProperty]
    private string _zipCode = "";
    [ObservableProperty]
    private string _city = "";
    [ObservableProperty]
    private string _country = "";
    public CountryList? CountriesList { get; set; }
    [ObservableProperty]
    private string _gender = "";
    public GenderList? GendersList { get; set; }
    [ObservableProperty]
    private string _height = "";
    [ObservableProperty]
    private bool _drivingLicense = false;
    [ObservableProperty]
    private bool _deutsch = false;
    [ObservableProperty]
    private bool _english = false;
    [ObservableProperty]
    private bool _french = false;
    [ObservableProperty]
    private bool _spanish = false;
    [ObservableProperty]
    private bool _latin = false;
    [ObservableProperty]
    private string _favouriteColor = "";
    public FavouriteColorList? FavouriteColorsList { get; set; }
    public string GetCountryString() => CountriesList?.ToDisplayString() ?? string.Empty;
    // Selected string values for binding
    public string GetGenderString() => GendersList?.ToDisplayString() ?? string.Empty;

    public string GetFavouriteColorString() => FavouriteColorsList?.ToDisplayString() ?? string.Empty;
    private string _selectedCountry { set; get; }
    public string SelectedCountry
    {
        get => _selectedCountry;
        set
        {
            _selectedCountry = value;
            Country = value;

        }
    }
    private string _selectedGender { set; get; }
    public string SelectedGender
    {
        get => _selectedGender;
        set
        {
            _selectedGender = value;
            Gender = value;
        }
    }
    private string _selectedColor { set; get; }
    public string SelectedColor
    {
        get => _selectedColor;
        set
        {
            _selectedColor = value;
            FavouriteColor = value;
        }
    }

    public PdfFormData()
    {
    }
    // Method to create a shallow copy
    public PdfFormData ShallowCopy()
    {
        return (PdfFormData)this.MemberwiseClone();
    }
}

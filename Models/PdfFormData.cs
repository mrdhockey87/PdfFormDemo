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
    public Country? Country { get; set; }
    public Gender? Genders { get; set; }
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
    public FavouriteColor? FavouriteColors { get; set; }
    public string GetCountryString() => Country?.ToDisplayString() ?? string.Empty;
    // Selected string values for binding
    public string GetGenderString() => Genders?.ToDisplayString() ?? string.Empty;

    public string GetFavouriteColorString() => FavouriteColors?.ToDisplayString() ?? string.Empty;
    private string _selectedCountry { set; get; }
    public string SelectedCountry
    {
        get => _selectedCountry;
        set
        {
            _selectedCountry = value;
        }
    }
    private string _selectedGender { set; get; }
    public string SelectedGender
    {
        get => _selectedGender;
        set
        {
            _selectedGender = value;
        }
    }
    private string _selectedColor { set; get; }
    public string SelectedColor
    {
        get => _selectedColor;
        set
        {
            _selectedColor = value;
        }
    }

    public PdfFormData()
    {
    }
}

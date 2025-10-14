using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic.FileIO;
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
    [ObservableProperty]
    private ObservableCollection<string> _gender;
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
    private ObservableCollection<string> _favouriteColor;

    public PdfFormData()
    {
        Gender = ["Male", "Female"];
        FavouriteColor = ["Black", "Brown", "Red", "Orange", "Yellow", "Green", "Blue", "Purple", "Violet", "Gery", "White"];
    }
}

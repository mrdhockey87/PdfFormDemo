using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using PdfFormDemo.Models;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PdfFormDemo;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
    //private PdfFormData _pdfFormData;
    public PdfFormData _pdfFormData
    {
        get => _pdfFormData;
        set {
            _pdfFormData = value;
        }; // Include a setter if needed for updates
    }
    public MainPage()
    {
        InitializeComponent();
        _pdfFormData = new PdfFormData();
    }
}
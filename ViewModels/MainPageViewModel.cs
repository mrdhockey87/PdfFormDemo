using CommunityToolkit.Mvvm.ComponentModel;
using PdfFormDemo.Enums;
using PdfFormDemo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfFormDemo.ViewModels
{
    public partial class MainPageViewModel : ContentPage
    {


        private PdfFormData _pdfFormData = new();
        public PdfFormData PdfPageData
        {
            get => _pdfFormData;
            set => _pdfFormData = value;
        }
        public ObservableCollection<string> Country { get; } = new(Enum.GetNames<Country>().Select(name =>
                            System.Text.RegularExpressions.Regex.Replace(name, "([a-z])([A-Z])", "$1 $2")));

        public ObservableCollection<string> Genders { get; } = new(Enum.GetNames<Gender>().Select(name =>
                            System.Text.RegularExpressions.Regex.Replace(name, "([a-z])([A-Z])", "$1 $2")));
        public ObservableCollection<string> FavouriteColors { get; } = new(Enum.GetNames<FavouriteColor>().Select(name =>
                            System.Text.RegularExpressions.Regex.Replace(name, "([a-z])([A-Z])", "$1 $2")));
        private string _selectedCountry;
        public string SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                _selectedCountry = value;
                PdfPageData.SelectedCountry = value;
                OnPropertyChanged(nameof(SelectedCountry));
            }
        }
        private string _selectedGender;
        public string SelectedGender
        {
            get => _selectedGender;
            set
            {
                _selectedGender = value;
                PdfPageData.SelectedGender = value;
                OnPropertyChanged(nameof(SelectedGender));
            }
        }
        private string _selectedColor;
        public string SelectedColor
        {
            get => _selectedColor;
            set
            {
                _selectedColor = value;
                PdfPageData.SelectedColor = value;
                OnPropertyChanged(nameof(SelectedColor));
            }
        }
    }
}

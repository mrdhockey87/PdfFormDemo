using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PdfFormDemo.Enums;
using PdfFormDemo.Models;
using PdfFormDemo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfFormDemo.Extensions;

namespace PdfFormDemo.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {


        private PdfFormData _pdfFormData = new();

        public IAsyncRelayCommand OpenPDFFormCommand { get; }
        public IAsyncRelayCommand OpenPDFCommand { get; }
        public MainPageViewModel()
        {
            OpenPDFFormCommand = new AsyncRelayCommand(OpenPDFFormCommandExecute);
            OpenPDFCommand = new AsyncRelayCommand(OpenPDFCommandExecute);
        }
        private async Task OpenPDFCommandExecute()
        {
            var nav = Microsoft.Maui.Controls.Application.Current?.MainPage?.Navigation;
            if (nav is null)
                return;

            await nav.PushAsync(new PdfViewFilled(null));
        }

        private async Task OpenPDFFormCommandExecute()
        {
            var nav = Microsoft.Maui.Controls.Application.Current?.MainPage?.Navigation;
            if (nav is null)
                return;

            await nav.PushAsync(new PdfViewFilled(PdfPageData));
        }
        public PdfFormData PdfPageData
        {
            get => _pdfFormData;
            set => _pdfFormData = value;
        }

        public ObservableCollection<string> Countries { get; } =
            new(Enum.GetValues<CountryList>().Select(e => e.ToDisplayString()));

        public ObservableCollection<string> Genders { get; } =
            new(Enum.GetValues<GenderList>().Select(e => e.ToDisplayString()));

        public ObservableCollection<string> FavouriteColors { get; } =
            new(Enum.GetValues<FavouriteColorList>().Select(e => e.ToDisplayString()));
        private string _selectedCountry;
        public string SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                _selectedCountry = value;
                PdfPageData.SelectedCountry = value;
                PdfPageData.Country = value;
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
                PdfPageData.Gender = value;
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
                PdfPageData.FavouriteColor = value;
                OnPropertyChanged(nameof(SelectedColor));
            }
        }
    }
}

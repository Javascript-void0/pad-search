using FFImageLoading.Forms;
using FFImageLoading.Transformations;
using PAD_Search.Models;
using PAD_Search.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Services;
using Rg.Plugins.Popup.Exceptions;

namespace PAD_Search
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {

        private FilterPopup filterPopup;
        private ViewModel viewModel { get; set; }

        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();

            viewModel = new ViewModel();
            list.BindingContext = viewModel;
            filterPopup = new FilterPopup(viewModel);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Debug.WriteLine("mainpage appear");
        }


        private async void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            string prev = searchbar.Text;

            if (prev == "" || prev == null)
            {
                viewModel.LoadDefaultMonsters();
                clearButton.IsVisible = false;
            }
            else
                clearButton.IsVisible = true;

            await Task.Delay(500);

            string now = searchbar.Text;
            // search if length >= 2 or single digit
            if (prev == now && (now.Length >= 2 || "123456789".Contains(now))) // stopped typing after delay
                viewModel.SearchMonsters(now);

            // scroll back up
            if (viewModel.LoadedMonsters.FirstOrDefault() != null)
                list.ScrollTo(viewModel.LoadedMonsters.First(), ScrollToPosition.Start, false);

        }

        private void Clear_Button_Clicked(object sender, EventArgs e)
        {
            viewModel.LoadDefaultMonsters();
            searchbar.Text = string.Empty;
            clearButton.IsVisible = false;
        }

        public HtmlWebViewSource Test
        {
            get
            {
                var html = @"
<html>
    <body>
        <style>
            :root { --size: 15 }
            body { background-color: #1d1d1d }
            span { font-size: var(--size); color: white }
            .icon {
                width: var(--size);
                height: var(--size);
                background-image: url('icon-orbs.png');
                background-size: 200% 1000%;
                background-position: 0% 22.222222%;
                background-repeat: none;
                aspect-ratio: 50 / 50;
                display: inline-block;
                color: transparent;
            }
        </style>
        <span>Removes {locks},\nchanges </span>
        <span class=""icon"">.</span>
        <span>{Jammers}{Poison}{Lethal Poison}{Bombs} to {Water}</span>
    </body>
</html>";
                var source = new HtmlWebViewSource();
                source.BaseUrl = "file:///android_asset/";
                source.Html = html;
                return source;
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            int id = (int)((TappedEventArgs)e).Parameter - 1; // compensate for removing index 0 place holder
            Navigation.PushAsync(new MonsterView(id));
        }

        private async void Filter_Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                //Navigation.PushAsync(new FilterPopup());
                await PopupNavigation.Instance.PushAsync(filterPopup);
            }
            catch (RGPageInvalidException ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}

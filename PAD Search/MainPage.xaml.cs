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

namespace PAD_Search
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {

        private static int numCols = 5;
        private static int gridSize = 60;
        private static int totalMonsters = 600;
        private static int totalRows = (int)Math.Ceiling((double)totalMonsters / numCols);

        private ViewModel viewModel { get; set; }



        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();

            viewModel = new ViewModel();
            list.BindingContext = viewModel;
        }


        private async void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            string prev = searchbar.Text;

            if (prev == "" || prev == null)
                viewModel.LoadDefaultMonsters();

            await Task.Delay(500);

            string now = searchbar.Text;
            // search if length >= 2 or single digit
            if (prev == now && (now.Length >= 2 || "123456789".Contains(now))) // stopped typing after delay
			    viewModel.SearchForMonsters(now);

            // scroll back up
            if (viewModel.LoadedMonsters.FirstOrDefault() != null)
                list.ScrollTo(viewModel.LoadedMonsters.First(), ScrollToPosition.Start, false);
        }
    }
}

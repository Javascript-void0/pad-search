using FFImageLoading.Forms;
using PAD_Search.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PAD_Search
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        ViewModel viewModel;
        public FilterPopup(ViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Debug.WriteLine("popup disappear");

            int? attr1Id, attr2Id, attr3Id, typeId;

            if (RadioButtonGroup.GetSelectedValue(attr1) != null)
                attr1Id = int.Parse((string)RadioButtonGroup.GetSelectedValue(attr1));
            else attr1Id = null;

            if (RadioButtonGroup.GetSelectedValue(attr2) != null)
                attr2Id = int.Parse((string)RadioButtonGroup.GetSelectedValue(attr2));
            else attr2Id = null;

            if (RadioButtonGroup.GetSelectedValue(attr3) != null)
                attr3Id = int.Parse((string)RadioButtonGroup.GetSelectedValue(attr3));
            else attr3Id = null;

            if (RadioButtonGroup.GetSelectedValue(type) != null)
                typeId = int.Parse((string)RadioButtonGroup.GetSelectedValue(type));
            else typeId = null;

            Debug.WriteLine(attr1Id);
            Debug.WriteLine(attr2Id);
            Debug.WriteLine(attr3Id);
            Debug.WriteLine(typeId);

            viewModel.attr1 = attr1Id;
            viewModel.attr2 = attr2Id;
            viewModel.attr3 = attr3Id;
            viewModel.type = typeId;

            //viewModel.Filter();
        }

        private void Reset_Button_Clicked(object sender, EventArgs e)
        {
            attr1fire.IsChecked = true;
            attr1fire.IsChecked = false;

            attr2fire.IsChecked = true;
            attr2fire.IsChecked = false;

            attr3fire.IsChecked = true;
            attr3fire.IsChecked = false;

            god.IsChecked = true;
            god.IsChecked = false;

            selectedAwoken.Children.Clear();
        }

        private void RadioButton_GestureRecognizer_Tapped(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)(((Frame)sender).Parent);

            if (button.IsChecked)
                button.IsChecked = false;
            else
                button.IsChecked = true;

        }

        private void Awoken_GestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (selectedAwoken.Children.Count >= 10) return;

            int awokenId = int.Parse((string)((Frame)sender).BindingContext);
            Frame f = new Frame()
            {
                HeightRequest = 25,
                WidthRequest = 25,
                Margin = 0,
                Padding = 0,
                BackgroundColor = Color.Transparent,
                CornerRadius = 1,
                VerticalOptions = LayoutOptions.Center
            };
            AbsoluteLayout a = new AbsoluteLayout();
            CachedImage img = new CachedImage() { Source = ImageSource.FromResource("PAD_Search.Images.awoken.png") };
            AbsoluteLayout.SetLayoutBounds(img, AwokenIdConverter.Convert2(awokenId));
            AbsoluteLayout.SetLayoutFlags(img, AbsoluteLayoutFlags.All);
            a.Children.Add(img);
            f.Content = a;


            TapGestureRecognizer tapped = new TapGestureRecognizer();
            tapped.Tapped += (s, x) =>
            {
                selectedAwoken.Children.Remove((Frame)s);
            };
            f.GestureRecognizers.Add(tapped);

            selectedAwoken.Children.Add(f);
        }
    }
}
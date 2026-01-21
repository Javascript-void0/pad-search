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
    //public partial class FilterPopup : Rg.Plugins.Popup.Pages.PopupPage
    public partial class FilterPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public FilterPopup()
        {
            InitializeComponent();
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

        }
    }
}
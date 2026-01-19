using System;
using System.Collections.Generic;
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
            attr1fire.IsChecked = false;
            attr1water.IsChecked = false;
            attr1wood.IsChecked = false;
            attr1light.IsChecked = false;
            attr1dark.IsChecked = false;
            attr1none.IsChecked = false;

            attr2fire.IsChecked = false;
            attr2water.IsChecked = false;
            attr2wood.IsChecked = false;
            attr2light.IsChecked = false;
            attr2dark.IsChecked = false;
            attr2none.IsChecked = false;

            attr3fire.IsChecked = false;
            attr3water.IsChecked = false;
            attr3wood.IsChecked = false;
            attr3light.IsChecked = false;
            attr3dark.IsChecked = false;
            attr3none.IsChecked = false;

            god.IsChecked = false;
            dragon.IsChecked = false;
            devil.IsChecked = false;
            machine.IsChecked = false;
            balanced.IsChecked = false;
            attacker.IsChecked = false;
            physical.IsChecked = false;
            healer.IsChecked = false;
            evoMaterial.IsChecked = false;
            awakenMaterial.IsChecked = false;
            enhanceMaterial.IsChecked = false;
            redeemableMaterial.IsChecked = false;
        }
    }
}
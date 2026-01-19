using PAD_Search.Models;
using PAD_Search.ViewModels;
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
	public partial class MonsterView : ContentPage
	{
		Monster monster { get; set; }
		public MonsterView(int id)
		{
			InitializeComponent();
			BindingContext = this;
			monster = ViewModel.GetMonster(id);
			layout.BindingContext = monster;
		}
	}
}
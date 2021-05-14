using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PersonalFactsApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.FactDataDatabase.GetFactDataAsync();
        }

        //async void OnSelection(object sender, SelectedItemChangedEventArgs e)
        //{
        //    if (e.SelectedItem == null)
        //    {
        //        return;
        //    }
        //    FactData fact = (FactData)e.SelectedItem;
        //    // DisplayAlert("The Fact", fact.TheFact, "Ok");

        //    var factData = (FactData)BindingContext;
        //    FactDataDatabase database = await FactDataDatabase.Instance;
        //    await database.SaveItemAsync(factData);

        //    // Navigate backwards
        //    await Navigation.PopAsync();
        //}

        //async void OnSaveClicked(object sender, EventArgs e)
        //{
        //    var factData = (FactData)BindingContext;
        //    FactDataDatabase database = await FactDataDatabase.Instance;
        //    await database.SaveItemAsync(factData);

        //    // Navigate backwards
        //    await Navigation.PopAsync();
        //}
    }
}
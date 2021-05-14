using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalFactsApp
{
    public partial class App : Application
    {
        static FactDataDatabase database;
        public static FactDataDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new FactDataDatabase();
                    prefillDatabase();
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        static void prefillDatabase()
        {
            database.ClearAllAsync();

            List<FactData> items = new List<FactData>();

            items.Add(new FactData() { TheFact = "Jerry's birthday is in April", ShortFact = "Birthday", ImageUrl = "https://c.tadst.com/gfx/750w/the-month-april.jpg?1" });
            items.Add(new FactData() { TheFact = "Jerry has two sons", ShortFact = "Children", ImageUrl= "https://cdn3.vectorstock.com/i/1000x1000/19/87/happy-family-mother-and-father-with-two-sons-vector-8201987.jpg" });
            items.Add(new FactData() { TheFact = "Jerry's favorite baseball team is the NY Yankees", ShortFact = "Favorite Baseball Team", ImageUrl= "http://mobileimages.lowes.com//product/converted/500027/5000273689.jpg?size=pdhi" });
            items.Add(new FactData() { TheFact = "Jerry's favorite cuisine is Chinese", ShortFact = "Favorite Cuisine", ImageUrl= "https://img1.mashed.com/img/gallery/myths-about-chinese-food-you-should-stop-believing/intro-1596806354.jpg" });
            items.Add(new FactData() { TheFact = "Jerry's favorite color is red", ShortFact = "Favorite Color", ImageUrl= "https://pbs.twimg.com/media/EheZ90KXcAAlR1u.jpg" });

            database.InsertList(items);

        }
    }
}

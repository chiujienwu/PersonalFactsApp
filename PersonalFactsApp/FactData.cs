using System;
using System.Collections.Generic;
using SQLite;

namespace PersonalFactsApp
{
    public class FactData
    {
        //public FactData()
        //{
        //}
        //public static IEnumerable<FactData> All { private set; get; }

        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string TheFact { get; set; }
        public string ShortFact { get; set; }
        public string ImageUrl { get; set; }

        //static FactData()
        //{
        //    List<FactData> all = new List<FactData>();
        //    all.Add(new FactData() { TheFact = "Jerry's birthday is in April", ShortFact = "Birthday" });
        //    all.Add(new FactData() { TheFact = "Jerry has two sons", ShortFact = "Children" });
        //    all.Add(new FactData() { TheFact = "Jerry's favorite baseball team is the NY Yankees", ShortFact = "Favorite Baseball Team" });
        //    all.Add(new FactData() { TheFact = "Jerry's favorite cuisine is Chinese", ShortFact = "Favorite Cuisine" });
        //    all.Add(new FactData() { TheFact = "Jerry's favorite color is red", ShortFact = "Favorite Color" });
        //    All = all;
        //    //Do your insert into database here
        //    InsertList(All);

        //}
    }
}
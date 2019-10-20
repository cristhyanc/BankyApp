using BankyApp.Entities;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BankyApp
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class TrackerPageModel: FreshBasePageModel
    {

        ObservableCollection<TrackerCategory> categories;
        public ObservableCollection<TrackerCategory> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }


        public TrackerPageModel()
        {
            Categories = new ObservableCollection<TrackerCategory>();
            var category = new TrackerCategory { Amount=750, Description="Rent" };
            Categories.Add(category);

            category = new TrackerCategory { Amount =80 , Description = "Mobile" };
            Categories.Add(category);

            category = new TrackerCategory { Amount = 240, Description = "Electricity Bills" };
            Categories.Add(category);

            category = new TrackerCategory { Amount = 70, Description = "Gym" };
            Categories.Add(category);

            category = new TrackerCategory { Amount = 120, Description = "Dining Out" };
            Categories.Add(category);

            var total = Categories.Sum(x => x.Amount);
            foreach (var item in Categories )
            {
                item.Percentage = Math.Round((item.Amount * 100) / total, 1);
            }
        }

    }
}

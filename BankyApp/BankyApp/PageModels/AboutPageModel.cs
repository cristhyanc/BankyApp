using FreshMvvm;
using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace BankyApp
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class AboutPageModel : FreshBasePageModel
    {
        public AboutPageModel()
        {         

        }

        public ICommand OpenWebCommand { get; }
    }
}
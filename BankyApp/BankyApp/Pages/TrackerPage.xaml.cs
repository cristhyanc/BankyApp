using BankyApp.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BankyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrackerPage : ContentPage
    {
        public TrackerPage()
        {
            InitializeComponent();
        }
    }

    public class DataMarkerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null && parameter.ToString() == "Label")
            {
                if (value is List<object>)
                {
                    return "Others";
                }
                else
                {
                    if (value != null)
                    {
                        return (value as TrackerCategory).Description;
                    }
                }
            }
            else
            {
                if (value is List<object>)
                {
                    return (value as List<object>).Sum(item => (item as TrackerCategory).Percentage).ToString() + "%";
                }
                else
                {
                    if (value != null)
                    {
                        return (value as TrackerCategory).Percentage  + "%";
                    }
                }
            }
            return null;
        }

       

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

      
    }

}


﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BankyApp.UserControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountCardCell : ContentView
    {
        public AccountCardCell()
        {
            InitializeComponent();
        }
    }
}
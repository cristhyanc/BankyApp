﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BankyApp.Services;
using FreshMvvm;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace BankyApp
{
    public partial class App : Xamarin.Forms.Application
    {

        public App()
        {
            try
            {
                Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTU5MTk4QDMxMzcyZTMzMmUzMGFvd0UvK2ZtUm5LSXYxRE9Rc3NvZnBOUFZqTHJqWkF2WVFKa1JVRENETFk9");
                InitializeComponent();

               // Page page = new BankyApp.MainPage();
               //page.BindingContext = new MainPageModel();
                //  var mainPage = new FreshNavigationContainer(page);

                var mainPage = new FreshTabbedNavigationContainer();


                // mainPage.On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
                //mainPage.UnselectedTabColor = Color.Black;
                //mainPage.SelectedTabColor = Color.DodgerBlue;
                mainPage.AddTab<TrackerPageModel>("Tracker", null);
                mainPage.AddTab<AccountsPageModel>("Accounts", null);
                mainPage.AddTab<AboutPageModel>("About", null);
                mainPage.AddTab<ContactPageModel>("Contact", null);
               

                MainPage = mainPage;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

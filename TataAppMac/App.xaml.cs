﻿using TataAppMac.Models;
using TataAppMac.Serviices;
using TataAppMac.Views;
using Xamarin.Forms;
using System;
using TataAppMac.ViewModels;

namespace TataAppMac
{
    public partial class App : Application
    {
        #region Attributes
        private DataService dataService; 
        #endregion

        #region Properties
        public static NavigationPage Navigator { get; internal set; }
        #endregion

        #region Constructors
        public App()
        {
            InitializeComponent();

            dataService = new DataService();

            var employee = dataService.First<Employee>(false);

            if (employee != null &&
                employee.IsRemembered &&
                employee.TokenExpires > DateTime.Now)
            {
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Employee = employee;
				MainPage = new MasterPage();
			}
            else
            {
                MainPage = new LoginPage();
            }
        }
        #endregion

        #region Methods
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
        #endregion
    }
}

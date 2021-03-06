﻿namespace TataAppMac.ViewModels
{
    using System.Collections.ObjectModel;
	using System.Windows.Input;
	using GalaSoft.MvvmLight.Command;
	using TataAppMac.Models;
	using TataAppMac.Serviices;

	public class MainViewModel
    {
        #region Attributes
        NavigationService navigationService;
        #endregion

        #region Properties
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }

        public Employee Employee
        {
            get;
            set;
        }

        public LoginViewModel Login
        {
            get;
            set;
        }

        public TimesViewModel Times
        {
            get;
            set;
        }

        public NewTimeViewModel NewTime
        {
            get;
            set;
        }

        public LocationsViewModel Locations
        {
            get;
            set;
        }

        public EmployeesViewModel Employees
        {
            get;
            set;
        }

        public EmployeeDetailViewModel EmployeeDetail
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;

            navigationService = new NavigationService();

            Menu = new ObservableCollection<MenuItemViewModel>();
            Login = new LoginViewModel();
            LoadMenu();
        }
		#endregion

		#region Singleton
		private static MainViewModel instance;

		public static MainViewModel GetInstance()
		{
			if (instance == null)
			{
				instance = new MainViewModel();
			}

			return instance;
		}
		#endregion

		#region Methods
		void LoadMenu()
        {
            Menu.Add(new MenuItemViewModel
            {
                Title = "Register Time",
                Icon = "ic_access_alarms.png",
                PageName = "TimesPage",
            });

            Menu.Add(new MenuItemViewModel
            {
                Title = "Employess",
                Icon = "ic_people_outline.png",
                PageName = "EmployeesPage",
            });

            Menu.Add(new MenuItemViewModel
            {
                Title = "Locations",
                Icon = "ic_location_on.png",
                PageName = "LocationsPage",
            });

            Menu.Add(new MenuItemViewModel
            {
                Title = "Close Sesion",
                Icon = "ic_exit_to_app.png",
                PageName = "LoginPage",
            });
        }
        #endregion

        #region Commands
        public ICommand NewTimeCommand
        {
            get { return new RelayCommand(GoNewTime); }
        }

        async void GoNewTime()
        {
            NewTime = new NewTimeViewModel();
            await navigationService.Navigate("NewTimePage");   
        }
        #endregion
    }
}

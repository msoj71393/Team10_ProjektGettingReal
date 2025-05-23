﻿using DATApp.Core;
using DATApp.MVVM.Model.Classes;
using DATApp.MVVM.View;
using DATApp.MVVM.View.Controls;

namespace DATApp.MVVM.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private static User? _currentUser;
        public static User? CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        private object _currentMenuView;
        public object CurrentMenuView
        {
            get { return _currentMenuView; }
            set { _currentMenuView = value; OnPropertyChanged(); }
        }

        public RelayCommand HomeViewCommand {  get; set; }
        public RelayCommand AdminHomeViewCommand { get; set; }
        public RelayCommand UsersViewCommand { get; set; }
        public RelayCommand ModulesViewCommand { get; set; }
        public RelayCommand SkillsViewCommand { get; set; }
        public RelayCommand NotesViewCommand { get; set; }
        public RelayCommand LoginViewCommand { get; set; }
        public RelayCommand LogoutViewCommand { get; set; }
        public RelayCommand BaseViewCommand { get; set; }
        public RelayCommand MenuViewCommand { get; set; }
        public RelayCommand ClientViewCommand { get; set; }
        public RelayCommand CloseMainWindowCommand { get; set; }

        public MatchesViewModel MatchesVM { get; set; }
        public AdminMatchViewModel AdminMatchVM { get; set; }
        public UsersViewModel UsersVM { get; set; }
        public ModulesViewModel ModulesVM { get; set; }
        public AdminModulesViewModel AdminModulesVM { get; set; }
        public AdminSkillsViewModel AdminSkillsVM { get; set; }
        public SkillsViewModel SkillsVM { get; set; }
        public LoginViewModel LoginVM { get; set; }
        public NotesViewModel NotesVM { get; set; }
        public LoginView LoginView { get; set; }
        public BaseMenuBar BaseMenuView { get; set; }
        public ClientMenuBar ClientMenuView { get; set; }
        public AdminMenuBar AdminMenuView { get; set; }


        public MainWindowViewModel()
        {
            MatchesVM = new MatchesViewModel();
            AdminMatchVM = new AdminMatchViewModel();
            UsersVM = new UsersViewModel();
            ModulesVM = new ModulesViewModel();
            AdminModulesVM = new AdminModulesViewModel();
            AdminSkillsVM = new AdminSkillsViewModel();
            SkillsVM = new SkillsViewModel();
            LoginVM = new LoginViewModel();
            NotesVM = new NotesViewModel();
            BaseMenuView = new BaseMenuBar();
            ClientMenuView  = new ClientMenuBar();
            AdminMenuView  = new AdminMenuBar();
            CurrentUser = new User();

            CurrentMenuView = BaseMenuView;

            if (CurrentUser == null || CurrentUser.IsAdmin == false)
                CurrentView = MatchesVM;
            else
                CurrentView = AdminMatchVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                if (CurrentUser == null || CurrentUser.IsAdmin == false)
                    CurrentView = MatchesVM;
                else
                    CurrentView = AdminMatchVM;
            });

            AdminHomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = AdminMatchVM;
            });

            UsersViewCommand = new RelayCommand(o =>
            {
                CurrentView = UsersVM;
            });

            ModulesViewCommand = new RelayCommand(o =>
            {
                if (CurrentUser == null || CurrentUser.IsAdmin == false)
                    CurrentView = ModulesVM;
                else
                    CurrentView = AdminModulesVM;
            });

            SkillsViewCommand = new RelayCommand(o =>
            {
                if (CurrentUser == null || CurrentUser.IsAdmin == false)
                    CurrentView = SkillsVM;
                else
                    CurrentView = AdminSkillsVM;
            });

            LoginViewCommand = new RelayCommand(o =>
            {
                CurrentView = LoginVM;
            });

            LogoutViewCommand = new RelayCommand(o =>
            {
                CurrentUser = null;
                CurrentView = MatchesVM;
                CurrentMenuView = BaseMenuView;
            });

            NotesViewCommand = new RelayCommand(o =>
            {
                CurrentView = NotesVM;
            });

            MenuViewCommand = new RelayCommand(o =>
            {
                if (CurrentUser == null)
                {
                    CurrentMenuView = BaseMenuView;
                }

                else if (CurrentUser.IsAdmin)
                {
                    CurrentMenuView = AdminMenuView;
                    CurrentView = MatchesVM;
                }
                else if (CurrentUser.IsAdmin == false)
                {
                    CurrentMenuView = ClientMenuView;
                    CurrentView = MatchesVM;
                }                
            });

            ClientViewCommand = new RelayCommand(o =>
            {
                CurrentMenuView = ClientMenuView;
            });

            BaseViewCommand = new RelayCommand(o =>
            {
                CurrentMenuView = BaseMenuView;
            });

            CloseMainWindowCommand = new RelayCommand(o =>
            {
                System.Windows.Application.Current.Shutdown();
            });

        }
    }
}

            
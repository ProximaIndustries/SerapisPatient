﻿using SerapisPatient.Models;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views.SideMenuPages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels
{
    public class MenuViewModel:BaseViewModel
    {
        public MenuViewModel()
        {
            NavigateSettings = new Command(GoToSettingsPage);
            NavigatePayment = new Command(GoToPaymentPage);
            NavigateContact = new Command(GoToContactUsPage);
            NavigateAppointment = new Command(GoToAppointmentHistoryPage);
            NavigateMedication = new Command(GoToMedicationHistoryPage);
            LogoutCommand = new Command(Logout);
        }


        #region Properties

        public Command NavigateSettings { get; set; }
        public Command NavigatePayment { get; set; }
        public Command NavigateContact { get; set; }
        public Command NavigateAppointment { get; set; }
        public Command NavigateMedication { get; set; }
        public Command LogoutCommand { get; set; }

        private string nextAppointment;
        public string NextAppointment
        {
            get
            {
                return nextAppointment="12/09/18";
            }
            set
            {
                nextAppointment = value;
                OnPropertyChanged("NextAppointment");
            }
        }

        private string profileImage="DefaultUserProfile.png";
        public string ProfileImage
        {
            get
            {
                return profileImage;
            }
            set
            {
                profileImage = value;
                OnPropertyChanged("ProfileImage");
            }
        }


        private string userName;
        public string UserName
        {
            get
            {
                return userName="Khanyisani Buthelezi";
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }
        #endregion

        #region Methods
        private async void GoToSettingsPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SettingsPage());
        }

        private async void GoToPaymentPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new PaymentPage());
        }

        private async void GoToContactUsPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new ContactUsPage());
        }

        private async void GoToAppointmentHistoryPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AppointmentHistoryPage());
        }

        private async void GoToMedicationHistoryPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new MedicationHistoryPage());
        }

        private async void Logout()
        {
            await App.Current.MainPage.Navigation.PushAsync(new LoginView());
        }
        #endregion

    }
}

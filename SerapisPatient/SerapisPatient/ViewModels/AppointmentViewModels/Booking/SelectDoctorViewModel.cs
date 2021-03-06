﻿using SerapisPatient.behavious;
using SerapisPatient.Models.Appointments;
using SerapisPatient.Models.Doctor;
using SerapisPatient.Utils;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views.AppointmentFolder.Booking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.BehaviorsPack;

namespace SerapisPatient.ViewModels.AppointmentViewModels.Booking
{
    public class SelectDoctorViewModel : BaseViewModel
    {
        #region Properties
        public Doctor enquiredDoctor;
        public MedicalBuildingModel _medicalBuildingData;
        public ObservableCollection<Doctor> Doctors { get; set; }
        string FullDateAndMonth;
        public ICommand NavigateToConfrimation { get; set; }

        public NotificationRequest NavigateNextPageRequest { get; } = new NotificationRequest();
        #endregion
        public ICommand SelectedCommand => new Command<Doctor>(async selectDoctor =>
        {
        NavigateNextPageRequest.Raise(new SelectedItemEvent { SelectedDoctor = selectDoctor });
             enquiredDoctor = selectDoctor;               
            // MessagingCenter.Send(this, MessagingKeys.Medicalbuilding, doctorname);

            await GoToConfirmation(enquiredDoctor, _medicalBuildingData, FullDateAndMonth);
        });


        //Important
        public SelectDoctorViewModel(MedicalBuildingModel _MedicalBuildingData)
        {
            GenerateDoctorList();
            // NavigateToConfrimation = new Command(async () => await GoToConfirmation());
        }

        private void GenerateDoctorList()
        {
            Doctors = new ObservableCollection<Doctor>
                  {
                    new Doctor{ LastName = "Zulu ", University="MBchB(Ukzn)",ProfileImageUrl="userplaceholder.png" },
                    new Doctor{ LastName = "Duma ", University="MBchB(UWC),FC Orth(SA),Mmed Ortho(Natal)",ProfileImageUrl="userplaceholder.png"},
                    new Doctor{ LastName = "Moody ", University="MBchB(Wits)",ProfileImageUrl="userplaceholder.png"},
                    new Doctor{ LastName = "McGhee ", University="MBchB(Stellenbosch)",ProfileImageUrl="userplaceholder.png"},
                    new Doctor{ LastName = "Naidoo", University="MBchB(Ukzn)",ProfileImageUrl="userplaceholder.png"},
                    new Doctor{ LastName = "Ngwenya ", University="MBchB(UFS)",ProfileImageUrl="userplaceholder.png"},
                    new Doctor{ LastName = "Miller", University="MBchB(UWC),FC Orth(SA),Mmed Ortho(Natal)",ProfileImageUrl="userplaceholder.png"},
                    new Doctor{ LastName = "Ronaldo ", University="MBchB(Wits)",ProfileImageUrl="userplaceholder.png"},
                    new Doctor{ LastName = "Buthelezi ", University="MBchB(Stellenbosch)",ProfileImageUrl="userplaceholder.png"},
                    new Doctor{ LastName = "Moodley", University="MBchB(Ukzn)",ProfileImageUrl="userplaceholder.png"},
                    new Doctor{ LastName = "Matsoso ", University="MBchB(UP)",ProfileImageUrl="userplaceholder.png"},
                    new Doctor{ LastName = "Ngcobo ", University="MBchB(Stellenbosch)",ProfileImageUrl="userplaceholder.png"},
                    new Doctor{ LastName = "Muller", University="MBchB(UWC),FC Orth(SA),Mmed Ortho(Natal)",ProfileImageUrl="userplaceholder.png"},
                    
            };
        }

        private async Task GoToConfirmation(Doctor enquiredDoctor, MedicalBuildingModel _medicalBuildingData, string FullDateAndMonth )
        {
            //This sends the message of itemSelected       
            await App.Current.MainPage.Navigation.PushAsync(new ConfirmBooking(enquiredDoctor, _medicalBuildingData, FullDateAndMonth), true);
        }
    }
}

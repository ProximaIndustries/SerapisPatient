﻿
using CarouselView.FormsPlugin.Abstractions;
using MongoDB.Bson;
using SerapisPatient.Models;
using SerapisPatient.Models.Appointments;
using SerapisPatient.Models.Patient;
using SerapisPatient.Models.Practices;
using SerapisPatient.Services;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views.AppointmentFolder.Booking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.BehaviorsPack;

namespace SerapisPatient.ViewModels.AppointmentViewModels
{

    public class MedicalBuildingViewModel : BaseViewModel
    {

        #region Properties
        private readonly APIServices _apiServices = new APIServices();
        //MockData List
        
        public MedicalBuildingModel _MedicalBuildingData;
        public NotificationRequest NavigateNextPageRequest { get; } = new NotificationRequest();
        public Command NavigateToHomePageCommand { get; set; }
        public ICommand ItemSelected { get; set; }

        private List<MedicalBuildingModel> _practices;

        public MedicalBuildingModel SelectedItem
        {
            get { return GetValue<MedicalBuildingModel>(); }
            set { SetValue(value); }
        }

     
        private string title;
        public string Title 
        {
            get
            {
                return title;
            }
            set
            {
                title = value;

                RaisePropertyChanged(nameof(Title));
            }
        }
        private string practicename;
        public string PracticeName
        {
            get
            {
                return practicename;
            }
            set
            {
                practicename = value;
                RaisePropertyChanged(nameof(PracticeName));
            }
        }

        private string icon;
        public string Icon
        {
            get
            {
                return icon;
            }
            set
            {
                icon = value;

                RaisePropertyChanged(nameof(Icon));
            }

        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;

                RaisePropertyChanged(nameof(Description));
            }

        }

        #region Khanyisani carousel code
        public ICommand SelectedPractice { get; set; }
        public Command selectedItem {get; set; }

        private int myPostion;

        public int MyPostion
        {
            get
            {
                return myPostion;
            }
            set
            {
                myPostion = value;
                OnPropertyChanged("MyPostion");
                myPostion = value;
            }
        }

        private ObservableCollection<PracticeDto> practiceList;

        public ObservableCollection<PracticeDto> PracticesList
        {
            get
            {
                return practiceList;
            }
            set
            {
                practiceList = value;
            }
        }

        private void MedicalBuildingViewInit(SpecilizationModel _specilizationData)
        {
            var myCarsoul = new CarouselViewControl();

            Title = _specilizationData.Title;

            Icon = _specilizationData.Icon;

            Description = _specilizationData.Description;

            myCarsoul.ItemsSource = PracticesList;
            myCarsoul.Position = 0;
            //SelectedPractice = new Command(async () => HandleNavigation());
        }

        #endregion

        #endregion

        public MedicalBuildingViewModel(SpecilizationModel _specilizationData)
        {

            selectedItem = new Command<MedicalBuildingModel>(args => 
            {
                _MedicalBuildingData = args;
                HandleNavigation(_MedicalBuildingData);
            });

            LoadRealData();
            
            MedicalBuildingViewInit(_specilizationData);
            PracticeName = "Default Value";
            //LoadDummyData();
        }


        public MedicalBuildingViewModel()
        {
            
        }
        public void LoadDummyData()
        {

            PracticesList = new ObservableCollection<PracticeDto>()
            {
               new PracticeDto
                 {
                     DistanceFromPractice=7.8,
                     ContactPractice = new PracticeContact
                     {
                         PracticeTelephoneNumber = "031 701 456 43"
                     },
                     //Id=ObjectId.Parse("5bc9bd861c9d4400001badf1"),
                     NumOfPatientsInPractice=5,
                     PracticeName="Grey's Hospital",
                     PracticePicture="MedicrossPinetown.jpg",
                     OperatingTime="08h00-17h00"
                 },
                 new PracticeDto
                 {
                     DistanceFromPractice=7,
                     ContactPractice = new PracticeContact
                     {
                         PracticeTelephoneNumber = "031 701 456 43"
                     },
                     //Id=ObjectId.Parse("5bc9bde81c9d4400001badf2"),
                     NumOfPatientsInPractice=10,
                     PracticeName="Crompton Hospital",
                     PracticePicture="MedicrossPinetown.jpg",
                     OperatingTime="08h00-17h00"
                 },
                 new PracticeDto
                 {
                     DistanceFromPractice=6,

                     ContactPractice = new PracticeContact
                     {
                         PracticeTelephoneNumber = "031 701 456 43"
                     },
                     //Id=ObjectId.Parse("5bc9bd741c9d4400001badf0"),
                     NumOfPatientsInPractice=10,
                     PracticeName="Groote Schuur Hospital",
                     PracticePicture="MedicrossPinetown.jpg",
                     OperatingTime="08h00-17h00"
                 }
            };
        }
        public void HandleNavigation(MedicalBuildingModel _MedicalBuildingData)
        {
            App.Current.MainPage.Navigation.PushAsync(new SelectBooking(_MedicalBuildingData), true);
        }

        public async void LoadRealData()
        {
            await GetAllPracticesAsync();
        }
       public async Task<ObservableCollection<PracticeDto>> GetAllPracticesAsync()
       {
            try
            {
                IsBusy = true;
                PracticesList = new ObservableCollection<PracticeDto>();

                var Practices = await _apiServices.GetAllMedicalBuildingsAsync();

                foreach (var _practice in Practices)
                {

                    PracticesList.Add(_practice);
                }
                
            }
            catch(Exception ex)
            {
                
            }
            IsBusy = false;
            return PracticesList;
        }
           


        public void ItemSelected_ExecuteCommand(object state)
        {
            SelectedItem = state as MedicalBuildingModel;
        }
    }
}

﻿using SerapisPatient.ViewModels;
using SerapisPatient.Views.AppointmentFolder.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views.MainViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainView : ContentPage
	{
        MainViewModel viewModel;
        public MainView ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new MainViewModel();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            appointmentframe.FadeTo(0.3, 500);
            appointmentframe.FadeTo(1, 500);
             appointmentframe1.FadeTo(0.3, 500);
            appointmentframe1.FadeTo(1, 500);

            appointmentframe2.FadeTo(0.3, 500);
            appointmentframe2.FadeTo(1, 500);
        }
        

       
    }
}
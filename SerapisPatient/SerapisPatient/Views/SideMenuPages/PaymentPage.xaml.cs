﻿using SerapisPatient.ViewModels.SideMenuViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views.SideMenuPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaymentPage : ContentPage
	{
        PaymentPageViewModel viewModel;

        public PaymentPage ()
		{
			InitializeComponent ();
            viewModel = new PaymentPageViewModel();
            BindingContext = viewModel;
		}
	}
}
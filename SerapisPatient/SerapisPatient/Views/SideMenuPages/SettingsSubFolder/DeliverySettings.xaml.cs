﻿using SerapisPatient.ViewModels.SideMenuViewModel.SettingsSubFolderViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views.SideMenuPages.SettingsSubFolder
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DeliverySettings : ContentPage
	{
        DeliverySettingsViewModel viewModel;

        public DeliverySettings ()
		{
			InitializeComponent ();
            viewModel = new DeliverySettingsViewModel();
            BindingContext = viewModel;
		}
	}
}
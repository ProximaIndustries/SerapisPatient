﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Cells
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CellWithSubTitle : ViewCell
	{
		public CellWithSubTitle ()
		{
			InitializeComponent ();
		}
	}
}
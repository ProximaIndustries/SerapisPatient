﻿using SerapisPatient.Models.Appointments;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SerapisPatient.ViewModels.AppointmentViewModels.Booking
{
    public class TimePickerPopUpVM
    {
        public ObservableCollection<BookedTimes> AvaliableTime { get; private set; }
        public TimePickerPopUpVM()
        {
            GenerateTimeList();
        }

        

        private void GenerateTimeList()
        {
            AvaliableTime = new ObservableCollection<BookedTimes>
                  {
                   new BookedTimes{ Time =new DateTime(2018,11,28,8,30,0) },
                   new BookedTimes{ Time =new DateTime(2018,11,28,9,00,0) },
                   new BookedTimes{ Time =new DateTime(2018,11,28,9,30,0) },
                   new BookedTimes{ Time =new DateTime(2018,11,28,10,00,0) },
                   new BookedTimes{ Time =new DateTime(2018,11,28,10,30,0) },
                   new BookedTimes{ Time =new DateTime(2018,11,28,11,00,0) },
                   new BookedTimes{ Time =new DateTime(2018,11,28,11,30,0) },
                   new BookedTimes{ Time =new DateTime(2018,11,28,12,00,0) },
                   new BookedTimes{ Time =new DateTime(2018,11,28,12,30,0) },
                   new BookedTimes{ Time =new DateTime(2018,11,28,13,00,0) },
                   new BookedTimes{ Time =new DateTime(2018,11,28,13,30,0) },
                   new BookedTimes{ Time =new DateTime(2018,11,28,14,00,0) },
                   new BookedTimes{ Time =new DateTime(2018,11,28,15,30,0) },
                   new BookedTimes{ Time =new DateTime(2018,11,28,16,00,0) },
                   new BookedTimes{ Time =new DateTime(2018,11,28,16,30,0) },
                   new BookedTimes{ Time =new DateTime(2018,11,28,17,00,0) },
                  };
        }

        //to be used in the future just need to know how will the data be stored
        public void ConverttoHours()
        {
            // DateTime time = new DateTime(2018, 11, 28, 17, 30, 0);
            // string newTime = time.ToString("HH:mm");

            //or 

            DateTime dt = new DateTime(2009, 6, 22, 10, 0, 0);  //Date 6/22/2009 10:00:00 AM
            string time1 = dt.ToString("hh:mm tt");

            var wholeDate = DateTime.Parse("6/22/2009 10:00:00 AM");
            var time = wholeDate - wholeDate.Date;
        }
    }
}

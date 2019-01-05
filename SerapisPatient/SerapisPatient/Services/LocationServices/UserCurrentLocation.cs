﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions.Abstractions;
using SerapisPatient.Models;

namespace SerapisPatient.Services.LocationServices
{
    public class UserCurrentLocation : ILocateUser
    {
        public double UserLatitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double UserLongitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        private readonly double GpsAccurecy=10;

        public UserCurrentLocation()
        {
            
        }

        public async Task<Position> GetCurrentLocationAsync()
        {
            var locator = CrossGeolocator.Current;

            //Set the accurecy of the gps locator
            locator.DesiredAccuracy = GpsAccurecy;

            Position userPostion = new Position();


            try
            {

                if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
                {
                    return null;
                }
                else
                {
                    userPostion = await locator.GetPositionAsync(TimeSpan.FromSeconds(2), null, false);

                    return userPostion;
                }

            }
            catch (Exception ex)
            {

            }

            return userPostion;
        }


        public async Task<Position> CacheUserLocation(Position cachedUserLocation)
        {
            cachedUserLocation = null;

            var locator = CrossGeolocator.Current;

            locator.DesiredAccuracy = GpsAccurecy;

            cachedUserLocation = await locator.GetLastKnownLocationAsync();

            if (cachedUserLocation != null)
            {
                return cachedUserLocation;
            }
            else
            {
                return null;
            }
        }
    }
}

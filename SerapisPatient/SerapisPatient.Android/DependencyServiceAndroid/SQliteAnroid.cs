using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SerapisPatient.Droid.DependencyServiceAndroid;
using SerapisPatient.Services.Local;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQliteAnroid))]
namespace SerapisPatient.Droid.DependencyServiceAndroid
{
    public class SQliteAnroid : Isqlite
    {
        public SQLiteConnection GetConnection()
        {
            var dbase = "medicalfarm";
            var dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dbpath, dbase);
            var connection = new SQLiteConnection(path);
            return connection;

        }
    }
}
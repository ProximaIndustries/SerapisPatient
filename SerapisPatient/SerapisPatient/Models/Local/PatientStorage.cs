using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models.Local
{
    public class PatientStorage
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string MongoDb { get; set; }//
        [NotNull]
        public string SocialID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string token { get; set; }
        public string expirydate { get; set; }
    }
}

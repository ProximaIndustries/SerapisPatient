﻿using SerapisPatient.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models.MedicalDetails
{
    public class Medication
    {
        public string DrugCode { get; set; }
        public string Dosage { get; set; }
        public string MedicationName { get; set; }
        public string BrandName { get; set; }
        public MedicationType MedicationTypeValue { get; set; }
    }
}

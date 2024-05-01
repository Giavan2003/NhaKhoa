using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaKhoa.Appointments
{
    internal class AppointmentInfo
    {
        public DateTime StartDateTime { get; set; }
        public string Description { get; set; }
        public string PatientName { get; set; }
        public string Status { get; set; }

        // Constructor
        public AppointmentInfo(DateTime startDateTime, string description, string patientName, string status)
        {
            StartDateTime = startDateTime;
            Description = description;
            PatientName = patientName;
            Status = status;
        }
    }
}

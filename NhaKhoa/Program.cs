using NhaKhoa.Appointments;
using NhaKhoa.MEDICINE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhaKhoa
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LoginForm());
            //Application.Run(new ShowAppointment());
            //Application.Run(new ApmForEmployees());
             Application.Run(new AdminMainForm());
        }
    }
}

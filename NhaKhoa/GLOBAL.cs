using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaKhoa
{
    public static class GLOBAL
    {
        public static int GlobalPatinetID { get; private set; }
        public static void SetGlobalUserIId(int PatinetID)
        {
            GlobalPatinetID = PatinetID;
        }
    }
}

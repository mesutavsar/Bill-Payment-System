using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill_Payment_System
{
    public static class Constant
    {
        // const ile değiştirilemez yaptık. New ile çoğaltılamaz.Static class  
        public static string BillPaid = "Ödendi";
        public const string BillNotPaid = "Ödenemedi";
    }
}

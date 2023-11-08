using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill_Payment_System
{
    public class CashPayment : Payment
    {
        public void MakePayment(double amount)
        {
            Console.WriteLine("Nakit ödeme yapıldı: " + amount + " TL");
            Console.WriteLine();
            // Nakit ödeme işlemleri burada gerçekleştirilir.
        }
    }
}

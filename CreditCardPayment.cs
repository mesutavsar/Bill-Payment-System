using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill_Payment_System
{
    public class CreditCardPayment : Payment
    {
        public void MakePayment(double amount)
        {
            Console.WriteLine("Kredi kartı ile ödeme yapıldı: " + amount + " TL");
            Console.WriteLine();
            // Kredi kartı ile ödeme işlemleri burada gerçekleştirilir.
        }
    }
}

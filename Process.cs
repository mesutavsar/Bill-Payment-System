using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill_Payment_System
{
    public class Process
    {
        public static void MakePayment(Payment paymentMethod, List<BillClass> billList)
        {
            // Ödeme yapılacak faturaları döngü ile kontrolü
            foreach (var bill in billList)
            {
                if (bill.DeptAmount > 0)
                {
                    Console.WriteLine($"Borcu olan kişi: {bill.FullName}");
                    paymentMethod.MakePayment(bill.DeptAmount);
                    bill.DeptAmount = 0; // Borcu sıfırla
                }
            }
        }
    }
}

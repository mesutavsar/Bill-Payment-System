using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill_Payment_System
{   

    public interface Payment
    {
        void MakePayment(double amount);
    }

}

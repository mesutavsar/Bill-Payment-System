using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill_Payment_System
{
    public class BillClass
    {
        private string fullName;
        private string tcNumber;
        private string billType;
        private double deptAmount;

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public string TcNumber
        {
            get { return tcNumber; }
            set 
            { 
                
                if (value.Length == 11)
                {
                    tcNumber = value;
                }            
                
            }




        }

        public string BillType
        {
            get { return billType; }
            set { billType = value; }
        }

        public double DeptAmount
        {
            get { return deptAmount; }
            set { deptAmount = value; }
        }

        public BillClass(string fullName, string tcNumber, string billType, double deptAmount)
        {
            this.FullName = fullName;
            this.TcNumber = tcNumber;
            this.BillType = billType;
            this.DeptAmount = deptAmount;
        }

        //boş constructor tanımladık hata almamak için
        public BillClass()
        {
        }
    }
}

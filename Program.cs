using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO; 

namespace Bill_Payment_System
{
    internal class Program
    {       
        static void Main(string[] args)
        {
            Dictionary<string, List<BillClass>> billGroup = new Dictionary<string, List<BillClass>>();
            List<BillClass> paidBills = new List<BillClass>();
            List<BillClass> unPaidBills = new List<BillClass>();           

            string newFilePath = "example.txt";

            // Create a StreamWriter to write to the file
            using (StreamWriter writer = new StreamWriter(newFilePath))
            {
                // Write lines to the file
                writer.WriteLine("This is the first line.");
                writer.WriteLine("This is the second line.");
                writer.WriteLine("This is the third line.");
                // You can continue to write more lines as needed
            }

            Console.WriteLine("File write operation completed.");

            Console.WriteLine();
                Console.Write("Fatura Ödeme Sistemi\n\n");

            while (true)
            {
                Console.Write("Ad Soyad: ");
                string fullName = Console.ReadLine();

                string tcNumber;
                do
                {
                    Console.Write("TC Kimlik Numarası: ");
                    tcNumber = Console.ReadLine();
                    if (tcNumber.Length != 11)
                    {
                        Console.Write("T.C Kimlik Numarası 11 Haneli Olmalıdır!\n");
                    }
                }
                while (tcNumber.Length != 11);

                Console.Write("Fatura Türü: ");
                string billType = Console.ReadLine();

                Console.Write("Borç Tutarı: ");
                double debtAmount = double.Parse(Console.ReadLine());

                if (billGroup.ContainsKey(tcNumber))
                {
                    billGroup[tcNumber].Add(new BillClass(fullName, tcNumber, billType, debtAmount));
                }
                else
                {
                    List<BillClass> newBillGroup = new List<BillClass> { new BillClass(fullName, tcNumber, billType, debtAmount) };
                    billGroup.Add(tcNumber, newBillGroup);
                }

                Console.Write("Fatura kaydedildi.\n\n");
                Console.Write("Başka bir fatura eklemek ister misiniz? (E/H): ");
                string answerForContinue = Console.ReadLine();
                Console.WriteLine();

                if (answerForContinue.ToLower() != "e")
                {
                    break;
                }
            }

            Console.WriteLine("\n\nFatura Bilgileri:\n");
                foreach (var keyTcNumber in billGroup)
                {
                    double totalDebt = 0;

                    Console.WriteLine("TC Kimlik Numarası: " + keyTcNumber.Key);
                    foreach (BillClass bill in keyTcNumber.Value)
                    {
                        Console.WriteLine("Ad Soyad: " + bill.FullName);
                        Console.WriteLine("Fatura Türü: " + bill.BillType);
                        Console.WriteLine("Borç Tutarı: " + bill.DeptAmount);
                        Console.WriteLine();

                        totalDebt += bill.DeptAmount;
                    }

                    Console.WriteLine("Toplam Borç: " + totalDebt);
                    Console.WriteLine();

                    Console.Write("Bu borcu ödemek ister misiniz? (E/H): ");
                    string payOption = Console.ReadLine();

                    if (payOption.ToLower() == "e")
                    {
                        Console.Write("Ödemenizi Kredi Kartıyla Yapmak İçin 1, Nakit Yapmak İçin 2 Yazınız : ");
                        int paymentMethod = Convert.ToInt32(Console.ReadLine());

                        Payment payment = null;
                        if (paymentMethod == 1)
                        {
                            payment = new CreditCardPayment();
                        }
                        else
                        {
                            payment = new CashPayment();
                        }

                        // Borcu olanları öde
                        Process.MakePayment(payment, keyTcNumber.Value);

                        // Borcu ödenenleri ve ödenmeyenleri ayır
                        foreach (BillClass bill in keyTcNumber.Value)
                        {
                            if (bill.DeptAmount == 0)
                            {
                                paidBills.Add(bill);
                            }
                        }
                    }
                    else
                    {
                        foreach (BillClass bill in keyTcNumber.Value)
                        {
                            if (bill.DeptAmount != 0)
                            {
                                unPaidBills.Add(bill);
                            }
                        }
                    }
                }

                // Borcu ödenenleri listeleyin
                Console.WriteLine("\nBORCU ÖDENENLER: ");
                foreach (BillClass bill in paidBills)
                {
                    Console.WriteLine(bill.FullName);
                }

                // Borcu ödenmeyenleri listeleyin
                Console.WriteLine("\nBORCU ÖDENMEYENLER: ");
                foreach (BillClass bill in unPaidBills)
                {
                    Console.WriteLine(bill.FullName);
                }

                Constant.BillPaid = "paid";
            }
        }
    }

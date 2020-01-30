using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Console;
using System.Linq;



namespace Information_System
{

    class Calculate_implementer : ICalculate
    {
        public static double deposit;
        public string WriteFullLine(string value) // color every line
        {

            BackgroundColor = ConsoleColor.Blue;
            ForegroundColor = ConsoleColor.Yellow;
            return value;
        }

        public double Calculate_balance() //balance based on inserted days in a month 
        {
            double paycheck, weight_loaded_truck, weight_empty_truck, price_kg, total_weight;
            int num_in_month;

            WriteLine("Insert available amount of cash per month: ");
            WriteLine();
            while (!double.TryParse(ReadLine(), out deposit))
            {
                WriteLine();
                WriteLine("You must enter a number, please try again");
                WriteLine();
            }
            WriteLine();

            WriteLine("insert number of days in a month: ");
            WriteLine();

            while (!int.TryParse(ReadLine(), out num_in_month) || num_in_month > 31)
            {
                WriteLine();
                WriteLine("You must enter a number and it can not exceed 31, please try again");
                WriteLine();
            }


            WriteLine();


            for (int i = 1; i <= num_in_month; i++)
            {


                WriteLine("Insert truck weight: ");
                WriteLine();
                while (!double.TryParse(ReadLine(), out weight_loaded_truck))
                {
                    WriteLine();
                    WriteLine("You must enter a number, please try again");
                    WriteLine();
                }
                WriteLine();

                WriteLine("Insert loaded truck: ");
                WriteLine();
                while (!double.TryParse(ReadLine(), out weight_empty_truck))
                {
                    WriteLine();
                    WriteLine("You must enter a number, please try again");
                    WriteLine();
                }
                WriteLine();

                WriteLine("Insert price(dinara) per kg: ");
                WriteLine();
                while (!double.TryParse(ReadLine(), out price_kg))
                {
                    WriteLine();
                    WriteLine("You must enter a number, please try again");
                    WriteLine();
                }
                WriteLine();
                total_weight = weight_loaded_truck - weight_empty_truck; //weight of fruits per one truck
                paycheck = price_kg * total_weight; //per one truck

                WriteLine($"paycheck is: ({paycheck}) dinara");
                deposit -= (-paycheck);

                WriteLine("Deposit is: " + deposit);
                if (deposit < 0) WriteLine("Debt(balance) is: " + deposit);

                else WriteLine("Demand(balance) is: " + deposit);
            }

            WriteLine("Balance is: " + deposit);
            WriteLine();


            string path = @"\Information_System_Cold_Storage\Balance";
            string fileName = "Calculate balance.txt";
            string pathString = Path.Combine(path, fileName);

            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            var Timestamp = new DateTimeOffset(DateTime.Now);

            //create directory on a given path and create .txt file with input data in it
            try
            {

                if (!Directory.Exists(path))
                {
                    directoryInfo.Create();
                    using (StreamWriter writer = new StreamWriter(pathString))
                    {
                        if (deposit < 0)
                            writer.WriteLine("Balance is in debt: " + deposit + " dinara " + " time " + Timestamp + "\n");
                        else writer.WriteLine("Balance is in demand: " + deposit + " dinara " + " time "  + Timestamp);
                    }

                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(pathString))
                    {
                        if (deposit < 0)
                            writer.WriteLine("Balance is in debt: " + deposit + " dinara " + " time " + Timestamp + "\n");
                        else writer.WriteLine("Balance is in demand: " + deposit + " dinara " + " time "  + Timestamp);

                    }
                }
            }
            catch (IOException e)
            {
                WriteLine("An error occurred: {0}", e.Message);
            }


            return deposit;

        }


        public double Database_Calculate() //use LINQ to Entities to query the data

        {

            using (var db = new Input_Data())
            {
                Model_Calculate input = new Model_Calculate
                {
                    Balance = deposit
                };

                db.Calculate.Add(input);

                db.SaveChanges();
                var query = from b in db.Calculate
                            orderby b.Balance
                            select b;
                WriteLine("Database is updated:");
                foreach (var b in query)
                {
                    WriteLine($"Balance is: {b.Balance}, ID={b.ID}");//Balance based on inserted days in a month 
                }
                WriteLine("Press a key to exit...");
                ReadKey();
            }
            return deposit;

        }

    }
}


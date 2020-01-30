using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using static System.Console;

namespace Information_System
{
    public class Manufacturer_implementer : IProduct
    {

        public static string place;

        public static string manufacturer;

        public static string fruit;

        public static int klass;

        public static int price;


        public string Copyright_protected()
        {

            string a = "Information System of Cold Storage by Danijel Tomic all rights reserved 2020";
            WriteLine(a + "\n");
            WriteLine("Press Enter in an empty line to continue...\n");
            string line;
            line = ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                WriteLine(string.Format("You entered: {0}, press enter to continue...", line));
                WriteLine();
                line = ReadLine();

            }

            return a;
        }

        public string Input_Information()
        {

            string path = @"\Information_System_Cold_Storage\Input_Information";
            string fileName = "Input Information.txt";
            string pathString = Path.Combine(path, fileName);

            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            var Timestamp = new DateTimeOffset(DateTime.Now);


            WriteLine("Input name of the place\n");
            place = ReadLine();
            bool isDigitPresent = place.Any(c => char.IsDigit(c));

            while (isDigitPresent == true)
            {
                WriteLine();
                WriteLine("You must enter a word that contains only letter, please try again\n");
                place = ReadLine();
                isDigitPresent = place.Any(c => char.IsDigit(c));
            }
            WriteLine();


            WriteLine("Input name of the manufacturer\n");

            manufacturer = ReadLine();
            WriteLine();


            WriteLine("Input name of the fruit\n");
            fruit = ReadLine();
            bool isDigitPresent1 = fruit.Any(c => char.IsDigit(c));

            while (isDigitPresent == true)
            {
                WriteLine();
                WriteLine("You must enter a word that contains only letter, please try again\n");
                fruit = ReadLine();
                isDigitPresent = fruit.Any(c => char.IsDigit(c));
            }
            WriteLine();


            WriteLine("Input class of the fruit\n");
            int klass;

            while (!int.TryParse(ReadLine(), out klass))
            {
                WriteLine();
                WriteLine("You must enter a number, please try again\n");

            }
            WriteLine();


            WriteLine("Input price\n"); //price per kg


            while (!int.TryParse(ReadLine(), out price))
            {
                WriteLine();
                WriteLine("You must enter a number, please try again\n");

            }
            WriteLine();


            WriteLine("Input name and surname\n");
            string name_S = ReadLine();
            isDigitPresent = name_S.Any(c => char.IsDigit(c));

            while (isDigitPresent == true)
            {
                WriteLine();
                WriteLine("You must enter a word that contains only letter, please try again\n");
                name_S = ReadLine();
                isDigitPresent = name_S.Any(c => char.IsDigit(c));
            }

            WriteLine();
            WriteLine("input id\n");

            string id = ReadLine();
            WriteLine();


            //create directory on a given path and create .txt file with input data in it
            try
            {

                if (!Directory.Exists(path))
                {
                    directoryInfo.Create();
                    using (StreamWriter writer = new StreamWriter(pathString))
                    {
                        writer.WriteLine("Place and the manufacturer:" + place + ", " + manufacturer + " time " + Timestamp + "\n");
                        writer.WriteLine("Fruit, klass and price are: " + fruit + ", " + klass + ", " + price + " time " + " " + Timestamp + "\n");
                        writer.WriteLine("Name, surname and id are: " + name_S + " " + id + " time " + Timestamp + "\n");
                    }
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(pathString))
                    {
                        writer.WriteLine("Place and the manufaturer:" + place + ", " + manufacturer + " time " + Timestamp + "\n");
                        writer.WriteLine("Klass and price are: " + fruit + ", " + klass + ", " + price + " time " + Timestamp + "\n");
                        writer.WriteLine("Name, surname and id are: " + name_S + ", " + id + " time " + Timestamp + "\n");
                    }
                }

            }
            catch (IOException e)
            {
                WriteLine("An error occurred: {0}", e.Message);
            }

            WriteLine("Place and the manufaturer are: " + place + ", " + manufacturer + " time " + Timestamp + "\n");
            WriteLine("Klass and price are: {0} i {1}, time: {2}", fruit, klass, price, Timestamp + "\n");
            WriteLine("Name, surname and id are: " + name_S + " time " + id + "\n");

            return place;

        }


        public string Database_Info() //use LINQ to Entities to query the data

        {

            string a = "";


            using (var db = new Input_Data())
            {
                Model_Input input = new Model_Input
                {
                    Name_Manufacturer = manufacturer,
                    Name_place = place,
                    Fruit = fruit,
                    Class = klass,
                    Price = price
                };
                db.Input.Add(input);


                db.SaveChanges();
                var query = from b in db.Input
                            orderby b.Name_Manufacturer
                            select b;
                WriteLine("Database is updated:");
                foreach (var b in query)
                {
                    WriteLine($"Name of manufacturer: {b.Name_Manufacturer}, place: {b.Name_place}, fruit: {b.Fruit} class: {b.Class}, price: {b.Price} code={b.Code}");
                }
                WriteLine("Press a key to exit...");
                ReadKey();
            }
            return a;
        }


      }
    }

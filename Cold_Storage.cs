using System;
using System.Collections.Generic;
using System.Text;

namespace Information_System
{

    public abstract class Cold_Storage

    {

        public abstract IProduct_information FactoryMethod();

        public abstract Interface_Calculate FactoryMehodCalculate();


        public string Color()
        {
            string value = "";
            var color = FactoryMehodCalculate();
            var result = color.WriteFullLine(value);
            return result;

        }

        public double Operation_Calculate()
        {
            var product = FactoryMehodCalculate();
            var result = product.Calculate_balance();
            return result;

        }

        public string Operation_Copyright()
        {
            var headline = FactoryMethod();
            var result = headline.Copyright_protected();
            return result;
        }

        public string Operation_Rentsome_Place()
        {
            var product = FactoryMethod();
            var result = product.Input_Information();
            return result;
        }


        public string Copy_to_Database()
        {
            var database = FactoryMethod();
            var result = database.Database_Info();
            return result;
        }

        public double Calculate_to_Database()
        {
            var database = FactoryMehodCalculate();
            var result = database.Database_Calculate();
            return result;

        }
    }
}


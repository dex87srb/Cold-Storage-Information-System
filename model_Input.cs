using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Text;

namespace Information_System
{
   public class Model_Input
    {
      
            public string Name_Manufacturer { get; set; }
            public string Name_place { get; set; }
            public string Fruit { get; set; }
            public int Class { get; set; }
            public int Price { get; set; }           
            [Key] public int Code { get; set; }
            

    }

    public class Model_Calculate
    {
            public double Balance { get; set; }

            [Key] public int ID { get; set; }
    }

    public class Input_Data : DbContext // for manage, create, update and delete the  books table
    {
        public DbSet<Model_Input> Input { get; set; }

        public DbSet<Model_Calculate> Calculate { get; set; }
    }
}

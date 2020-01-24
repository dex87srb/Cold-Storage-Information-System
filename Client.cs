using System;
using System.Collections.Generic;
using System.Text;

namespace Information_System
{
    
    
   class Client
    {
      public void Main()
        {
            ClientCode(new CreatorManufacter());
          
        }

        public void ClientCode(Cold_Storage creator)
        {
           
            creator.Color();
            creator.Operation_Copyright();
            creator.Operation_Rentsome_Place();
            creator.Operation_Calculate();
            creator.Copy_to_Database();
            creator.Calculate_to_Database();
        }
    }

}

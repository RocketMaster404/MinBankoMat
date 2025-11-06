using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinBankoMat
{
   internal class User
   {
      
      public string UserName { get; set; } = string.Empty;
      public int PinCode { get; set; }
      public decimal Balance { get; set; }
      public int ResetCode { get; set; }
      public int AccountNumber { get; set; }
      public bool Admin { get; set; } = false;
      public int CustomerId { get; private set; }
      private static int CustomerIdCount = 1;


      public User()
      {
          
      }
      public User(string userName, int pinCode, decimal balance, int resetCode, int accountNumber)
      {
         UserName = userName;
         PinCode = pinCode;
         Balance = balance;
         ResetCode = resetCode;
         AccountNumber = accountNumber;
         CustomerId = CustomerIdCount++;
         
      }

      

      

      

   }
}

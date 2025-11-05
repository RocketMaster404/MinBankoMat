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

      public User(string userName, int pinCode, decimal balance, int resetCode)
      {
         UserName = userName;
         PinCode = pinCode;
         Balance = balance;
         ResetCode = resetCode;
      }

      public void ShowBalance()
      {
         Console.WriteLine($"{UserName} ditt saldo är: {Balance}");
      }

      

   }
}

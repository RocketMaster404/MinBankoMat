using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinBankoMat
{
   internal class CashManager
   {

      public static void Withdraw(User user)
      {
         Console.Write("Ange beloppet du önskar ta ut: ");
         int withdraw = Inputs.GetUserNumber();
         user.Balance -= withdraw;

      }

      public static void Deposit(User user)
      {
         Console.Write("Ange hur mycket du vill sätta in: ");
         int deposit = Inputs.GetUserNumber();
         user.Balance += deposit;
         Console.WriteLine($"{deposit}Kr har mottagit, nytt saldo {user.Balance}");
      }

      public static void ShowBalance(User user)
      {
         Console.WriteLine($"{user.UserName} ditt saldo är: {user.Balance}");
      }


   }
}

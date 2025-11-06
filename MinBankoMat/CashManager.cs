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

         if(withdraw <= 100)
         {
            Console.WriteLine("Minsta belopp för uttag 100 Kr");
         } else if (withdraw > user.Balance)
         {
            Console.WriteLine($"Du har endast {user.Balance} Kr kvar.");
         } else
         {
            user.Balance -= withdraw;
            Console.WriteLine($"{withdraw} kr har dragits från ditt konto. Nytt saldo: {user.Balance}");
         }

            

      }

      public static void Deposit(User user)
      {
         Console.Write("Ange hur mycket du vill sätta in: ");
         int deposit = Inputs.GetUserNumber();
         if(deposit <= 0)
         {
            Console.WriteLine("Du kan inte ange negativa värden");
         }else if (deposit > 10000)
         {
            Console.WriteLine("Insättningar över 10 000kr behöver gå via kundtjänst");
         }
         else
         {
            user.Balance += deposit;
            Console.WriteLine($"{deposit}Kr har mottagit, nytt saldo {user.Balance}");
         }
        
      }

      public static void ShowBalance(User user)
      {
         Console.WriteLine($"{user.UserName} ditt saldo är: {user.Balance}");
      }


   }
}

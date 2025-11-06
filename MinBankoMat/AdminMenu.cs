using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinBankoMat
{
   internal class AdminMenu
   {
      public static void PrintAdminMenu()
      {
         Console.WriteLine("1) Ta ut pengar");
         Console.WriteLine("2) Sätt in pengar");
         Console.WriteLine("3) Visa Saldo");
         Console.WriteLine("4) Inställningar");
         Console.WriteLine("5) Skapa användare");
         Console.WriteLine("6) Ändra användare");
         Console.WriteLine("7) Logga ut");
      }

      public static void AdminnMenuChoice(User user)
      {
         bool running = true;

         while (running)
         {
            Console.Clear();
            PrintAdminMenu();
            int choice = Inputs.GetNumberMinMax(1, 5);
            switch (choice)
            {
               case 1:
                  Console.Clear();
                  CashManager.Withdraw(user);
                  // Ta ut pengar
                  break;
               case 2:
                  Console.Clear();
                  CashManager.Deposit(user);
                  // Sätt in pengar
                  break;
               case 3:
                  Console.Clear();
                  CashManager.ShowBalance(user);
                  // Visa saldo
                  break;
               case 4:
                  // Inställningar
                  break;
               case 5:
                  //Skapa användare
                  break;
               case 7:
                  running = false;
                  break;

            }
            Console.ReadKey();
         }
      }
   }
}

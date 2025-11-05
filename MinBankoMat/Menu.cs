using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinBankoMat
{
   internal class Menu
   {
      public static void PrintMainMeny()
      {
         Console.WriteLine("1) Ta ut pengar");
         Console.WriteLine("2) Sätt in pengar");
         Console.WriteLine("3) Visa Saldo");
         Console.WriteLine("4) Inställningar");
         Console.WriteLine("5) Logga ut");
      }

      public static void PrintLoginMenu()
      {
         Console.WriteLine("1) Logga in");
         Console.WriteLine("2) Glömt lösenord");
         Console.WriteLine("3) Avsluta");
      }

      public static void LoginChoice()
      {

         int choice = Inputs.GetNumberMinMax(1, 3);
         switch (choice)
         {
            case 1:
               var user = LogInManager.LogIn();
               if (user != null)
               {
                  Console.Clear();

                  MainMenuChoice(user);
               }
               break;
            case 2:
               LogInManager.ResetPassword();
               // Glömt lösenord
               break;
            case 3:
               Console.WriteLine("Programmet avslutas");
               RunProgram.ProgramOn = false;
               break;

         }
      }

      public static void MainMenuChoice(User user)
      {
         bool running = true;

         while (running)
         {
            Console.Clear();
            PrintMainMeny();
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
                  running = false;
                  break;

            }
            Console.ReadKey();
         }
      }



   }
}

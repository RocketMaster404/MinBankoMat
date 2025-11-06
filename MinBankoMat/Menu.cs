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
         Console.WriteLine("4) För över pengar");
         Console.WriteLine("5) Inställningar");
         Console.WriteLine("6) Logga ut");
      }

      public static void PrintLoginMenu()
      {
         Console.WriteLine("1) Logga in");
         Console.WriteLine("2) Glömt lösenord");
         Console.WriteLine("3) Avsluta");
      }

      public static void SettingsMenu()
      {
         Console.WriteLine("1) Mina uppgifter");
         Console.WriteLine("2) Ändra pinkod");
         Console.WriteLine("3) Ändra användarnamn");
         Console.WriteLine("4) Spärra konto");
         Console.WriteLine("5) Tillbaka till meny");
      }

      public static void LoginChoice()
      {

         int choice = Inputs.GetNumberMinMax(1, 3);
         switch (choice)
         {
            case 1:
               Console.Clear();
               var user = UserManager.LogIn();
               if (user != null)
               {
                  Console.Clear();

                  if (user.Admin)
                  {
                     AdminMenu.PrintAdminMenu();
                     AdminMenu.AdminnMenuChoice(user);
                     
                  }
                  else
                  {
                     MainMenuChoice(user);
                  }
               }
               break;
            case 2:
               Console.Clear();
               UserManager.ResetPassword();
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
                  Console.Clear();
                  UserManager.TransferMoney(user);
                  Console.ReadKey();
                  break;
               case 5:
                  Console.Clear();
                  SettingsMenu();
                  Console.ReadKey();
                  break;
               case 6:
                  running = false;
                  break;

            }
            Console.ReadKey();
         }
      }



   }
}

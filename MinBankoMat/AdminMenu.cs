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
         Console.WriteLine("6) Redigera användare");
         Console.WriteLine("7) Logga ut");
      }

      public static void UserManagerMenu()
      {
         Console.WriteLine("1) Ändra lösenord");
         Console.WriteLine("2) Ändra användarnamn");
         Console.WriteLine("3) Spärra konto");
         Console.WriteLine("4) Kundregister");
      }

      public static void UserManagerMenuChoice()
      {
         int input = Inputs.GetUserNumber();
         switch (input)
         {
            case 1:
               Console.Clear();
               UserManager.AdminChangePassword();
               // Ändra lösenord
               break;
            case 4:
               Console.Clear();
               UserManager.PrintUser();
               
               //Kundregister
               break;
         }
         
      }

      

      public static void AdminnMenuChoice(User user)
      {
         bool running = true;
         
         while (running)
         {
            Console.Clear();
            PrintAdminMenu();
            int choice = Inputs.GetNumberMinMax(1, 7);
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
                  Menu.SettingsMenu();
                  Console.ReadKey();
                  // Inställningar
                  break;
               case 5:
                  Console.Clear();
                  UserManager manager = new UserManager();
                  manager.CreateUser();
                  //Skapa användare
                  break;
               case 6:
                  Console.Clear();
                  UserManagerMenu();
                  UserManagerMenuChoice();
                  // Ändra användare
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

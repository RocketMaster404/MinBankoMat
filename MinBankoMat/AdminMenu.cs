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
         Console.WriteLine("4) För över pengar");
         Console.WriteLine("5) Inställningar");
         Console.WriteLine("6) Skapa användare");
         Console.WriteLine("7) Redigera användare");
         Console.WriteLine("8) Logga ut");
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
            int choice = Inputs.GetNumberMinMax(1, 8);
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
                  Menu.SettingsMenu();
                  Console.ReadKey();
                  // Inställningar
                  break;
               case 6:
                  Console.Clear();
                  UserManager manager = new UserManager();
                  manager.CreateUser();
                  //Skapa användare
                  break;
               case 7:
                  Console.Clear();
                  UserManagerMenu();
                  UserManagerMenuChoice();
                  // Ändra användare
                  break;
               case 8:
                  running = false;
                  break;

            }
            Console.ReadKey();
         }
      }

     
   }
}

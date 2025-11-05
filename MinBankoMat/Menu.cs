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
                  PrintMainMeny();
                  MainMenuChoice(user);   
               }
               break;
            case 2:
               LogInManager.ResetPassword();
               // Glömt lösenord
               break;
            case 3:
               break;
               
         }
      }

      public static void MainMenuChoice(User user)
      {
         int choice = Inputs.GetNumberMinMax(1, 5);
         switch (choice)
         {
            case 1:
               // Ta ut pengar
               break;
            case 2:
               // Sätt in pengar
               break;
            case 3:
               user.ShowBalance();
               // Visa saldo
               break;
            case 4:
               // Inställningar
               break;
            case 5:
               // Logga ut
               break;
         }
      }


      
   }
}

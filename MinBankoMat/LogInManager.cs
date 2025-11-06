using System;

namespace MinBankoMat
{
   internal class LogInManager
   {
      private List<int> usedAccountNumbers = new List<int>();
      private Random rnd = new Random();

      static List<User> users = new List<User>()
      {
         new User("Erik", 1234,1000,4455, 888888),
         new User("Malin", 1234, 2000,5544,999999),
         new User(){UserName = "Admin", PinCode = 1234, Admin = true}
      };


      public void CreateUser()
      {
         Console.Write("Ange användarnamn: ");
         string userName = Inputs.GetString();
         Console.Write("Ange pinkod: ");
         int pinCode = Inputs.GetUserNumber();
         Console.Write("Ange start saldo: ");
         int balance = Inputs.GetUserNumber();
         


         int accountNumber = GenerateUniqueAccountNumber();
         int resetCode = GenerateResetCode();
         User user = new User(userName, pinCode, balance, resetCode, accountNumber);
         users.Add(user);
         Console.WriteLine("Användare skapad nedan ser du ditt kontonummer samt Resetkod. Spara dessa på ett säkert ställe!");
         Console.WriteLine($"Kontonummer: {accountNumber}");
         Console.WriteLine($"Reset kod: {resetCode}");
         
      }

      private int GenerateUniqueAccountNumber()
      {
         int accountNumber;
         do
         {
            accountNumber = rnd.Next(10000000, 99999999); 
         } while (usedAccountNumbers.Contains(accountNumber));

         usedAccountNumbers.Add(accountNumber);
         return accountNumber;
      }

      private int GenerateResetCode()
      {
         int resetCode;
         resetCode = rnd.Next(1000, 9999);
         return resetCode;
      }

      public static User LogIn()
      {
         bool running = true;
         while (running)
         {
            Console.Write("Ange ditt användarnamn:");
            string userName = Inputs.GetString();
            Console.Write("Ange din pinkod:");
            int pinCode = Inputs.GetUserNumber();

            foreach (var user in users)
            {
               

               if (user.UserName == userName && user.PinCode == pinCode)
               {
                  Console.WriteLine("Lyckad inloggning");
                  Console.ReadKey();
                  return user;
                  
               }
            }
            Console.WriteLine("Ogiltigt användarnamn/lösenord");
         }

         return null;
      }

      public static void ResetPassword()
      {
         Console.WriteLine("Ange din återställningskod");
         int reset = Inputs.GetUserNumber();
         bool match = false;
         foreach(var user in users)
         {
            if(user.ResetCode == reset)
            {
               Console.WriteLine("Ange din nya pinkod:");
               int newPassword = Inputs.GetUserNumber();
               user.PinCode = newPassword;
               Console.WriteLine($"Pinkod ändrad för {user.UserName}");
               match = true;
            }
         }
         if (!match)
         {
            Console.WriteLine("Felaktig återställningskod");
         }



      }
   }
}

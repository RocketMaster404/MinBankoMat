using System;

namespace MinBankoMat
{
   internal class UserManager
   {
      private List<int> usedAccountNumbers = new List<int>();
      private static Random rnd = new Random();

      static List<User> users = new List<User>()
      {
         new User("Erik", 1234,1000,4455, 888888){Admin = true},
         new User("Malin", 1234, 2000,5544,11),
         new User("Pontus", 1234, 2000,5544,199999){ActiveAccount = false}

      };

      public static void PrintUser()
      {
         foreach (var user in users)
         {
            Console.WriteLine($"Användarnamn {user.UserName}");
            Console.WriteLine($"Pinkod: {user.PinCode}");
            Console.WriteLine($"Återställningskod: {user.ResetCode}");
            Console.WriteLine($"Kund Id: {user.CustomerId}");
            Console.WriteLine();

         }
         Console.ReadKey();
      }
      public void CreateUser()
      {
         string userName = "";
         bool userNameMatch = false;
         while (!userNameMatch)
         {
            Console.Write("Ange användarnamn: ");
            userName = Inputs.GetString();
            bool nameTaken = false;
            foreach(var u in users)
            {
               if(userName == u.UserName)
               {
                  Console.WriteLine("Användarnamn upptaget");
                  nameTaken = true;
                  break;
                  
               }
               
            }
            if (!nameTaken)
            {
               userNameMatch = true;
            }
         }
         
         Console.Write("Ange pinkod: ");
         int pinCode = Inputs.GetUserNumber();
         Console.Write("Ange start saldo: ");
         int balance = Inputs.GetUserNumber();



         int accountNumber = GenerateUniqueAccountNumber();
         int resetCode = GenerateResetCode();
         User user = new User(userName, pinCode, balance, resetCode, accountNumber);
         users.Add(user);
         Console.WriteLine("Användare skapad nedan ser du ditt kontonummer, kund id samt Resetkod.");
         Console.WriteLine($"Kontonummer: {accountNumber}");
         Console.WriteLine($"Reset kod: {resetCode}");
         Console.WriteLine($"Kund Id: {user.CustomerId}");

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

               if (user.UserName == userName && user.PinCode == pinCode && user.ActiveAccount == false)
               {
                  Console.WriteLine("Ditt konto är spärrat, kontakta kundtjänst");
                  Console.ReadKey();
                  return null;

               }


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
         foreach (var user in users)
         {
            if (user.ResetCode == reset)
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

      public static void AdminChangePassword()
      {
         bool match = false;
         Console.WriteLine("Ange kundens ID:");
         int id = Inputs.GetUserNumber();

         foreach (var user in users)
         {
            if (user.CustomerId == id)
            {
               Console.WriteLine($"Ange ny pinkod för {user.UserName}");
               int pin = Inputs.GetUserNumber();
               user.PinCode = pin;
               Console.WriteLine($"Pinkod ändrad för {user.UserName}");
               match = true;
            }
         }

         if (!match)
         {
            Console.WriteLine("Felaktigt kund id");
         }

      }
      public static void AdminChangeUsername()
      {
         
         bool match = false;
         Console.WriteLine("Ange kundens ID:");
         int id = Inputs.GetUserNumber();

         foreach (var user in users)
         {
            if (user.CustomerId == id)
            {
               Console.WriteLine($"Ange nytt användarnamn för {user.UserName}");
               string userName = Console.ReadLine();
               user.UserName = userName;
               Console.WriteLine($"Användarnamn ändrat till {user.UserName}");
               match = true;
            }
         }

         if (!match)
         {
            Console.WriteLine("Felaktigt kund id");
         }

      }
      public static void AdminBlockAccount()
      {
         
         bool match = false;
         Console.WriteLine("Ange kundens ID:");
         int id = Inputs.GetUserNumber();

         foreach (var user in users)
         {
            if (user.CustomerId == id)
            {
               Console.WriteLine($"{user.UserName} konto spärrat");
               user.ActiveAccount = false;
               match = true;
            }
         }

         if (!match)
         {
            Console.WriteLine("Felaktigt kund id");
         }

      }

      public static void TransferMoney(User LoggedInUser)
      {
         bool match = false;
         Console.Write("Ange mottagarens kontonummer:");
         int accountNumber = Inputs.GetUserNumber();
         foreach (var user in users)
         {

            if (accountNumber == LoggedInUser.AccountNumber)
            {
               Console.WriteLine("Du kan inte föra över till ditt egna konto");
               return;
            }
            if (accountNumber == user.AccountNumber)
            {
               Console.WriteLine($"Överför till {user.UserName}");
               Console.Write("Ange belopp: ");
               int amount = Inputs.GetUserNumber();
               if (amount <= 0)
               {
                  Console.WriteLine("Du måste ange ett belopp större än 0.");
               }
               else if (amount > LoggedInUser.Balance)
               {
                  Console.WriteLine("Du har inte tillräckligt med pengar.");
                  match = true;
               }
               else
               {
                  LoggedInUser.Balance -= amount;
                  user.Balance += amount;
                  Console.WriteLine($"{amount} kr har förts över till {user.UserName}.");
                  Console.WriteLine($"Nytt saldo {LoggedInUser.Balance} kr.");
                  match = true;
               }
              
            }


         }
         if (!match)
         {
            Console.WriteLine("Felaktigt kontonummer");
         }
      }


   }
}

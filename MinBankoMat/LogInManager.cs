namespace MinBankoMat
{
   internal class LogInManager
   {
      static List<User> users = new List<User>()
      {
         new User("Erik", 1234,1000,123),
         new User("Malin", 1234, 2000,1234)
      };
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

namespace MinBankoMat
{
   internal class LogInManager
   {
      static List<User> users = new List<User>();
      public User LogIn()
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
   }
}

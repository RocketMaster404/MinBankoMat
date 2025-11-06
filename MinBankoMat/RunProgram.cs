using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinBankoMat
{
   internal class RunProgram
   {
      public static bool ProgramOn = true;
      
      public static void Run()
      {
         

         while (ProgramOn)
         {
           
               UserLogIn();
            
         }



      }

    

      public static void UserLogIn()
      {
         Console.Clear();
         Menu.PrintLoginMenu();
         Menu.LoginChoice();
         Console.ReadKey();
      }


   }
}

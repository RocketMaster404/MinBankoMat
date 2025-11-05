using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinBankoMat
{
   internal class RunProgram
   {
      public static void Run()
      {
         bool runProgram = true;

         while (runProgram)
         {
            Menu.PrintLoginMenu();
            Menu.LoginChoice();
            Console.ReadKey();
            Console.Clear();
         }



      }


   }
}

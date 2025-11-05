using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinBankoMat
{
   internal class Inputs
   {
      public static int GetUserNumber()
      {
         int input;
         while(!int.TryParse(Console.ReadLine(), out input))
         {
            Console.WriteLine("Du måste ange heltal");
         }
         return input;
      }

      public static string GetString()
      {
         string input = Console.ReadLine();
         return input;
      }

      public static int GetNumberMinMax(int min,int max)
      {
         int input;
         while(!int.TryParse(Console.ReadLine(), out input) || input < min || input > max)
         {
            Console.WriteLine($"Du måste ange ett nummer mellan {min} - {max}");
         }
         return input;
      }



   }
}

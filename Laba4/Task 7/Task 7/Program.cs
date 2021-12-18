using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Треклист: ");
            string[] traklist =
            {
                "1.Gentle Giant – Free Hand[6:15]",
                "2.Supertramp – Child Of Vision[07:27]",
                "3.Camel – Lawrence[10:46]",
                "4.Yes – Don’t Kill The Whale[3:55]",
                "5. 10CC – Notell Hotel[04:58]",
                "6.Nektar – King Of Twilight[4:16]",
                "7.The Flower Kings – Monsters & Men[21:19]",
                "8.Focus – Le Clochard[1:59]",
                "9.Pendragon – Fallen Dream And Angel[5:23]",
                "10.Kaipa – Remains Of The Day(08:02)"
            };
            Console.WriteLine();
            for (int i = 0; i < traklist.Length; i++)
            {
                Console.WriteLine(traklist[i]);
            }
            char[] mass = traklist.ToArray();
            for (int i = 0; i < mass.Length; i++)
            {

                Console.WriteLine(mass[i]);
            }
        }
    }
}

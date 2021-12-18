using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace task7
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
            int sek = 0, sek_Min = 0, sek_Max = 0;
            int min = 0, min_Min = 0, min_Max = 0 
            Regex regex = new Regex(@"(\d+)[:](\d+)");
            for (int i = 0; i < traklist.Length; i++)
            {
                Match match = regex.Match(traklist[i]);
                while (match.Success)
                {
                    sek += Convert.ToInt32(match.Groups[2].Value);
                    min += Convert.ToInt32(match.Groups[1].Value);
                    sek_Min = sek 
                    match = match.NextMatch();
                }
            }
            int sek_Final = 0;
            double min_Final = 0;
            int Hour = 0;
            if (sek > 60)
            {
                sek_Final = sek - (int)(sek / 60) * 60;
                min += (int)(sek / 60);
            }
            if (min > 60)
            {
                min_Final = (min % 60);
                Hour = (int)(min / 60);
            }
            Console.WriteLine($"Общая длительность песен: {Hour}:{min_Final}:{sek_Final}");
        }
    }
}

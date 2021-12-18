using System;
using System.Text.RegularExpressions;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст формата: '15 + 36 = 51'");
            string text = Console.ReadLine();
            int a, b, c;
            Regex reg = new Regex(@"^(\d+)\s+[+]\s+(\d+)\s+[=]\s+(\d+)");
            Match match = reg.Match(text);
            while (match.Success)
            {
                Console.WriteLine(a = Convert.ToInt32(match.Groups[1].Value));
                Console.WriteLine(b = Convert.ToInt32(match.Groups[2].Value));
                Console.WriteLine(c = Convert.ToInt32(match.Groups[3].Value));
                match = match.NextMatch();
            }
        }
    }
}

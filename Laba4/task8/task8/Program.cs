using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace task8
{
    class Program
    {
        public static string Polybius_Square(string text)
        {
            string text_Up = text.ToUpper();
            string text_Final = text_Up.Replace(" ", "");
            char[] sign = text_Final.ToCharArray();
            string[,] square = new string[6, 6]{{ "А", "Б", "В", "Г", "Д", "Е" },
                                                { "Ё", "Ж", "З", "И", "Й", "К" },
                                                { "Л", "М", "Н", "О", "П", "Р" },
                                                { "С", "Т", "У", "Ф", "Х", "Ц" },
                                                { "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь" },
                                                { "Э", "Ю", "Я", "-", "-", "-" }};
            string ansver = "";
            for (int f = 0; f < sign.Length; f++)
            {
                for (int i = 0; i < square.GetLength(0); i++)
                {
                    for (int j = 0; j < square.GetLength(1); j++)
                    {
                        if (sign[f] == Convert.ToChar(square[i, j]))
                        {
                            if (square[i, j] == "Ъ" | square[i, j] == "Ы" | square[i, j] == "Ь")
                            {
                                ansver += square[0, j];
                            }
                            else if (i == 5 && square[i, j] != "-")
                            {
                                ansver += square[0, j];
                            }
                            else if (square[i, j] != "-")
                            {
                                ansver += square[i + 1, j];
                            }
                        }
                    }
                }
            }
            return ansver;
        }
        public static string Gronsfeld(string text)
        {
            
            string text_Up = text.ToUpper();
            string text_Final = text_Up.Replace(" ", "");
            char[,] square = new char[text.Length, 33];
            string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            char[] Array_alphabet = alphabet.ToCharArray();
            int k = 0;
            for (int i = 0; i < text_Final.Length; i++)
            {
                for (int j = 0; j < 33; j++)
                {
                    if (k < alphabet.Length)
                    {
                        square[i, j] = alphabet[(i + k) % alphabet.Length];
                        k++;
                    }
                    else
                    {
                        j = 0;
                        k = 0;
                        continue;
                    }
                }
            }
            Console.WriteLine("Таблица Гронсфельда: ");
            for (int i = 0; i < text_Final.Length; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 33; j++)
                {
                    square[1, 0] = 'А';
                    Console.Write(square[i, j] + " ");
                }
            }
            Console.WriteLine();
            Random rand = new Random();
            int[] key = new int[text_Final.Length];
            Console.WriteLine("Ключ: ");
            for (int index = 0; index < text_Final.Length; index++)
            {
                key[index] = rand.Next(0, text_Final.Length - 1);
                Console.Write(key[index] + " ");
            }
            Console.WriteLine();
            string ansver = "";
            for (int i = 0; i < text_Final.Length; i++)
            {
                if (alphabet.Contains(text_Final[i]))
                {
                    ansver += square[key[i], alphabet.LastIndexOf(text_Final[i])];
                }
            }
            return ansver;
        }
        public static string Book_Cipher(string text)
        {
            Console.WriteLine("Введите текст стиха: ");
            string poem = Console.ReadLine().ToUpper();
            string text_Final = text.Replace(" ", "").ToUpper();
            string poem_Final = poem.Replace(" ", "");
            char[,] square = new char[10, 10];
            int k = 0;
            for (int i = 0; i < square.GetLength(0); i++)
            {
                for (int j = 0; j < square.GetLength(1); j++)
                {
                    if (k < poem_Final.Length)
                    {
                        square[i, j] = poem_Final[k];
                        k++;
                    }
                }
            }
            Console.WriteLine("Стихотворение для шифровки: ");
            for (int i = 0; i < square.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < square.GetLength(1); j++)
                {
                    Console.Write($"{square[i, j]} ");
                }
            }
            string ansver = "";
            for (int i = 0, f = 0; i < square.GetLength(0); i++)
            {
                for (int j = 0; j < square.GetLength(1); j++)
                {
                    if (f < text_Final.Length)
                    {
                        if (square[i, j] == text_Final[f])
                        {
                            ansver += $"{i}/{j} ";
                            f++; i = 0; j = 0;
                        }
                        else if (i == 9 & j == 9)
                        {
                            f++;
                            i = 0; j = 0;
                        }
                    }
                }
            }
            Console.WriteLine();
            return ansver;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст для шифровки: ");
            string text = Console.ReadLine();
           Console.WriteLine("Выберите способ шифрования: ");
              Console.WriteLine("1 - Шифр Полибия " +
                                "2 - Шифр Гронсфельда " +
                                "3 - Книжный шифр");
            switch (Console.ReadLine()) 
            {
                case "1":
                    Console.WriteLine("Зашифрованный текст: " + Polybius_Square(text));
                    break;
                case "2":
                    Console.WriteLine("Зашифрованный текст: " + Gronsfeld(text));
                    break;
                case "3":
                    Console.WriteLine("Зашифрованный текст: " + Book_Cipher(text));
                    break;
            }
        }
    }
    //Сегодня я кушал пицу. Птичка божия не знает Ни заботы, ни труда, Хлопотливо не свивает Долговечного гнезда.
}

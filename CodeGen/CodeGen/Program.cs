using System;
using System.IO;
using System.Text;

namespace CodeGen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the file name : ");
            string fileName = Console.ReadLine();
            string filePath = fileName + ".txt";

            Console.Write("Enter the number of codes : ");
            if (!int.TryParse(Console.ReadLine(), out int numberOfCodes))
            {
                Console.WriteLine("Invalid number Exiting...");
                return;
            }

            string[] codes = GenerateRandomCodes(numberOfCodes);

            File.WriteAllLines(filePath, codes);

            Console.WriteLine($"Generated {numberOfCodes} random codes and saved to {filePath}");
        }

        static string[] GenerateRandomCodes(int count)
        {
            string[] codes = new string[count];
            for (int i = 0; i < count; i++)
            {
                codes[i] = GenerateRandomCode();
            }
            return codes;
        }

        static string GenerateRandomCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder code = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    code.Append(chars[random.Next(chars.Length)]);
                }
                if (i < 3)
                {
                    code.Append("-");
                }
            }

            return code.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProyect
{
    class Program
    {
        static void Main(string[] args)
        {

            string secretWord;
            string ShownWord = "";
            secretWord = Console.ReadLine();
            Console.Clear();
            for (int i = 0; i < secretWord.Length; i++)
            {
                if (!(secretWord[i] == ' '))
                {
                    ShownWord += "*";
                }
                else
                {
                    ShownWord += " ";
                }
            }
            Console.WriteLine("Your secret word is " + ShownWord);

            while (!(ShownWord == secretWord))
            {
                string chartry;
                chartry = Console.ReadLine();

                while (chartry != secretWord || string.IsNullOrWhiteSpace(chartry) || chartry.Length > 1)
                {
                    Console.Clear();
                    Console.WriteLine("Your secret word is " + ShownWord);
                    Console.WriteLine("Plese imput just one letter per try");
                    chartry = Console.ReadLine();
                }

                if (chartry == secretWord)
                {
                    ShownWord = chartry;

                    if (secretWord.Contains(chartry))
                    {
                        string tempWord = string.Empty;
                        for (int i = 0; i < secretWord.Length; i++)
                        {
                            if (secretWord[i] == chartry[0])
                            {
                                tempWord += secretWord[i];
                            }
                            else
                            {
                                tempWord += ShownWord[i];
                            }
                        }
                        ShownWord = tempWord;
                    }

                    Console.Clear();
                    Console.WriteLine("Your secret word is " + ShownWord);

                }
            }
        }
    }
}
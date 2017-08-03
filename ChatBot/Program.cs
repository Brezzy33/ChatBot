using System;
using System.IO;

namespace ChatBot
{
    class Program
    {

        //Delete letters
        static string Trim(string str, char[] chars)
        {
            string strA = str; //Coppy line (do not correct)

            //Delete symbols
            for (int i = 0; i < chars.Length; i++)
            {
                strA = strA.Replace(char.ToString(chars[i]), "");
            }
            return strA;
        }

        static string Ans(string quest)
        {
            string tr = ")(:^^=!?", //Simbols that should delete
                ans = ""; //Bots answers

            quest = quest.ToLower(); //Translate to lower register
            quest = Trim(quest, tr.ToCharArray()); //Delete letters
            string[] baza = File.ReadAllLines("D:\\C#\\ChatBot\\ChatBot\\bin\\Debug\\1.txt");

            //Searching
            for (int i = 0; i < baza.Length; i += 2)
            {
                if (quest == baza[i])
                {
                    ans = baza[i + 1]; //Return answer
                    break; //End cycle
                }
            }
            return ans; //Answer
        }

        public static void Main()
        {
            //Endless cycle
            while (true)
            {
                Console.Write("Your answer:");
                string quest = Console.ReadLine();
                Console.WriteLine("Bot answered: " + Ans(quest) + "\n");
            }
        } 
    }
}
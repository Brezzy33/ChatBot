using System;
using System.IO;

namespace ChatBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Your answer:");
            string s = Console.ReadLine();
            Console.WriteLine("Bot answer:" + Ans(q)+"/n");
        }

        private static string Ans(string q)
        {
            string tr = ")(:^^=!?", //Simbols that should delete
                ans = ""; //Bots answers

            q = q.ToLower(); //Translate to lower register
            q = Trim(q, tr.ToCharArray()); //Delete letters
            string[] baza = File.ReadAllLines("1.txt");

            //Searching
            for (int i = 0; i < baza.Length; i += 2) 
            {
                if (q==baza[i])
                {
                    ans = baza[i + 1];
                    break;
                }   
            }
            return ans;
        }

        //Delete letters
        private static string Trim(string str, char[] chars)
        {
            string stra = str; //Coppy line (do not correct)

            //Delete symbols
            for (int i=0;i<chars.Length;i++)
            {
                stra = stra.Replace(char.ToString(chars[i]), "");
            }
            return stra;
        }
    }
}
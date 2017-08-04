using System;

namespace ChatBot
{
    class Program
    {
        public static void Main()
        {
            ChatBot bot = new ChatBot(@"D:\\C#\\ChatBot\\ChatBot\\bin\\Debug\\1.txt"); //Create bot
            bot.GetStr += bot_GetStr; //Subscribe to action

            //Endless cycle
            while (true)
            {
                string q = Console.ReadLine(); //Enter answer
                bot.Ans(q);
            }
        }

        static void bot_GetStr(string obj)
        {
            Console.WriteLine(obj); //Show answer
        }
    }
}
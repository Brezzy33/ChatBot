using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChatBot
{
    internal class ChatBot
    {
        string q, //Question
        path, //Way
        userAnswer; //Users answer(for education)
        List<string> sempls = new List<string>(); //Answers-Questions (Base)
        bool flag = true; //Switch education/work

        public event Action<string> GetStr; //Event when enter new text

        public ChatBot(string pat)
        {
            path = pat; //Way

            try
            {
                sempls.AddRange(File.ReadAllLines(path)); //Try add base
            }
            catch
            {

            }

            GetStr += ChatBot_GetStr;
            GetStr("\n Your answer:");
        }

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

        public void Ans(string qw)
        {
            if (flag)
            {
                q = qw;
                string ans = Answer(qw);

                if (ans == string.Empty)
                {
                    flag = false;
                    GetStr("Enter answer: ");
                }
                else GetStr("Bots answer: " + ans + "\n\nYour answer:");
            }
            //Education
            else
            {
                flag = true;
                userAnswer = qw;
                Teach();
                GetStr("\n Enter answer: ");
            }
        }

        /// <summary>
        /// Answer
        /// </summary>
        /// <param name="quest">Question</param>
        /// <returns></returns>
        private string Answer(string qw)
        {
            string tr = ")(:^^=!?", //Simbols that should delete
                ans = string.Empty; //Bots answers

            qw = qw.ToLower(); //Translate to lower register
            qw = Trim(qw, tr.ToCharArray()); //Delete letters 

            //Searching
            for (int i = 0; i < sempls.Count; i += 2)
            {
                if (qw == sempls[i])
                {
                    ans = sempls[i + 1]; //Return answer
                    break; //End cycle
                }
            }
            return ans; //Answer
        }

        /// <summary>
        /// Teach
        /// </summary>
        private void Teach()
        {
            sempls.Add(q); //Add question
            sempls.Add(userAnswer); //Answer
            File.WriteAllLines(path, sempls.ToArray()); //Save
        }

        void ChatBot_GetStr(string obj) //Stug or Cap for event (if event = empty)
        {

        }
    }
}

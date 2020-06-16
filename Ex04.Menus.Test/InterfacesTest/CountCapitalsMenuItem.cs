using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test.InterfacesTest
{
    public class CountCapitalsMenuItem : MenuItem, IExecutable
    {
        public CountCapitalsMenuItem() : base("Count Capitals")
        {
        }

        void IExecutable.Execute()
        {
            string word = getWordFromUser();
            int capitalLettersAmount = calculateCapitals(word);
            Console.WriteLine("The sentence " + '"' + "{0}" + '"' + " has {1} capital letters.", word, capitalLettersAmount);
        }

        private int calculateCapitals(string word)
        {
            int capitalAmount = 0;

            foreach(char letter in word)
            {
                if(char.IsLetter(letter) == true && char.IsUpper(letter) == true)
                {
                    capitalAmount++;
                }
            }

            return capitalAmount;
        }

        private string getWordFromUser()
        {
            Console.WriteLine("Please enter a sentence:");
            string sentence = Console.ReadLine();
            return sentence;
        }
    }
}

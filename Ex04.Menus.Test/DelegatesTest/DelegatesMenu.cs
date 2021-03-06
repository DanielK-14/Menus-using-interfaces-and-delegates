﻿using System;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public class DelegatesMenu
    {
        public MainMenu MainMenu;

        public DelegatesMenu()
        {
            ActionMenuItem countCapital = new ActionMenuItem("Count Capitals");
            countCapital.PickedMenuItem += countingCapital_Picked;

            ActionMenuItem showVersion = new ActionMenuItem("Show Version");
            showVersion.PickedMenuItem += showVersion_Picked;

            ActionMenuItem showTime = new ActionMenuItem("Show Time");
            showTime.PickedMenuItem += showTime_Picked;

            ActionMenuItem showDate = new ActionMenuItem("Show Date");
            showDate.PickedMenuItem += showDate_Picked;

            MainMenu = new MainMenu("Main Menu - Delegates");
            Menu versionAndDigits = new Menu("Version and Digits", 1, MainMenu);
            Menu showDateAndTime = new Menu("Show Date/Time", 1, MainMenu);

            versionAndDigits.AddOption(countCapital);
            versionAndDigits.AddOption(showVersion);
            showDateAndTime.AddOption(showTime);
            showDateAndTime.AddOption(showDate);

            MainMenu.AddOption(versionAndDigits);
            MainMenu.AddOption(showDateAndTime);
        }

        private void countingCapital_Picked()
        {
            string word = getWordFromUser();
            int capitalLettersAmount = calculateCapitals(word);
            Console.WriteLine("The sentence " + '"' + "{0}" + '"' + " has {1} capital letters.", word, capitalLettersAmount);
        }

        private int calculateCapitals(string word)
        {
            int capitalAmount = 0;

            foreach (char letter in word)
            {
                if (char.IsLetter(letter) == true && char.IsUpper(letter) == true)
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

        private void showVersion_Picked()
        {
            Console.WriteLine("Version 20.2.4.30620");
        }

        private void showTime_Picked()
        {
            DateTime localDate = DateTime.Now;
            Console.WriteLine("Local date and time: {0}", DateTime.Now.ToShortTimeString());
        }

        private void showDate_Picked()
        {
            Console.WriteLine("Current date is: {0}", DateTime.Now.ToString("dd/MM/yyyy"));
        }

        public void StartMenu()
        {
            MainMenu.Show();
        }
    }
}

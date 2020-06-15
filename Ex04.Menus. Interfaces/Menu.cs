﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class Menu : MenuItem
    {
        protected Dictionary<int, MenuItem> m_MenuOptions = new Dictionary<int, MenuItem>();
        protected int m_Level;
        protected int m_NextEmptyOptionNumber;
        protected const string k_Exit = "Exit";
        protected const string k_Back = "Back";
        protected string m_Header;
        protected string m_Footer;

        public Menu(string i_Title, int i_Level) : base(i_Title)
        {
            m_Level = i_Level;
            m_NextEmptyOptionNumber = 0;
            setHeaderAndFooter(i_Title);
        }

        private void setHeaderAndFooter(string i_Title)
        {
            m_Header = string.Format("X-X-X-X-X-X-X-X- {0} -X-X-X-X-X-X-X-X", i_Title);
            m_Footer ="X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X-X";
        }

        public int Level
        {
            get { return m_Level; }
            set
            {
                m_Level = value;
                setOptionExitBack(value);
            }
        }

        private void setOptionExitBack(int i_Level)
        {
            if (i_Level == 0)
            {
                setZeroOption(k_Exit);
            }
            else
            {
                setZeroOption(k_Back);
            }
        }

        private void setZeroOption(string i_ZeroTitle)
        {
            if (m_MenuOptions.ContainsKey(0) == true)
            {
                m_MenuOptions[0].Title = i_ZeroTitle;
            }
            else
            {
                m_MenuOptions.Add(0, new MenuItem(i_ZeroTitle));
            }
        }

        public void AddOption(MenuItem i_Item)
        {
            m_MenuOptions.Add(m_NextEmptyOptionNumber, i_Item);
            m_NextEmptyOptionNumber++;
        }

        public void RemoveOption(int i_OptionNumber)
        {
            m_MenuOptions.Remove(i_OptionNumber);
        }

        private void printMenuOptions()
        {
            Console.WriteLine(m_Header);
            Console.WriteLine("Current Level is : {0}", m_Level);
            foreach (int option in m_MenuOptions.Keys)
            {
                Console.WriteLine("({0}) {1}", option, m_MenuOptions[option].Title);
            }

            Console.WriteLine(m_Footer);
            Console.WriteLine();
        }

        public void Show()
        {
            int optionNumber;
            do
            {
                optionNumber = pickOption();
                if(optionNumber != 0)
                {
                    if(m_MenuOptions[optionNumber] is Menu)
                    {
                        (m_MenuOptions[optionNumber] as Menu).Show();
                    }
                    else    /// In this case the selected option is an IExecutable type.
                    {
                        (m_MenuOptions[optionNumber] as IExecutable).Execute();
                    }
                }
            }
            while (optionNumber != 0);

            doExitOrBackOperation();
        }

        private void doExitOrBackOperation()
        {
            if(m_Level == 0)
            {
                Console.Clear();
                Console.WriteLine("Exiting the program...");
                Environment.Exit(0);
            }
            else
            {
                (m_MenuOptions[0] as Menu).Show();
            }
        }

        public int pickOption()
        {
            bool valid;
            int optionNumber = 0;
            string option;

            do
            {
                try
                {
                    printMenuOptions();
                    Console.Write("Please pick an option number: ");
                    option = Console.ReadLine();
                    optionNumber = convertOptionToInt(option);
                    valid = true;
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    valid = false;
                    Console.WriteLine(ex.Message);
                }
            }
            while (valid == false);

            return optionNumber;
        }

        private int convertOptionToInt(string i_Option)
        { 
            if(i_Option == string.Empty || i_Option.StartsWith(" ") == true)
            {
                throw new FormatException("Inputted value is not valid.");
            }
            else if(int.Parse(i_Option) < 0 || int.Parse(i_Option) >= m_NextEmptyOptionNumber)
            {
                throw new ArgumentOutOfRangeException("Inputted value is not in Range of menu options.");
            }

            return int.Parse(i_Option);
        }
    }
}
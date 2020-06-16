﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class Menu : MenuItem
    {
        protected Dictionary<int, MenuItem> m_MenuOptions = new Dictionary<int, MenuItem>();
        protected Menu m_PreviousMenu;
        protected int m_Level;
        protected int m_NextEmptyOptionNumber;
        protected const string k_Exit = "Exit";
        protected const string k_Back = "Back";
        protected string m_ZeroPosition;
        protected string m_Header;
        protected string m_Footer;

        public Menu(string i_Title, int i_Level, Menu i_PreviousMenu) : base(i_Title)
        {
            m_Level = i_Level;
            setOptionExitBack(m_Level);
            m_NextEmptyOptionNumber = 0;
            m_PreviousMenu = i_PreviousMenu;
            setHeaderAndFooter(i_Title);
        }

        private void setHeaderAndFooter(string i_Title)
        {
            StringBuilder headBuilder = new StringBuilder();
            headBuilder.Append('#', 12);
            headBuilder.Append(string.Format(" {0} ", i_Title));
            headBuilder.Append('#', 12);
            m_Header = headBuilder.ToString();

            StringBuilder footerBuilder = new StringBuilder();
            footerBuilder.Append('#', m_Header.Length);
            m_Footer = footerBuilder.ToString();
        }

        public int Level
        {
            get { return m_Level; }
            set 
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Value entered not in valid range of levels ,must be bigger than 0.");
                }

                setOptionExitBack(m_Level);
                m_Level = value; 
            }
        }

        private void setOptionExitBack(int i_Level)
        {
            if (i_Level == 0)
            {
                m_MenuOptions.Add(0, null);
                m_ZeroPosition = k_Exit;
            }
            else
            {
                m_MenuOptions.Add(0, m_PreviousMenu);
                m_ZeroPosition = k_Back;
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
                Console.Clear();
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
                    optionNumber = convertOptiorrnToIntAndCheckValidation(option);
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

        private int convertOptiorrnToIntAndCheckValidation(string i_Option)
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

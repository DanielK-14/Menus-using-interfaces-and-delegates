using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test.InterfacesTest
{
    public class ShowTimeMenuItem : MenuItem, IExecutable
    {
        public ShowTimeMenuItem() : base("Show Time") 
        {
        }

        void IExecutable.Execute()
        {
            DateTime localDate = DateTime.Now;
            Console.WriteLine("Local date and time: {0}", DateTime.Now.ToShortTimeString());
        }
    }
}

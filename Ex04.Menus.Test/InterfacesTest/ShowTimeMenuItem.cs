using Ex04.Menus.Interfaces;
using System;

namespace Ex04.Menus.Test.InterfacesTest
{
    class ShowTimeMenuItem : MenuItem, IExecutable
    {
        public ShowTimeMenuItem() : base("Show Time") { }

        void IExecutable.Execute()
        {
            DateTime localDate = DateTime.Now;
            Console.WriteLine("Local date and time: {0}", DateTime.Now.ToShortTimeString());
        }
    }
}

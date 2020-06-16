using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test.InterfacesTest
{
    class ShowVersionMenuItem : MenuItem, IExecutable
    {
        public ShowVersionMenuItem() : base("Show Version") { }

        void IExecutable.Execute()
        {
            Console.WriteLine("Version 20.2.4.30620");
        }
    }
}

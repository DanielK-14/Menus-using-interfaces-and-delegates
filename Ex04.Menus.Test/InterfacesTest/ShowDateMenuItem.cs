using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test.InterfacesTest
{
    public class ShowDateMenuItem : MenuItem, IExecutable
    {
        public ShowDateMenuItem() : base("Show Date") 
        {
        }

        void IExecutable.Execute()
        {
            Console.WriteLine("Current date is: {0}", DateTime.Now.ToString("dd/MM/yyyy"));
        }
    }
}

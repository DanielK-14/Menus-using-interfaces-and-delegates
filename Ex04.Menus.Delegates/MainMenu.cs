using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MainMenu : Menu
    {
        public MainMenu(string i_Title) : base(i_Title, 0, null) { }

        public override void Action()
        {
            base.Action();
        }
    }
}

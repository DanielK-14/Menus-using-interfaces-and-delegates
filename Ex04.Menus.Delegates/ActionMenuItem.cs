using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public delegate void PickInvoker();

    public class ActionMenuItem : MenuItem
    {
        public ActionMenuItem(string i_Title) : base(i_Title) { }

        public event PickInvoker PickedMenuItem;

        protected void OnPicked()
        {
            if (PickedMenuItem != null)
            {
                PickedMenuItem.Invoke();
            }
        }

        public override void Action()
        {
            OnPicked();
        }
    }
}

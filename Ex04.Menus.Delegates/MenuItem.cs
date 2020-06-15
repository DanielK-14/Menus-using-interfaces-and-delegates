using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public delegate void ReportClickedDelegate(string i_buttonID);

    public class MenuItem
    {
        public readonly List<MenuItem> m_MenuItems = new List<MenuItem>();
        string title;
        private string m_ID;
        bool m_Clicked = false;
        bool m_Final = false;

        private ReportClickedDelegate m_ReportClickedDelegates;

        public MenuItem(string i_ID)
        {
            this.m_ID = i_ID;
        }

        public void AttachObserver(ReportClickedDelegate i_ObserverDelegate)
        {
            m_ReportClickedDelegates += i_ObserverDelegate;
        }

        public void DetachObserver(ReportClickedDelegate i_ObserverDelegate)
        {
            m_ReportClickedDelegates -= i_ObserverDelegate;
        }

        public bool Clicked
        {
            get
            {
                return m_Clicked;
            }
            set
            {
                if (m_Clicked != value)
                {
                    m_Clicked = value;
                    doWhenClickedChange();
                }
            }
        }

        private void doWhenClickedChange()
        {
            if (m_Clicked == true && m_Final == true)
            {
                doAction();
            }
            else if (m_Clicked == true && m_Final == false)
            {
                notifyClickedObservers();
            }
        }
        private void doAction()
        {
            // call to functions
        }

        //private void doWhenClicked()
        //{
        //    m_Clicked = true;
        //    notifyClickedObservers();
        //}

        private void notifyClickedObservers()
        {
            if (m_ReportClickedDelegates != null)
            {
                m_ReportClickedDelegates.Invoke(m_ID);
            }
        }
    }
}

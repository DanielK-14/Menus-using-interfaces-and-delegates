namespace Ex04.Menus.Interfaces
{
    public abstract class MenuItem 
    {
        protected string m_Title;

        public MenuItem(string i_Title)
        {
            m_Title = i_Title;
        }

        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }
    }
}

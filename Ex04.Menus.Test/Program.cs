namespace Ex04.Menus.Test
{
    class Program
    {
        public static void Main()
        {
            InterfacesMenu interfacesMenu = new InterfacesMenu();
            DelegatesMenu delegatesMenu = new DelegatesMenu();

            interfacesMenu.StartMenu();
            delegatesMenu.StartMenu();
        }
    }
}

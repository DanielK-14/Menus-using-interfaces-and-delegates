using Ex04.Menus.Interfaces;
using Ex04.Menus.Test.InterfacesTest;

namespace Ex04.Menus.Test
{
    class InterfacesMenu
    {
        MainMenu mainMenu;

        public InterfacesMenu()
        {
            CountCapitalsMenuItem countCapital = new CountCapitalsMenuItem();
            ShowVersionMenuItem showVersion = new ShowVersionMenuItem();
            ShowTimeMenuItem showTime = new ShowTimeMenuItem();
            ShowDateMenuItem showDate = new ShowDateMenuItem();

            mainMenu = new MainMenu("Main Menu");
            Menu versionAndDigits = new Menu("Version and Digits", 1, mainMenu);
            Menu showDateAndTime = new Menu("Show Date/Time", 1, mainMenu);

            versionAndDigits.AddOption(countCapital);
            versionAndDigits.AddOption(showVersion);
            showDateAndTime.AddOption(showTime);
            showDateAndTime.AddOption(showDate);

            mainMenu.AddOption(versionAndDigits);
            mainMenu.AddOption(showDateAndTime);
        }

        public void StartMenu()
        {
            mainMenu.Show();
        }
    }
}

using System;
using MenuSystem;

namespace consoleApp007
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("====menu====");
            var menuB = new Menu(MenuLevel.Level2plus);
            menuB.AddMenuItem(new MenuItem("Sub 2", "1", DefaultMenuAction));
            var menuA = new Menu(MenuLevel.Level1);
            menuA.AddMenuItem(new MenuItem("go to Submenu 2", "1", menuB.RunMenu));
            var menu = new Menu(MenuLevel.Level0);
            menu.AddMenuItem(new MenuItem("go to submenu 1", "s", menuA.RunMenu));
            menu.AddMenuItem(new MenuItem("new game vs human", "2", DefaultMenuAction));
            menu.AddMenuItem(new MenuItem("New game ai vs ai", "3", DefaultMenuAction));

            menu.RunMenu();
        }

        private static string DefaultMenuAction()
        {
            Console.WriteLine("NOT IMPLEMENTED YET!");
            return "";
        }
    }
}
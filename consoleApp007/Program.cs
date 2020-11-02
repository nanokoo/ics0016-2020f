using System;
using MenuSystem;


namespace ConsoleApp01
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("====menu====");
            var menuB =new  Menu(MenuLevel.Level2plus);
            menuB.MenuItems.Add(new MenuItem("Sub 2", "1", DefaultMenuAction));
            var menuA=new  Menu(MenuLevel.Level1);
            menuA.MenuItems.Add(new MenuItem("go to Submenu 2", "1", menuB.RunMenu));
            var menu = new Menu(MenuLevel.Level0);
            menu.MenuItems.Add(new MenuItem("go to submenu 1","s",  menuA.RunMenu ));
            menu.MenuItems.Add(new MenuItem("new game vs human","2", DefaultMenuAction));
            menu.MenuItems.Add(new MenuItem("New game ai vs ai","3", DefaultMenuAction));
            menu.RunMenu();
      

            //Console.WriteLine("dfgdg " + i);
        }
        // how to create the method sample:
        static void DefaultMenuAction()
        {
            Console.WriteLine("NOT IMPLEMENTED YET!");
        }

        private static void Output(int i)
        {
            Console.WriteLine($"I is {i}");
        }
    }
}
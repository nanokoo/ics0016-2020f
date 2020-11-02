using System;
using System.Collections.Generic;
using System.Linq;

namespace MenuSystem
{
    public enum MenuLevel
    {
        Level0,
        Level1,
        Level2plus
    }
    public class Menu
    {
        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
        private readonly MenuLevel _menuLevel;

        public Menu(MenuLevel level)
        {
            _menuLevel = level;
        }

        public void RunMenu()
        {
            var userChoice = "";
            do
            {
                Console.WriteLine("");
                foreach (var menuItem in MenuItems)
                {
                   // Console.WriteLine($"{menuItem.UserChoice}) {menuItem.Label} ");
                    Console.WriteLine(menuItem);
                }

                switch (_menuLevel)
                {
                    case MenuLevel.Level0:
                        Console.WriteLine("X) exit game");
                        break;
                    case MenuLevel.Level1:
                        Console.WriteLine("M) return toi main");
                        Console.WriteLine("X) exit game");
                        break;
                    case MenuLevel.Level2plus:
                        Console.WriteLine("P) return to previous");
                        Console.WriteLine("R) return to main");
                        Console.WriteLine("X) exit game");
                        break;
                    default:
                        throw new Exception("Unknown menu depth!");
                    
                }
                Console.WriteLine(">");

                userChoice = Console.ReadLine()?.ToLower().Trim() ?? "";
                if (userChoice == "x")
                {
                    Console.WriteLine("game quit");
                    break;
                }

                var userMenuItem = MenuItems.FirstOrDefault(t => t.UserChoice == userChoice);
                if (userMenuItem != null)
                {
                    userMenuItem.MethodToExecute();
                }
                else
                {
                    Console.WriteLine("I don't have this option!");
                }

                    //Console.WriteLine(userMenuItem != null ? "not impelemted yet" : "I don't have this option!");
            } while (userChoice != "x");
        }
    }
}
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
        //public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
        public Dictionary<string, MenuItem>MenuItems { get; set; } = new Dictionary<string, MenuItem>();
        private readonly MenuLevel _menuLevel;
        private readonly string[] _reservedActions = {"x", "m", "r"};

        public Menu(MenuLevel level)
        {
            _menuLevel = level;
        }

        public void AddMenuItem(MenuItem item)
        {
            if (item.UserChoice == "")
            {
                throw new ArgumentException("nah... 😏 empty string ");
            }

            if (_reservedActions.Contains(item.UserChoice.ToLower()))
            {
                throw new ArgumentException("reserved choice ⛔️");
                
            }
            MenuItems.Add(item.UserChoice.ToLower(), item);
        }

        public string RunMenu()
        {
            string userChoice;
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
                        Console.WriteLine("R) return to previous");
                        Console.WriteLine("M) return to main");
                        Console.WriteLine("X) exit game");
                        break;
                    default:
                        throw new Exception("Unknown menu depth!");
                    
                }
                Console.WriteLine(">");

                userChoice = Console.ReadLine()?.ToLower().Trim() ?? "";
                if (!_reservedActions.Contains(userChoice))
                {
                    if (MenuItems.TryGetValue(userChoice, out var userMenuItem))
                    {
                        userChoice = userMenuItem.MethodToExecute();
                    }
                    else
                    {
                        Console.WriteLine("NO option");
                    }
                    
                }
                if (userChoice == "x")
                {
                    if (_menuLevel != MenuLevel.Level0) continue;
                    Console.WriteLine("game quit");
                    break;

                }
                if (userChoice == "m"&& _menuLevel != MenuLevel.Level0)
                {
                    break;
                }
                if (userChoice == "r" && _menuLevel != MenuLevel.Level2plus)
                {
                    userChoice = null;
                    break;
                }
                //Console.WriteLine(userMenuItem != null ? "not impelemted yet" : "I don't have this option!");
            } while (true);

            return userChoice!;
        }
    }
}
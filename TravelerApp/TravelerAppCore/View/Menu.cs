using System;
using System.Collections.Generic;
using System.Linq;
using TravelerAppCore.Controller;
using TravelerAppCore.Models.Hotels;
using TravelerAppCore.View;

namespace TravelerAppConsole
{
    public class Menu
    {
        public static List<Option> MenuList = new List<Option>();
        public static List<Option> SelectedOptions = new List<Option>();
        public static List<Hotel> DataCopy = new List<Hotel>();
        public static int nextline = 0;
        public static bool MultipleOptions { get; set; }

        public Menu() { }
        public Menu(Option[] options)
        {
            foreach (var option in options)
            {
                MenuList.Add(option);
            }
        }
        static int origRow = Console.CursorTop;
        static int origCol = Console.CursorLeft;
        static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
        static int i = 0;
        public static void DisplayMenu()
        {
            Console.CursorVisible = false;
            
            Console.WriteLine("Menu:");
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;
            foreach (var item in MenuList)
            {
                if (i == item._id)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine($" {(char)16}  {item._optionText}");
                    Console.ResetColor();
                }
                else Console.WriteLine($"[ ] {item._optionText}");
            }
        }
        public void Interface()
        {
            DisplayMenu();
            Console.CursorVisible = false;
            bool[] selected = new bool[MenuList.Count()];
            ConsoleKeyInfo info;
            do
            {
                info = Console.ReadKey(true);
                if (info.Key == ConsoleKey.UpArrow)
                {
                    i--;
                    if (i < 0) i = 0;
                    if (!selected[i + 1])
                    {
                        Console.ResetColor();
                        WriteAt($"[ ] {MenuList[i + 1]._optionText}   ", 0, i + 1);
                    }
                    if (selected[i + 1] || selected[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        WriteAt($"[█] {MenuList[i + 1]._optionText}   ", 0, i + 1);
                        Console.ResetColor();
                    }
                    if (!selected[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        WriteAt($" {(char)16}  {MenuList[i]._optionText}", 0, i);
                        Console.ResetColor();
                    }
                    if (selected[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        WriteAt($"[█] {MenuList[i]._optionText} {(char)17}   ", 0, i);
                        Console.ResetColor();
                    }
                }
                if (info.Key == ConsoleKey.DownArrow)
                {
                    i++;
                    if (i >= MenuList.Count()) i = MenuList.Count() - 1;

                    if (!selected[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        WriteAt($" {(char)16}  {MenuList[i]._optionText}", 0, i);
                        Console.ResetColor();
                    }
                    if (!selected[i - 1])
                    {
                        Console.ResetColor();
                        WriteAt($"[ ] {MenuList[i - 1]._optionText}   ", 0, i - 1);
                    }
                    if (selected[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        WriteAt($"[█] {MenuList[i]._optionText} {(char)17}", 0, i);
                        Console.ResetColor();
                    }
                    if (selected[i - 1])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        WriteAt($"[█] {MenuList[i - 1]._optionText}   ", 0, i - 1);
                        Console.ResetColor();
                    }
                }
                if (info.Key == ConsoleKey.Spacebar)
                {
                    selected[i] = selected[i] ? false : true;
                    if (!selected[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        WriteAt($" {(char)16}  {MenuList[i]._optionText}  ", 0, i);
                        Console.ResetColor();
                        SelectedOptions.Remove(MenuList[i]);
                    }
                    if (selected[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        WriteAt($"[█] {MenuList[i]._optionText} {(char)17}   ", 0, i);
                        Console.ResetColor();
                        SelectedOptions.Add(MenuList[i]);
                    }
                }
                if (info.Key == ConsoleKey.N)
                {
                    Sort.DataToSort = Sort.OrderByName();
                    ConsolePrint.DisplaySort();
                }
                if (info.Key == ConsoleKey.A)
                {
                    Sort.DataToSort = Sort.OrderByAddress();
                    ConsolePrint.DisplaySort();
                }
                if (info.Key == ConsoleKey.R)
                {
                    Sort.DataToSort = Sort.OrderByAverageOverall();
                    ConsolePrint.DisplaySort();
                }
                if (info.Key == ConsoleKey.P)
                {
                    Sort.DataToSort = Sort.OrderByPrice();
                    ConsolePrint.DisplaySort();
                }
                if (info.Key == ConsoleKey.Enter)
                {
                    
                    if (!selected[i])
                    {
                        SelectedOptions.Add(MenuList[i]);
                    }
                    Console.Clear();
                    DisplayMenu();

                    if (SelectedOptions.Count() > 1)
                    {
                        MultipleOptions = true;
                    }
                    else MultipleOptions = false;
                    nextline = 0;
                    var last = SelectedOptions.Last();
                    if (HotelService.Data.Count != 0 && MultipleOptions)
                    {
                        DataCopy.Clear();
                        DataCopy.AddRange(HotelService.Data);

                        foreach (var item in SelectedOptions)
                        {
                            selected[item._id] = false;
                            Console.ResetColor();
                            origRow = MenuList.Count() + 2 + nextline;
                            origCol = 0;
                            Console.SetCursorPosition(origCol, origRow);
                            item._menuOptions();
                            nextline++;
                        }
                        Sort.DataOrder(HotelService.Data);
                        if (HotelService.Data.Count() > 0) { ConsolePrint.DisplaySort(); }
                        MultipleOptions = false;
                        HotelService.Data.Clear();
                        HotelService.Data.AddRange(DataCopy);
                        Console.CursorVisible = false;
                    }
                    else
                    {
                        selected[i] = false;
                        Console.ResetColor();
                        origRow = MenuList.Count() + 2 + nextline;
                        origCol = 0;
                        Console.SetCursorPosition(origCol, origRow);
                        SelectedOptions[0]._menuOptions();
                    }
                    SelectedOptions.Clear();
                    origRow = 1;
                    origCol = 0;
                    Console.SetCursorPosition(origCol, origRow);
                }
            } while (true);
        }
    }
    public delegate void Options();
}



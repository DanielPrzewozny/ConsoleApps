using System;
using TravelerAppCore.Controller;
using TravelerAppCore.Models.Hotels;
using TravelerAppCore.View;


namespace TravelerAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(140, 50);

            Option[] options = new Option[] {
                new Option("Load hotels collection", HotelService.ReadAndDisplay),
                new Option("Register hotel", new Hotel().CreateNew),
                new Option("Search with localisation", ConsolePrint.SearchAddressConsole),
                new Option("Find by name", ConsolePrint.SearchByNameConsole),
                new Option("Find by rate", ConsolePrint.SearchByRate),
                new Option("Exit", ConsolePrint.Exit),
            };
            new Menu(options).Interface();
        }
    }
}

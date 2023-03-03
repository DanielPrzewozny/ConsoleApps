using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TravelerAppCore.Models.Hotels;
using TravelerAppCore.View;

namespace TravelerAppCore.Controller
{
    public class HotelService
    {
        public static Stopwatch stopper = new Stopwatch();
        public static List<Hotel> Data = new List<Hotel>();
        public static void ReadAndDisplay()
        {
            Read();
            Sort.DataOrder(HotelService.Data);
            ConsolePrint.DisplayLoadedData();
        }
        public static void Read()
        {
            stopper = new Stopwatch();
            stopper.Start();
            Data.Clear();
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, @"..\..\..\..\TravelerAppCore\Data\JSON_Hotels");
            string sFilePath = Path.GetFullPath(sFile);
            string[] jsonFiles = Directory.GetFiles(sFilePath, "*.json").Select(Path.GetFileName).ToArray();
            foreach (var item in jsonFiles)
            {
                string sFileJson = Path.Combine(sFilePath, item);
                try
                {
                    string jsonFromFiles;
                    using (StreamReader reader = new StreamReader(sFileJson))
                    {
                        jsonFromFiles = reader.ReadToEnd();
                        Data.Add(JsonConvert.DeserializeObject<Hotel>(jsonFromFiles));
                    }
                }
                catch (Exception ex)
                {
                }
            }
            FixAddress();
            stopper.Stop();
        }
        public static void FixAddress()
        {
            foreach (Hotel hotel in Data)
            {
                var address = Regex.Replace(hotel.HotelInfo.Address, "<.*?>", string.Empty);
                Regex rg = new Regex(@"(?<street>.+),\s(?<city>.+),\s(?<postalCode>.+)");
                var addressMatch = rg.Match(address);
                string street = addressMatch.Groups["street"].Value;
                string city = addressMatch.Groups["city"].Value;
                string postalCode = addressMatch.Groups["postalCode"].Value;
                street = street.Trim();
                city = city.Trim();
                postalCode = postalCode.Trim();
                hotel.HotelInfo.Address = $"{city}, {street}, {postalCode}";
            }
        }
        public static void WriteAndDisplay()
        {
            Write(Hotel.NewHotel);
            ConsolePrint.DisplaySavedData();
        }
        public static void Write(Hotel Object)
        {
            string JsonFile = JsonConvert.SerializeObject(Object);
            string CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string File = Path.Combine(CurrentDirectory, @"..\..\..\..\TravelerAppCore\Data\JSON_Hotels");
            string FilePath = Path.GetFullPath(File);
            Console.WriteLine("\nEnter the name of file to save");
            string Name = Console.ReadLine();
            string FileJson = Path.Combine(FilePath, $"{Name}.json");
            try
            {
                using (StreamWriter sw = new StreamWriter(FileJson))
                {
                    sw.WriteLine(JsonFile);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}

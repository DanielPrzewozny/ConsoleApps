using System;
using System.Collections.Generic;
using TravelerAppCore.View;
using System.Linq;

namespace TravelerAppCore.Models.Hotels
{
    public class Hotel
    {
        public List<Review> Reviews { get; set; }
        public HotelInfo HotelInfo { get; set; }
        private Ratings averages;
        public Ratings AverageRates
        {
            get
            {
                averages = new Ratings()
                {
                    Service = (float)Math.Round(Reviews.Average(a => a.Ratings.Service), 2),
                    Cleanliness = (float)Math.Round(Reviews.Average(a => a.Ratings.Cleanliness), 2),
                    Value = (float)Math.Round(Reviews.Average(a => a.Ratings.Value), 2),
                    SleepQuality = (float)Math.Round(Reviews.Average(a => a.Ratings.SleepQuality), 2),
                    Rooms = (float)Math.Round(Reviews.Average(a => a.Ratings.Rooms), 2),
                    Location = (float)Math.Round(Reviews.Average(a => a.Ratings.Location), 2)
                };
                return averages;
            }
        }
        public static Hotel NewHotel = new Hotel();
        public void CreateNew()
        {
            NewHotel = new Hotel()
            {
                HotelInfo = new HotelInfo()
                {
                    Name = ConsolePrint.GetNewName(),
                    HotelURL = "default",
                    Price = ConsolePrint.GetNewPrice(),
                    Address = ConsolePrint.GetNewAddress(),
                    HotelID = "default",
                    ImgURL = "default"
                },
                Reviews = new List<Review>() {
                    new Review() {
                    Ratings = new Ratings() {
                        Service = ConsolePrint.GetRateService(),
                        Cleanliness = ConsolePrint.GetRateCleanliness(),
                        Value = ConsolePrint.GetRateValue(),
                        SleepQuality = ConsolePrint.GetRateSleepQuality(),
                        Rooms = ConsolePrint.GetRateRooms(),
                        Location = ConsolePrint.GetRateLocation()
                        } } }
            };
            ConsolePrint.SaveToFile();
        }
    }
}

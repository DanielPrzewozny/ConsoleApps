using Newtonsoft.Json;
using System;

namespace TravelerAppCore.Models.Hotels
{
    public class Ratings
    {
        public float Overall {
            get
            {
                return (float)Math.Round((Service + Cleanliness + Value + SleepQuality + Rooms + Location) / 6, 2);
            }
        }
        public float Service { get; set; }
        public float Cleanliness { get; set; }
        public float Value { get; set; }
        public float SleepQuality { get; set; }
        public float Rooms { get; set; }
        public float Location { get; set; }

        [JsonProperty("Checkin/frontdesk")]
        public string CheckinFrontdesk { get; set; }

        [JsonProperty("Businessservice(e.g.,internetaccess)")]
        public string BusinessserviceEGInternetaccess { get; set; }
    }
}

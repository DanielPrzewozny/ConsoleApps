using System.Collections.Generic;
using System.Linq;
using TravelerAppCore.Models.Hotels;

namespace TravelerAppCore.Controller
{
    public class Sort
    {
        public static List<Hotel> DataToSort = new List<Hotel>();
        private static bool orderByHotelName;
        private static bool orderByHotelAddress;
        private static bool orderByAverageRates;
        private static bool orderByPrice;

        public static List<Hotel> OrderByName()
        {
            orderByHotelName = orderByHotelName is false ? true : orderByHotelName is true ? false : true;
            if (!orderByHotelName)
                return DataToSort.OrderBy(x => x.HotelInfo.Name).ToList();
            else
                return DataToSort.OrderByDescending(x => x.HotelInfo.Name).ToList();
        }
        public static List<Hotel> OrderByAddress()
        {
            orderByHotelAddress = orderByHotelAddress is false ? true : orderByHotelAddress is true ? false : true;
            if (!orderByHotelAddress)
                return DataToSort.OrderBy(x => x.HotelInfo.Address).ToList();
            else
                return DataToSort.OrderByDescending(x => x.HotelInfo.Address).ToList();
        }
        public static List<Hotel> OrderByAverageOverall()
        {
            orderByAverageRates = orderByAverageRates is false ? true : orderByAverageRates is true ? false : true;
            if (!orderByAverageRates)
                return DataToSort.OrderBy(x => x.AverageRates.Overall).ToList();
            else
                return DataToSort.OrderByDescending(x => x.AverageRates.Overall).ToList();
        }
        public static List<Hotel> OrderByPrice()
        {
            orderByPrice = orderByPrice is false? true : orderByPrice is true ? false : true;
            if (!orderByPrice)
                return DataToSort.OrderBy(x => x.HotelInfo.Price).ToList();
            else
                return DataToSort.OrderByDescending(x => x.HotelInfo.Price).ToList();
        }
        public static void DataOrder(List<Hotel> DataOrder)
        {
            Sort.DataToSort.Clear();
            Sort.DataToSort.AddRange(DataOrder);
        }
    }
}

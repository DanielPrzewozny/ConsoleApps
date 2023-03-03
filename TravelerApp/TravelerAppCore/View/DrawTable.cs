using System;
using System.Collections.Generic;
using TravelerAppCore.Models.Hotels;

namespace TravelerAppCore.View
{
    public class DrawTable
    {
        public static int tableWidth;
        public static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }
        public static void PrintRow(bool newline, params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "";
            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }
            if (newline) { Console.WriteLine(row); }
            else Console.Write(row);
        }
        public static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;
            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
        public static void Hotelinfo(List<Hotel> dataReaded, int numRecords, bool withRate)
        {
            DrawTable.tableWidth = 135;
            DrawTable.PrintLine();
            DrawTable.tableWidth = 5;
            DrawTable.PrintRow(false, "Id");
            DrawTable.tableWidth = 60;
            DrawTable.PrintRow(false, "Name");
            DrawTable.tableWidth = 15;
            DrawTable.PrintRow(false, "Price");
            DrawTable.tableWidth = 40;
            DrawTable.PrintRow(false, "Address");
            DrawTable.tableWidth = 15;
            if (withRate) { DrawTable.PrintRow(true, "Rate"); }
            else { DrawTable.PrintRow(true, "Hotel ID"); }
            DrawTable.tableWidth = 135;
            DrawTable.PrintLine();
            for (int i = 0; i < numRecords; i++)
            {
                DrawTable.tableWidth = 5;
                DrawTable.PrintRow(false, (i + 1).ToString());
                DrawTable.tableWidth = 60;
                DrawTable.PrintRow(false, dataReaded[i].HotelInfo.Name);
                DrawTable.tableWidth = 15;
                DrawTable.PrintRow(false, dataReaded[i].HotelInfo.Price);
                DrawTable.tableWidth = 40;
                DrawTable.PrintRow(false, dataReaded[i].HotelInfo.Address);
                DrawTable.tableWidth = 15;
                if (withRate) { DrawTable.PrintRow(true, (dataReaded[i].AverageRates.Overall).ToString("0.00")); }
                else { DrawTable.PrintRow(true, dataReaded[i].HotelInfo.HotelID); }
            }
            DrawTable.tableWidth = 135;
            DrawTable.PrintLine();
        }
    }
}

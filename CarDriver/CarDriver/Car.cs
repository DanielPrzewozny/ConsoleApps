using System;
using System.Collections.Generic;
using System.Linq;

namespace CarProject
{
    public class Car
    {
        public bool isRunning;
        public bool isMoving;

        public string Company { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Power { get; set; }
        public double Weight { get; set; }
        public double TopSpeed { get; set; }

        public Car() { }
        public Car(string company, string model, int year, double powerOutput, double weight, double topSpeed)
        {

            this.Company = company;
            this.Model = model;
            this.Year = year;
            this.Power = powerOutput;
            this.Weight = weight;
            this.TopSpeed = topSpeed;
        }

        public void ListOfCars(List<Car> Car)
        {
            DrawTable.tableWidth = 100;
            DrawTable.PrintLine();
            DrawTable.PrintRow(true, "Id", "Company", "Model", "Premiere", "Power (KM)", "Weight (kg)", "Top speed (mph)");
            DrawTable.PrintLine();
            int count = 1;
            foreach (var car in Car)
            {
                DrawTable.PrintRow(true, count.ToString(), car.Company, car.Model, car.Year.ToString(), car.Power.ToString(), car.Weight.ToString(), car.TopSpeed.ToString());

                count++;
            }
            DrawTable.PrintRow(true, "", "", "", "", "", "", "");
            DrawTable.PrintLine();
        }

        public int ChoseCar(List<Car> Car)
        {
            Console.WriteLine("\n\nChoose Your car: ");
            int carNum = 0;
            while (!int.TryParse(Console.ReadLine(), out carNum) || carNum < 1 || carNum > 3)
            {
                Console.WriteLine("Choose again (id 1-3)! \n");
            }
            carNum = carNum - 1;
            return carNum;
        }

        public void OnTheStreet(int carNum, List<Car> Car)
        {
            Console.WriteLine("Selected : {0} {1} from year {2}\n", Car[carNum].Company, Car[carNum].Model, Car[carNum].Year, Car[carNum].TopSpeed);
            Console.WriteLine("Choose the options with following buttons: \n" +
                              "[E] Run the engine\n" +
                              "[Q] Turn off the engine\n" +
                              "[W] Accelerate\n" +
                              "[S] Stop the car\n" +
                              "[F] Check the fastest car in Your garage\n" +
                              "[ESC] Exit\n");

            DrawTable.tableWidth = 77;
            DrawTable.PrintLine();
            DrawTable.tableWidth = 15;
            DrawTable.PrintRow(false, "Time");
            DrawTable.tableWidth = 60;
            DrawTable.PrintRow(true, $"({Car[carNum].Company} {Car[carNum].Model}) Log:");
            DrawTable.tableWidth = 77;
            DrawTable.PrintLine();

            ConsoleKeyInfo info;
            do
            {
                info = Console.ReadKey(true);
                if (info.Key == ConsoleKey.E)
                {
                    StartEngine();
                }
                if (info.Key == ConsoleKey.Q)
                {
                    StopEngine();
                }
                if (info.Key == ConsoleKey.W)
                {
                    Move();
                }
                if (info.Key == ConsoleKey.S)
                {
                    Stop();
                }
                if (info.Key == ConsoleKey.F)
                {
                    Car carFastest = TheFastest(Car);
                    Console.WriteLine($"\n\n- The fastest car in your garage is {carFastest.Company} {carFastest.Model} with a top speed of {carFastest.TopSpeed} mph ({Math.Round(carFastest.TopSpeed * 1.609344, 0)} km/h)");
                    List<Car> Fastest = new List<Car>();
                    Fastest.Add(carFastest);
                    ListOfCars(Fastest);
                }
            } while (info.Key != ConsoleKey.Escape);
        }

        public void StartEngine()
        {
            if (!isRunning && !isMoving)
            {
                isRunning = isRunning ? false : true;
                Log($" - The engine has been started");
            }
            else { Log($" - The engine has already started"); }
        }

        public void StopEngine()
        {
            if (isRunning && !isMoving)
            {
                isRunning = isRunning ? false : true;
                Log($" - Engine has stopped");
            }
            else if (isRunning && isMoving) { Log($" - Dont turn off the engine if car is in move"); }
            else { Log($" - The engine has already turned off"); }
        }

        public void Move()
        {
            if (!isMoving && isRunning)
            {
                isMoving = isMoving ? false : true;
                Log($" - Car is in move");
            }
            else if (isMoving && isRunning) Log($" - Car is in move");
            else if (!isRunning) Log($" - At first turn on the engine");
        }

        public void Stop()
        {
            if (isMoving)
            {
                isMoving = isMoving ? false : true;
                Log($" - Car has stopped");
            }
            else { Log($" - The car has stopped and doesn't move"); }
        }

        public Car TheFastest(List<Car> Car)
        {
            double mn = Car[0].TopSpeed;
            int numCarmn = 0;

            return Car.MaxBy(c => c.TopSpeed);
        }

        public void Log(string events)
        {
            DateTime localDate = DateTime.Now;
            DrawTable.tableWidth = 15;
            DrawTable.PrintRow(false, localDate.ToString("hh:mm:ss"));
            DrawTable.tableWidth = 60;
            DrawTable.PrintRow(true, events);
        }
    }
}
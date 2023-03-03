using System;
using System.Collections.Generic;

namespace CarProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> Car = new List<Car>() {
                new Car(
                company: "Hennessey",
                model: "Venom F5",
                year: 2020,
                powerOutput: 1355, //kW
                weight: 1385,
                topSpeed: 301), //mhp
            new Car(
                company: "Bugatti",
                model: "Chiron Super Sport 300+",
                year: 2021,
                powerOutput: 1176, //kW
                weight: 1365,
                topSpeed: 304), //mhp
            new Car(
                company: "9ff",
                model: "GT9-CS",
                year: 2007,
                powerOutput: 736, //kW
                weight: 1385,
                topSpeed: 257) //mhp
        };
            


            Car[0].ListOfCars(Car);                                //Displays the list of cars
            Car[0].OnTheStreet(Car[0].ChoseCar(Car), Car);         //Navigation with logs
        }
    }
}

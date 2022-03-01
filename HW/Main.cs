using System;
using System.Collections.Generic;

namespace HW_2021_OOP
{
    class Program
    {
        static GUI getUnitSystem()
        {
            string input = "";
            while (input != "imperial" && input != "metric")
            {
                Console.WriteLine("Please enter imperial or metric");
                input = Console.ReadLine();
            }
            return input == "imperial" ? new ImperialGUI() : new MetricGUI();
        }

        static void Main(string[] args)
        {
            GUI gui = getUnitSystem();
            Car car = new Car(); car.SetDesiredSpeed(65.0);
            Truck truck1 = new Truck(4); truck1.SetDesiredSpeed(55.0);
            Truck truck2 = new Truck(8); truck2.SetDesiredSpeed(50.0);

            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles.Add(car); vehicles.Add(truck1); vehicles.Add(truck2);

            for (int i = 0; i < 11; i++)
            {
                foreach (Vehicle v in vehicles)
                {
                    v.UpdateSpeed(1);
                    string vehicleType = v.GetType().ToString();
                    Console.WriteLine("{0} speed: {1:F} {2}", vehicleType, gui.GetSpeed(v), gui.speedUnit);
                }
            }
            Console.Read();  // To keep terminal open after iteration is complete
        }
    }
}

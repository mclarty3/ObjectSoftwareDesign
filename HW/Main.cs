using System;
using System.Collections.Generic;

namespace HW_2021_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            ISimOutput simOutput = new MetricOutput();
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
                    Console.WriteLine("{0} speed: {1:F} kmph", vehicleType, simOutput.GetSpeed(v));
                }
            }
            Console.Read();  // To keep terminal open after iteration is complete
        }
    }
}

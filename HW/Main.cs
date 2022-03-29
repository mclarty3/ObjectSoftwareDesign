using System;
using System.Collections.Generic;

namespace HW_2021_OOP
{
    class Program : ISimInput, ISimOutput
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
            GUI simInput;
            Map map = new Map();
            IPrintDriver cp = new ConsolePrint();
            //Console.Write("Enter 'M' for metric or 'I' for Imperial: ");
            //string units = Console.ReadLine();
            //Console.Write("Enter speed limit: ");
            //double speedLimit = Convert.ToDouble(Console.ReadLine());
            //if (units == "I") gui = new ImperialGUI();
            //else gui = new MetricGUI();
            //Car car = new Car(); gui.SetSpeedLimit(car, speedLimit);
            //Truck truck1 = new Truck(4); gui.SetSpeedLimit(truck1, speedLimit);
            //Truck truck2 = new Truck(8); gui.SetSpeedLimit(truck2, speedLimit);
            //List<Vehicle> vehicles = new List<Vehicle>();
            //vehicles.Add(car); vehicles.Add(truck1); vehicles.Add(truck2);
            //for (int i = 0; i < 11; i++)
            //{
            //    foreach (Vehicle v in vehicles)
            //    {
            //        v.UpdateSpeed(1);
            //        string s = v.GetType().ToString();
            //        Console.WriteLine("{0} speed: {1:F}", s, gui.GetSpeed(v));
            //    }
            //}
            simInput = new MetricGUI();
            Road Uptown = simInput.CreateRoad("Uptown", 0.0, -0.09, .180, Heading.North);
            map.AddRoad(Uptown);
            Road Crosstown = simInput.CreateRoad("Crosstown", -0.09, 0.0, .180, Heading.East);
            map.AddRoad(Crosstown);

            CharMatrix cm = new CharMatrix();
            map.Print(cp, cm);
            for (int i = 0; i < Constants.CharMapSize; i++)
            {
                string s = new string(cm.map[i]);
                Console.WriteLine(s);
            }
            Console.Read();
        }

        public double GetSpeed(Vehicle v)
        {
            return v.GetCurrentSpeed() * Constants.MpsToMph;
        }

        public void SetSpeedLimit(Vehicle v, double speed)
        {
            v.SetDesiredSpeed(speed / Constants.MpsToMph);
        }
    }
}

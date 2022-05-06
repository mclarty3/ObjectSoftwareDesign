using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

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
            GUI gui = new ImperialGUI();

			Map map = new Map();

            using (StreamReader r = new StreamReader("finalInput.json"))
            {
                string json = r.ReadToEnd();
                map = Map.FromJson(json, gui);
            }

            IPrintDriver cp = new ConsolePrint();
            IPrintDriver dp = new DebugPrint();

            // Console.Write("Enter 'M' for metric or 'I' for Imperial: ");
            // string units = Console.ReadLine();
            // Console.Write("Enter speed limit: ");
            // double speedLimit = Convert.ToDouble(Console.ReadLine());
            // gui = units == "I" ? new ImperialGUI() : new MetricGUI();

            double speedLimit = 65;

            Car car = new Car();
            gui.SetSpeedLimit(car, speedLimit);
            Truck truck1 = new Truck(4);
            gui.SetSpeedLimit(truck1, speedLimit);
            Truck truck2 = new Truck(8);
            gui.SetSpeedLimit(truck2, speedLimit);
            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles.Add(car); vehicles.Add(truck1); vehicles.Add(truck2);

            for (int i = 0; i < 11; i++)
            {
               foreach (Vehicle v in vehicles)
               {
                   v.UpdateSpeed(1);
                   string s = v.GetType().ToString();
                   Console.WriteLine("{0} speed: {1:F}", s, gui.GetSpeed(v));
               }
            }

            Road Uptown = map.GetRoads().First(r => r.GetName() == "Uptown");
            Uptown.AddRoadItem(gui.CreateSpeedLimit(speedLimit, 10));
            Uptown.AddRoadItem(gui.CreateSpeedLimit(speedLimit, 165));

            Road Crosstown = map.GetRoads().First(r => r.GetName() == "Crosstown");
            Crosstown.AddRoadItem(gui.CreateStopSign(170));
            Crosstown.AddRoadItem(gui.CreateSpeedLimit(22, 160));

            map.ToJson("finalOutput.json", gui);

            CharMatrix cm = new CharMatrix();
            map.Print(cp, cm);
            for (int i = 0; i < Constants.CharMapSize; i++)
            {
                string s = new string(cm.map[i]);
                Console.WriteLine(s);
            }
            Console.Read();
        }
    }
}

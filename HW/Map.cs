using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace HW_2021_OOP
{
    public class Map
    {
        [JsonProperty("Roads")]
        private List<Road> roads { get; set; }

        public Map()
        {
            roads = new List<Road>();
        }

		public List<Road> GetRoads() { return roads; }

        public static Map FromJson(string json, GUI gui)
        {
            JObject jObject = JObject.Parse(json);

            JArray jArray = (JArray)jObject["Roads"];

            Map map = new Map();
            List<Road> roads = new List<Road>();

            foreach (JObject j in jArray)
            {
                string type = (string)j["Type"];
                double length = (double)j["Length"];
                double xlocation = (double)j["XLocation"];
                double ylocation = (double)j["YLocation"];
                string headingStr = (string)j["Heading"];
                string name = (string)j["Name"];
                Heading heading = (Heading)Enum.Parse(typeof(Heading), headingStr);
                JArray jArray2 = (JArray)j["RoadItems"];

                Road road = gui.CreateRoad(name, xlocation, ylocation, length, heading);

                foreach (JObject j2 in jArray2)
                {
                    string type2 = (string)j2["Type"];
                    double mileMarker = (double)j2["MileMarker"];
                    RoadItem roadItem;

                    if (type2 == "StopSign")
                    {
                        roadItem = gui.CreateStopSign(mileMarker);
                    }
                    else if (type2 == "SpeedLimit")
                    {
                        double speed = (double)j2["SpeedLimit"];
                        roadItem = gui.CreateSpeedLimit(speed, mileMarker);
                    }
                    else
                    {
                        break;
                    }
                    road.AddRoadItem(roadItem);
                }

                roads.Add(road);
            }

            map.roads = roads;

            return map;
        }

        public void ToJson(string filename, GUI gui)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                Map tempMap = new Map();
                tempMap.roads = new List<Road>();

                foreach (Road road in roads)
                {
                    tempMap.roads.Add(gui.GetInterfaceUnitRoad(road));
                }

                string json = JsonConvert.SerializeObject(tempMap);

                JObject reparsedJson = JObject.Parse(json);
                JArray parsedJsonRoads = (JArray)reparsedJson["Roads"];

                foreach (JObject j in parsedJsonRoads)
                {
                    foreach (Road road in roads)
                    {
                        if (road.GetRoadName() == (string)j["Name"])
                        {
                            List<RoadItem> items = new List<RoadItem>();
                            foreach (RoadItem roadItem in road.GetRoadItems())
                            {
                                items.Add(gui.GetInterfaceUnitRoadItem(roadItem));
                            }
                            string itemsJson = JsonConvert.SerializeObject(items);
                            j["RoadItems"] = JArray.Parse(itemsJson);
                        }
                    }
                }

                sw.Write(reparsedJson.ToString());
            }
        }

        public void AddRoad(Road road)
        {
            roads.Add(road);
        }

        public void Print(IPrintDriver pd, Object o, GUI gui)
        {
            foreach (Road road in roads)
            {
                road.Print(pd, o, gui);
            }
        }

        public double CalculateWorldSize()
        {
            double maxX = 0;
            double maxY = 0;
            foreach (Road road in roads)
            {
                if (road.GetXLocation() > maxX)
                {
                    maxX = road.GetXLocation();
                }
                if (road.GetYLocation() > maxY)
                {
                    maxY = road.GetYLocation();
                }

                if (road.GetHeading() == Heading.North)
                {
                    if (road.GetYLocation() + road.GetLength() > maxY)
                    {
                        maxX = road.GetYLocation() + road.GetLength();
                    }
                }
                else if (road.GetHeading() == Heading.East)
                {
                    if (road.GetXLocation() + road.GetLength() > maxX)
                    {
                        maxY = road.GetXLocation() + road.GetLength();
                    }
                }
            }

            return Math.Max(maxX, maxY);
        }
    }
}

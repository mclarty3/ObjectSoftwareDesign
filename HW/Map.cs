using System;
using System.Collections.Generic;
// using System.Text.Json;
// using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.IO;

namespace HW_2021_OOP
{
    class Map
    {
        [JsonProperty("Roads")]
        private List<Road> roads;

        public Map()
        {
            roads = new List<Road>();
        }

        public static Map FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Map>(json);
        }

        public void ToJson(string filename)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(filename))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, this);
            }
        }

        public void AddRoad(Road road)
        {
            roads.Add(road);
        }

        public void Print(IPrintDriver pd, Object o)
        {
            foreach (Road road in roads)
            {
                road.Print(pd, o);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using JsonSubTypes;

namespace HW_2021_OOP
{
    public abstract class StaticRoadItem : RoadItem
    {
        public StaticRoadItem(double distance)
        {
            SetMileMarker(distance);
        }
    }

    public class StopSign : StaticRoadItem
    {
        public string Type { get; } = "StopSign";
        public StopSign(double distance) : base(distance) { }

        public override char[] GetChar()
        {
            return new char[] { 'S' };
        }
    }

    public class Intersection : StaticRoadItem
    {
        public List<Road> connecting_roads;

        public Intersection(double distance) : base(distance)
        {
            connecting_roads = new List<Road>();
        }
    }

    public class SpeedLimit : StaticRoadItem
    {
        public string Type { get; } = "SpeedLimit";

		[JsonProperty("SpeedLimit")]
        private double speedLimit { get; set; }

        public SpeedLimit(double speedLimit, double distance) : base(distance)
        {
            this.speedLimit = speedLimit;
        }

        public double GetSpeedLimit() { return speedLimit; }

        public override char[] GetChar()
        {
            string speedLimitString = ((int)speedLimit).ToString();
            return speedLimitString.ToCharArray();
        }
    }

    public class Yield : StaticRoadItem
    {
        public Yield(double distance) : base(distance) { }
    }
}
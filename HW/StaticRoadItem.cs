using System;
using System.Collections.Generic;

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
        public StopSign(double distance) : base(distance) { }
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
        private double speedLimit;

        public SpeedLimit(double speedLimit, double distance) : base(distance)
        {
            this.speedLimit = speedLimit;
        }
    }

    public class Yield : StaticRoadItem
    {
        public Yield(double distance) : base(distance) { }
    }
}
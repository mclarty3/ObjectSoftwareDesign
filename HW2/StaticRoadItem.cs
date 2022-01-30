using System;

public class StaticRoadItem : RoadItem
{
    
}

public class StopSign : StaticRoadItem
{

}

public class Intersection : StaticRoadItem
{
    public List<Road> connecting_roads;
}

public class SpeedLimit : StaticRoadItem
{

}

public class Yield : StaticRoadItem
{

}
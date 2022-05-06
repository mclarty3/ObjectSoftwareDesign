using System;

namespace HW_2021_OOP
{
	public abstract class DynamicRoadItem : RoadItem
	{

	}

	public class TrafficLight : DynamicRoadItem
	{
		public override char[] GetChar()
		{
			return new char[] { 'T' };
		}
	}
}
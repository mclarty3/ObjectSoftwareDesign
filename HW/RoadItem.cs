using System;

namespace HW_2021_OOP
{
	public abstract class RoadItem
	{
		private Road currentRoad;
		private RoadItem previous;
		private RoadItem next;
		private double mileMarker = 0.0f;

		public void SetCurrentRoad(Road road)
		{
			currentRoad = road;
		}

		public Road GetCurrentRoad()
		{
			return currentRoad;
		}

		public void SetPrevious(RoadItem previous)
		{
			this.previous = previous;
		}

		public RoadItem GetPrevious()
		{
			return previous;
		}

		public void SetNext(RoadItem next)
		{
			this.next = next;
		}

		public RoadItem GetNext()
		{
			return next;
		}

		public double GetMileMarker()
		{
			return mileMarker;
		}

		public void SetMileMarker(double distance)
		{
			mileMarker = distance;
		}
	}
}
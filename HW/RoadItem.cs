using System;
using Newtonsoft.Json;
using JsonSubTypes;

namespace HW_2021_OOP
{
	[JsonConverter(typeof(JsonSubtypes), "Type")]
	public abstract class RoadItem
	{
		string Type { get; }
		private Road currentRoad = null;
		private RoadItem previous = null;
		private RoadItem next = null;

		[JsonProperty("MileMarker")]
		private double mileMarker { get; set; } = 0.0f;

		public virtual char[] GetChar() { return new char[] { ' ' }; }

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
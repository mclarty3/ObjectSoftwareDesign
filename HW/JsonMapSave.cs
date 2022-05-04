namespace HW_2021_OOP
{
	public class JsonMapSave : ISaveDriver {
			public void SaveMap(Map map, string filename) {
				map.ToJson(filename);
			}
			public void SaveRoad(Road road) {}
			public void SaveStopSign(StopSign stopSign) {}
			public void SaveSpeedLimit(SpeedLimit speedLimit) {}
	}
}

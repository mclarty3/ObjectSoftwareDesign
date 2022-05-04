namespace HW_2021_OOP
{
    public interface ISaveDriver
    {
        void SaveMap(Map map, string filename);
		void SaveRoad(Road road);
		void SaveStopSign(StopSign stopSign);
		void SaveSpeedLimit(SpeedLimit speedLimit);
    }
}
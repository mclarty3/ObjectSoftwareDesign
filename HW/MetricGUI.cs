using System;

namespace HW_2021_OOP
{
    class MetricGUI: GUI
    {
        public override Road CreateRoad(string name, double locx, double locy, double len, Heading hdg)
        {
            return new Road(name, locx / Constants.MetersToKm, locy / Constants.MetersToKm,
                            len / Constants.MetersToKm, hdg);
        }

        public override double  GetSpeed(Vehicle v)
        {
            return v.GetCurrentSpeed() * Constants.MpsToKph;
        }

        public override void SetSpeedLimit(Vehicle v, double speed)
        {
            v.SetDesiredSpeed(speed / Constants.MpsToKph);
        }

        public override SpeedLimit CreateSpeedLimit(double speed, double location = 0)
        {
            return new SpeedLimit(speed / Constants.MpsToKph, location / Constants.MetersToKm);
        }

        public override StopSign CreateStopSign(double location = 0)
        {
            return new StopSign(location / Constants.MetersToKm);
        }
    }
}
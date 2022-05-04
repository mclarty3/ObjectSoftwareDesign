using System;

namespace HW_2021_OOP
{
    class ImperialGUI : GUI
    {
        public override Road CreateRoad(string name, double locx, double locy, double len, Heading hdg)
        {
            return new Road(name, locx / Constants.MetersToMiles, locy / Constants.MetersToMiles, len / Constants.MetersToMiles, hdg);
        }
        public override double GetSpeed(Vehicle v)
        {
            return v.GetCurrentSpeed() * Constants.MpsToMph;
        }

        public override void SetSpeedLimit(Vehicle v, double speed)
        {
            v.SetDesiredSpeed(speed / Constants.MpsToMph);
        }

        public override SpeedLimit CreateSpeedLimit(double speed, double location = 0)
        {
            return new SpeedLimit(speed / Constants.MpsToMph, location / Constants.MetersToMiles);
        }

        public override StopSign CreateStopSign(double location = 0)
        {
            return new StopSign(location / Constants.MetersToMiles);
        }
    }
}
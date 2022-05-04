using System;

namespace HW_2021_OOP
{
    abstract class GUI : ISimInput, ISimOutput
    {
        public abstract Road CreateRoad(string name, double locx, double locy, double len, Heading hdg);
        public abstract double GetSpeed(Vehicle v);
        public abstract void SetSpeedLimit(Vehicle v, double speed);
        public abstract SpeedLimit CreateSpeedLimit(double speed, double location = 0);
        public abstract StopSign CreateStopSign(double location = 0);
    }
}
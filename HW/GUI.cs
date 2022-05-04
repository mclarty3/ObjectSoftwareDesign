using System;

namespace HW_2021_OOP
{
    abstract class GUI : ISimInput, ISimOutput
    {
        public abstract Road CreateRoad(string name, double locx, double locy, double len, Heading hdg);
        public abstract double GetSpeed(Vehicle v);
        public abstract void SetSpeedLimit(Vehicle v, double speed);
    }
}
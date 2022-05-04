using System;
using System.Collections.Generic;

namespace HW_2021_OOP
{
    interface ISimInput
    {
        Road CreateRoad(string name, double xPos, double yPos, double len, Heading heading);
        void SetSpeedLimit(Vehicle v, double speed);
        SpeedLimit CreateSpeedLimit(double speed, double location = 0);
        StopSign CreateStopSign(double location = 0);
    }
}
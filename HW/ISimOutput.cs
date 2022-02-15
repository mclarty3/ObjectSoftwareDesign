using System;
using System.Collections.Generic;

interface ISimOutput
{
    double GetSpeed(Vehicle v);
}

class ImperialOutput : ISimOutput
{
    public double GetSpeed(Vehicle v)
    {
        return v.GetCurrentSpeed();
    }
}

class MetricOutput : ISimOutput
{
    public double GetSpeed(Vehicle v)
    {
        return v.GetCurrentSpeed() * 1.6;
    }
}
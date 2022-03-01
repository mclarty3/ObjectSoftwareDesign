using System;

public abstract class GUI : ISimInput, ISimOutput
{
    public virtual string speedUnit { get; }
    public abstract void SetSpeedLimit(Vehicle v, double speed);
    public abstract double GetSpeed(Vehicle v);
}
using System;

public class MetricGUI: GUI
{
    public override string speedUnit { get { return "km/h"; } }
    public override void SetSpeedLimit(Vehicle v, double speed)
    {
        v.SetDesiredSpeed(speed / Constants.MpsToKph);
    }

    public override double GetSpeed(Vehicle v)
    {
        return v.GetCurrentSpeed() * Constants.MpsToKph;
    }
}
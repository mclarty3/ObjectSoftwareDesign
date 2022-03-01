using System;

public class ImperialGUI: GUI
{
    public override string speedUnit { get { return "mph"; } }
    public override void SetSpeedLimit(Vehicle v, double speed)
    {
        v.SetDesiredSpeed(speed / Constants.MpsToMph);
    }

    public override double GetSpeed(Vehicle v)
    {
        return v.GetCurrentSpeed() * Constants.MpsToMph;
    }
}
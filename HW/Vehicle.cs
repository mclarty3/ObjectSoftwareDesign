using System;

public abstract class Vehicle : DynamicRoadItem
{
    private double currentSpeed = 0.0;
    private double desiredSpeed;

    protected abstract void Accelerate(int secondsDelta);
    protected abstract void Decelerate(int secondsDelta);

    public double GetCurrentSpeed()
    {
        return currentSpeed;
    }

    public void SetDesiredSpeed(double mph)
    {
        desiredSpeed = mph;
    }

    protected void SetCurrentSpeed(double speed)
    {
        if (currentSpeed <= speed)  // Accelerating
        {
            if (speed > desiredSpeed) {
                currentSpeed = desiredSpeed;
            } else {
                currentSpeed = speed;
            }
        } else // Braking
        {
            if (speed < desiredSpeed) {
                currentSpeed = desiredSpeed;
            } else {
                currentSpeed = speed;
            }
        } 
    }

    public void UpdateSpeed(int seconds)
    {
        if (currentSpeed > desiredSpeed) {
            Decelerate(seconds);
        } else if (currentSpeed < desiredSpeed) {
            Accelerate(seconds);
        }
    }
}

public class Car : Vehicle
{
    protected override void Accelerate(int secondsDelta)
    {
        SetCurrentSpeed(GetCurrentSpeed() + Constants.AccRate * secondsDelta * Constants.MpsToMph);
    }

    protected override void Decelerate(int secondsDelta)
    {
        SetCurrentSpeed(GetCurrentSpeed() - Constants.DecRate * secondsDelta * Constants.MpsToMph);
    }
}

public class Truck : Vehicle
{
    private int loadWeight;  // in tons

    public Truck(int weight)
    {
        loadWeight = weight;
    }

    protected override void Accelerate(int secondsDelta)
    {
        double accRate = loadWeight <= 5 ? Constants.AccRateEmpty : Constants.AccRateFull;
        SetCurrentSpeed(GetCurrentSpeed() + accRate * secondsDelta * Constants.MpsToMph);
    }

    protected override void Decelerate(int secondsDelta)
    {
        double decRate = loadWeight <= 5 ? Constants.DecRateEmpty : Constants.DecRateFull;
        SetCurrentSpeed(GetCurrentSpeed() - decRate * secondsDelta * Constants.MpsToMph);
    }
}

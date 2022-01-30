using System;

public class Vehicle : DynamicRoadItem
{
    private float current_speed { get; private set; }
    private float desired_speed { get; private set; }
    private float current_direction { get; private set; }
    private float[] current_position { get; private set; }
    private int[] body_color { get; private set; }

    public Vehicle(float current_speed = 0, float current_direction = 0, float desired_speed = -1,
               float[] current_position = new float[2] {0, 0}, 
               float[] body_color = new float[3] {255, 255, 255})
    {
        this.current_speed = current_speed;
        this.desired_speed = desired_speed == -1 ? current_speed : desired_speed;
        this.current_direction = current_direction;
        this.current_position = current_position;
        this.body_color = body_color;
    }

    public void Brake(float toSpeed) { }

    public void Turn(float direction, float degrees) { }
}

public class Car : Vehicle
{

}

public class Truck : Vehicle
{
    private float load_weight;

    public Truck()
    {
        load_weight = 0;
    }

    public void SetLoadWeight(float weight) { }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Car
{
    private float current_speed;
    private float current_direction;
    private float[] current_position;

    public Car()
    {
        current_speed = 0;
        current_direction = 0;
        current_position = new float[2] {0, 0};
    }

    public void Accelerate(float toSpeed) { }

    public void Brake(float toSpeed) { }

    public void Turn(float direction, float degrees) { }
}

public class Truck : Car
{
    private float load_weight;

    public Truck()
    {
        load_weight = 0;
    }

    public void SetLoadWeight(float weight) { }
}
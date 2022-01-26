using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Car
{
    private float current_speed { get ; private set; }
    private float current_direction { get ; private set; }
    private float[] current_position { get ; private set; }

    public Car(float current_speed = 0, float current_direction = 0, 
               float[] current_position = new float[2] {0, 0})
    {
        this.current_speed = current_speed;
        this.current_direction = current_direction;
        this.current_position = current_position;
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
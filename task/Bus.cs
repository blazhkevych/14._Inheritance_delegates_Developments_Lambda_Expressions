namespace task;

internal class Bus : Car
{
    public Bus(string name, string model, int speed)
        : base(name, model, speed)
    {
        _speedRange = RNG.NextInt(2);
        _accelerationSpeed = RNG.NextInt(4);
        Graphics = "EO0)";
    }
}
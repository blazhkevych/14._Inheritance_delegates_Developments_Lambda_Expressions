namespace task;

internal class SportCar : Car
{
    public SportCar(string name, string model, int speed)
        : base(name, model, speed)
    {
        _speedRange = RNG.NextInt(4);
        _accelerationSpeed = RNG.NextInt(8);
        Graphics = "|O->";
    }
}
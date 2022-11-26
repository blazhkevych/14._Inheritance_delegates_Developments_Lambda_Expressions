namespace task;

internal class PassengerCar : Car
{
    public PassengerCar(string name, string model, int speed)
        : base(name, model, speed)
    {
        _speedRange = RNG.NextInt(3);
        _accelerationSpeed = RNG.NextInt(6);
        Graphics = "EH3";
    }
}
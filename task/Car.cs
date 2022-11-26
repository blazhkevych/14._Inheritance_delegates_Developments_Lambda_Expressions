namespace task;

// Делегат для события, создаваемого автомобилем.
internal delegate void CarEvent(Car car);

// Делегат для события гонки.
internal delegate void RaceEvent();

// Абстрактный класс Машины.
internal abstract class Car
{
    protected int _accelerationSpeed;
    private bool _reachedMaxSpeed;

    // Поля для внутреннего использования.
    protected int _speedRange;

    // Конструктор с параметрами.
    protected Car(string name, string model, int speed)
    {
        Name = name;
        Model = model;
        Speed = speed;
        TraveledDistance = 0;
        CurrentSpeed = 0;
        _reachedMaxSpeed = false;

        // Подписка на события гонки: её начало и обновление.
        Game.Instance.StartEvent += Start;
        Game.Instance.UpdateEvent += Update;
    }

    // Публичные поля.
    public string Name { get; protected set; }
    public string Model { get; protected set; }
    public int Speed { get; protected set; }
    public string Graphics { get; protected init; }
    public int TraveledDistance { get; private set; }

    public int CurrentSpeed { get; private set; }

    // Событие достижения машиной финишной линии.
    public event CarEvent FinishedEvent;

    // Событие достижения машиной максимальной скорости.
    public event CarEvent MaxSpeedEvent;

    // Событие для изменения машиной позиции на экране.
    public event CarEvent PositionChangedEvent;

    // Изменить текущую скорость машины.
    private void ChangeSpeed()
    {
        CurrentSpeed += _accelerationSpeed;

        var delta = RNG.R.Next() % _speedRange;
        var deltaPositive = (RNG.R.Next() & 1) == 0;

        if (deltaPositive)
            CurrentSpeed += delta;
        else if (CurrentSpeed > delta)
            CurrentSpeed -= delta;
    }

    // Начать гонку.
    private void Start()
    {
        Screen.DrawMessage($"\"{Name}\" started!");
    }

    // Обноаить состояние машины.
    private void Update()
    {
        ChangeSpeed();

        // Вызвать событие, если была достигнута максимальная скорость.
        if (CurrentSpeed >= Speed)
        {
            CurrentSpeed = Speed;

            if (!_reachedMaxSpeed)
            {
                MaxSpeedEvent?.Invoke(this);
                _reachedMaxSpeed = true;
            }
        }

        var oldDist = TraveledDistance / Game.GridSize;
        TraveledDistance += CurrentSpeed;
        var newDist = TraveledDistance / Game.GridSize;

        // Вызвать событие, если позиция машины на экране должна быть обновлена.
        if (newDist != oldDist)
            PositionChangedEvent?.Invoke(this);

        // Вызвать событие, если машина достигла линии финиша.
        if (TraveledDistance >= Game.TrackLength)
            FinishedEvent?.Invoke(this);
    }
}
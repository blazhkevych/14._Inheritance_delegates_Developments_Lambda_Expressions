namespace task;

// Класс управление гонкой.
internal class Game
{
    // Паттерн "Singleton".

    private static Game _instance;

    // Публичные статические поля.
    public static readonly int NumberOfCars = 4;
    public static readonly int TrackLength = 8000;
    public static readonly int GridSize = TrackLength / Screen._TRACK_WIDTH;

    // Поля для внутреннего пользования.
    private List<Car> _cars;
    private bool _raceFinished;

    public static Game Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Game();
            return _instance;
        }
    }

    // Событие начала гонки.
    public event RaceEvent StartEvent;

    // Событие обновления гонки.
    public event RaceEvent UpdateEvent;

    // Подготовить машины к гонке.
    public void PrepareCars()
    {
        // Инициализировать список машин.
        _cars = new List<Car>
        {
            new PassengerCar("Dad's Zhiguli", "Kopejka", RNG.NextInt(180, 20)),
            new CargoCar("Contra de Banda", "DJI-Mavic", RNG.NextInt(150, 25)),
            new Bus("Marshrutka", "9cX221", RNG.NextInt(190, 30)),
            new SportCar("Neighbor", "Tesla", RNG.NextInt(210, 35))
        };

        for (var i = 0; i < _cars.Count; ++i)
        {
            // Подписаться на события машин.
            _cars[i].MaxSpeedEvent += OnMaxSpeed;
            _cars[i].PositionChangedEvent += OnCarPositionChanged;
            _cars[i].FinishedEvent += OnFinish;

            // Нарисовать начальное состояние гонки.
            Screen.DrawTrack(i + 1);
            Screen.DrawCar(_cars[i], i + 1);
        }

        // Нарисовать начальную статистику гонки.
        Screen.DrawRaceInfo(_cars);
    }

    // Начать гонку.
    public void Start()
    {
        _raceFinished = false;

        // Отсчёт до начала гонки.
        for (var i = 3; i > 0; --i)
        {
            Screen.DrawMessage($"Race starts in {i}...");
            Thread.Sleep(1000);
        }

        // Вызвать событие начала гонки.
        StartEvent?.Invoke();
        Screen.DrawMessage("Race started!!");

        // Обновлять состояние гонки, пока она не будет завершена.
        while (!_raceFinished)
            Update();
    }

    // Обновить состояние гонки.
    private void Update()
    {
        // Вызвать событие обновления.
        UpdateEvent?.Invoke();
        // Задержка программы.
        Thread.Sleep(200);
    }

    // Метод, исполняемый при достижении машиной максимальной скорости.
    private void OnMaxSpeed(Car c)
    {
        if (!_raceFinished)
            Screen.DrawMessage($"\"{c.Name}\" reached maximum speed! ({c.Speed} km/h)");
    }

    // Метод, исполняемый при необходимости перерисовать машину.
    private void OnCarPositionChanged(Car c)
    {
        var track = _cars.IndexOf(c) + 1;
        Screen.DrawTrack(track);
        Screen.DrawCar(c, track);
        Screen.DrawRaceInfo(_cars);
    }

    // Метод, вызываемый по завершению гонки.
    private void OnFinish(Car c)
    {
        Screen.DrawMessage($"\"{c.Name}\" reached finish line! Race finished!!!");
        _raceFinished = true;
    }
}
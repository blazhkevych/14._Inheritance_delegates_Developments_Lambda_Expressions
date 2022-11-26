namespace task;

// Воспомогательный класс для отрисовки графики в консоли.
internal class Screen
{
    public static readonly int _TRACK_WIDTH = 72;
    private static readonly int _TRACK_HEIGHT = 1;
    private static readonly int _LEFT_OFFSET = 2;
    private static readonly int _TOP_OFFSET = 2;

    // Нарисовать гоночную дорожку для машины.
    public static void DrawTrack(int nTrack)
    {
        var top = (nTrack - 1) * _TRACK_HEIGHT + _TOP_OFFSET;
        Console.SetCursorPosition(_LEFT_OFFSET, top);

        Console.Write('|');
        for (int i = 0, len = _TRACK_WIDTH - 3; i < len; ++i)
            Console.Write('_');

        Console.Write((nTrack & 1) == 0 ? "|# " : "| #");
    }

    // Нарисовать машину на заданной дорожке.
    public static void DrawCar(Car car, int nTrack)
    {
        // Вычислить позицию машини на экране.
        var traveled = car.TraveledDistance / Game.GridSize;
        var left = _LEFT_OFFSET + traveled;
        var top = (nTrack - 1) * _TRACK_HEIGHT + _TOP_OFFSET;

        Console.SetCursorPosition(left, top);
        Console.Write(car.Graphics);
    }

    // Нарисовать информацию о гонке.
    public static void DrawRaceInfo(List<Car> cars)
    {
        var top = Console.WindowHeight - _TOP_OFFSET - 1;
        top -= Game.NumberOfCars;

        var sorted = cars.OrderBy(x => x.TraveledDistance).ToList();
        sorted.Reverse();

        Console.SetCursorPosition(_LEFT_OFFSET, top - 10);
        Console.Write("/-------------------------------------------------\\");
        Console.SetCursorPosition(_LEFT_OFFSET, Console.CursorTop + 1);
        Console.Write("|{0, -4}| {1, -16} | {2, -12} | {3, -8} |",
            "RANK", "CAR NAME", "CAR MODEL", "SPEED");
        Console.SetCursorPosition(_LEFT_OFFSET, Console.CursorTop + 1);

        for (var i = 0; i < Game.NumberOfCars; ++i)
        {
            var fmt = string.Format(
                "| №{0, -1} | {1, -16} | {2, -12} | {3, -3} km/h |",
                i + 1, sorted[i].Name, sorted[i].Model, sorted[i].CurrentSpeed
            );

            Console.Write(fmt);
            Console.SetCursorPosition(_LEFT_OFFSET, Console.CursorTop + 1);
        }

        Console.Write("\\-------------------------------------------------/");
    }

    // Нарисовать произовольное сообщение на экране.
    public static void DrawMessage(string msg)
    {
        var top = Game.NumberOfCars * _TRACK_HEIGHT + _TOP_OFFSET;
        Console.SetCursorPosition(_LEFT_OFFSET, top + 2);
        for (var i = 0; i < _TRACK_WIDTH; ++i)
            Console.Write(' ');
        Console.SetCursorPosition(_LEFT_OFFSET, top + 2);

        Console.Write($"Latest Info: {msg}");
    }
}
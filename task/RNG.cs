namespace task;

// Вспомагательный класс для генерации случайных чисел.
internal sealed class RNG
{
    private static Random r;

    public static Random R
    {
        get
        {
            if (r == null)
                r = new Random();
            return r;
        }
    }

    //Сгенерировать случайный байт вокруг заданного значения.
    public static int NextInt(int v, int spray = 0)
    {
        var offset = spray == 0
            ? R.Next() % (v / 2)
            : R.Next() % spray;

        var offsetPositive = (R.Next() & 1) == 0;
        return offsetPositive ? v + offset : v - offset;
    }
}
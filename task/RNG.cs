using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    // Вспомагательный класс для генерации случайных чисел.
    internal sealed class RNG
    {
        private static Random r = null;

        public static Random R
        {
            get
            {
                if (r == null)
                    r = new Random();
                return r;
            }
        }

        // Сгенерировать случайный байт вокруг заданного значения.
        //public static int NextInt(int v, int spray = 0)
        //{
        //    int offset = (spray == 0)
        //        ? (int)(R.Next() % (v / 2))
        //        : (int)(R.Next() % spray);

        //    bool offsetPositive = (R.Next() & 1) == 0;
        //    return offsetPositive ? (int)(v + offset) : (int)(v - offset);
        //}

        // Сгенерировать случайное число вокруг заданного значения.
        public static int NextInt(int v, int spray = 0)
        {
            if (spray == 0)
            {

            }
        }
    }
}

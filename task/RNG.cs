using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    // Воспомагательный класс для генерации случайных чисел
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

        // Сгенерировать случайный байт вокруг заданного значения
        public static byte NextByte(byte v, byte spray = 0)
        {
            byte offset = (spray == 0)
                ? (byte)(R.Next() % (v / 2))
                : (byte)(R.Next() % spray);

            bool offsetPositive = (R.Next() & 1) == 0;
            return offsetPositive ? (byte)(v + offset) : (byte)(v - offset);
        }
    }
}

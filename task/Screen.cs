using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    // Воспомогательный класс для отрисовки графики в консоли.
    internal class Screen
    {
        public static readonly int _TRACK_WIDTH = 72;
        public static readonly int _TRACK_HEIGHT = 1;
        private static readonly int _LEFT_OFFSET = 2;
        private static readonly int _TOP_OFFSET = 2;

        // Нарисовать гоночную дорожку для машины
        public static void DrawTrack(int nTrack)
        {
            int top = (int)(((nTrack - 1) * _TRACK_HEIGHT) + _TOP_OFFSET);
            Console.SetCursorPosition(_LEFT_OFFSET, top);

            Console.WriteLine('|');
            for (int i = 0, len = (int)(_TRACK_WIDTH - 3); i < len; ++i)
                Console.WriteLine('_');

            if ((nTrack & 1) == 0)
                Console.WriteLine("|# ");
            else
                Console.WriteLine("| #");
        }

        // Нарисовать машину на заданной дорожке
        public static void DrawCar(Car car, int nTrack)
        {
            // вычислить позицию машини на экране
            int traveled = (int)(car.TraveledDistance / Game.GridSize);
            int left = (int)(_LEFT_OFFSET + traveled);
            int top = (int)(((nTrack - 1) * _TRACK_HEIGHT) + _TOP_OFFSET);

            Console.SetCursorPosition(left, top);
            Console.WriteLine(car.Graphics);
        }

        // Нарисовать информацию о гонке
        public static void DrawRaceInfo(List<Car> cars)
        {
            int top = (int)(Console.WindowHeight - _TOP_OFFSET - 1);
            top -= Game.NumberOfCars;

            List<Car> sorted = cars.OrderBy(x => x.TraveledDistance).ToList();
            sorted.Reverse();

            Console.SetCursorPosition(_LEFT_OFFSET, top);
            Console.WriteLine("/-------------------------------------------------\\");
            Console.SetCursorPosition(_LEFT_OFFSET, Console.CursorTop + 1);
            Console.WriteLine("|{0, -4}| {1, -16} | {2, -12} | {3, -8} |",
                    "RANK", "CAR NAME", "CAR MODEL", "SPEED");
            Console.SetCursorPosition(_LEFT_OFFSET, Console.CursorTop + 1);

            for (int i = 0; i < Game.NumberOfCars; ++i)
            {
                string fmt = String.Format(
                    "| №{0, -1} | {1, -16} | {2, -12} | {3, -3} km/h |",
                    i + 1, sorted[i].Name, sorted[i].Model, sorted[i].CurrentSpeed
                );

                Console.WriteLine(fmt);
                try
                {
                    Console.SetCursorPosition(_LEFT_OFFSET, Console.CursorTop + 1);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    //throw;
                }
            }

            Console.WriteLine("\\-------------------------------------------------/");
        }

        // Нарисовать произовольное сообщение на экране.
        public static void DrawMessage(string msg)
        {
            int top = (int)((Game.NumberOfCars * _TRACK_HEIGHT) + _TOP_OFFSET);
            Console.SetCursorPosition(_LEFT_OFFSET, top + 2);
            for (int i = 0; i < _TRACK_WIDTH; ++i)
                Console.WriteLine(' ');
            Console.SetCursorPosition(_LEFT_OFFSET, top + 2);

            Console.WriteLine($"Latest Info: {msg}");
        }
    }
}

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
        public static readonly byte _TRACK_WIDTH = 72;
        public static readonly byte _TRACK_HEIGHT = 1;
        private static readonly byte _LEFT_OFFSET = 2;
        private static readonly byte _TOP_OFFSET = 2;

        // Нарисовать гоночную дорожку для машины
        public static void DrawTrack(byte nTrack)
        {
            byte top = (byte)(((nTrack - 1) * _TRACK_HEIGHT) + _TOP_OFFSET);
            SetCursorPosition(_LEFT_OFFSET, top);

            Write('|');
            for (byte i = 0, len = (byte)(_TRACK_WIDTH - 3); i < len; ++i)
                Write('_');

            if ((nTrack & 1) == 0)
                Write("|# ");
            else
                Write("| #");
        }

        // Нарисовать машину на заданной дорожке
        public static void DrawCar(Car car, byte nTrack)
        {
            // вычислить позицию машини на экране
            ushort traveled = (ushort)(car.TraveledDistance / RacingGame.GridSize);
            byte left = (byte)(_LEFT_OFFSET + traveled);
            byte top = (byte)(((nTrack - 1) * _TRACK_HEIGHT) + _TOP_OFFSET);

            SetCursorPosition(left, top);
            Write(car.Graphics);
        }

        // Нарисовать информацию о гонке
        public static void DrawRaceInfo(List<Car> cars)
        {
            byte top = (byte)(WindowHeight - _TOP_OFFSET - 1);
            top -= RacingGame.NumberOfCars;

            List<Car> sorted = cars.OrderBy(x => x.TraveledDistance).ToList();
            sorted.Reverse();

            SetCursorPosition(_LEFT_OFFSET, top);
            Write("/-------------------------------------------------\\");
            SetCursorPosition(_LEFT_OFFSET, CursorTop + 1);
            Write("|{0, -4}| {1, -16} | {2, -12} | {3, -8} |",
                    "RANK", "CAR NAME", "CAR MODEL", "SPEED");
            SetCursorPosition(_LEFT_OFFSET, CursorTop + 1);

            for (byte i = 0; i < RacingGame.NumberOfCars; ++i)
            {
                string fmt = String.Format(
                    "| №{0, -1} | {1, -16} | {2, -12} | {3, -3} km/h |",
                    i + 1, sorted[i].Name, sorted[i].Model, sorted[i].CurrentSpeed
                );

                Write(fmt);
                SetCursorPosition(_LEFT_OFFSET, CursorTop + 1);
            }

            Write("\\-------------------------------------------------/");
        }

        // Нарисовать произовольное сообщение на экране
        public static void DrawMessage(string msg)
        {
            byte top = (byte)((RacingGame.NumberOfCars * _TRACK_HEIGHT) + _TOP_OFFSET);
            SetCursorPosition(_LEFT_OFFSET, top + 2);
            for (byte i = 0; i < _TRACK_WIDTH; ++i)
                Write(' ');
            SetCursorPosition(_LEFT_OFFSET, top + 2);

            Write($"Latest Info: {msg}");
        }
    }
}

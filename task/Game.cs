using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    // Класс игры должен производить запуск соревнований автомобилей,
    // выводить сообщения о текущем положении автомобилей, выводить
    // сообщение об автомобиле, победившем в гонках.
    internal class Game
    {
        // Список автомобилей.
        private List<Car> cars = new List<Car>();

        public double KilometersLeftInTheRace { get; set; }     

        // Конструктор.
        public Game()
        {
            // Создание автомобилей.
            cars.Add(new SportCar());
            cars.Add(new PassengerCar());
            cars.Add(new CargoCar());
            cars.Add(new Bus());
        }

        // Запуск соревнований.
        public void Start()
        {
            // Подписка на событие Finish.
            foreach (Car car in cars)
            {
                car.Finish += Car_Finish;
            }

            // Запуск соревнований.
            foreach (Car car in cars)
            {
                car.Start();
            }
        }

        // Обработчик события Finish.
        private void Car_Finish(object sender, EventArgs e)
        {
            // Определение победителя.
            Car winner = cars[0];
            foreach (Car car in cars)
            {
                if (car.Distance > winner.Distance)
                {
                    winner = car;
                }
            }

            // Вывод сообщения о победителе.
            Console.WriteLine("Winner is {0}", winner.Name);
        }
    }
}

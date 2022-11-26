using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace task
{
    // Делегат для события, создаваемого автомобилем.
    delegate void CarEvent(Car car);
    // Делегат для события гонки.
    delegate void RaceEvent();

    // Абстрактный класс Машины.
    internal abstract class Car
    {
        // Событие достижения машиной финишной линии.
        public event CarEvent FinishedEvent;
        // Событие достижения машиной максимальной скорости.
        public event CarEvent MaxSpeedEvent;
        // Событие для изменения машиной позиции на экране.
        public event CarEvent PositionChangedEvent;

        // Публичные поля
        public string Name { get; protected set; }
        public string Model { get; protected set; }
        public int Speed { get; protected set; }
        public string Graphics { get; protected set; }
        public int TraveledDistance { get; protected set; }
        public int CurrentSpeed { get; protected set; }

        // Поля для внутреннего использования.
        protected int _speedRange;
        protected int _accelerationSpeed;
        protected bool _reachedMaxSpeed;

        // Конструктор с параметрами.
        public Car(string name, string model, int speed)
        {
            Name = name;
            Model = model;
            Speed = speed;
            TraveledDistance = 0;
            CurrentSpeed = 0;
            _reachedMaxSpeed = false;

            // Подписка на события гонки: её начало и обновление.
            RacingGame.Instance.StartEvent += Start;
            RacingGame.Instance.UpdateEvent += Update;
        }
    }
}

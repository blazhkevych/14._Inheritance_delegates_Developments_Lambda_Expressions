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
            Game.Instance.StartEvent += Start;
            Game.Instance.UpdateEvent += Update;
        }

        // Изменить текущую скорость машины
        private void ChangeSpeed()
        {
            CurrentSpeed += _accelerationSpeed;

            int delta = (int)(RNG.R.Next() % _speedRange);
            bool deltaPositive = (RNG.R.Next() & 1) == 0;

            if (deltaPositive)
                CurrentSpeed += delta;
            else if (CurrentSpeed > delta)
                CurrentSpeed -= delta;
        }

        // Начать гонку
        protected virtual void Start()
        {
            Screen.DrawMessage($"\"{Name}\" started!");
        }

        // Обноаить состояние машины
        protected virtual void Update()
        {
            ChangeSpeed();

            // вызвать событие, если была достигнута максимальная скорость
            if (CurrentSpeed >= Speed)
            {
                CurrentSpeed = Speed;

                if (!_reachedMaxSpeed)
                {
                    MaxSpeedEvent?.Invoke(this);
                    _reachedMaxSpeed = true;
                }
            }

            int oldDist = (int)(TraveledDistance / Game.GridSize);
            TraveledDistance += CurrentSpeed;
            int newDist = (int)(TraveledDistance / Game.GridSize);

            // вызвать событие, если позиция машины на экране должна быть обновлена
            if (newDist != oldDist)
                PositionChangedEvent?.Invoke(this);

            // вызвать событие, если машина достигла линии финиша
            if (TraveledDistance >= Game.TrackLength)
                FinishedEvent?.Invoke(this);
        }
    }
}

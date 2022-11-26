﻿namespace task
{
    internal class Program
    {
        /// <summary>
        ///     Игра «Автомобильные гонки»
        /// Разработать игру "Автомобильные гонки" с использованием делегатов.
        /// 1. В игре использовать несколько типов автомобилей: спортивные,               sports car
        /// легковые, грузовые и автобусы.                                                passenger car
        /// 2. Принцип игры: автомобили двигаются от старта к финишу со                   cargo vehicle
        /// скоростями, которые изменяются в установленных пределах случайным             bus
        /// образом. Победителем считается автомобиль, пришедший к финишу
        /// первым.
        ///     Рекомендации по реализации игры
        /// 1. Разработать абстрактный класс «автомобиль» (класс Car). Собрать в
        /// нем все общие поля, свойства (например, скорость) и методы
        /// (например, ехать).
        /// 2. Разработать классы автомобилей с конкретной реализацией
        /// конструкторов, свойств и методов. В классы автомобилей добавить
        /// необходимые события (например, финиш).
        /// 3. Класс игры должен производить запуск соревнований автомобилей,
        /// выводить сообщения о текущем положении автомобилей, выводить
        /// сообщение об автомобиле, победившем в гонках.
        /// 4. Создать делегаты, обеспечивающие вызов методов из классов
        /// автомобилей (например, выйти на старт, начать гонку).
        /// 5. Игра заканчивается, когда какой-то из автомобилей проехал
        /// определенное расстояние (старт в положении 0, финиш в положении
        /// 100). Уведомление об окончании гонки (прибытии какого-либо
        /// автомобиля на финиш) реализовать с помощью событий.
        /// </summary>
        static void Main(string[] args)
        {
            
            
        }
    }
}
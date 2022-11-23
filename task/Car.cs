using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace task
{
    internal abstract class Car
    {
        public string Model { get; set; }
        public int Speed { get; set; }
        public int MaxSpeed { get; set; }

        // Random speed generator.
        public  void RandomSpeed()
        {
            Random rnd = new Random();
            Speed = rnd.Next(0, MaxSpeed);
        }

        // Method for getting car type.
        public string GetCarType()
        {
            return this.GetType().Name;
        }

        // Method for getting car info.
        public string GetCarInfo()
        {
            return $"Car type: {GetCarType()}, Model: {Model}, Speed: {Speed}";
        }

        // Рисунок машины.
        public abstract void DrawCar();





    }
}

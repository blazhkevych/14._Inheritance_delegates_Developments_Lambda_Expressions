using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace task
{
    internal delegate int MyDelegate();

    internal abstract class Car
    {
        public string Model { get; set; }
        public int Speed { get; set; }
        public int MaxSpeed { get; set; }
        

        // Random speed generator.
        public void RandomSpeed()
        {
            Random rnd = new Random();
            Speed = rnd.Next(0, MaxSpeed);
        }
        
        // Method for getting car info.
        public  string GetCarInfo()
        {
            return "Model: " + Model + " Speed: " + Speed + " MaxSpeed: " + MaxSpeed;
        }

        // Method for drawing car.
        public abstract void DrawCar();


    }
}

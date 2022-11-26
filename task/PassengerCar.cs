using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    internal class PassengerCar : Car
    {
        public PassengerCar(string name, string model, byte speed)
            : base(name, model, speed)
        {
            _speedRange = RNG.NextByte(3);
            _accelerationSpeed = RNG.NextByte(6);
            Graphics = "EH3";
        }
    }
}

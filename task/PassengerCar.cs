using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    internal class PassengerCar : Car
    {
        public PassengerCar(string name, string model, int speed)
            : base(name, model, speed)
        {
            _speedRange = RNG.Nextint(3);
            _accelerationSpeed = RNG.Nextint(6);
            Graphics = "EH3";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    internal class SportCar : Car
    {
        public RacingCar(string name, string model, int speed)
            : base(name, model, speed)
        {
            _speedRange = RNG.Nextint(4);
            _accelerationSpeed = RNG.Nextint(8);
            Graphics = "|O->";
        }
    }
}
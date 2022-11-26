using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    internal class Bus: Car
    {
        public Bus(string name, string model, int speed)
            : base(name, model, speed)
        {
            _speedRange = RNG.Nextint(2);
            _accelerationSpeed = RNG.Nextint(4);
            Graphics = "EO0)";
        }
    }
}

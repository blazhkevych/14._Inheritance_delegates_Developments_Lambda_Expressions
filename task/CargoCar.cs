using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    internal class CargoCar: Car
    {
        public Truck(string name, string model, byte speed)
            : base(name, model, speed)
        {
            _speedRange = RNG.NextByte(2);
            _accelerationSpeed = RNG.NextByte(3);
            Graphics = "###-D";
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    internal class CargoCar: Car
    {
        public CargoCar(string name, string model, int speed)
            : base(name, model, speed)
        {
            _speedRange = RNG.NextInt(2);
            _accelerationSpeed = RNG.NextInt(3);
            Graphics = "###-D";
        }
    }
}

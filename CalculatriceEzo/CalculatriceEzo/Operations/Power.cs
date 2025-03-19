using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatriceEzo.Operations
{
    class Power : IOperation
    {
        public double Execute(double a, double b) => Math.Pow(a, b);
    }
}

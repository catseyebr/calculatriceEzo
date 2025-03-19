using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatriceEzo.Operations
{
    class Division : IOperation
    {
        public double Execute(double a, double b)
        {
            if (a == 0 || b == 0) throw new DivideByZeroException("La division par zéro n’est pas possible");
            return a / b;
        }
    }
}

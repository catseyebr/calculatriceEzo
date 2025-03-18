using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CalculatriceEzo
{
    class Calculatrice
    {
        public Calculatrice()
        {
            
        }

        public double Calculate(string expression)
        {
            double result;
            if (expression.Contains("+"))
            {
                string[] operands = expression.Split('+');
                result = double.Parse(operands[0]) + double.Parse(operands[1]);
            }
            else if (expression.Contains("-"))
            {
                string[] operands = expression.Split('-');
                result = double.Parse(operands[0]) - double.Parse(operands[1]);
            }
            else 
            {
                result = 0;
            }
            return result;
        }
    }
}

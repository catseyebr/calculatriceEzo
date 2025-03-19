using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatriceEzo.Operations
{
    class SquareRoot : IUnitaireOperation
    {
        public double Execute(double a)
        {
            if (a < 0) throw new ArgumentException("Impossible de calculer la racine carrée d’un nombre négatif");
            return Math.Sqrt(a);
        }
    }
}

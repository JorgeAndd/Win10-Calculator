using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculadorawin10.VO
{
    public class CalculadoraVO
    {
        public double Numero1 { get; set; }
        public double Numero2 { get; set; }

        public double Somar()
        {
            return Numero1 + Numero2;
        }
    }
}

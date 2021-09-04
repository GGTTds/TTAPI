using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace APITZ.Interfase
{
    interface ICalc
    {
        public double GetSum(double a, double b);
        public double GetMinus(double a, double b);
        public double GetMultiply(double a, double b);
        public double GetDiv(double a, double b);
        public double GetOstOtDiv(double a, double b);
    }
}

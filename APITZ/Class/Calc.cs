using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APITZ.Class
{
    public class Calc 
    {
        public double GetSum(double a, double b)
        {
            return a + b;
        }
        public double GetMinus(double a, double b)
        {
            return a - b;
        }
        public double GetMultiply(double a, double b)
        {
            return a * b;
        }
        public double GetDiv(double a, double b)
        {
            return a / b;
        }
        public double GetOstOtDiv(double a, double b)
        {
            return a % b;
        }
    }
}

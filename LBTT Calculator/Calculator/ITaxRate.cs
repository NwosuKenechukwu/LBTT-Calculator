using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBTT_Calculator.Calculator
{
    public interface ITaxRate
    {
        public double TaxRate { get; }
        public double LowerBand { get; }

        public double CalculateCurrentBandTax(double housePrice);
    }
}

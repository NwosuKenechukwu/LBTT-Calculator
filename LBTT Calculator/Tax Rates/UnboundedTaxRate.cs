using LBTT_Calculator.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBTT_Calculator.Tax_Bands
{
    public class UnboundedTaxRate : ITaxRate
    {
        public double TaxRate { get; }
        public double LowerBand { get; }

        public UnboundedTaxRate(double TaxRate, double lowerBand)
        {
            this.TaxRate = TaxRate;
            this.LowerBand = lowerBand;
        }


        public double CalculateCurrentBandTax(double housePrice)
        {
            if (housePrice > LowerBand)
            {
                double currentBandTaxableAmount = housePrice - LowerBand;

                return currentBandTaxableAmount * TaxRate;
            }
            return 0;
        }
    }
}

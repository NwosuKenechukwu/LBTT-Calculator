using LBTT_Calculator.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBTT_Calculator.Tax_Bands
{
    public class BoundedTaxRate : ITaxRate
    {
        public double TaxRate { get; }
        public double LowerBand { get; }
        public double Higherband { get; }

        public BoundedTaxRate(double taxRate, double lowerBand, double higherband)
        {
            TaxRate = taxRate;
            LowerBand = lowerBand;
            Higherband = higherband;
        }


        public double CalculateCurrentBandTax(double housePrice)
        {
            if (housePrice > LowerBand)
            {
                double currentBandTaxableAmount = housePrice > Higherband ? Higherband - LowerBand : housePrice - LowerBand;

                return currentBandTaxableAmount * TaxRate;
            }
            return 0;
        }
    }
}

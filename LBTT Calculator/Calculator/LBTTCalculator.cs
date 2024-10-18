using LBTT_Calculator.Tax_Bands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBTT_Calculator.Calculator
{
    public class LBTTCalculator
    {
        private double _totalTax;
        private double _housePrice;
        private List<ITaxRate> _taxBands = new List<ITaxRate>
        {
            new BoundedTaxRate(0.02, 145000, 250000),
            new BoundedTaxRate(0.05, 250000, 325000),
            new BoundedTaxRate(0.10, 325000, 750000),
            new UnboundedTaxRate(0.12, 750000),
        };

        public LBTTCalculator(double housePrice)
        {
            _housePrice = housePrice;
        }

        public double calculateLbtt()
        {
            foreach (ITaxRate band in _taxBands) {
                _totalTax += band.CalculateCurrentBandTax(_housePrice);
            }

            return _totalTax;
        }
    }
}

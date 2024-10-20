using LBTT_Calculator.Tax_Bands;
using LBTT_Calculator.TaxBand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBTT_Calculator.Calculator
{
    public class HouseTaxCalculator
    {
        private double _totalTax;
        private double _housePrice;
        private ITaxBandList _taxBandList;

        public HouseTaxCalculator(double housePrice, ITaxBandList taxBandList)
        {
            _housePrice = housePrice;
            _taxBandList = taxBandList;
        }

        public double calculateLbtt()
        {
            foreach (ITaxRate band in _taxBandList.bands) {
                _totalTax += band.CalculateCurrentBandTax(_housePrice);
            }

            return _totalTax;
        }
    }
}

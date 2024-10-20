using LBTT_Calculator.Calculator;
using LBTT_Calculator.Tax_Bands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBTT_Calculator.TaxBand
{
    public class LBTTResidentialTaxBandList : ITaxBandList
    {
        public List<ITaxRate> bands { get; } = new List<ITaxRate> {
            new BoundedTaxRate(0.02, 145000, 250000),
            new BoundedTaxRate(0.05, 250000, 325000),
            new BoundedTaxRate(0.10, 325000, 750000),
            new UnboundedTaxRate(0.12, 750000),
        };
    }
}

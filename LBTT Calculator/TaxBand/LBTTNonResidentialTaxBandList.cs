using LBTT_Calculator.Calculator;
using LBTT_Calculator.Tax_Bands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBTT_Calculator.TaxBand
{
    public class LBTTNonResidentialTaxBandList : ITaxBandList
    {
        public List<ITaxRate> bands { get; } = new List<ITaxRate>
        {
            new BoundedTaxRate(0.01, 150000, 250000),
            new UnboundedTaxRate(0.05, 250000),
        };
    }
}

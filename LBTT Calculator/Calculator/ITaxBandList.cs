using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBTT_Calculator.Calculator
{
    public interface ITaxBandList
    {
        public List<ITaxRate> bands {  get; }
    }
}

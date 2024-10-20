using LBTT_Calculator.Calculator;
using LBTT_Calculator.TaxBand;

namespace LBTT_Calculator;

public class Application
{
    static void Main ()
    {
        new Application().Run();
    }

    void Run()
    {
        ITaxBandList taxBandList = new LBTTNonResidentialTaxBandList();
        HouseTaxCalculator calculator = new HouseTaxCalculator(465000, taxBandList);
        string totalTax = calculator.calculateLbtt().ToString("n2");

        Console.WriteLine(totalTax);
    }
}

using LBTT_Calculator.Calculator;

namespace LBTT_Calculator;

public class Application
{
    static void Main ()
    {
        new Application().Run();
    }

    void Run()
    {
        LBTTCalculator calculator = new LBTTCalculator(875000);
        string totalTax = calculator.calculateLbtt().ToString("n2");

        Console.WriteLine(totalTax);
    }
}

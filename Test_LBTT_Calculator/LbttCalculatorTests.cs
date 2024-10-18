using LBTT_Calculator.Calculator;
using LBTT_Calculator.Tax_Bands;
using NUnit.Framework;

namespace Test_LBTT_Calculator
{
    public class LbttCalculatorTests
    {
        private LBTTCalculator _lbttCalculator { get; set; } = null;

        double housePrice = 875000;

        private ITaxRate _unboundedTaxRate;
        private ITaxRate _boundedTaxRate;

        [SetUp]
        public void Setup()
        {
            _lbttCalculator = new LBTTCalculator(housePrice);
        }

        [Test]
        public void TestCalculateLbtt()
        {
            double expected = 63350;

            double lbttTax = _lbttCalculator.calculateLbtt();

            Assert.That(lbttTax, Is.EqualTo(expected));
        }

        [TestCase(0.02, 145000, 250000, 2100)]
        [TestCase(0.05, 250000, 325000, 3750)]
        [TestCase(0.10, 325000, 750000, 42500)]
        public void TestBoundedTaxRate(double taxRate, double lowerBand, double higherBand, double expected)
        {
            _boundedTaxRate = new BoundedTaxRate(taxRate, lowerBand, higherBand);

            double lbttTax = _boundedTaxRate.CalculateCurrentBandTax(housePrice);

            Assert.That(lbttTax, Is.EqualTo(expected));
        }

        [TestCase(0.12, 750000, 15000)]
        public void TestUnboundedTaxRate(double TaxRate, double lowerBand, double expected)
        {
            _unboundedTaxRate = new UnboundedTaxRate(TaxRate, lowerBand);

            double lbttTax = _unboundedTaxRate.CalculateCurrentBandTax(housePrice);

            Assert.That(lbttTax, Is.EqualTo(expected));
        }
    }
}
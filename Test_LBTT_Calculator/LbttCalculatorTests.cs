using LBTT_Calculator.Calculator;
using LBTT_Calculator.Tax_Bands;
using LBTT_Calculator.TaxBand;
using NUnit.Framework;

namespace Test_LBTT_Calculator
{
    public class LbttCalculatorTests
    {
        private HouseTaxCalculator _residentialLbttCalculator { get; set; }
        private HouseTaxCalculator _nonResidentialLbttCalculator { get; set; }

        double residentialHousePrice = 875000;
        double nonResidentialHousePrice = 465000;


        [SetUp]
        public void Setup()
        {
            _residentialLbttCalculator = new HouseTaxCalculator(residentialHousePrice, new LBTTResidentialTaxBandList());
            _nonResidentialLbttCalculator = new HouseTaxCalculator(nonResidentialHousePrice, new LBTTNonResidentialTaxBandList());
        }

        [Test]
        public void TestCalculateResidentialLbtt()
        {
            double expected = 63350;

            double lbttTax = _residentialLbttCalculator.calculateLbtt();

            Assert.That(lbttTax, Is.EqualTo(expected));
        }

        [Test]
        public void TestCalculateNonResidentialLbtt()
        {
            double expected = 11750;

            double lbttTax = _nonResidentialLbttCalculator.calculateLbtt();

            Assert.That(lbttTax, Is.EqualTo(expected));
        }

        [TestCase(0.02, 145000, 250000, 2100)]
        [TestCase(0.05, 250000, 325000, 3750)]
        [TestCase(0.10, 325000, 750000, 42500)]
        public void TestBoundedTaxRate(double taxRate, double lowerBand, double higherBand, double expected)
        {
            ITaxRate _boundedTaxRate = new BoundedTaxRate(taxRate, lowerBand, higherBand);

            double lbttTax = _boundedTaxRate.CalculateCurrentBandTax(residentialHousePrice);

            Assert.That(lbttTax, Is.EqualTo(expected));
        }

        [TestCase(0.12, 750000, 15000)]
        public void TestUnboundedTaxRate(double TaxRate, double lowerBand, double expected)
        {
            ITaxRate _unboundedTaxRate = new UnboundedTaxRate(TaxRate, lowerBand);

            double lbttTax = _unboundedTaxRate.CalculateCurrentBandTax(residentialHousePrice);

            Assert.That(lbttTax, Is.EqualTo(expected));
        }
    }
}
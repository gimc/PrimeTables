using NUnit.Framework;

namespace PrimeTables.Tests
{
    class PrimeTableViewTests
    {
        [Test]
        public void TextOutput()
        {
            const string expected = @"
|   |  2|  3|  5|
|  2|  4|  6| 10|
|  3|  6|  9| 15|
|  5| 10| 15| 25|";

            var sequenceGenerator = new PrimeSequenceGenerator();
            var tableGenerator = new NaivePrimeTableGenerator(sequenceGenerator);
            var view = new PrimeTableTextView(tableGenerator);
            var output = view.Generate(3);

            Assert.AreEqual(expected, output);
        }
    }
}
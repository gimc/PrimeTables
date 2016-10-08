using NUnit.Framework;

namespace PrimeTables.Tests
{
    public class PrimeSequenceGeneratorTests
    {
        [Test]
        public void GenerateSequence_FirstPrimeIsTwo()
        {
            var generator = new PrimeSequenceGenerator();
            var prime = generator.Next();

            Assert.AreEqual(2, prime);
        }
    }
}

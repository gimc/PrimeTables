using NUnit.Framework;

namespace PrimeTables.Tests
{
    class PrimeTableGeneratorTests
    {
        [Test]
        public void ThreeByThreeTable()
        {
            var expected = new [,]
            {
                {4, 6, 10},
                {6, 9, 15},
                {10, 15, 25}
            };

            var generator = new PrimeTableGenerator(new PrimeSequenceGenerator());
            var table = generator.Generate(3);

            Assert.AreEqual(expected, table);
        }
    }
}
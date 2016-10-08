using NUnit.Framework;

namespace PrimeTables.Tests
{
    class PrimeTableGeneratorTests
    {
        [Test]
        public void NaiveThreeByThreeTable()
        {
            var expected = new [,]
            {
                {4, 6, 10},
                {6, 9, 15},
                {10, 15, 25}
            };

            var generator = new NaivePrimeTableGenerator(new PrimeSequenceGenerator());
            var table = generator.Generate(3);

            Assert.AreEqual(expected, table);
        }

        [Test]
        public void NaiveFiveByFiveTable()
        {
            var expected = new[,]
            {
                {4, 6, 10, 14, 22},
                {6, 9, 15, 21, 33},
                {10, 15, 25, 35, 55},
                {14, 21, 35, 49, 77},
                {22, 33, 55, 77, 121}
            };

            var generator = new NaivePrimeTableGenerator(new PrimeSequenceGenerator());
            var table = generator.Generate(5);

            Assert.AreEqual(expected, table);
        }
    }
}
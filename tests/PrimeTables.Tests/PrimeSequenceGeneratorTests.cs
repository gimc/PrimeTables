using System.Collections.Generic;
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

        [Test]
        public void GenerateSequence_HundredthPrime()
        {
            const int hundredthPrime = 541;
            var generator = new PrimeSequenceGenerator();
            var prime = 0;
            for (var i = 0; i < 100; i++)
            {
                prime = generator.Next();
            }

            Assert.AreEqual(hundredthPrime, prime);
        }

        [Test]
        public void GenerateSequence_FirstFivePrimes()
        {
            var expected = new[] {2, 3, 5, 7, 11};
            var generator = new PrimeSequenceGenerator();
            var generated = new List<int>();
            for (var i = 0; i < 5; i++)
            {
                generated.Add(generator.Next());
            }

            Assert.AreEqual(expected, generated.ToArray());
        }
    }
}

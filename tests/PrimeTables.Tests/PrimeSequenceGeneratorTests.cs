using System;
using System.Collections.Generic;
using System.Diagnostics;
using Common.Logging;
using Common.Logging.Simple;
using NUnit.Framework;
using PrimeTables.Sequences;

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
        public void GenerateSequenceParallel_HundredthPrime()
        {
            const int hundredthPrime = 541;
            var generator = new ParallelPrimeSequenceGenerator(4);
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

        [Test]
        [Ignore("Long running - maybe a million primes is a bit on the optimistic side")]
        public void GenerateSequence_MillionthPrime()
        {
            const int millionthPrime = 179424673;
            var generator = new PrimeSequenceGenerator();
            var prime = 0;
            var sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < 1000000; i++)
            {
                prime = generator.Next();
                
                if (i % 10000 == 0)
                    Console.WriteLine("Prime " + i + ": " + sw.Elapsed);
            }

            Assert.AreEqual(millionthPrime, prime);
        }

        [Test]
        [Ignore("Long running - maybe a million primes is a bit on the optimistic side")]
        public void GenerateSequenceParallel_MillionthPrime()
        {
            LogManager.Adapter = new ConsoleOutLoggerFactoryAdapter();

            const int millionthPrime = 179424673;
            var generator = new ParallelPrimeSequenceGenerator(2);
            var prime = 0;
            var sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < 1000000; i++)
            {
                prime = generator.Next();

                if (i % 10000 == 0)
                    Console.WriteLine("Prime " + i + ": " + sw.Elapsed);
            }

            Assert.AreEqual(millionthPrime, prime);
        }
    }
}
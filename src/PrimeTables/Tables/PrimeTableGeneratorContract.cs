using System;
using System.Diagnostics.Contracts;

namespace PrimeTables.Tables
{
    [ContractClassFor(typeof(IPrimeTableGenerator))]
    sealed class PrimeTableGeneratorContract : IPrimeTableGenerator
    {
        public int[] PrimeList { get; set; }

        public int[,] Generate(int numPrimes)
        {
            Contract.Requires<ArgumentOutOfRangeException>(numPrimes > 0);
            return null;
        }
    }
}
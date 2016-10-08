using System;
using System.Diagnostics.Contracts;

namespace PrimeTables
{
    [ContractClassFor(typeof(IPrimeTableGenerator))]
    sealed class PrimeTableGeneratorContract : IPrimeTableGenerator
    {
        public int[] PrimeList { get; set; }
        
        public int[,] Generate(int numPrimes)
        {
            Contract.Requires<ArgumentException>(numPrimes > 0);
            return null;
        }
    }
}
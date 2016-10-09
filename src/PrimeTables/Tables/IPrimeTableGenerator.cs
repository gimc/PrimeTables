using System;
using System.Diagnostics.Contracts;

namespace PrimeTables.Tables
{
    [ContractClass(typeof(PrimeTableGeneratorContract))]
    public interface IPrimeTableGenerator
    {
        int[] PrimeList { get; }

        /// <exception cref="ArgumentOutOfRangeException"></exception>
        int[,] Generate(int numPrimes);
    }
}
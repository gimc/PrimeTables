﻿using System;
using System.Diagnostics.Contracts;

namespace PrimeTables
{
    [ContractClass(typeof(PrimeTableGeneratorContract))]
    public interface IPrimeTableGenerator
    {
        int[] PrimeList { get; }

        int[,] Generate(int numPrimes);
    }

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
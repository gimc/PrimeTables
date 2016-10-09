using System;
using System.Diagnostics.Contracts;

namespace PrimeTables.Views
{
    [ContractClass(typeof(PrimeTableViewContract<>))]
    public interface IPrimeTableView<out T>
    {
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        T Generate(int numPrimes);
    }
}
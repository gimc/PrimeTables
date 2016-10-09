using System;
using System.Diagnostics.Contracts;

namespace PrimeTables.Views
{
    [ContractClassFor(typeof(IPrimeTableView<>))]
    abstract class PrimeTableViewContract<T> : IPrimeTableView<T>
    {
        public T Generate(int numPrimes)
        {
            Contract.Requires<ArgumentOutOfRangeException>(numPrimes > 0);
            return default(T);
        }
    }
}
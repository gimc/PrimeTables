using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace PrimeTables
{
    public class PrimeTableTextView : IPrimeTableView<string>
    {
        private readonly IPrimeTableGenerator _tableGenerator;

        public PrimeTableTextView(IPrimeTableGenerator tableGenerator)
        {
            _tableGenerator = tableGenerator;
        }

        /// <summary>
        /// Generates a string representation of the Prime Table for the supplied number of primes
        /// </summary>
        /// <param name="numPrimes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Number of primes must be greater than zero</exception>
        public string Generate(int numPrimes)
        {
            Contract.Requires<ArgumentOutOfRangeException>(numPrimes > 0);

            var tableValues = _tableGenerator.Generate(numPrimes);
            var primeValues = _tableGenerator.PrimeList;
            const int columnWidth = 3;

            var output = Environment.NewLine + "|   |" + string.Join("|", primeValues.Select(v => v.ToString().PadLeft(columnWidth))) + "|";

            for (var rowIndex = 0; rowIndex < primeValues.Length; rowIndex++)
            {
                output += Environment.NewLine;
                output += "|" + primeValues[rowIndex].ToString().PadLeft(columnWidth) + "|";
                for (var colIndex = 0; colIndex < primeValues.Length; colIndex++)
                {
                    output += tableValues[rowIndex, colIndex].ToString().PadLeft(columnWidth) + "|";
                }
            }

            return output;
        }
    }
}
namespace PrimeTables
{
    /// <summary>
    /// Uses a naive implementation whereby the result is recalculated for every entry in the table.
    /// </summary>
    public class NaivePrimeTableGenerator : IPrimeTableGenerator
    {
        private readonly IPrimeSequenceGenerator _primeSequenceGenerator;

        public NaivePrimeTableGenerator(IPrimeSequenceGenerator primeSequenceGenerator)
        {
            _primeSequenceGenerator = primeSequenceGenerator;
        }

        public int[,] Generate(int numPrimes)
        {
            var table = new int[numPrimes, numPrimes];
            var primeList = GeneratePrimeList(numPrimes);

            for (var row = 0; row < numPrimes; row++)
            {
                for (var col = 0; col < numPrimes; col++)
                {
                    table[row, col] = primeList[row]*primeList[col];
                }
            }

            return table;
        }

        private int[] GeneratePrimeList(int numPrimes)
        {
            var primeList = new int[numPrimes];
            for (var i = 0; i < numPrimes; i++)
            {
                primeList[i] = _primeSequenceGenerator.Next();
            }

            return primeList;
        }
    }
}
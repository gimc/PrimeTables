namespace PrimeTables
{
    /// <summary>
    /// Uses a naive implementation whereby the result is recalculated for every entry in the table.
    /// </summary>
    public class NaivePrimeTableGenerator : IPrimeTableGenerator
    {
        public int[] PrimeList { get; private set; }
        private readonly IPrimeSequenceGenerator _primeSequenceGenerator;

        public NaivePrimeTableGenerator(IPrimeSequenceGenerator primeSequenceGenerator)
        {
            _primeSequenceGenerator = primeSequenceGenerator;
        }

        public int[,] Generate(int numPrimes)
        {
            var table = new int[numPrimes, numPrimes];
            GeneratePrimeList(numPrimes);

            for (var row = 0; row < numPrimes; row++)
            {
                for (var col = 0; col < numPrimes; col++)
                {
                    table[row, col] = PrimeList[row] * PrimeList[col];
                }
            }

            return table;
        }

        private void GeneratePrimeList(int numPrimes)
        {
            PrimeList = new int[numPrimes];
            for (var i = 0; i < numPrimes; i++)
            {
                PrimeList[i] = _primeSequenceGenerator.Next();
            }
        }

    }
}
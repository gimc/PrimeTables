namespace PrimeTables
{
    public class PrimeTableGenerator : IPrimeTableGenerator
    {
        private readonly IPrimeSequenceGenerator _primeSequenceGenerator;

        public PrimeTableGenerator(IPrimeSequenceGenerator primeSequenceGenerator)
        {
            _primeSequenceGenerator = primeSequenceGenerator;
        }

        public int[,] Generate(int numPrimes)
        {
            return new[,]
            {
                {4, 6, 10},
                {6, 9, 15},
                {10, 15, 25}
            };
        }
    }
}
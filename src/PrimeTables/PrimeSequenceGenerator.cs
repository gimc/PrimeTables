namespace PrimeTables
{
    /// <summary>
    /// Generates a sequence of primes, starting at 2
    /// </summary>
    public class PrimeSequenceGenerator : IPrimeSequenceGenerator
    {
        public int Next()
        {
            return 2;
        }
    }
}

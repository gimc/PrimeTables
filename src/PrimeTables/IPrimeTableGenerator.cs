namespace PrimeTables
{
    public interface IPrimeTableGenerator
    {
        int[] PrimeList { get; }

        int[,] Generate(int numPrimes);
    }
}
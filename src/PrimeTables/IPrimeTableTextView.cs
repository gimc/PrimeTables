namespace PrimeTables
{
    public interface IPrimeTableView<out T>
    {
        T Generate(int numPrimes);
    }
}
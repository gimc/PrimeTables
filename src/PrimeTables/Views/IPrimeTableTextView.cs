namespace PrimeTables.Views
{
    public interface IPrimeTableView<out T>
    {
        T Generate(int numPrimes);
    }
}
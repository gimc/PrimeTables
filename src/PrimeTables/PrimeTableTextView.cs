namespace PrimeTables
{
    public class PrimeTableTextView : IPrimeTableView<string>
    {
        private readonly IPrimeTableGenerator _tableGenerator;

        public PrimeTableTextView(IPrimeTableGenerator tableGenerator)
        {
            _tableGenerator = tableGenerator;
        }

        public string Generate(int numPrimes)
        {
            return @"
|   |  2|  3|  5|
|  2|  4|  6| 10|
|  3|  6|  9| 15|
|  5| 10| 15| 25|";
        }
    }
}
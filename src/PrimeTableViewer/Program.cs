using System;
using CommandLine;
using CommandLine.Text;
using PrimeTables;
using PrimeTables.Sequences;
using PrimeTables.Tables;
using PrimeTables.Views;

namespace PrimeTableViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            if (!Parser.Default.ParseArguments(args, options))
            {
                Console.WriteLine(HelpText.AutoBuild(options));
                return;
            }

            var sequenceGenerator = new PrimeSequenceGenerator();
            var tableGenerator = new NaivePrimeTableGenerator(sequenceGenerator);
            var view = new PrimeTableTextView(tableGenerator);

            try
            {
                var output = view.Generate(options.NumPrimes);
                Console.Write(output);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Could not generate prime tables for " + options.NumPrimes + " primes (number of primes must be greater than zero).");
            }
        }
    }
}

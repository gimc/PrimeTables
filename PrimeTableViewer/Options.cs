using System.Collections.Generic;
using CommandLine;

namespace PrimeTableViewer
{
    public class Options : IParserState
    {
        [Option('n', "NumPrimes", HelpText = "The number of primes in the generated table.", DefaultValue = 2)]
        public int NumPrimes { get; set; }

        [ParserState]
        public ParserState LastParserState { get; set; }

        public IList<ParsingError> Errors { get; private set; }
    }
}
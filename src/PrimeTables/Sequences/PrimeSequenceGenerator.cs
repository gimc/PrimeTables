using System.Collections.Generic;
using System.Linq;

namespace PrimeTables.Sequences
{
    /// <summary>
    /// Generates a sequence of primes, starting at 2
    /// </summary>
    public class PrimeSequenceGenerator : IPrimeSequenceGenerator
    {
        private readonly List<long> _primes = new List<long>();
        private int _current;

        public PrimeSequenceGenerator()
        {
            _current = 1;
        }

        public int Next()
        {
            FindNextPrime();
            return _current;
        }

        private void FindNextPrime()
        {
            var candidate = _current + 1;
            while (true)
            {
                if (_primes.Any(prime => candidate%prime == 0))
                {
                    candidate++;
                    continue;
                }

                _current = candidate;
                _primes.Add(candidate);
                return;
            }
        }
    }
}

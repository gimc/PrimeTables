﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeTables
{
    /// <summary>
    /// Generates a sequence of primes, starting at 2
    /// </summary>
    public class PrimeSequenceGenerator : IPrimeSequenceGenerator
    {
        private List<int> _primes = new List<int>();
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

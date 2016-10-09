using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeTables.Sequences
{
    /// <summary>
    /// Spawns a number of tasks (defined by numTasks) in parallel which each interrogate their own non-overlapping subsets of primes to determine primality of a candidate value.
    /// </summary>
    public class ParallelPrimeSequenceGenerator : IPrimeSequenceGenerator
    {
        private readonly int _numTasks;
        private readonly List<long>[] _primeLists;
        private int _currentValue;
        private int _currentPrimeList;

        public ParallelPrimeSequenceGenerator(int numTasks)
        {
            _numTasks = numTasks;

            _primeLists = new List<long>[_numTasks];
            for (var i = 0; i < _numTasks; i++)
            {
                _primeLists[i] = new List<long>();
            }

            _currentValue = 1;
            _currentPrimeList = 0;
        }

        public int Next()
        {
            FindNextPrime();
            return _currentValue;
        }

        private bool IsPrime(int candidate)
        {
            var tasks = new Task<bool>[_numTasks];
            for (var i = 0; i < _numTasks; i++)
            {
                var closureIndex = i;
                tasks[i] = Task.Run(() => _primeLists[closureIndex].All(prime => candidate % prime != 0));
            }

            Task.WaitAll(tasks);

            return tasks.All(task => task.Result);            
        }

        private void FindNextPrime()
        {
            var candidate = _currentValue + 1;
            while (!IsPrime(candidate))
            {
                candidate++;
            }

            _currentValue = candidate;
            _primeLists[_currentPrimeList].Add(candidate);
            _currentPrimeList = (_currentPrimeList + 1) % _numTasks;
        }
    }
}
# PrimeTables

### How to run
A command-line application called **PrimeTableViewer** is provided. The application takes one parameter (-n), which is the number of primes to be displayed in the table.

For example, to view a prime table with three entries, open a command prompt in the directory containing the executable and run:

    PrimeTableViewer -n 3

The application defaults to 2 values if the flag is not specified.

### Compilation
If you wish to compile the PrimeTables library, you must have Microsoft's Code Contracts for .NET installed. This is available from the  [Visual Studio Gallery](https://visualstudiogallery.msdn.microsoft.com/1ec7db13-3363-46c9-851f-1ce455f66970).

### What I'm pleased with
Clean design separated adhering (mostly) to SRP:
- Sequence generator classes which generate sequences of primes
- Table generation which uses the prime sequences to generate table data
- View to output table data

['mostly' because the primality testing part of the sequence generation could be factored out into another class]

Prime sequence generator which keeps track of discovered primes and uses these to test for primality of new candidates, taking advantage of the fact the problem only requires sequential generation as opposed to random primality testing.

Test coverage, including functionality and input edge cases.

Dependency injection, can easily use different prime sequence generator implementations for table generation, for example.

Design-by-contract to make input conditions explicit and enforced for any future implementations (e.g. contract class provided for IPrimeTableView interface).

Use of third-party packages were appropriate - don't reinvent the wheel - in particular:
- Common.Logging, to allow library consumers to use their own API implementation of choice, such as Log4net;
- CommandLine parser, a nice tool for handling command line options and related tasks.
 
### If I had more time...
1. Investigate the unexpectedly poor parallelism performance. I expected to see some overhead from Task creation/synchronisation, but was surprised by just how terrible the performance was here. The Basic implementation calculates 100,000 primes in 1m 03s on my machine, but 8-way Parallel takes 3m 53s (on an 8-core machine). I may be doing something stupid, I realise parallelism is not easy!
2. More sophisticated version of PrimeTableGenerator which uses the triangular nature of the prime table to reduce the number of computations required. The Naive version does many unnecessary calculations.
3. Improve the padding behaviour of PrimeTableTextView, which currently uses a magic number for column width. Could determine the width of the largest number and pad everything to that, for example.
4. Making 'PrimeList' publically getable in NaivePrimeTableGenerator was a pragmatic need when writing calling code, revisit that.
5. Investigate how to improve the prime number generation algorithm.
6. Needs more documentation.
7. NaivePrimeTableGenerator.Generate doesn't check input.
8. Switches in command-line application to use different generator types.
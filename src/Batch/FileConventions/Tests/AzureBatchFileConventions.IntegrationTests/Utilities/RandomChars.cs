using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.Conventions.Files.IntegrationTests.Utilities
{
    internal static class RandomChars
    {
        private static readonly Random _random = new Random();

        private static readonly char[] CharsForRandomId =
            Enumerable.Range((int)'a', 26).Concat(Enumerable.Range((int)'0', 10))
                      .Select(i => (char)i)
                      .ToArray();

        internal static string RandomString(int count)
        {
            return new string(RandomChar(count).ToArray());
        }

        private static IEnumerable<char> RandomChar(int count)
        {
            return Enumerable.Range(0, count).Select(_ => RandomChar());
        }

        private static char RandomChar()
        {
            return CharsForRandomId[_random.Next(CharsForRandomId.Length - 1)];
        }
    }
}

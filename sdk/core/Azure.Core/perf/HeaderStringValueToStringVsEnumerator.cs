// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// |           Method | Count |      Mean |     Error |    StdDev |   Gen0 | Allocated |
// |----------------- |------ |----------:|----------:|----------:|-------:|----------:|
// |     CallToString |     1 |  2.282 ns | 0.0029 ns | 0.0024 ns |      - |         - |
// | CreateEnumerator |     1 | 41.830 ns | 0.2883 ns | 0.2697 ns | 0.0004 |      40 B |
// |     CallToString |     2 | 29.230 ns | 0.2876 ns | 0.2691 ns | 0.0005 |      56 B |
// | CreateEnumerator |     2 | 52.589 ns | 0.1854 ns | 0.1643 ns | 0.0005 |      56 B |
// |     CallToString |     5 | 57.748 ns | 0.1114 ns | 0.0870 ns | 0.0011 |     112 B |
// | CreateEnumerator |     5 | 76.548 ns | 0.2156 ns | 0.1800 ns | 0.0011 |     104 B |

using System.Linq;
using System.Runtime.CompilerServices;
using System.Net.Http;
using System.Net.Http.Headers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Azure.Core.Perf
{
    [SimpleJob(RuntimeMoniker.Net60)]
    public class HeaderStringValueToStringVsEnumerator
    {
#if NET6_0_OR_GREATER
        private static string[] _acceptValues = { "chunked", "compress", "deflate", "gzip", "identity"};
        private HeaderStringValues _headerStringValues;

        [Params(1,2,5)]
        public int Count { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            var response = new HttpResponseMessage();
            response.Headers.Add("Transfer-Encoding", _acceptValues.Take(Count));

            _headerStringValues = response.Headers.NonValidated["Transfer-Encoding"];
        }

        [Benchmark]
        public string CallToString() => _headerStringValues.ToString();

        [Benchmark]
        public string CreateEnumerator()
        {
            var count = _headerStringValues.Count;
            var interpolatedStringHandler = new DefaultInterpolatedStringHandler(count-1, count);
            var isFirst = true;
            foreach (var str in _headerStringValues)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    interpolatedStringHandler.AppendLiteral(",");
                }
                interpolatedStringHandler.AppendFormatted(str);
            }
            return string.Create(null, ref interpolatedStringHandler);
        }
#endif
    }
}

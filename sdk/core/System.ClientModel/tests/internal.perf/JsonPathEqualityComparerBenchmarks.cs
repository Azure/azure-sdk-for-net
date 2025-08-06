// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using BenchmarkDotNet.Attributes;

namespace System.ClientModel.Tests.Internal.Perf
{
    public class JsonPathEqualityComparerBenchmarks
    {
        private byte[] _path1a = "$.properties.virtualMachines[0].name"u8.ToArray();
        private byte[] _path1b = "$.properties.virtualMachines[0].name"u8.ToArray();
        private byte[] _path2 = "$.props.virtualMachines[0].name"u8.ToArray();
        private byte[] _path3 = "$.properties.virtualMachines[0].id"u8.ToArray();

        [Benchmark]
        public bool AreEqual_Comparer()
        {
            return JsonPathEqualityComparer.Equals(_path1a.AsSpan(), _path1b.AsSpan());
        }

        [Benchmark]
        public bool EarlyNotEqual_Comparer()
        {
            return JsonPathEqualityComparer.Equals(_path1a.AsSpan(), _path2.AsSpan());
        }

        [Benchmark]
        public bool LateNotEqual_Comparer()
        {
            return JsonPathEqualityComparer.Equals(_path1a.AsSpan(), _path3.AsSpan());
        }

        [Benchmark]
        public bool AreEqual_Span()
        {
            return _path1a.AsSpan().SequenceEqual(_path1b.AsSpan());
        }

        [Benchmark]
        public bool EarlyNotEqual_Span()
        {
            return _path1a.AsSpan().SequenceEqual(_path2.AsSpan());
        }

        [Benchmark]
        public bool LateNotEqual_Span()
        {
            return _path1a.AsSpan().SequenceEqual(_path3.AsSpan());
        }
    }
}

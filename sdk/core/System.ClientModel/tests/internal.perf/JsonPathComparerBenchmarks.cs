// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using BenchmarkDotNet.Attributes;

namespace System.ClientModel.Tests.Internal.Perf
{
    public class JsonPathComparerBenchmarks
    {
        private byte[] _path1a = "$.properties.virtualMachines[0].name"u8.ToArray();
        private byte[] _path1b = "$.properties.virtualMachines[0].name"u8.ToArray();
        private byte[] _path1aPrime = "$.properties['virtualMachines'][0].name"u8.ToArray();
        private byte[] _path2 = "$.props.virtualMachines[0].name"u8.ToArray();
        private byte[] _path3 = "$.properties.virtualMachines[0].id"u8.ToArray();

        [Benchmark]
        public int GetHashCode_Comparer()
        {
            return JsonPathComparer.Default.GetHashCode(_path1a);
        }

        [Benchmark]
        public bool AreEqual_Comparer()
        {
            return JsonPathComparer.Default.Equals(_path1a, _path1b);
        }

        [Benchmark]
        public bool AreEqual_Comparer_AlternateForm()
        {
            return JsonPathComparer.Default.Equals(_path1a, _path1aPrime);
        }

        [Benchmark]
        public bool EarlyNotEqual_Comparer()
        {
            return JsonPathComparer.Default.Equals(_path1a, _path2);
        }

        [Benchmark]
        public bool LateNotEqual_Comparer()
        {
            return JsonPathComparer.Default.Equals(_path1a, _path3);
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

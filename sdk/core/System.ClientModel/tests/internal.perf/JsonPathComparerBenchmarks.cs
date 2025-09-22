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
        public void Normalize_Comparer()
        {
            Span<byte> buffer = stackalloc byte[_path1a.Length];
            JsonPathComparer.Default.Normalize(_path1a, buffer, out int bytesWritten);
        }

        [Benchmark]
        public void Normalize_AlternateForm_Comparer()
        {
            Span<byte> buffer = stackalloc byte[_path1aPrime.Length];
            JsonPathComparer.Default.Normalize(_path1aPrime, buffer, out int bytesWritten);
        }

        [Benchmark]
        public int Normalize_GetHashCode_Comparer()
        {
            return JsonPathComparer.Default.GetNormalizedHashCode(_path1a);
        }

        [Benchmark]
        public int Normalize_GetHashCode_AlternateForm_Comparer()
        {
            return JsonPathComparer.Default.GetNormalizedHashCode(_path1aPrime);
        }

        [Benchmark]
        public bool Normalize_Equals_Comparer()
        {
            return JsonPathComparer.Default.NormalizedEquals(_path1a, _path1b);
        }

        [Benchmark]
        public bool Normalize_Equals_AlternateForm_Comparer()
        {
            return JsonPathComparer.Default.NormalizedEquals(_path1a, _path1aPrime);
        }

        [Benchmark]
        public bool Normalize_EarlyNotEqual_Comparer()
        {
            return JsonPathComparer.Default.NormalizedEquals(_path1a, _path2);
        }

        [Benchmark]
        public bool Normalize_LateNotEqual_Comparer()
        {
            return JsonPathComparer.Default.NormalizedEquals(_path1a, _path3);
        }

        [Benchmark]
        public int GetHashCode_Comparer()
        {
            return JsonPathComparer.Default.GetHashCode(_path1a);
        }

        [Benchmark]
        public int GetHashCode_AlternateForm_Comparer()
        {
            return JsonPathComparer.Default.GetHashCode(_path1aPrime);
        }

        [Benchmark]
        public bool Equal_Comparer()
        {
            return JsonPathComparer.Default.Equals(_path1a, _path1b);
        }

        [Benchmark]
        public bool Equal_AlternateForm_Comparer()
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
        public int GetHashCode_Span()
        {
#if NET8_0_OR_GREATER
            var hash = new HashCode();
            hash.AddBytes(_path1a);
            return hash.ToHashCode();
#else
        unchecked
        {
            int hash = 17;
            for (int i = 0; i < _path1a.Length; i++)
            {
                hash = hash * 31 + _path1a[i];
            }
            return hash;
        }
#endif
        }

        [Benchmark]
        public bool Equal_Span()
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

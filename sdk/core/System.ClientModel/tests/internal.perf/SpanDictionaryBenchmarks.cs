// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace System.ClientModel.Tests.Internal.Perf
{
    public class SpanDictionaryBenchmarks
    {
        private byte[] _key = new byte[] { 1, 2, 3 };
        private byte[] _value = new byte[] { 4, 5, 6 };
        private byte[] _key2 = new byte[] { 1, 2, 3, 4 };
        private byte[] _key3 = new byte[] { 1, 2, 3, 4, 5 };

        [Benchmark]
        public void New_Dictionary()
        {
            _ = new Dictionary<byte[], byte[]>();
        }

        [Benchmark]
        public void New_SpanDictionary()
        {
            _ = new SpanDictionary<byte[]>();
        }

        [Benchmark]
        public void NewCapacity_Dictionary()
        {
            _ = new Dictionary<byte[], byte[]>(20);
        }

        [Benchmark]
        public void NewCapacity_SpanDictionary()
        {
            _ = new SpanDictionary<byte[]>(20);
        }

        [Benchmark]
        public void Add_Dictionary()
        {
            var dict = new Dictionary<byte[], byte[]>();
            dict.Add(_key, _value);
        }

        [Benchmark]
        public void Add_SpanDictionary()
        {
            var dict = new SpanDictionary<byte[]>();
            dict.Add(_key, _value);
        }

        [Benchmark]
        public void AddWithCapacity_Dictionary()
        {
            var dict = new Dictionary<byte[], byte[]>(20);
            dict.Add(_key, _value);
        }

        [Benchmark]
        public void AddWithCapacity_SpanDictionary()
        {
            var dict = new SpanDictionary<byte[]>(20);
            dict.Add(_key, _value);
        }

        [Benchmark]
        public void AddOverCapacity_Dictionary()
        {
            var dict = new Dictionary<byte[], byte[]>(2);
            dict.Add(_key, _value);
            dict.Add(_key2, _value);
            dict.Add(_key3, _value);
        }

        [Benchmark]
        public void AddOverCapacity_SpanDictionary()
        {
            var dict = new SpanDictionary<byte[]>(2);
            dict.Add(_key, _value);
            dict.Add(_key2, _value);
            dict.Add(_key3, _value);
        }
    }
}

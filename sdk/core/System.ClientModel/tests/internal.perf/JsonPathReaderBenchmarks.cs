// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using BenchmarkDotNet.Attributes;
using System.ClientModel.Primitives;

namespace System.ClientModel.Tests.Internal.Perf
{
    public class JsonPathReaderBenchmarks
    {
        [Benchmark]
        public void Read_DotNotation()
        {
            var reader = new JsonPathReader("$.foo.bar[2].baz"u8);
            while (reader.Read()) { }
        }

        [Benchmark]
        public void Read_SingleQuote()
        {
            var reader = new JsonPathReader("$['foo']['bar'][2]['baz']"u8);
            while (reader.Read()) { }
        }

        [Benchmark]
        public void Read_DoubleQuote()
        {
            var reader = new JsonPathReader("$[\"foo\"].bar[2].baz"u8);
            while (reader.Read()) { }
        }

        [Benchmark]
        public void GetFirstProperty_DotNotation()
        {
            var reader = new JsonPathReader("$.foo.bar[2].baz"u8);
            var prop = reader.GetFirstProperty();
        }

        [Benchmark]
        public void GetFirstProperty_SingleQuote()
        {
            var reader = new JsonPathReader("$['foo']['bar'][2]['baz']"u8);
            var prop = reader.GetFirstProperty();
        }

        [Benchmark]
        public void GetFirstProperty_DoubleQuote()
        {
            var reader = new JsonPathReader("$[\"foo\"].bar[2].baz"u8);
            var prop = reader.GetFirstProperty();
        }

        [Benchmark]
        public void Advance_DotNotation()
        {
            var reader = new JsonPathReader("$.foo.bar[2].baz"u8);
            reader.Advance("$.foo.bar"u8);
        }

        [Benchmark]
        public void Advance_SingleQuote()
        {
            var reader = new JsonPathReader("$['foo']['bar'][2]['baz']"u8);
            reader.Advance("$['foo']['bar']"u8);
        }

        [Benchmark]
        public void Advance_DoubleQuote()
        {
            var reader = new JsonPathReader("$[\"foo\"].bar[2].baz"u8);
            reader.Advance("$[\"foo\"].bar"u8);
        }

        [Benchmark]
        public void Equals_DifferentVariants()
        {
            var reader1 = new JsonPathReader("$.foo.bar[2].baz"u8);
            var reader2 = new JsonPathReader("$['foo']['bar'][2]['baz']"u8);
            reader1.Equals(reader2);
        }

        [Benchmark]
        public void GetHashCode_DotNotation()
        {
            var reader = new JsonPathReader("$.foo.bar[2].baz"u8);
            reader.GetHashCode();
        }

        [Benchmark]
        public void GetHashCode_SingleQuote()
        {
            var reader = new JsonPathReader("$['foo']['bar'][2]['baz']"u8);
            reader.GetHashCode();
        }

        [Benchmark]
        public void GetHashCode_DoubleQuote()
        {
            var reader = new JsonPathReader("$[\"foo\"].bar[2].baz"u8);
            reader.GetHashCode();
        }
    }
}

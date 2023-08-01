// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Azure.Core.Perf
{
    public class SequenceWriterBenchmark
    {
        private static SequenceWriter _writer0;
        private static SequenceWriter _writer1;
        private static SequenceWriter _writer5;
        private static SequenceWriter _writer10;
        private static SequenceWriter _writer50;

        [GlobalSetup]
        public void Setup()
        {
            _writer0 = GetSequenceWriter(0);
            _writer1 = GetSequenceWriter(1);
            _writer5 = GetSequenceWriter(5);
            _writer10 = GetSequenceWriter(10);
            _writer50 = GetSequenceWriter(50);
        }

        public IEnumerable<SequenceWriter> GetWriters()
        {
            yield return GetSequenceWriter(0);
            yield return GetSequenceWriter(1);
            yield return GetSequenceWriter(5);
            yield return GetSequenceWriter(10);
            yield return GetSequenceWriter(50);
        }

        private static SequenceWriter GetSequenceWriter(int count)
        {
            SequenceWriter writer = new SequenceWriter(512);
            for (int i = 0; i < count; i++)
            {
                WriteMemory(writer, 400);
            }
            return writer;
        }

        private static void WriteMemory(SequenceWriter writer, int size)
        {
            var memory = writer.GetMemory(size);
            writer.Advance(size);
        }

        [Benchmark]
        [Arguments(0)]
        [Arguments(1)]
        [Arguments(2)]
        [Arguments(3)]
        [Arguments(4)]
        [Arguments(5)]
        [Arguments(10)]
        [Arguments(50)]
        public void WriteBuffers(int buffers)
        {
            using SequenceWriter writer = new SequenceWriter(512);
            for (int i = 0; i < buffers; i++)
            {
                WriteMemory(writer, 400);
            }
        }

        //[Benchmark]
        //[ArgumentsSource(nameof(GetWriters))]
        //public ReadOnlySequence<byte> GetSequence0(SequenceWriter writer)
        //{
        //    var sequence = writer.GetReadOnlySequence();
        //    return sequence;
        //}

        [Benchmark]
        public ReadOnlySequence<byte> GetSequence0()
        {
            var sequence = _writer0.GetReadOnlySequence();
            return sequence;
        }

        [Benchmark]
        public ReadOnlySequence<byte> GetSequence1()
        {
            var sequence = _writer1.GetReadOnlySequence();
            return sequence;
        }

        [Benchmark]
        public ReadOnlySequence<byte> GetSequence5()
        {
            var sequence = _writer5.GetReadOnlySequence();
            return sequence;
        }

        [Benchmark]
        public ReadOnlySequence<byte> GetSequence10()
        {
            var sequence = _writer10.GetReadOnlySequence();
            return sequence;
        }

        [Benchmark]
        public ReadOnlySequence<byte> GetSequence50()
        {
            var sequence = _writer50.GetReadOnlySequence();
            return sequence;
        }
    }
}

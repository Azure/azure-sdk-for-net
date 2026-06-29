// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.IO;
using System.Reflection;
using System.Text.Json;
using BenchmarkDotNet.Attributes;

namespace System.ClientModel.Tests.Internal.Perf
{
    /// <summary>
    /// Proxy resolution benchmarks over a realistic model (<see cref="AvailabilitySetData"/>) so the
    /// proxy overhead is measured against representative serialization work rather than a micro payload.
    /// Reuses the AvailabilitySetDataProxy from the client test library and compares:
    /// no proxy, an unconditional proxy that hits, a conditional proxy that hits, and a conditional
    /// proxy that declines (miss) so the model does the work.
    /// </summary>
    [MemoryDiagnoser]
    public class ProxyResolutionRealisticBenchmark
    {
        private AvailabilitySetData _model;
        private BinaryData _data;

        private ModelReaderWriterOptions _noProxyOptions;
        private ModelReaderWriterOptions _unconditionalProxyOptions;
        private ModelReaderWriterOptions _conditionalHitOptions;
        private ModelReaderWriterOptions _conditionalMissOptions;

        [GlobalSetup]
        public void Setup()
        {
            string json = File.ReadAllText(Path.Combine(
                Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName,
                "TestData",
                "AvailabilitySetData",
                "AvailabilitySetData.json"));
            _data = BinaryData.FromString(json);
            _model = ModelReaderWriter.Read<AvailabilitySetData>(_data);

            _noProxyOptions = new ModelReaderWriterOptions("J");

            // Unconditional proxy that always handles.
            _unconditionalProxyOptions = new ModelReaderWriterOptions("J");
            _unconditionalProxyOptions.AddProxy<AvailabilitySetData>((IJsonModel<AvailabilitySetData>)new AvailabilitySetDataProxy());

            // Conditional proxy that handles (hit).
            _conditionalHitOptions = new ModelReaderWriterOptions("J");
            _conditionalHitOptions.AddProxy<AvailabilitySetData>(new AvailabilitySetDataConditionalProxy(canHandle: true));

            // Conditional proxy that declines (miss) — the model itself does the work.
            _conditionalMissOptions = new ModelReaderWriterOptions("J");
            _conditionalMissOptions.AddProxy<AvailabilitySetData>(new AvailabilitySetDataConditionalProxy(canHandle: false));
        }

        // ── Write benchmarks ──

        [Benchmark(Baseline = true)]
        [BenchmarkCategory("Write")]
        public BinaryData Write_NoProxy()
            => ModelReaderWriter.Write(_model, _noProxyOptions);

        [Benchmark]
        [BenchmarkCategory("Write")]
        public BinaryData Write_UnconditionalProxy()
            => ModelReaderWriter.Write(_model, _unconditionalProxyOptions);

        [Benchmark]
        [BenchmarkCategory("Write")]
        public BinaryData Write_ConditionalProxy_Hit()
            => ModelReaderWriter.Write(_model, _conditionalHitOptions);

        [Benchmark]
        [BenchmarkCategory("Write")]
        public BinaryData Write_ConditionalProxy_Miss()
            => ModelReaderWriter.Write(_model, _conditionalMissOptions);

        // ── Read benchmarks ──

        [Benchmark]
        [BenchmarkCategory("Read")]
        public AvailabilitySetData Read_NoProxy()
            => ModelReaderWriter.Read<AvailabilitySetData>(_data, _noProxyOptions);

        [Benchmark]
        [BenchmarkCategory("Read")]
        public AvailabilitySetData Read_UnconditionalProxy()
            => ModelReaderWriter.Read<AvailabilitySetData>(_data, _unconditionalProxyOptions);

        [Benchmark]
        [BenchmarkCategory("Read")]
        public AvailabilitySetData Read_ConditionalProxy_Hit()
            => ModelReaderWriter.Read<AvailabilitySetData>(_data, _conditionalHitOptions);

        [Benchmark]
        [BenchmarkCategory("Read")]
        public AvailabilitySetData Read_ConditionalProxy_Miss()
            => ModelReaderWriter.Read<AvailabilitySetData>(_data, _conditionalMissOptions);

        /// <summary>
        /// Wraps the unconditional AvailabilitySetDataProxy in a conditional proxy whose CanHandle
        /// result is configurable, so we can benchmark both the hit and miss conditional paths.
        /// </summary>
        private class AvailabilitySetDataConditionalProxy : ConditionalModelProxy<AvailabilitySetData>
        {
            private readonly bool _canHandle;

            public AvailabilitySetDataConditionalProxy(bool canHandle)
                : base(new AvailabilitySetDataProxy())
            {
                _canHandle = canHandle;
            }

            public override bool CanHandle(AvailabilitySetData model) => _canHandle;
            public override bool CanHandle(ReadOnlyMemory<byte> data) => _canHandle;
            public override bool CanHandle(ref Utf8JsonReader reader) => _canHandle;
        }
    }
}

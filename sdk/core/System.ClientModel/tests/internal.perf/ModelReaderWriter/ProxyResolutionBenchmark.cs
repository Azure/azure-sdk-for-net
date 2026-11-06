// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;

namespace System.ClientModel.Tests.Internal.Perf;

[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
[Config(typeof(ProxyResolutionBenchmark.SharedHostConfig))]
public class ProxyResolutionBenchmark
{
    public sealed class SharedHostConfig : ManualConfig
    {
        public SharedHostConfig() => AddJob(Job.Default
            .DontEnforcePowerPlan()
            .AsMutator());
    }

    internal enum Scenario { NoProxy, Direct, LookupMiss, ConditionalFirst, ConditionalLast, AllDecline }

    private const string Payload = "{\"type\":\"tool\",\"name\":\"search\",\"description\":\"Search the documentation index\",\"count\":42,\"enabled\":true,\"region\":\"westus\",\"version\":\"2026-10-21\"}";
    private static readonly JsonProxy s_proxy = new();
    private static readonly DiscriminatorProxy s_matching = new("tool", s_proxy);
    private static readonly DiscriminatorProxy[] s_declining = CreateDecliningProxies();
    private static readonly Action<ModelReaderWriterOptions>[] s_unrelated =
    [
        o => o.AddProxy(UnrelatedModel<int>.Instance),
        o => o.AddProxy(UnrelatedModel<long>.Instance),
        o => o.AddProxy(UnrelatedModel<double>.Instance),
        o => o.AddProxy(UnrelatedModel<decimal>.Instance),
        o => o.AddProxy(UnrelatedModel<float>.Instance),
        o => o.AddProxy(UnrelatedModel<byte>.Instance),
        o => o.AddProxy(UnrelatedModel<short>.Instance),
        o => o.AddProxy(UnrelatedModel<bool>.Instance),
        o => o.AddProxy(UnrelatedModel<Guid>.Instance),
        o => o.AddProxy(UnrelatedModel<DateTime>.Instance)
    ];

    private BinaryData _data;
    private BenchmarkModel _model;
    private ModelReaderWriterOptions _noProxy, _direct1, _direct10, _lookup1, _lookup10;
    private ModelReaderWriterOptions _conditional1, _first10, _last10, _decline1, _decline10;

    [GlobalSetup]
    public void Setup()
    {
        _data = BinaryData.FromString(Payload);
        _model = ModelReaderWriter.Read<BenchmarkModel>(_data);
        _noProxy = SetupCase(Scenario.NoProxy, 0);
        _direct1 = SetupCase(Scenario.Direct, 1);
        _direct10 = SetupCase(Scenario.Direct, 10);
        _lookup1 = SetupCase(Scenario.LookupMiss, 1);
        _lookup10 = SetupCase(Scenario.LookupMiss, 10);
        _conditional1 = SetupCase(Scenario.ConditionalFirst, 1);
        _first10 = SetupCase(Scenario.ConditionalFirst, 10);
        _last10 = SetupCase(Scenario.ConditionalLast, 10);
        _decline1 = SetupCase(Scenario.AllDecline, 1);
        _decline10 = SetupCase(Scenario.AllDecline, 10);
    }

    [Benchmark(Baseline = true), BenchmarkCategory("Read")]
    public BenchmarkModel Read_NoProxy() => ModelReaderWriter.Read<BenchmarkModel>(_data, _noProxy);
    [Benchmark, BenchmarkCategory("Read")]
    public BenchmarkModel Read_Direct_1Key() => ModelReaderWriter.Read<BenchmarkModel>(_data, _direct1);
    [Benchmark, BenchmarkCategory("Read")]
    public BenchmarkModel Read_Direct_10Keys() => ModelReaderWriter.Read<BenchmarkModel>(_data, _direct10);
    [Benchmark, BenchmarkCategory("Read")]
    public BenchmarkModel Read_LookupMiss_1OtherKey() => ModelReaderWriter.Read<BenchmarkModel>(_data, _lookup1);
    [Benchmark, BenchmarkCategory("Read")]
    public BenchmarkModel Read_LookupMiss_10OtherKeys() => ModelReaderWriter.Read<BenchmarkModel>(_data, _lookup10);
    [Benchmark, BenchmarkCategory("Read")]
    public BenchmarkModel Read_Conditional_1Entry() => ModelReaderWriter.Read<BenchmarkModel>(_data, _conditional1);
    [Benchmark, BenchmarkCategory("Read")]
    public BenchmarkModel Read_Conditional_FirstOf10() => ModelReaderWriter.Read<BenchmarkModel>(_data, _first10);
    [Benchmark, BenchmarkCategory("Read")]
    public BenchmarkModel Read_Conditional_LastOf10() => ModelReaderWriter.Read<BenchmarkModel>(_data, _last10);
    [Benchmark, BenchmarkCategory("Read")]
    public BenchmarkModel Read_AllDecline_1Entry() => ModelReaderWriter.Read<BenchmarkModel>(_data, _decline1);
    [Benchmark, BenchmarkCategory("Read")]
    public BenchmarkModel Read_AllDecline_10Entries() => ModelReaderWriter.Read<BenchmarkModel>(_data, _decline10);

    [Benchmark(Baseline = true), BenchmarkCategory("Write")]
    public BinaryData Write_NoProxy() => ModelReaderWriter.Write(_model, _noProxy);
    [Benchmark, BenchmarkCategory("Write")]
    public BinaryData Write_Direct_1Key() => ModelReaderWriter.Write(_model, _direct1);
    [Benchmark, BenchmarkCategory("Write")]
    public BinaryData Write_Direct_10Keys() => ModelReaderWriter.Write(_model, _direct10);
    [Benchmark, BenchmarkCategory("Write")]
    public BinaryData Write_LookupMiss_1OtherKey() => ModelReaderWriter.Write(_model, _lookup1);
    [Benchmark, BenchmarkCategory("Write")]
    public BinaryData Write_LookupMiss_10OtherKeys() => ModelReaderWriter.Write(_model, _lookup10);
    [Benchmark, BenchmarkCategory("Write")]
    public BinaryData Write_Conditional_1Entry() => ModelReaderWriter.Write(_model, _conditional1);
    [Benchmark, BenchmarkCategory("Write")]
    public BinaryData Write_Conditional_FirstOf10() => ModelReaderWriter.Write(_model, _first10);
    [Benchmark, BenchmarkCategory("Write")]
    public BinaryData Write_Conditional_LastOf10() => ModelReaderWriter.Write(_model, _last10);
    [Benchmark, BenchmarkCategory("Write")]
    public BinaryData Write_AllDecline_1Entry() => ModelReaderWriter.Write(_model, _decline1);
    [Benchmark, BenchmarkCategory("Write")]
    public BinaryData Write_AllDecline_10Entries() => ModelReaderWriter.Write(_model, _decline10);

    private ModelReaderWriterOptions SetupCase(Scenario scenario, int count)
    {
        // Instrument only this verification graph, not the graph used by measured operations.
        var calls = new Calls();
        ModelReaderWriterOptions verificationOptions = CreateOptions(scenario, count, calls);
        BenchmarkModel result = ModelReaderWriter.Read<BenchmarkModel>(_data, verificationOptions);
        BinaryData written = ModelReaderWriter.Write(_model, verificationOptions);
        bool hit = scenario is Scenario.Direct or Scenario.ConditionalFirst or Scenario.ConditionalLast;
        int expectedChecks = scenario switch
        {
            Scenario.ConditionalFirst => 1,
            Scenario.ConditionalLast or Scenario.AllDecline => count,
            _ => 0
        };
        if (calls.ReadChecks != expectedChecks || calls.WriteChecks != expectedChecks ||
            calls.Reads != (hit ? 1 : 0) || calls.Writes != (hit ? 1 : 0) ||
            result.Type != _model.Type || result.Name != _model.Name ||
            result.Description != _model.Description || result.Count != _model.Count ||
            result.Enabled != _model.Enabled || result.Region != _model.Region ||
            result.Version != _model.Version || written.ToString() != Payload ||
            verificationOptions.ProxiedModel != null)
        {
            throw new InvalidOperationException($"Proxy fixture verification failed: {scenario}, {count}.");
        }
        return CreateOptions(scenario, count);
    }

    internal static ModelReaderWriterOptions CreateOptions(Scenario scenario, int count, Calls calls = null)
    {
        var options = new ModelReaderWriterOptions("J");
        if (count == 0)
            return options;

        JsonProxy proxy = calls == null ? s_proxy : new CountingJsonProxy(calls);
        if (scenario == Scenario.Direct)
        {
            options.AddProxy<BenchmarkModel>(proxy);
            for (int i = 0; i < count - 1; i++)
                s_unrelated[i](options);
        }
        else if (scenario == Scenario.LookupMiss)
        {
            for (int i = 0; i < count; i++)
                s_unrelated[i](options);
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                bool match = (scenario == Scenario.ConditionalFirst && i == 0) ||
                    (scenario == Scenario.ConditionalLast && i == count - 1);
                DiscriminatorProxy candidate = match ? s_matching : s_declining[i];
                options.AddProxy<BenchmarkModel>(calls == null ? candidate :
                    new CountingDiscriminatorProxy(candidate.Discriminator, proxy, calls));
            }
        }
        return options;
    }

    private static DiscriminatorProxy[] CreateDecliningProxies()
    {
        var proxies = new DiscriminatorProxy[10];
        for (int i = 0; i < proxies.Length; i++)
            proxies[i] = new DiscriminatorProxy($"other-{i}", s_proxy);
        return proxies;
    }

    internal sealed class Calls
    {
        public int ReadChecks, WriteChecks, Reads, Writes;
    }

    private class DiscriminatorProxy : ConditionalModelProxy<BenchmarkModel>
    {
        private readonly byte[] _utf8Discriminator;
        internal string Discriminator { get; }

        public DiscriminatorProxy(string discriminator, JsonProxy proxy) : base(proxy)
        {
            Discriminator = discriminator;
            _utf8Discriminator = Encoding.UTF8.GetBytes(discriminator);
        }

        public override bool CanHandle(BenchmarkModel model, ModelReaderWriterOptions options, ModelReaderWriterContext context)
            => string.Equals(model.Type, Discriminator, StringComparison.Ordinal);

        public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options, ModelReaderWriterContext context)
        {
            var reader = new Utf8JsonReader(data.Span);
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.PropertyName && reader.ValueTextEquals("type"u8))
                    return reader.Read() && reader.TokenType == JsonTokenType.String && reader.ValueTextEquals(_utf8Discriminator);
            }
            return false;
        }
    }

    private sealed class CountingDiscriminatorProxy : DiscriminatorProxy
    {
        private readonly Calls _calls;
        public CountingDiscriminatorProxy(string discriminator, JsonProxy proxy, Calls calls) : base(discriminator, proxy) => _calls = calls;

        public override bool CanHandle(BenchmarkModel model, ModelReaderWriterOptions options, ModelReaderWriterContext context)
        {
            _calls.WriteChecks++;
            return base.CanHandle(model, options, context);
        }

        public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options, ModelReaderWriterContext context)
        {
            _calls.ReadChecks++;
            return base.CanHandle(data, options, context);
        }
    }

    private class JsonProxy : IJsonModel<BenchmarkModel>
    {
        public virtual BenchmarkModel Create(BinaryData data, ModelReaderWriterOptions options) => BenchmarkModel.Deserialize(data);
        public BenchmarkModel Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return BenchmarkModel.Deserialize(document.RootElement);
        }
        public virtual void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((BenchmarkModel)options.ProxiedModel).Serialize(writer);
        public BinaryData Write(ModelReaderWriterOptions options) => throw new InvalidOperationException("Expected the JSON writer path.");
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }

    private sealed class CountingJsonProxy : JsonProxy
    {
        private readonly Calls _calls;
        public CountingJsonProxy(Calls calls) => _calls = calls;
        public override BenchmarkModel Create(BinaryData data, ModelReaderWriterOptions options)
        {
            _calls.Reads++;
            return base.Create(data, options);
        }
        public override void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            _calls.Writes++;
            base.Write(writer, options);
        }
    }

    private sealed class UnrelatedModel<T> : IPersistableModel<UnrelatedModel<T>>
    {
        public static readonly UnrelatedModel<T> Instance = new();
        public UnrelatedModel<T> Create(BinaryData data, ModelReaderWriterOptions options) => throw new InvalidOperationException("An unrelated proxy must not run.");
        public BinaryData Write(ModelReaderWriterOptions options) => throw new InvalidOperationException("An unrelated proxy must not run.");
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }

    public sealed class BenchmarkModel : IJsonModel<BenchmarkModel>
    {
        public string Type { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Count { get; private set; }
        public bool Enabled { get; private set; }
        public string Region { get; private set; }
        public string Version { get; private set; }

        internal static BenchmarkModel Deserialize(BinaryData data)
        {
            using JsonDocument document = JsonDocument.Parse(data);
            return Deserialize(document.RootElement);
        }

        internal static BenchmarkModel Deserialize(JsonElement element) => new()
        {
            Type = element.GetProperty("type"u8).GetString(),
            Name = element.GetProperty("name"u8).GetString(),
            Description = element.GetProperty("description"u8).GetString(),
            Count = element.GetProperty("count"u8).GetInt32(),
            Enabled = element.GetProperty("enabled"u8).GetBoolean(),
            Region = element.GetProperty("region"u8).GetString(),
            Version = element.GetProperty("version"u8).GetString()
        };

        internal void Serialize(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteString("type"u8, Type);
            writer.WriteString("name"u8, Name);
            writer.WriteString("description"u8, Description);
            writer.WriteNumber("count"u8, Count);
            writer.WriteBoolean("enabled"u8, Enabled);
            writer.WriteString("region"u8, Region);
            writer.WriteString("version"u8, Version);
            writer.WriteEndObject();
        }

        BenchmarkModel IPersistableModel<BenchmarkModel>.Create(BinaryData data, ModelReaderWriterOptions options) => Deserialize(data);
        BenchmarkModel IJsonModel<BenchmarkModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return Deserialize(document.RootElement);
        }
        void IJsonModel<BenchmarkModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => Serialize(writer);
        BinaryData IPersistableModel<BenchmarkModel>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write(this, options);
        string IPersistableModel<BenchmarkModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;

using BenchmarkDotNet.Attributes;

using OpenTelemetry;

/*
Baseline captured before the AzMonList/ActivityTagsProcessor rework.

Measures the full Activity -> TelemetryItem conversion (CategorizeTags plus every
MappedTags lookup performed by TelemetryItem/RequestData/RemoteDependencyData), with no
transmitter and no network. This is the granularity the existing benchmarks miss:
TagObjectsGetValuesBenchmarks measures a single lookup, but a real conversion performs
13-26 of them.

NOTE: ShortRun (3 iterations) - Error is wide. Re-run without --job short for a
publishable comparison.

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.9106/25H2/2025Update/HudsonValley2) (Hyper-V)
Intel Xeon Platinum 8370C CPU 2.80GHz (Max: 2.79GHz), 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.400
  [Host]   : .NET 8.0.30 (8.0.30, 8.0.3026.36720), X64 RyuJIT x86-64-v4
  ShortRun : .NET 8.0.30 (8.0.30, 8.0.3026.36720), X64 RyuJIT x86-64-v4

Job=ShortRun  IterationCount=3  LaunchCount=1  WarmupCount=3

| Method                | Mean       | Error    | StdDev   | Ratio | Gen0   | Allocated |
|---------------------- |-----------:|---------:|---------:|------:|-------:|----------:|
| HttpServer_NewSemConv | 1,558.3 ns | 514.9 ns | 28.22 ns |  1.00 | 0.0916 |   2.26 KB |
| HttpServer_OldSemConv | 1,388.6 ns | 133.3 ns |  7.30 ns |  0.89 | 0.0782 |   1.94 KB |
| HttpClient_NewSemConv | 1,436.0 ns | 272.2 ns | 14.92 ns |  0.92 | 0.0687 |   1.73 KB |
| HttpClient_OldSemConv | 1,523.3 ns | 416.6 ns | 22.84 ns |  0.98 | 0.0629 |   1.56 KB |
| DbClient_NewSemConv   | 1,232.8 ns | 369.2 ns | 20.24 ns |  0.79 | 0.0648 |   1.62 KB |
| DbClient_OldSemConv   | 1,118.4 ns | 159.2 ns |  8.73 ns |  0.72 | 0.0591 |   1.49 KB |
| Messaging             | 1,014.7 ns | 449.6 ns | 24.64 ns |  0.65 | 0.0706 |   1.75 KB |
| AzureSdk              |   896.8 ns | 234.0 ns | 12.82 ns |  0.58 | 0.0601 |   1.48 KB |
| OverrideAttributes    | 2,001.5 ns | 235.6 ns | 12.92 ns |  1.28 | 0.0725 |   1.84 KB |
| ArrayValuedTags       | 1,937.4 ns | 770.6 ns | 42.24 ns |  1.24 | 0.1030 |   2.62 KB |

OverrideAttributes is the slowest shape because it performs the most MappedTags lookups
(7 context-tag overrides plus 4 request overrides on top of the base path).

After switching mapped-tag reads to slot indexing, and holding recognized attributes in the
slot array alone so a mapped list rents one pooled buffer instead of two. Every shape
improves against the baseline; the read-heavy shapes improve most because a conversion
performs 13-26 attribute reads.

| Method                | Mean       | Error       | StdDev   | Ratio | Gen0   | Allocated |
|---------------------- |-----------:|------------:|---------:|------:|-------:|----------:|
| HttpServer_NewSemConv | 1,356.7 ns |   224.72 ns | 12.32 ns |  1.00 | 0.0858 |   2.13 KB |
| HttpServer_OldSemConv | 1,296.7 ns |   210.99 ns | 11.57 ns |  0.96 | 0.0782 |   1.94 KB |
| HttpClient_NewSemConv | 1,322.8 ns |   157.20 ns |  8.62 ns |  0.98 | 0.0668 |   1.65 KB |
| HttpClient_OldSemConv | 1,515.7 ns | 1,164.84 ns | 63.85 ns |  1.12 | 0.0629 |   1.56 KB |
| DbClient_NewSemConv   |   960.3 ns |   119.32 ns |  6.54 ns |  0.71 | 0.0553 |   1.37 KB |
| DbClient_OldSemConv   | 1,001.9 ns |   335.84 ns | 18.41 ns |  0.74 | 0.0534 |   1.34 KB |
| Messaging             |   933.8 ns |    76.35 ns |  4.18 ns |  0.69 | 0.0677 |   1.67 KB |
| AzureSdk              |   838.7 ns |   186.51 ns | 10.22 ns |  0.62 | 0.0563 |    1.4 KB |
| OverrideAttributes    | 1,333.0 ns |   304.17 ns | 16.67 ns |  0.98 | 0.0687 |   1.72 KB |
| ArrayValuedTags       | 1,808.0 ns |   501.17 ns | 27.47 ns |  1.33 | 0.1011 |   2.49 KB |
*/

namespace Azure.Monitor.OpenTelemetry.Exporter.Benchmarks
{
    [MemoryDiagnoser]
    public class ActivityConversionBenchmarks
    {
        private const string InstrumentationKey = "00000000-0000-0000-0000-000000000000";

        private static readonly AzureMonitorResource s_resource = new(
            roleName: "BenchmarkRole",
            roleInstance: "BenchmarkInstance",
            serviceVersion: "1.0.0",
            monitorBaseData: null);

        private Batch<Activity> _httpServerNewSemConv;
        private Batch<Activity> _httpServerOldSemConv;
        private Batch<Activity> _httpClientNewSemConv;
        private Batch<Activity> _httpClientOldSemConv;
        private Batch<Activity> _dbClientNewSemConv;
        private Batch<Activity> _dbClientOldSemConv;
        private Batch<Activity> _messaging;
        private Batch<Activity> _azureSdk;
        private Batch<Activity> _overrideAttributes;
        private Batch<Activity> _arrayValuedTags;

        static ActivityConversionBenchmarks()
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            Activity.ForceDefaultIdFormat = true;

            var listener = new ActivityListener
            {
                ShouldListenTo = _ => true,
                Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllData,
            };

            ActivitySource.AddActivityListener(listener);
        }

        [GlobalSetup]
        public void Setup()
        {
            _httpServerNewSemConv = CreateBatch(ActivityKind.Server, new Dictionary<string, object?>
            {
                [SemanticConventions.AttributeHttpRequestMethod] = "GET",
                [SemanticConventions.AttributeUrlScheme] = "https",
                [SemanticConventions.AttributeUrlPath] = "/api/items",
                [SemanticConventions.AttributeUrlQuery] = "?id=1",
                [SemanticConventions.AttributeServerAddress] = "localhost",
                [SemanticConventions.AttributeServerPort] = 8080,
                [SemanticConventions.AttributeHttpRoute] = "api/{id}",
                [SemanticConventions.AttributeHttpResponseStatusCode] = 200,
                [SemanticConventions.AttributeUserAgentOriginal] = "Mozilla/5.0",
                [SemanticConventions.AttributeClientAddress] = "127.0.0.1",
                ["custom.tenant"] = "contoso",
                ["custom.region"] = "westus2",
            });

            _httpServerOldSemConv = CreateBatch(ActivityKind.Server, new Dictionary<string, object?>
            {
                [SemanticConventions.AttributeHttpMethod] = "GET",
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpTarget] = "/api/items",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpRoute] = "api/{id}",
                [SemanticConventions.AttributeNetHostName] = "localhost",
                [SemanticConventions.AttributeNetHostPort] = 8080,
                [SemanticConventions.AttributeHttpStatusCode] = 200,
                [SemanticConventions.AttributeHttpUserAgent] = "Mozilla/5.0",
                ["custom.tenant"] = "contoso",
                ["custom.region"] = "westus2",
            });

            _httpClientNewSemConv = CreateBatch(ActivityKind.Client, new Dictionary<string, object?>
            {
                [SemanticConventions.AttributeHttpRequestMethod] = "POST",
                [SemanticConventions.AttributeUrlFull] = "https://localhost:8080/api/items",
                [SemanticConventions.AttributeServerAddress] = "localhost",
                [SemanticConventions.AttributeServerPort] = 8080,
                [SemanticConventions.AttributeHttpResponseStatusCode] = 200,
                ["custom.tenant"] = "contoso",
                ["custom.region"] = "westus2",
            });

            // Worst measured case: every old-semconv fallback chain is walked.
            _httpClientOldSemConv = CreateBatch(ActivityKind.Client, new Dictionary<string, object?>
            {
                [SemanticConventions.AttributeHttpMethod] = "POST",
                [SemanticConventions.AttributeHttpUrl] = "https://localhost:8080/api/items",
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpTarget] = "/api/items",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeNetPeerName] = "localhost",
                [SemanticConventions.AttributeNetPeerIp] = "127.0.0.1",
                [SemanticConventions.AttributeNetPeerPort] = 8080,
                [SemanticConventions.AttributePeerService] = "items-service",
                [SemanticConventions.AttributeHttpStatusCode] = 200,
                [SemanticConventions.AttributeHttpUserAgent] = "Mozilla/5.0",
                ["custom.tenant"] = "contoso",
                ["custom.region"] = "westus2",
            });

            _dbClientNewSemConv = CreateBatch(ActivityKind.Client, new Dictionary<string, object?>
            {
                [SemanticConventions.AttributeDbSystemName] = "mssql",
                [SemanticConventions.AttributeDbNamespace] = "inventory",
                [SemanticConventions.AttributeDbQueryText] = "SELECT * FROM items WHERE id = @id",
                [SemanticConventions.AttributeServerAddress] = "localhost",
                [SemanticConventions.AttributeServerPort] = 1433,
                ["custom.tenant"] = "contoso",
            });

            _dbClientOldSemConv = CreateBatch(ActivityKind.Client, new Dictionary<string, object?>
            {
                [SemanticConventions.AttributeDbSystem] = "mssql",
                [SemanticConventions.AttributeDbName] = "inventory",
                [SemanticConventions.AttributeDbStatement] = "SELECT * FROM items WHERE id = @id",
                [SemanticConventions.AttributePeerService] = "sqlserver",
                [SemanticConventions.AttributeNetPeerName] = "localhost",
                [SemanticConventions.AttributeNetPeerIp] = "127.0.0.1",
                [SemanticConventions.AttributeNetPeerPort] = 1433,
                ["custom.tenant"] = "contoso",
            });

            _messaging = CreateBatch(ActivityKind.Producer, new Dictionary<string, object?>
            {
                [SemanticConventions.AttributeMessagingSystem] = "servicebus",
                [SemanticConventions.AttributeMessagingDestinationName] = "orders",
                [SemanticConventions.AttributeNetworkProtocolName] = "amqp",
                [SemanticConventions.AttributeServerAddress] = "contoso.servicebus.windows.net",
                ["custom.tenant"] = "contoso",
            });

            _azureSdk = CreateBatch(ActivityKind.Client, new Dictionary<string, object?>
            {
                [SemanticConventions.AttributeAzureNameSpace] = "Microsoft.ServiceBus",
                [SemanticConventions.AttributeServerAddress] = "contoso.servicebus.windows.net",
                [SemanticConventions.AttributeServerPort] = 443,
                ["custom.tenant"] = "contoso",
            });

            // Exercises HasOverrideAttributes plus all seven context-tag lookups.
            _overrideAttributes = CreateBatch(ActivityKind.Server, new Dictionary<string, object?>
            {
                [SemanticConventions.AttributeHttpRequestMethod] = "GET",
                [SemanticConventions.AttributeUrlPath] = "/api/items",
                [SemanticConventions.AttributeHttpResponseStatusCode] = 200,
                [SemanticConventions.AttributeMicrosoftOperationName] = "GET /api/items",
                [SemanticConventions.AttributeMicrosoftRequestName] = "OverrideName",
                [SemanticConventions.AttributeMicrosoftRequestUrl] = "https://localhost/api/items",
                [SemanticConventions.AttributeMicrosoftRequestSource] = "OverrideSource",
                [SemanticConventions.AttributeMicrosoftRequestResultCode] = "201",
                [SemanticConventions.AttributeMicrosoftSessionId] = "session-1",
                [SemanticConventions.AttributeAiDeviceId] = "device-1",
                [SemanticConventions.AttributeAiDeviceModel] = "model-1",
                [SemanticConventions.AttributeAiDeviceType] = "type-1",
                [SemanticConventions.AttributeAiDeviceOsVersion] = "os-1",
                [SemanticConventions.AttributeMicrosoftSyntheticSource] = "synthetic-1",
                [SemanticConventions.AttributeMicrosoftUserAccountId] = "account-1",
                [SemanticConventions.AttributeEnduserId] = "user-1",
                [SemanticConventions.AttributeEnduserPseudoId] = "pseudo-1",
            });

            // Exercises the ToCommaDelimitedString path in the UnMappedTags branch.
            _arrayValuedTags = CreateBatch(ActivityKind.Server, new Dictionary<string, object?>
            {
                [SemanticConventions.AttributeHttpRequestMethod] = "GET",
                [SemanticConventions.AttributeUrlPath] = "/api/items",
                [SemanticConventions.AttributeHttpResponseStatusCode] = 200,
                ["custom.ints"] = new int[] { 1, 2, 3, 4, 5 },
                ["custom.strings"] = new string[] { "a", "b", "c" },
                ["custom.bools"] = new bool[] { true, false },
            });
        }

        [Benchmark(Baseline = true)]
        public void HttpServer_NewSemConv() => Convert(_httpServerNewSemConv);

        [Benchmark]
        public void HttpServer_OldSemConv() => Convert(_httpServerOldSemConv);

        [Benchmark]
        public void HttpClient_NewSemConv() => Convert(_httpClientNewSemConv);

        [Benchmark]
        public void HttpClient_OldSemConv() => Convert(_httpClientOldSemConv);

        [Benchmark]
        public void DbClient_NewSemConv() => Convert(_dbClientNewSemConv);

        [Benchmark]
        public void DbClient_OldSemConv() => Convert(_dbClientOldSemConv);

        [Benchmark]
        public void Messaging() => Convert(_messaging);

        [Benchmark]
        public void AzureSdk() => Convert(_azureSdk);

        [Benchmark]
        public void OverrideAttributes() => Convert(_overrideAttributes);

        [Benchmark]
        public void ArrayValuedTags() => Convert(_arrayValuedTags);

        private static void Convert(Batch<Activity> batch)
            => TraceHelper.OtelToAzureMonitorTrace(batch, s_resource, InstrumentationKey, sampleRate: 100F);

        private static Batch<Activity> CreateBatch(ActivityKind kind, Dictionary<string, object?> tags)
        {
            var activitySource = new ActivitySource(nameof(ActivityConversionBenchmarks));
            var startTimestamp = DateTime.UtcNow;

            var activity = activitySource.StartActivity(
                "BenchmarkActivity",
                kind,
                parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                tags,
                links: null,
                startTime: startTimestamp);

            if (activity == null)
            {
                throw new InvalidOperationException("Activity was not sampled. The ActivityListener is not configured correctly.");
            }

            activity.SetStatus(ActivityStatusCode.Ok);
            activity.SetEndTime(startTimestamp.AddMilliseconds(50));
            activity.Stop();

            return new Batch<Activity>(new[] { activity }, 1);
        }
    }
}

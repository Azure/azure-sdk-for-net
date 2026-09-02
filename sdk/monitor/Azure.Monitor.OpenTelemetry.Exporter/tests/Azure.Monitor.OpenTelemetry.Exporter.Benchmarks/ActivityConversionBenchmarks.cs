// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;

using BenchmarkDotNet.Attributes;

using OpenTelemetry;

/*
Measures the full Activity -> TelemetryItem conversion (CategorizeTags plus every
recognized-attribute read performed by TelemetryItem/RequestData/RemoteDependencyData),
with no transmitter and no network. This is the granularity the existing benchmarks miss:
TagObjectsGetValuesBenchmarks measures a single read, but a real conversion performs 13-26
of them.

Both tables below are MediumRun on the same machine. The "before" run is this file compiled
against the unmodified exporter, so the pair is like for like. Deltas exceed the combined
error on every shape except HttpClient_OldSemConv, Messaging, AzureSdk and ArrayValuedTags,
where they are marginal and should be read as directional only.

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.9106/25H2/2025Update/HudsonValley2) (Hyper-V)
Intel Xeon Platinum 8370C CPU 2.80GHz (Max: 2.79GHz), 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.400
  [Host]    : .NET 8.0.30 (8.0.30, 8.0.3026.36720), X64 RyuJIT x86-64-v4
  MediumRun : .NET 8.0.30 (8.0.30, 8.0.3026.36720), X64 RyuJIT x86-64-v4

Job=MediumRun  IterationCount=15  LaunchCount=2  WarmupCount=10

BEFORE

| Method                | Mean       | Error    | StdDev   | Gen0   | Allocated |
|---------------------- |-----------:|---------:|---------:|-------:|----------:|
| HttpServer_NewSemConv | 1,570.1 ns | 31.32 ns | 44.91 ns | 0.0916 |   2.26 KB |
| HttpServer_OldSemConv | 1,401.9 ns | 27.76 ns | 41.55 ns | 0.0782 |   1.94 KB |
| HttpClient_NewSemConv | 1,449.4 ns | 23.10 ns | 34.57 ns | 0.0687 |   1.73 KB |
| HttpClient_OldSemConv | 1,522.5 ns | 20.03 ns | 29.98 ns | 0.0629 |   1.56 KB |
| DbClient_NewSemConv   | 1,238.4 ns | 20.42 ns | 29.29 ns | 0.0648 |   1.62 KB |
| DbClient_OldSemConv   | 1,146.0 ns | 23.40 ns | 35.02 ns | 0.0591 |   1.49 KB |
| Messaging             | 1,019.8 ns | 18.41 ns | 27.56 ns | 0.0706 |   1.75 KB |
| AzureSdk              |   901.2 ns | 11.38 ns | 16.32 ns | 0.0601 |   1.48 KB |
| OverrideAttributes    | 2,024.6 ns | 37.40 ns | 55.97 ns | 0.0725 |   1.84 KB |
| ArrayValuedTags       | 1,968.9 ns | 34.74 ns | 52.00 ns | 0.1030 |   2.62 KB |

AFTER

| Method                | Mean       | Error    | StdDev   | Gen0   | Allocated | Delta  |
|---------------------- |-----------:|---------:|---------:|-------:|----------:|-------:|
| HttpServer_NewSemConv | 1,406.9 ns | 32.18 ns | 48.16 ns | 0.0858 |   2.13 KB | -10.4% |
| HttpServer_OldSemConv | 1,273.5 ns | 20.12 ns | 30.12 ns | 0.0782 |   1.94 KB |  -9.2% |
| HttpClient_NewSemConv | 1,322.2 ns | 25.67 ns | 37.62 ns | 0.0668 |   1.65 KB |  -8.8% |
| HttpClient_OldSemConv | 1,462.6 ns | 43.43 ns | 63.66 ns | 0.0629 |   1.56 KB |  -3.9% |
| DbClient_NewSemConv   |   962.8 ns | 16.38 ns | 24.51 ns | 0.0553 |   1.37 KB | -22.3% |
| DbClient_OldSemConv   |   978.2 ns | 17.93 ns | 26.83 ns | 0.0534 |   1.34 KB | -14.6% |
| Messaging             |   981.0 ns | 19.05 ns | 28.51 ns | 0.0677 |   1.67 KB |  -3.8% |
| AzureSdk              |   873.2 ns | 17.35 ns | 24.89 ns | 0.0563 |    1.4 KB |  -3.1% |
| OverrideAttributes    | 1,361.7 ns | 49.72 ns | 72.87 ns | 0.0687 |   1.72 KB | -32.7% |
| ArrayValuedTags       | 1,892.9 ns | 57.24 ns | 85.68 ns | 0.1011 |   2.49 KB |  -3.9% |

OverrideAttributes gains the most because it performs the most reads: 7 context-tag
overrides and 4 request overrides on top of the base path. Averaged across the ten shapes
a conversion costs 173 ns less and allocates 105 bytes less. Two shapes are unchanged on
managed allocation; the pooled buffer a mapped list no longer rents does not appear in the
Allocated column, because MemoryDiagnoser does not count ArrayPool rents.
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

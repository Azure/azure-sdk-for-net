// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiTenant;

using BenchmarkDotNet.Attributes;

using OpenTelemetry;

/*
Measures the routed conversion against the single-tenant one, and how the routed path scales with
the number of distinct ingestion endpoints in a batch.

There is no single honest way to compare the two conversions, because the routing attributes are
custom dimensions to one path and consumed input to the other. Both baselines are therefore measured:

  SingleTenant_NoRoutingTags   - single-tenant on a batch carrying no routing attributes. This is
                                 how single-tenant actually runs, and is the number to quote for the
                                 existing product.
  SingleTenant_WithRoutingTags - single-tenant on the same batch the routed path is given. The two
                                 extra attributes fall through to unmapped tags and are serialized as
                                 custom dimensions, work the routed path does not do.
  MultiTenant                  - the routed conversion on that same batch.

MultiTenant against SingleTenant_WithRoutingTags is an upper bound on what routing costs, not an
isolated measurement of it: any gap includes two custom dimensions per Activity that only the
baseline pays. The gap between the two baselines is what those two dimensions cost on their own.

GroupOnly isolates EndpointRouteBatch.GetOrAdd, whose ordinal linear scan over the groups opened so
far is documented as beating a hash at the handful of regions a process is expected to talk to. The
endpoint strings are built once in setup and indexed rather than formatted in the loop: formatting
512 strings per iteration costs more than the thing being measured and puts its own garbage in the
allocation column. Indexing also reproduces production, where TenantRouting.NormalizeEndpoint
memoizes and hands GetOrAdd the same instance every time, so the ordinal comparison short-circuits
on reference equality.

Both SingleTenant rows are independent of EndpointCount, so their spread across the three parameter
values is this harness's noise floor. It came out at about 12%, so each baseline is pooled across
its three rows before any percentage below is computed; a per-row comparison would manufacture
differences out of that spread.

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.9106/25H2/2025Update/HudsonValley2) (Hyper-V)
Intel Xeon Platinum 8370C CPU 2.80GHz (Max: 2.79GHz), 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.401
  [Host]    : .NET 8.0.31 (8.0.31, 8.0.3126.42015), X64 RyuJIT x86-64-v4
  MediumRun : .NET 8.0.31 (8.0.31, 8.0.3126.42015), X64 RyuJIT x86-64-v4

Job=MediumRun  IterationCount=15  LaunchCount=2  WarmupCount=10

| Method                       | EndpointCount | Mean         | Error        | StdDev        | Ratio | RatioSD | Gen0    | Gen1    | Allocated | Alloc Ratio |
|----------------------------- |-------------- |-------------:|-------------:|--------------:|------:|--------:|--------:|--------:|----------:|------------:|
| SingleTenant_NoRoutingTags   | 1             | 643,799.5 ns | 34,496.91 ns |  51,633.35 ns | 1.006 |    0.11 | 30.2734 | 21.4844 |  766208 B |        1.00 |
| SingleTenant_WithRoutingTags | 1             | 726,850.7 ns | 35,138.94 ns |  52,594.32 ns | 1.136 |    0.12 | 30.2734 | 21.4844 |  766208 B |        1.00 |
| MultiTenant                  | 1             | 765,342.8 ns | 97,410.61 ns | 145,799.63 ns | 1.196 |    0.24 | 29.2969 |  9.7656 |  757760 B |        0.99 |
| GroupOnly                    | 1             |     998.2 ns |     34.32 ns |      48.11 ns | 0.002 |    0.00 |       - |       - |         - |        0.00 |
| SingleTenant_NoRoutingTags   | 3             | 658,007.1 ns | 68,808.27 ns | 102,988.99 ns | 1.020 |    0.21 | 30.2734 | 21.4844 |  766208 B |        1.00 |
| SingleTenant_WithRoutingTags | 3             | 703,885.8 ns | 31,395.07 ns |  46,990.67 ns | 1.092 |    0.16 | 30.2734 | 21.4844 |  766208 B |        1.00 |
| MultiTenant                  | 3             | 686,400.9 ns | 40,725.12 ns |  60,955.45 ns | 1.064 |    0.17 | 29.2969 |  9.7656 |  757760 B |        0.99 |
| GroupOnly                    | 3             |   2,522.1 ns |    111.31 ns |     159.64 ns | 0.004 |    0.00 |       - |       - |         - |        0.00 |
| SingleTenant_NoRoutingTags   | 25            | 588,613.8 ns | 13,589.76 ns |  19,050.95 ns | 1.000 |    0.04 | 30.2734 | 21.4844 |  766208 B |        1.00 |
| SingleTenant_WithRoutingTags | 25            | 690,046.4 ns | 18,759.69 ns |  27,497.71 ns | 1.170 |    0.06 | 30.2734 | 21.4844 |  766208 B |        1.00 |
| MultiTenant                  | 25            | 818,049.2 ns | 60,325.65 ns |  86,517.25 ns | 1.390 |    0.15 | 29.2969 |  9.7656 |  757760 B |        0.99 |
| GroupOnly                    | 25            |  16,216.6 ns |    733.30 ns |   1,097.56 ns | 0.030 |    0.00 |       - |       - |         - |        0.00 |

Pooled baselines: 630 us without the routing attributes, 707 us with them.

1. Grouping is cheap and allocates nothing. GroupOnly sorts 512 Activities into N buckets and does
   nothing else. GetOrAdd scans the buckets already open, so the average scan is (N+1)/2 deep, and
   the measured cost is a flat ~2.4 ns per comparison at every N: 1.95, 2.46 and 2.44. That is 1 us
   at one endpoint and 16 us at 25, against roughly 800 us to convert the same batch, so about 2%.
   Extrapolating the same 2.4 ns to the 64-partition cap gives about 41 us, or 5%. Not worth
   replacing with a hash, which would add an allocation to the one-to-three endpoint case that every
   deployment pays.

2. The routing attributes cost the single-tenant path about 12% (707 us against 630 us pooled).
   That is the bias that has to come out before routing is judged at all.

3. Routing itself costs roughly 9% to 30% over a plain single-tenant conversion, depending on
   endpoint count, and the endpoint count is what moves it. Against the like-for-like baseline that
   also carries the attributes, the routed path is within noise at 1 and 3 endpoints and about 16%
   slower at 25.

4. The routed path allocates 8,448 B less per batch, identically in all three rows. This is not the
   routing attributes: both baselines allocate 766,208 B whether they carry those attributes or not,
   so serializing them costs nothing measurable. It is the two per-call objects the single-tenant
   path builds and the routed path does not - a List<TelemetryItem> grown to 512 entries (8,384 B of
   backing arrays plus the list) and a TelemetrySchemaTypeCounter (64 B) - which sums to exactly the
   observed gap. The routed path writes into the pooled group list instead. The Gen1 column carries
   the same story more usefully: 21.5 against 9.8.

MemoryDiagnoser does not count ArrayPool rents, and AzMonList rents on both paths, so the Allocated
column excludes that traffic. GroupOnly's zero is unaffected: EndpointRouteBatch uses no pool.
*/
namespace Azure.Monitor.OpenTelemetry.Exporter.Benchmarks
{
    [MemoryDiagnoser]
    public class MultiTenantExportBenchmarks
    {
        private const string InstrumentationKey = "00000000-0000-0000-0000-000000000000";
        private const int BatchSize = 512;

        private static readonly AzureMonitorResource s_resource = new(
            roleName: "BenchmarkRole",
            roleInstance: "BenchmarkInstance",
            serviceVersion: "1.0.0",
            monitorBaseData: null);

        private Batch<Activity> _routedBatch;
        private Batch<Activity> _plainBatch;
        private EndpointRouteBatch _routeBatch = null!;
        private string[] _endpoints = null!;

        [Params(1, 3, 25)]
        public int EndpointCount { get; set; }

        static MultiTenantExportBenchmarks()
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
            _endpoints = new string[EndpointCount];

            for (int i = 0; i < EndpointCount; i++)
            {
                _endpoints[i] = string.Format(CultureInfo.InvariantCulture, "https://region{0}.in.applicationinsights.azure.com/", i);
            }

            _routeBatch = new EndpointRouteBatch();
            _routedBatch = CreateBatch(BatchSize, withRoutingTags: true);
            _plainBatch = CreateBatch(BatchSize, withRoutingTags: false);
        }

        [Benchmark(Baseline = true)]
        public int SingleTenant_NoRoutingTags() => ConvertSingleTenant(_plainBatch);

        [Benchmark]
        public int SingleTenant_WithRoutingTags() => ConvertSingleTenant(_routedBatch);

        [Benchmark]
        public int MultiTenant()
        {
            _routeBatch.Reset();

            TraceHelper.OtelToAzureMonitorTraceMultiTenant(
                _routedBatch,
                s_resource,
                sampleRate: 100F,
                _routeBatch);

            return _routeBatch.Count;
        }

        [Benchmark]
        public int GroupOnly()
        {
            _routeBatch.Reset();

            for (int i = 0; i < BatchSize; i++)
            {
                _routeBatch.GetOrAdd(_endpoints[i % EndpointCount]);
            }

            return _routeBatch.Count;
        }

        private static int ConvertSingleTenant(Batch<Activity> batch)
        {
            var (telemetryItems, _) = TraceHelper.OtelToAzureMonitorTrace(
                batch,
                s_resource,
                InstrumentationKey,
                sampleRate: 100F);

            return telemetryItems.Count;
        }

        private Batch<Activity> CreateBatch(int size, bool withRoutingTags)
        {
            var activitySource = new ActivitySource(nameof(MultiTenantExportBenchmarks));
            var activities = new Activity[size];

            for (int i = 0; i < size; i++)
            {
                var tags = new Dictionary<string, object?>
                {
                    [SemanticConventions.AttributeHttpRequestMethod] = "GET",
                    [SemanticConventions.AttributeUrlScheme] = "https",
                    [SemanticConventions.AttributeUrlPath] = "/api/items",
                    [SemanticConventions.AttributeServerAddress] = "localhost",
                    [SemanticConventions.AttributeServerPort] = 8080,
                    [SemanticConventions.AttributeHttpRoute] = "api/{id}",
                    [SemanticConventions.AttributeHttpResponseStatusCode] = 200,
                    ["custom.tenant"] = "contoso",
                };

                if (withRoutingTags)
                {
                    tags[SemanticConventions.AttributeMicrosoftInstrumentationKey] = InstrumentationKey;
                    tags[SemanticConventions.AttributeMicrosoftIngestionEndpoint] = _endpoints[i % EndpointCount];
                }

                var startTimestamp = DateTime.UtcNow;

                var activity = activitySource.StartActivity(
                    "BenchmarkActivity",
                    ActivityKind.Server,
                    parentContext: new ActivityContext(ActivityTraceId.CreateRandom(), ActivitySpanId.CreateRandom(), ActivityTraceFlags.Recorded),
                    tags,
                    links: null,
                    startTime: startTimestamp);

                activity!.SetStatus(ActivityStatusCode.Ok);
                activity.SetEndTime(startTimestamp.AddMilliseconds(50));
                activity.Stop();

                activities[i] = activity;
            }

            return new Batch<Activity>(activities, size);
        }
    }
}

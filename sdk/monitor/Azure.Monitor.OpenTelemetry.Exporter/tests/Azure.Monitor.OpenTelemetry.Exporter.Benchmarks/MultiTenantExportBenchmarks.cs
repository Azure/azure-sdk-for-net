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
values is this harness's noise floor. Read nothing from a difference smaller than that spread.

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.9106/25H2/2025Update/HudsonValley2) (Hyper-V)
Intel Xeon Platinum 8370C CPU 2.80GHz (Max: 2.79GHz), 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.401
  [Host]    : .NET 8.0.31 (8.0.31, 8.0.3126.42015), X64 RyuJIT x86-64-v4
  MediumRun : .NET 8.0.31 (8.0.31, 8.0.3126.42015), X64 RyuJIT x86-64-v4

Job=MediumRun  IterationCount=15  LaunchCount=2  WarmupCount=10   BatchSize=512

| Method                       | EndpointCount | Mean         | Error        | Ratio | Allocated |
|----------------------------- |-------------- |-------------:|-------------:|------:|----------:|
| SingleTenant_NoRoutingTags   | 1             | 643,799.5 ns | 34,496.91 ns | 1.006 |  766208 B |
| SingleTenant_WithRoutingTags | 1             | 726,850.7 ns | 35,138.94 ns | 1.136 |  766208 B |
| MultiTenant                  | 1             | 765,342.8 ns | 97,410.61 ns | 1.196 |  757760 B |
| GroupOnly                    | 1             |     998.2 ns |     34.32 ns | 0.002 |       0 B |
| SingleTenant_NoRoutingTags   | 3             | 658,007.1 ns | 68,808.27 ns | 1.020 |  766208 B |
| SingleTenant_WithRoutingTags | 3             | 703,885.8 ns | 31,395.07 ns | 1.092 |  766208 B |
| MultiTenant                  | 3             | 686,400.9 ns | 40,725.12 ns | 1.064 |  757760 B |
| GroupOnly                    | 3             |   2,522.1 ns |    111.31 ns | 0.004 |       0 B |
| SingleTenant_NoRoutingTags   | 25            | 588,613.8 ns | 13,589.76 ns | 1.000 |  766208 B |
| SingleTenant_WithRoutingTags | 25            | 690,046.4 ns | 18,759.69 ns | 1.170 |  766208 B |
| MultiTenant                  | 25            | 818,049.2 ns | 60,325.65 ns | 1.390 |  757760 B |
| GroupOnly                    | 25            |  16,216.6 ns |    733.30 ns | 0.030 |       0 B |

Reading these numbers:

The noise floor is about 12%: SingleTenant_NoRoutingTags does identical work in all three rows and
came out 644, 658 and 589 us. Nothing below that is a result.

Grouping is linear in the endpoint count and allocates nothing. 998 ns, 2.5 us and 16.2 us for 512
lookups is roughly 2, 5 and 32 ns per lookup against 1, 3 and 25 open groups, which is the ordinal
scan doing exactly what a scan does. The zero in the allocation column is the useful part: it is
direct evidence that the group and list pooling holds, with no garbage per export. In absolute terms
16.2 us against 818 us of conversion is about 2% of a routed export at 25 endpoints, and a linear
extrapolation to the 64-partition cap gives roughly 40 us, or 5%. The scan is not worth replacing;
a hash would add an allocation to the one-to-three endpoint case that every deployment pays.

Routing is not cheaper than single-tenant. The two extra custom dimensions cost the baseline 7 to
17% (SingleTenant_WithRoutingTags against SingleTenant_NoRoutingTags), and once that bias is
accounted for MultiTenant is within noise of its like-for-like partner at 1 and 3 endpoints and
about 19% slower at 25, where grouping and route validation have grown. Against the realistic
single-tenant workload, which carries no routing attributes at all, the routed path costs 4 to 39%
more depending on endpoint count.

The one stable non-time result is allocation: MultiTenant allocates 757,760 B against 766,208 B,
about 1% less, identically in all three parameter rows. That is the routed path consuming the two
routing attributes instead of serializing them as custom dimensions, and it is consistent enough
across rows to be believed where the timings are not.
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

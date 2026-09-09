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

Two things are being separated:

  SingleTenant / MultiTenant at EndpointCount=1 answers what routing costs per Activity when there
  is nothing to group. The routed path skips the resource envelope and the schema counter, and adds
  routing tag recognition, route validation and endpoint normalization.

  MultiTenant across EndpointCount 1, 3 and 25 answers whether the grouping strategy holds up.
  EndpointRouteBatch.GetOrAdd does an ordinal linear scan over the groups opened so far, which is
  documented as beating a hash at the handful of regions a process is expected to talk to. At 25
  endpoints a 512-Activity batch performs up to ~12,800 string comparisons, so this is where that
  assumption is tested rather than assumed.

SingleTenant is the baseline. It does not vary with EndpointCount - the routing tags are simply
carried as ordinary custom dimensions - so its rows should be flat, and a non-flat result means the
measurement is picking up noise rather than signal.

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.9106/25H2/2025Update/HudsonValley2) (Hyper-V)
Intel Xeon Platinum 8370C CPU 2.80GHz (Max: 2.79GHz), 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.401
  [Host]    : .NET 8.0.31 (8.0.31, 8.0.3126.42015), X64 RyuJIT x86-64-v4
  MediumRun : .NET 8.0.31 (8.0.31, 8.0.3126.42015), X64 RyuJIT x86-64-v4

Job=MediumRun  IterationCount=15  LaunchCount=2  WarmupCount=10   BatchSize=512

| Method       | EndpointCount | Mean      | Error      | StdDev     | Ratio | Allocated | Alloc Ratio |
|------------- |-------------- |----------:|-----------:|-----------:|------:|----------:|------------:|
| SingleTenant | 1             | 864.32 us | 122.343 us | 175.461 us |  1.04 | 748.25 KB |        1.00 |
| MultiTenant  | 1             | 643.26 us |  14.872 us |  22.260 us |  0.77 |    740 KB |        0.99 |
| GroupOnly    | 1             |  37.10 us |   1.887 us |   2.707 us |  0.04 |     72 KB |        0.10 |
| SingleTenant | 3             | 739.64 us |  25.741 us |  37.730 us |  1.00 | 748.25 KB |        1.00 |
| MultiTenant  | 3             | 654.11 us |  17.335 us |  24.861 us |  0.89 |    740 KB |        0.99 |
| GroupOnly    | 3             |  36.87 us |   0.844 us |   1.211 us |  0.05 |     72 KB |        0.10 |
| SingleTenant | 25            | 704.66 us |  18.792 us |  28.126 us |  1.00 | 748.25 KB |        1.00 |
| MultiTenant  | 25            | 760.19 us |  69.319 us | 101.607 us |  1.08 |    740 KB |        0.99 |
| GroupOnly    | 25            |  56.13 us |   2.303 us |   3.303 us |  0.08 |  74.36 KB |        0.10 |

Reading these numbers:

The baseline is not flat - 864, 740, 705 us for identical work - so anything below roughly 20% at
this scale is noise. The 864 us row is the first benchmark executed and carries an error of 175 us.
Treat the SingleTenant against MultiTenant comparison as directional only.

Routing does not cost more per Activity. If anything it is slightly cheaper at one to three
endpoints, which is explainable rather than surprising: the routed path skips the resource metric
envelope and the schema type counter that the single-tenant path emits. Allocations differ by about
1%, which is the same story.

Grouping is where the endpoint count actually shows. GroupOnly is flat from 1 to 3 endpoints and
then rises by roughly half at 25, with tight error bars, which is the ordinal linear scan in
EndpointRouteBatch.GetOrAdd behaving exactly as its comment predicts. Allocation stays flat
(72 to 74 KB), so the pooling holds.

Even so, grouping at 25 endpoints is about 56 us against roughly 700 us of conversion, so under a
tenth of the export. Replacing the scan with a dictionary would recover a fraction of that while
adding an allocation to the one-to-three endpoint case that every deployment pays, so the current
design is the right trade at the supported scale. The partition cap is 64; the scan cost grows
linearly, so 64 endpoints would be around 2.5 times the 25-endpoint figure, and that is the point
at which this is worth revisiting.
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

        private Batch<Activity> _batch;
        private EndpointRouteBatch _routeBatch = null!;

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
            _routeBatch = new EndpointRouteBatch();
            _batch = CreateBatch(BatchSize, EndpointCount);
        }

        [Benchmark(Baseline = true)]
        public int SingleTenant()
        {
            var (telemetryItems, _) = TraceHelper.OtelToAzureMonitorTrace(
                _batch,
                s_resource,
                InstrumentationKey,
                sampleRate: 100F);

            return telemetryItems.Count;
        }

        [Benchmark]
        public int MultiTenant()
        {
            _routeBatch.Reset();

            TraceHelper.OtelToAzureMonitorTraceMultiTenant(
                _batch,
                s_resource,
                sampleRate: 100F,
                _routeBatch);

            return _routeBatch.Count;
        }

        /// <summary>
        /// Grouping on its own, with no conversion, so the linear scan is not hidden behind the
        /// per-Activity conversion cost.
        /// </summary>
        [Benchmark]
        public int GroupOnly()
        {
            _routeBatch.Reset();

            for (int i = 0; i < BatchSize; i++)
            {
                _routeBatch.GetOrAdd(EndpointFor(i % EndpointCount));
            }

            return _routeBatch.Count;
        }

        private static string EndpointFor(int index)
            => string.Format(CultureInfo.InvariantCulture, "https://region{0}.in.applicationinsights.azure.com/", index);

        private static Batch<Activity> CreateBatch(int size, int endpointCount)
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

                    // The routing contract. On the single-tenant path these are not recognized and
                    // simply become custom dimensions, which is what makes the baseline comparable.
                    [SemanticConventions.AttributeMicrosoftInstrumentationKey] = InstrumentationKey,
                    [SemanticConventions.AttributeMicrosoftIngestionEndpoint] = EndpointFor(i % endpointCount),
                };

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

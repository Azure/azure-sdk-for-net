// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;

using BenchmarkDotNet.Attributes;

/*
BenchmarkDotNet=v0.13.4, OS=Windows 11 (10.0.22621.1702)
Intel Core i7-8850H CPU 2.60GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.203
  [Host]     : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2


|                          Method |     Mean |   Error |  StdDev | Allocated |
|-------------------------------- |---------:|--------:|--------:|----------:|
| Benchmark_ActivityTagsProcessor | 262.0 ns | 2.51 ns | 2.10 ns |         - |
*/

/*
Baseline before the AzMonList/ActivityTagsProcessor rework, widened past the original
6-tag case because scan cost is O(k*n) in the tag count.

NOTE: ShortRun (3 iterations) - Error is wide. Allocated shows "-" because the buffers
come from ArrayPool, which MemoryDiagnoser does not count. Pool rents are not visible here.

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.9106/25H2/2025Update/HudsonValley2) (Hyper-V)
Intel Xeon Platinum 8370C CPU 2.80GHz (Max: 2.79GHz), 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.400
  [Host]   : .NET 8.0.30 (8.0.30, 8.0.3026.36720), X64 RyuJIT x86-64-v4
  ShortRun : .NET 8.0.30 (8.0.30, 8.0.3026.36720), X64 RyuJIT x86-64-v4

Job=ShortRun  IterationCount=3  LaunchCount=1  WarmupCount=3

| Method                                 | Mean       | Error     | StdDev  | Allocated |
|--------------------------------------- |-----------:|----------:|--------:|----------:|
| Benchmark_ActivityTagsProcessor        |   189.1 ns |  50.83 ns | 2.79 ns |         - |
| Benchmark_ActivityTagsProcessor_15Tags |   354.9 ns | 154.99 ns | 8.50 ns |         - |
| Benchmark_ActivityTagsProcessor_50Tags | 1,019.7 ns | 133.01 ns | 7.29 ns |         - |
*/

/*
After the AzMonList pooling fixes. The used region of each buffer is now zeroed before it
goes back to the shared pool, which costs 6-16% here. That cost is real but this benchmark
exaggerates it: CategorizeTags is roughly 200 ns of a ~1550 ns full conversion, so the
same change is within noise in ActivityConversionBenchmarks. The 50-tag case is worst
because each array growth also clears the buffer it hands back.

| Method                                 | Mean       | Error     | StdDev   | Allocated |
|--------------------------------------- |-----------:|----------:|---------:|----------:|
| Benchmark_ActivityTagsProcessor        |   201.3 ns |  46.34 ns |  2.54 ns |         - |
| Benchmark_ActivityTagsProcessor_15Tags |   383.1 ns | 110.98 ns |  6.08 ns |         - |
| Benchmark_ActivityTagsProcessor_50Tags | 1,188.1 ns | 251.37 ns | 13.78 ns |         - |
*/

/*
After the slot index, the mapped-only mode, and storing recognized attributes in the slot
array only.

An earlier revision also appended every recognized attribute to the list buffer, which cost
a third pooled buffer per activity and pushed the 15-tag case to 537.8 ns. Recognized
attributes are now held in the slot array alone, so a mapped list rents one buffer instead
of two and categorizing is back to where it was before the slot index was introduced, while
reads stay constant time.

MappedOnly is what the standard-metrics path uses. It skips the unmapped list entirely,
avoiding a pooled buffer and the string conversion of array-valued tags.

| Method                                            | Mean       | Error     | StdDev   | Allocated |
|-------------------------------------------------- |-----------:|----------:|---------:|----------:|
| Benchmark_ActivityTagsProcessor                   |   210.1 ns |  22.30 ns |  1.22 ns |         - |
| Benchmark_ActivityTagsProcessor_15Tags            |   391.1 ns |  58.24 ns |  3.19 ns |         - |
| Benchmark_ActivityTagsProcessor_50Tags            | 1,192.4 ns | 190.02 ns | 10.42 ns |         - |
| Benchmark_ActivityTagsProcessor_15Tags_MappedOnly |   321.9 ns |  21.02 ns |  1.15 ns |         - |
| Benchmark_ActivityTagsProcessor_50Tags_MappedOnly |   819.8 ns | 143.91 ns |  7.89 ns |         - |
*/

namespace Azure.Monitor.OpenTelemetry.Exporter.Benchmarks
{
    [MemoryDiagnoser]
    public class ActivityTagsProcessorBenchmarks
    {
        private Activity? _activity;
        private Activity? _activityRealistic;
        private Activity? _activityStress;

        static ActivityTagsProcessorBenchmarks()
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
            IEnumerable<KeyValuePair<string, object?>> tagObjects = new Dictionary<string, object?>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpMethod] = "GET",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                ["somekey"] = "value",
                [SemanticConventions.AttributeAzureNameSpace] = "DemoAzureResource",
                [SemanticConventions.AttributeEnduserId] = "test"
            };

            _activity = CreateTestActivity(tagObjects!);
            _activityRealistic = CreateTestActivity(CreateTags(mappedCount: 10, unmappedCount: 5)!);
            _activityStress = CreateTestActivity(CreateTags(mappedCount: 20, unmappedCount: 30)!);
        }

        [Benchmark]
        public void Benchmark_ActivityTagsProcessor()
        {
            var activityTagsProcessor = new ActivityTagsProcessor();
            activityTagsProcessor.CategorizeTags(_activity!);
            activityTagsProcessor.Return();
        }

        [Benchmark]
        public void Benchmark_ActivityTagsProcessor_15Tags()
        {
            var activityTagsProcessor = new ActivityTagsProcessor();
            activityTagsProcessor.CategorizeTags(_activityRealistic!);
            activityTagsProcessor.Return();
        }

        [Benchmark]
        public void Benchmark_ActivityTagsProcessor_50Tags()
        {
            var activityTagsProcessor = new ActivityTagsProcessor();
            activityTagsProcessor.CategorizeTags(_activityStress!);
            activityTagsProcessor.Return();
        }

        // What the standard-metrics path now does: mapped tags only.
        [Benchmark]
        public void Benchmark_ActivityTagsProcessor_15Tags_MappedOnly()
        {
            var activityTagsProcessor = new ActivityTagsProcessor(includeUnmappedTags: false);
            activityTagsProcessor.CategorizeTags(_activityRealistic!);
            activityTagsProcessor.Return();
        }

        [Benchmark]
        public void Benchmark_ActivityTagsProcessor_50Tags_MappedOnly()
        {
            var activityTagsProcessor = new ActivityTagsProcessor(includeUnmappedTags: false);
            activityTagsProcessor.CategorizeTags(_activityStress!);
            activityTagsProcessor.Return();
        }

        // Scan cost of the current design is O(k*n) in the mapped-tag count, so the mapped
        // and unmapped halves are grown independently.
        private static Dictionary<string, object?> CreateTags(int mappedCount, int unmappedCount)
        {
            string[] mappedKeys =
            {
                SemanticConventions.AttributeHttpRequestMethod,
                SemanticConventions.AttributeHttpResponseStatusCode,
                SemanticConventions.AttributeUrlScheme,
                SemanticConventions.AttributeUrlPath,
                SemanticConventions.AttributeUrlQuery,
                SemanticConventions.AttributeUrlFull,
                SemanticConventions.AttributeServerAddress,
                SemanticConventions.AttributeServerPort,
                SemanticConventions.AttributeHttpRoute,
                SemanticConventions.AttributeUserAgentOriginal,
                SemanticConventions.AttributeClientAddress,
                SemanticConventions.AttributePeerService,
                SemanticConventions.AttributeNetPeerName,
                SemanticConventions.AttributeNetPeerIp,
                SemanticConventions.AttributeNetPeerPort,
                SemanticConventions.AttributeDbStatement,
                SemanticConventions.AttributeDbSystem,
                SemanticConventions.AttributeDbName,
                SemanticConventions.AttributeMessagingSystem,
                SemanticConventions.AttributeMessagingDestinationName,
            };

            if (mappedCount > mappedKeys.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(mappedCount));
            }

            var tags = new Dictionary<string, object?>();

            for (int i = 0; i < mappedCount; i++)
            {
                tags[mappedKeys[i]] = "value";
            }

            for (int i = 0; i < unmappedCount; i++)
            {
                tags[$"custom.key{i}"] = "value";
            }

            return tags;
        }

        private static Activity? CreateTestActivity(IEnumerable<KeyValuePair<string, object>>? additionalAttributes = null)
        {
            var startTimestamp = DateTime.UtcNow;
            var endTimestamp = startTimestamp.AddSeconds(60);
            var eventTimestamp = DateTime.UtcNow;
            var traceId = ActivityTraceId.CreateRandom();

            var parentSpanId = ActivitySpanId.CreateRandom();

            Dictionary<string, object>? attributes = null;
            if (additionalAttributes != null)
            {
                attributes = new Dictionary<string, object>();
                foreach (var attribute in additionalAttributes)
                {
                    attributes.Add(attribute.Key, attribute.Value);
                }
            }

            var activitySource = new ActivitySource(nameof(CreateTestActivity));

            var activity = activitySource.StartActivity(
                "Name",
                ActivityKind.Server,
                parentContext: new ActivityContext(traceId, parentSpanId, ActivityTraceFlags.Recorded),
                attributes!,
                null,
                startTime: startTimestamp);

            activity?.SetEndTime(endTimestamp);
            activity?.Stop();

            return activity;
        }
    }
}

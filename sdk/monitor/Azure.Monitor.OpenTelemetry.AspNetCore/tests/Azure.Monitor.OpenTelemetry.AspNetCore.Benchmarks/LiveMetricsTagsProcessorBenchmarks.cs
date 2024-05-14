// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.AspNetCore.Internals;
using Azure.Monitor.OpenTelemetry.AspNetCore.LiveMetrics.DataCollection;
using Azure.Monitor.OpenTelemetry.AspNetCore.Models;
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

namespace Azure.Monitor.OpenTelemetry.Exporter.Benchmarks
{
    [MemoryDiagnoser]
    public class LiveMetricsTagsProcessorBenchmarks
    {
        private Activity? _activity;
        private RemoteDependency? remoteDependencyDocument;

        static LiveMetricsTagsProcessorBenchmarks()
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
            remoteDependencyDocument = new();
            IEnumerable<KeyValuePair<string, object?>> tagObjects = new Dictionary<string, object?>
            {
                ["http.request.method"] = "value1",
                ["http.response.status_code"] = 200,
                ["url.full"] = "value1",
                ["somekey1"] = "value1",
                ["somekey2"] = "value2",
                ["somekey3"] = "value3",
                ["somekey4"] = "value4",
                ["somekey5"] = "value5",
                ["somekey6"] = "value6",
                ["somekey7"] = "value7",
                ["somekey8"] = "value8",
                ["somekey9"] = "value9",
                ["somekey10"] = "value10"
            };

            _activity = CreateTestActivity(tagObjects!);
        }

        [Benchmark]
        public void Benchmark_ActivityTagsProcessor()
        {
            var activityTagsProcessor = new ActivityTagsProcessor();
            activityTagsProcessor.CategorizeTags(_activity!);
            activityTagsProcessor.Return();
        }

        [Benchmark]
        public void Benchmark_LiveMetricsTagsProcessor()
        {
            var liveMetricsTagsProcessor = new LiveMetricsTagsProcessor();
            liveMetricsTagsProcessor.CategorizeTagsAndAddProperties(_activity!, remoteDependencyDocument!);
            liveMetricsTagsProcessor.Return();
        }

        [Benchmark]
        public void Benchmark_DependencyOldDocument()
        {
            DocumentHelper.ConvertToOldDependencyDocument(_activity!);
        }

        [Benchmark]
        public void Benchmark_DependencyDocument()
        {
            DocumentHelper.ConvertToDependencyDocument(_activity!);
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

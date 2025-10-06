// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.DataCollection;
using BenchmarkDotNet.Attributes;

/*
BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3447/23H2/2023Update/SunValley3) (Hyper-V)
AMD EPYC 7763, 1 CPU, 16 logical and 8 physical cores
.NET SDK 7.0.408
  [Host]     : .NET 7.0.18 (7.0.1824.16914), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.18 (7.0.1824.16914), X64 RyuJIT AVX2


| Method                          | Mean     | Error   | StdDev  | Gen0   | Allocated |
|-------------------------------- |---------:|--------:|--------:|-------:|----------:|
| Benchmark_DependencyDocument    | 598.2 ns | 1.93 ns | 1.50 ns | 0.0505 |     856 B |
*/

namespace Azure.Monitor.OpenTelemetry.Exporter.Benchmarks
{
    [MemoryDiagnoser]
    public class LiveMetricsTagsProcessorBenchmarks
    {
        private Activity? _activity;

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

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;

using BenchmarkDotNet.Attributes;

/*
BenchmarkDotNet=v0.13.4, OS=Windows 11 (10.0.22621.1778)
Intel Core i7-8650U CPU 1.90GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.105
  [Host] : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=InProcess  Toolchain=InProcessEmitToolchain

|                              Method    |     Mean |   Error |   StdDev |   Median |   Gen0 | Allocated |
|--------------------------------------- |---------:|--------:|---------:|---------:|-------:|----------:|
|     Benchmark_ActivityTagsProcessor    | 282.5 ns | 5.61 ns | 13.66 ns | 279.0 ns | 0.1335 |     560 B |
*/

namespace Azure.Monitor.OpenTelemetry.Exporter.Benchmarks
{
    [MemoryDiagnoser]
    public class ActivityTagsProcessorBenchmarks
    {
        private Activity? _activity;

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
        }

        [Benchmark]
        public void Benchmark_ActivityTagsProcessor()
        {
            var activityTagsProcessor = new ActivityTagsProcessor();
            activityTagsProcessor.CategorizeTags(_activity!);
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

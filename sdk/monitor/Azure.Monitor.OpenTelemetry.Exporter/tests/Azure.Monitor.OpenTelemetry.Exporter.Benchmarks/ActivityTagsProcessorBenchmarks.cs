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


|                             Method |     Mean |   Error |  StdDev |   Gen0 | Allocated |
|----------------------------------- |---------:|--------:|--------:|-------:|----------:|
|    Benchmark_ActivityTagsProcessor | 274.7 ns | 5.29 ns | 6.09 ns | 0.1187 |     560 B |
| Benchmark_ActivityTagsProcessorNew | 189.9 ns | 3.25 ns | 2.88 ns | 0.0594 |     280 B |
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
                ["key1"] = "value1",
                ["key2"] = "value2",
                ["key3"] = "value3",
                ["key4"] = "value4",
                ["key5"] = "value5",
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

        [Benchmark]
        public void Benchmark_ActivityTagsProcessorNew()
        {
            var activityTagsProcessor = new ActivityTagsProcessorNew();
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

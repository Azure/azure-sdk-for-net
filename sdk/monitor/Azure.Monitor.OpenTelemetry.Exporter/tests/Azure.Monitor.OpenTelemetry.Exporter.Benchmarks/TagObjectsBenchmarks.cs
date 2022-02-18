// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;

/*
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-8650U CPU 1.90GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.102
  [Host]     : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT
  DefaultJob : .NET 6.0.2 (6.0.222.6406), X64 RyuJIT


|                           Method |     Mean |    Error |   StdDev |  Gen 0 | Allocated |
|--------------------------------- |---------:|---------:|---------:|-------:|----------:|
|      Enumerate_TagObjects_NoItem | 205.4 ns |  8.56 ns | 24.71 ns |      - |         - |
|       Enumerate_TagObjects_PartB | 530.1 ns | 16.31 ns | 47.31 ns | 0.0191 |      80 B |
|       Enumerate_TagObjects_PartC | 856.6 ns | 25.41 ns | 74.54 ns | 0.0763 |     320 B |
| Enumerate_TagObjects_PartB_And_C | 510.5 ns | 11.70 ns | 33.94 ns | 0.0191 |      80 B |
*/

namespace Azure.Monitor.OpenTelemetry.Exporter.Benchmarks
{
    [MemoryDiagnoser]
    public class TagObjectsBenchmarks
    {
        private IEnumerable<KeyValuePair<string, object>> _partB_tagObjects;
        private IEnumerable<KeyValuePair<string, object>> _partC_tagObjects;
        private IEnumerable<KeyValuePair<string, object>> _partB_And_C_tagObjects;
        private Activity _noItemActivity;
        private Activity _partBActivity;
        private Activity _partCActivity;
        private Activity _partBAndCActivity;

        static TagObjectsBenchmarks()
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
            _noItemActivity = CreateTestActivity();

            _partB_tagObjects = new Dictionary<string, object>
            {
                [SemanticConventions.AttributeNetHostIp] = "127.0.0.1",
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "8888",
            };

            _partBActivity = CreateTestActivity(_partB_tagObjects);

            _partC_tagObjects = new Dictionary<string, object>
            {
                ["intKey"] = 1,
                ["doubleKey"] = 1.1,
                ["stringKey"] = "test",
                ["boolKey"] = true,
                ["arrayKey"] = new int[] { 1, 2, 3 }
            };

            _partCActivity = CreateTestActivity(_partC_tagObjects);

            _partB_And_C_tagObjects = new Dictionary<string, object>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "8888",
                ["somekey"] = "value"
            };

            _partBAndCActivity = CreateTestActivity(_partB_And_C_tagObjects);
        }

        [GlobalCleanup]
        public void Cleanup()
        {
        }

        [Benchmark]
        public void Enumerate_TagObjects_NoItem()
        {
            var monitorTags = TraceHelper.EnumerateActivityTags(_noItemActivity);
            monitorTags.Return();
        }

        [Benchmark]
        public void Enumerate_TagObjects_PartB()
        {
            var monitorTags = TraceHelper.EnumerateActivityTags(_partBActivity);
            monitorTags.Return();
        }

        [Benchmark]
        public void Enumerate_TagObjects_PartC()
        {
            var monitorTags = TraceHelper.EnumerateActivityTags(_partCActivity);
            monitorTags.Return();
        }

        [Benchmark]
        public void Enumerate_TagObjects_PartB_And_C()
        {
            var monitorTags = TraceHelper.EnumerateActivityTags(_partBAndCActivity);
            monitorTags.Return();
        }

        private static Activity CreateTestActivity(IEnumerable<KeyValuePair<string, object>> additionalAttributes = null)
        {
            var startTimestamp = DateTime.UtcNow;
            var endTimestamp = startTimestamp.AddSeconds(60);
            var eventTimestamp = DateTime.UtcNow;
            var traceId = ActivityTraceId.CreateRandom();

            var parentSpanId = ActivitySpanId.CreateRandom();

            Dictionary<string, object> attributes = null;
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
                attributes,
                null,
                startTime: startTimestamp);

            activity.SetEndTime(endTimestamp);
            activity.Stop();

            return activity;
        }
    }
}

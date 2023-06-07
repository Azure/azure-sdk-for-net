// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Azure.Core;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;

using BenchmarkDotNet.Attributes;

/*
BenchmarkDotNet=v0.13.4, OS=Windows 11 (10.0.22621.1702)
Intel Core i7-8850H CPU 2.60GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.203
  [Host]     : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2


|                                         Method |     Mean |   Error |  StdDev | Allocated |
|----------------------------------------------- |---------:|--------:|--------:|----------:|
|    ProcessUnMappedTagsWithActivityTagProcessor | 101.4 ns | 0.69 ns | 0.65 ns |         - |
| ProcessUnMappedTagsWithoutActivityTagProcessor | 211.2 ns | 3.18 ns | 2.65 ns |         - |
*/
namespace Azure.Monitor.OpenTelemetry.Exporter.Benchmarks
{
    [MemoryDiagnoser]
    public class ProcessUnMappedTagsBenchmarks
    {
        private Activity? _activity;
        private ChangeTrackingDictionary<string, string>? _properties;
        private ActivityTagsProcessor _tagsProcessor;

        static ProcessUnMappedTagsBenchmarks()
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

        [GlobalSetup(Target = nameof(ProcessUnMappedTagsWithActivityTagProcessor))]
        public void SetupWithActivityTagProcessor()
        {
            IEnumerable<KeyValuePair<string, object?>> tagObjects = new Dictionary<string, object?>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpMethod] = "GET",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeAzureNameSpace] = "DemoAzureResource",
                [SemanticConventions.AttributeEnduserId] = "test",
                ["key1"] = "value1",
                ["key2"] = "value2",
                ["key3"] = "value3",
                ["key4"] = "value4",
                ["key5"] = "value5",
            };

            _activity = CreateTestActivity(tagObjects!);

            _properties = new ChangeTrackingDictionary<string, string>();

            _tagsProcessor = new ActivityTagsProcessor();
            _tagsProcessor.CategorizeTags(_activity!);
        }

        [GlobalSetup(Target = nameof(ProcessUnMappedTagsWithoutActivityTagProcessor))]
        public void SetupWithoutActivityTagProcessor()
        {
            IEnumerable<KeyValuePair<string, object?>> tagObjects = new Dictionary<string, object?>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpMethod] = "GET",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeAzureNameSpace] = "DemoAzureResource",
                [SemanticConventions.AttributeEnduserId] = "test",
                ["key1"] = "value1",
                ["key2"] = "value2",
                ["key3"] = "value3",
                ["key4"] = "value4",
                ["key5"] = "value5",
            };

            _activity = CreateTestActivity(tagObjects!);

            _properties = new ChangeTrackingDictionary<string, string>();
        }

        [Benchmark]
        public void ProcessUnMappedTagsWithActivityTagProcessor()
        {
            _properties?.Clear();
            for (int i = 0; i < _tagsProcessor.UnMappedTags.Length; i++)
            {
                var tag = _tagsProcessor.UnMappedTags[i];
                _properties?.Add(tag.Key, tag.Value?.ToString() ?? "null");
            }
        }

        [Benchmark]
        public void ProcessUnMappedTagsWithoutActivityTagProcessor()
        {
            _properties?.Clear();
            foreach (ref readonly var tag in _activity!.EnumerateTagObjects())
            {
                if (ActivityTagsProcessorNew.s_semantics.Contains(tag.Key))
                {
                    continue;
                }
                else
                {
                    _properties?.Add(new KeyValuePair<string, string>(tag.Key, tag.Value?.ToString() ?? "null"));
                }
            }
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

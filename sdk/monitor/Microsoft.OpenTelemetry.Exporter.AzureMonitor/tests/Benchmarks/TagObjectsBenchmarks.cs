// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using BenchmarkDotNet.Attributes;
using OpenTelemetry.Trace;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor.Benchmarks
{
    [MemoryDiagnoser]
    public class TagObjectsBenchmarks
    {
        private TagEnumerationState monitorTags;
        private IEnumerable<KeyValuePair<string, object>> tagObjects;
        private IEnumerable<KeyValuePair<string, object>> PartB_tagObjects;
        private IEnumerable<KeyValuePair<string, object>> PartC_tagObjects;
        private IEnumerable<KeyValuePair<string, object>> PartB_And_C_tagObjects;
        private Activity NoItemActivity;
        private Activity PartBActivity;
        private Activity PartCActivity;
        private Activity PartBAndCActivity;

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
            monitorTags = new TagEnumerationState
            {
                PartBTags = AzMonList.Initialize(),
                PartCTags = AzMonList.Initialize()
            };

            tagObjects = new Dictionary<string, object>();
            NoItemActivity = CreateTestActivity();

            PartB_tagObjects = new Dictionary<string, object>
            {
                [SemanticConventions.AttributeNetHostIp] = "127.0.0.1",
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "8888",
            };

            PartBActivity = CreateTestActivity(PartB_tagObjects);

            PartC_tagObjects = new Dictionary<string, object>
            {
                ["intKey"] = 1,
                ["doubleKey"] = 1.1,
                ["stringKey"] = "test",
                ["boolKey"] = true,
                ["arrayKey"] = new int[] { 1, 2, 3 }
            };

            PartCActivity = CreateTestActivity(PartC_tagObjects);

            PartB_And_C_tagObjects = new Dictionary<string, object>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "8888",
                ["somekey"] = "value"
            };

            PartBAndCActivity = CreateTestActivity(PartB_And_C_tagObjects);
        }

        [GlobalCleanup]
        public void Cleanup()
        {
        }

        [Benchmark]
        public void Enumerate_AzMonList_NoItem()
        {
            NoItemActivity.EnumerateTags(ref monitorTags);
        }

        [Benchmark]
        public void Enumerate_AzMonList_Part_B()
        {
            PartBActivity.EnumerateTags(ref monitorTags);
        }

        [Benchmark]
        public void Enumerate_AzMonList_Part_C()
        {
            PartCActivity.EnumerateTags(ref monitorTags);
        }

        [Benchmark]
        public void Enumerate_AzMonList_PartB_And_C()
        {
            PartBAndCActivity.EnumerateTags(ref monitorTags);
        }

        [Benchmark]
        public void Enumerate_TagObjects_NoItem()
        {
            _ = tagObjects.ToAzureMonitorTags(out var _, out var _);
        }

        [Benchmark]
        public void Enumerate_TagObjects_PartB()
        {
            _ = PartB_tagObjects.ToAzureMonitorTags(out var _, out var _);
        }

        [Benchmark]
        public void Enumerate_TagObjects_PartC()
        {
            _ = PartC_tagObjects.ToAzureMonitorTags(out var _, out var _);
        }

        [Benchmark]
        public void Enumerate_TagObjects_PartB_And_C()
        {
            _ = PartB_And_C_tagObjects.ToAzureMonitorTags(out var _, out var _);
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

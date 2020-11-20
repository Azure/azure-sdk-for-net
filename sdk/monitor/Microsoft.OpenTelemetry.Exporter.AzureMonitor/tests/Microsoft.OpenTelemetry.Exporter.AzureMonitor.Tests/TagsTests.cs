// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry.Trace;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor.Tests
{
    public class TagsTests
    {
        static TagsTests()
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
        [Fact]
        public void TagObjects_NoItem()
        {
            var monitorTags = new TagEnumerationState
            {
                PartBTags = AzMonList.Initialize(),
                PartCTags = AzMonList.Initialize()
            };

            using var activity = CreateTestActivity();
            activity.EnumerateTags(ref monitorTags);

            Assert.Equal(PartBType.Unknown, monitorTags.activityType);
            Assert.Empty(monitorTags.PartBTags);
            Assert.Empty(monitorTags.PartCTags);
        }

        [Fact]
        public void TagObjects_Empty()
        {
            var monitorTags = new TagEnumerationState
            {
                PartBTags = AzMonList.Initialize(),
                PartCTags = AzMonList.Initialize()
            };

            using var activity = CreateTestActivity(new Dictionary<string, object>());
            activity.EnumerateTags(ref monitorTags);

            Assert.Equal(PartBType.Unknown, monitorTags.activityType);
            Assert.Empty(monitorTags.PartBTags);
            Assert.Empty(monitorTags.PartCTags);
        }

        [Fact]
        public void TagObjects_NullItem()
        {
            var monitorTags = new TagEnumerationState
            {
                PartBTags = AzMonList.Initialize(),
                PartCTags = AzMonList.Initialize()
            };

            IEnumerable<KeyValuePair<string, object>> tagObjects = new Dictionary<string, object>
            {
                ["key1"] = null,
                ["key2"] = new string[] { "test", null },
                ["key3"] = new string[] { null, null }
            };

            using var activity = CreateTestActivity(tagObjects);
            activity.EnumerateTags(ref monitorTags);

            Assert.Equal(PartBType.Unknown, monitorTags.activityType);
            Assert.Empty(monitorTags.PartBTags);
            Assert.Equal(2, monitorTags.PartCTags.Length);
            Assert.Null(AzMonList.GetTagValue(ref monitorTags.PartCTags, "key1"));
            Assert.Equal("test", AzMonList.GetTagValue(ref monitorTags.PartCTags, "key2"));
            Assert.Equal(string.Empty, AzMonList.GetTagValue(ref monitorTags.PartCTags, "key3"));
        }

        [Fact]
        public void TagObjects_PartC()
        {
            var monitorTags = new TagEnumerationState
            {
                PartBTags = AzMonList.Initialize(),
                PartCTags = AzMonList.Initialize()
            };

            IEnumerable<KeyValuePair<string, object>> tagObjects = new Dictionary<string, object> { ["somekey"] = "value" }; ;
            using var activity = CreateTestActivity(tagObjects);
            activity.EnumerateTags(ref monitorTags);

            Assert.Equal(PartBType.Unknown, monitorTags.activityType);
            Assert.Empty(monitorTags.PartBTags);
            Assert.Equal("value", AzMonList.GetTagValue(ref monitorTags.PartCTags, "somekey"));
        }

        [Fact]
        public void TagObjects_PartB()
        {
            var monitorTags = new TagEnumerationState
            {
                PartBTags = AzMonList.Initialize(),
                PartCTags = AzMonList.Initialize()
            };

            IEnumerable<KeyValuePair<string, object>> tagObjects = new Dictionary<string, object>
            {
                [SemanticConventions.AttributeNetHostIp] = "127.0.0.1",
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "8888",
                [SemanticConventions.AttributeRpcSystem] = "test"
            };

            using var activity = CreateTestActivity(tagObjects);
            activity.EnumerateTags(ref monitorTags);

            Assert.Equal(PartBType.Http, monitorTags.activityType);
            Assert.Equal(4, monitorTags.PartBTags.Length);
            Assert.Equal("https", AzMonList.GetTagValue(ref monitorTags.PartBTags, SemanticConventions.AttributeHttpScheme));
            Assert.Equal("localhost", AzMonList.GetTagValue(ref monitorTags.PartBTags, SemanticConventions.AttributeHttpHost));
            Assert.Equal("8888", AzMonList.GetTagValue(ref monitorTags.PartBTags, SemanticConventions.AttributeHttpHostPort));
            Assert.Equal("127.0.0.1", AzMonList.GetTagValue(ref monitorTags.PartBTags, SemanticConventions.AttributeNetHostIp));
            Assert.Single(monitorTags.PartCTags);
            Assert.Equal("test", AzMonList.GetTagValue(ref monitorTags.PartCTags, SemanticConventions.AttributeRpcSystem));
        }

        [Fact]
        public void TagObjects_PartB_PartC()
        {
            var monitorTags = new TagEnumerationState
            {
                PartBTags = AzMonList.Initialize(),
                PartCTags = AzMonList.Initialize()
            };

            IEnumerable<KeyValuePair<string, object>> tagObjects = new Dictionary<string, object>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "8888",
                ["somekey"] = "value"
            };

            using var activity = CreateTestActivity(tagObjects);
            activity.EnumerateTags(ref monitorTags);

            Assert.Equal(PartBType.Http, monitorTags.activityType);
            Assert.Equal(3, monitorTags.PartBTags.Length);
            Assert.Single(monitorTags.PartCTags);

            Assert.Equal("https", AzMonList.GetTagValue(ref monitorTags.PartBTags, SemanticConventions.AttributeHttpScheme));
            Assert.Equal("localhost", AzMonList.GetTagValue(ref monitorTags.PartBTags, SemanticConventions.AttributeHttpHost));
            Assert.Equal("8888", AzMonList.GetTagValue(ref monitorTags.PartBTags, SemanticConventions.AttributeHttpHostPort));

            Assert.Equal("value", AzMonList.GetTagValue(ref monitorTags.PartCTags, "somekey"));
        }

        [Fact]
        public void TagObjects_IntArray()
        {
            var monitorTags = new TagEnumerationState
            {
                PartBTags = AzMonList.Initialize(),
                PartCTags = AzMonList.Initialize()
            };

            IEnumerable<KeyValuePair<string, object>> tagObjects = new Dictionary<string, object>
            {
                ["intArray"] = new int[] { 1, 2, 3 },
            };

            using var activity = CreateTestActivity(tagObjects);
            activity.EnumerateTags(ref monitorTags);

            Assert.Equal(PartBType.Unknown, monitorTags.activityType);
            Assert.Empty(monitorTags.PartBTags);
            Assert.Single(monitorTags.PartCTags);

            Assert.Equal("1,2,3", AzMonList.GetTagValue(ref monitorTags.PartCTags, "intArray"));
        }

        [Fact]
        public void TagObjects_DoubleArray()
        {
            var monitorTags = new TagEnumerationState
            {
                PartBTags = AzMonList.Initialize(),
                PartCTags = AzMonList.Initialize()
            };

            IEnumerable<KeyValuePair<string, object>> tagObjects = new Dictionary<string, object>
            {
                ["doubleArray"] = new double[] { 1.1, 2.2, 3.3 },
            };

            using var activity = CreateTestActivity(tagObjects);
            activity.EnumerateTags(ref monitorTags);

            Assert.Equal(PartBType.Unknown, monitorTags.activityType);
            Assert.Empty(monitorTags.PartBTags);
            Assert.Single(monitorTags.PartCTags);

            Assert.Equal("1.1,2.2,3.3", AzMonList.GetTagValue(ref monitorTags.PartCTags, "doubleArray"));
        }

        [Fact]
        public void TagObjects_StringArray()
        {
            var monitorTags = new TagEnumerationState
            {
                PartBTags = AzMonList.Initialize(),
                PartCTags = AzMonList.Initialize()
            };

            IEnumerable<KeyValuePair<string, object>> tagObjects = new Dictionary<string, object>
            {
                ["strArray"] = new string[] { "test1", "test2", "test3" },
            };

            using var activity = CreateTestActivity(tagObjects);
            activity.EnumerateTags(ref monitorTags);

            Assert.Equal(PartBType.Unknown, monitorTags.activityType);
            Assert.Empty(monitorTags.PartBTags);
            Assert.Single(monitorTags.PartCTags);

            Assert.Equal("test1,test2,test3", AzMonList.GetTagValue(ref monitorTags.PartCTags, "strArray"));
        }

        [Fact]
        public void TagObjects_BooleanArray()
        {
            var monitorTags = new TagEnumerationState
            {
                PartBTags = AzMonList.Initialize(),
                PartCTags = AzMonList.Initialize()
            };

            IEnumerable<KeyValuePair<string, object>> tagObjects = new Dictionary<string, object>
            {
                ["boolArray"] = new bool[] { true, false, true },
            };

            using var activity = CreateTestActivity(tagObjects);
            activity.EnumerateTags(ref monitorTags);

            Assert.Equal(PartBType.Unknown, monitorTags.activityType);
            Assert.Empty(monitorTags.PartBTags);
            Assert.Single(monitorTags.PartCTags);

            Assert.Equal("True,False,True", AzMonList.GetTagValue(ref monitorTags.PartCTags, "boolArray"));
        }

        [Fact]
        public void TagObjects_ObjectArray()
        {
            var monitorTags = new TagEnumerationState
            {
                PartBTags = AzMonList.Initialize(),
                PartCTags = AzMonList.Initialize()
            };

            IEnumerable<KeyValuePair<string, object>> tagObjects = new Dictionary<string, object>
            {
                ["objArray"] = new Test[] { new Test(), new Test(), new Test() { TestProperty = 0 } },
            };

            using var activity = CreateTestActivity(tagObjects);
            activity.EnumerateTags(ref monitorTags);

            Assert.Equal(PartBType.Unknown, monitorTags.activityType);
            Assert.Empty(monitorTags.PartBTags);
            Assert.Single(monitorTags.PartCTags);

            Assert.Equal("Microsoft.OpenTelemetry.Exporter.AzureMonitor.Tests.TagsTests+Test,Microsoft.OpenTelemetry.Exporter.AzureMonitor.Tests.TagsTests+Test,Microsoft.OpenTelemetry.Exporter.AzureMonitor.Tests.TagsTests+Test", AzMonList.GetTagValue(ref monitorTags.PartCTags, "objArray"));
        }

        [Fact]
        public void TagObjects_Diff_DataTypes()
        {
            var monitorTags = new TagEnumerationState
            {
                PartBTags = AzMonList.Initialize(),
                PartCTags = AzMonList.Initialize()
            };

            IEnumerable<KeyValuePair<string, object>> tagObjects = new Dictionary<string, object>
            {
                ["intKey"] = 1,
                ["doubleKey"] = 1.1,
                ["stringKey"] = "test",
                ["boolKey"] = true,
                ["objectKey"] = new Test(),
                ["arrayKey"] = new int[] { 1, 2, 3 }
            };

            using var activity = CreateTestActivity(tagObjects);
            activity.EnumerateTags(ref monitorTags);

            Assert.Equal(PartBType.Unknown, monitorTags.activityType);
            Assert.Empty(monitorTags.PartBTags);
            Assert.Equal(6, monitorTags.PartCTags.Length);

            Assert.Equal(1, AzMonList.GetTagValue(ref monitorTags.PartCTags, "intKey"));
            Assert.Equal(1.1, AzMonList.GetTagValue(ref monitorTags.PartCTags, "doubleKey"));
            Assert.Equal("test", AzMonList.GetTagValue(ref monitorTags.PartCTags, "stringKey"));
            Assert.Equal(true, AzMonList.GetTagValue(ref monitorTags.PartCTags, "boolKey"));
            Assert.Equal("Microsoft.OpenTelemetry.Exporter.AzureMonitor.Tests.TagsTests+Test", AzMonList.GetTagValue(ref monitorTags.PartCTags, "objectKey").ToString());
            Assert.Equal("1,2,3", AzMonList.GetTagValue(ref monitorTags.PartCTags, "arrayKey"));
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

        private class Test
        {
            public int TestProperty { get; set; }
        }
    }
}

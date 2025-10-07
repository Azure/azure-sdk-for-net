// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
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
            var activityTagsProcessor = new ActivityTagsProcessor();

            using var activity = CreateTestActivity();
            activityTagsProcessor.CategorizeTags(activity);

            Assert.Equal(OperationType.Unknown, activityTagsProcessor.activityType);
            Assert.Empty(activityTagsProcessor.MappedTags);
            Assert.Empty(activityTagsProcessor.UnMappedTags);
        }

        [Fact]
        public void TagObjects_Empty()
        {
            var activityTagsProcessor = new ActivityTagsProcessor();

            using var activity = CreateTestActivity(new Dictionary<string, object?>());
            activityTagsProcessor.CategorizeTags(activity);

            Assert.Equal(OperationType.Unknown, activityTagsProcessor.activityType);
            Assert.Empty(activityTagsProcessor.MappedTags);
            Assert.Empty(activityTagsProcessor.UnMappedTags);
        }

        [Fact]
        public void TagObjects_NullItem()
        {
            var activityTagsProcessor = new ActivityTagsProcessor();

            IEnumerable<KeyValuePair<string, object?>> tagObjects = new Dictionary<string, object?>
            {
                ["key1"] = null,
                ["key2"] = new string?[] { "test", null },
                ["key3"] = new string?[] { null, null }
            };

            using var activity = CreateTestActivity(tagObjects);
            activityTagsProcessor.CategorizeTags(activity);

            Assert.Equal(OperationType.Unknown, activityTagsProcessor.activityType);
            Assert.Empty(activityTagsProcessor.MappedTags);
            Assert.Equal(2, activityTagsProcessor.UnMappedTags.Length);
            Assert.Null(AzMonList.GetTagValue(ref activityTagsProcessor.UnMappedTags, "key1"));
            Assert.Equal("test", AzMonList.GetTagValue(ref activityTagsProcessor.UnMappedTags, "key2"));
            Assert.Equal(string.Empty, AzMonList.GetTagValue(ref activityTagsProcessor.UnMappedTags, "key3"));
        }

        [Fact]
        public void TagObjects_UnMapped()
        {
            var activityTagsProcessor = new ActivityTagsProcessor();

            IEnumerable<KeyValuePair<string, object?>> tagObjects = new Dictionary<string, object?> { ["somekey"] = "value" };
            using var activity = CreateTestActivity(tagObjects);
            activityTagsProcessor.CategorizeTags(activity);

            Assert.Equal(OperationType.Unknown, activityTagsProcessor.activityType);
            Assert.Empty(activityTagsProcessor.MappedTags);
            Assert.Equal("value", AzMonList.GetTagValue(ref activityTagsProcessor.UnMappedTags, "somekey"));
        }

        [Fact]
        public void TagObjects_Mapped()
        {
            var activityTagsProcessor = new ActivityTagsProcessor();

            IEnumerable<KeyValuePair<string, object?>> tagObjects = new Dictionary<string, object?>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpMethod] = "GET",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "8888",
            };

            using var activity = CreateTestActivity(tagObjects);
            activityTagsProcessor.CategorizeTags(activity);

            Assert.Equal(OperationType.Http, activityTagsProcessor.activityType);
            Assert.Equal(4, activityTagsProcessor.MappedTags.Length);
            Assert.Equal("https", AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeHttpScheme));
            Assert.Equal("GET", AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeHttpMethod));
            Assert.Equal("localhost", AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeHttpHost));
            Assert.Equal("8888", AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeHttpHostPort));
        }

        [Fact]
        public void TagObjects_Mapped_HonorsNewHTTPSchema()
        {
            var activityTagsProcessor = new ActivityTagsProcessor();

            IEnumerable<KeyValuePair<string, object?>> tagObjects = new Dictionary<string, object?>
            {
                [SemanticConventions.AttributeUrlScheme] = "https",
                [SemanticConventions.AttributeHttpRequestMethod] = "GET",
                [SemanticConventions.AttributeServerAddress] = "localhost",
                [SemanticConventions.AttributeServerPort] = "8888",
                [SemanticConventions.AttributeUrlPath] = "/test"
            };

            using var activity = CreateTestActivity(tagObjects);
            activityTagsProcessor.CategorizeTags(activity);

            Assert.Equal(OperationType.Http | OperationType.V2, activityTagsProcessor.activityType);
            Assert.Equal(5, activityTagsProcessor.MappedTags.Length);
            Assert.Equal("https", AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeUrlScheme));
            Assert.Equal("localhost", AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeServerAddress));
            Assert.Equal("8888", AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeServerPort));
            Assert.Equal("/test", AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeUrlPath));
        }

        [Fact]
        public void TagObjects_Mapped_HonorsNewDBSchema()
        {
            var activityTagsProcessor = new ActivityTagsProcessor();

            IEnumerable<KeyValuePair<string, object?>> tagObjects = new Dictionary<string, object?>
            {
                [SemanticConventions.AttributeDbNamespace] = "mysqlserver",
                [SemanticConventions.AttributeDbSystemName] = "mssql",
                [SemanticConventions.AttributePeerService] = "localhost",
                [SemanticConventions.AttributeDbQueryText] = "Select * from table",
            };

            using var activity = CreateTestActivity(tagObjects);
            activityTagsProcessor.CategorizeTags(activity);

            Assert.Equal(OperationType.Db | OperationType.V2, activityTagsProcessor.activityType);
            Assert.Equal(5, activityTagsProcessor.MappedTags.Length);
            Assert.Equal("mysqlserver", AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeDbNamespace));
            Assert.Equal("mssql", AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeDbSystemName));
            Assert.Equal("localhost", AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributePeerService));
            Assert.Equal("Select * from table", AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeDbQueryText));
        }

        [Fact]
        public void TagObjects_Mapped_UnMapped()
        {
            var activityTagsProcessor = new ActivityTagsProcessor();

            IEnumerable<KeyValuePair<string, object?>> tagObjects = new Dictionary<string, object?>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "8888",
                [SemanticConventions.AttributeHttpMethod] = "GET",
                ["somekey"] = "value"
            };

            using var activity = CreateTestActivity(tagObjects);
            activityTagsProcessor.CategorizeTags(activity);

            Assert.Equal(OperationType.Http, activityTagsProcessor.activityType);
            Assert.Equal(4, activityTagsProcessor.MappedTags.Length);
            Assert.Single(activityTagsProcessor.UnMappedTags);

            Assert.Equal("https", AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeHttpScheme));
            Assert.Equal("localhost", AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeHttpHost));
            Assert.Equal("8888", AzMonList.GetTagValue(ref activityTagsProcessor.MappedTags, SemanticConventions.AttributeHttpHostPort));

            Assert.Equal("value", AzMonList.GetTagValue(ref activityTagsProcessor.UnMappedTags, "somekey"));
        }

        [Fact]
        public void TagObjects_IntArray()
        {
            var activityTagsProcessor = new ActivityTagsProcessor();

            IEnumerable<KeyValuePair<string, object?>> tagObjects = new Dictionary<string, object?>
            {
                ["intArray"] = new int[] { 1, 2, 3 },
            };

            using var activity = CreateTestActivity(tagObjects);
            activityTagsProcessor.CategorizeTags(activity);

            Assert.Equal(OperationType.Unknown, activityTagsProcessor.activityType);
            Assert.Empty(activityTagsProcessor.MappedTags);
            Assert.Single(activityTagsProcessor.UnMappedTags);

            Assert.Equal("1,2,3", AzMonList.GetTagValue(ref activityTagsProcessor.UnMappedTags, "intArray"));
        }

        [Fact]
        public void TagObjects_DoubleArray()
        {
            var activityTagsProcessor = new ActivityTagsProcessor();

            IEnumerable<KeyValuePair<string, object?>> tagObjects = new Dictionary<string, object?>
            {
                ["doubleArray"] = new double[] { 1.1, 2.2, 3.3 },
            };

            using var activity = CreateTestActivity(tagObjects);
            activityTagsProcessor.CategorizeTags(activity);

            Assert.Equal(OperationType.Unknown, activityTagsProcessor.activityType);
            Assert.Empty(activityTagsProcessor.MappedTags);
            Assert.Single(activityTagsProcessor.UnMappedTags);

            Assert.Equal("1.1,2.2,3.3", AzMonList.GetTagValue(ref activityTagsProcessor.UnMappedTags, "doubleArray"));
        }

        [Fact]
        public void TagObjects_StringArray()
        {
            var activityTagsProcessor = new ActivityTagsProcessor();

            IEnumerable<KeyValuePair<string, object?>> tagObjects = new Dictionary<string, object?>
            {
                ["strArray"] = new string[] { "test1", "test2", "test3" },
            };

            using var activity = CreateTestActivity(tagObjects);
            activityTagsProcessor.CategorizeTags(activity);

            Assert.Equal(OperationType.Unknown, activityTagsProcessor.activityType);
            Assert.Empty(activityTagsProcessor.MappedTags);
            Assert.Single(activityTagsProcessor.UnMappedTags);

            Assert.Equal("test1,test2,test3", AzMonList.GetTagValue(ref activityTagsProcessor.UnMappedTags, "strArray"));
        }

        [Fact]
        public void TagObjects_BooleanArray()
        {
            var activityTagsProcessor = new ActivityTagsProcessor();

            IEnumerable<KeyValuePair<string, object?>> tagObjects = new Dictionary<string, object?>
            {
                ["boolArray"] = new bool[] { true, false, true },
            };

            using var activity = CreateTestActivity(tagObjects);
            activityTagsProcessor.CategorizeTags(activity);

            Assert.Equal(OperationType.Unknown, activityTagsProcessor.activityType);
            Assert.Empty(activityTagsProcessor.MappedTags);
            Assert.Single(activityTagsProcessor.UnMappedTags);

            Assert.Equal("True,False,True", AzMonList.GetTagValue(ref activityTagsProcessor.UnMappedTags, "boolArray"));
        }

        [Fact]
        public void TagObjects_ObjectArray()
        {
            var activityTagsProcessor = new ActivityTagsProcessor();

            IEnumerable<KeyValuePair<string, object?>> tagObjects = new Dictionary<string, object?>
            {
                ["objArray"] = new Test[] { new Test(), new Test(), new Test() { TestProperty = 0 } },
            };

            using var activity = CreateTestActivity(tagObjects);
            activityTagsProcessor.CategorizeTags(activity);

            Assert.Equal(OperationType.Unknown, activityTagsProcessor.activityType);
            Assert.Empty(activityTagsProcessor.MappedTags);
            Assert.Single(activityTagsProcessor.UnMappedTags);

            Assert.Equal("Azure.Monitor.OpenTelemetry.Exporter.Tests.TagsTests+Test,Azure.Monitor.OpenTelemetry.Exporter.Tests.TagsTests+Test,Azure.Monitor.OpenTelemetry.Exporter.Tests.TagsTests+Test", AzMonList.GetTagValue(ref activityTagsProcessor.UnMappedTags, "objArray"));
        }

        [Fact]
        public void TagObjects_Diff_DataTypes()
        {
            var activityTagsProcessor = new ActivityTagsProcessor();

            IEnumerable<KeyValuePair<string, object?>> tagObjects = new Dictionary<string, object?>
            {
                ["intKey"] = 1,
                ["doubleKey"] = 1.1,
                ["stringKey"] = "test",
                ["boolKey"] = true,
                ["objectKey"] = new Test(),
                ["arrayKey"] = new int[] { 1, 2, 3 }
            };

            using var activity = CreateTestActivity(tagObjects);
            activityTagsProcessor.CategorizeTags(activity);

            Assert.Equal(OperationType.Unknown, activityTagsProcessor.activityType);
            Assert.Empty(activityTagsProcessor.MappedTags);
            Assert.Equal(6, activityTagsProcessor.UnMappedTags.Length);

            Assert.Equal(1, AzMonList.GetTagValue(ref activityTagsProcessor.UnMappedTags, "intKey"));
            Assert.Equal(1.1, AzMonList.GetTagValue(ref activityTagsProcessor.UnMappedTags, "doubleKey"));
            Assert.Equal("test", AzMonList.GetTagValue(ref activityTagsProcessor.UnMappedTags, "stringKey"));
            Assert.Equal(true, AzMonList.GetTagValue(ref activityTagsProcessor.UnMappedTags, "boolKey"));
            Assert.Equal("Azure.Monitor.OpenTelemetry.Exporter.Tests.TagsTests+Test", AzMonList.GetTagValue(ref activityTagsProcessor.UnMappedTags, "objectKey")?.ToString());
            Assert.Equal("1,2,3", AzMonList.GetTagValue(ref activityTagsProcessor.UnMappedTags, "arrayKey"));
        }

        [Theory]
        [InlineData(ActivityKind.Client)]
        [InlineData(ActivityKind.Server)]
        public void ActivityTagsProcessor_CategorizeTags_ExtractsAzureNamespace(ActivityKind activityKind)
        {
            var activityTagsProcessor = new ActivityTagsProcessor();

            IEnumerable<KeyValuePair<string, object?>> tagObjects = new Dictionary<string, object?>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpMethod] = "GET",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "8888",
                ["somekey"] = "value",
                [SemanticConventions.AttributeAzureNameSpace] = "DemoAzureResource"
            };

            using var activity = CreateTestActivity(tagObjects, activityKind);
            activityTagsProcessor.CategorizeTags(activity);

            Assert.Equal("DemoAzureResource", activityTagsProcessor.AzureNamespace);
            Assert.Equal(OperationType.Http, activityTagsProcessor.activityType);

            Assert.Equal(5, activityTagsProcessor.MappedTags.Length);
            Assert.Equal(1, activityTagsProcessor.UnMappedTags.Length);
        }

        [Theory]
        [InlineData(ActivityKind.Client)]
        [InlineData(ActivityKind.Server)]
        public void ActivityTagsProcessor_CategorizeTags_ExtractsAuthUserId(ActivityKind activityKind)
        {
            var activityTagsProcessor = new ActivityTagsProcessor();

            IEnumerable<KeyValuePair<string, object?>> tagObjects = new Dictionary<string, object?>
            {
                [SemanticConventions.AttributeEnduserId] = "TestUser",
            };

            using var activity = CreateTestActivity(tagObjects, activityKind);
            activityTagsProcessor.CategorizeTags(activity);

            Assert.Equal("TestUser", activityTagsProcessor.EndUserId);
        }

        [Theory]
        [InlineData("fr-FR")] // French culture
        [InlineData("de-DE")] // German culture
        public void TagObjects_TestCulture(string cultureName)
        {
            var activityTagsProcessor = new ActivityTagsProcessor();
            var originalCulture = Thread.CurrentThread.CurrentCulture;
            var cultureInfo = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            IDictionary<string, string> properties = new Dictionary<string, string>();

            var doubleArray = new double[] { 1.1, 2.2, 3.3 };
            var doubleValue = 123.45;

            IEnumerable<KeyValuePair<string, object?>> tagObjects = new Dictionary<string, object?>
            {
                ["doubleArray"] = doubleArray,
                ["double"] = doubleValue,
            };

            using var activity = CreateTestActivity(tagObjects);
            activityTagsProcessor.CategorizeTags(activity);
            TraceHelper.AddPropertiesToTelemetry(properties, ref activityTagsProcessor.UnMappedTags);

            // Asserting Culture Behavior
            Assert.NotEqual("1.1,2.2,3.3", doubleArray.ToCommaDelimitedString(cultureInfo));
            Assert.NotEqual("123.45", doubleValue.ToString(cultureInfo));

            // Asserting CultureInvariant Behavior
            Assert.Equal("1.1,2.2,3.3", properties["doubleArray"]);
            Assert.Equal("123.45", properties["double"]);

            // Cleanup: Revert to the original culture
            Thread.CurrentThread.CurrentCulture = originalCulture;
        }

        [Fact]
        public void TagObjects_RpcTagsAreNotMapped()
        {
            /// As of today (2024-08-01), The RPC Semantic Convention is still Experimental.
            /// https://github.com/open-telemetry/semantic-conventions/blob/main/docs/rpc/rpc-spans.md
            /// We shouldn't have any special handling of these attributes until they are promoted to stable.
            /// Unmapped Tags should pass through to a telemetry item's custom properties.
            /// This test can be removed when the RPC Semantic Convention is promoted to stable.

            var activityTagsProcessor = new ActivityTagsProcessor();

            IEnumerable<KeyValuePair<string, object?>> tagObjects = new Dictionary<string, object?>
            {
                ["rpc.system"] = "test",
                ["rpc.grpc.status_code"] = "test",
                ["rpc.service"] = "test",
                ["rpc.method"] = "test",
            };

            using var activity = CreateTestActivity(tagObjects);
            activityTagsProcessor.CategorizeTags(activity);

            Assert.Equal(OperationType.Unknown, activityTagsProcessor.activityType);

            Assert.Equal(0, activityTagsProcessor.MappedTags.Length);
            Assert.Equal(4, activityTagsProcessor.UnMappedTags.Length);
        }

        private static Activity CreateTestActivity(IEnumerable<KeyValuePair<string, object?>>? additionalAttributes = null, ActivityKind activityKind = ActivityKind.Server)
        {
            var startTimestamp = DateTime.UtcNow;
            var endTimestamp = startTimestamp.AddSeconds(60);
            var eventTimestamp = DateTime.UtcNow;
            var traceId = ActivityTraceId.CreateRandom();

            var parentSpanId = ActivitySpanId.CreateRandom();

            Dictionary<string, object?>? attributes = null;
            if (additionalAttributes != null)
            {
                attributes = new Dictionary<string, object?>();
                foreach (var attribute in additionalAttributes)
                {
                    attributes.Add(attribute.Key, attribute.Value);
                }
            }

            var activitySource = new ActivitySource(nameof(CreateTestActivity));

            var activity = activitySource.StartActivity(
                "Name",
                activityKind,
                parentContext: new ActivityContext(traceId, parentSpanId, ActivityTraceFlags.Recorded),
                attributes,
                null,
                startTime: startTimestamp);

            activity?.SetEndTime(endTimestamp);
            activity?.Stop();

            return activity ?? throw new Exception("Failed to create Activity");
        }

        private class Test
        {
            public int TestProperty { get; set; }
        }
    }
}

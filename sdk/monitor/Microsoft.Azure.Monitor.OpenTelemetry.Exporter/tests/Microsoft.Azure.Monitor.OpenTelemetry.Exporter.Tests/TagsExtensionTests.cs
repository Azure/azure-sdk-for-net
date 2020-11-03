// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Monitor.OpenTelemetry.Exporter
{
    public class TagsExtensionTests
    {
        [Fact]
        public void TagObjects_NoItem()
        {
            IEnumerable<KeyValuePair<string, object>> tagObjects = null;
            var activityType = tagObjects.ToAzureMonitorTags(out var partBTags, out var PartCTags);

            Assert.Equal(PartBType.Unknown, activityType);
            Assert.Null(partBTags);
            Assert.Null(PartCTags);
        }

        [Fact]
        public void TagObjects_Empty()
        {
            IEnumerable<KeyValuePair<string, object>> tagObjects = new Dictionary<string, object>();
            var activityType = tagObjects.ToAzureMonitorTags(out var partBTags, out var PartCTags);

            Assert.Equal(PartBType.Unknown, activityType);
            Assert.Empty(partBTags);
            Assert.Empty(PartCTags);
        }

        [Fact]
        public void TagObjects_NullItem()
        {
            IEnumerable<KeyValuePair<string, object>> tagObjects = new Dictionary<string, object>
            {
                ["key1"] = null,
                ["key2"] = new string[] {"test", null},
                ["key3"] = new string[] { null, null }
            };
            var activityType = tagObjects.ToAzureMonitorTags(out var partBTags, out var PartCTags);

            Assert.Equal(PartBType.Unknown, activityType);
            Assert.Empty(partBTags);
            Assert.Equal(2, PartCTags.Count);
            Assert.Throws<KeyNotFoundException>(() => PartCTags["key1"]);
            Assert.Equal("test", PartCTags["key2"]);
            Assert.Equal(string.Empty, PartCTags["key3"]);
        }

        [Fact]
        public void TagObjects_PartC()
        {
            IEnumerable<KeyValuePair<string, object>> tagObjects = new Dictionary<string, object> { ["somekey"] = "value" };
            var activityType = tagObjects.ToAzureMonitorTags(out var partBTags, out var PartCTags);

            Assert.Equal(PartBType.Unknown, activityType);
            Assert.Empty(partBTags);
            Assert.Equal("value", PartCTags["somekey"]);
        }

        [Fact]
        public void TagObjects_PartB()
        {
            IEnumerable<KeyValuePair<string, object>> tagObjects = new Dictionary<string, object>
            {
                [SemanticConventions.AttributeNetHostIp] = "127.0.0.1",
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "8888",
                [SemanticConventions.AttributeRpcSystem] = "test"
            };

            var activityType = tagObjects.ToAzureMonitorTags(out var partBTags, out var partCTags);

            Assert.Equal(PartBType.Http, activityType);
            Assert.Equal(4, partBTags.Count);
            Assert.Equal("https", partBTags[SemanticConventions.AttributeHttpScheme]);
            Assert.Equal("localhost", partBTags[SemanticConventions.AttributeHttpHost]);
            Assert.Equal("8888", partBTags[SemanticConventions.AttributeHttpHostPort]);
            Assert.Equal("127.0.0.1", partBTags[SemanticConventions.AttributeNetHostIp]);
            Assert.Single(partCTags);
            Assert.Equal("test", partCTags[SemanticConventions.AttributeRpcSystem]);
        }

        [Fact]
        public void TagObjects_PartB_PartC()
        {
            IEnumerable<KeyValuePair<string, object>> tagObjects = new Dictionary<string, object>
            {
                [SemanticConventions.AttributeHttpScheme] = "https",
                [SemanticConventions.AttributeHttpHost] = "localhost",
                [SemanticConventions.AttributeHttpHostPort] = "8888",
                ["somekey"] = "value"
            };

            var activityType = tagObjects.ToAzureMonitorTags(out var partBTags, out var PartCTags);

            Assert.Equal(PartBType.Http, activityType);
            Assert.Equal(3, partBTags.Count);
            Assert.Single(PartCTags);

            Assert.Equal("https", partBTags[SemanticConventions.AttributeHttpScheme]);
            Assert.Equal("localhost", partBTags[SemanticConventions.AttributeHttpHost]);
            Assert.Equal("8888", partBTags[SemanticConventions.AttributeHttpHostPort]);

            Assert.Equal("value", PartCTags["somekey"]);
        }

        [Fact]
        public void TagObjects_IntArray()
        {
            IEnumerable<KeyValuePair<string, object>> tagObjects = new Dictionary<string, object>
            {
                ["intArray"] = new int []{ 1, 2, 3},
            };

            var activityType = tagObjects.ToAzureMonitorTags(out var partBTags, out var PartCTags);

            Assert.Equal(PartBType.Unknown, activityType);
            Assert.Empty(partBTags);
            Assert.Single(PartCTags);

            Assert.Equal("1,2,3", PartCTags["intArray"]);
        }

        [Fact]
        public void TagObjects_DoubleArray()
        {
            IEnumerable<KeyValuePair<string, object>> tagObjects = new Dictionary<string, object>
            {
                ["doubleArray"] = new double[] { 1.1, 2.2, 3.3 },
            };

            var activityType = tagObjects.ToAzureMonitorTags(out var partBTags, out var PartCTags);

            Assert.Equal(PartBType.Unknown, activityType);
            Assert.Empty(partBTags);
            Assert.Single(PartCTags);

            Assert.Equal("1.1,2.2,3.3", PartCTags["doubleArray"]);
        }

        [Fact]
        public void TagObjects_StringArray()
        {
            IEnumerable<KeyValuePair<string, object>> tagObjects = new Dictionary<string, object>
            {
                ["strArray"] = new string[] { "test1", "test2", "test3" },
            };

            var activityType = tagObjects.ToAzureMonitorTags(out var partBTags, out var PartCTags);

            Assert.Equal(PartBType.Unknown, activityType);
            Assert.Empty(partBTags);
            Assert.Single(PartCTags);

            Assert.Equal("test1,test2,test3", PartCTags["strArray"]);
        }

        [Fact]
        public void TagObjects_BooleanArray()
        {
            IEnumerable<KeyValuePair<string, object>> tagObjects = new Dictionary<string, object>
            {
                ["boolArray"] = new bool[] { true, false, true },
            };

            var activityType = tagObjects.ToAzureMonitorTags(out var partBTags, out var PartCTags);

            Assert.Equal(PartBType.Unknown, activityType);
            Assert.Empty(partBTags);
            Assert.Single(PartCTags);

            Assert.Equal("True,False,True", PartCTags["boolArray"]);
        }

        [Fact]
        public void TagObjects_ObjectArray()
        {
            IEnumerable<KeyValuePair<string, object>> tagObjects = new Dictionary<string, object>
            {
                ["objArray"] = new Test[] { new Test(), new Test(), new Test() { TestProperty = 0} },
            };

            var activityType = tagObjects.ToAzureMonitorTags(out var partBTags, out var PartCTags);

            Assert.Equal(PartBType.Unknown, activityType);
            Assert.Empty(partBTags);
            Assert.Single(PartCTags);

            Assert.Equal("Microsoft.Azure.Monitor.OpenTelemetry.Exporter.TagsExtensionTests+Test,Microsoft.Azure.Monitor.OpenTelemetry.Exporter.TagsExtensionTests+Test,Microsoft.Azure.Monitor.OpenTelemetry.Exporter.TagsExtensionTests+Test", PartCTags["objArray"]);
        }

        [Fact]
        public void TagObjects_Diff_DataTypes()
        {
            IEnumerable<KeyValuePair<string, object>> tagObjects = new Dictionary<string, object>
            {
                ["intKey"] = 1,
                ["doubleKey"] = 1.1,
                ["stringKey"] = "test",
                ["boolKey"] = true,
                ["objectKey"] = new Test(),
                ["arrayKey"] = new int[] {1, 2, 3}
            };

            var activityType = tagObjects.ToAzureMonitorTags(out var partBTags, out var PartCTags);

            Assert.Equal(PartBType.Unknown, activityType);
            Assert.Empty(partBTags);
            Assert.Equal(6, PartCTags.Count);

            Assert.Equal("1", PartCTags["intKey"]);
            Assert.Equal("1.1", PartCTags["doubleKey"]);
            Assert.Equal("test", PartCTags["stringKey"]);
            Assert.Equal("True", PartCTags["boolKey"]);
            Assert.Equal("Microsoft.Azure.Monitor.OpenTelemetry.Exporter.TagsExtensionTests+Test", PartCTags["objectKey"]);
            Assert.Equal("1,2,3", PartCTags["arrayKey"]);
        }

        private class Test
        {
            public int TestProperty { get; set; }
        }
    }
}

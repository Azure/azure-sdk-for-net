// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Xunit;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    public class TagsExtensionTest
    {
        [Fact]
        public void TagObjects_OnlyPartC()
        {
            DateTime dateTime = DateTime.Now;
            IEnumerable<KeyValuePair<string, object>> tagObjects = new Dictionary<string, object>
            {
                ["boolKey"] = true,
                ["byteKey"] = (byte)27,
                ["sbyteKey"] = (sbyte)27,
                ["shortKey"] = (short) 1000,
                ["ushortKey"] = (ushort)63000,
                ["intKey"] = 1,
                ["uintKey"] = (uint)1,
                ["longKey"] = (long) 100000000000,
                ["ulongKey"] = (ulong)100000000001,
                ["floatKey"] = (float)3.5F,
                ["doubleKey"] = 3.1D,
                ["stringKey"] = "test",
                ["objectKey"] = new Test(),
                ["arrayKey"] = new int[] { 1, 2, 3 },
                ["dateKey"] = dateTime,
                ["dictKey"] = new Dictionary<string, object> { ["key"] = true}
            };

            var PartCTags = tagObjects.ToAzureMonitorTags();
            Assert.Equal(16, PartCTags.Count);

            Assert.Equal("True", PartCTags["boolKey"]);
            Assert.Equal("27", PartCTags["byteKey"]);
            Assert.Equal("27", PartCTags["sbyteKey"]);
            Assert.Equal("1000", PartCTags["shortKey"]);
            Assert.Equal("63000", PartCTags["ushortKey"]);
            Assert.Equal("1", PartCTags["intKey"]);
            Assert.Equal("1", PartCTags["uintKey"]);
            Assert.Equal("100000000000", PartCTags["longKey"]);
            Assert.Equal("100000000001", PartCTags["ulongKey"]);
            Assert.Equal("3.5", PartCTags["floatKey"]);
            Assert.Equal("3.1", PartCTags["doubleKey"]);
            Assert.Equal("test", PartCTags["stringKey"]);
            Assert.Equal("OpenTelemetry.Exporter.AzureMonitor.TagsExtensionTest+Test", PartCTags["objectKey"]);
            Assert.Equal("1,2,3", PartCTags["arrayKey"]);
            Assert.Equal(dateTime.ToString(), PartCTags["dateKey"]);
            Assert.Equal("System.Collections.Generic.Dictionary`2[System.String,System.Object]", PartCTags["dictKey"]);
        }

        [Fact]
        public void TagObjects_OnlyPartC_NullOrEmpty()
        {
            DateTime dateTime = DateTime.Now;
            IEnumerable<KeyValuePair<string, object>> tagObjects = null;

            var PartCTags = tagObjects.ToAzureMonitorTags();
            Assert.Null(PartCTags);

            tagObjects = new Dictionary<string, object>();
            PartCTags = tagObjects.ToAzureMonitorTags();
            Assert.Empty(PartCTags);
        }

        private class Test
        {
            public int TestProperty { get; set; }
        }
    }
}

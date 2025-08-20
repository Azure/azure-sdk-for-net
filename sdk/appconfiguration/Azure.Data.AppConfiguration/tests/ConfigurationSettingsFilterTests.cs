// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Tests
{
    public class ConfigurationSettingsFilterTests
    {
        [TestCaseSource(nameof(DeserializeKeyValueFilterTestCases))]
        public void DeserializeKeyValueFilter(string json, bool hasTags)
        {
            var element = JsonDocument.Parse(json).RootElement;

            // Act
            var filter = ConfigurationSettingsFilter.DeserializeKeyValueFilter(element);

            // Assert
            Assert.AreEqual("testKey", filter.Key);
            Assert.AreEqual("testLabel", filter.Label);
            if (hasTags)
            {
                Assert.IsNotNull(filter.Tags);
                Assert.AreEqual(new List<string> { "tag1=value1", "tag2=value2" }, filter.Tags);
            }
            else
            {
                Assert.IsNull(filter.Tags);
            }
        }

        public static IEnumerable<TestCaseData> DeserializeKeyValueFilterTestCases
        {
            get
            {
                yield return new TestCaseData(@"{
                ""key"": ""testKey"",
                ""label"": ""testLabel"",
                ""tags"": [""tag1=value1"", ""tag2=value2""]
                }", true);
                yield return new TestCaseData(@"{
                ""key"": ""testKey"",
                ""label"": ""testLabel""
                }", false);
            }
        }
    }
}

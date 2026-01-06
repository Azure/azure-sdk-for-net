// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Tests
{
    public class ConfigurationSettingsFilterTests
    {
        [TestCaseSource(nameof(DeserializeConfigurationSettingsFilterTestCases))]
        public void DeserializeConfigurationSettingsFilter(string json, bool hasTags)
        {
            var element = JsonDocument.Parse(json).RootElement;

            // Act
            var filter = ConfigurationSettingsFilter.DeserializeConfigurationSettingsFilter(element, ModelSerializationExtensions.WireOptions);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(filter.Key, Is.EqualTo("testKey"));
                Assert.That(filter.Label, Is.EqualTo("testLabel"));
            });
            if (hasTags)
            {
                Assert.That(filter.Tags, Is.Not.Null);
                Assert.That(filter.Tags, Is.EqualTo(new List<string> { "tag1=value1", "tag2=value2" }));
            }
            else
            {
                Assert.That(filter.Tags, Is.Empty);
            }
        }

        public static IEnumerable<TestCaseData> DeserializeConfigurationSettingsFilterTestCases
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

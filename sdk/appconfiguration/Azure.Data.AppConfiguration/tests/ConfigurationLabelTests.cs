// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Tests
{
    public class ConfigurationLabelTests
    {
        [TestCaseSource(nameof(DeserializeConfigurationLabelTestCases))]
        public void DeserializeConfigurationLabel(string json, bool hasName)
        {
            var element = JsonDocument.Parse(json).RootElement;

            // Act
            var label = ConfigurationLabel.DeserializeLabel(element);

            if (hasName)
            {
                Assert.IsNotNull(label.Name);
                Assert.AreEqual("testName", label.Name);
            }
            else
            {
                Assert.IsNull(label.Name);
            }
        }

        public static IEnumerable<TestCaseData> DeserializeConfigurationLabelTestCases
        {
            get
            {
                yield return new TestCaseData(@"{
                ""name"": ""testName""
                }", true);
                yield return new TestCaseData(@"{}", false);
            }
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Tests
{
    public class SettingLabelTests
    {
        [TestCaseSource(nameof(DeserializeLabelTestCases))]
        public void DeserializeLabel(string json, bool hasName)
        {
            var element = JsonDocument.Parse(json).RootElement;

            // Act
            var label = SettingLabel.DeserializeLabel(element);

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

        public static IEnumerable<TestCaseData> DeserializeLabelTestCases
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

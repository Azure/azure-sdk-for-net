// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Data.AppConfiguration.Tests
{
    public class FeatureManagementTests
    {
        private static readonly FeatureFlag s_testFlag = new FeatureFlag("testFlag")
        {
            Description = "This is a test feature flag.",
        };

        [Test]
        public void FeatureFlagEquals()
        {
            var comparer = FeatureFlagEqualityComparer.Instance;

            //Case tests
            FeatureFlag testFlagUpperCase = s_testFlag.Clone();
            testFlagUpperCase.Alias = testFlagUpperCase.Name.ToUpper();

            FeatureFlag testFlagLowerCase = s_testFlag.Clone();
            testFlagLowerCase.Alias = testFlagLowerCase.Name.ToLower();
            Assert.IsFalse(comparer.Equals(testFlagUpperCase, testFlagLowerCase));

            FeatureFlag testSettingSameCase = s_testFlag.Clone();
            Assert.IsTrue(comparer.Equals(s_testFlag, testSettingSameCase));

            //Etag tests
            FeatureFlag testSettingEtagDiff = testSettingSameCase.Clone();
            testSettingSameCase.ETag = new ETag(Guid.NewGuid().ToString());
            testSettingEtagDiff.ETag = new ETag(Guid.NewGuid().ToString());
            Assert.IsFalse(comparer.Equals(testSettingSameCase, testSettingEtagDiff));

            // Different tags
            FeatureFlag testFlagDiffTags = s_testFlag.Clone();
            testFlagDiffTags.Tags.Add("tag3", "test_value3");
            Assert.IsFalse(comparer.Equals(s_testFlag, testFlagDiffTags));
        }

        [Test]
        public void FeatureFlagSerialization()
        {
            var comparer = FeatureFlagEqualityComparer.Instance;
            var serialized = JsonSerializer.Serialize(s_testFlag);
            var deserialized = JsonSerializer.Deserialize<FeatureFlag>(serialized);
            Assert.IsTrue(comparer.Equals(s_testFlag, deserialized));
        }

        [Test]
        public void FeatureFlagDictionarySerialization()
        {
            var comparer = FeatureFlagEqualityComparer.Instance;
            IDictionary<string, FeatureFlag> dict = new Dictionary<string, FeatureFlag>
            {
                { s_testFlag.Name, s_testFlag },
                { "null_key", null }
            };

            var serialized = JsonSerializer.Serialize(dict);
            var deserialized = JsonSerializer.Deserialize<IDictionary<string, FeatureFlag>>(serialized);
            CollectionAssert.IsNotEmpty(deserialized);

            Assert.IsTrue(comparer.Equals(s_testFlag, deserialized[s_testFlag.Name]));
            Assert.IsNull(deserialized["null_key"]);
        }

        [Test]
        public void FeatureFlagEtagConstructor()
        {
            var featureFlag = new FeatureFlag("name", true, "label", new ETag("etag"));
            Assert.AreEqual("name", featureFlag.Name);
            Assert.AreEqual(true, featureFlag.Enabled);
            Assert.AreEqual("label", featureFlag.Label);
            Assert.AreEqual("etag", featureFlag.ETag.ToString());
        }
    }
}

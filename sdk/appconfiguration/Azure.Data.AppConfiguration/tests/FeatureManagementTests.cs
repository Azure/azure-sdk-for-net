// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;

namespace Azure.Data.AppConfiguration.Tests
{
    public class FeatureManagementTests
    {
        private static readonly FeatureFlag s_testFlag = ConfigurationModelFactory.FeatureFlag(
            name: "testFlag",
            description: "This is a test feature flag."
        );

        //
        //
        // Equality and clone tests
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
            var options = ModelReaderWriterOptions.Json;
            var serialized = ((IPersistableModel<FeatureFlag>)s_testFlag).Write(options);
            var deserialized = ((IPersistableModel<FeatureFlag>)s_testFlag).Create(serialized, options);

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

            var options = ModelReaderWriterOptions.Json;
            var serializedDict = new Dictionary<string, BinaryData>();
            foreach (var kvp in dict)
            {
                if (kvp.Value != null)
                {
                    serializedDict[kvp.Key] = ((IPersistableModel<FeatureFlag>)kvp.Value).Write(options);
                }
                else
                {
                    serializedDict[kvp.Key] = null;
                }
            }

            var deserializedDict = new Dictionary<string, FeatureFlag>();
            foreach (var kvp in serializedDict)
            {
                if (kvp.Value != null)
                {
                    deserializedDict[kvp.Key] = ((IPersistableModel<FeatureFlag>)s_testFlag).Create(kvp.Value, options);
                }
                else
                {
                    deserializedDict[kvp.Key] = null;
                }
            }

            CollectionAssert.IsNotEmpty(deserializedDict);
            Assert.IsTrue(comparer.Equals(s_testFlag, deserializedDict[s_testFlag.Name]));
            Assert.IsNull(deserializedDict["null_key"]);
        }

        [Test]
        public void FeatureFlagEtagConstructor()
        {
            var featureFlag = ConfigurationModelFactory.FeatureFlag(
                name: "name",
                enabled: true,
                label: "label",
                eTag: new ETag("etag")
            );
            Assert.AreEqual("name", featureFlag.Name);
            Assert.AreEqual(true, featureFlag.Enabled);
            Assert.AreEqual("label", featureFlag.Label);
            Assert.AreEqual("etag", featureFlag.ETag.ToString());
        }
    }
}

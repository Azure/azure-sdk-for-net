// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Data.AppConfiguration.Tests
{
    public class ConfigurationSettingTests
    {
        private static readonly ConfigurationSetting s_testSetting = new ConfigurationSetting(
            string.Concat("key-", Guid.NewGuid().ToString("N")),
            "test_value",
            "test_label"
        )
        {
            ContentType = "test_content_type",
            ETag = new ETag("test_etag"),
            LastModified = new DateTimeOffset(DateTime.Today).AddHours(5).AddMinutes(15).AddSeconds(32),
            IsReadOnly = true,
            Tags = new Dictionary<string, string>
            {
                { "tag1", "value1" },
                { "tag2", "value2" }
            }
        };

        [Test]
        public void ConfigurationSettingEquals()
        {
            var comparer = ConfigurationSettingEqualityComparer.Instance;

            //Case tests
            ConfigurationSetting testSettingUpperCase = s_testSetting.Clone();
            testSettingUpperCase.Key = testSettingUpperCase.Key.ToUpper();

            ConfigurationSetting testSettingLowerCase = s_testSetting.Clone();
            testSettingLowerCase.Key = testSettingLowerCase.Key.ToLower();
            Assert.That(comparer.Equals(testSettingUpperCase, testSettingLowerCase), Is.False);

            ConfigurationSetting testSettingsameCase = s_testSetting.Clone();
            Assert.That(comparer.Equals(s_testSetting, testSettingsameCase), Is.True);

            //Etag tests
            ConfigurationSetting testSettingEtagDiff = testSettingsameCase.Clone();
            testSettingsameCase.ETag = new ETag(Guid.NewGuid().ToString());
            testSettingEtagDiff.ETag = new ETag(Guid.NewGuid().ToString());
            Assert.That(comparer.Equals(testSettingsameCase, testSettingEtagDiff), Is.False);

            // Different tags
            ConfigurationSetting testSettingDiffTags = s_testSetting.Clone();
            testSettingDiffTags.Tags.Add("tag3", "test_value3");
            Assert.That(comparer.Equals(s_testSetting, testSettingDiffTags), Is.False);
        }

        [Test]
        public void ConfigurationSettingSerialization()
        {
            var comparer = ConfigurationSettingEqualityComparer.Instance;
            var serialized = JsonSerializer.Serialize(s_testSetting);
            var deserialized = JsonSerializer.Deserialize<ConfigurationSetting>(serialized);
            Assert.That(comparer.Equals(s_testSetting, deserialized), Is.True);
        }

        [Test]
        public void ConfigurationSettingDictionarySerialization()
        {
            var comparer = ConfigurationSettingEqualityComparer.Instance;
            IDictionary<string, ConfigurationSetting> dict = new Dictionary<string, ConfigurationSetting>
            {
                { s_testSetting.Key, s_testSetting },
                { "null_key", null }
            };

            var serialized = JsonSerializer.Serialize(dict);
            var deserialized = JsonSerializer.Deserialize<IDictionary<string, ConfigurationSetting>>(serialized);
            CollectionAssert.IsNotEmpty(deserialized);

            Assert.That(comparer.Equals(s_testSetting, deserialized[s_testSetting.Key]), Is.True);
            Assert.That(deserialized["null_key"], Is.Null);
        }

        [Test]
        public void ConfigurationSettingEtagConstructor()
        {
            var configurationSetting = new ConfigurationSetting("key", "value", "label", new ETag("etag"));
            Assert.That(configurationSetting.Key, Is.EqualTo("key"));
            Assert.That(configurationSetting.Value, Is.EqualTo("value"));
            Assert.That(configurationSetting.Label, Is.EqualTo("label"));
            Assert.That(configurationSetting.ETag.ToString(), Is.EqualTo("etag"));
        }
    }
}

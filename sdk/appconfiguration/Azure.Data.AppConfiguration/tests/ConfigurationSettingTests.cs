// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

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
        public void FilterReservedCharacter()
        {
            var selector = new SettingSelector
            {
                KeyFilter = @"my_key,key\,key",
                LabelFilter = @"my_label,label\,label"
            };

            var builder = new RequestUriBuilder();
            builder.Reset(new Uri("http://localhost/"));

            ConfigurationClient.BuildBatchQuery(builder, selector, null);

            Assert.AreEqual(@"http://localhost/?key=my_key%2Ckey%5C%2Ckey&label=my_label%2Clabel%5C%2Clabel", builder.ToUri().AbsoluteUri);
        }

        [Test]
        public void FilterContains()
        {
            var selector = new SettingSelector{ KeyFilter = "*key*", LabelFilter = "*label*" };
            var builder = new RequestUriBuilder();
            builder.Reset(new Uri("http://localhost/"));

            ConfigurationClient.BuildBatchQuery(builder, selector, null);

            Assert.AreEqual("http://localhost/?key=%2Akey%2A&label=%2Alabel%2A", builder.ToUri().AbsoluteUri);
        }

        [Test]
        public void FilterNullLabel()
        {
            var selector = new SettingSelector { LabelFilter = "\0" };

            var builder = new RequestUriBuilder();
            builder.Reset(new Uri("http://localhost/"));

            ConfigurationClient.BuildBatchQuery(builder, selector, null);

            Assert.AreEqual("http://localhost/?label=%00", builder.ToUri().AbsoluteUri);
        }

        [Test]
        public void FilterOnlyKey()
        {
            var key = "my-key";
            var selector = new SettingSelector { KeyFilter = key };

            var builder = new RequestUriBuilder();
            builder.Reset(new Uri("http://localhost/"));

            ConfigurationClient.BuildBatchQuery(builder, selector, null);

            Assert.AreEqual($"http://localhost/?key={key}", builder.ToUri().AbsoluteUri);
        }

        [Test]
        public void FilterOnlyLabel()
        {
            var label = "my-label";
            var selector = new SettingSelector
            {
                LabelFilter = label
            };

            var builder = new RequestUriBuilder();
            builder.Reset(new Uri("http://localhost/"));

            ConfigurationClient.BuildBatchQuery(builder, selector, null);

            Assert.AreEqual($"http://localhost/?label={label}", builder.ToUri().AbsoluteUri);
        }

        [Test]
        public void SettingSomeFields()
        {
            var selector = new SettingSelector
            {
                KeyFilter = "key",
                Fields = SettingFields.Key | SettingFields.Value
            };

            var builder = new RequestUriBuilder();
            builder.Reset(new Uri("http://localhost/"));

            ConfigurationClient.BuildBatchQuery(builder, selector, null);

            Assert.AreEqual($"http://localhost/?key=key&$select=key%2C%20value", builder.ToUri().AbsoluteUri);
        }

        [Test]
        public void SettingAllFields()
        {
            var selector = new SettingSelector
            {
                KeyFilter = "key",
                Fields = SettingFields.All
            };

            var builder = new RequestUriBuilder();
            builder.Reset(new Uri("http://localhost/"));

            ConfigurationClient.BuildBatchQuery(builder, selector, null);

            Assert.AreEqual($"http://localhost/?key=key", builder.ToUri().AbsoluteUri);
        }

        [Test]
        public void ConfigurationSettingEquals()
        {
            var comparer = ConfigurationSettingEqualityComparer.Instance;

            //Case tests
            ConfigurationSetting testSettingUpperCase = s_testSetting.Clone();
            testSettingUpperCase.Key = testSettingUpperCase.Key.ToUpper();

            ConfigurationSetting testSettingLowerCase = s_testSetting.Clone();
            testSettingLowerCase.Key = testSettingLowerCase.Key.ToLower();
            Assert.IsFalse(comparer.Equals(testSettingUpperCase, testSettingLowerCase));

            ConfigurationSetting testSettingsameCase = s_testSetting.Clone();
            Assert.IsTrue(comparer.Equals(s_testSetting, testSettingsameCase));

            //Etag tests
            ConfigurationSetting testSettingEtagDiff = testSettingsameCase.Clone();
            testSettingsameCase.ETag = new ETag(Guid.NewGuid().ToString());
            testSettingEtagDiff.ETag = new ETag(Guid.NewGuid().ToString());
            Assert.IsFalse(comparer.Equals(testSettingsameCase, testSettingEtagDiff));

            // Different tags
            ConfigurationSetting testSettingDiffTags = s_testSetting.Clone();
            testSettingDiffTags.Tags.Add("tag3", "test_value3");
            Assert.IsFalse(comparer.Equals(s_testSetting, testSettingDiffTags));
        }

        [Test]
        public void ConfigurationSettingSerialization()
        {
            var comparer = ConfigurationSettingEqualityComparer.Instance;
            var serialized = JsonSerializer.Serialize(s_testSetting);
            var deserialized = JsonSerializer.Deserialize<ConfigurationSetting>(serialized);
            Assert.IsTrue(comparer.Equals(s_testSetting, deserialized));
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

            Assert.IsTrue(comparer.Equals(s_testSetting, deserialized[s_testSetting.Key]));
            Assert.IsNull(deserialized["null_key"]);
        }
    }
}

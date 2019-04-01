using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.ApplicationModel.Configuration.Tests
{
    public class ConfigurationSettingTests
    {
        static readonly string s_connectionString = "Endpoint=https://contoso.azconfig.io;Id=b1d9b31;Secret=aabbccdd";

        static readonly ConfigurationSetting s_testSetting = new ConfigurationSetting(
            string.Concat("key-", Guid.NewGuid().ToString("N")),
            "test_value"
        )
        {
            Label = "test_label",
            ContentType = "test_content_type",
            Tags = new Dictionary<string, string>
            {
                { "tag1", "value1" },
                { "tag2", "value2" }
            }
        };

        [Test]
        public void FilterReservedCharacter()
        {
            var service = new ConfigurationClient(s_connectionString);
            var selector = new SettingSelector()
            {
                Keys = new List<string>() { "my_key", "key,key" },
                Labels = new List<string>() { "my_label", "label,label" },
            };

            var builder = new UriBuilder();
            service.BuildBatchQuery(builder, selector);

            Assert.AreEqual(builder.Uri.AbsoluteUri, @"http://localhost/?key=my_key,key%5C,key&label=my_label,label%5C,label");

        }

        [Test]
        public void FilterContains()
        {
            var service = new ConfigurationClient(s_connectionString);
            var selector = new SettingSelector()
            {
                Keys = new List<string>() { "*key*" },
                Labels = new List<string>() { "*label*" },
            };

            var builder = new UriBuilder();
            service.BuildBatchQuery(builder, selector);

            Assert.AreEqual(builder.Uri.AbsoluteUri, "http://localhost/?key=*key*&label=*label*");
        }

        [Test]
        public void FilterNullLabel()
        {
            var service = new ConfigurationClient(s_connectionString);
            var selector = new SettingSelector()
            {
                Labels = new List<string>() { "" },
            };

            var builder = new UriBuilder();
            service.BuildBatchQuery(builder, selector);

            Assert.AreEqual(builder.Uri.AbsoluteUri, "http://localhost/?key=*&label=%00");
        }

        [Test]
        public void FilterOnlyKey()
        {
            var service = new ConfigurationClient(s_connectionString);

            var key = "my-key";
            var selector = new SettingSelector(key);

            var builder = new UriBuilder();
            service.BuildBatchQuery(builder, selector);

            Assert.AreEqual(builder.Uri.AbsoluteUri, $"http://localhost/?key={key}");
        }

        [Test]
        public void FilterOnlyLabel()
        {
            var service = new ConfigurationClient(s_connectionString);

            var label = "my-label";
            var selector = new SettingSelector(null, label);

            var builder = new UriBuilder();
            service.BuildBatchQuery(builder, selector);

            Assert.AreEqual(builder.Uri.AbsoluteUri, $"http://localhost/?key=*&label={label}");
        }

        [Test]
        public void ConfigurationSettingEquals()
        {
            //Case tests
            var testSettingUpperCase = s_testSetting.Clone();
            testSettingUpperCase.Key = testSettingUpperCase.Key.ToUpper();

            var testSettingLowerCase = s_testSetting.Clone();
            testSettingLowerCase.Key = testSettingLowerCase.Key.ToLower();
            Assert.AreNotEqual(testSettingUpperCase, testSettingLowerCase);

            var testSettingsameCase = s_testSetting.Clone();
            Assert.AreEqual(testSettingsameCase, s_testSetting);

            //Etag tests
            var testSettingEtagDiff = testSettingsameCase.Clone();
            testSettingsameCase.ETag = new ETag(Guid.NewGuid().ToString());
            testSettingEtagDiff.ETag = new ETag(Guid.NewGuid().ToString());
            Assert.AreNotEqual(testSettingsameCase, testSettingEtagDiff);

            // Different tags
            var testSettingDiffTags = s_testSetting.Clone();
            testSettingDiffTags.Tags.Add("tag3", "test_value3");
            Assert.AreNotEqual(s_testSetting, testSettingDiffTags);
        }

        private bool SettingSelectoComparissonr(SettingSelector actual, SettingSelector other)
        {
            if (actual != null && other == null) return false;
            if (!actual.Keys.SequenceEqual(other.Keys)) return false;
            if (!actual.Labels.SequenceEqual(other.Labels)) return false;
            if (!actual.Fields.Equals(other.Fields)) return false;
            if (actual.AsOf != other.AsOf) return false;

            return true;
        }

        [Test]
        public void SettingSelectorCloneWithBatchLink()
        {
            SettingSelector selector = new SettingSelector()
            {
                Keys = new List<string> { "key1", "key2", "key3" },
                Labels = { "label1" },
                Fields = SettingFields.Key | SettingFields.Label | SettingFields.Value,
                AsOf = DateTimeOffset.Now
            };

            var selectorWithLink = selector.CloneWithBatchLink("someLink");

            Assert.IsTrue(SettingSelectoComparissonr(selector, selectorWithLink));

            selector.Keys.Add("Key4");
            selector.Labels.Add("Label2");
            selector.Fields = SettingFields.All;

            Assert.IsFalse(SettingSelectoComparissonr(selector, selectorWithLink));
        }
    }
}

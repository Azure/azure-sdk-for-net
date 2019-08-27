using NUnit.Framework;
using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.Http;

namespace Azure.Data.AppConfiguration.Tests
{
    public class ConfigurationSettingTests
    {
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
            var selector = new SettingSelector()
            {
                Keys = new List<string>() { "my_key", "key,key" },
                Labels = new List<string>() { "my_label", "label,label" },
            };

            var builder = new RequestUriBuilder();
            builder.Uri = new Uri("http://localhost/");
            ConfigurationClient.BuildBatchQuery(builder, selector, null);

            Assert.AreEqual(@"http://localhost/?key=my_key,key%5C,key&label=my_label,label%5C,label", builder.Uri.AbsoluteUri);

        }

        [Test]
        public void FilterContains()
        {
            var selector = new SettingSelector()
            {
                Keys = new List<string>() { "*key*" },
                Labels = new List<string>() { "*label*" },
            };

            var builder = new RequestUriBuilder();
            builder.Uri = new Uri("http://localhost/");
            ConfigurationClient.BuildBatchQuery(builder, selector, null);

            Assert.AreEqual("http://localhost/?key=*key*&label=*label*", builder.Uri.AbsoluteUri);
        }

        [Test]
        public void FilterNullLabel()
        {
            var selector = new SettingSelector()
            {
                Labels = new List<string>() { "" },
            };

            var builder = new RequestUriBuilder();
            builder.Uri = new Uri("http://localhost/");
            ConfigurationClient.BuildBatchQuery(builder, selector, null);

            Assert.AreEqual("http://localhost/?key=*&label=%00", builder.Uri.AbsoluteUri);
        }

        [Test]
        public void FilterOnlyKey()
        {
            var key = "my-key";
            var selector = new SettingSelector(key);

            var builder = new RequestUriBuilder();
            builder.Uri = new Uri("http://localhost/");
            ConfigurationClient.BuildBatchQuery(builder, selector, null);

            Assert.AreEqual($"http://localhost/?key={key}", builder.Uri.AbsoluteUri);
        }

        [Test]
        public void FilterOnlyLabel()
        {
            var label = "my-label";
            var selector = new SettingSelector(null, label);

            var builder = new RequestUriBuilder();
            builder.Uri = new Uri("http://localhost/");
            ConfigurationClient.BuildBatchQuery(builder, selector, null);

            Assert.AreEqual($"http://localhost/?key=*&label={label}", builder.Uri.AbsoluteUri);
        }

        [Test]
        public void SettingSomeFields()
        {
            var selector = new SettingSelector("key")
            {
                Fields = SettingFields.Key | SettingFields.Value
            };

            var builder = new RequestUriBuilder();
            builder.Uri = new Uri("http://localhost/");
            ConfigurationClient.BuildBatchQuery(builder, selector, null);

            Assert.AreEqual($"http://localhost/?key=key&$select=key,%20value", builder.Uri.AbsoluteUri);
        }

        [Test]
        public void SettingAllFields()
        {
            var selector = new SettingSelector("key")
            {
                Fields = SettingFields.All
            };

            var builder = new RequestUriBuilder();
            builder.Uri = new Uri("http://localhost/");
            ConfigurationClient.BuildBatchQuery(builder, selector, null);

            Assert.AreEqual($"http://localhost/?key=key", builder.Uri.AbsoluteUri);
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
            Assert.AreEqual(s_testSetting, testSettingsameCase);

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
    }
}

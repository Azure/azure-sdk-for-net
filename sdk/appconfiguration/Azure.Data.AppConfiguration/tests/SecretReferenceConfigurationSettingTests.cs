// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration
{
    public class SecretReferenceConfigurationSettingTests
    {
        private const string ReferenceValue = "{\"uri\":\"http://example.com/secret\"}";
        private const string ReferenceValueWithFormatting = "{\"uri\"          :         \"http://example.com/secret\"}";

        [Test]
        public void CreatingSetsContentType()
        {
            var reference = new SecretReferenceConfigurationSetting("key", new Uri("http://example.com/secret"));

            Assert.AreEqual("application/vnd.microsoft.appconfig.keyvaultref+json;charset=utf-8", reference.ContentType);
            Assert.AreEqual("key" , reference.Key);
            Assert.AreEqual("http://example.com/secret", reference.SecretId.AbsoluteUri);
        }

        [TestCase("INVALID")]
        [TestCase(ReferenceValue)]
        [TestCase("")]
        [TestCase(null)]
        public void CanRountripValue(string value)
        {
            var featureFlag = new SecretReferenceConfigurationSetting();
            featureFlag.Value = value;

            Assert.AreEqual(value, featureFlag.Value);
        }

        [Test]
        public void CanFormatValue()
        {
            var featureFlag = new SecretReferenceConfigurationSetting();
            featureFlag.Value = ReferenceValueWithFormatting;

            Assert.AreEqual(ReferenceValue, featureFlag.Value);
        }

        [Test]
        public void NewFeatureReferenceSerialized()
        {
            var reference = new SecretReferenceConfigurationSetting("key", new Uri("http://example.com/secret"));
            Assert.AreEqual(ReferenceValue, reference.Value);
        }

        [Test]
        public void ReferenceParsedOnAssignment()
        {
            var reference = new SecretReferenceConfigurationSetting("key", new Uri("http://example.org"));
            reference.Value = ReferenceValueWithFormatting;
            Assert.AreEqual("http://example.com/secret", reference.SecretId.AbsoluteUri);
        }

        [Test]
        public void ReadingPropertiedDoesNotChangeValue()
        {
            var feature = new SecretReferenceConfigurationSetting();
            feature.Value = ReferenceValueWithFormatting;
            _ = feature.SecretId;

            Assert.AreEqual(ReferenceValue, feature.Value);
        }

        [Test]
        public void SettingSecretUriChangesValue()
        {
            var feature = new SecretReferenceConfigurationSetting();
            feature.Value = ReferenceValueWithFormatting;
            feature.SecretId = new Uri("http://example.org");

            Assert.AreEqual("{\"uri\":\"http://example.org/\"}", feature.Value);
        }
    }
}

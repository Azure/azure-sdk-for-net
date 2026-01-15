// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Tests
{
    public class SecretReferenceConfigurationSettingTests
    {
        private const string ReferenceValue = "{\"uri\":\"http://example.com/secret\"}";
        private const string ReferenceValueWithFormatting = "{\"uri\"          :         \"http://example.com/secret\"}";

        private const string UnknownAttributeReferenceValue = @"{
            ""uri"":""http://example.com/secret"",
            ""custom_stuff"": { ""id"":""dummy"", ""description"":""dummy"", ""enabled"":false },
            ""more_custom"" : [1, 2, 3, 4]
            }";

        private readonly JsonElementEqualityComparer _jsonComparer = new();

        [Test]
        public void CreatingSetsContentType()
        {
            var reference = new SecretReferenceConfigurationSetting("key", new Uri("http://example.com/secret"));

            Assert.That(reference.ContentType, Is.EqualTo("application/vnd.microsoft.appconfig.keyvaultref+json;charset=utf-8"));
            Assert.That(reference.Key, Is.EqualTo("key"));
            Assert.That(reference.SecretId.AbsoluteUri, Is.EqualTo("http://example.com/secret"));
        }

        [TestCase("INVALID")]
        [TestCase(ReferenceValue)]
        [TestCase("")]
        [TestCase(null)]
        public void CanRountripValue(string value)
        {
            var secretSetting = new SecretReferenceConfigurationSetting();
            secretSetting.Value = value;

            try
            {
                using var expected = JsonDocument.Parse(value ?? "");
                using var actual = JsonDocument.Parse(secretSetting.Value);

                Assert.That(_jsonComparer.Equals(expected.RootElement, actual.RootElement), Is.True);
            }
            catch (JsonException)
            {
                // For the cases that are not legal JSON, this exception will occur
                // and we just want to make sure that the string value is set correctly.
                Assert.That(secretSetting.Value, Is.EqualTo(value));
            }
        }

        [Test]
        public void CanFormatValue()
        {
            var secretSetting = new SecretReferenceConfigurationSetting();
            secretSetting.Value = ReferenceValueWithFormatting;

            using var expected = JsonDocument.Parse(ReferenceValueWithFormatting);
            using var actual = JsonDocument.Parse(secretSetting.Value);

            Assert.That(_jsonComparer.Equals(expected.RootElement, actual.RootElement), Is.True);        }

        [Test]
        public void NewFeatureReferenceSerialized()
        {
            var secretSetting = new SecretReferenceConfigurationSetting("key", new Uri("http://example.com/secret"));

            using var expected = JsonDocument.Parse(ReferenceValueWithFormatting);
            using var actual = JsonDocument.Parse(secretSetting.Value);

            Assert.That(_jsonComparer.Equals(expected.RootElement, actual.RootElement), Is.True);
        }

        [Test]
        public void ReferenceParsedOnAssignment()
        {
            var secretSetting = new SecretReferenceConfigurationSetting("key", new Uri("http://example.org"));
            secretSetting.Value = ReferenceValueWithFormatting;

            using var expected = JsonDocument.Parse(ReferenceValueWithFormatting);
            using var actual = JsonDocument.Parse(secretSetting.Value);

            Assert.That(_jsonComparer.Equals(expected.RootElement, actual.RootElement), Is.True);
        }

        [Test]
        public void ReadingPropertiedDoesNotChangeValue()
        {
            var secretSetting = new SecretReferenceConfigurationSetting("key", new Uri("http://example.com/secret"));
            secretSetting.Value = ReferenceValueWithFormatting;
            _ = secretSetting.SecretId;

            using var expected = JsonDocument.Parse(ReferenceValueWithFormatting);
            using var actual = JsonDocument.Parse(secretSetting.Value);

            Assert.That(_jsonComparer.Equals(expected.RootElement, actual.RootElement), Is.True);
        }

        [Test]
        public void SettingSecretUriChangesValue()
        {
            var secretSetting = new SecretReferenceConfigurationSetting("key", new Uri("http://example.com/secret"));
            secretSetting.Value = ReferenceValueWithFormatting;
            secretSetting.SecretId = new Uri("http://example.org");

            using var expected = JsonDocument.Parse("{\"uri\":\"http://example.org/\"}");
            using var actual = JsonDocument.Parse(secretSetting.Value);

            Assert.That(_jsonComparer.Equals(expected.RootElement, actual.RootElement), Is.True);
        }

        [Test]
        public void UnknownAttributesArePreservedWhenReadingValue()
        {
            var secretSetting = new SecretReferenceConfigurationSetting();
            secretSetting.Value = UnknownAttributeReferenceValue;

            using var expected = JsonDocument.Parse(UnknownAttributeReferenceValue);

            // Since the value is generated on each read, read and compare multiple times to ensure
            // that the result is consistent.
            for (var index = 0; index < 3; ++index)
            {
                using var actual = JsonDocument.Parse(secretSetting.Value);
                Assert.That(_jsonComparer.Equals(expected.RootElement, actual.RootElement), Is.True);
            }
        }

        [Test]
        public void UnknownAttributesArePreservedChangingProperties()
        {
            var originalSecretSetting = new SecretReferenceConfigurationSetting();
            originalSecretSetting.Value = UnknownAttributeReferenceValue;

            var secretSetting = new SecretReferenceConfigurationSetting();
            secretSetting.Value = UnknownAttributeReferenceValue;

            secretSetting.SecretId = new Uri("https://www.i-was-changed.org");

            var expectedJson = originalSecretSetting.Value
                .Replace(originalSecretSetting.SecretId.AbsoluteUri, secretSetting.SecretId.AbsoluteUri);

            using var expected = JsonDocument.Parse(expectedJson);
            using var actual = JsonDocument.Parse(secretSetting.Value);

            Assert.That(_jsonComparer.Equals(expected.RootElement, actual.RootElement), Is.True);
        }
    }
}

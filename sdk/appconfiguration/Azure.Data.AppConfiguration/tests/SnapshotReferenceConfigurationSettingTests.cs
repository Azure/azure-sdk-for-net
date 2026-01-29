// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Tests
{
    public class SnapshotReferenceConfigurationSettingTests
    {
        private const string ReferenceValue = "{\"snapshot_name\":\"my-snapshot\"}";
        private const string ReferenceValueWithFormatting = "{\"snapshot_name\"          :         \"my-snapshot\"}";

        private readonly JsonElementEqualityComparer _jsonComparer = new();

        [Test]
        public void CreatingSetsContentType()
        {
            var reference = new SnapshotReferenceConfigurationSetting("key", "my-snapshot");

            Assert.AreEqual("application/json; profile=\"https://azconfig.io/mime-profiles/snapshot-ref\"; charset=utf-8", reference.ContentType);
            Assert.AreEqual("key", reference.Key);
            Assert.AreEqual("my-snapshot", reference.SnapshotName);
        }

        [Test]
        public void ConstructorAllowsEmptySnapshotName()
        {
            var setting1 = new SnapshotReferenceConfigurationSetting("key", null);
            Assert.IsNull(setting1.SnapshotName);

            var setting2 = new SnapshotReferenceConfigurationSetting("key", string.Empty);
            Assert.AreEqual(string.Empty, setting2.SnapshotName);
        }

        [Test]
        public void SettingSnapshotNameAllowsEmpty()
        {
            var snapshotSetting = new SnapshotReferenceConfigurationSetting("key", "initial-snapshot");

            snapshotSetting.SnapshotName = null;
            Assert.IsNull(snapshotSetting.SnapshotName);

            snapshotSetting.SnapshotName = string.Empty;
            Assert.AreEqual(string.Empty, snapshotSetting.SnapshotName);
        }

        [TestCase("INVALID")]
        [TestCase(ReferenceValue)]
        [TestCase("")]
        [TestCase(null)]
        public void CanRoundtripValue(string value)
        {
            var snapshotSetting = new SnapshotReferenceConfigurationSetting();
            snapshotSetting.Value = value;

            try
            {
                using var expected = JsonDocument.Parse(value ?? "");
                using var actual = JsonDocument.Parse(snapshotSetting.Value);

                Assert.IsTrue(_jsonComparer.Equals(expected.RootElement, actual.RootElement));
            }
            catch (JsonException)
            {
                // For the cases that are not legal JSON, this exception will occur
                // and we just want to make sure that the string value is set correctly.
                Assert.AreEqual(value, snapshotSetting.Value);
            }
        }

        [Test]
        public void CanFormatValue()
        {
            var snapshotSetting = new SnapshotReferenceConfigurationSetting();
            snapshotSetting.Value = ReferenceValueWithFormatting;

            using var expected = JsonDocument.Parse(ReferenceValueWithFormatting);
            using var actual = JsonDocument.Parse(snapshotSetting.Value);

            Assert.IsTrue(_jsonComparer.Equals(expected.RootElement, actual.RootElement));
        }

        [Test]
        public void NewSnapshotReferenceSerialized()
        {
            var snapshotSetting = new SnapshotReferenceConfigurationSetting("key", "my-snapshot");

            using var expected = JsonDocument.Parse(ReferenceValue);
            using var actual = JsonDocument.Parse(snapshotSetting.Value);

            Assert.IsTrue(_jsonComparer.Equals(expected.RootElement, actual.RootElement));
        }

        [Test]
        public void ReferenceParsedOnAssignment()
        {
            var snapshotSetting = new SnapshotReferenceConfigurationSetting("key", "initial-snapshot");
            snapshotSetting.Value = ReferenceValueWithFormatting;

            Assert.AreEqual("my-snapshot", snapshotSetting.SnapshotName);
        }

        [Test]
        public void ReadingPropertiesDoesNotChangeValue()
        {
            var snapshotSetting = new SnapshotReferenceConfigurationSetting("key", "my-snapshot");
            snapshotSetting.Value = ReferenceValueWithFormatting;
            _ = snapshotSetting.SnapshotName;

            using var expected = JsonDocument.Parse(ReferenceValueWithFormatting);
            using var actual = JsonDocument.Parse(snapshotSetting.Value);

            Assert.IsTrue(_jsonComparer.Equals(expected.RootElement, actual.RootElement));
        }

        [Test]
        public void SettingSnapshotNameChangesValue()
        {
            var snapshotSetting = new SnapshotReferenceConfigurationSetting("key", "initial-snapshot");
            snapshotSetting.Value = ReferenceValueWithFormatting;
            snapshotSetting.SnapshotName = "updated-snapshot";

            using var expected = JsonDocument.Parse("{\"snapshot_name\":\"updated-snapshot\"}");
            using var actual = JsonDocument.Parse(snapshotSetting.Value);

            Assert.IsTrue(_jsonComparer.Equals(expected.RootElement, actual.RootElement));
        }

        [Test]
        public void InvalidValueThrowsOnPropertyAccess()
        {
            var snapshotSetting = new SnapshotReferenceConfigurationSetting();
            snapshotSetting.Value = "INVALID";

            Assert.Throws<InvalidOperationException>(() => _ = snapshotSetting.SnapshotName);
        }

        [Test]
        public void EmptySnapshotNameInJsonIsValid()
        {
            var snapshotSetting = new SnapshotReferenceConfigurationSetting();
            snapshotSetting.Value = "{\"snapshot_name\":\"\"}";

            Assert.AreEqual(string.Empty, snapshotSetting.SnapshotName);
        }

        [Test]
        public void MissingSnapshotNameInJsonIsInvalid()
        {
            var snapshotSetting = new SnapshotReferenceConfigurationSetting();
            snapshotSetting.Value = "{\"other_property\":\"value\"}";

            Assert.Throws<InvalidOperationException>(() => _ = snapshotSetting.SnapshotName);
        }
    }
}

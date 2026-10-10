// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Tests
{
    public class ConfigurationModelFactoryTests
    {
        // ---------- ConfigurationSetting ----------

        [Test]
        public void ConfigurationSetting_SetsAllProperties()
        {
            var eTag = new ETag("etag");
            var lastModified = DateTimeOffset.UtcNow;
            var tags = new Dictionary<string, string> { ["t1"] = "v1" };

            // tags/description passed by name so the test is independent of parameter position.
            ConfigurationSetting setting = ConfigurationModelFactory.ConfigurationSetting(
                key: "key",
                value: "value",
                label: "label",
                contentType: "ct",
                eTag: eTag,
                lastModified: lastModified,
                isReadOnly: true,
                tags: tags,
                description: "desc");

            Assert.That(setting.Key, Is.EqualTo("key"));
            Assert.That(setting.Value, Is.EqualTo("value"));
            Assert.That(setting.Label, Is.EqualTo("label"));
            Assert.That(setting.ContentType, Is.EqualTo("ct"));
            Assert.That(setting.ETag, Is.EqualTo(eTag));
            Assert.That(setting.LastModified, Is.EqualTo(lastModified));
            Assert.That(setting.IsReadOnly, Is.True);
            Assert.That(setting.Tags, Is.EquivalentTo(tags));
            Assert.That(setting.Description, Is.EqualTo("desc"));
        }

        [Test]
        public void ConfigurationSetting_DescriptionAndTagsDefaultSafely()
        {
            ConfigurationSetting setting = ConfigurationModelFactory.ConfigurationSetting("key", "value");

            Assert.That(setting.Description, Is.Null);
            // Factory must not leave Tags null even when not supplied.
            Assert.That(setting.Tags, Is.Not.Null.And.Empty);
        }

        [Test]
        public void ConfigurationSetting_LegacyPositionalArguments_StillBind()
        {
            // Locks the historically-shipped positional order:
            // (key, value, label, contentType, eTag, lastModified, isReadOnly).
            // This FAILS TO COMPILE if tags/description are ever inserted before isReadOnly.
            var eTag = new ETag("etag");
            var lastModified = DateTimeOffset.UtcNow;

            // 5 positional args -> binds canonical overload (eTag in slot 5).
            ConfigurationSetting fiveArgs =
                ConfigurationModelFactory.ConfigurationSetting("key", "value", "label", "ct", eTag);
            Assert.That(fiveArgs.ETag, Is.EqualTo(eTag));
            Assert.That(fiveArgs.Description, Is.Null);

            // 6 positional args -> binds canonical overload (lastModified in slot 6).
            ConfigurationSetting sixArgs =
                ConfigurationModelFactory.ConfigurationSetting("key", "value", "label", "ct", eTag, lastModified);
            Assert.That(sixArgs.LastModified, Is.EqualTo(lastModified));

            // 7 positional args -> binds the [EditorBrowsable(Never)] back-compat shim.
            ConfigurationSetting sevenArgs =
                ConfigurationModelFactory.ConfigurationSetting("key", "value", "label", "ct", eTag, lastModified, true);
            Assert.That(sevenArgs.IsReadOnly, Is.True);
            Assert.That(sevenArgs.Description, Is.Null); // shim forwards description: default
        }

        // ---------- ConfigurationSnapshot ----------

        [Test]
        public void ConfigurationSnapshot_SetsDescription()
        {
            ConfigurationSnapshot snapshot = ConfigurationModelFactory.ConfigurationSnapshot(
                name: "snap",
                description: "desc");

            Assert.That(snapshot.Name, Is.EqualTo("snap"));
            Assert.That(snapshot.Description, Is.EqualTo("desc"));
        }

        [Test]
        public void ConfigurationSnapshot_SetsAllProperties()
        {
            var eTag = new ETag("etag");
            var createdOn = DateTimeOffset.UtcNow;
            var expiresOn = createdOn.AddDays(1);
            var filters = new[] { new ConfigurationSettingsFilter("key") };
            var tags = new Dictionary<string, string> { ["t"] = "v" };

            ConfigurationSnapshot snapshot = ConfigurationModelFactory.ConfigurationSnapshot(
                name: "snap",
                status: ConfigurationSnapshotStatus.Ready,
                filters: filters,
                snapshotComposition: SnapshotComposition.Key,
                createdOn: createdOn,
                expiresOn: expiresOn,
                retentionPeriod: TimeSpan.FromHours(1),
                sizeInBytes: 1024,
                itemCount: 5,
                tags: tags,
                description: "desc",
                eTag: eTag);

            Assert.That(snapshot.Name, Is.EqualTo("snap"));
            Assert.That(snapshot.Status, Is.EqualTo(ConfigurationSnapshotStatus.Ready));
            Assert.That(snapshot.SnapshotComposition, Is.EqualTo(SnapshotComposition.Key));
            Assert.That(snapshot.CreatedOn, Is.EqualTo(createdOn));
            Assert.That(snapshot.ExpiresOn, Is.EqualTo(expiresOn));
            Assert.That(snapshot.RetentionPeriod, Is.EqualTo(TimeSpan.FromHours(1)));
            Assert.That(snapshot.SizeInBytes, Is.EqualTo(1024));
            Assert.That(snapshot.ItemCount, Is.EqualTo(5));
            Assert.That(snapshot.Tags, Is.EquivalentTo(tags));
            Assert.That(snapshot.Description, Is.EqualTo("desc"));
            Assert.That(snapshot.ETag, Is.EqualTo(eTag));
        }

        [Test]
        public void ConfigurationSnapshot_LegacyPositionalArguments_StillBind()
        {
            // Historical 11-arg positional order (no description) -> binds the
            // [EditorBrowsable(Never)] shim, with Description defaulting to null.
            var eTag = new ETag("etag");

            ConfigurationSnapshot snapshot = ConfigurationModelFactory.ConfigurationSnapshot(
                "snap",
                ConfigurationSnapshotStatus.Ready,
                new[] { new ConfigurationSettingsFilter("key") },
                SnapshotComposition.Key,
                DateTimeOffset.UtcNow,
                DateTimeOffset.UtcNow.AddDays(1),
                TimeSpan.FromHours(1),
                1024,
                5,
                new Dictionary<string, string> { ["t"] = "v" },
                eTag);

            Assert.That(snapshot.Name, Is.EqualTo("snap"));
            Assert.That(snapshot.ETag, Is.EqualTo(eTag));
            Assert.That(snapshot.Description, Is.Null);
        }
    }
}

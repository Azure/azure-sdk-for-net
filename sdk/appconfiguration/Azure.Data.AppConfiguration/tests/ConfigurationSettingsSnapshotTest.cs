// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Tests
{
    public class ConfigurationSettingsSnapshotTest
    {
        [Test]
        public void SetRetentionPeriodUsingConstructor()
        {
            var settingSnapshot = new ConfigurationSettingsSnapshot(
                "name",
                SnapshotStatus.Ready,
                new List<SnapshotSettingFilter>(),
                new CompositionType(),
                DateTime.UtcNow,
                DateTime.UtcNow,
                10675199, // retention period
                20,
                20,
                new Dictionary<string, string>(),
                new ETag());

            var retentionPeriod = settingSnapshot.RetentionPeriod;
            Assert.AreEqual(retentionPeriod, TimeSpan.FromSeconds(10675199));
        }

        [Test]
        public void SetRetentionPeriodUsingSetter()
        {
            List<SnapshotSettingFilter> filters = new() { new SnapshotSettingFilter("key", "val") };

            var settingSnapshot = new ConfigurationSettingsSnapshot(filters);
            settingSnapshot.RetentionPeriod = TimeSpan.FromSeconds(10675199);

            Assert.AreEqual(settingSnapshot.RetentionPeriod, TimeSpan.FromSeconds(10675199));
        }
    }
}

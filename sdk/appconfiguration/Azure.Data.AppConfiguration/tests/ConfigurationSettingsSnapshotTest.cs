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
    public class ConfigurationSettingsSnapshotTest
    {
        [Test]
        public void SetRetentionPeriodUsingConstructor()
        {
            var settingSnapshot = new ConfigurationSettingsSnapshot(
                "name",
                SnapshotStatus.Ready,
                1,
                new List<ConfigurationSettingFilter>(),
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
            Assert.AreEqual(settingSnapshot.RetentionPeriodLong, 10675199);
        }

        [Test]
        public void SetRetentionPeriodUsingSetter()
        {
            List<ConfigurationSettingFilter> filters = new() { new ConfigurationSettingFilter("key", "val") };

            var settingSnapshot = new ConfigurationSettingsSnapshot(filters);
            settingSnapshot.RetentionPeriod = TimeSpan.FromSeconds(10675199);

            Assert.AreEqual(settingSnapshot.RetentionPeriod, TimeSpan.FromSeconds(10675199));
            Assert.AreEqual(settingSnapshot.RetentionPeriodLong, 10675199);
        }
    }
}

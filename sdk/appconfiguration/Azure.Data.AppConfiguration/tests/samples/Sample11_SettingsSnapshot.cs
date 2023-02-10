// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Samples
{
    public partial class ConfigurationSamples : SamplesBase<AppConfigurationTestEnvironment>
    {
        [Test]
        [Ignore("Snapshot feature is currently available only in the dogfood version")]
        public void CreateSnapshot()
        {
            var connectionString = TestEnvironment.ConnectionString;
            var client = new ConfigurationClient(connectionString);
            var setting = new ConfigurationSetting("some_key", "some_value");

            try
            {
                client.SetConfigurationSetting(setting);

                // #region Snippet:AzConfigSample11_CreateSnapshot
                List<ConfigurationSettingFilter> snapshotFilter = new(new ConfigurationSettingFilter[] { new ConfigurationSettingFilter(setting.Key) });
                var settingsSnapshot = new ConfigurationSettingsSnapshot(snapshotFilter);

                ConfigurationSettingsSnapshot createdSnapshot = client.CreateSnapshot("some_snapshot", settingsSnapshot);
                Console.WriteLine($"Created configuration setting snapshot is: {createdSnapshot}");
                // #endregion

                // #region Snippet:AzConfigSample11_RetrieveSnapshot
                ConfigurationSettingsSnapshot retrievedSnapshot = client.GetSnapshot("some_snapshot");
                Console.WriteLine($"Retrieved configuration setting snapshot is: {retrievedSnapshot}");
                // #endregion

                Assert.NotNull(retrievedSnapshot);
                Assert.AreEqual(createdSnapshot.Name, retrievedSnapshot.Name);
            }
            finally
            {
                AssertStatus200(client.DeleteConfigurationSetting(setting.Key, setting.Label));
            }
        }

        [Test]
        [Ignore("Snapshot feature is currently available only in the dogfood version")]
        public void UpdateSnapshotStatus()
        {
            var connectionString = TestEnvironment.ConnectionString;
            var client = new ConfigurationClient(connectionString);
            var setting = new ConfigurationSetting("some_key", "some_value");

            try
            {
                client.SetConfigurationSetting(setting);

                List<ConfigurationSettingFilter> snapshotFilter = new(new ConfigurationSettingFilter[] { new ConfigurationSettingFilter(setting.Key) });
                var settingsSnapshot = new ConfigurationSettingsSnapshot(snapshotFilter);

                ConfigurationSettingsSnapshot createdSnapshot = client.CreateSnapshot("some_snapshot", settingsSnapshot);
                Console.WriteLine($"Created configuration setting snapshot is: {createdSnapshot}");

                Assert.NotNull(createdSnapshot);
                Assert.AreEqual("some_snapshot", createdSnapshot.Name);

                // #region Snippet:AzConfigSample11_ArchiveSnapshot
                ConfigurationSettingsSnapshot archivedSnapshot = client.ArchiveSnapshot("some_snapshot");
                Console.WriteLine($"Archived configuration setting snapshot is: {archivedSnapshot}");
                // #endregion

                Assert.AreEqual(SnapshotStatus.Archived, archivedSnapshot.Status);

                // #region Snippet:AzConfigSample11_RecoverSnapshot
                ConfigurationSettingsSnapshot recoveredSnapshot = client.RecoverSnapshot("some_snapshot");
                Console.WriteLine($"Recovered configuration setting snapshot is: {recoveredSnapshot}");
                // #endregion

                Assert.AreEqual(SnapshotStatus.Ready, archivedSnapshot.Status);
            }
            finally
            {
                AssertStatus200(client.DeleteConfigurationSetting(setting.Key, setting.Label));
            }
        }

        [Test]
        [Ignore("Snapshot feature is currently available only in the dogfood version")]
        public void GetSnapshots()
        {
            var connectionString = TestEnvironment.ConnectionString;
            var client = new ConfigurationClient(connectionString);

            var firstSetting = new ConfigurationSetting("first_key", "first_value");
            var secondSetting = new ConfigurationSetting("second_key", "second_value");

            try
            {
            client.SetConfigurationSetting(firstSetting);
            client.SetConfigurationSetting(secondSetting);

            List<ConfigurationSettingFilter> firstSnapshotFilter = new(new ConfigurationSettingFilter[] { new ConfigurationSettingFilter(firstSetting.Key) });
            ConfigurationSettingsSnapshot createdfirstSnapshot = client.CreateSnapshot("first_snapshot", new ConfigurationSettingsSnapshot(firstSnapshotFilter));
            Console.WriteLine($"Created configuration setting snapshot is: {createdfirstSnapshot}");

            Assert.NotNull(createdfirstSnapshot);
            Assert.AreEqual("first_snapshot", createdfirstSnapshot.Name);

            List<ConfigurationSettingFilter> secondSnapshotFilter = new(new ConfigurationSettingFilter[] { new ConfigurationSettingFilter(secondSetting.Key) });
            ConfigurationSettingsSnapshot createdsecondSnapshot = client.CreateSnapshot("second_snapshot", new ConfigurationSettingsSnapshot(secondSnapshotFilter));
            Console.WriteLine($"Created configuration setting snapshot is: {createdsecondSnapshot}");

            Assert.NotNull(createdsecondSnapshot);
            Assert.AreEqual("second_snapshot", createdsecondSnapshot.Name);

            // #region Snippet:Sample_GetSnapshots
            var count = 0;
            foreach (ConfigurationSettingsSnapshot item in client.GetSnapshots())
            {
                count++;
                Console.WriteLine($"Name {item.Name} status {item.Status}");
            }
            // #endregion

            Assert.AreEqual(2, count);
            }
            finally
            {
                AssertStatus200(client.DeleteConfigurationSetting(firstSetting.Key, firstSetting.Label));
                AssertStatus200(client.DeleteConfigurationSetting(secondSetting.Key, secondSetting.Label));
            }
        }

        private static void AssertStatus200(Response response) => Assert.AreEqual(200, response.Status);
    }
}

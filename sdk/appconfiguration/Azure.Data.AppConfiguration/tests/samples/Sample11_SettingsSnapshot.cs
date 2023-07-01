// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Samples
{
    public partial class ConfigurationSamples : SamplesBase<AppConfigurationTestEnvironment>
    {
        [Test]
        public void CreateSnapshotAutomaticPolling()
        {
            var connectionString = TestEnvironment.ConnectionString;
            var client = new ConfigurationClient(connectionString);
            var setting = new ConfigurationSetting("some_key", "some_value");

            try
            {
                client.AddConfigurationSetting(setting);

                #region Snippet:AzConfigSample11_CreateSnapshot_AutomaticPolling
                List<SnapshotSettingFilter> snapshotFilter = new(new SnapshotSettingFilter[] { new SnapshotSettingFilter("some_key") });
                var settingsSnapshot = new ConfigurationSettingsSnapshot(snapshotFilter);

                string snapshotName = "some_snapshot";
#if !SNIPPET
                snapshotName = GenerateSnapshotName();
#endif
                CreateSnapshotOperation createSnapshotOperation = client.CreateSnapshot(WaitUntil.Completed, snapshotName, settingsSnapshot);
                ConfigurationSettingsSnapshot createdSnapshot = createSnapshotOperation.Value;
                Console.WriteLine($"Created configuration setting snapshot: {createdSnapshot.Name}, Status: {createdSnapshot.Status}");
                #endregion

                ConfigurationSettingsSnapshot retrievedSnapshot = client.GetSnapshot(snapshotName);
                Console.WriteLine($"Retrieved configuration setting snapshot: {retrievedSnapshot.Name}, status: {createdSnapshot.Status}");

                Assert.NotNull(retrievedSnapshot);
                Assert.AreEqual(createdSnapshot.Name, retrievedSnapshot.Name);
            }
            finally
            {
                AssertStatus200(client.DeleteConfigurationSetting(setting.Key, setting.Label));
            }
        }

        [Test]
        public void CreateSnapshotAutomaticPollingLater()
        {
            var connectionString = TestEnvironment.ConnectionString;
            var client = new ConfigurationClient(connectionString);
            var setting = new ConfigurationSetting("some_key", "some_value");

            try
            {
                client.AddConfigurationSetting(setting);

                #region Snippet:AzConfigSample11_CreateSnapshot_AutomaticPollingLater
                List<SnapshotSettingFilter> snapshotFilter = new(new SnapshotSettingFilter[] { new SnapshotSettingFilter("some_key") });
                var settingsSnapshot = new ConfigurationSettingsSnapshot(snapshotFilter);

                string snapshotName = "some_snapshot";
#if !SNIPPET
                snapshotName = GenerateSnapshotName();
#endif
                CreateSnapshotOperation createSnapshotOperation = client.CreateSnapshot(WaitUntil.Started, snapshotName, settingsSnapshot);
                createSnapshotOperation.WaitForCompletion();

                ConfigurationSettingsSnapshot createdSnapshot = createSnapshotOperation.Value;
                Console.WriteLine($"Created configuration setting snapshot: {createdSnapshot.Name}, status: {createdSnapshot.Status}");
                #endregion

                ConfigurationSettingsSnapshot retrievedSnapshot = client.GetSnapshot(snapshotName);
                Console.WriteLine($"Retrieved configuration setting snapshot: {retrievedSnapshot.Name}, status: {createdSnapshot.Status}");

                Assert.NotNull(retrievedSnapshot);
                Assert.AreEqual(createdSnapshot.Name, retrievedSnapshot.Name);
            }
            finally
            {
                AssertStatus200(client.DeleteConfigurationSetting(setting.Key, setting.Label));
            }
        }

        [Test]
        public async Task CreateSnapshotManualPolling()
        {
            var connectionString = TestEnvironment.ConnectionString;
            var client = new ConfigurationClient(connectionString);
            var setting = new ConfigurationSetting("some_key", "some_value");

            try
            {
                client.AddConfigurationSetting(setting);

                #region Snippet:AzConfigSample11_CreateSnapshot_ManualPolling
                List<SnapshotSettingFilter> snapshotFilter = new(new SnapshotSettingFilter[] { new SnapshotSettingFilter("some_key") });
                var settingsSnapshot = new ConfigurationSettingsSnapshot(snapshotFilter);

                string snapshotName = "some_snapshot";
#if !SNIPPET
                snapshotName = GenerateSnapshotName();
#endif
                CreateSnapshotOperation createSnapshotOperation = client.CreateSnapshot(WaitUntil.Started, snapshotName, settingsSnapshot);
                while (true)
                {
                    createSnapshotOperation.UpdateStatus();
                    if (createSnapshotOperation.HasCompleted)
                        break;
                    await Task.Delay(1000); // Add some delay for polling
                }

                ConfigurationSettingsSnapshot createdSnapshot = createSnapshotOperation.Value;
                Console.WriteLine($"Created configuration setting snapshot: {createdSnapshot.Name}, status: {createdSnapshot.Status}");
                #endregion

                ConfigurationSettingsSnapshot retrievedSnapshot = client.GetSnapshot(snapshotName);
                Console.WriteLine($"Retrieved configuration setting snapshot: {retrievedSnapshot.Name}, status: {createdSnapshot.Status}");

                Assert.NotNull(retrievedSnapshot);
                Assert.AreEqual(createdSnapshot.Name, retrievedSnapshot.Name);
            }
            finally
            {
                AssertStatus200(client.DeleteConfigurationSetting(setting.Key, setting.Label));
            }
        }

        [Test]
        public void GetSnapshot()
        {
            var connectionString = TestEnvironment.ConnectionString;
            var client = new ConfigurationClient(connectionString);
            var setting = new ConfigurationSetting("some_key", "some_value");

            try
            {
                client.AddConfigurationSetting(setting);

                List<SnapshotSettingFilter> snapshotFilter = new(new SnapshotSettingFilter[] { new SnapshotSettingFilter(setting.Key) });
                var settingsSnapshot = new ConfigurationSettingsSnapshot(snapshotFilter);

                string configSnapshotName = GenerateSnapshotName();
                CreateSnapshotOperation createSnapshotOperation = client.CreateSnapshot(WaitUntil.Completed, configSnapshotName, settingsSnapshot);
                ConfigurationSettingsSnapshot createdSnapshot = createSnapshotOperation.Value;
                Console.WriteLine($"Created configuration setting snapshot: {createdSnapshot.Name}, Status: {createdSnapshot.Status}");

                #region Snippet:AzConfigSample11_GetSnapshot
                string snapshotName = "some_snapshot";
#if !SNIPPET
                snapshotName = configSnapshotName;
#endif
                ConfigurationSettingsSnapshot retrievedSnapshot = client.GetSnapshot(snapshotName);
                Console.WriteLine($"Retrieved configuration setting snapshot: {retrievedSnapshot.Name}, status: {retrievedSnapshot.Status}");
                #endregion

                Assert.NotNull(retrievedSnapshot);
                Assert.AreEqual(createdSnapshot.Name, retrievedSnapshot.Name);
            }
            finally
            {
                AssertStatus200(client.DeleteConfigurationSetting(setting.Key, setting.Label));
            }
        }

        [Test]
        public void ArchiveSnapshot()
        {
            var connectionString = TestEnvironment.ConnectionString;
            var client = new ConfigurationClient(connectionString);
            var setting = new ConfigurationSetting("some_key", "some_value");

            try
            {
                client.AddConfigurationSetting(setting);

                List<SnapshotSettingFilter> snapshotFilter = new(new SnapshotSettingFilter[] { new SnapshotSettingFilter(setting.Key) });
                var settingsSnapshot = new ConfigurationSettingsSnapshot(snapshotFilter);

                string configSnapshotName = GenerateSnapshotName();

                CreateSnapshotOperation createSnapshotOperation = client.CreateSnapshot(WaitUntil.Completed, configSnapshotName, settingsSnapshot);
                ConfigurationSettingsSnapshot createdSnapshot = createSnapshotOperation.Value;
                Console.WriteLine($"Created configuration setting snapshot: {createdSnapshot.Name}, status: {createdSnapshot.Status}");

                Assert.NotNull(createdSnapshot);
                Assert.AreEqual(configSnapshotName, createdSnapshot.Name);
                Assert.AreEqual(SnapshotStatus.Ready, createdSnapshot.Status);

                #region Snippet:AzConfigSample11_ArchiveSnapshot
                string snapshotName = "some_snapshot";
#if !SNIPPET
                snapshotName = configSnapshotName;
#endif
                ConfigurationSettingsSnapshot archivedSnapshot = client.ArchiveSnapshot(snapshotName);
                Console.WriteLine($"Archived configuration setting snapshot: {archivedSnapshot.Name}, status: {archivedSnapshot.Status}");
                #endregion

                Assert.NotNull(archivedSnapshot);
                Assert.AreEqual(SnapshotStatus.Archived, archivedSnapshot.Status);
            }
            finally
            {
                AssertStatus200(client.DeleteConfigurationSetting(setting.Key, setting.Label));
            }
        }

        [Test]
        public void RecoverSnapshot()
        {
            var connectionString = TestEnvironment.ConnectionString;
            var client = new ConfigurationClient(connectionString);
            var setting = new ConfigurationSetting("some_key", "some_value");

            try
            {
                client.AddConfigurationSetting(setting);

                List<SnapshotSettingFilter> snapshotFilter = new(new SnapshotSettingFilter[] { new SnapshotSettingFilter(setting.Key) });
                var settingsSnapshot = new ConfigurationSettingsSnapshot(snapshotFilter);

                string configSnapshotName = GenerateSnapshotName();

                CreateSnapshotOperation createSnapshotOperation = client.CreateSnapshot(WaitUntil.Completed, configSnapshotName, settingsSnapshot);
                ConfigurationSettingsSnapshot createdSnapshot = createSnapshotOperation.Value;
                Console.WriteLine($"Created configuration setting snapshot: {createdSnapshot.Name}, status: {createdSnapshot.Status}");

                Assert.NotNull(createdSnapshot);
                Assert.AreEqual(configSnapshotName, createdSnapshot.Name);
                Assert.AreEqual(SnapshotStatus.Ready, createdSnapshot.Status);

                ConfigurationSettingsSnapshot archivedSnapshot = client.ArchiveSnapshot(configSnapshotName);
                Console.WriteLine($"Archived configuration setting snapshot: {archivedSnapshot.Name}, status: {archivedSnapshot.Status}");

                Assert.AreEqual(SnapshotStatus.Archived, archivedSnapshot.Status);

                #region Snippet:AzConfigSample11_RecoverSnapshot
                string snapshotName = "some_snapshot";
#if !SNIPPET
                snapshotName = configSnapshotName;
#endif
                ConfigurationSettingsSnapshot recoveredSnapshot = client.RecoverSnapshot(snapshotName);
                Console.WriteLine($"Recovered configuration setting snapshot: {recoveredSnapshot.Name}, status: {recoveredSnapshot.Status}");
                #endregion

                Assert.NotNull(recoveredSnapshot);
                Assert.AreEqual(SnapshotStatus.Ready, recoveredSnapshot.Status);
            }
            finally
            {
                AssertStatus200(client.DeleteConfigurationSetting(setting.Key, setting.Label));
            }
        }

        [Test]
        public void GetSnapshots()
        {
            var connectionString = TestEnvironment.ConnectionString;
            var client = new ConfigurationClient(connectionString);

            var firstSetting = new ConfigurationSetting("first_key", "first_value");
            var secondSetting = new ConfigurationSetting("second_key", "second_value");

            try
            {
                client.AddConfigurationSetting(firstSetting);
                client.AddConfigurationSetting(secondSetting);

                List<SnapshotSettingFilter> firstSnapshotFilter = new(new SnapshotSettingFilter[] { new SnapshotSettingFilter(firstSetting.Key) });
                string firstSnapshotName = GenerateSnapshotName("first_snapshot");
                CreateSnapshotOperation createfirstSnapshotOperation = client.CreateSnapshot(WaitUntil.Completed, firstSnapshotName, new ConfigurationSettingsSnapshot(firstSnapshotFilter));
                ConfigurationSettingsSnapshot createdFirstSnapshot = createfirstSnapshotOperation.Value;
                Console.WriteLine($"Created configuration setting snapshot: {createdFirstSnapshot.Name}, status: {createdFirstSnapshot.Status}");

                Assert.NotNull(createdFirstSnapshot);
                Assert.AreEqual(firstSnapshotName, createdFirstSnapshot.Name);

                List<SnapshotSettingFilter> secondSnapshotFilter = new(new SnapshotSettingFilter[] { new SnapshotSettingFilter(secondSetting.Key) });
                string secondSnapshotName = GenerateSnapshotName("second_snapshot");
                CreateSnapshotOperation createdSecondSnapshotOperation = client.CreateSnapshot(WaitUntil.Completed, secondSnapshotName, new ConfigurationSettingsSnapshot(secondSnapshotFilter));
                ConfigurationSettingsSnapshot createdSecondSnapshot = createdSecondSnapshotOperation.Value;
                Console.WriteLine($"Created configuration setting snapshot: {createdSecondSnapshot.Name}, status: {createdFirstSnapshot.Status}");

                Assert.NotNull(createdSecondSnapshot);
                Assert.AreEqual(secondSnapshotName, createdSecondSnapshot.Name);

                #region Snippet:AzConfigSample11_GetSnapshots
                var count = 0;
                foreach (ConfigurationSettingsSnapshot item in client.GetSnapshots())
                {
                    count++;
                    Console.WriteLine($"Retrieved configuration setting snapshot: {item.Name}, status {item.Status}");
                }
                Console.WriteLine($"Total number of snapshots retrieved: {count}");
                #endregion

                Assert.GreaterOrEqual(count, 2);
            }
            finally
            {
                AssertStatus200(client.DeleteConfigurationSetting(firstSetting.Key, firstSetting.Label));
                AssertStatus200(client.DeleteConfigurationSetting(secondSetting.Key, secondSetting.Label));
            }
        }

        [Test]
        public void GetConfigurationSettingsForSnapshot()
        {
            var connectionString = TestEnvironment.ConnectionString;
            var client = new ConfigurationClient(connectionString);

            try
            {
                #region Snippet:AzConfigSample11_GetConfigurationSettingsForSnapshot
                var firstSetting = new ConfigurationSetting("first_key", "first_value");
                client.AddConfigurationSetting(firstSetting);

                var secondSetting = new ConfigurationSetting("second_key", "second_value");
                client.AddConfigurationSetting(secondSetting);

                List<SnapshotSettingFilter> snapshotFilter = new(new SnapshotSettingFilter[] { new SnapshotSettingFilter(firstSetting.Key), new SnapshotSettingFilter(secondSetting.Key) });
                var settingsSnapshot = new ConfigurationSettingsSnapshot(snapshotFilter);

                string snapshotName = "some_snapshot";
#if !SNIPPET
                snapshotName = GenerateSnapshotName();
#endif
                CreateSnapshotOperation createSnapshotOperation = client.CreateSnapshot(WaitUntil.Completed, snapshotName, settingsSnapshot);
                ConfigurationSettingsSnapshot createdSnapshot = createSnapshotOperation.Value;
                Console.WriteLine($"Created configuration setting snapshot: {createdSnapshot.Name}, Status: {createdSnapshot.Status}");

                var count = 0;
                foreach (ConfigurationSetting item in client.GetConfigurationSettingsForSnapshot(snapshotName))
                {
                    count++;
                    Console.WriteLine($"Retrieved configuration setting: {item.Key}");
                }
                Console.WriteLine($"Total number of retrieved Configuration Settings for snapshot {snapshotName}: {count}");
                #endregion

                Assert.GreaterOrEqual(count, 2);
            }
            finally
            {
                AssertStatus200(client.DeleteConfigurationSetting("first_key"));
                AssertStatus200(client.DeleteConfigurationSetting("second_key"));
            }
        }

        private static string GenerateSnapshotName(string prefix = "snapshot-")
        {
            return prefix + Guid.NewGuid();
        }

        private static void AssertStatus200(Response response) => Assert.AreEqual(200, response.Status);
    }
}

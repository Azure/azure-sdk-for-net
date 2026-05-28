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
                var settingsFilter = new List<ConfigurationSettingsFilter> { new ConfigurationSettingsFilter("some_key") };
                var settingsSnapshot = new ConfigurationSnapshot(settingsFilter);

                var snapshotName = "some_snapshot";
#if !SNIPPET
                snapshotName = GenerateSnapshotName();
#endif
                var operation = client.CreateSnapshot(WaitUntil.Completed, snapshotName, settingsSnapshot);
                var createdSnapshot = operation.Value;
                Console.WriteLine($"Created configuration snapshot: {createdSnapshot.Name}, Status: {createdSnapshot.Status}");
                #endregion

                ConfigurationSnapshot retrievedSnapshot = client.GetSnapshot(snapshotName);
                Console.WriteLine($"Retrieved configuration snapshot: {retrievedSnapshot.Name}, status: {createdSnapshot.Status}");

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
                var settingsFilter = new List<ConfigurationSettingsFilter> { new ConfigurationSettingsFilter("some_key") };
                var settingsSnapshot = new ConfigurationSnapshot(settingsFilter);

                var snapshotName = "some_snapshot";
#if !SNIPPET
                snapshotName = GenerateSnapshotName();
#endif
                var operation = client.CreateSnapshot(WaitUntil.Started, snapshotName, settingsSnapshot);
                operation.WaitForCompletion();

                var createdSnapshot = operation.Value;
                Console.WriteLine($"Created configuration snapshot: {createdSnapshot.Name}, status: {createdSnapshot.Status}");
                #endregion

                ConfigurationSnapshot retrievedSnapshot = client.GetSnapshot(snapshotName);
                Console.WriteLine($"Retrieved configuration snapshot: {retrievedSnapshot.Name}, status: {createdSnapshot.Status}");

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
                var settingsFilter = new List<ConfigurationSettingsFilter> { new ConfigurationSettingsFilter("some_key") };
                var settingsSnapshot = new ConfigurationSnapshot(settingsFilter);

                var snapshotName = "some_snapshot";
#if !SNIPPET
                snapshotName = GenerateSnapshotName();
#endif
                var operation = client.CreateSnapshot(WaitUntil.Started, snapshotName, settingsSnapshot);
                while (true)
                {
                    operation.UpdateStatus();
                    if (operation.HasCompleted)
                        break;
                    await Task.Delay(1000); // Add some delay for polling
                }

                var createdSnapshot = operation.Value;
                Console.WriteLine($"Created configuration snapshot: {createdSnapshot.Name}, status: {createdSnapshot.Status}");
                #endregion

                ConfigurationSnapshot retrievedSnapshot = client.GetSnapshot(snapshotName);
                Console.WriteLine($"Retrieved configuration snapshot: {retrievedSnapshot.Name}, status: {createdSnapshot.Status}");

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

                var settingsFilter = new List<ConfigurationSettingsFilter> { new ConfigurationSettingsFilter(setting.Key) };
                var settingsSnapshot = new ConfigurationSnapshot(settingsFilter);

                var configSnapshotName = GenerateSnapshotName();
                var operation = client.CreateSnapshot(WaitUntil.Completed, configSnapshotName, settingsSnapshot);
                var createdSnapshot = operation.Value;
                Console.WriteLine($"Created configuration snapshot: {createdSnapshot.Name}, Status: {createdSnapshot.Status}");

                #region Snippet:AzConfigSample11_GetSnapshot
                var snapshotName = "some_snapshot";
#if !SNIPPET
                snapshotName = configSnapshotName;
#endif
                ConfigurationSnapshot retrievedSnapshot = client.GetSnapshot(snapshotName);
                Console.WriteLine($"Retrieved configuration snapshot: {retrievedSnapshot.Name}, status: {retrievedSnapshot.Status}");
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

                var settingsFilter = new List<ConfigurationSettingsFilter> { new ConfigurationSettingsFilter(setting.Key) };
                var settingsSnapshot = new ConfigurationSnapshot(settingsFilter);

                var configSnapshotName = GenerateSnapshotName();

                var operation = client.CreateSnapshot(WaitUntil.Completed, configSnapshotName, settingsSnapshot);
                var createdSnapshot = operation.Value;
                Console.WriteLine($"Created configuration snapshot: {createdSnapshot.Name}, status: {createdSnapshot.Status}");

                Assert.NotNull(createdSnapshot);
                Assert.AreEqual(configSnapshotName, createdSnapshot.Name);
                Assert.AreEqual(ConfigurationSnapshotStatus.Ready, createdSnapshot.Status);

                #region Snippet:AzConfigSample11_ArchiveSnapshot
                var snapshotName = "some_snapshot";
#if !SNIPPET
                snapshotName = configSnapshotName;
#endif
                ConfigurationSnapshot archivedSnapshot = client.ArchiveSnapshot(snapshotName);
                Console.WriteLine($"Archived configuration snapshot: {archivedSnapshot.Name}, status: {archivedSnapshot.Status}");
                #endregion

                Assert.NotNull(archivedSnapshot);
                Assert.AreEqual(ConfigurationSnapshotStatus.Archived, archivedSnapshot.Status);
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

                var settingsFilter = new List<ConfigurationSettingsFilter> { new ConfigurationSettingsFilter(setting.Key) };
                var settingsSnapshot = new ConfigurationSnapshot(settingsFilter);

                var configSnapshotName = GenerateSnapshotName();

                var operation = client.CreateSnapshot(WaitUntil.Completed, configSnapshotName, settingsSnapshot);
                var createdSnapshot = operation.Value;
                Console.WriteLine($"Created configuration snapshot: {createdSnapshot.Name}, status: {createdSnapshot.Status}");

                Assert.NotNull(createdSnapshot);
                Assert.AreEqual(configSnapshotName, createdSnapshot.Name);
                Assert.AreEqual(ConfigurationSnapshotStatus.Ready, createdSnapshot.Status);

                ConfigurationSnapshot archivedSnapshot = client.ArchiveSnapshot(configSnapshotName);
                Console.WriteLine($"Archived configuration snapshot: {archivedSnapshot.Name}, status: {archivedSnapshot.Status}");

                Assert.AreEqual(ConfigurationSnapshotStatus.Archived, archivedSnapshot.Status);

                #region Snippet:AzConfigSample11_RecoverSnapshot
                var snapshotName = "some_snapshot";
#if !SNIPPET
                snapshotName = configSnapshotName;
#endif
                ConfigurationSnapshot recoveredSnapshot = client.RecoverSnapshot(snapshotName);
                Console.WriteLine($"Recovered configuration snapshot: {recoveredSnapshot.Name}, status: {recoveredSnapshot.Status}");
                #endregion

                Assert.NotNull(recoveredSnapshot);
                Assert.AreEqual(ConfigurationSnapshotStatus.Ready, recoveredSnapshot.Status);
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

                var firstSnapshotFilter = new List<ConfigurationSettingsFilter> { new ConfigurationSettingsFilter(firstSetting.Key) };
                var firstSnapshotName = GenerateSnapshotName("first_snapshot");
                var firstOperation = client.CreateSnapshot(WaitUntil.Completed, firstSnapshotName, new ConfigurationSnapshot(firstSnapshotFilter));
                var createdFirstSnapshot = firstOperation.Value;
                Console.WriteLine($"Created configuration snapshot: {createdFirstSnapshot.Name}, status: {createdFirstSnapshot.Status}");

                Assert.NotNull(createdFirstSnapshot);
                Assert.AreEqual(firstSnapshotName, createdFirstSnapshot.Name);

                var secondSnapshotFilter = new List<ConfigurationSettingsFilter> { new ConfigurationSettingsFilter(secondSetting.Key) };
                var secondSnapshotName = GenerateSnapshotName("second_snapshot");
                var secondOperation = client.CreateSnapshot(WaitUntil.Completed, secondSnapshotName, new ConfigurationSnapshot(secondSnapshotFilter));
                var createdSecondSnapshot = secondOperation.Value;
                Console.WriteLine($"Created configuration snapshot: {createdSecondSnapshot.Name}, status: {createdFirstSnapshot.Status}");

                Assert.NotNull(createdSecondSnapshot);
                Assert.AreEqual(secondSnapshotName, createdSecondSnapshot.Name);

                #region Snippet:AzConfigSample11_GetSnapshots
                var count = 0;
                foreach (var item in client.GetSnapshots(new SnapshotSelector()))
                {
                    count++;
                    Console.WriteLine($"Retrieved configuration snapshot: {item.Name}, status {item.Status}");
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

                var settingsFilter = new List<ConfigurationSettingsFilter> { new ConfigurationSettingsFilter(firstSetting.Key), new ConfigurationSettingsFilter(secondSetting.Key) };
                var settingsSnapshot = new ConfigurationSnapshot(settingsFilter);

                var snapshotName = "some_snapshot";
#if !SNIPPET
                snapshotName = GenerateSnapshotName();
#endif
                var operation = client.CreateSnapshot(WaitUntil.Completed, snapshotName, settingsSnapshot);
                var createdSnapshot = operation.Value;
                Console.WriteLine($"Created configuration snapshot: {createdSnapshot.Name}, Status: {createdSnapshot.Status}");

                var count = 0;
                foreach (var item in client.GetConfigurationSettingsForSnapshot(snapshotName))
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

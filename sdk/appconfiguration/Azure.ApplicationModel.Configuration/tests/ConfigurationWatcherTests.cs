// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using NUnit.Framework;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace Azure.ApplicationModel.Configuration.Tests
{
    [Category("Live")]
    public class ConfigurationWatcherTests
    {
        [Test]
        public async Task Helpers()
        {
            ConfigurationClient client = new ConfigurationClient(TestEnvironment.GetClientConnectionString());TestEnvironment.GetClientConnectionString();
            var source = new CancellationTokenSource();

            const int numberOfSettings = 2;

            // key prefix used to partition tests running at the same time so that they don't interract with each other
            var testPartition = Guid.NewGuid().ToString();

            var addedSettings = new List<ConfigurationSetting>(numberOfSettings);

            try {
                // add settings to the store
                for (int i = 0; i < numberOfSettings; i++) {
                    ConfigurationSetting setting = await client.AddAsync(new ConfigurationSetting($"{testPartition}_{i}", i.ToString()));
                    addedSettings.Add(setting);
                }

                var changed = new List<ConfigurationWatcher.SettingChangedEventArgs>(); // acumulator for detected changes
                var watcher = new ConfigurationWatcher(client, addedSettings.Select((setting) => setting.Key).ToArray());
                watcher.SettingChanged += (sender, e) =>
                {
                    changed.Add(e);
                };
                watcher.Error += (sender, e) =>
                {
                    Assert.Fail(e.Message);
                };

                // start watching for changes
                watcher.Start();

                // do updates in the service store
                for (int i = 0; i < numberOfSettings; i++) {
                    var updated = addedSettings[i];
                    updated.Value = (i + 100).ToString();
                    var response = await client.UpdateAsync(updated);
                }

                // wait for updates to be detected
                await Task.Delay(2000);
                await watcher.Stop();

                // assert expectations
                Assert.AreEqual(numberOfSettings, changed.Count);
            }
            finally {
                // delete settings from the service store
                foreach (var setting in addedSettings) {
                    var response = await client.DeleteAsync(setting.Key);
                    if (response.Status != 200) {
                        throw new Exception("could not delete setting " + setting.Key);
                    }
                }
            }
        }

        [Test]
        public async Task WatcherSample()
        {
            // Retrieve the connection string from the configuration store.
            // You can get the string from your Azure portal.
            var connectionString = Environment.GetEnvironmentVariable("APP_CONFIG_CONNECTION");

            // Instantiate a client that will be used to call the service.
            var client = new ConfigurationClient(connectionString);

            // Setup the watcher to watch "key1" and "key2"
            var watcher = new ConfigurationWatcher(client, "key1", "key2");
            watcher.SettingChanged += (sender, e) =>
            {
                Console.WriteLine($"old value: {e.Older.Value}");
                Console.WriteLine($"new value: {e.Newer.Value}");
            };
            // Print errors occuring during watching
            watcher.Error += (sender, e) =>
            {
                Console.WriteLine($"Error {e.Message}");
            };

            // start watching
            watcher.Start();

            // watch for 1 second
            await Task.Delay(1000);

            // stop watching
            await watcher.Stop();
        }
    }
}

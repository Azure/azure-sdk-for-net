// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using NUnit.Framework;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using static Azure.ApplicationModel.Configuration.ConfigurationWatcher;

namespace Azure.ApplicationModel.Configuration.Tests
{
    [Category("Live")]
    public class ConfigurationWatcherTests
    {
        [Test]
        public async Task Helpers()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            Assert.NotNull(connectionString, "Set AZ_CONFIG_CONNECTION environment variable to the connection string");

            var client = new ConfigurationClient(connectionString);
            var source = new CancellationTokenSource();

            const int numberOfSettings = 2;

            // key prexfix used to partition tests running at the same time so that they don't interract with each other
            var testPartition = Guid.NewGuid().ToString();

            var addedSettings = new List<ConfigurationSetting>(numberOfSettings);

            try {
                // add settings to the store
                for (int i = 0; i < numberOfSettings; i++) {
                    var reponse = await client.AddAsync(new ConfigurationSetting($"{testPartition}_{i}", i.ToString()));
                    Assert.AreEqual(200, reponse.Status);
                    addedSettings.Add(reponse.Result);
                }

                var changed = new List<SettingChangedEventArgs>(); // acumulator for detected changes
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
    }
}
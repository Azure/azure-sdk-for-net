// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Azure.ApplicationModel.Configuration.Samples
{
    [Category("Live")]
    public partial class ConfigurationSamples
    {
        [Test]
        public async Task Watcher()
        {
            // Retrieve the connection string from the configuration store. 
            // You can get the string from your Azure portal.
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");

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

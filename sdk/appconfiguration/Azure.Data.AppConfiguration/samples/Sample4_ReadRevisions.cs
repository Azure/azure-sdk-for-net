// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.


using NUnit.Framework;
using System;
using System.Diagnostics;

namespace Azure.Data.AppConfiguration.Samples
{
    [Category("Live")]
    public partial class ConfigurationSamples
    {
        [Test]
        public void ReadRevisions()
        {
            // Retrieve the connection string from the configuration store. 
            // You can get the string from your Azure portal.
            var connectionString = Environment.GetEnvironmentVariable("APPCONFIGURATION_CONNECTION_STRING");

            // Instantiate a client that will be used to call the service.
            var client = new ConfigurationClient(connectionString);

            // Create a Configuration Setting to be stored in the Configuration
            // Store to illustrate revision history.
            var setting = new ConfigurationSetting("revised_key", "value1");

            // Set the initial value
            client.Set(setting);

            setting.Value = "value2";

            // Update to the second value.
            client.Set(setting);

            var selector = new SettingSelector("revised_key");

            foreach (var response in client.GetRevisions(selector))
            {
                var settingVersion = response.Value;
                Debug.WriteLine($"Setting: {settingVersion}, ETag: {settingVersion.ETag}, LastModified: {settingVersion.LastModified}");
            }

            // Delete the setting since it's no longer needed.
            client.Delete(setting.Key);
        }
    }
}

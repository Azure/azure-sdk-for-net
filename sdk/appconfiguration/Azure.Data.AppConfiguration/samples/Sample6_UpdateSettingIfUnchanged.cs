// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Samples
{
    [LiveOnly]
    public partial class ConfigurationSamples
    {
        [Test]
        /*
         * This sample ilustrates how to update a setting in the configuration
         * store only when the store holds same version it did when you last
         * retrieved it from the configuration store, as determined by whether
         * the client and service setting ETags match.  This ensures our client
         * will not overwrite updates applied to the setting from other sources.
         */
        public void UpdateSettingIfUnchanged()
        {
            // Retrieve the connection string from the environment.
            // The connection string is available from the App Configuration Access Keys view in the Azure Portal.
            var connectionString = Environment.GetEnvironmentVariable("APPCONFIGURATION_CONNECTION_STRING");

            // Instantiate a client that will be used to call the service.
            var client = new ConfigurationClient(connectionString);

            // Create a Configuration Setting for this sample.
            ConfigurationSetting setting = new ConfigurationSetting("available_vms", "10");

            // Add the setting to the Configuration Store.
            setting = client.SetConfigurationSetting(setting);

            // Here we invoke code that releases VMs from our application's pool of resources.
            // After this completes, we will update the total number of available VMs
            int releasedVMs = ReleaseVMs(vmsToRelease: 2);

            // Modify the setting before updating it in the Configuration Store.
            int availableVMCount = int.Parse(setting.Value);
            setting.Value = (availableVMCount + releasedVMs).ToString();

            // Update the value only if it hasn't been updated by another client,
            // so that updates from other sources don't get overwritten.
            ConfigurationSetting updatedSetting = null;
            bool hasChanged;
            do
            {
                try
                {
                    updatedSetting = client.SetConfigurationSetting(setting, onlyIfUnchanged: true);
                    hasChanged = false;
                }
                catch (RequestFailedException e) when (e.Status == 412)
                {
                    hasChanged = true;

                    // The setting has been modified since the last time our client retrieved it from the service.
                    // Get the latest value and re-apply our update logic before attempting to set it again on the service.
                    setting = client.GetConfigurationSetting(setting);

                    availableVMCount = int.Parse(setting.Value);
                    setting.Value = (availableVMCount + releasedVMs).ToString();
                }
            }
            while (hasChanged);

            Debug.WriteLine($"Setting after update was applied: {updatedSetting}");

            // Delete the Configuration Setting from the Configuration Store.
            client.DeleteConfigurationSetting("available_vms");
        }

        private int ReleaseVMs(int vmsToRelease)
        {
            // Code to release a VM and give it back to our application's shared pool.

            // In a real system, we would count how many VMs were successfully released and return that number.
            return vmsToRelease;
        }
    }
}

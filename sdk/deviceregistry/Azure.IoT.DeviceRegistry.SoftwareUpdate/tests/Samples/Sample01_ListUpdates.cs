// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.IoT.DeviceRegistry._SoftwareUpdate.Tests.Samples
{
    public class Sample01_ListUpdates
    {
        [Test]
        [Ignore("Only used to verify that the sample compiles")]
        public async Task ListUpdatesAsync()
        {
            #region Snippet:DeviceRegistrySoftwareUpdate_ListUpdatesAsync
            string endpoint = Environment.GetEnvironmentVariable("DEVICE_REGISTRY_SOFTWARE_UPDATE_ENDPOINT")
                ?? throw new InvalidOperationException("Set DEVICE_REGISTRY_SOFTWARE_UPDATE_ENDPOINT before running this example.");

            var client = new DeviceRegistrySoftwareUpdateClient(
                new Uri(endpoint),
                new DefaultAzureCredential());

            SoftwareUpdate softwareUpdate = client.GetSoftwareUpdateClient();

            await foreach (UpdateContent update in softwareUpdate.GetUpdatesAsync())
            {
                Console.WriteLine($"{update.UpdateId.Provider}/{update.UpdateId.Name}/{update.UpdateId.Version}");
            }
            #endregion
        }
    }
}
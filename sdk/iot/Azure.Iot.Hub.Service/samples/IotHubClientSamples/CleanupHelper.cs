// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Iot.Hub.Service.Models;

namespace Azure.Iot.Hub.Service.Samples
{
    /// <summary>
    /// Helper class to help cleanup resources created by the sample runs.
    /// </summary>
    public static class CleanupHelper
    {
        public async static Task DeleteAllDevicesInHubAsync(IotHubServiceClient hubClient)
        {
            Console.WriteLine($"\nTrying to clean up all devices\n");

            try
            {
                AsyncPageable<TwinData> asyncPageableResponse = hubClient.Devices.GetTwinsAsync();
                List<TwinData> deviceTwins = new List<TwinData>();
                await foreach (TwinData twin in asyncPageableResponse)
                {
                    deviceTwins.Add(twin);
                }

                foreach (TwinData twin in deviceTwins)
                {
                    DeviceIdentity device = await hubClient.Devices.GetIdentityAsync(twin.DeviceId);
                    await hubClient.Devices.DeleteIdentityAsync(device);
                }

                SampleLogger.PrintSuccess($"Cleanup succeeded\n");
            }
            catch (Exception ex)
            {
                SampleLogger.PrintWarning($"Cleanup failed due to:\n{ex.Message}\n");
            }
        }
    }
}

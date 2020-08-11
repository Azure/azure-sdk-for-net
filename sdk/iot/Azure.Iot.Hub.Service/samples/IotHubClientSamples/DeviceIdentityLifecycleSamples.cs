// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Iot.Hub.Service.Models;

namespace Azure.Iot.Hub.Service.Samples
{
    /// <summary>
    /// This sample goes through the lifecycle of a Device Identity for a device.
    /// </summary>
    internal class DeviceIdentityLifecycleSamples
    {
        public readonly IotHubServiceClient IoTHubServiceClient;
        public const int MaxRandomValue = 200;
        public static readonly Random Random = new Random();

        public DeviceIdentityLifecycleSamples(IotHubServiceClient client)
        {
            IoTHubServiceClient = client;
        }

        public async Task RunSampleAsync()
        {
            string deviceId = $"device{Random.Next(MaxRandomValue)}";

            // Create a DeviceIdentity.
            await CreateDeviceIdentityAsync(deviceId);

            // Get the Device Identity.
            await GetDeviceIdentityAsync(deviceId);

            // Update Device Identity.
            await UpdateDeviceIdentityAsync(deviceId);

            // Get Device Twin.
            await GetDeviceTwinAsync(deviceId);

            // Update Device Twin.
            await UpdateDeviceTwinAsync(deviceId);

            // Delete the device.
            await DeleteDeviceIdentityAsync(deviceId);
        }

        /// <summary>
        /// Creates a new device identity.
        /// </summary>
        /// <param name="deviceId">Unique identifier of the device.</param>
        public async Task<DeviceIdentity> CreateDeviceIdentityAsync(string deviceId)
        {
            SampleLogger.PrintHeader("CREATE DEVICE IDENTITY");

            // Construct the device identity object.
            var deviceIdentity = new DeviceIdentity
            {
                DeviceId = deviceId
            };

            try
            {
                Console.WriteLine($"Creating a new device with Id '{deviceId}'");

                Response<DeviceIdentity> response = await IoTHubServiceClient.Devices.CreateOrUpdateIdentityAsync(deviceIdentity);

                SampleLogger.PrintSuccess($"Successfully create a new device identity with Id: '{response.Value.DeviceId}', ETag: '{response.Value.Etag}'");

                return response.Value;
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to create device identity due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Get a device identity.
        /// </summary>
        /// <param name="deviceId">Unique identifier of the device the device belongs to.</param>
        /// <param name="deviceId">Unique identifier of the device to get.</param>
        public async Task<DeviceIdentity> GetDeviceIdentityAsync(string deviceId)
        {
            SampleLogger.PrintHeader("GET A DEVICE");

            try
            {
                Console.WriteLine($"Getting device identity with Id: '{deviceId}'\n");

                Response<DeviceIdentity> response = await IoTHubServiceClient.Devices.GetIdentityAsync(deviceId);

                DeviceIdentity deviceIdentity = response.Value;

                SampleLogger.PrintSuccess($"\t- Device Id: '{deviceIdentity.DeviceId}', ETag: '{deviceIdentity.Etag}'");

                return deviceIdentity;
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to get a device identity due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Update a device identity.
        /// </summary>
        /// <param name="deviceId">Unique identifier of the device to be updated.</param>
        public async Task<DeviceIdentity> UpdateDeviceIdentityAsync(string deviceId)
        {
            SampleLogger.PrintHeader("UPDATE A DEVICE");

            try
            {
                Response<DeviceIdentity> getResponse = await IoTHubServiceClient.Devices.GetIdentityAsync(deviceId);

                DeviceIdentity deviceIdentity = getResponse.Value;
                Console.WriteLine($"Current device identity: DeviceId: '{deviceIdentity.DeviceId}', Status: '{deviceIdentity.Status}', ETag: '{deviceIdentity.Etag}'");

                Console.WriteLine($"Updating device identity with Id: '{deviceIdentity.DeviceId}'. Disabling device so it cannot connect to IoT Hub.");
                deviceIdentity.Status = DeviceStatus.Disabled;

                Response<DeviceIdentity> response = await IoTHubServiceClient.Devices.CreateOrUpdateIdentityAsync(deviceIdentity);

                DeviceIdentity updatedDevice = response.Value;

                SampleLogger.PrintSuccess($"Successfully updated device identity: DeviceId: '{updatedDevice.DeviceId}', DeviceId: '{updatedDevice.DeviceId}', Status: '{updatedDevice.Status}', ETag: '{updatedDevice.Etag}'");

                return updatedDevice;
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to update a device identity due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Get device twin.
        /// </summary>
        /// <param name="deviceId">Unique identifier of the device to be updated.</param>
        public async Task<TwinData> GetDeviceTwinAsync(string deviceId)
        {
            SampleLogger.PrintHeader("GET A DEVICE TWIN");

            try
            {
                Console.WriteLine($"Getting device twin with Id: '{deviceId}'");

                Response<TwinData> response = await IoTHubServiceClient.Devices.GetTwinAsync(deviceId);

                SampleLogger.PrintSuccess($"\t- Device Twin: DeviceId: '{response.Value.DeviceId}', Status: '{response.Value.Status}', ETag: '{response.Value.Etag}'");

                return response.Value;
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to get a device twin due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Update a device twin desired properties.
        /// </summary>
        /// <param name="deviceId">Unique identifier of the device to be updated.</param>
        public async Task<TwinData> UpdateDeviceTwinAsync(string deviceId)
        {
            SampleLogger.PrintHeader("UPDATE A DEVICE TWIN");

            string userPropName = "user";

            try
            {
                // Get the device device
                Response<TwinData> getResponse = await IoTHubServiceClient.Devices.GetTwinAsync(deviceId);
                TwinData deviceTwin = getResponse.Value;

                Console.WriteLine($"Updating device twin: DeviceId: '{deviceTwin.DeviceId}', ETag: '{deviceTwin.Etag}'");
                Console.WriteLine($"Setting a new desired property {userPropName} to: '{Environment.UserName}'");

                deviceTwin.Properties.Desired.Add(new KeyValuePair<string, object>(userPropName, Environment.UserName));

                Response<TwinData> response = await IoTHubServiceClient.Devices.UpdateTwinAsync(deviceTwin);

                TwinData updatedTwin = response.Value;

                var userPropValue = (string)updatedTwin.Properties.Desired
                    .Where(p => p.Key == userPropName)
                    .First()
                    .Value;

                SampleLogger.PrintSuccess($"Successfully updated device twin: DeviceId: '{updatedTwin.DeviceId}', desired property: ['{userPropName}': '{userPropValue}'], ETag: '{updatedTwin.Etag}',");

                return updatedTwin;
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to update a device identity due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Deletes a device identity.
        /// </summary>
        /// <param name="deviceId">Unique identifier of the device.</param>
        public async Task DeleteDeviceIdentityAsync(string deviceId)
        {
            SampleLogger.PrintHeader("DELETE DEVICE IDENTITY");

            try
            {
                // Get the device identity first.
                Response<DeviceIdentity> getResponse = await IoTHubServiceClient.Devices.GetIdentityAsync(deviceId);
                DeviceIdentity deviceIdentity = getResponse.Value;

                Console.WriteLine($"Deleting device identity with Id: '{deviceIdentity.DeviceId}'");

                Response response = await IoTHubServiceClient.Devices.DeleteIdentityAsync(deviceIdentity);

                SampleLogger.PrintSuccess($"Successfully deleted device identity with Id: '{deviceIdentity.DeviceId}'");
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to device identity due to:\n{ex}");
            }
        }
    }
}

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
    /// This sample goes through the lifecycle of multiple Device Identities for multiple devices. It utilizes
    /// bulk APIs that allow for creating, updating, and deleting of up to 100 device identities at a time.
    /// There are also bulk APIs for updating twins on up to 100 devices at time
    /// </summary>
    internal class BulkDeviceIdentityLifecycleSamples
    {
        public readonly IoTHubServiceClient IoTHubServiceClient;
        public const int MaxRandomValue = 200;
        public static readonly Random Random = new Random();

        // Can be 1 to 100, configures how many devices to create/update/delete per service API call
        public const int BulkCount = 20;

        public BulkDeviceIdentityLifecycleSamples(IoTHubServiceClient client)
        {
            IoTHubServiceClient = client;
        }

        public async Task RunSampleAsync()
        {
            List<DeviceIdentity> deviceIdentities = new List<DeviceIdentity>();
            for (int deviceIndex = 0; deviceIndex < BulkCount; deviceIndex++)
            {
                deviceIdentities.Add(
                    new DeviceIdentity()
                    {
                        DeviceId = $"device_{deviceIndex}_{Random.Next(MaxRandomValue)}"
                    });
            }

            // Create multiple DeviceIdentities.
            await CreateDeviceIdentitiesAsync(deviceIdentities);

            // Get the created devices from the service
            IEnumerable<DeviceIdentity> createdIdentities = await GetDeviceIdentities(deviceIdentities.Select(identity => identity.DeviceId).ToArray());

            // Update multiple DeviceIdentities.
            await UpdateDeviceIdentitiesAsync(createdIdentities);

            // Get the updated devices from the service
            IEnumerable<TwinData> deviceTwins = await GetDeviceTwins(deviceIdentities.Select(identity => identity.DeviceId).ToArray());

            // Update Device Twin.
            await UpdateDeviceTwinsAsync(deviceTwins);

            // Get the updated devices from the service
            IEnumerable<DeviceIdentity> identitiesBeforeDelete = await GetDeviceIdentities(deviceIdentities.Select(identity => identity.DeviceId).ToArray());

            // Delete the device.
            await DeleteDeviceIdentitiesAsync(identitiesBeforeDelete);
        }

        /// <summary>
        /// Creates a new device identity.
        /// </summary>
        /// <param name="deviceId">Unique identifier of the device.</param>
        public async Task CreateDeviceIdentitiesAsync(IEnumerable<DeviceIdentity> deviceIdentities)
        {
            SampleLogger.PrintHeader("CREATE DEVICE IDENTITIES");

            try
            {
                Console.WriteLine($"Creating {BulkCount} new devices");

                Response<BulkRegistryOperationResponse> response = await IoTHubServiceClient.Devices.CreateIdentitiesAsync(deviceIdentities);

                var bulkResponse = response.Value;

                if (bulkResponse.IsSuccessful ?? true)
                {
                    SampleLogger.PrintSuccess("Successfully created new device identities");
                }
                else
                {
                    SampleLogger.PrintWarning("Failed to create new device identities");

                    foreach (var bulkOperationError in bulkResponse.Errors)
                    {
                        SampleLogger.PrintWarning($"Device id that failed: {bulkOperationError.DeviceId}, error code: {bulkOperationError.ErrorCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to create device identity due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Update a device identity.
        /// </summary>
        /// <param name="deviceId">Unique identifier of the device to be updated.</param>
        public async Task UpdateDeviceIdentitiesAsync(IEnumerable<DeviceIdentity> deviceIdentities)
        {
            SampleLogger.PrintHeader("UPDATE DEVICE IDENTITIES");

            try
            {
                Console.WriteLine($"Disabling multiple devices so they cannot connect to IoT Hub.");
                foreach (var identity in deviceIdentities)
                {
                    identity.Status = DeviceStatus.Disabled;
                }

                Response<BulkRegistryOperationResponse> response = await IoTHubServiceClient.Devices.UpdateIdentitiesAsync(deviceIdentities, BulkIfMatchPrecondition.IfMatch);
                var bulkResponse = response.Value;

                if (bulkResponse.IsSuccessful ?? true)
                {
                    SampleLogger.PrintSuccess("Successfully disabled the device identities");
                }
                else
                {
                    SampleLogger.PrintWarning("Failed to disable the device identities");

                    foreach (var bulkOperationError in bulkResponse.Errors)
                    {
                        SampleLogger.PrintWarning($"Device id that failed: {bulkOperationError.DeviceId}, error code: {bulkOperationError.ErrorCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to update a device identity due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Update a device twin desired properties.
        /// </summary>
        /// <param name="deviceId">Unique identifier of the device to be updated.</param>
        public async Task UpdateDeviceTwinsAsync(IEnumerable<TwinData> deviceTwins)
        {
            SampleLogger.PrintHeader("UPDATE DEVICE TWINS");

            string userPropName = "user";

            try
            {
                // Get the device device
                Console.WriteLine($"Setting a new desired property {userPropName} to: '{Environment.UserName}' for each twin");
                foreach (TwinData twin in deviceTwins)
                {
                    twin.Properties.Desired.Add(new KeyValuePair<string, object>(userPropName, Environment.UserName));
                }

                Response<BulkRegistryOperationResponse> response = await IoTHubServiceClient.Devices.UpdateTwinsAsync(deviceTwins);
                var bulkResponse = response.Value;

                if (bulkResponse.IsSuccessful ?? true)
                {
                    SampleLogger.PrintSuccess("Successfully updated the device twins");
                }
                else
                {
                    SampleLogger.PrintWarning("Failed to update the device twins");

                    foreach (var bulkOperationError in bulkResponse.Errors)
                    {
                        SampleLogger.PrintWarning($"Device id that failed: {bulkOperationError.DeviceId}, error code: {bulkOperationError.ErrorCode}");
                    }
                }
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
        public async Task DeleteDeviceIdentitiesAsync(IEnumerable<DeviceIdentity> deviceIdentities)
        {
            SampleLogger.PrintHeader("DELETE DEVICE IDENTITIES");

            try
            {
                Console.WriteLine($"Deleting bulk device identities");

                Response<BulkRegistryOperationResponse> response = await IoTHubServiceClient.Devices.DeleteIdentitiesAsync(deviceIdentities);
                var bulkResponse = response.Value;

                if (bulkResponse.IsSuccessful ?? true)
                {
                    SampleLogger.PrintSuccess("Successfully deleted the device identities");
                }
                else
                {
                    SampleLogger.PrintWarning("Failed to delete the device identities");

                    foreach (var bulkOperationError in bulkResponse.Errors)
                    {
                        SampleLogger.PrintWarning($"Device id that failed: {bulkOperationError.DeviceId}, error code: {bulkOperationError.ErrorCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to device identity due to:\n{ex}");
            }
        }

        /// <summary>
        /// Gets the list of device identities that was created for this sample
        /// </summary>
        public async Task<IEnumerable<DeviceIdentity>> GetDeviceIdentities(string[] deviceIds)
        {
            List<DeviceIdentity> retrievedIdentities = new List<DeviceIdentity>();
            for (int deviceIndex = 0; deviceIndex < BulkCount; deviceIndex++)
            {
                retrievedIdentities.Add(await IoTHubServiceClient.Devices.GetIdentityAsync(deviceIds[deviceIndex]));
            }

            return retrievedIdentities;
        }

        /// <summary>
        /// Gets the list of device twins that are tied to the device identities that were created for this sample
        /// </summary>
        public async Task<IEnumerable<TwinData>> GetDeviceTwins(string[] deviceIds)
        {
            List<TwinData> retrievedTwins = new List<TwinData>();
            for (int deviceIndex = 0; deviceIndex < BulkCount; deviceIndex++)
            {
                retrievedTwins.Add(await IoTHubServiceClient.Devices.GetTwinAsync(deviceIds[deviceIndex]));
            }

            return retrievedTwins;
        }
    }
}

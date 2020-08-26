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
    /// There are also bulk APIs for updating twins on up to 100 devices at time.
    /// </summary>
    internal class BulkDeviceIdentityLifecycleSamples
    {
        public readonly IotHubServiceClient IoTHubServiceClient;
        public const int MaxRandomValue = 200;
        public static readonly Random Random = new Random();

        // Can be 1 to 100, configures how many devices to create/update/delete per service API call.
        public const int BulkCount = 20;

        public BulkDeviceIdentityLifecycleSamples(IotHubServiceClient client)
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

            // Create multiple device identities.
            await CreateDeviceIdentitiesAsync(deviceIdentities);

            // Get the created devices from the service.
            IEnumerable<DeviceIdentity> createdIdentities = await GetDeviceIdentities(deviceIdentities.Select(identity => identity.DeviceId).ToArray());

            // Update multiple device identities.
            await UpdateDeviceIdentitiesAsync(createdIdentities);

            // Get the device twins from the service.
            IEnumerable<TwinData> deviceTwins = await GetDeviceTwins();

            // Update multiple device twins.
            await UpdateDeviceTwinsAsync(deviceTwins);

            // Get the updated devices from the service.
            IEnumerable<DeviceIdentity> identitiesBeforeDelete = await GetDeviceIdentities(deviceIdentities.Select(identity => identity.DeviceId).ToArray());

            // Delete multiple device identities.
            await DeleteDeviceIdentitiesAsync(identitiesBeforeDelete);
        }

        /// <summary>
        /// Create multiple device identities.
        /// </summary>
        /// <param name="deviceIdentities">Collection of device identities to be created.</param>
        public async Task CreateDeviceIdentitiesAsync(IEnumerable<DeviceIdentity> deviceIdentities)
        {
            SampleLogger.PrintHeader("CREATE DEVICE IDENTITIES");

            try
            {
                Console.WriteLine($"Creating {BulkCount} new devices");

                #region Snippet:IotHubCreateDeviceIdentities

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

                #endregion Snippet:IotHubCreateDeviceIdentities
            }
            catch (Exception ex)
            {
                // Try to cleanup before exiting with fatal error.
                await CleanupHelper.DeleteAllDevicesInHubAsync(IoTHubServiceClient);
                SampleLogger.FatalError($"Failed to create device identity due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Update multiple device identity.
        /// </summary>
        /// <param name="deviceIdentities">Collection of device identities to be updated.</param>
        public async Task UpdateDeviceIdentitiesAsync(IEnumerable<DeviceIdentity> deviceIdentities)
        {
            SampleLogger.PrintHeader("UPDATE DEVICE IDENTITIES");

            try
            {
                Console.WriteLine($"Disabling multiple devices so they cannot connect to IoT Hub.");

                #region Snippet:IotHubUpdateDeviceIdentities

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

                #endregion Snippet:IotHubUpdateDeviceIdentities
            }
            catch (Exception ex)
            {
                // Try to cleanup before exiting with fatal error.
                await CleanupHelper.DeleteAllDevicesInHubAsync(IoTHubServiceClient);
                SampleLogger.FatalError($"Failed to update a device identity due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Update multiple device twin desired properties.
        /// </summary>
        /// <param name="deviceTwins">Collection of device twins to be updated.</param>
        public async Task UpdateDeviceTwinsAsync(IEnumerable<TwinData> deviceTwins)
        {
            SampleLogger.PrintHeader("UPDATE DEVICE TWINS");

            string userPropName = "user";

            try
            {
                #region Snippet:IotHubUpdateDeviceTwins

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

                #endregion Snippet:IotHubUpdateDeviceTwins
            }
            catch (Exception ex)
            {
                // Try to cleanup before exiting with fatal error.
                await CleanupHelper.DeleteAllDevicesInHubAsync(IoTHubServiceClient);
                SampleLogger.FatalError($"Failed to update a device identity due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Delete multiple device identities.
        /// </summary>
        /// <param name="deviceIdentities">Collection of device identities to be deleted.</param>
        public async Task DeleteDeviceIdentitiesAsync(IEnumerable<DeviceIdentity> deviceIdentities)
        {
            SampleLogger.PrintHeader("DELETE DEVICE IDENTITIES");

            try
            {
                #region Snippet:IotHubDeleteDeviceIdentities

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

                #endregion Snippet:IotHubDeleteDeviceIdentities
            }
            catch (Exception ex)
            {
                // Try to cleanup before exiting with fatal error.
                await CleanupHelper.DeleteAllDevicesInHubAsync(IoTHubServiceClient);
                SampleLogger.FatalError($"Failed to device identity due to:\n{ex}");
            }
        }

        /// <summary>
        /// Get the list of device identities that was created for this sample.
        /// </summary>
        /// <param name="deviceIds">Collection of device identifiers.</param>
        public async Task<IEnumerable<DeviceIdentity>> GetDeviceIdentities(string[] deviceIds)
        {
            #region Snippet:IotHubGetDeviceIdentities

            List<DeviceIdentity> retrievedIdentities = new List<DeviceIdentity>();
            for (int deviceIndex = 0; deviceIndex < BulkCount; deviceIndex++)
            {
                retrievedIdentities.Add(await IoTHubServiceClient.Devices.GetIdentityAsync(deviceIds[deviceIndex]));
            }

            #endregion Snippet:IotHubGetDeviceIdentities

            return retrievedIdentities;
        }

        /// <summary>
        /// Get the list of device twins that are tied to the device identities that were created for this sample.
        /// </summary>
        /// <param name="deviceIds">Collection of device identifiers.</param>
        public async Task<IEnumerable<TwinData>> GetDeviceTwins()
        {
            #region Snippet:IotHubGetDeviceTwins

            AsyncPageable<TwinData> asyncPageableResponse = IoTHubServiceClient.Devices.GetTwinsAsync();

            // Iterate over the twin instances in the pageable response.
            // The "await" keyword here is required because new pages will be fetched when necessary,
            // which involves a request to the service.
            List<TwinData> retrievedTwins = new List<TwinData>();
            await foreach (TwinData twin in asyncPageableResponse)
            {
                retrievedTwins.Add(twin);
            }

            #endregion Snippet:IotHubGetDeviceTwins

            return retrievedTwins;
        }
    }
}

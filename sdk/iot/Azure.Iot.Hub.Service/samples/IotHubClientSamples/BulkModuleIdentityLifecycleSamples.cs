// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Iot.Hub.Service.Models;

namespace Azure.Iot.Hub.Service.Samples
{
    /// <summary>
    /// This sample goes through the lifecycle of multiple Module Identities for multiple modules. It utilizes
    /// bulk APIs that allow for creating, updating, and deleting of up to 100 module identities at a time.
    /// There are also bulk APIs for updating twins on up to 100 modules at time.
    /// </summary>
    internal class BulkModuleIdentityLifecycleSamples
    {
        public readonly IotHubServiceClient IoTHubServiceClient;
        public const int MaxRandomValue = 200;
        public static readonly Random Random = new Random();

        // Can be 1 to 100, configures how many modules to create/update/delete per service API call.
        public const int BulkCount = 20;

        public BulkModuleIdentityLifecycleSamples(IotHubServiceClient client)
        {
            IoTHubServiceClient = client;
        }

        public async Task RunSampleAsync()
        {
            List<ModuleIdentity> moduleIdentities = new List<ModuleIdentity>();
            var deviceId = $"device_{Random.Next(MaxRandomValue)}";
            for (int moduleIndex = 0; moduleIndex < BulkCount; moduleIndex++)
            {
                moduleIdentities.Add(
                    new ModuleIdentity()
                    {
                        DeviceId = deviceId,
                        ModuleId = $"module_{moduleIndex}_{Random.Next(MaxRandomValue)}"
                    });
            }

            // Create a DeviceIdentity.
            await CreateDeviceIdentityAsync(deviceId);

            // Create multiple module identities.
            await CreateModuleIdentitiesAsync(moduleIdentities);

            // Get the created modules from the service.
            IEnumerable<ModuleIdentity> createdIdentities = await GetModuleIdentities(deviceId);

            // Update multiple module identities.
            await UpdateModuleIdentitiesAsync(createdIdentities);

            // Get the module twins from the service.
            IEnumerable<TwinData> moduleTwins = await GetModuleTwins();

            // Update multiple module twins.
            await UpdateModuleTwinsAsync(moduleTwins);

            // Get the updated modules from the service.
            IEnumerable<ModuleIdentity> identitiesBeforeDelete = await GetModuleIdentities(deviceId);

            // Delete multiple module identities.
            await DeleteModuleIdentitiesAsync(identitiesBeforeDelete);

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
                // Try to cleanup before exiting with fatal error.
                await CleanupHelper.DeleteAllDevicesInHubAsync(IoTHubServiceClient);
                SampleLogger.FatalError($"Failed to create device identity due to:\n{ex}");
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
                // Try to cleanup before exiting with fatal error.
                await CleanupHelper.DeleteAllDevicesInHubAsync(IoTHubServiceClient);
                SampleLogger.FatalError($"Failed to device identity due to:\n{ex}");
            }
        }

        /// <summary>
        /// Create multiple module identities.
        /// </summary>
        /// <param name="moduleIdentities">Collection of modules identities to be created.</param>
        public async Task CreateModuleIdentitiesAsync(IEnumerable<ModuleIdentity> moduleIdentities)
        {
            SampleLogger.PrintHeader("CREATE MODULE IDENTITIES");

            try
            {
                Console.WriteLine($"Creating {BulkCount} new modules");

                #region Snippet:IotHubCreateModuleIdentities

                Response<BulkRegistryOperationResponse> response = await IoTHubServiceClient.Modules.CreateIdentitiesAsync(moduleIdentities);

                var bulkResponse = response.Value;

                if (bulkResponse.IsSuccessful ?? true)
                {
                    SampleLogger.PrintSuccess("Successfully created new module identities");
                }
                else
                {
                    SampleLogger.PrintWarning("Failed to create new module identities");

                    foreach (var bulkOperationError in bulkResponse.Errors)
                    {
                        SampleLogger.PrintWarning($"Module id that failed: {bulkOperationError.ModuleId}, for device {bulkOperationError.DeviceId}, error code: {bulkOperationError.ErrorCode}");
                    }
                }

                #endregion Snippet:IotHubCreateModuleIdentities
            }
            catch (Exception ex)
            {
                // Try to cleanup before exiting with fatal error.
                await CleanupHelper.DeleteAllDevicesInHubAsync(IoTHubServiceClient);
                SampleLogger.FatalError($"Failed to create module identity due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Update multiple module identities.
        /// </summary>
        /// <param name="moduleIdentities">Collection of module identities to be updated.</param>
        public async Task UpdateModuleIdentitiesAsync(IEnumerable<ModuleIdentity> moduleIdentities)
        {
            SampleLogger.PrintHeader("UPDATE MODULE IDENTITIES");

            try
            {
                Console.WriteLine($"Disconnect multiple modules so they cannot connect to IoT Hub.");

                #region Snippet:IotHubUpdateModuleIdentities

                foreach (var identity in moduleIdentities)
                {
                    identity.ConnectionState = ModuleConnectionState.Disconnected;
                }

                Response<BulkRegistryOperationResponse> response = await IoTHubServiceClient.Modules.UpdateIdentitiesAsync(moduleIdentities, BulkIfMatchPrecondition.IfMatch);
                var bulkResponse = response.Value;

                if (bulkResponse.IsSuccessful ?? true)
                {
                    SampleLogger.PrintSuccess("Successfully disconnected the module identities");
                }
                else
                {
                    SampleLogger.PrintWarning("Failed to disconnect the module identities");

                    foreach (var bulkOperationError in bulkResponse.Errors)
                    {
                        SampleLogger.PrintWarning($"Module id that failed: {bulkOperationError.ModuleId}, for device {bulkOperationError.DeviceId}, error code: {bulkOperationError.ErrorCode}");
                    }
                }

                #endregion Snippet:IotHubUpdateModuleIdentities
            }
            catch (Exception ex)
            {
                // Try to cleanup before exiting with fatal error.
                await CleanupHelper.DeleteAllDevicesInHubAsync(IoTHubServiceClient);
                SampleLogger.FatalError($"Failed to update a module identity due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Update multiple module twin desired properties.
        /// </summary>
        /// <param name="moduleTwins">Collection of module twins to be updated.</param>
        public async Task UpdateModuleTwinsAsync(IEnumerable<TwinData> moduleTwins)
        {
            SampleLogger.PrintHeader("UPDATE MODULE TWINS");

            string userPropName = "user";

            try
            {
                Console.WriteLine($"Setting a new desired property {userPropName} to: '{Environment.UserName}' for each twin");

                #region Snippet:IotHubUpdateModuleTwins

                foreach (TwinData twin in moduleTwins)
                {
                    twin.Properties.Desired.Add(new KeyValuePair<string, object>(userPropName, Environment.UserName));
                }

                Response<BulkRegistryOperationResponse> response = await IoTHubServiceClient.Modules.UpdateTwinsAsync(moduleTwins);
                var bulkResponse = response.Value;

                if (bulkResponse.IsSuccessful ?? true)
                {
                    SampleLogger.PrintSuccess("Successfully updated the module twins");
                }
                else
                {
                    SampleLogger.PrintWarning("Failed to update the module twins");

                    foreach (var bulkOperationError in bulkResponse.Errors)
                    {
                        SampleLogger.PrintWarning($"Module id that failed: {bulkOperationError.ModuleId}, for device {bulkOperationError.DeviceId}, error code: {bulkOperationError.ErrorCode}");
                    }
                }

                #endregion Snippet:IotHubUpdateModuleTwins
            }
            catch (Exception ex)
            {
                // Try to cleanup before exiting with fatal error.
                await CleanupHelper.DeleteAllDevicesInHubAsync(IoTHubServiceClient);
                SampleLogger.FatalError($"Failed to update a module identity due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Delete multiple module identities.
        /// </summary>
        /// <param name="moduleIdentities">Collection of module identities to be deleted.</param>
        public async Task DeleteModuleIdentitiesAsync(IEnumerable<ModuleIdentity> moduleIdentities)
        {
            SampleLogger.PrintHeader("DELETE MODULE IDENTITIES");

            try
            {
                Console.WriteLine($"Deleting bulk module identities");

                #region Snippet:IotHubDeleteModuleIdentities

                Response<BulkRegistryOperationResponse> response = await IoTHubServiceClient.Modules.DeleteIdentitiesAsync(moduleIdentities);
                var bulkResponse = response.Value;

                if (bulkResponse.IsSuccessful ?? true)
                {
                    SampleLogger.PrintSuccess("Successfully deleted the module identities");
                }
                else
                {
                    SampleLogger.PrintWarning("Failed to delete the module identities");

                    foreach (var bulkOperationError in bulkResponse.Errors)
                    {
                        SampleLogger.PrintWarning($"Module id that failed: {bulkOperationError.ModuleId}, for device {bulkOperationError.DeviceId}, error code: {bulkOperationError.ErrorCode}");
                    }
                }

                #endregion Snippet:IotHubDeleteModuleIdentities
            }
            catch (Exception ex)
            {
                // Try to cleanup before exiting with fatal error.
                await CleanupHelper.DeleteAllDevicesInHubAsync(IoTHubServiceClient);
                SampleLogger.FatalError($"Failed to delete module identity due to:\n{ex}");
            }
        }

        /// <summary>
        /// Get the list of module identities that was created for this sample.
        /// </summary>
        /// <param name="deviceId">The device identifier of the modules.</param>
        /// <param name="moduleIds">Collection of module identifiers.</param>
        public async Task<IEnumerable<ModuleIdentity>> GetModuleIdentities(string deviceId)
        {
            #region Snippet:IotHubGetModuleIdentities

            Response<IReadOnlyList<ModuleIdentity>> retrievedIdentities = await IoTHubServiceClient.Modules.GetIdentitiesAsync(deviceId);

            #endregion Snippet:IotHubGetModuleIdentities

            return retrievedIdentities.Value;
        }

        /// <summary>
        /// Get the list of module twins that are tied to the module identities that were created for this sample.
        /// </summary>
        /// <param name="deviceId">The device identifier of the modules.</param>
        /// <param name="moduleIds">Collection of module identifiers.</param>
        public async Task<IEnumerable<TwinData>> GetModuleTwins()
        {
            #region Snippet:IotHubGetModuleTwins

            AsyncPageable<TwinData> asyncPageableResponse = IoTHubServiceClient.Modules.GetTwinsAsync();

            // Iterate over the twin instances in the pageable response.
            // The "await" keyword here is required because new pages will be fetched when necessary,
            // which involves a request to the service.
            List<TwinData> retrievedTwins = new List<TwinData>();
            await foreach (TwinData twin in asyncPageableResponse)
            {
                retrievedTwins.Add(twin);
            }

            #endregion Snippet:IotHubGetModuleTwins

            return retrievedTwins;
        }
    }
}

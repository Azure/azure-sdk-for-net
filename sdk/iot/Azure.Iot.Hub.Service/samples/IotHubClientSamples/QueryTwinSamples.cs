// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Iot.Hub.Service.Models;

namespace Azure.Iot.Hub.Service.Samples
{
    /// <summary>
    /// This sample shows how to query the device twins to get data.
    /// </summary>
    internal class QueryTwinSamples
    {
        public readonly IotHubServiceClient IoTHubServiceClient;
        public const int MaxRandomValue = 200;
        public static readonly Random Random = new Random();

        public QueryTwinSamples(IotHubServiceClient client)
        {
            IoTHubServiceClient = client;
        }

        public async Task RunSampleAsync()
        {
            string deviceId = $"device{Random.Next(MaxRandomValue)}";
            string moduleId = $"module{Random.Next(MaxRandomValue)}";

            // Create device identity.
            await CreateDeviceIdentityAsync(deviceId);

            // Create module identity.
            await CreateModuleIdentityAsync(deviceId, moduleId);

            // Query all the device twin.
            await QueryDeviceTwinsAsync();

            // Query all the module twin.
            await QueryModuleTwinsAsync();

            // Delete device identity.
            await DeleteDeviceIdentityAsync(deviceId);
        }

        /// <summary>
        /// Queries for device twin data.
        /// </summary>
        /// <param name="query">Query to execute.</param>
        public async Task QueryDeviceTwinsAsync()
        {
            #region Snippet:IotHubQueryDeviceTwins

            AsyncPageable<TwinData> asyncPageableResponse = IoTHubServiceClient.Query.QueryAsync("SELECT * FROM devices");

            // Iterate over the twin instances in the pageable response.
            // The "await" keyword here is required because new pages will be fetched when necessary,
            // which involves a request to the service.
            await foreach (TwinData twin in asyncPageableResponse)
            {
                Console.WriteLine($"Found device '{twin.DeviceId}'");
            }

            #endregion Snippet:IotHubQueryDeviceTwins
        }

        /// <summary>
        /// Queries for module twin data.
        /// </summary>
        /// <param name="query">Query to execute.</param>
        public async Task QueryModuleTwinsAsync()
        {
            #region Snippet:IotHubQueryModuleTwins

            AsyncPageable<TwinData> asyncPageableResponse = IoTHubServiceClient.Query.QueryAsync("SELECT * FROM devices.modules");

            // Iterate over the twin instances in the pageable response.
            // The "await" keyword here is required because new pages will be fetched when necessary,
            // which involves a request to the service.
            await foreach (TwinData twin in asyncPageableResponse)
            {
                Console.WriteLine($"Found module {twin.ModuleId}");
            }

            #endregion Snippet:IotHubQueryModuleTwins
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
        /// Creates a new module identity.
        /// </summary>
        /// <param name="deviceId">Unique identifier of the device.</param>
        /// <param name="moduleId">Unique identifier of the new module.</param>
        public async Task<ModuleIdentity> CreateModuleIdentityAsync(string deviceId, string moduleId)
        {
            SampleLogger.PrintHeader("CREATE MODULE IDENTITY");

            // Construct the module identity object.
            var moduleIdentity = new ModuleIdentity
            {
                DeviceId = deviceId,
                ModuleId = moduleId
            };

            try
            {
                Console.WriteLine($"Creating a new module with Id: '{moduleId}'");

                // Call APIs to create the module identity.
                Response<ModuleIdentity> response = await IoTHubServiceClient.Modules.CreateOrUpdateIdentityAsync(moduleIdentity);

                SampleLogger.PrintSuccess($"Successfully created a new module identity: DeviceId: '{deviceId}', ModuleId: '{response.Value.ModuleId}', ETag: '{response.Value.Etag}'");

                return response.Value;
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
        /// Deletes a module identity.
        /// </summary>
        /// <param name="deviceId">Unique identifier of the device the module belongs to.</param>
        /// <param name="moduleId">Unique identifier of the module to be updated.</param>
        public async Task DeleteModuleIdentityAsync(string deviceId, string moduleId)
        {
            SampleLogger.PrintHeader("DELETE MODULE IDENTITY");

            try
            {
                // Get the module identity first.
                Response<ModuleIdentity> getResponse = await IoTHubServiceClient.Modules.GetIdentityAsync(deviceId, moduleId);
                ModuleIdentity moduleIdentity = getResponse.Value;

                Console.WriteLine($"Deleting module identity: DeviceId: '{moduleIdentity.DeviceId}', ModuleId: '{moduleIdentity.ModuleId}', ETag: '{moduleIdentity.Etag}'");

                // We use UnconditionalIfMatch to force delete the Module Identity (disregard the IfMatch ETag).
                Response response = await IoTHubServiceClient.Modules.DeleteIdentityAsync(moduleIdentity);

                SampleLogger.PrintSuccess($"Successfully deleted module identity: DeviceId: '{deviceId}', ModuleId: '{moduleId}'");
            }
            catch (Exception ex)
            {
                // Try to cleanup before exiting with fatal error.
                await CleanupHelper.DeleteAllDevicesInHubAsync(IoTHubServiceClient);
                SampleLogger.FatalError($"Failed to delete module identity due to:\n{ex}");
            }
        }
    }
}

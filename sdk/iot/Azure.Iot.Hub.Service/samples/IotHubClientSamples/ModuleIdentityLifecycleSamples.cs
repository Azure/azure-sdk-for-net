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
    /// This sample goes through the lifecycle of a Module Identity for a device.
    /// </summary>
    internal class ModuleIdentityLifecycleSamples
    {
        public readonly IotHubServiceClient IoTHubServiceClient;
        public const int MaxRandomValue = 200;
        public static readonly Random Random = new Random();

        public ModuleIdentityLifecycleSamples(IotHubServiceClient client)
        {
            IoTHubServiceClient = client;
        }

        public async Task RunSampleAsync()
        {
            string deviceId = $"device{Random.Next(MaxRandomValue)}";
            string moduleId = $"module{Random.Next(MaxRandomValue)}";

            // Create a DeviceIdentity.
            await CreateDeviceIdentityAsync(deviceId);

            // Create a ModuleIdentity.
            await CreateModuleIdentityAsync(deviceId, moduleId);

            // List all modules within the device.
            await ListAllModulesAsync(deviceId);

            // Get the Module Identity.
            await GetModuleIdentityAsync(deviceId, moduleId);

            // Update Module Identity.
            await UpdateModuleIdentityAsync(deviceId, moduleId);

            // Get Module Twin.
            await GetModuleTwinAsync(deviceId, moduleId);

            // Update Module Twin.
            await UpdateModuleTwinAsync(deviceId, moduleId);

            // Delete the module identity.
            await DeleteModuleIdentityAsync(deviceId, moduleId);

            // Delete the device (cleanup).
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

                #region Snippet:IotHubCreateModuleIdentity

                // Call APIs to create the module identity.
                Response<ModuleIdentity> response = await IoTHubServiceClient.Modules.CreateOrUpdateIdentityAsync(moduleIdentity);

                SampleLogger.PrintSuccess($"Successfully created a new module identity: DeviceId: '{deviceId}', ModuleId: '{response.Value.ModuleId}', ETag: '{response.Value.Etag}'");

                #endregion Snippet:IotHubCreateModuleIdentity

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
        /// List all module identities within a device.
        /// </summary>
        /// <param name="deviceId">Unique identifier of the device to query.</param>
        public async Task<IReadOnlyList<ModuleIdentity>> ListAllModulesAsync(string deviceId)
        {
            SampleLogger.PrintHeader("LIST ALL MODULES");

            try
            {
                Console.WriteLine($"Listing all modules in device with Id: '{deviceId}'\n");

                #region Snippet:IotHubGetModuleIdentities

                Response<IReadOnlyList<ModuleIdentity>> response = await IoTHubServiceClient.Modules.GetIdentitiesAsync(deviceId);

                foreach (ModuleIdentity moduleIdentity in response.Value)
                {
                    SampleLogger.PrintSuccess($"\t- Device Id: '{moduleIdentity.DeviceId}', Module Id: '{moduleIdentity.ModuleId}', ETag: '{moduleIdentity.Etag}'");
                }

                #endregion Snippet:IotHubGetModuleIdentities

                return response.Value;
            }
            catch (Exception ex)
            {
                // Try to cleanup before exiting with fatal error.
                await CleanupHelper.DeleteAllDevicesInHubAsync(IoTHubServiceClient);
                SampleLogger.FatalError($"Failed to list module identities due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Get a module identity.
        /// </summary>
        /// <param name="deviceId">Unique identifier of the device the module belongs to.</param>
        /// <param name="moduleId">Unique identifier of the module to get.</param>
        public async Task<ModuleIdentity> GetModuleIdentityAsync(string deviceId, string moduleId)
        {
            SampleLogger.PrintHeader("GET A MODULE");

            try
            {
                Console.WriteLine($"Getting module identity with Id: '{moduleId}'\n");

                #region Snippet:IotHubGetModuleIdentity

                Response<ModuleIdentity> response = await IoTHubServiceClient.Modules.GetIdentityAsync(deviceId, moduleId);

                ModuleIdentity moduleIdentity = response.Value;

                SampleLogger.PrintSuccess($"\t- Device Id: '{moduleIdentity.DeviceId}', Module Id: '{moduleIdentity.ModuleId}', ETag: '{moduleIdentity.Etag}'");

                #endregion Snippet:IotHubGetModuleIdentity

                return moduleIdentity;
            }
            catch (Exception ex)
            {
                // Try to cleanup before exiting with fatal error.
                await CleanupHelper.DeleteAllDevicesInHubAsync(IoTHubServiceClient);
                SampleLogger.FatalError($"Failed to get a module identity due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Update a module identity.
        /// </summary>
        /// <param name="deviceId">Unique identifier of the device the module belongs to.</param>
        /// <param name="moduleId">Unique identifier of the module to be updated.</param>
        public async Task<ModuleIdentity> UpdateModuleIdentityAsync(string deviceId, string moduleId)
        {
            SampleLogger.PrintHeader("UPDATE A MODULE");

            try
            {
                #region Snippet:IotHubUpdateModuleIdentity

                Response<ModuleIdentity> getResponse = await IoTHubServiceClient.Modules.GetIdentityAsync(deviceId, moduleId);

                ModuleIdentity moduleIdentity = getResponse.Value;
                Console.WriteLine($"Current module identity: DeviceId: '{moduleIdentity.DeviceId}', ModuleId: '{moduleIdentity.ModuleId}', ManagedBy: '{moduleIdentity.ManagedBy ?? "N/A"}', ETag: '{moduleIdentity.Etag}'");

                Console.WriteLine($"Updating module identity with Id: '{moduleIdentity.ModuleId}'. Setting 'ManagedBy' property to: '{Environment.UserName}'");
                moduleIdentity.ManagedBy = Environment.UserName;

                Response<ModuleIdentity> response = await IoTHubServiceClient.Modules.CreateOrUpdateIdentityAsync(moduleIdentity);

                ModuleIdentity updatedModule = response.Value;

                SampleLogger.PrintSuccess($"Successfully updated module identity: DeviceId: '{updatedModule.DeviceId}', ModuleId: '{updatedModule.ModuleId}', ManagedBy: '{updatedModule.ManagedBy}', ETag: '{updatedModule.Etag}'");

                #endregion Snippet:IotHubUpdateModuleIdentity

                return updatedModule;
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
        /// Get module twin.
        /// </summary>
        /// <param name="deviceId">Unique identifier of the device the module belongs to.</param>
        /// <param name="moduleId">Unique identifier of the module to be updated.</param>
        public async Task<TwinData> GetModuleTwinAsync(string deviceId, string moduleId)
        {
            SampleLogger.PrintHeader("GET A MODULE TWIN");

            try
            {
                Console.WriteLine($"Getting module twin with Id: '{moduleId}'");

                #region Snippet:IotHubGetModuleTwin

                Response<TwinData> response = await IoTHubServiceClient.Modules.GetTwinAsync(deviceId, moduleId);

                SampleLogger.PrintSuccess($"\t- Module Twin: DeviceId: '{response.Value.DeviceId}', ModuleId: '{response.Value.ModuleId}', Status: '{response.Value.Status}', ETag: '{response.Value.Etag}'");

                #endregion Snippet:IotHubGetModuleTwin

                return response.Value;
            }
            catch (Exception ex)
            {
                // Try to cleanup before exiting with fatal error.
                await CleanupHelper.DeleteAllDevicesInHubAsync(IoTHubServiceClient);
                SampleLogger.FatalError($"Failed to get a module twin due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Update a module twin desired properties.
        /// </summary>
        /// <param name="deviceId">Unique identifier of the device the module belongs to.</param>
        /// <param name="moduleId">Unique identifier of the module to be updated.</param>
        public async Task<TwinData> UpdateModuleTwinAsync(string deviceId, string moduleId)
        {
            SampleLogger.PrintHeader("UPDATE A MODULE TWIN");

            string userPropName = "user";

            try
            {
                // Get the device module

                #region Snippet:IotHubUpdateModuleTwin

                Response<TwinData> getResponse = await IoTHubServiceClient.Modules.GetTwinAsync(deviceId, moduleId);
                TwinData moduleTwin = getResponse.Value;

                Console.WriteLine($"Updating module twin: DeviceId: '{moduleTwin.DeviceId}', ModuleId: '{moduleTwin.ModuleId}', ETag: '{moduleTwin.Etag}'");
                Console.WriteLine($"Setting a new desired property {userPropName} to: '{Environment.UserName}'");

                moduleTwin.Properties.Desired.Add(new KeyValuePair<string, object>(userPropName, Environment.UserName));

                Response<TwinData> response = await IoTHubServiceClient.Modules.UpdateTwinAsync(moduleTwin);

                TwinData updatedTwin = response.Value;

                var userPropValue = (string)updatedTwin.Properties.Desired
                    .Where(p => p.Key == userPropName)
                    .First()
                    .Value;

                SampleLogger.PrintSuccess($"Successfully updated module twin: DeviceId: '{updatedTwin.DeviceId}', ModuleId: '{updatedTwin.ModuleId}', desired property: [{userPropName}: '{userPropValue}'], ETag: '{updatedTwin.Etag}',");

                #endregion Snippet:IotHubUpdateModuleTwin

                return updatedTwin;
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
        /// Deletes a module identity.
        /// </summary>
        /// <param name="deviceId">Unique identifier of the device the module belongs to.</param>
        /// <param name="moduleId">Unique identifier of the module to be updated.</param>
        public async Task DeleteModuleIdentityAsync(string deviceId, string moduleId)
        {
            SampleLogger.PrintHeader("DELETE MODULE IDENTITY");

            try
            {
                #region Snippet:IotHubDeleteModuleIdentity

                // Get the module identity first.
                Response<ModuleIdentity> getResponse = await IoTHubServiceClient.Modules.GetIdentityAsync(deviceId, moduleId);
                ModuleIdentity moduleIdentity = getResponse.Value;

                Console.WriteLine($"Deleting module identity: DeviceId: '{moduleIdentity.DeviceId}', ModuleId: '{moduleIdentity.ModuleId}', ETag: '{moduleIdentity.Etag}'");

                // We use UnconditionalIfMatch to force delete the Module Identity (disregard the IfMatch ETag).
                Response response = await IoTHubServiceClient.Modules.DeleteIdentityAsync(moduleIdentity);

                SampleLogger.PrintSuccess($"Successfully deleted module identity: DeviceId: '{deviceId}', ModuleId: '{moduleId}'");

                #endregion Snippet:IotHubDeleteModuleIdentity
            }
            catch (Exception ex)
            {
                // Try to cleanup before exiting with fatal error.
                await CleanupHelper.DeleteAllDevicesInHubAsync(IoTHubServiceClient);
                SampleLogger.FatalError($"Failed to delete module identity due to:\n{ex}");
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
    }
}

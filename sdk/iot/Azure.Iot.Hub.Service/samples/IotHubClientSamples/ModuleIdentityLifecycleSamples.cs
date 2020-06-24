using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Iot.Hub.Service.Models;

namespace Azure.Iot.Hub.Service.Samples
{
    /// <summary>
    /// This sample goes through the lifecycle of a Module Identity for a device
    /// </summary>
    internal class ModuleIdentityLifecycleSamples
    {
        public readonly IoTHubServiceClient IoTHubServiceClient;
        public const int MaxRandomValue = 200;
        public readonly Random Random = new Random();

        public ModuleIdentityLifecycleSamples(IoTHubServiceClient client)
        {
            IoTHubServiceClient = client;
        }

        public async Task RunSampleAsync()
        {
            string deviceId = $"device{Random.Next(MaxRandomValue)}";
            string moduleId = $"module{Random.Next(MaxRandomValue)}";

            // Create a DeviceIdentity.
            DeviceIdentity deviceIdentity = await CreateDeviceIdentityAsync(deviceId);

            // Create a ModuleIdentity.
            ModuleIdentity moduleIdentity = await CreateModuleIdentityAsync(deviceIdentity, moduleId);

            // List all modules within the device.
            await ListAllModulesAsync(deviceIdentity);

            // Get the Module Identity.
            moduleIdentity = await GetModuleIdentityAsync(deviceIdentity, moduleIdentity.ModuleId);

            // Update Module Identity.
            moduleIdentity = await UpdateModuleIdentityAsync(moduleIdentity);

            // Get Module Twin,
            TwinData moduleTwin = await GetModuleTwinAsync(moduleIdentity);

            // Update Module Twin.
            await UpdateModuleTwinAsync(moduleTwin);

            // Delete the module identity
            await DeleteModuleIdentityAsync(moduleIdentity);

            // Delete the device (cleanup)
            await DeleteDeviceIdentityAsync(deviceIdentity);
        }

        /// <summary>
        /// Creates a new device identity
        /// </summary>
        /// <param name="deviceId">Device Id for the device identity</param>
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

                // Call APIs to create the device identity.
                Response<DeviceIdentity> response = await IoTHubServiceClient.Devices.CreateOrUpdateIdentityAsync(deviceIdentity);

                SampleLogger.PrintSuccess($"Successfully create a new device identity with Id: '{deviceId}', ETag: '{response.Value.Etag}'");

                return response.Value;
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to create device identity due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Creates a new module identity
        /// </summary>
        /// <param name="deviceIdentity">Device identity</param>
        /// <param name="moduleId">Module Id for the module identity</param>
        public async Task<ModuleIdentity> CreateModuleIdentityAsync(DeviceIdentity deviceIdentity, string moduleId)
        {
            SampleLogger.PrintHeader("CREATE MODULE IDENTITY");

            // Construct the module identity object.
            var moduleIdentity = new ModuleIdentity
            {
                DeviceId = deviceIdentity.DeviceId,
                ModuleId = moduleId
            };

            try
            {
                Console.WriteLine($"Creating a new module with Id: '{moduleId}'");

                // Call APIs to create the module identity.
                Response<ModuleIdentity> response = await IoTHubServiceClient.Modules.CreateOrUpdateIdentityAsync(moduleIdentity);

                SampleLogger.PrintSuccess($"Successfully created a new module identity with Id: '{moduleId}', ETag: '{response.Value.Etag}'");

                return response.Value;
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to create module identity due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// List all modules within a Device
        /// </summary>
        /// <param name="deviceIdentity">Device Identity to query</param>
        public async Task<IReadOnlyList<ModuleIdentity>> ListAllModulesAsync(DeviceIdentity deviceIdentity)
        {
            SampleLogger.PrintHeader("LIST ALL MODULES");

            try
            {
                Console.WriteLine($"Listing all modules in device with Id: '{deviceIdentity.DeviceId}'\n");

                Response<IReadOnlyList<ModuleIdentity>> response = await IoTHubServiceClient.Modules.GetIdentitiesAsync(deviceIdentity.DeviceId);

                foreach (ModuleIdentity moduleIdentity in response.Value)
                {
                    SampleLogger.PrintSuccess($"\t- Module Id: '{moduleIdentity.ModuleId}', Device Id: '{moduleIdentity.DeviceId}', ETag: '{moduleIdentity.Etag}'");
                }

                return response.Value;
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to list module identities due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Get a module identity
        /// </summary>
        /// <param name="deviceIdentity">The device identity module belongs to.</param>
        /// <param name="moduleId">The unique identifier of the module to get.</param>
        public async Task<ModuleIdentity> GetModuleIdentityAsync(DeviceIdentity deviceIdentity, string moduleId)
        {
            SampleLogger.PrintHeader("GET A MODULE");

            try
            {
                Console.WriteLine($"Getting module identity with Id: '{moduleId}'\n");

                Response<ModuleIdentity> response = await IoTHubServiceClient.Modules.GetIdentityAsync(deviceIdentity.DeviceId, moduleId);

                ModuleIdentity moduleIdentity = response.Value;

                SampleLogger.PrintSuccess($"\t- Module Id: '{moduleIdentity.ModuleId}', Device Id: '{moduleIdentity.DeviceId}', ETag: '{moduleIdentity.Etag}'");

                return moduleIdentity;
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to get a module identity due to:\n{ex}");
                throw;
            }
        }
        
        /// <summary>
        /// Update a module identity
        /// </summary>
        /// <param name="moduleIdentity">Module identity to be updated.</param>
        public async Task<ModuleIdentity> UpdateModuleIdentityAsync(ModuleIdentity moduleIdentity)
        {
            SampleLogger.PrintHeader("UPDATE A MODULE");

            try
            {
                Console.WriteLine($"Updating module identity with Id: '{moduleIdentity.ModuleId}'. Setting 'ManagedBy' property to: '{Environment.UserName}'\n");
                moduleIdentity.ManagedBy = Environment.UserName;

                Response<ModuleIdentity> response = await IoTHubServiceClient.Modules.CreateOrUpdateIdentityAsync(moduleIdentity, IfMatchPrecondition.UnconditionalIfMatch);

                ModuleIdentity updatedModule = response.Value;
                
                SampleLogger.PrintSuccess($"Successfully updated module identity with Id: '{updatedModule.ModuleId}', ManagedBy: '{updatedModule.ManagedBy}', ETag: '{updatedModule.Etag}'");
                
                return updatedModule;
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to update a module identity due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Get module twin.
        /// </summary>
        /// <param name="moduleIdentity">The module identity.</param>
        public async Task<TwinData> GetModuleTwinAsync(ModuleIdentity moduleIdentity)
        {
            SampleLogger.PrintHeader("GET A MODULE TWIN");

            try
            {
                Console.WriteLine($"Getting module twin with Id: '{moduleIdentity.ModuleId}'\n");

                Response<TwinData> response = await IoTHubServiceClient.Modules.GetTwinAsync(moduleIdentity.DeviceId, moduleIdentity.ModuleId);

                SampleLogger.PrintSuccess($"\t- Module Twin Status: '{response.Value.Status}', ETag: '{response.Value.Etag}'");

                return response.Value;
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to get a module twin due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Update a module twin desired properties
        /// </summary>
        /// <param name="moduleTwin">Module twin.</param>
        public async Task<TwinData> UpdateModuleTwinAsync(TwinData moduleTwin)
        {
            SampleLogger.PrintHeader("UPDATE A MODULE TWIN");

            string userPropName = "user";

            try
            {
                Console.WriteLine($"Updating module twin with Id: '{moduleTwin.ModuleId}'. Setting Desired property {userPropName} to: '{Environment.UserName}'\n");

                moduleTwin.Properties.Desired.Add(new KeyValuePair<string, object>(userPropName, Environment.UserName));

                Response<TwinData> response = await IoTHubServiceClient.Modules.UpdateTwinAsync(moduleTwin, IfMatchPrecondition.UnconditionalIfMatch);

                TwinData updatedTwin = response.Value;

                var userPropValue = (string) updatedTwin.Properties.Desired
                    .Where(p => p.Key == userPropName)
                    .First()
                    .Value;

                SampleLogger.PrintSuccess($"Successfully updated module twin with Id: '{updatedTwin.ModuleId}' ETag: '{updatedTwin.Etag}', {userPropName}: '{userPropValue}'");

                return updatedTwin;
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to update a module identity due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Deletes a module identity
        /// </summary>
        /// <param name="moduleIdentity">Module identity to delete</param>
        public async Task DeleteModuleIdentityAsync(ModuleIdentity moduleIdentity)
        {
            SampleLogger.PrintHeader("DELETE MODULE IDENTITY");

            try
            {
                Console.WriteLine($"Deleting module identity with Id: '{moduleIdentity.ModuleId}'");

                // Call APIs to delete the module identity.
                // We use UnconditionalIfMatch to force delete the Module Identity (disregard the IfMatch ETag)
                Response response = await IoTHubServiceClient.Modules.DeleteIdentityAsync(moduleIdentity, IfMatchPrecondition.UnconditionalIfMatch);

                SampleLogger.PrintSuccess($"Successfully deleted module identity with Id: '{moduleIdentity.ModuleId}'");
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to delete module identity due to:\n{ex}");
            }
        }

        /// <summary>
        /// Deletes a device identity
        /// </summary>
        /// <param name="deviceIdentity">Device identity to delete</param>
        public async Task DeleteDeviceIdentityAsync(DeviceIdentity deviceIdentity)
        {
            SampleLogger.PrintHeader("DELETE DEVICE IDENTITY");

            try
            {
                Console.WriteLine($"Deleting device identity with Id: '{deviceIdentity.DeviceId}'");

                // Call APIs to delete the device identity.
                // We use UnconditionalIfMatch to force delete the Device Identity (disregard the IfMatch ETag)
                Response response = await IoTHubServiceClient.Devices.DeleteIdentityAsync(deviceIdentity, IfMatchPrecondition.UnconditionalIfMatch);

                SampleLogger.PrintSuccess($"Successfully deleted device identity with Id: '{deviceIdentity.DeviceId}'");
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to device identity due to:\n{ex}");
            }
        }
    }
}

using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Azure.Iot.Hub.Service.Models;

namespace Azure.Iot.Hub.Service.Samples
{
    /// <summary>
    /// This sample goes through the lifecycle of a Module Identity of a device
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
            await ListAllModulesAsync();

            // Get the Module Identity.
            await GetModuleIdentityAsync();

            // Update Module Identity.
            await UpdateModuleIdentityAsync();

            // Get Module module Twin,
            await GetModuleTwinAsync();

            // Update Module Twin.
            await UpdateModuleTwinAsync();

            // Invoke a method on the ModuleTwin
            await InvokeMethodAsync();

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

            // Construt the device identity object.
            DeviceIdentity deviceIdentity = new DeviceIdentity
            {
                DeviceId = deviceId
            };

            try
            {
                Console.WriteLine($"Creating a new device with Id '{deviceId}'");

                // Call APIs to create the device identity.
                Response<DeviceIdentity> response = await IoTHubServiceClient.Devices.CreateOrUpdateIdentityAsync(deviceIdentity);

                SampleLogger.PrintSuccessfulEvent($"Successfully create a new device identity with Id: '{deviceId}' - Status Code: {response.GetRawResponse().Status}");

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

            // Construt the module identity object.
            ModuleIdentity moduleIdentity = new ModuleIdentity
            {
                DeviceId = deviceIdentity.DeviceId,
                ModuleId = moduleId
            };

            try
            {
                Console.WriteLine($"Creating a new module with Id: '{moduleId}'");

                // Call APIs to create the module identity.
                Response<ModuleIdentity> response = await IoTHubServiceClient.Modules.CreateOrUpdateIdentityAsync(moduleIdentity);

                SampleLogger.PrintSuccessfulEvent($"Successfully create a new module identity with Id: '{moduleId}' - Status Code: {response.GetRawResponse().Status}");

                return response.Value;
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to create module identity due to:\n{ex}");
                throw;
            }
        }

        public Task InvokeMethodAsync()
        {
            return Task.CompletedTask;
        }

        public Task ListAllModulesAsync()
        {
            return Task.CompletedTask;
        }

        public Task UpdateModuleTwinAsync()
        {
            return Task.CompletedTask;
        }

        public Task GetModuleTwinAsync()
        {
            return Task.CompletedTask;
        }   

        public Task UpdateModuleIdentityAsync()
        {
            return Task.CompletedTask;
        }

        public Task GetModuleIdentityAsync()
        {
            return Task.CompletedTask;
        }

        public async Task DeleteModuleIdentityAsync(ModuleIdentity moduleIdentity)
        {
            SampleLogger.PrintHeader("DELETE MODULE IDENTITY");

            try
            {
                Console.WriteLine($"Deleting module identity with Id: '{moduleIdentity.ModuleId}'");

                // Call APIs to delete the module identity.
                Response response = await IoTHubServiceClient.Modules.DeleteIdentityAsync(moduleIdentity, IfMatchPrecondition.UnconditionalIfMatch);

                SampleLogger.PrintSuccessfulEvent($"Successfully deleted module identity with Id: '{moduleIdentity.ModuleId}' - Status Code: {response.Status}");
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to delete module identity due to:\n{ex}");
            }
        }

        /// <summary>
        /// Deletes a device identity
        /// </summary>
        /// <param name="deviceId">Device identity to delete</param>
        public async Task DeleteDeviceIdentityAsync(DeviceIdentity deviceIdentity)
        {
            SampleLogger.PrintHeader("DELETE DEVICE IDENTITY");

            try
            {
                Console.WriteLine($"Deleting device identity with Id: '{deviceIdentity.DeviceId}'");

                // Call APIs to delete the device identity.
                Response response = await IoTHubServiceClient.Devices.DeleteIdentityAsync(deviceIdentity, IfMatchPrecondition.UnconditionalIfMatch);

                SampleLogger.PrintSuccessfulEvent($"Successfully deleted device identity with Id: '{deviceIdentity.DeviceId}' - Status Code: {response.Status}");
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to device identity due to:\n{ex}");
            }
        }
    }
}

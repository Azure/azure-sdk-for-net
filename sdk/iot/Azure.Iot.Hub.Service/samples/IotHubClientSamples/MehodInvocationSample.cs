// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Iot.Hub.Service.Models;

namespace Azure.Iot.Hub.Service.Samples
{
    /// <summary>
    /// This sample shows how to invoke a method on a device and module.
    /// This sample requires the device sample to be running so that it can connect to the device.
    /// </summary>
    internal class MethodInvocationSamples
    {
        public readonly IotHubServiceClient IoTHubServiceClient;
        public const int MaxRandomValue = 200;
        public static readonly Random Random = new Random();

        public MethodInvocationSamples(IotHubServiceClient client)
        {
            IoTHubServiceClient = client;
        }

        public async Task RunSampleAsync()
        {
            string deviceId = "methodSampleDeviceId";
            string moduleId = "methodSampleModuleId";

            // Create a DeviceIdentity.
            await CreateDeviceIdentityAsync(deviceId);

            // Create a ModuleIdentity.
            await CreateModuleIdentityAsync(deviceId, moduleId);

            // Wait for user to run the device sample
            WaitForDeviceSample(deviceId, moduleId);

            // Invoke method on device
            await InvokeMethodOnDeviceAsync(deviceId);

            // Invoke method on module
            await InvokeMethodOnModuleAsync(deviceId, moduleId);

            // Delete the device.
            await DeleteDeviceIdentityAsync(deviceId);
        }

        public void WaitForDeviceSample(string deviceId, string moduleId)
        {
            Console.WriteLine($"\nStart the device sample for device {deviceId} and module {moduleId} and press any key to continue.\n");
            Console.ReadKey(true);
        }

        /// <summary>
        /// Invokes a method on the module.
        /// </summary>
        /// <param name="deviceId">Unique identifier of the device to be updated.</param>
        /// <param name="moduleId">Unique identifier of the module to be updated.</param>
        public async Task InvokeMethodOnModuleAsync(string deviceId, string moduleId)
        {
            SampleLogger.PrintHeader("INVOKE REBOOT METHOD ON A MODULE");

            try
            {
                #region Snippet:IotInvokeMethodOnModule

                var request = new CloudToDeviceMethodRequest
                {
                    MethodName = "reboot",
                };
                CloudToDeviceMethodResponse response = (await IoTHubServiceClient.Modules
                    .InvokeMethodAsync(deviceId, moduleId, request)
                    .ConfigureAwait(false))
                    .Value;

                SampleLogger.PrintSuccess($"\t- Method 'REBOOT' invoked on module {moduleId} of device {deviceId}");
                SampleLogger.PrintHeader($"Status of method invocation is: {response.Status}");

                #endregion Snippet:IotInvokeMethodOnModule
            }
            catch (Exception ex)
            {
                // Try to cleanup before exiting with fatal error.
                await CleanupHelper.DeleteAllDevicesInHubAsync(IoTHubServiceClient);
                SampleLogger.FatalError($"Failed to invoke method on module due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Invokes a method on the device.
        /// </summary>
        /// <param name="deviceId">Unique identifier of the device to be updated.</param>
        public async Task InvokeMethodOnDeviceAsync(string deviceId)
        {
            SampleLogger.PrintHeader("INVOKE REBOOT METHOD ON A DEVICE");

            try
            {
                #region Snippet:IotInvokeMethodOnDevice

                var request = new CloudToDeviceMethodRequest
                {
                    MethodName = "reboot",
                };

                CloudToDeviceMethodResponse response = (await IoTHubServiceClient.Devices
                    .InvokeMethodAsync(deviceId, request)
                    .ConfigureAwait(false))
                    .Value;

                SampleLogger.PrintSuccess($"\t- Method 'REBOOT' invoked on device {deviceId}");
                SampleLogger.PrintHeader($"Status of method invocation is: {response.Status}");

                #endregion Snippet:IotInvokeMethodOnDevice
            }
            catch (Exception ex)
            {
                // Try to cleanup before exiting with fatal error.
                await CleanupHelper.DeleteAllDevicesInHubAsync(IoTHubServiceClient);
                SampleLogger.FatalError($"Failed to invoke method on device due to:\n{ex.Message}");
                throw;
            }
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

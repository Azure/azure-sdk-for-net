using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Iot.Hub.Service.Models;

namespace Azure.Iot.Hub.Service.Samples
{
    /// <summary>
    /// This sample goes through the lifecycle of a Device Identity.
    /// </summary>
    internal class DeviceIdentityLifecycleSamples
    {
        public const int MAX_RANDOM_VALUE = 200;
        public const int BULK_DEVICE_COUNT = 5;
        
        public readonly IoTHubServiceClient IoTHubServiceClient;
        public readonly Random Random = new Random();

        public DeviceIdentityLifecycleSamples(IoTHubServiceClient client)
        {
            IoTHubServiceClient = client;
        }

        public async Task RunSampleAsync()
        {
            // Run lifecycle samples that interact with a single device identity.
            await RunSingleDeviceLifecycleSamplesAsync();

            // Run lifecycle samples that interact with multiple device identities in bulk.
            await RunBulkDeviceLifecycleSamplesAsync();
        }

        /// <summary>
        /// Go through lifecycle of a single device identity.
        /// </summary>
        public async Task RunSingleDeviceLifecycleSamplesAsync()
        {
            SampleLogger.PrintHeader("RUNNING SINLE DEVICE IDENTITY LIFECYCLE SAMPLES");

            string deviceId = $"device{Random.Next(MAX_RANDOM_VALUE)}";

            // Create a DeviceIdentity.
            await CreateDeviceIdentityAsync(deviceId);

            // Get the device identity.
            await GetDeviceIdentityAsync(deviceId);

            // Update Module Identity.
            await UpdateDeviceIdentityAsync(deviceId);

            // Get Device Twin.
            await GetDeviceTwinAsync(deviceId);

            // Update Device Twin.
            await UpdateDeviceTwinAsync(deviceId);

            // Delete the device (cleanup).
            await DeleteDeviceIdentityAsync(deviceId);
        }

        /// <summary>
        /// Go through lifecycle of multiple device identities using bulk operations.
        /// </summary>
        public async Task RunBulkDeviceLifecycleSamplesAsync()
        {
            SampleLogger.PrintHeader("RUNNING BULK DEVICE IDENTITY LIFECYCLE SAMPLES");

            string devicesPrefix = $"bulkDevice";

            IEnumerable<DeviceIdentity> listOfDevices = BuildMultipleDevices(devicesPrefix, BULK_DEVICE_COUNT);
            
            // Create device identities using bulk operations.
            await CreateDevicesInBulkAsync(listOfDevices);

            // Update device identities using bulk operations.
            await UpdateDevicesInBulkAsync(listOfDevices);

            await GetDeviceTwinsAsync();

            // Delete device identities using bulk operations.
            await DeleteDevicesInBulkAsync(listOfDevices);
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
        /// <param name="deviceId">Unique identifier of the device.</param>
        public async Task<DeviceIdentity> GetDeviceIdentityAsync(string deviceId)
        {
            SampleLogger.PrintHeader("GET A DEVICE IDENTITY");

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
        /// <param name="deviceId">Unique identifier of the device.</param>
        public async Task<DeviceIdentity> UpdateDeviceIdentityAsync(string deviceId)
        {
            SampleLogger.PrintHeader("UPDATE A DEVICE IDENTITY");

            try
            {
                Response<DeviceIdentity> getResponse = await IoTHubServiceClient.Devices.GetIdentityAsync(deviceId);

                DeviceIdentity deviceIdentity = getResponse.Value;
                Console.WriteLine($"Current device identity: DeviceId: '{deviceIdentity.DeviceId}', , Status: '{deviceIdentity.Status}', ETag: '{deviceIdentity.Etag}'");

                Console.WriteLine($"Updating device identity with Id: '{deviceIdentity.DeviceId}'. Setting 'Status' to: '{DeviceStatus.Disabled}'");
                deviceIdentity.Status = DeviceStatus.Disabled;

                Response<DeviceIdentity> response = await IoTHubServiceClient.Devices.CreateOrUpdateIdentityAsync(deviceIdentity);

                DeviceIdentity updatedDevice = response.Value;

                SampleLogger.PrintSuccess($"Successfully updated device identity: DeviceId: '{updatedDevice.DeviceId}', Status: '{updatedDevice.Status}', ETag: '{updatedDevice.Etag}'");

                return updatedDevice;
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to update a device identity due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Get module twin.
        /// </summary>
        /// <param name="deviceId">Unique identifier of the device.</param>
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
        /// Update a module twin desired properties.
        /// </summary>
        /// <param name="deviceId">Unique identifier of the device.</param>
        public async Task<TwinData> UpdateDeviceTwinAsync(string deviceId)
        {
            SampleLogger.PrintHeader("UPDATE A DEVICE TWIN");

            string userPropName = "user";

            try
            {
                // Get the device module
                Response<TwinData> getResponse = await IoTHubServiceClient.Devices.GetTwinAsync(deviceId);
                TwinData deviceTwin = getResponse.Value;

                Console.WriteLine($"Updating module twin: DeviceId: '{deviceTwin.DeviceId}', ETag: '{deviceTwin.Etag}'");
                Console.WriteLine($"Setting a new desired property {userPropName} to: '{Environment.UserName}'");

                deviceTwin.Properties.Desired.Add(new KeyValuePair<string, object>(userPropName, Environment.UserName));

                Response<TwinData> response = await IoTHubServiceClient.Devices.UpdateTwinAsync(deviceTwin);

                TwinData updatedTwin = response.Value;

                var userPropValue = (string)updatedTwin.Properties.Desired
                    .Where(p => p.Key == userPropName)
                    .First()
                    .Value;

                SampleLogger.PrintSuccess($"Successfully updated device twin: DeviceId: '{updatedTwin.DeviceId}', desired property: [{userPropName}: '{userPropValue}'], ETag: '{updatedTwin.Etag}',");

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

        /// <summary>
        /// Creates multiple device identities in a single bulk operation.
        /// </summary>
        /// <param name="listOfDevices">List of device identities to create.</param>
        public async Task CreateDevicesInBulkAsync(IEnumerable<DeviceIdentity> listOfDevices)
        {
            SampleLogger.PrintHeader("CREATE DEVICE IDENTITIES IN BULK");

            try
            {
                Console.WriteLine($"Creating {listOfDevices.Count()} devices");
                Response<BulkRegistryOperationResponse> createResponse = await IoTHubServiceClient.Devices.CreateIdentitiesAsync(listOfDevices);

                BulkRegistryOperationResponse operationResponse = createResponse.Value;

                if (operationResponse.IsSuccessful ?? false)
                {
                    SampleLogger.PrintSuccess($"Successfully created {listOfDevices.Count()} devices.");
                    Console.WriteLine($"List of created device identities:\n{string.Join(", ", listOfDevices.Select(s => $"'{s.DeviceId}'"))}");
                }
                else
                {
                    // TODO:(azabbasi) Print all the errors and warnings (this cannot be tested due to an issue with the swagger document)
                    // Refer to: https://msazure.visualstudio.com/One/_workitems/edit/7536750
                    SampleLogger.PrintWarning($"Not all devices were created successfully.");
                }
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to create device identities in bulk due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Updates multiple device identities in a single bulk operation.
        /// </summary>
        /// <param name="listOfDevices">List of device identities to update.</param>
        public async Task UpdateDevicesInBulkAsync(IEnumerable<DeviceIdentity> listOfDevices)
        {
            SampleLogger.PrintHeader("UPDATE DEVICE IDENTITIES IN BULK");

            try
            {
                Console.WriteLine($"Updating {listOfDevices.Count()} devices");

                foreach(var device in listOfDevices)
                {
                    device.Status = DeviceStatus.Disabled;
                }

                Console.WriteLine($"Setting 'Status' property to '{DeviceStatus.Disabled}' on {listOfDevices.Count()} device identities");

                // Since we did not get the list of devices from the service, we have to use UnconditionalIfMatch precondition to force the update.
                Response<BulkRegistryOperationResponse> updateResponse = await IoTHubServiceClient.Devices.UpdateIdentitiesAsync(listOfDevices, BulkIfMatchPrecondition.Unconditional);

                BulkRegistryOperationResponse operationResponse = updateResponse.Value;

                if (operationResponse.IsSuccessful ?? false)
                {
                    SampleLogger.PrintSuccess($"Successfully updated {listOfDevices.Count()} devices.");
                }
                else
                {
                    // TODO:(azabbasi) Print all the errors and warnings (this cannot be tested due to an issue with the swagger document)
                    // Refer to: https://msazure.visualstudio.com/One/_workitems/edit/7536750
                    SampleLogger.PrintWarning($"Not all devices were created successfully.");
                }
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to update device identities in bulk due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Get all device twins in IoT Hub.
        /// </summary>
        public async Task GetDeviceTwinsAsync()
        {
            SampleLogger.PrintHeader("GET DEVICE TWINS");

            try
            {
                // Since we did not get the list of devices from the service, we have to use UnconditionalIfMatch precondition to force the update.
                AsyncPageable<TwinData> updateResponse = IoTHubServiceClient.Devices.GetTwinsAsync();

                AsyncPageable<TwinData> twins = IoTHubServiceClient.Devices.GetTwinsAsync();

                SampleLogger.PrintSuccess($"Successfully fetched all device twins");

                // We will verify we have twins for all recently created devices.
                await foreach (TwinData twin in twins)
                {
                    SampleLogger.PrintSuccess($"\t- Device Twin Id: '{twin.DeviceId}', ETag: '{twin.Etag}', Number of desired properties: {twin.Properties.Desired.Count}");
                }
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to get all device twins due to:\n{ex}");
                throw;
            }
        }


        /// <summary>
        /// Deletes multiple device identities in a single bulk operation.
        /// </summary>
        /// <param name="listOfDevices">List of device identities to delete.</param>
        public async Task DeleteDevicesInBulkAsync(IEnumerable<DeviceIdentity> listOfDevices)
        {
            SampleLogger.PrintHeader("DELETE DEVICE IDENTITIES IN BULK");

            Console.WriteLine($"Deleting the following device identities:\n{string.Join(", ", listOfDevices.Select(s => $"'{s.DeviceId}'"))}");

            try
            {
                Response<BulkRegistryOperationResponse> deleteResponse = await IoTHubServiceClient.Devices.DeleteIdentitiesAsync(listOfDevices, BulkIfMatchPrecondition.Unconditional);
                BulkRegistryOperationResponse operationResponse = deleteResponse.Value;

                if (operationResponse.IsSuccessful ?? false)
                {
                    SampleLogger.PrintSuccess($"Successfully deleted device identities:\n{string.Join(", ", listOfDevices.Select(s => $"'{s.DeviceId}'"))}");
                }
                else
                {
                    // TODO:(azabbasi) Print all the errors and warnings (this cannot be tested due to an issue with the swagger document)
                    // Refer to: https://msazure.visualstudio.com/One/_workitems/edit/7536750
                    SampleLogger.PrintWarning($"Not all devices were deleted successfully.");
                }
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to device identity due to:\n{ex}");
            }
        }

        private IEnumerable<DeviceIdentity> BuildMultipleDevices(string devicesPrefix, int deviceCount)
        {
            IList<DeviceIdentity> listOfDevices = new List<DeviceIdentity>();

            for (int i = 0; i < deviceCount; i++)
            {
                listOfDevices.Add(new DeviceIdentity
                {
                    DeviceId = $"{devicesPrefix}{Random.Next()}"
                });
            }

            return listOfDevices;
        }
    }
}

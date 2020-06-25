// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Iot.Hub.Service.Models;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.Iot.Hub.Service.Tests
{
    public class DevicesClientTests : E2eTestBase
    {
        private const int BULK_DEVICE_COUNT = 10;
        private TimeSpan QUERY_RETRY_LIMIT = TimeSpan.FromSeconds(10);

        public DevicesClientTests(bool isAsync)
            : base(isAsync)
        {
        }

        /// <summary>
        /// Test basic lifecycle of a Device Identity.
        /// This test includes CRUD operations only.
        /// </summary>
        [Test]
        public async Task Devices_IdentityLifecycle()
        {
            string testDeviceName = $"IdentityLifecycleDevice{GetRandom()}";

            DeviceIdentity device = null;

            IoTHubServiceClient client = GetClient();

            // Wrap all the operations in a try block to be able to cleanup in case of any failure.
            try
            {
                // Create a device
                Response<DeviceIdentity> createResponse = await client.Devices.CreateOrUpdateIdentityAsync(
                    new Models.DeviceIdentity
                    {
                        DeviceId = testDeviceName
                    }).ConfigureAwait(false);

                device = createResponse.Value;

                // Get device
                // Get the device and compare ETag values (should remain unchanged);
                Response<DeviceIdentity> getResponse = await client.Devices.GetIdentityAsync(testDeviceName).ConfigureAwait(false);

                getResponse.Value.Etag.Should().BeEquivalentTo(device.Etag, "ETag value should not have changed.");

                device = getResponse.Value;

                // Update a device
                device.Status = DeviceStatus.Disabled;

                // TODO: (azabbasi) We should leave the IfMatchPrecondition to be the default value once we know more about the fix.
                Response<DeviceIdentity> updateResponse = await client.Devices.CreateOrUpdateIdentityAsync(device, IfMatchPrecondition.UnconditionalIfMatch).ConfigureAwait(false);

                updateResponse.Value.Status.Should().Be(DeviceStatus.Disabled, "Device should have been disabled");

                // Delete the device
                // Deleting the device happens in the finally block as cleanup.
            }
            finally
            {
                await Cleanup(client, device);
            }
        }

        /// <summary>
        /// Test basic operations of a Device Twin.
        /// </summary>
        [Test]
        public async Task Devices_TwinLifecycle()
        {
            string testDeviceName = $"TwinLifecycleDevice{GetRandom()}";

            DeviceIdentity device = null;

            IoTHubServiceClient client = GetClient();

            // Wrap all the operations in a try block to be able to cleanup in case of any failure.
            try
            {
                // Create a device
                // Creating a device also creates a twin for the device.
                Response<DeviceIdentity> createResponse = await client.Devices.CreateOrUpdateIdentityAsync(
                    new Models.DeviceIdentity
                    {
                        DeviceId = testDeviceName
                    }).ConfigureAwait(false);

                device = createResponse.Value;

                // Get the device twin
                Response<TwinData> getResponse = await client.Devices.GetTwinAsync(testDeviceName).ConfigureAwait(false);
                TwinData deviceTwin = getResponse.Value;

                deviceTwin.DeviceId.Should().BeEquivalentTo(testDeviceName, "DeviceId on the Twin should match that of the device.");

                // Update device twin
                string propName = "username";
                string propValue = "userA";
                deviceTwin.Properties.Desired.Add(new KeyValuePair<string, object>(propName, propValue));

                // TODO: (azabbasi) We should leave the IfMatchPrecondition to be the default value once we know more about the fix.
                Response<TwinData> updateResponse = await client.Devices.UpdateTwinAsync(deviceTwin, IfMatchPrecondition.UnconditionalIfMatch).ConfigureAwait(false);

                updateResponse.Value.Properties.Desired.Where(p => p.Key == propName).First().Value.Should().Be(propValue, "Desired property value is incorrect.");

                // Delete the device
                // Deleting the device happens in the finally block as cleanup.
            }
            finally
            {
                await Cleanup(client, device);
            }
        }

        /// <summary>
        /// Test bulk Device creation.
        /// In this test we create multiple brand new devices and expect them all to be created with no issues.
        /// </summary>
        [Test]
        public async Task Devices_BulkCreation()
        {
            string testDeviceprefix = $"bulkDevice";

            IEnumerable<DeviceIdentity> devices = BuildMultipleDevices(testDeviceprefix, BULK_DEVICE_COUNT);

            IoTHubServiceClient client = GetClient();

            // Wrap all the operations in a try block to be able to cleanup in case of any failure.
            try
            {
                // Create all devices
                Response<BulkRegistryOperationResponse> createResponse = await client.Devices.CreateIdentitiesAsync(devices).ConfigureAwait(false);

                Assert.IsTrue(createResponse.Value.IsSuccessful, "Bulk device creation must be successful");
            }
            finally
            {
                await Cleanup(client, devices);
            }
        }

        /// <summary>
        /// Test bulk Device creation.
        /// All but one devices are going to be brand new. One device alreadyExists.
        /// </summary>
        [Test]
        [Ignore("DeviceRegistryOperationError cannot be parsed since service sends integer instead of a string")]
        public async Task Devices_BulkCreation_OneAlreadyExists()
        {
            string testDeviceprefix = $"bulkDevice";
            string existingDeviceName = $"{testDeviceprefix}{GetRandom()}";

            IoTHubServiceClient client = GetClient();
            IList<DeviceIdentity> devices = BuildMultipleDevices(testDeviceprefix, BULK_DEVICE_COUNT-1);

            // Wrap all the operations in a try block to be able to cleanup in case of any failure.
            try
            {
                // We first create a single device.
                Response<DeviceIdentity> response = await client.Devices.CreateOrUpdateIdentityAsync(new DeviceIdentity { DeviceId = existingDeviceName });

                // Add the existing device to the list of devices to be bulk created.
                devices.Add(response.Value);

                // Create all devices
                Response<BulkRegistryOperationResponse> createResponse = await client.Devices.CreateIdentitiesAsync(devices).ConfigureAwait(false);

                Assert.IsTrue(createResponse.Value.IsSuccessful, "Bulk device creation must be successful");
            }
            finally
            {
                await Cleanup(client, devices);
            }
        }

        /// <summary>
        /// Test bulk device and twin creation.
        /// </summary>
        [Test]
        public async Task Devices_BulkCreation_DeviceWithTwin()
        {
            string testDeviceprefix = $"bulkDeviceWithTwin";

            IoTHubServiceClient client = GetClient();

            IDictionary<string, object> desiredProperties = new Dictionary<string, object>
            {
                { "user", "userA" }
            };

            // We will build multiple devices and all of them with the same desired properties for convenience.
            IDictionary<DeviceIdentity, TwinData> devicesAndTwins = BuildDevicesAndTwins(testDeviceprefix, BULK_DEVICE_COUNT, desiredProperties);

            // Wrap all the operations in a try block to be able to cleanup in case of any failure.
            try
            {
                // Create all devices with twins
                Response<BulkRegistryOperationResponse> createResponse = await client.Devices.CreateIdentitiesWithTwinAsync(devicesAndTwins).ConfigureAwait(false);

                Assert.IsTrue(createResponse.Value.IsSuccessful, "Bulk device creation must be successful");
            }
            finally
            {
                await Cleanup(client, devicesAndTwins.Keys);
            }
        }

        /// <summary>
        /// Test query by getting all twins.
        /// </summary>
        [Test]
        public async Task Devices_Query_GetTwins()
        {
            string testDeviceprefix = $"bulkDevice";

            IEnumerable<DeviceIdentity> devices = BuildMultipleDevices(testDeviceprefix, BULK_DEVICE_COUNT);

            IoTHubServiceClient client = GetClient();

            // Wrap all the operations in a try block to be able to cleanup in case of any failure.
            try
            {
                // Create all devices
                Response<BulkRegistryOperationResponse> createResponse = await client.Devices.CreateIdentitiesAsync(devices).ConfigureAwait(false);

                Assert.IsTrue(createResponse.Value.IsSuccessful, "Bulk device creation must be successful");

                // We will retry the operation since it can take some time for the query to match what was recently created.
                int matchesFound = 0;
                DateTimeOffset startTime = DateTime.UtcNow;

                while (
                    matchesFound != BULK_DEVICE_COUNT
                    && DateTime.UtcNow - startTime < QUERY_RETRY_LIMIT)
                {
                    matchesFound = 0;
                    AsyncPageable<TwinData> twins = client.Devices.GetTwinsAsync();

                    // We will verify we have twins for all recently created devices.
                    await foreach (TwinData twin in twins)
                    {
                        if (devices.Any(d => d.DeviceId.Equals(twin.DeviceId, StringComparison.OrdinalIgnoreCase)))
                        {
                            matchesFound++;
                        }
                    }
                }

                matchesFound.Should().Be(BULK_DEVICE_COUNT, "Number of matching devices must be equal to count of recently created devices.");
            }
            finally
            {
                await Cleanup(client, devices);
            }
        }

        private IDictionary<DeviceIdentity, TwinData> BuildDevicesAndTwins(string testDeviceprefix, int deviceCount, IDictionary<string, object> desiredProperties)
        {
            IList<DeviceIdentity> devices = BuildMultipleDevices(testDeviceprefix, deviceCount);
            IDictionary<DeviceIdentity, TwinData> devicesAndTwins = new Dictionary<DeviceIdentity, TwinData>();

            foreach (DeviceIdentity device in devices)
            {
                devicesAndTwins.Add(device, new TwinData { Properties = new TwinProperties { Desired = desiredProperties } });
            }

            return devicesAndTwins;
        }

        private IList<DeviceIdentity> BuildMultipleDevices(string testDeviceprefix, int deviceCount)
        {
            List<DeviceIdentity> deviceList = new List<DeviceIdentity>();

            for (int i = 0; i < deviceCount; i++)
            {
                deviceList.Add(new DeviceIdentity { DeviceId = $"{testDeviceprefix}{GetRandom()}" });
            }

            return deviceList;
        }

        private async Task Cleanup(IoTHubServiceClient client, IEnumerable<DeviceIdentity> devices)
        {
            try
            {
                if (devices.Any())
                {
                    await client.Devices.DeleteIdentitiesAsync(devices, BulkIfMatchPrecondition.Unconditional);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test clean up failed: {ex.Message}");
            }
        }

        private async Task Cleanup(IoTHubServiceClient client, DeviceIdentity device)
        {
            // cleanup
            try
            {
                if (device != null)
                {
                    await client.Devices.DeleteIdentityAsync(device, IfMatchPrecondition.UnconditionalIfMatch).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test clean up failed: {ex.Message}");
            }
        }
    }
}

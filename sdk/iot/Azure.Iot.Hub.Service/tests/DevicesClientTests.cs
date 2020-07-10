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
    /// <summary>
    /// Test all APIs of a DeviceClient.
    /// </summary>
    /// <remarks>
    /// All API calls are wrapped in a try catch block so we can clean up resources regardless of the test outcome.
    /// </remarks>
    public class DevicesClientTests : E2eTestBase
    {
        private const int BULK_DEVICE_COUNT = 10;
        private readonly TimeSpan _queryMaxWaitTime = TimeSpan.FromSeconds(30);
        private readonly TimeSpan _queryRetryInterval = TimeSpan.FromSeconds(2);

        public DevicesClientTests(bool isAsync)
            : base(isAsync)
        {
        }

        /// <summary>
        /// Test basic lifecycle of a Device Identity.
        /// This test includes CRUD operations only.
        /// </summary>
        [Test]
        public async Task DevicesClient_IdentityLifecycle()
        {
            string testDeviceId = $"IdentityLifecycleDevice{GetRandom()}";

            DeviceIdentity device = null;
            IoTHubServiceClient client = GetClient();

            try
            {
                // Create a device
                Response<DeviceIdentity> createResponse = await client.Devices.CreateOrUpdateIdentityAsync(
                    new Models.DeviceIdentity
                    {
                        DeviceId = testDeviceId
                    }).ConfigureAwait(false);

                device = createResponse.Value;

                // Get device
                // Get the device and compare ETag values (should remain unchanged);
                Response<DeviceIdentity> getResponse = await client.Devices.GetIdentityAsync(testDeviceId).ConfigureAwait(false);

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
        /// Test the logic for ETag if-match header
        /// </summary>
        [Test]
        public async Task DevicesClient_UpdateDevice_EtagDoesNotMatch()
        {
            string testDeviceId = $"UpdateWithETag{GetRandom()}";

            DeviceIdentity device = null;
            IoTHubServiceClient client = GetClient();

            try
            {
                // Create a device
                Response<DeviceIdentity> createResponse = await client.Devices.CreateOrUpdateIdentityAsync(
                    new Models.DeviceIdentity
                    {
                        DeviceId = testDeviceId
                    }).ConfigureAwait(false);

                // Store the device object to later update it with invalid ETag
                device = createResponse.Value;

                // Update the device to get a new ETag value.
                device.Status = DeviceStatus.Disabled;
                Response<DeviceIdentity> getResponse = await client.Devices.CreateOrUpdateIdentityAsync(device).ConfigureAwait(false);
                DeviceIdentity updatedDevice = getResponse.Value;

                Assert.AreNotEqual(updatedDevice.Etag, device.Etag, "ETag should have been updated.");

                // Perform another update using the old device object to verify precondition fails.
                device.Status = DeviceStatus.Enabled;
                try
                {
                    Response<DeviceIdentity> updateResponse = await client.Devices.CreateOrUpdateIdentityAsync(device).ConfigureAwait(false);
                    Assert.Fail($"Update call with outdated ETag should fail with 412 (PreconditionFailed)");
                }
                // We will catch the exception and verify status is 412 (PreconditionfFailed)
                catch (RequestFailedException ex)
                {
                    Assert.AreEqual(412, ex.Status, $"Expected the update to fail with http status code 412 (PreconditionFailed)");
                }

                // Perform the same update and ignore the ETag value by providing UnconditionalIfMatch precondition
                await client.Devices.CreateOrUpdateIdentityAsync(device, IfMatchPrecondition.UnconditionalIfMatch).ConfigureAwait(false);
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
        public async Task DevicesClient_DeviceTwinLifecycle()
        {
            string testDeviceId = $"TwinLifecycleDevice{GetRandom()}";

            DeviceIdentity device = null;

            IoTHubServiceClient client = GetClient();

            try
            {
                // Create a device
                // Creating a device also creates a twin for the device.
                Response<DeviceIdentity> createResponse = await client.Devices.CreateOrUpdateIdentityAsync(
                    new Models.DeviceIdentity
                    {
                        DeviceId = testDeviceId
                    }).ConfigureAwait(false);

                device = createResponse.Value;

                // Get the device twin
                Response<TwinData> getResponse = await client.Devices.GetTwinAsync(testDeviceId).ConfigureAwait(false);
                TwinData deviceTwin = getResponse.Value;

                deviceTwin.DeviceId.Should().BeEquivalentTo(testDeviceId, "DeviceId on the Twin should match that of the device.");

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
        public async Task DevicesClient_BulkCreation()
        {
            string testDeviceprefix = $"bulkDevice";

            IEnumerable<DeviceIdentity> devices = BuildMultipleDevices(testDeviceprefix, BULK_DEVICE_COUNT);

            IoTHubServiceClient client = GetClient();

            try
            {
                // Create all devices
                Response<BulkRegistryOperationResponse> createResponse = await client.Devices.CreateIdentitiesAsync(devices).ConfigureAwait(false);

                Assert.IsTrue(createResponse.Value.IsSuccessful, "Bulk device creation ended with errors");
            }
            finally
            {
                await Cleanup(client, devices);
            }
        }

        /// <summary>
        /// Test bulk Device update.
        /// In this test we create multiple brand new devices and expect them all to be created with no issues.
        /// </summary>
        [Test]
        public async Task DevicesClient_BulkUpdate()
        {
            string testDeviceprefix = $"bulkDeviceUpdate";

            IoTHubServiceClient client = GetClient();
            IList<DeviceIdentity> listOfDevicesToUpdate = null;

            try
            {
                // Create two devices
                Response<DeviceIdentity> deviceOneCeateResponse = await client.Devices.CreateOrUpdateIdentityAsync(
                    new DeviceIdentity
                    {
                        DeviceId = $"{testDeviceprefix}{GetRandom()}",
                        Status = DeviceStatus.Enabled,
                    }).ConfigureAwait(false);

                Response<DeviceIdentity> deviceTwoCeateResponse = await client.Devices.CreateOrUpdateIdentityAsync(
                    new DeviceIdentity
                    {
                        DeviceId = $"{testDeviceprefix}{GetRandom()}",
                        Status = DeviceStatus.Enabled,
                    }).ConfigureAwait(false);

                DeviceIdentity deviceOne = deviceOneCeateResponse.Value;
                DeviceIdentity deviceTwo = deviceTwoCeateResponse.Value;

                listOfDevicesToUpdate = new List<DeviceIdentity> { deviceOne, deviceTwo };

                // Update device status to disabled.
                deviceOne.Status = DeviceStatus.Disabled;
                deviceTwo.Status = DeviceStatus.Disabled;

                // Make the API call to disable devices.
                Response<BulkRegistryOperationResponse> updateResponse =
                    await client.Devices.UpdateIdentitiesAsync(listOfDevicesToUpdate, BulkIfMatchPrecondition.Unconditional)
                    .ConfigureAwait(false);

                // TODO: (azabbasi) Once the issue with the error parsing is resolved, include the error message in the message of the assert statement.
                Assert.IsTrue(updateResponse.Value.IsSuccessful, "Bulk device update ended with errors");

                // Verify the devices status is updated.
                deviceOne = (await client.Devices.GetIdentityAsync(deviceOne.DeviceId)).Value;
                deviceTwo = (await client.Devices.GetIdentityAsync(deviceTwo.DeviceId)).Value;

                deviceOne.Status.Should().Be(DeviceStatus.Disabled, "Device should have been disabled");
                deviceTwo.Status.Should().Be(DeviceStatus.Disabled, "Device should have been disabled");
            }
            finally
            {
                await Cleanup(client, listOfDevicesToUpdate);
            }
        }

        /// <summary>
        /// Test bulk Device creation with an expected error.
        /// All but one devices are going to be brand new. One device already exists and we expect an error regarding that specific device.
        /// </summary>
        [Test]
        [Ignore("DeviceRegistryOperationError cannot be parsed since service sends integer instead of a string")]
        public async Task DevicesClient_BulkCreation_OneAlreadyExists()
        {
            string testDeviceprefix = $"bulkDevice";
            string existingDeviceName = $"{testDeviceprefix}{GetRandom()}";

            IoTHubServiceClient client = GetClient();
            IList<DeviceIdentity> devices = BuildMultipleDevices(testDeviceprefix, BULK_DEVICE_COUNT-1);

            try
            {
                // We first create a single device.
                Response<DeviceIdentity> response = await client.Devices.CreateOrUpdateIdentityAsync(new DeviceIdentity { DeviceId = existingDeviceName });

                // Add the existing device to the list of devices to be bulk created.
                devices.Add(response.Value);

                // Create all devices
                Response<BulkRegistryOperationResponse> createResponse = await client.Devices.CreateIdentitiesAsync(devices).ConfigureAwait(false);

                // TODO: (azabbasi) Once the issue with the error parsing is resolved, include the error message in the message of the assert statement.
                Assert.IsTrue(createResponse.Value.IsSuccessful, "Bulk device creation failed with errors");
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
        public async Task DevicesClient_BulkCreation_DeviceWithTwin()
        {
            string testDeviceprefix = $"bulkDeviceWithTwin";
            string userPropertyName = "user";
            string userPropertyValue = "userA";

            IoTHubServiceClient client = GetClient();

            IDictionary<string, object> desiredProperties = new Dictionary<string, object>
            {
                { userPropertyName, userPropertyValue }
            };

            // We will build multiple devices and all of them with the same desired properties for convenience.
            IDictionary<DeviceIdentity, TwinData> devicesAndTwins = BuildDevicesAndTwins(testDeviceprefix, BULK_DEVICE_COUNT, desiredProperties);

            try
            {
                // Create all devices with twins
                Response<BulkRegistryOperationResponse> createResponse = await client.Devices.CreateIdentitiesWithTwinAsync(devicesAndTwins).ConfigureAwait(false);

                // TODO: (azabbasi) Once the issue with the error parsing is resolved, include the error message in the message of the assert statement.
                Assert.IsTrue(createResponse.Value.IsSuccessful, "Bulk device creation ended with errors");

                // Verify that the desired properties were set
                // For quicker test run, we will only verify the first device on the list.
                Response<TwinData> getResponse = await client.Devices.GetTwinAsync(devicesAndTwins.Keys.First().DeviceId).ConfigureAwait(false);
                getResponse.Value.Properties.Desired[userPropertyName].Should().Be(userPropertyValue);
            }
            finally
            {
                await Cleanup(client, devicesAndTwins.Keys);
            }
        }

        /// <summary>
        /// Test query by getting all twins.
        /// For the purpose of this test, we will create multiple devices (and device twins as a byproduct)
        /// and list all twins and verify the query returns everything expected.
        /// </summary>
        [Test]
        public async Task DevicesClient_Query_GetTwins()
        {
            string testDeviceprefix = $"bulkDevice";

            IEnumerable<DeviceIdentity> devices = BuildMultipleDevices(testDeviceprefix, BULK_DEVICE_COUNT);

            IoTHubServiceClient client = GetClient();

            try
            {
                // Create all devices
                Response<BulkRegistryOperationResponse> createResponse = await client.Devices.CreateIdentitiesAsync(devices).ConfigureAwait(false);

                Assert.IsTrue(createResponse.Value.IsSuccessful, "Bulk device creation ended with errors");

                // We will retry the operation since it can take some time for the query to match what was recently created.
                int matchesFound = 0;
                DateTimeOffset startTime = DateTime.UtcNow;

                while (DateTime.UtcNow - startTime < _queryMaxWaitTime)
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

                    if (matchesFound == BULK_DEVICE_COUNT)
                    {
                        break;
                    }

                    await Task.Delay(_queryRetryInterval);
                }

                matchesFound.Should().Be(BULK_DEVICE_COUNT, "Timed out waiting for all the bulk created devices to be query-able." +
                    " Number of matching devices must be equal to the number of recently created devices.");
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
                if (devices != null && devices.Any())
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

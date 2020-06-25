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
                // CREATE A DEVICE
                Response<DeviceIdentity> createResponse = await client.Devices.CreateOrUpdateIdentityAsync(
                    new Models.DeviceIdentity
                    {
                        DeviceId = testDeviceName
                    }).ConfigureAwait(false);

                device = createResponse.Value;

                // GET DEVICE
                // Get the device and compare ETag values (should remain unchanged);
                Response<DeviceIdentity> getResponse = await client.Devices.GetIdentityAsync(testDeviceName).ConfigureAwait(false);

                getResponse.Value.Etag.Should().BeEquivalentTo(device.Etag, "ETag value should not have changed.");

                device = getResponse.Value;

                // UPDATE DEVICE
                device.Status = DeviceStatus.Disabled;

                // TODO: (azabbasi) We should leave the IfMatchPrecondition to be the default value once we know more about the fix.
                Response<DeviceIdentity> updateResponse = await client.Devices.CreateOrUpdateIdentityAsync(device, IfMatchPrecondition.UnconditionalIfMatch).ConfigureAwait(false);

                updateResponse.Value.Status.Should().Be(DeviceStatus.Disabled, "Device should have been disabled");

                // DELETE DEVICE
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
                // CREATE A DEVICE
                // Creating a device also creates a twin for the device.
                Response<DeviceIdentity> createResponse = await client.Devices.CreateOrUpdateIdentityAsync(
                    new Models.DeviceIdentity
                    {
                        DeviceId = testDeviceName
                    }).ConfigureAwait(false);

                device = createResponse.Value;

                // GET DEVICE TWIN
                Response<TwinData> getResponse = await client.Devices.GetTwinAsync(testDeviceName).ConfigureAwait(false);
                TwinData deviceTwin = getResponse.Value;

                deviceTwin.DeviceId.Should().BeEquivalentTo(testDeviceName, "DeviceId on the Twin should match that of the device.");

                // UPDATE DEVICE TWIN
                string propName = "username";
                string propValue = "userA";
                deviceTwin.Properties.Desired.Add(new KeyValuePair<string, object>(propName, propValue));

                // TODO: (azabbasi) We should leave the IfMatchPrecondition to be the default value once we know more about the fix.
                Response<TwinData> updateResponse = await client.Devices.UpdateTwinAsync(deviceTwin, IfMatchPrecondition.UnconditionalIfMatch).ConfigureAwait(false);

                updateResponse.Value.Properties.Desired.Where(p => p.Key == propName).First().Value.Should().Be(propValue, "Desired property value is incorrect.");

                // DELETE DEVICE
                // Deleting the device happens in the finally block as cleanup.
            }
            finally
            {
                await Cleanup(client, device);
            }
        }

        /// <summary>
        /// Test bulk Device creation.
        /// In this test we create 10 brand new devices and expect them all to be created with no issues.
        /// </summary>
        [Test]
        public async Task Devices_BulkCreation()
        {
            string testDeviceprefix = $"bulkDevice";

            IEnumerable<DeviceIdentity> devices = CreateMultipleDevices(testDeviceprefix, 10);

            IoTHubServiceClient client = GetClient();

            // Wrap all the operations in a try block to be able to cleanup in case of any failure.
            try
            {
                // CREATE ALL DEVICES
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
        /// 9 out of 10 devices are going to be brand new. One device alreadyExists.
        /// </summary>
        [Test]
        [Ignore("DeviceRegistryOperationError cannot be parsed since service sends integer instead of a string")]
        public async Task Devices_BulkCreation_OneAlreadyExists()
        {
            string testDeviceprefix = $"bulkDevice";
            string existingDeviceName = $"{testDeviceprefix}{GetRandom()}";

            IoTHubServiceClient client = GetClient();
            // We first create a single device.
            IList<DeviceIdentity> devices = CreateMultipleDevices(testDeviceprefix, 9);

            // Wrap all the operations in a try block to be able to cleanup in case of any failure.
            try
            {
                var response = await client.Devices.CreateOrUpdateIdentityAsync(new DeviceIdentity { DeviceId = existingDeviceName });

                // Add the existing device to the list of devices to be bulk created.
                devices.Add(response.Value);

                // CREATE ALL DEVICES
                Response<BulkRegistryOperationResponse> createResponse = await client.Devices.CreateIdentitiesAsync(devices).ConfigureAwait(false);

                Assert.IsTrue(createResponse.Value.IsSuccessful, "Bulk device creation must be successful");
            }
            finally
            {
                await Cleanup(client, devices);
            }
        }

        private IList<DeviceIdentity> CreateMultipleDevices(string testDeviceprefix, int deviceCount)
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
            foreach (var device in devices)
            {
                await Cleanup(client, device);
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

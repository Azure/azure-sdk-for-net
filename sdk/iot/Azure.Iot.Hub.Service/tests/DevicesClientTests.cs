// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
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

        [Test]
        [Category("Live")]
        public async Task Devices_Lifecycle()
        {
            // TODO: This is just a verification that tests run and it requires the tester to complete this test however they see fit.
            string testDeviceName = $"testDevice{GetRandom()}";

            DeviceIdentity device = null;

            IoTHubServiceClient client = GetClient();
            try
            {
                try
                {
                    device = (await client.Devices.GetIdentityAsync(testDeviceName).ConfigureAwait(false)).Value;
                }
                catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.NotFound)
                {
                    // If the Device doesn't exist, we will create it.
                    device = (await client.Devices.CreateOrUpdateIdentityAsync(
                        new Models.DeviceIdentity
                        {
                            DeviceId = testDeviceName
                        }).ConfigureAwait(false)).Value;
                }

                // Perform another GET. We expect the device to exist.
                Response<Models.DeviceIdentity> response = await client.Devices.GetIdentityAsync(testDeviceName).ConfigureAwait(false);
                device = response.Value;
                response.GetRawResponse().Status.Should().Be(200);
            }
            finally
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
}

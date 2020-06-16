// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Threading.Tasks;
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
        public async Task Devices_Lifecycle()
        {
            // TODO: This is just a verification that tests run and it requires the tester to complete this test however they see fit.
            string testDeviceName = GetRandom();

            IoTHubServiceClient client = GetClient();

            try
            {
                await client.Devices.GetIdentityAsync(testDeviceName).ConfigureAwait(false);
            }
            catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.NotFound)
            {
                // If the Device doesn't exist, we will create it.
                await client.Devices.CreateOrUpdateIdentityAsync(
                new Models.DeviceIdentity
                {
                    DeviceId = testDeviceName
                }).ConfigureAwait(false);
            }

            // Perform another GET. We expect the device to exist.
            Response<Models.DeviceIdentity> response = await client.Devices.GetIdentityAsync(testDeviceName).ConfigureAwait(false);
            response.GetRawResponse().Status.Should().Be(200);

            // Delete the device at the end.
            await client.Devices.DeleteIdentityAsync(response.Value, IfMatchPrecondition.UnconditionalIfMatch).ConfigureAwait(false);
        }
    }
}

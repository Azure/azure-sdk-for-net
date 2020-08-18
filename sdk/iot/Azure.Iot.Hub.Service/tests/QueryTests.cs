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
    /// Test the query API. This API is a query on Twins only.
    /// </summary>
    /// <remarks>
    /// All API calls are wrapped in a try catch block so we can clean up resources regardless of the test outcome.
    /// </remarks>
    public class QueryTests : E2eTestBase
    {
        private const int _maxTryCount = 10;

        public QueryTests(bool isAsync)
            : base(isAsync)
        {
        }

        /// <summary>
        /// Test querying all device twins in the IoTHub.
        /// </summary>
        [Test]
        public async Task QueryClient_GetAllDevicesTwinsWithTag()
        {
            string testDeviceId = $"QueryDevice{GetRandom()}";

            DeviceIdentity device = null;
            IotHubServiceClient client = GetClient();

            try
            {
                // Create a device.
                device = (await client.Devices
                    .CreateOrUpdateIdentityAsync(
                        new DeviceIdentity
                        {
                            DeviceId = testDeviceId
                        })
                    .ConfigureAwait(false))
                    .Value;

                int tryCount = 0;
                var twinsFound = new List<TwinData>();
                // A new device may not return immediately from a query, so give it some time and some retries to appear.
                while (tryCount < _maxTryCount && !twinsFound.Any())
                {
                    // Query for device twins with a specific tag.
                    AsyncPageable<TwinData> queryResponse = client.Query.QueryAsync($"SELECT * FROM devices WHERE deviceId = '{testDeviceId}'");
                    await foreach (TwinData item in queryResponse)
                    {
                        twinsFound.Add(item);
                    }

                    tryCount++;

                    // Adding a delay to account for query cache sync.
                    await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(false);
                }

                twinsFound.Count.Should().Be(1);
                twinsFound.First().DeviceId.Should().Be(testDeviceId);

                // Delete the device
                // Deleting the device happens in the finally block as cleanup.
            }
            finally
            {
                await CleanupAsync(client, device).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Test querying all module twins in the IoTHub.
        /// </summary>
        [Test]
        public async Task QueryClient_GetAllModulesTwinsWithTag()
        {
            string testDeviceId = $"QueryDevice{GetRandom()}";
            string testModuleId = $"QueryModule{GetRandom()}";

            DeviceIdentity device = null;
            IotHubServiceClient client = GetClient();

            try
            {
                // Create a device to house the module
                device = (await client.Devices
                    .CreateOrUpdateIdentityAsync(
                        new DeviceIdentity
                        {
                            DeviceId = testDeviceId
                        })
                    .ConfigureAwait(false))
                    .Value;

                // Create a module on the device
                Response<ModuleIdentity> createResponse = await client.Modules
                    .CreateOrUpdateIdentityAsync(
                        new ModuleIdentity
                        {
                            DeviceId = testDeviceId,
                            ModuleId = testModuleId
                        })
                    .ConfigureAwait(false);

                int tryCount = 0;
                var twinsFound = new List<TwinData>();
                // A new device may not return immediately from a query, so give it some time and some retries to appear.
                while (tryCount < _maxTryCount && !twinsFound.Any())
                {
                    // Query for module twins with a specific tag.
                    AsyncPageable<TwinData> queryResponse = client.Query.QueryAsync($"SELECT * FROM devices.modules WHERE moduleId = '{testModuleId}'");
                    await foreach (TwinData item in queryResponse)
                    {
                        twinsFound.Add(item);
                    }

                    tryCount++;

                    // Adding a delay to account for query cache sync.
                    await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(false);
                }

                twinsFound.Count.Should().Be(1);
                twinsFound.First().ModuleId.Should().Be(testModuleId);

                // Delete the device
                // Deleting the device happens in the finally block as cleanup.
            }
            finally
            {
                await CleanupAsync(client, device).ConfigureAwait(false);
            }
        }

        private async Task CleanupAsync(IotHubServiceClient client, DeviceIdentity device)
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

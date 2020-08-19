// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Iot.Hub.Service.Models;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.Iot.Hub.Service.Tests
{
    /// <summary>
    /// Test all APIs of JobsClient.
    /// Note: The IoTHub can only run one job at a time so these tests cannot be run in parallel.
    /// </summary>
    /// <remarks>
    /// All API calls are wrapped in a try catch block so we can clean up resources regardless of the test outcome.
    /// </remarks>
    [Parallelizable(ParallelScope.None)]
    public class JobsClientTests : E2eTestBase
    {
        private const int DEVICE_COUNT = 5;

        public JobsClientTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task Jobs_Export_Import_Lifecycle()
        {
            // setup
            string testDevicePrefix = $"jobDevice";
            IEnumerable<DeviceIdentity> deviceIdentities = null;

            IotHubServiceClient client = GetClient();

            try
            {
                //Create multiple devices.
                deviceIdentities = BuildMultipleDevices(testDevicePrefix, DEVICE_COUNT);
                await client.Devices.CreateIdentitiesAsync(deviceIdentities).ConfigureAwait(false);

                // Export all devices to blob storage.
                Response<JobProperties> response = await client.Jobs
                    .CreateExportDevicesJobAsync(outputBlobContainerUri: TestEnvironment.StorageSasToken, excludeKeys: false)
                    .ConfigureAwait(false);

                response.GetRawResponse().Status.Should().Be(200);

                // Wait for job completion and validate result.
                response = await WaitForJobCompletionAsync(client, response.Value.JobId).ConfigureAwait(false);
                response.Value.Status.Should().Be(JobPropertiesStatus.Completed);

                //Import all devices from storage to create and provision devices on the IoTHub.
                response = await client.Jobs
                    .CreateImportDevicesJobAsync(TestEnvironment.StorageSasToken, TestEnvironment.StorageSasToken)
                    .ConfigureAwait(false);

                response.GetRawResponse().Status.Should().Be(200);

                // Wait for job completion and validate result.
                response = await WaitForJobCompletionAsync(client, response.Value.JobId).ConfigureAwait(false);
                response.Value.Status.Should().Be(JobPropertiesStatus.Completed);
            }
            finally
            {
                await CleanupAsync(client, deviceIdentities).ConfigureAwait(false);
            }
        }

        private IList<DeviceIdentity> BuildMultipleDevices(string testDevicePrefix, int deviceCount)
        {
            List<DeviceIdentity> deviceList = new List<DeviceIdentity>();

            for (int i = 0; i < deviceCount; i++)
            {
                deviceList.Add(new DeviceIdentity { DeviceId = $"{testDevicePrefix}{GetRandom()}" });
            }

            return deviceList;
        }

        private async Task CleanupAsync(IotHubServiceClient client, IEnumerable<DeviceIdentity> deviceIdentities)
        {
            // Delete all devices.
            if (deviceIdentities != null)
            {
                await client.Devices.DeleteIdentitiesAsync(deviceIdentities).ConfigureAwait(false);
            }
        }

        private async Task<Response<JobProperties>> WaitForJobCompletionAsync(IotHubServiceClient client, string jobId)
        {
            Response<JobProperties> response;

            // Wait for job to complete.
            do
            {
                response = await client.Jobs.GetImportExportJobAsync(jobId).ConfigureAwait(false);

                // We do not need to really wait when running on mocked values(Playback mode).
                // This will speed up testing in Playback mode and the PR pipeline.
                if (TestSettings.Instance.TestMode != Core.TestFramework.RecordedTestMode.Playback)
                {
                    await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(false);
                }
            } while (!IsTerminalStatus(response.Value.Status));

            return response;
        }

        private bool IsTerminalStatus(JobPropertiesStatus? status)
        {
            return status == JobPropertiesStatus.Completed
                || status == JobPropertiesStatus.Failed
                || status == JobPropertiesStatus.Cancelled;
        }
    }
}

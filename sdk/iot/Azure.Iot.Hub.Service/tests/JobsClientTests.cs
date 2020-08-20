// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Iot.Hub.Service.Models;
using FluentAssertions;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
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
    [Ignore("Ignore till storage is fixed for playback")]
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

            var containerName = "jobs" + GetRandom();
            Uri containerSasUri = await GetSasUriAsync(containerName).ConfigureAwait(false);

            IotHubServiceClient client = GetClient();

            try
            {
                //Create multiple devices.
                deviceIdentities = BuildMultipleDevices(testDevicePrefix, DEVICE_COUNT);
                await client.Devices.CreateIdentitiesAsync(deviceIdentities).ConfigureAwait(false);

                // Export all devices to blob storage.
                Response<JobProperties> response = await client.Jobs
                    .CreateExportDevicesJobAsync(outputBlobContainerUri: containerSasUri, excludeKeys: false)
                    .ConfigureAwait(false);

                response.GetRawResponse().Status.Should().Be(200);

                // Wait for job completion and validate result.
                response = await WaitForJobCompletionAsync(client, response.Value.JobId).ConfigureAwait(false);
                response.Value.Status.Should().Be(JobPropertiesStatus.Completed);

                //Import all devices from storage to create and provision devices on the IoTHub.
                var importJobRequestOptions = new ImportJobRequestOptions
                {
                    OutputBlobName = "Devices.txt" // default location where devices are created by blob.
                };
                response = await client.Jobs.CreateImportDevicesJobAsync(containerSasUri, containerSasUri, importJobRequestOptions).ConfigureAwait(false);

                response.GetRawResponse().Status.Should().Be(200);

                // Wait for job completion and validate result.
                response = await WaitForJobCompletionAsync(client, response.Value.JobId).ConfigureAwait(false);
                response.Value.Status.Should().Be(JobPropertiesStatus.Completed);
            }
            finally
            {
                await CleanupAsync(containerName, client, deviceIdentities).ConfigureAwait(false);
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

        private async Task CleanupAsync(string containerName, IotHubServiceClient client, IEnumerable<DeviceIdentity> deviceIdentities)
        {
            // Delete container
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(TestEnvironment.StorageConnectionString);
            CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = cloudBlobClient.GetContainerReference(containerName);
            await container.DeleteIfExistsAsync().ConfigureAwait(false);

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
                await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(false);
            } while (!IsTerminalStatus(response.Value.Status));

            return response;
        }

        private bool IsTerminalStatus(JobPropertiesStatus? status)
        {
            return status == JobPropertiesStatus.Completed
                || status == JobPropertiesStatus.Failed
                || status == JobPropertiesStatus.Cancelled;
        }

        // TODO: Move to arm template so that we can run this in playback mode. There is no way to mock CloudBlobClient using Azure.Core.TestFramework.
        private async Task<Uri> GetSasUriAsync(string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(TestEnvironment.StorageConnectionString);
            CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = cloudBlobClient.GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync().ConfigureAwait(false);

            var containerUri = container.Uri;
            var constraints = new SharedAccessBlobPolicy
            {
                SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddHours(1),
                Permissions = SharedAccessBlobPermissions.Read
                    | SharedAccessBlobPermissions.Write
                    | SharedAccessBlobPermissions.Create
                    | SharedAccessBlobPermissions.List
                    | SharedAccessBlobPermissions.Add
                    | SharedAccessBlobPermissions.Delete,
                SharedAccessStartTime = DateTimeOffset.UtcNow,
            };

            string sasContainerToken = container.GetSharedAccessSignature(constraints);

            return new Uri($"{containerUri}{sasContainerToken}");
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Iot.Hub.Service.Models;
using Castle.Core.Internal;
using FluentAssertions;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using NUnit.Framework;

namespace Azure.Iot.Hub.Service.Tests
{
    public class JobsClientTests : E2eTestBase
    {
        public JobsClientTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task Jobs_Export_Import_Lifecycle()
        {
            // setup
            var storageAccountConnectionString = "DefaultEndpointsProtocol=https;AccountName=prmathurfu;AccountKey=HMwaBvW3z3jf6xO6xRJY1apLuLwgO6IHmboyzwD7wT9tRcuvV5HUyNZSKm5pL0XCl0CZzWZXRu4WLBWdUleIAQ==;EndpointSuffix=core.windows.net";
            var containerName = "jobs" + Guid.NewGuid();
            Uri containerSasUri = await GetSasUri(storageAccountConnectionString, containerName).ConfigureAwait(false);

            IoTHubServiceClient client = GetClient();
            //Create multiple devices and export it to blob
            IList<DeviceIdentity> devices = await GetDevicesWrittenToBlob(client, containerSasUri, 2);
            Assert.IsTrue(!devices.IsNullOrEmpty());

            //Use job import to create and provision devices on hub in mixed auth modes
            await ImportJobs(client, containerSasUri);

            await cleanUp(storageAccountConnectionString, containerName);
        }

        private async Task cleanUp(String storageAccountConnectionString, String containerName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageAccountConnectionString);
            CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
            //delete container;
            CloudBlobContainer container = cloudBlobClient.GetContainerReference(containerName);
            await container.DeleteIfExistsAsync().ConfigureAwait(false);
        }

        private async Task ExportJobs(IoTHubServiceClient client, Uri containerSasUri)
        {
            // act
            try
            {
                Response<JobProperties> response = await client.Jobs.CreateExportDevicesJobAsync(containerSasUri, false).ConfigureAwait(false);
                response.GetRawResponse().Status.Should().Be(200);
                JobProperties jobProperties = response.Value;
                await WaitForJobCompletion(response.Value, client, 5);
            }
            catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.NotFound)
            {
                //log and throw
            }
        }

        private async Task WaitForJobCompletion(JobProperties jobProperties, IoTHubServiceClient client, double waitTimeInSecs)
        {
            Response<JobProperties> response;
            do
            {
                response = await client.Jobs.GetImportExportJobAsync(jobProperties.JobId).ConfigureAwait(false);
                await Task.Delay(TimeSpan.FromSeconds(waitTimeInSecs));
            } while (!((response.Value.Status == JobPropertiesStatus.Completed) ||
                        (response.Value.Status == JobPropertiesStatus.Failed) ||
                        (response.Value.Status == JobPropertiesStatus.Cancelled)));

            Assert.AreEqual(response.Value.Status, JobPropertiesStatus.Completed);
        }

        private async Task ImportJobs(IoTHubServiceClient client, Uri containerSasUri)
        {
            var importJobRequestOptions = new ImportJobRequestOptions
            {
                OutputBlobName = "Devices.txt" // default location where devices are created by blob.
            };

            // act
            try
            {
                Response<JobProperties> response = await client.Jobs.CreateImportDevicesJobAsync(containerSasUri, containerSasUri, importJobRequestOptions).ConfigureAwait(false);
                Assert.AreEqual(response.GetRawResponse().Status, 200);
                await WaitForJobCompletion(response.Value, client, 5);
            }
            catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.NotFound)
            {
                Assert.Fail($"Create Import failed : {ex.Message}");
            }
        }

        private async Task<List<DeviceIdentity>> GetDevicesWrittenToBlob(IoTHubServiceClient client, Uri containerSasUri, int NumberOfDevices)
        {
            string testDevicePrefix = $"JobsLifecycleDevice";

            // Create devices
            List<DeviceIdentity> devicesList = new List<DeviceIdentity>();
            for (int i =0; i < NumberOfDevices; i++)
            {
                devicesList.Add(new DeviceIdentity { DeviceId = $"{testDevicePrefix}{GetRandom()}" });
            }

            Response<BulkRegistryOperationResponse> createResponse = await client.Devices.CreateIdentitiesAsync(devicesList).ConfigureAwait(false);

            Assert.IsTrue(createResponse.Value.IsSuccessful, "Bulk device creation ended with errors");

            // Export to store it in blob
            await ExportJobs(client, containerSasUri);

            //Delete Devices

            try
            {
                if (devicesList != null && devicesList.Any())
                {
                    await client.Devices.DeleteIdentitiesAsync(devicesList, BulkIfMatchPrecondition.Unconditional);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Delete Devices failed : {ex.Message}");
            }

            return devicesList;
        }

        private static async Task<Uri> GetSasUri(string storageAccountConnectionString, string containerName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageAccountConnectionString);
            CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer CloudBlobContainer = cloudBlobClient.GetContainerReference(containerName);
            await CloudBlobContainer.CreateIfNotExistsAsync().ConfigureAwait(false);

            Uri containerUri = CloudBlobContainer.Uri;
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

            string sasContainerToken = CloudBlobContainer.GetSharedAccessSignature(constraints);
            Uri sasUri = new Uri($"{containerUri}{sasContainerToken}");
            return sasUri;
        }
    }
}

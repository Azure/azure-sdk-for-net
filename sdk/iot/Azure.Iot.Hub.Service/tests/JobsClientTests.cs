// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Iot.Hub.Service.Models;
using FluentAssertions;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using NUnit.Framework;

namespace Azure.Iot.Hub.Service.Tests
{
    // TODO: The is a temporary test suite to ensure functionality as we are building the API. It is not meant to be an official
    // e2e test. Proper e2e tests should be written as the code matures.
    public class JobsClientTests : E2eTestBase
    {
        public JobsClientTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task Jobs_Export_E2E()
        {
            // setup
            var storageAccountConnectionString = "";
            var containerName = "jobs";
            Uri outputContainerSasUri = await GetSasUri(storageAccountConnectionString, containerName).ConfigureAwait(false);

            IoTHubServiceClient client = GetClient();

            // act
            try
            {
                Response<JobProperties> response1 = await client.Jobs.CreateExportDevicesJobAsync(outputContainerSasUri, false).ConfigureAwait(false);
                response1.GetRawResponse().Status.Should().Be(200);
            }
            catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.NotFound)
            {
            }
        }

        [Test]
        public async Task Jobs_Import_E2E()
        {
            // setup
            var storageAccountConnectionString = "";
            var containerName = "jobs";
            Uri containerSasUri = await GetSasUri(storageAccountConnectionString, containerName).ConfigureAwait(false);

            IoTHubServiceClient client = GetClient();

            var importJobRequestOptions = new ImportJobRequestOptions
            {
                InputBloblName = "importDevices.txt",
                OutputBlobName = "outputDevices.txt"
            };

            // act
            try
            {
                Response<JobProperties> response1 = await client.Jobs.CreateImportDevicesJobAsync(containerSasUri, containerSasUri, importJobRequestOptions).ConfigureAwait(false);
                response1.GetRawResponse().Status.Should().Be(200);
            }
            catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.NotFound)
            {
            }
        }

        [Test]
        public async Task Jobs_GetImportExportJobs_E2E()
        {
            // setup
            IoTHubServiceClient client = GetClient();

            // act
            try
            {
                Response<System.Collections.Generic.IReadOnlyList<JobProperties>> response = await client.Jobs.GetImportExportJobsAsync().ConfigureAwait(false);
            }
            catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.NotFound)
            {
            }
        }

        [Test]
        public async Task Jobs_GetImportExportJob_E2E()
        {
            // setup
            IoTHubServiceClient client = GetClient();

            // act
            try
            {
                Response<JobProperties> response = await client.Jobs.GetImportExportJobAsync("4710a036-da2b-4979-be0d-bfb7fa3e8441").ConfigureAwait(false);
            }
            catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.NotFound)
            {
            }
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

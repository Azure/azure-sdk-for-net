// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;
using Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Azure.WebJobs.Extensions.Storage.Blobs.Samples.Tests
{
    public class BlobTriggerAttributeSample
    {
        [TestCase(typeof(BlobTriggerBindingFunction))]
        public async Task Run_BlobTriggerBindingFunction(Type programType)
        {
            var containerClient = AzuriteNUnitFixture.Instance.GetBlobServiceClient().GetBlobContainerClient("sample-container");
            await containerClient.CreateIfNotExistsAsync();
            var blobClient = containerClient.GetBlockBlobClient("sample-blob.txt");
            await blobClient.UploadTextAsync("content");
            await RunTrigger(programType);
        }

        private async Task RunTrigger(Type programType)
        {
            await FunctionalTest.RunTriggerAsync(b => {
                b.Services.AddAzureClients(builder =>
                {
                    builder.ConfigureDefaults(options => options.Transport = AzuriteNUnitFixture.Instance.GetTransport());
                });
                b.AddAzureStorageBlobs();
            }, programType,
            settings: new Dictionary<string, string>() {
                // This takes precedence over env variables.
                { "ConnectionStrings:AzureWebJobsStorage", AzuriteNUnitFixture.Instance.GetAzureAccount().ConnectionString }
            });
        }
    }

    #region Snippet:BlobTriggerBindingFunction_String
    public static class BlobTriggerBindingFunction
    {
        [FunctionName("BlobTriggerBindingFunction")]
        public static void Run([BlobTrigger("sample-container/sample-blob.txt")] string blobContent, ILogger logger)
        {
            logger.LogInformation("Blob has been updated with content: {content}", blobContent);
        }
    }
    #endregion
}

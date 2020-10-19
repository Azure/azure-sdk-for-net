// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using System;
using System.Collections.Generic;
using System.IO;
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
        [TestCase(typeof(BlobTriggerFunction_String))]
        [TestCase(typeof(BlobTriggerFunction_Stream))]
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

    #region Snippet:BlobTriggerFunction_String
    public static class BlobTriggerFunction_String
    {
        [FunctionName("BlobTriggerFunction")]
        public static void Run([BlobTrigger("sample-container/sample-blob.txt")] string blobContent, ILogger logger)
        {
            logger.LogInformation("Blob has been updated with content: {content}", blobContent);
        }
    }
    #endregion

    #region Snippet:BlobTriggerFunction_Stream
    public static class BlobTriggerFunction_Stream
    {
        [FunctionName("BlobTriggerFunction")]
        public static void Run([BlobTrigger("sample-container/sample-blob.txt")] Stream streamContent, ILogger logger)
        {
            using var streamReader = new StreamReader(streamContent);
            logger.LogInformation("Blob has been updated with content: {content}", streamReader.ReadToEnd());
        }
    }
    #endregion
}

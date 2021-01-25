// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Samples.Tests
{
    public class BlobExtensionSamples
    {
        [TestCase(typeof(BlobFunction_String))]
        [TestCase(typeof(BlobFunction_ReadStream))]
        [TestCase(typeof(BlobFunction_WriteStream))]
        [TestCase(typeof(BlobFunction_BlobClient))]
        public async Task Run_BlobFunction(Type programType)
        {
            var containerClient = AzuriteNUnitFixture.Instance.GetBlobServiceClient().GetBlobContainerClient("sample-container");
            await containerClient.CreateIfNotExistsAsync();
            await containerClient.GetBlockBlobClient("sample-blob").UploadTextAsync("content");
            await containerClient.GetBlockBlobClient("sample-blob-1").UploadTextAsync("content-1");
            await containerClient.GetBlockBlobClient("sample-blob-2").UploadTextAsync("content-2");
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

    #region Snippet:BlobFunction_String
    public static class BlobFunction_String
    {
        [FunctionName("BlobFunction")]
        public static void Run(
            [BlobTrigger("sample-container/sample-blob-1")] string blobTriggerContent,
            [Blob("sample-container/sample-blob-2")] string blobContent,
            ILogger logger)
        {
            logger.LogInformation("Blob sample-container/sample-blob-1 has been updated with content: {content}", blobTriggerContent);
            logger.LogInformation("Blob sample-container/sample-blob-2 has content: {content}", blobContent);
        }
    }
    #endregion

    #region Snippet:BlobFunction_ReadStream
    public static class BlobFunction_ReadStream
    {
        [FunctionName("BlobFunction")]
        public static void Run(
            [BlobTrigger("sample-container/sample-blob-1")] Stream blobTriggerStream,
            [Blob("sample-container/sample-blob-2", FileAccess.Read)] Stream blobStream,
            ILogger logger)
        {
            using var blobTriggerStreamReader = new StreamReader(blobTriggerStream);
            logger.LogInformation("Blob sample-container/sample-blob-1 has been updated with content: {content}", blobTriggerStreamReader.ReadToEnd());
            using var blobStreamReader = new StreamReader(blobStream);
            logger.LogInformation("Blob sample-container/sample-blob-2 has content: {content}", blobStreamReader.ReadToEnd());
        }
    }
    #endregion

    #region Snippet:BlobFunction_WriteStream
    public static class BlobFunction_WriteStream
    {
        [FunctionName("BlobFunction")]
        public static async Task Run(
            [BlobTrigger("sample-container/sample-blob-1")] Stream blobTriggerStream,
            [Blob("sample-container/sample-blob-2", FileAccess.Write)] Stream blobStream,
            ILogger logger)
        {
            await blobTriggerStream.CopyToAsync(blobStream);
            logger.LogInformation("Blob sample-container/sample-blob-1 has been copied to sample-container/sample-blob-2");
        }
    }
    #endregion

    #region Snippet:BlobFunction_BlobClient
    public static class BlobFunction_BlobClient
    {
        [FunctionName("BlobFunction")]
        public static async Task Run(
            [BlobTrigger("sample-container/sample-blob-1")] BlobClient blobTriggerClient,
            [Blob("sample-container/sample-blob-2")] BlobClient blobClient,
            ILogger logger)
        {
            BlobProperties blobTriggerProperties = await blobTriggerClient.GetPropertiesAsync();
            logger.LogInformation("Blob sample-container/sample-blob-1 has been updated on: {datetime}", blobTriggerProperties.LastModified);
            BlobProperties blobProperties = await blobClient.GetPropertiesAsync();
            logger.LogInformation("Blob sample-container/sample-blob-2 has been updated on: {datetime}", blobProperties.LastModified);
        }
    }
    #endregion
}

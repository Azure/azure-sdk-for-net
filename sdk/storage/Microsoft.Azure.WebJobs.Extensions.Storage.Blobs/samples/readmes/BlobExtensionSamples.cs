// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
        [TestCase(typeof(BlobFunction_ReactToBlobChange))]
        [TestCase(typeof(BlobFunction_String))]
        [TestCase(typeof(BlobFunction_ByteArray))]
        [TestCase(typeof(BlobFunction_String_Write))]
        [TestCase(typeof(BlobFunction_ByteArray_Write))]
        [TestCase(typeof(BlobFunction_ReadStream))]
        [TestCase(typeof(BlobFunction_WriteStream))]
        [TestCase(typeof(BlobFunction_BlobClient))]
        [TestCase(typeof(BlobFunction_TextReader_TextWriter))]
        [TestCase(typeof(BlobFunction_AccessContainer))]
        [TestCase(typeof(BlobFunction_EnumerateBlobs_Stream))]
        [TestCase(typeof(BlobFunction_EnumerateBlobs_BlobClient))]
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

    #region Snippet:BlobFunction_ReactToBlobChange
    public static class BlobFunction_ReactToBlobChange
    {
        [FunctionName("BlobFunction")]
        public static void Run(
            [BlobTrigger("sample-container/sample-blob")] Stream blobStream,
            ILogger logger)
        {
            using var blobStreamReader = new StreamReader(blobStream);
            logger.LogInformation("Blob sample-container/sample-blob has been updated with content: {content}", blobStreamReader.ReadToEnd());
        }
    }
    #endregion

    // This doesn't work with Azurite so it's not run, just for compilation here.
    #region Snippet:BlobFunction_ReactToBlobChange_EventGrid
    public static class BlobFunction_ReactToBlobChange_EventGrid
    {
        [FunctionName("BlobFunction")]
        public static void Run(
            [BlobTrigger("sample-container/sample-blob", Source = BlobTriggerSource.EventGrid)] Stream blobStream,
            ILogger logger)
        {
            using var blobStreamReader = new StreamReader(blobStream);
            logger.LogInformation("Blob sample-container/sample-blob has been updated with content: {content}", blobStreamReader.ReadToEnd());
        }
    }
    #endregion

    #region Snippet:BlobFunction_String
    public static class BlobFunction_String
    {
        [FunctionName("BlobFunction")]
        public static void Run(
            [BlobTrigger("sample-container/sample-blob-1")] string blobContent1,
            [Blob("sample-container/sample-blob-2")] string blobContent2,
            ILogger logger)
        {
            logger.LogInformation("Blob sample-container/sample-blob-1 has been updated with content: {content}", blobContent1);
            logger.LogInformation("Blob sample-container/sample-blob-2 has content: {content}", blobContent2);
        }
    }
    #endregion

    #region Snippet:BlobFunction_ByteArray
    public static class BlobFunction_ByteArray
    {
        [FunctionName("BlobFunction")]
        public static void Run(
            [BlobTrigger("sample-container/sample-blob-1")] byte[] blobContent1,
            [Blob("sample-container/sample-blob-2")] byte[] blobContent2,
            ILogger logger)
        {
            logger.LogInformation("Blob sample-container/sample-blob-1 has been updated with content: {content}", Encoding.UTF8.GetString(blobContent1));
            logger.LogInformation("Blob sample-container/sample-blob-2 has content: {content}", Encoding.UTF8.GetString(blobContent2));
        }
    }
    #endregion

    #region Snippet:BlobFunction_ByteArray_Write
    public static class BlobFunction_ByteArray_Write
    {
        [FunctionName("BlobFunction")]
        public static void Run(
            [BlobTrigger("sample-container/sample-blob-1")] byte[] blobContent1,
            [Blob("sample-container/sample-blob-2")] out byte[] blobContent2,
            ILogger logger)
        {
            logger.LogInformation("Blob sample-container/sample-blob-1 has been updated with content: {content}", Encoding.UTF8.GetString(blobContent1));
            blobContent2 = blobContent1;
            logger.LogInformation("Blob sample-container/sample-blob-1 has been copied to sample-container/sample-blob-2");
        }
    }
    #endregion

    #region Snippet:BlobFunction_ReadStream
    public static class BlobFunction_ReadStream
    {
        [FunctionName("BlobFunction")]
        public static void Run(
            [BlobTrigger("sample-container/sample-blob-1")] Stream blobStream1,
            [Blob("sample-container/sample-blob-2", FileAccess.Read)] Stream blobStream2,
            ILogger logger)
        {
            using var blobStreamReader1 = new StreamReader(blobStream1);
            logger.LogInformation("Blob sample-container/sample-blob-1 has been updated with content: {content}", blobStreamReader1.ReadToEnd());
            using var blobStreamReader2 = new StreamReader(blobStream2);
            logger.LogInformation("Blob sample-container/sample-blob-2 has content: {content}", blobStreamReader2.ReadToEnd());
        }
    }
    #endregion

    #region Snippet:BlobFunction_WriteStream
    public static class BlobFunction_WriteStream
    {
        [FunctionName("BlobFunction")]
        public static async Task Run(
            [BlobTrigger("sample-container/sample-blob-1")] Stream blobStream1,
            [Blob("sample-container/sample-blob-2", FileAccess.Write)] Stream blobStream2,
            ILogger logger)
        {
            await blobStream1.CopyToAsync(blobStream2);
            logger.LogInformation("Blob sample-container/sample-blob-1 has been copied to sample-container/sample-blob-2");
        }
    }
    #endregion

    #region Snippet:BlobFunction_String_Write
    public static class BlobFunction_String_Write
    {
        [FunctionName("BlobFunction")]
        public static void Run(
            [BlobTrigger("sample-container/sample-blob-1")] string blobContent1,
            [Blob("sample-container/sample-blob-2")] out string blobContent2,
            ILogger logger)
        {
            logger.LogInformation("Blob sample-container/sample-blob-1 has been updated with content: {content}", blobContent1);
            blobContent2 = blobContent1;
            logger.LogInformation("Blob sample-container/sample-blob-1 has been copied to sample-container/sample-blob-2");
        }
    }
    #endregion

    #region Snippet:BlobFunction_TextReader_TextWriter
    public static class BlobFunction_TextReader_TextWriter
    {
        [FunctionName("BlobFunction")]
        public static async Task Run(
            [BlobTrigger("sample-container/sample-blob-1")] TextReader blobContentReader1,
            [Blob("sample-container/sample-blob-2")] TextWriter blobContentWriter2,
            ILogger logger)
        {
            while (blobContentReader1.Peek() >= 0)
            {
                await blobContentWriter2.WriteLineAsync(await blobContentReader1.ReadLineAsync());
            }
            logger.LogInformation("Blob sample-container/sample-blob-1 has been copied to sample-container/sample-blob-2");
        }
    }
    #endregion

    #region Snippet:BlobFunction_BlobClient
    public static class BlobFunction_BlobClient
    {
        [FunctionName("BlobFunction")]
        public static async Task Run(
            [BlobTrigger("sample-container/sample-blob-1")] BlobClient blobClient1,
            [Blob("sample-container/sample-blob-2")] BlobClient blobClient2,
            ILogger logger)
        {
            BlobProperties blobProperties1 = await blobClient1.GetPropertiesAsync();
            logger.LogInformation("Blob sample-container/sample-blob-1 has been updated on: {datetime}", blobProperties1.LastModified);
            BlobProperties blobProperties2 = await blobClient2.GetPropertiesAsync();
            logger.LogInformation("Blob sample-container/sample-blob-2 has been updated on: {datetime}", blobProperties2.LastModified);
        }
    }
    #endregion

    #region Snippet:BlobFunction_AccessContainer
    public static class BlobFunction_AccessContainer
    {
        [FunctionName("BlobFunction")]
        public static async Task Run(
            [BlobTrigger("sample-container/sample-blob")] Stream blobStream,
            [Blob("sample-container")] BlobContainerClient blobContainerClient,
            ILogger logger)
        {
            logger.LogInformation("Blobs within container:");
            await foreach (BlobItem blobItem in blobContainerClient.GetBlobsAsync())
            {
                logger.LogInformation(blobItem.Name);
            }
        }
    }
    #endregion

    #region Snippet:BlobFunction_EnumerateBlobs_Stream
    public static class BlobFunction_EnumerateBlobs_Stream
    {
        [FunctionName("BlobFunction")]
        public static async Task Run(
            [BlobTrigger("sample-container/sample-blob")] Stream blobStream,
            [Blob("sample-container")] IEnumerable<Stream> blobs,
            ILogger logger)
        {
            logger.LogInformation("Blobs contents within container:");
            foreach (Stream content in blobs)
            {
                using var blobStreamReader = new StreamReader(content);
                logger.LogInformation(await blobStreamReader.ReadToEndAsync());
            }
        }
    }
    #endregion

    #region Snippet:BlobFunction_EnumerateBlobs_BlobClient
    public static class BlobFunction_EnumerateBlobs_BlobClient
    {
        [FunctionName("BlobFunction")]
        public static void Run(
            [BlobTrigger("sample-container/sample-blob")] Stream blobStream,
            [Blob("sample-container")] IEnumerable<BlobClient> blobs,
            ILogger logger)
        {
            logger.LogInformation("Blobs within container:");
            foreach (BlobClient blob in blobs)
            {
                logger.LogInformation(blob.Name);
            }
        }
    }
    #endregion
}

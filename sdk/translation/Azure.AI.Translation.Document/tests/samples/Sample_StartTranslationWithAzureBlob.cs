﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.Translation.Document.Tests;
using Azure.Core.TestFramework;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using NUnit.Framework;

namespace Azure.AI.Translation.Document.Samples
{
    [LiveOnly]
    public partial class DocumentTranslationSamples : SamplesBase<DocumentTranslationTestEnvironment>
    {
        [Test]
        [Ignore("Samples not working yet")]
        public async Task StartTranslationWithAzureBlob()
        {
            /**
            FILE: SampleTranslationWithAzureBlob.cs
            DESCRIPTION:
                This sample demonstrates how to use Azure Blob Storage to set up the necessary resources to create a translation
                operation. Run the sample to create containers, upload documents, and generate SAS tokens for the source/target
                containers. Once the operation is completed, use the storage library to download your documents locally.

            PREREQUISITE:
                This sample requires you install Azure.Storage.Blobs nuget package:
                https://www.nuget.org/packages/Azure.Storage.Blobs

            USAGE:
                Set the environment variables with your own values before running the sample:
                1) AZURE_DOCUMENT_TRANSLATION_ENDPOINT - the endpoint to your Document Translation resource.
                2) AZURE_DOCUMENT_TRANSLATION_KEY - your Document Translation API key.
                3) AZURE_STORAGE_SOURCE_ENDPOINT - the endpoint to your Storage account
                4) AZURE_STORAGE_ACCOUNT_NAME - the name of your storage account
                5) AZURE_STORAGE_SOURCE_KEY - the shared access key to your storage account
                Optional environment variables - if not set, they will be created for you
                6) AZURE_STORAGE_SOURCE_CONTAINER_NAME - the name of your source container
                7) AZURE_STORAGE_TARGET_CONTAINER_NAME - the name of your target container
                8) AZURE_DOCUMENT_PATH - (optional) the path and file extension of your document in this directory
                    e.g. "path/mydocument.txt"
            **/
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:StartTranslationWithAzureBlobAsync
            Uri storageEndpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_STORAGE_SOURCE_ENDPOINT"));
            string storageAccountName = Environment.GetEnvironmentVariable("AZURE_STORAGE_ACCOUNT_NAME");
            string storageAccountKey = Environment.GetEnvironmentVariable("AZURE_STORAGE_SOURCE_KEY");
            string sourceContainerName = Environment.GetEnvironmentVariable("AZURE_STORAGE_SOURCE_CONTAINER_NAME");
            string targetContainerName = Environment.GetEnvironmentVariable("AZURE_STORAGE_TARGET_CONTAINER_NAME");
            string documentPath = Environment.GetEnvironmentVariable("AZURE_DOCUMENT_PATH");

            // Create source and target storage containers
            BlobServiceClient blobServiceClient = new BlobServiceClient(storageEndpoint, new StorageSharedKeyCredential(storageAccountName, storageAccountKey));
            BlobContainerClient sourceContainerClient = await blobServiceClient.CreateBlobContainerAsync(sourceContainerName ?? "translation-source-container").ConfigureAwait(false);
            BlobContainerClient targetContainerClient = await blobServiceClient.CreateBlobContainerAsync(targetContainerName ?? "translation-target-container").ConfigureAwait(false);

            // Upload blob (file) to the source container
            BlobClient srcBlobClient = sourceContainerClient.GetBlobClient(string.IsNullOrWhiteSpace(documentPath) ? Path.GetFileName(documentPath) : "example_source_document.txt");

            if (!string.IsNullOrWhiteSpace(documentPath))
            {
                using (FileStream uploadFileStream = File.OpenRead(documentPath))
                {
                    await srcBlobClient.UploadAsync(uploadFileStream, true).ConfigureAwait(false);
                }
            }
            else
            {
                await srcBlobClient.UploadAsync(new MemoryStream(Encoding.UTF8.GetBytes("Hello.\nThis is a testing text.")), true).ConfigureAwait(false);
            }

            Console.WriteLine($"Uploaded document {srcBlobClient.Uri} to source storage container");

            // Generate SAS tokens for source & target
            Uri srcSasUri = sourceContainerClient.GenerateSasUri(BlobContainerSasPermissions.List | BlobContainerSasPermissions.Read, DateTime.UtcNow.AddMinutes(30));
            Uri tgtSasUri = targetContainerClient.GenerateSasUri(BlobContainerSasPermissions.Read | BlobContainerSasPermissions.Write | BlobContainerSasPermissions.Delete, DateTime.UtcNow.AddMinutes(30));

            // Submit the translation operation and wait for it to finish
            var operationRequest = new DocumentTranslationInput(srcSasUri, tgtSasUri, "es");
            DocumentTranslationOperation operationResult = await client.StartTranslationAsync(operationRequest);
            await operationResult.WaitForCompletionAsync();

            Console.WriteLine($"Operation status: {operationResult.Status}");
            Console.WriteLine($"Operation created on: {operationResult.CreatedOn}");
            Console.WriteLine($"Operation last updated on: {operationResult.LastModified}");
            Console.WriteLine($"Total number of translations on documents: {operationResult.DocumentsTotal}");
            Console.WriteLine("\nOf total documents...");
            Console.WriteLine($"{operationResult.DocumentsFailed} failed");
            Console.WriteLine($"{operationResult.DocumentsSucceeded} succeeded");

            await foreach (DocumentStatusResult document in operationResult.GetAllDocumentStatusesAsync())
            {
                if (document.Status == TranslationStatus.Succeeded)
                {
                    Console.WriteLine($"Document at {document.SourceDocumentUri} was translated to {document.TranslatedTo} language.You can find translated document at {document.TranslatedDocumentUri}");
                }
                else
                {
                    Console.WriteLine($"Document ID: {document.DocumentId}, Error Code: {document.Error.ErrorCode}, Message: {document.Error.Message}");
                }
            }

            #endregion
        }
    }
}

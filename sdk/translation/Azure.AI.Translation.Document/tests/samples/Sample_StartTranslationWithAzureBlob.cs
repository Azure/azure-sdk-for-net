// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.Translation.Document.Tests;
using Azure.Core.TestFramework;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using NUnit.Framework;

namespace Azure.AI.Translation.Document.Samples
{
    public partial class DocumentTranslationSamples : DocumentTranslationLiveTestBase
    {
        [Test]
        [AsyncOnly]
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
                1) DOCUMENT_TRANSLATION_ENDPOINT - the endpoint to your Document Translation resource.
                2) DOCUMENT_TRANSLATION_API_KEY - your Document Translation API key.
                3) DOCUMENT_TRANSLATION_CONNECTION_STRING - the connection string to your Storage account
                4) AZURE_DOCUMENT_PATH - (optional) the path and file extension of your document in this directory
                    e.g. "path/mydocument.txt"
                Optionally, you can also set the following variables in code:
                5) sourceContainerName - the name of your source container
                6) targetContainerName - the name of your target container
            **/
#if SNIPPET
            string endpoint = "<Document Translator Resource Endpoint>";
            string apiKey = "<Document Translator Resource API Key>";
#else
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
#endif

            var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            var storageConnectionString = Environment.GetEnvironmentVariable("DOCUMENT_TRANSLATION_CONNECTION_STRING");
#if SNIPPET
            string sourceContainerName = "<Source Container Name>";
            string targetContainerName = "<Target Container Name>";
#else
            string sourceContainerName = GenerateRandomName("source");
            string targetContainerName = GenerateRandomName("target");
#endif
            string documentPath = Environment.GetEnvironmentVariable("AZURE_DOCUMENT_PATH");

            // Create source and target storage containers
            BlobServiceClient blobServiceClient = new BlobServiceClient(storageConnectionString);
            BlobContainerClient sourceContainerClient = await blobServiceClient.CreateBlobContainerAsync(sourceContainerName ?? "translation-source-container", PublicAccessType.BlobContainer).ConfigureAwait(false);
            BlobContainerClient targetContainerClient = await blobServiceClient.CreateBlobContainerAsync(targetContainerName ?? "translation-target-container", PublicAccessType.BlobContainer).ConfigureAwait(false);

            // Upload blob (file) to the source container
            BlobClient srcBlobClient = sourceContainerClient.GetBlobClient(!string.IsNullOrWhiteSpace(documentPath) ? Path.GetFileName(documentPath) : "example_source_document.txt");

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
            Uri tgtSasUri = targetContainerClient.GenerateSasUri(BlobContainerSasPermissions.List | BlobContainerSasPermissions.Write | BlobContainerSasPermissions.Delete, DateTime.UtcNow.AddMinutes(30));

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

            await foreach (DocumentStatusResult document in operationResult.GetDocumentStatusesAsync())
            {
                if (document.Status == DocumentTranslationStatus.Succeeded)
                {
                    Console.WriteLine($"Document at {document.SourceDocumentUri} was translated to {document.TranslatedToLanguageCode} language.You can find translated document at {document.TranslatedDocumentUri}");
                }
                else
                {
                    Console.WriteLine($"Document ID: {document.Id}, Error Code: {document.Error.Code}, Message: {document.Error.Message}");
                }
            }
        }
    }
}

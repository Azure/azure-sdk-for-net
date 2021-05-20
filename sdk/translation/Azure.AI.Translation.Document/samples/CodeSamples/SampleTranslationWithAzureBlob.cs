// <copyright file="SampleTranslationWithAzureBlob.cs" company="Microsoft Corporation">
// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// </copyright>

using Azure;
using Azure.AI.Translation.Document;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/**
FILE: SampleTranslationWithAzureBlob.cs
DESCRIPTION:
    This sample demonstrates how to use Azure Blob Storage to set up the necessary resources to create a translation
    job. Run the sample to create containers, upload documents, and generate SAS tokens for the source/target
    containers. Once the job is completed, use the storage library to download your documents locally.

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

namespace DocumentTranslatorSamples
{
    class SampleTranslationWithAzureBlob
    {
        public async static Task RunSampleAsync()
        {
            var endpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_DOCUMENT_TRANSLATION_ENDPOINT"));
            var key = Environment.GetEnvironmentVariable("AZURE_DOCUMENT_TRANSLATION_KEY");
            var storageEndpoint = new Uri(Environment.GetEnvironmentVariable("AZURE_STORAGE_SOURCE_ENDPOINT"));
            var storageAccountName = Environment.GetEnvironmentVariable("AZURE_STORAGE_ACCOUNT_NAME");
            var storageAccountKey = Environment.GetEnvironmentVariable("AZURE_STORAGE_SOURCE_KEY");
            var sourceContainerName = Environment.GetEnvironmentVariable("AZURE_STORAGE_SOURCE_CONTAINER_NAME");
            var targetContainerName = Environment.GetEnvironmentVariable("AZURE_STORAGE_TARGET_CONTAINER_NAME");
            var documentPath = Environment.GetEnvironmentVariable("AZURE_DOCUMENT_PATH");

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
            var srcSasUri = sourceContainerClient.GenerateSasUri(BlobContainerSasPermissions.List | BlobContainerSasPermissions.Read, DateTime.UtcNow.AddMinutes(30));
            var tgtSasUri = targetContainerClient.GenerateSasUri(BlobContainerSasPermissions.Read | BlobContainerSasPermissions.Write | BlobContainerSasPermissions.Delete, DateTime.UtcNow.AddMinutes(30));

            var documentTranslationClient = new DocumentTranslationClient(endpoint, new AzureKeyCredential(key));

            var jobRequest = new List<DocumentTranslationInput>()
            {
                new DocumentTranslationInput(
                    source: new TranslationSource(srcSasUri),
                    targets: new List<TranslationTarget>()
                        {
                            new TranslationTarget(targetUri: tgtSasUri, languageCode: "es")
                        }
                    )
            };

            // Submit the translation job and wait for it to finish
            var jobResult = await documentTranslationClient.StartTranslationAsync(jobRequest).ConfigureAwait(false);
            await jobResult.WaitForCompletionAsync().ConfigureAwait(false);

            Console.WriteLine($"Job status: {jobResult.Status}");
            Console.WriteLine($"Job created on: {jobResult.CreatedOn}");
            Console.WriteLine($"Job last updated on: {jobResult.LastModified}");
            Console.WriteLine($"Total number of translations on documents: {jobResult.DocumentsTotal}");
            Console.WriteLine("\nOf total documents...");
            Console.WriteLine($"{jobResult.DocumentsFailed} failed");
            Console.WriteLine($"{jobResult.DocumentsSucceeded} succeeded");

            await foreach (var document in jobResult.GetAllDocumentStatusesAsync())
            {
                if (document.Status == TranslationStatus.Succeeded)
                {
                    Console.WriteLine($"Document at {document.SourceDocumentUri} was translated to {document.TranslateTo} language.You can find translated document at {document.TranslatedDocumentUri}");
                }
                else
                {
                    Console.WriteLine($"Document ID: {document.DocumentId}, Error Code: {document.Error.ErrorCode}, Message: {document.Error.Message}");
                }
            }
        }
    }
}

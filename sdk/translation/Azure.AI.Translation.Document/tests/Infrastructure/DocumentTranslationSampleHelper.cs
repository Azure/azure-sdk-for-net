// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core.Tests.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;

namespace Azure.AI.Translation.Document.Tests
{
    internal static class DocumentTranslationSampleHelper
    {
        public static DocumentTranslationTestEnvironment TestEnvironment;
        public static readonly List<TestDocument> oneTestDocuments = new()
        {
            new TestDocument("Document1.txt", "First english test document"),
        };

        private static TestRandom random
        {
            get
            {
                var csp = new RNGCryptoServiceProvider();
                var bytes = new byte[4];
                csp.GetBytes(bytes);
                return new TestRandom(RecordedTestMode.Live, BitConverter.ToInt32(bytes, 0));
            }
        }

        private static BlobContainerClient GetBlobContainerClient(string containerName)
        {
            return new BlobContainerClient(TestEnvironment.StorageConnectionString, containerName, new BlobClientOptions());
        }
        public static DocumentTranslationClient GetClient(
            AzureKeyCredential credential = default,
            DocumentTranslationClientOptions options = default,
            bool useTokenCredential = default)
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            options ??= new DocumentTranslationClientOptions()
            {
                Diagnostics =
                {
                    LoggedHeaderNames = { "x-ms-request-id", "X-RequestId" },
                    IsLoggingContentEnabled = true
                }
            };

            if (useTokenCredential)
            {
                return new DocumentTranslationClient(endpoint, TestEnvironment.Credential, options);
            }
            else
            {
                credential ??= new AzureKeyCredential(TestEnvironment.ApiKey);
                return new DocumentTranslationClient(endpoint, credential, options);
            }
        }
        public static Uri CreateSourceContainer(List<TestDocument> documents)
        {
            string containerName = "source" + random.Next().ToString();
            var containerClient = GetBlobContainerClient(containerName);
            containerClient.Create(PublicAccessType.BlobContainer);

            UploadDocuments(containerClient, documents);

            var expiresOn = DateTimeOffset.UtcNow.AddHours(1);
            return containerClient.GenerateSasUri(BlobContainerSasPermissions.List | BlobContainerSasPermissions.Read, expiresOn);
        }

        public static async Task<Uri> CreateSourceContainerAsync(List<TestDocument> documents)
        {
            string containerName = "source" + random.Next().ToString();
            var containerClient = GetBlobContainerClient(containerName);
            await containerClient.CreateAsync(PublicAccessType.BlobContainer).ConfigureAwait(false);

            await UploadDocumentsAsync(containerClient, documents);

            var expiresOn = DateTimeOffset.UtcNow.AddHours(1);
            return containerClient.GenerateSasUri(BlobContainerSasPermissions.List | BlobContainerSasPermissions.Read, expiresOn);
        }

        public static async Task<Uri> CreateTargetContainerAsync(List<TestDocument> documents = default)
        {
            string containerName = "target" + random.Next().ToString();
            var containerClient = GetBlobContainerClient(containerName);
            await containerClient.CreateAsync(PublicAccessType.BlobContainer).ConfigureAwait(false);

            if (documents != default)
            {
                await UploadDocumentsAsync(containerClient, documents);
            }

            var expiresOn = DateTimeOffset.UtcNow.AddHours(1);
            return containerClient.GenerateSasUri(BlobContainerSasPermissions.List | BlobContainerSasPermissions.Write, expiresOn);
        }
        public static Uri CreateTargetContainer(List<TestDocument> documents = default)
        {
            string containerName = "target" + random.Next().ToString();
            var containerClient = GetBlobContainerClient(containerName);
            containerClient.Create(PublicAccessType.BlobContainer);

            if (documents != default)
            {
                UploadDocuments(containerClient, documents);
            }

            var expiresOn = DateTimeOffset.UtcNow.AddHours(1);
            return containerClient.GenerateSasUri(BlobContainerSasPermissions.List | BlobContainerSasPermissions.Write, expiresOn);
        }

        public static async Task<Uri> CreateGlossaryContainerAsync(List<TestDocument> documents = default)
        {
            var glossaryContainerName = "glossary" + random.Next().ToString();
            var containerClient = GetBlobContainerClient(glossaryContainerName);
            await containerClient.CreateAsync(PublicAccessType.BlobContainer).ConfigureAwait(false);

            if (documents != default)
            {
                await UploadDocumentsAsync(containerClient, documents);
            }

            var expiresOn = DateTimeOffset.UtcNow.AddHours(1);
            return containerClient.GenerateSasUri(BlobContainerSasPermissions.Read | BlobContainerSasPermissions.Write, expiresOn);
        }

        public static Uri CreateGlossaryContainer(List<TestDocument> documents = default)
        {
            var glossaryContainerName = "glossary" + random.Next().ToString();
            var containerClient = GetBlobContainerClient(glossaryContainerName);
            containerClient.Create(PublicAccessType.BlobContainer);

            if (documents != default)
            {
                UploadDocuments(containerClient, documents);
            }

            var expiresOn = DateTimeOffset.UtcNow.AddHours(1);
            return containerClient.GenerateSasUri(BlobContainerSasPermissions.Read | BlobContainerSasPermissions.List| BlobContainerSasPermissions.Write, expiresOn);
        }

        private static async Task UploadDocumentsAsync(BlobContainerClient containerClient, List<TestDocument> documents)
        {
            for (int i = 0; i < documents.Count; i++)
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(documents[i].Content);
                MemoryStream stream = new MemoryStream(byteArray);
                await containerClient.UploadBlobAsync(documents[i].Name, stream);
            }
        }

        private static void UploadDocuments(BlobContainerClient containerClient, List<TestDocument> documents)
        {
            for (int i = 0; i < documents.Count; i++)
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(documents[i].Content);
                MemoryStream stream = new MemoryStream(byteArray);
                containerClient.UploadBlob(documents[i].Name, stream);
            }
        }
    }
}

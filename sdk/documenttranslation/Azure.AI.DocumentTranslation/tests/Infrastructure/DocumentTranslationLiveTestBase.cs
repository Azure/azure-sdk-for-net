// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;

namespace Azure.AI.Translator.DocumentTranslation.Tests
{
    public class DocumentTranslationLiveTestBase : RecordedTestBase<DocumentTranslationTestEnvironment>
    {
        protected TimeSpan PollingInterval => TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0 : 30);

        public DocumentTranslationLiveTestBase(bool isAsync, RecordedTestMode? mode = null)
            : base(isAsync, mode ?? RecordedTestUtilities.GetModeFromEnvironment())
        {
            Sanitizer = new DocumentTranslationRecordedTestSanitizer();
        }

        protected static readonly List<TestDocument> oneTestDocuments = new()
        {
            new TestDocument("Document1.txt", "First english test document"),
        };

        protected static readonly List<TestDocument> twoTestDocuments = new()
        {
            new TestDocument("Document1.txt", "First english test document"),
            new TestDocument("File2.txt", "Second english test file"),
        };

        public DocumentTranslationClient GetClient(
            AzureKeyCredential credential = default,
            DocumentTranslationClientOptions options = default)
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            options ??= new DocumentTranslationClientOptions();

            credential ??= new AzureKeyCredential(TestEnvironment.ApiKey);
            return InstrumentClient(new DocumentTranslationClient(endpoint, credential, InstrumentClientOptions(options)));
        }

        public BlobContainerClient GetBlobContainerClient(string containerName)
        {
            return InstrumentClient(new BlobContainerClient(TestEnvironment.StorageConnectionString, containerName, InstrumentClientOptions(new BlobClientOptions())));
        }

        public async Task<Uri> CreateSourceContainerAsync(List<TestDocument> documents)
        {
            Recording.DisableIdReuse();
            string containerName = "source" + Recording.GenerateId();
            var containerClient = GetBlobContainerClient(containerName);
            await containerClient.CreateAsync(PublicAccessType.BlobContainer).ConfigureAwait(false);

            await UploadDocumentsAsync(containerClient, documents);

            var expiresOn = DateTimeOffset.UtcNow.AddHours(1);
            return containerClient.GenerateSasUri(BlobContainerSasPermissions.List | BlobContainerSasPermissions.Read, expiresOn);
        }

        public async Task<Uri> CreateTargetContainerAsync(List<TestDocument> documents = default)
        {
            Recording.DisableIdReuse();
            string containerName = "target" + Recording.GenerateId();
            var containerClient = GetBlobContainerClient(containerName);
            await containerClient.CreateAsync(PublicAccessType.BlobContainer).ConfigureAwait(false);

            if (documents != default)
            {
                await UploadDocumentsAsync(containerClient, documents);
            }

            var expiresOn = DateTimeOffset.UtcNow.AddHours(1);
            return containerClient.GenerateSasUri(BlobContainerSasPermissions.Read | BlobContainerSasPermissions.Write, expiresOn);
        }

        private async Task UploadDocumentsAsync(BlobContainerClient containerClient, List<TestDocument> documents)
        {
            for (int i = 0; i < documents.Count; i++)
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(documents[i].Content);
                MemoryStream stream = new MemoryStream(byteArray);
                await containerClient.UploadBlobAsync(documents[i].Name, stream);
            }
        }
    }
}

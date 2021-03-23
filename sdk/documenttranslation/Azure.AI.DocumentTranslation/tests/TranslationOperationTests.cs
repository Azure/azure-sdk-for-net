// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using NUnit.Framework;

namespace Azure.AI.DocumentTranslation.Tests
{
    public class TranslationOperationTests : DocumentTranslationLiveTestBase
    {
        public TranslationOperationTests(bool isAsync) : base(isAsync) { }

        private string StorageConnectionString = Environment.GetEnvironmentVariable("STORAGE_ACCOUNT_CONNECTION_STRING");

        private List<string> Documents = new List<string>
        {
            "This is the first english test document",
            "This is the second english test document"
        };

        private string GetSourceContainerName() => (TestContext.CurrentContext.Test.Name + IsAsync + "source").ToLower();
        private string GetTargetContainerName() => (TestContext.CurrentContext.Test.Name + IsAsync + "target").ToLower();

        private async Task CreateSourceContainerAsync()
        {
            string containerName = GetSourceContainerName();
            var containerClient = new BlobContainerClient(StorageConnectionString, containerName.ToLower());
            await containerClient.CreateIfNotExistsAsync(PublicAccessType.BlobContainer).ConfigureAwait(false);

            for (int i = 0; i < Documents.Count; i++)
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(Documents[i]);
                MemoryStream stream = new MemoryStream(byteArray);
                await containerClient.UploadBlobAsync($"document{i}.txt", stream);
            }
        }

        private async Task CreateTargetContainerAsync()
        {
            string containerName = GetTargetContainerName();
            var containerClient = new BlobContainerClient(StorageConnectionString, containerName.ToLower());
            await containerClient.CreateIfNotExistsAsync(PublicAccessType.BlobContainer).ConfigureAwait(false);
        }

        private async Task DeleteContainerAsync(string containerName)
        {
            var containerClient = new BlobContainerClient(StorageConnectionString, containerName.ToLower());
            await containerClient.DeleteIfExistsAsync().ConfigureAwait(false);
        }

        [TearDown]
        public async Task CleanTest()
        {
            await DeleteContainerAsync(GetSourceContainerName());
            await DeleteContainerAsync(GetTargetContainerName());
        }

        [SetUp]
        public async Task SetupTest()
        {
            await CreateSourceContainerAsync();
            await CreateTargetContainerAsync();
        }

        private Uri GetSasUrl(string containerName)
        {
            var containerClient = new BlobContainerClient(StorageConnectionString, containerName);
            var expiresOn = DateTimeOffset.Now.AddHours(1);
            return containerClient.GenerateSasUri(BlobContainerSasPermissions.Write | BlobContainerSasPermissions.List | BlobContainerSasPermissions.Read, expiresOn);
        }

        [Test]
        public async Task TranslationOperationTest()
        {
            Uri source = GetSasUrl(GetSourceContainerName());
            Uri target = GetSasUrl(GetTargetContainerName());
            Uri endpoint = new Uri(TestEnvironment.Endpoint);
            AzureKeyCredential credential = new AzureKeyCredential(TestEnvironment.ApiKey);

            var client = new DocumentTranslationClient(endpoint, credential);

            var input = new TranslationConfiguration(source, target, "fr");
            var operation = await client.StartTranslationAsync(input);

            await operation.WaitForCompletionAsync();

            Assert.AreEqual(2, operation.DocumentsTotal);
            Assert.AreEqual(2, operation.DocumentsSucceeded);
            Assert.AreEqual(0, operation.DocumentsFailed);
        }
    }
}

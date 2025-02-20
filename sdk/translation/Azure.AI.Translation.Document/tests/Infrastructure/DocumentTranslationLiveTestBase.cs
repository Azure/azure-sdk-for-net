// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;

namespace Azure.AI.Translation.Document.Tests
{
    public abstract class DocumentTranslationLiveTestBase : RecordedTestBase<DocumentTranslationTestEnvironment>
    {
        protected TimeSpan PollingInterval => TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0 : 30);

        public DocumentTranslationLiveTestBase(bool isAsync, RecordedTestMode? mode = null)
            : base(isAsync)
            //: base(isAsync, RecordedTestMode.Record)
        {
            JsonPathSanitizers.Add("$..sourceUrl");
            JsonPathSanitizers.Add("$..targetUrl");
            JsonPathSanitizers.Add("$..glossaryUrl");
            SanitizedHeaders.Add(Constants.AuthorizationHeader);
            IgnoredHeaders.Add("x-ms-blob-public-access");
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

        public List<TestDocument> CreateDummyTestDocuments(int count)
        {
            var result = new List<TestDocument>();
            for (int i = 0; i < count; i++)
            {
                var fileName = $"File_{i}.txt";
                var text = "some random text";
                result.Add( new TestDocument(fileName, text) );
            }
            return result;
        }

        public DocumentTranslationClient GetClient(
            AzureKeyCredential credential = default,
            DocumentTranslationClientOptions options = default,
            bool useTokenCredential = default)
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            options ??= new DocumentTranslationClientOptions()
            {
                Diagnostics =
                {
                    LoggedHeaderNames = { "x-ms-request-id", "X-RequestId", "apim-request-id" },
                    IsLoggingContentEnabled = true
                }
            };

            if (useTokenCredential)
            {
                return InstrumentClient(new DocumentTranslationClient(endpoint, TestEnvironment.Credential, InstrumentClientOptions(options)));
            }
            else
            {
                credential ??= new AzureKeyCredential(TestEnvironment.ApiKey);
                return InstrumentClient(new DocumentTranslationClient(endpoint, credential, InstrumentClientOptions(options)));
            }
        }

        public BlobContainerClient GetBlobContainerClient(string containerName)
        {
            string accountUrl = String.Format("https://{0}.blob.core.windows.net/", TestEnvironment.StorageAccountName);
            BlobServiceClient blobServiceClient = new BlobServiceClient(
                new Uri(accountUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new BlobClientOptions(BlobClientOptions.ServiceVersion.V2020_04_08)));
            BlobContainerClient blobContainerClient = blobServiceClient.CreateBlobContainer(containerName, PublicAccessType.None);
            return InstrumentClient(blobContainerClient);
        }

        public Uri CreateSourceContainer(List<TestDocument> documents)
        {
            var containerClient = CreateContainer("source", documents);
            return containerClient.Uri;
        }

        public async Task<Uri> CreateSourceContainerAsync(List<TestDocument> documents)
        {
            var containerClient = await CreateContainerAsync("source", documents);
            return containerClient.Uri;
        }

        public Uri CreateTargetContainer(List<TestDocument> documents = default)
        {
            var containerClient = CreateContainer("target", documents);
            return containerClient.Uri;
        }

        public async Task<Uri> CreateTargetContainerAsync(List<TestDocument> documents = default)
        {
            var containerClient = await CreateContainerAsync("target", documents);
            return containerClient.Uri;
        }
        public async Task<Uri> CreateGlossaryAsync(TestDocument document = default)
        {
            var containerClient = await CreateContainerAsync("glossary", new List<TestDocument> { document });
            var containerUri = containerClient.Uri;
            return new Uri(String.Format("{0}/{1}", containerUri, document.Name));
        }

        public Uri CreateGlossary(TestDocument document = default)
        {
            var containerClient = CreateContainer("glossary", new List<TestDocument> { document });
            var containerUri = containerClient.Uri;
            return new Uri(String.Format("{0}/{1}", containerUri, document.Name));
        }

        public async Task<Tuple<Uri, BlobContainerClient>> CreateTargetContainerWithClientAsync(List<TestDocument> documents = default)
        {
            var containerClient = await CreateContainerAsync("target", documents);
            return Tuple.Create(containerClient.Uri, containerClient);
        }

        private BlobContainerClient CreateContainer(string name, List<TestDocument> documents)
        {
            var containerName = name + Recording.GenerateId();
            BlobContainerClient containerClient = GetBlobContainerClient(containerName);

            if (documents != default)
            {
                UploadDocuments(containerClient, documents);
            }

            return containerClient;
        }

        private async Task<BlobContainerClient> CreateContainerAsync(string name, List<TestDocument> documents)
        {
            string containerName = name + Recording.GenerateId();
            BlobContainerClient containerClient = GetBlobContainerClient(containerName);

            if (documents != default)
            {
                await UploadDocumentsAsync(containerClient, documents);
            }

            return containerClient;
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
        private void UploadDocuments(BlobContainerClient containerClient, List<TestDocument> documents)
        {
            for (int i = 0; i < documents.Count; i++)
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(documents[i].Content);
                MemoryStream stream = new MemoryStream(byteArray);
                containerClient.UploadBlob(documents[i].Name, stream);
            }
        }
        public string GenerateRandomName(string baseName)
        {
            return baseName + Recording.GenerateId();
        }
    }
}

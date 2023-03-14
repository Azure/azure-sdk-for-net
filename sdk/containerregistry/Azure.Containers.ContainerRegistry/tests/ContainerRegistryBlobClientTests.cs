// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Containers.ContainerRegistry.Specialized;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class ContainerRegistryBlobClientTests : ClientTestBase
    {
        public ContainerRegistryBlobClientTests(bool isAsync) : base(isAsync)
        {
        }

        private ContainerRegistryBlobClient client { get; set; }
        private readonly Uri _url = new Uri("https://example.azurecr.io");

        private TokenCredential GetCredential()
        {
            return new EnvironmentCredential();
        }

        [SetUp]
        public void TestSetup()
        {
            client = InstrumentClient(new ContainerRegistryBlobClient(_url, "<repository>", GetCredential(), new ContainerRegistryClientOptions()
            {
                Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
            }));
        }

        /// <summary>
        /// Validates client constructor argument null checks.
        /// </summary>
        [Test]
        public void ConstructorValidatesArguments()
        {
            Assert.That(() => new ContainerRegistryBlobClient(null, "<repo>", GetCredential() ), Throws.InstanceOf<ArgumentNullException>(), "The constructor should validate the url.");

            Assert.That(() => new ContainerRegistryBlobClient(_url, "<repo>", credential: null), Throws.InstanceOf<ArgumentNullException>(), "The constructor should not accept a null credential.");

            Assert.That(() => new ContainerRegistryBlobClient(_url, null, GetCredential()), Throws.InstanceOf<ArgumentNullException>(), "The constructor should not accept null repository.");
        }

        /// <summary>
        /// Validates service method argument null checks.
        /// </summary>
        [Test]
        public void ServiceMethodsValidateArguments()
        {
            Assert.That(async () => await client.DeleteBlobAsync(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `digest` is not null.");
            Assert.That(async () => await client.DeleteManifestAsync(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `digest` is not null.");
            Assert.That(async () => await client.DownloadBlobContentAsync(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `digest` is not null.");
            Assert.That(async () => await client.DownloadManifestAsync(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `digest` is not null.");
            Assert.That(async () => await client.UploadManifestAsync(manifest: null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `manifest` is not null.");
            Assert.That(async () => await client.UploadManifestAsync(content: null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `content` is not null.");
            Assert.That(async () => await client.UploadManifestAsync(stream: null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `stream` is not null.");
            Assert.That(async () => await client.UploadBlobAsync(content: null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `content` is not null.");
            Assert.That(async () => await client.UploadBlobAsync(stream: null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `stream` is not null.");
        }

        /// <summary>
        /// Validates digest checks for DownloadManifest.
        /// </summary>
        [Test]
        public async Task DownloadManifestValidatesDigest()
        {
            // Arrange
            Uri endpoint = new("https://example.acr.io");
            string repository = "TestRepository";
            string tagName = "v1";
            BinaryData manifest = BinaryData.FromObjectAsJson(ContainerRegistryTestDataHelpers.CreateManifest());
            string manifestContent = manifest.ToString();
            string digest = BlobHelper.ComputeDigest(manifest.ToStream());

            ContainerRegistryClientOptions options = new()
            {
                Transport = new MockTransport(
                    new MockResponse(200).SetContent(manifestContent).AddHeader("Docker-Content-Digest", digest),
                    new MockResponse(200).SetContent(manifestContent).AddHeader("Docker-Content-Digest", digest),
                    new MockResponse(200).SetContent(manifestContent).AddHeader("Docker-Content-Digest", digest),
                    new MockResponse(200).SetContent(manifestContent).AddHeader("Docker-Content-Digest", "Invalid server digest")),
                Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
            };

            ContainerRegistryBlobClient client = new(endpoint, repository, new MockCredential(), options);

            // Act

            // Request with digest
            DownloadManifestResult result = await client.DownloadManifestAsync(digest);
            Assert.AreEqual(manifestContent, result.Content.ToString());

            // Request with tag
            result = await client.DownloadManifestAsync(tagName);
            Assert.AreEqual(manifestContent, result.Content.ToString());

            // Request with digest that doesn't match the content
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await client.DownloadManifestAsync(digest.Replace('0', '1'));
            });

            // Request with tag, getting a response with invalid digest header.
            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await client.DownloadManifestAsync(tagName);
            });
        }
    }
}

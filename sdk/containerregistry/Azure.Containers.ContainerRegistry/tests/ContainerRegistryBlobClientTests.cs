// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            Assert.That(async () => await client.DownloadBlobAsync(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `digest` is not null.");
            Assert.That(async () => await client.DownloadManifestAsync(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `digest` is not null.");
            Assert.That(async () => await client.UploadManifestAsync(manifest: null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `manifest` is not null.");
            Assert.That(async () => await client.UploadManifestAsync(manifestStream: null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `manifest stream` is not null.");
            Assert.That(async () => await client.UploadBlobAsync(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `stream` is not null.");
        }
    }
}

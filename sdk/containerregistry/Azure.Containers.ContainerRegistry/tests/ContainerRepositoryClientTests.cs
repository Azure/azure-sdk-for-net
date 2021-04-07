// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class ContainerRepositoryClientTests : ClientTestBase
    {
        public ContainerRepositoryClientTests(bool isAsync) : base(isAsync)
        {
        }

        private ContainerRepositoryClient client { get; set; }
        private readonly Uri _url = new Uri("https://example.azurecr.io");
        private readonly string _repository = "hello-world";

        private TokenCredential GetCredential()
        {
            return new EnvironmentCredential();
        }

        [SetUp]
        public void TestSetup()
        {
            client = InstrumentClient(new ContainerRepositoryClient(_url, _repository, GetCredential(), new ContainerRegistryClientOptions()));
        }

        /// <summary>
        /// Validates client constructor argument null checks.
        /// </summary>
        [Test]
        public void ConstructorValidatesArguments()
        {
            Assert.That(() => new ContainerRepositoryClient(null, _repository, GetCredential()), Throws.InstanceOf<ArgumentNullException>(), "The constructor should validate the url.");

            Assert.That(() => new ContainerRepositoryClient(_url, null, GetCredential()), Throws.InstanceOf<ArgumentNullException>(), "The constructor should not accept a null repository.");

            Assert.That(() => new ContainerRepositoryClient(_url, _repository, null), Throws.InstanceOf<ArgumentNullException>(), "The constructor should not accept a null credential.");

            Assert.That(() => new ContainerRepositoryClient(_url, _repository, GetCredential(), null), Throws.InstanceOf<ArgumentNullException>(), "The constructor not accept null options.");
        }

        /// <summary>
        /// Validates service method argument null checks.
        /// </summary>
        [Test]
        public void ServiceMethodsValidateArguments()
        {
            Assert.That(async () => await client.SetPropertiesAsync(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `value` is not null.");

            Assert.That(async () => await client.GetRegistryArtifactPropertiesAsync(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `tagOrDigest` is not null.");

            Assert.That(async () => await client.SetManifestPropertiesAsync(null, new ContentProperties()), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `digest` is not null.");
            Assert.That(async () => await client.SetManifestPropertiesAsync("digest", null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `value` is not null.");

            Assert.That(async () => await client.DeleteRegistryArtifactAsync(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `digest` is not null.");

            Assert.That(async () => await client.GetTagPropertiesAsync(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `tag` is not null.");

            Assert.That(async () => await client.SetTagPropertiesAsync(null, new ContentProperties()), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `tag` is not null.");
            Assert.That(async () => await client.SetTagPropertiesAsync("tag", null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `value` is not null.");

            Assert.That(async () => await client.DeleteTagAsync(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `tag` is not null.");
        }
    }
}

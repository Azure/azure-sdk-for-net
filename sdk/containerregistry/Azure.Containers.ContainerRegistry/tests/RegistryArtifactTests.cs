// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class RegistryArtifactTests : ClientTestBase
    {
        public RegistryArtifactTests(bool isAsync) : base(isAsync)
        {
        }

        private ContainerRegistryClient client { get; set; }
        private RegistryArtifact artifact { get; set; }
        private readonly Uri _url = new Uri("https://example.azurecr.io");
        private readonly string _repositoryName = "hello-world";
        private readonly string _artifactTag = "latest";

        private TokenCredential GetCredential()
        {
            return new EnvironmentCredential();
        }

        [SetUp]
        public void TestSetup()
        {
            client = InstrumentClient(new ContainerRegistryClient(_url, GetCredential(), new ContainerRegistryClientOptions()
            {
                Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
            }));
            artifact = client.GetArtifact(_repositoryName, _artifactTag);
        }

        /// <summary>
        /// Validates helper getter method argument null checks.
        /// </summary>
        [Test]
        public void GetterMethodValidatesArguments()
        {
            Assert.That(() => client.GetArtifact(null, _artifactTag), Throws.InstanceOf<ArgumentNullException>(), "The getter should validate the repository name.");
            Assert.That(() => client.GetArtifact(_repositoryName, null), Throws.InstanceOf<ArgumentNullException>(), "The getter should validate the tag name.");
        }

        /// <summary>
        /// Validates service method argument null checks.
        /// </summary>
        [Test]
        public void ServiceMethodsValidateArguments()
        {
            Assert.That(async () => await artifact.UpdateManifestPropertiesAsync(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `value` is not null.");

            Assert.That(async () => await artifact.GetTagPropertiesAsync(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `tag` is not null.");

            Assert.That(async () => await artifact.UpdateTagPropertiesAsync(null, new ArtifactTagProperties()), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `tag` is not null.");
            Assert.That(async () => await artifact.UpdateTagPropertiesAsync("tag", null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `value` is not null.");

            Assert.That(async () => await artifact.DeleteTagAsync(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `tag` is not null.");
        }
    }
}

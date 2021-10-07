// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class ContainerRepositoryTests : ClientTestBase
    {
        public ContainerRepositoryTests(bool isAsync) : base(isAsync)
        {
        }

        private ContainerRegistryClient client { get; set; }
        private ContainerRepository repository { get; set; }
        private readonly Uri _url = new Uri("https://example.azurecr.io");
        private readonly string _repositoryName = "hello-world";

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
            repository = client.GetRepository(_repositoryName);
        }

        /// <summary>
        /// Validates helper getter method argument null checks.
        /// </summary>
        [Test]
        public void GetterMethodValidatesArguments()
        {
            Assert.That(() => client.GetRepository(null), Throws.InstanceOf<ArgumentNullException>(), "The constructor should validate the repository name.");
        }

        /// <summary>
        /// Validates service method argument null checks.
        /// </summary>
        [Test]
        public void ServiceMethodsValidateArguments()
        {
            Assert.That(async () => await repository.UpdatePropertiesAsync(null), Throws.InstanceOf<ArgumentNullException>(), "The method should validate that `value` is not null.");
        }
    }
}

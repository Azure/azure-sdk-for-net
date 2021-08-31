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
            client = InstrumentClient(new ContainerRegistryBlobClient(_url, GetCredential(), "<repository>", new ContainerRegistryClientOptions()
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
            // TODO: Complete these

            Assert.That(() => new ContainerRegistryClient(null, GetCredential()), Throws.InstanceOf<ArgumentNullException>(), "The constructor should validate the url.");

            Assert.That(() => new ContainerRegistryClient(_url, credential: null), Throws.InstanceOf<ArgumentNullException>(), "The constructor should not accept a null credential.");

            Assert.That(() => new ContainerRegistryClient(_url, GetCredential(), null), Throws.InstanceOf<ArgumentNullException>(), "The constructor should not accept null options.");

            Assert.That(() => new ContainerRegistryClient(_url, GetCredential()), Throws.InstanceOf<InvalidOperationException>(), "The constructor should not accept default ClientOptions");
        }

        /// <summary>
        /// Validates service method argument null checks.
        /// </summary>
        [Test]
        public void ServiceMethodsValidateArguments()
        {
            // TODO: Anything to address here?
        }
    }
}

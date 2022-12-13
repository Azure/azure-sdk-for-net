// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Containers.ContainerRegistry.Specialized;
using System;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.Containers.ContainerRegistry.Tests.Samples
{
    public class ContainerRegistrySamplesBase : SamplesBase<ContainerRegistryTestEnvironment>
    {
        [SetUp]
        public void ContainerRegistryTestSetup()
        {
            string endpoint = TestEnvironment.Endpoint;
            if (ContainerRegistryRecordedTestBase.GetAuthorityHost(endpoint) != AzureAuthorityHosts.AzurePublicCloud)
            {
                Assert.Ignore("Sample tests are not enabled in national clouds.");
            }
        }

        public async Task CreateImageAsync(Uri endpoint, string repository, string tag)
        {
            var client = GetUploadClient(endpoint, repository);
            await client.UploadTestImageAsync(tag);
        }

        public async Task AddTagAsync(Uri endpoint, string repository, string reference, string tag)
        {
            var client = GetUploadClient(endpoint, repository);
            await client.AddTagAsync(reference, tag);
        }

        private ContainerRegistryBlobClient GetUploadClient(Uri endpoint, string repository)
        {
            // We won't record the set-up calls, so don't instrument this client.
            return new ContainerRegistryBlobClient(endpoint,
                TestEnvironment.Credential,
                repository,
                new ContainerRegistryClientOptions()
                {
                    Audience = ContainerRegistryAudience.AzureResourceManagerPublicCloud
                });
        }
    }
}

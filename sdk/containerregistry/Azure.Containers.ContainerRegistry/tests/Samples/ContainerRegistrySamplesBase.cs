// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

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
    }
}

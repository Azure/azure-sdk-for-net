// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageDiscovery.Tests
{
    public class StorageDiscoveryWorkspaceTests : StorageDiscoveryManagementTestBase
    {
        public StorageDiscoveryWorkspaceTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        [RecordedTest]
        public async Task ListBySubscriptionGetsResponse()
        {
            await foreach (Page<StorageDiscoveryWorkspaceResource> page in DefaultSubscription.GetStorageDiscoveryWorkspacesAsync().AsPages())
            {
                Assert.That(page.GetRawResponse().Status, Is.InRange(200, 299));
                return;
            }

            Assert.Fail("Expected the service to return at least one page.");
        }

        [Test]
        [RecordedTest]
        public async Task ListByResourceGroupGetsResponse()
        {
            var resourceGroup = await CreateResourceGroup(DefaultSubscription, "sdtest-rg-", AzureLocation.WestUS2).ConfigureAwait(false);

            try
            {
                StorageDiscoveryWorkspaceCollection collection = resourceGroup.GetStorageDiscoveryWorkspaces();

                await foreach (Page<StorageDiscoveryWorkspaceResource> page in collection.GetAllAsync().AsPages())
                {
                    Assert.That(page.GetRawResponse().Status, Is.InRange(200, 299));
                    return;
                }

                Assert.Fail("Expected the service to return at least one page.");
            }
            finally
            {
                await resourceGroup.DeleteAsync(WaitUntil.Completed).ConfigureAwait(false);
            }
        }
    }
}

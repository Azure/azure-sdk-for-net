// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Search.Tests
{
    using Microsoft.Azure.Management.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Xunit;

    public sealed class SharedPrivateLinkResourceTests : SearchTestBase<SharedPrivateLinkResourceFixture>
    {
        [Fact]
        public void CanPerformSharedPrivateLinkManagement()
        {
            Run(() =>
            {
                SearchManagementClient searchMgmt = GetSearchManagementClient();

                SharedPrivateLinkResource resource = searchMgmt.SharedPrivateLinkResources.CreateOrUpdate(
                    Data.ResourceGroupName,
                    Data.ServiceName,
                    Data.SharedPrivateLinkResourceName,
                    new SharedPrivateLinkResource(
                        name: Data.SharedPrivateLinkResourceName,
                        properties: new SharedPrivateLinkResourceProperties(
                            privateLinkResourceId: Data.StorageAccountId,
                            groupId: Data.SharedPrivateLinkResourceGroupId,
                            requestMessage: Data.SharedPrivateLinkResourceRequestMessage)));

                Assert.NotNull(resource);

                resource = searchMgmt.SharedPrivateLinkResources.Get(
                    Data.ResourceGroupName,
                    Data.ServiceName,
                    Data.SharedPrivateLinkResourceName);

                Assert.EndsWith($"/sharedPrivateLinkResources/{Data.SharedPrivateLinkResourceName}", resource.Id);
                Assert.Equal("Microsoft.Search/searchServices/sharedPrivateLinkResources", resource.Type);
                Assert.Equal(SharedPrivateLinkResourceProvisioningState.Succeeded, resource.Properties.ProvisioningState);
                Assert.Equal(SharedPrivateLinkResourceStatus.Pending, resource.Properties.Status);

                var resources = searchMgmt.SharedPrivateLinkResources.ListByService(
                    Data.ResourceGroupName,
                    Data.ServiceName);

                Assert.Single(resources);

                // shouldn't throw an exception
                searchMgmt.SharedPrivateLinkResources.Delete(
                    Data.ResourceGroupName,
                    Data.ServiceName,
                    Data.SharedPrivateLinkResourceName);
            });
        }
    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Network.Admin;
using Microsoft.AzureStack.Management.Network.Admin.Models;
using Xunit;

namespace Network.Tests
{
    public class NetworkTests : NetworkTestBase
    {
        private void AssertAdminOverviewResourceHealth(AdminOverviewResourceHealth health) 
        {
            Assert.NotNull(health);
            Assert.NotNull(health.ErrorResourceCount);
            Assert.NotNull(health.HealthUnknownCount);
            Assert.NotNull(health.HealthyResourceCount);
            Assert.NotNull(health.ErrorResourceCount);
            Assert.NotNull(health.ErrorResourceCount);
        }

        private void AssertAdminOverviewResourceUsage(AdminOverviewResourceUsage usage)
        {
            Assert.NotNull(usage);
            Assert.NotNull(usage.InUseResourceCount);
            Assert.NotNull(usage.TotalResourceCount);
        }

        [Fact]
        public void TestGetAdminOverview()
        {
            RunTest((client) =>
            {
                var overview = client.ResourceProviderState.Get();
                if (overview != null)
                {
                    Assert.NotNull(overview.Id);
                    Assert.NotNull(overview.Type);

                    AssertAdminOverviewResourceHealth(overview.LoadBalancerMuxHealth);
                    AssertAdminOverviewResourceHealth(overview.VirtualNetworkHealth);
                    AssertAdminOverviewResourceHealth(overview.VirtualGatewayHealth);

                    AssertAdminOverviewResourceUsage(overview.MacAddressUsage);
                    AssertAdminOverviewResourceUsage(overview.PublicIpAddressUsage);
                    AssertAdminOverviewResourceUsage(overview.BackendIpUsage);
                }
            });
        }
    }
}
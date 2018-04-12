// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Network.Admin;
using Microsoft.AzureStack.Management.Network.Admin.Models;
using Xunit;

namespace Network.Tests
{
    public class LoadBalancers : NetworkTestBase
    {
        private void AssertLoadBalancersAreSame(LoadBalancer expected, LoadBalancer found)
        {
            if (expected == null)
            {
                Assert.Null(found);
            }
            else
            {
                Assert.True(NetworkCommon.CheckBaseResourcesAreSame(expected, found));

                Assert.True(NetworkCommon.CheckBaseResourceTenantAreSame(expected, found));

                Assert.Equal(expected.PublicIpAddresses, found.PublicIpAddresses);
            }
        }

        [Fact]
        public void TestGetAllLoadBalancers()
        {
            RunTest((client) =>
            {
                var balancers = client.LoadBalancers.List();
                // This test should be using the SessionRecord which has an existing LoadBalancer created
                if (balancers != null)
                {
                    balancers.ForEach((loadBalancer) =>
                    {
                        //var retrieved = client.LoadBalancers.Get(loadBalancer.Name);
                        //AssertLoadBalancersAreSame(loadBalancer, retrieved);

                        NetworkCommon.ValidateBaseResources(loadBalancer);

                        NetworkCommon.ValidateBaseResourceTenant(loadBalancer);

                        Assert.NotNull(loadBalancer.PublicIpAddresses);
                        foreach(string IpAddress in loadBalancer.PublicIpAddresses) {
                            Assert.NotNull(IpAddress);
                        }
                    });
                }
            });
        }
    }
}

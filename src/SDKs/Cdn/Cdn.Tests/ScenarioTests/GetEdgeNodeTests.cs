// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Cdn;
using Cdn.Tests.Helpers;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Cdn.Models;

namespace Cdn.Tests.ScenarioTests
{
    public class GetEdgeNodeTests
    {
        [Fact]
        public void GetEdgeNodeTest()
        {
            const int minPrefixLength = 0;
            const int maxIpv4PrefixLength = 32;
            const int maxIpv6PrefixLength = 128;
            var expectedEdgeNodeNames = new List<string> { "Standard_Verizon", "Premium_Verizon", "Custom_Verizon" };

            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                var edgeNodes = cdnMgmtClient.EdgeNodes.List().GetEnumerator().ToIEnumerable<EdgeNode>().ToList();

                Assert.Empty(edgeNodes.Select(e => e.Name).Except(expectedEdgeNodeNames));
                Assert.Empty(expectedEdgeNodeNames.Except(edgeNodes.Select(e => e.Name)));

                foreach (var edgeNode in edgeNodes)
                {
                    Assert.True(edgeNode.IpAddressGroups.Count > 0);
                    foreach (var ipAddressGroup in edgeNode.IpAddressGroups)
                    {
                        Assert.False(string.IsNullOrWhiteSpace(ipAddressGroup.DeliveryRegion));

                        Assert.True(ipAddressGroup.Ipv4Addresses.Count > 0);
                        foreach (var cidrIpAddress in ipAddressGroup.Ipv4Addresses)
                        {
                            Assert.False(string.IsNullOrWhiteSpace(cidrIpAddress.BaseIpAddress));
                            Assert.True(cidrIpAddress.PrefixLength >= minPrefixLength &&
                                          cidrIpAddress.PrefixLength <= maxIpv4PrefixLength);
                        }

                        Assert.True(ipAddressGroup.Ipv6Addresses.Count > 0);
                        foreach (var cidrIpAddress in ipAddressGroup.Ipv6Addresses)
                        {
                            Assert.False(string.IsNullOrWhiteSpace(cidrIpAddress.BaseIpAddress));
                            Assert.True(cidrIpAddress.PrefixLength >= minPrefixLength &&
                                          cidrIpAddress.PrefixLength <= maxIpv6PrefixLength);
                        }
                    }
                }
            }
        }
    }
}

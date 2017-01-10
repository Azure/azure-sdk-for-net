// 
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Cdn;
using Cdn.Tests.Helpers;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Linq;

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

                var edgeNodes = cdnMgmtClient.EdgeNodes.List().Value;

                Assert.Equal(0, edgeNodes.Select(e => e.Name).Except(expectedEdgeNodeNames).Count());
                Assert.Equal(0, expectedEdgeNodeNames.Except(edgeNodes.Select(e => e.Name)).Count());

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

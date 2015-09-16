using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;

namespace Networks.Tests
{
    public class NetworkSecurityGroupTests
    {
        [Fact]
        public void NetworkSecurityGroupApiTest()
        {
            var handler = new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK};

            using (var context = UndoContext.Current)
            {
                context.Start();
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/networkSecurityGroups");
                
                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                string networkSecurityGroupName = TestUtilities.GenerateName();

                var networkSecurityGroup = new NetworkSecurityGroup()
                {
                    Location = location,
                };

                // Put Nsg
                var putNsgResponse = networkResourceProviderClient.NetworkSecurityGroups.CreateOrUpdate(resourceGroupName, networkSecurityGroupName, networkSecurityGroup);
                Assert.Equal(HttpStatusCode.OK, putNsgResponse.StatusCode);
                Assert.Equal("Succeeded", putNsgResponse.Status);

                // Get NSG
                var getNsgResponse = networkResourceProviderClient.NetworkSecurityGroups.Get(resourceGroupName, networkSecurityGroupName);
                Assert.Equal(HttpStatusCode.OK, getNsgResponse.StatusCode);
                Assert.Equal(networkSecurityGroupName, getNsgResponse.NetworkSecurityGroup.Name);
                Assert.NotNull(getNsgResponse.NetworkSecurityGroup.ResourceGuid);
                Assert.Equal(6, getNsgResponse.NetworkSecurityGroup.DefaultSecurityRules.Count);
                Assert.Equal("AllowVnetInBound", getNsgResponse.NetworkSecurityGroup.DefaultSecurityRules[0].Name);
                Assert.Equal("AllowAzureLoadBalancerInBound", getNsgResponse.NetworkSecurityGroup.DefaultSecurityRules[1].Name);
                Assert.Equal("DenyAllInBound", getNsgResponse.NetworkSecurityGroup.DefaultSecurityRules[2].Name);
                Assert.Equal("AllowVnetOutBound", getNsgResponse.NetworkSecurityGroup.DefaultSecurityRules[3].Name);
                Assert.Equal("AllowInternetOutBound", getNsgResponse.NetworkSecurityGroup.DefaultSecurityRules[4].Name);
                Assert.Equal("DenyAllOutBound", getNsgResponse.NetworkSecurityGroup.DefaultSecurityRules[5].Name);

                // Verify a default security rule
                Assert.Equal(SecurityRuleAccess.Allow, getNsgResponse.NetworkSecurityGroup.DefaultSecurityRules[0].Access);
                Assert.Equal("Allow inbound traffic from all VMs in VNET", getNsgResponse.NetworkSecurityGroup.DefaultSecurityRules[0].Description);
                Assert.Equal("VirtualNetwork", getNsgResponse.NetworkSecurityGroup.DefaultSecurityRules[0].DestinationAddressPrefix);
                Assert.Equal("*", getNsgResponse.NetworkSecurityGroup.DefaultSecurityRules[0].DestinationPortRange);
                Assert.Equal(SecurityRuleDirection.Inbound, getNsgResponse.NetworkSecurityGroup.DefaultSecurityRules[0].Direction);
                Assert.Equal(65000, getNsgResponse.NetworkSecurityGroup.DefaultSecurityRules[0].Priority);
                Assert.Equal(SecurityRuleProtocol.All, getNsgResponse.NetworkSecurityGroup.DefaultSecurityRules[0].Protocol);
                Assert.Equal("Succeeded", getNsgResponse.NetworkSecurityGroup.DefaultSecurityRules[0].ProvisioningState);
                Assert.Equal("VirtualNetwork", getNsgResponse.NetworkSecurityGroup.DefaultSecurityRules[0].SourceAddressPrefix);
                Assert.Equal("*", getNsgResponse.NetworkSecurityGroup.DefaultSecurityRules[0].SourcePortRange);

                // List NSG
                var listNsgResponse = networkResourceProviderClient.NetworkSecurityGroups.List(resourceGroupName);
                Assert.Equal(HttpStatusCode.OK, listNsgResponse.StatusCode);
                Assert.Equal(1, listNsgResponse.NetworkSecurityGroups.Count);
                Assert.Equal(networkSecurityGroupName, listNsgResponse.NetworkSecurityGroups[0].Name);
                Assert.Equal(6, listNsgResponse.NetworkSecurityGroups[0].DefaultSecurityRules.Count);
                Assert.Equal("AllowVnetInBound", listNsgResponse.NetworkSecurityGroups[0].DefaultSecurityRules[0].Name);
                Assert.Equal("AllowAzureLoadBalancerInBound", listNsgResponse.NetworkSecurityGroups[0].DefaultSecurityRules[1].Name);
                Assert.Equal("DenyAllInBound", listNsgResponse.NetworkSecurityGroups[0].DefaultSecurityRules[2].Name);
                Assert.Equal("AllowVnetOutBound", listNsgResponse.NetworkSecurityGroups[0].DefaultSecurityRules[3].Name);
                Assert.Equal("AllowInternetOutBound", listNsgResponse.NetworkSecurityGroups[0].DefaultSecurityRules[4].Name);
                Assert.Equal("DenyAllOutBound", listNsgResponse.NetworkSecurityGroups[0].DefaultSecurityRules[5].Name);
                Assert.Equal(getNsgResponse.NetworkSecurityGroup.Etag, listNsgResponse.NetworkSecurityGroups[0].Etag);

                // List NSG in a subscription
                var listNsgSubsciptionResponse = networkResourceProviderClient.NetworkSecurityGroups.ListAll();
                Assert.Equal(HttpStatusCode.OK, listNsgSubsciptionResponse.StatusCode);
                Assert.Equal(1, listNsgSubsciptionResponse.NetworkSecurityGroups.Count);
                Assert.Equal(networkSecurityGroupName, listNsgSubsciptionResponse.NetworkSecurityGroups[0].Name);
                Assert.Equal(6, listNsgSubsciptionResponse.NetworkSecurityGroups[0].DefaultSecurityRules.Count);
                Assert.Equal("AllowVnetInBound", listNsgSubsciptionResponse.NetworkSecurityGroups[0].DefaultSecurityRules[0].Name);
                Assert.Equal("AllowAzureLoadBalancerInBound", listNsgSubsciptionResponse.NetworkSecurityGroups[0].DefaultSecurityRules[1].Name);
                Assert.Equal("DenyAllInBound", listNsgSubsciptionResponse.NetworkSecurityGroups[0].DefaultSecurityRules[2].Name);
                Assert.Equal("AllowVnetOutBound", listNsgSubsciptionResponse.NetworkSecurityGroups[0].DefaultSecurityRules[3].Name);
                Assert.Equal("AllowInternetOutBound", listNsgSubsciptionResponse.NetworkSecurityGroups[0].DefaultSecurityRules[4].Name);
                Assert.Equal("DenyAllOutBound", listNsgSubsciptionResponse.NetworkSecurityGroups[0].DefaultSecurityRules[5].Name);
                Assert.Equal(getNsgResponse.NetworkSecurityGroup.Etag, listNsgSubsciptionResponse.NetworkSecurityGroups[0].Etag);

                // Delete NSG
                var deleteResponse = networkResourceProviderClient.NetworkSecurityGroups.Delete(resourceGroupName, networkSecurityGroupName);
                Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);

                // List NSG
                listNsgResponse = networkResourceProviderClient.NetworkSecurityGroups.List(resourceGroupName);
                Assert.Equal(HttpStatusCode.OK, listNsgResponse.StatusCode);
                Assert.Equal(0, listNsgResponse.NetworkSecurityGroups.Count);
            }
        }

        [Fact]
        public void NetworkSecurityGroupWithRulesApiTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/networkSecurityGroups");
                
                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                string networkSecurityGroupName = TestUtilities.GenerateName();
                string securityRule1 = TestUtilities.GenerateName();
                string securityRule2 = TestUtilities.GenerateName();

                string destinationPortRange = "123-3500";

                var networkSecurityGroup = new NetworkSecurityGroup()
                {
                    Location = location,
                    SecurityRules = new List<SecurityRule>()
                                    {
                                        new SecurityRule()
                                            {
                                                Name = securityRule1,
                                                Access = SecurityRuleAccess.Allow,
                                                Description = "Test security rule",
                                                DestinationAddressPrefix = "*",
                                                DestinationPortRange = destinationPortRange,
                                                Direction = SecurityRuleDirection.Inbound,
                                                Priority = 500,
                                                Protocol = SecurityRuleProtocol.Tcp,
                                                SourceAddressPrefix = "*",
                                                SourcePortRange = "655"
                                            }
                                    }
                };

                // Put Nsg
                var putNsgResponse = networkResourceProviderClient.NetworkSecurityGroups.CreateOrUpdate(resourceGroupName, networkSecurityGroupName, networkSecurityGroup);
                Assert.Equal(HttpStatusCode.OK, putNsgResponse.StatusCode);
                Assert.Equal("Succeeded", putNsgResponse.Status);

                // Get NSG
                var getNsgResponse = networkResourceProviderClient.NetworkSecurityGroups.Get(resourceGroupName, networkSecurityGroupName);
                Assert.Equal(HttpStatusCode.OK, getNsgResponse.StatusCode);
                Assert.Equal(networkSecurityGroupName, getNsgResponse.NetworkSecurityGroup.Name);
                Assert.Equal(6, getNsgResponse.NetworkSecurityGroup.DefaultSecurityRules.Count);
                Assert.Equal("AllowVnetInBound", getNsgResponse.NetworkSecurityGroup.DefaultSecurityRules[0].Name);
                Assert.Equal("AllowAzureLoadBalancerInBound", getNsgResponse.NetworkSecurityGroup.DefaultSecurityRules[1].Name);
                Assert.Equal("DenyAllInBound", getNsgResponse.NetworkSecurityGroup.DefaultSecurityRules[2].Name);
                Assert.Equal("AllowVnetOutBound", getNsgResponse.NetworkSecurityGroup.DefaultSecurityRules[3].Name);
                Assert.Equal("AllowInternetOutBound", getNsgResponse.NetworkSecurityGroup.DefaultSecurityRules[4].Name);
                Assert.Equal("DenyAllOutBound", getNsgResponse.NetworkSecurityGroup.DefaultSecurityRules[5].Name);

                // Verify the security rule
                Assert.Equal(SecurityRuleAccess.Allow, getNsgResponse.NetworkSecurityGroup.SecurityRules[0].Access);
                Assert.Equal("Test security rule", getNsgResponse.NetworkSecurityGroup.SecurityRules[0].Description);
                Assert.Equal("*", getNsgResponse.NetworkSecurityGroup.SecurityRules[0].DestinationAddressPrefix);
                Assert.Equal(destinationPortRange, getNsgResponse.NetworkSecurityGroup.SecurityRules[0].DestinationPortRange);
                Assert.Equal(SecurityRuleDirection.Inbound, getNsgResponse.NetworkSecurityGroup.SecurityRules[0].Direction);
                Assert.Equal(500, getNsgResponse.NetworkSecurityGroup.SecurityRules[0].Priority);
                Assert.Equal(SecurityRuleProtocol.Tcp, getNsgResponse.NetworkSecurityGroup.SecurityRules[0].Protocol);
                Assert.Equal("Succeeded", getNsgResponse.NetworkSecurityGroup.SecurityRules[0].ProvisioningState);
                Assert.Equal("*", getNsgResponse.NetworkSecurityGroup.SecurityRules[0].SourceAddressPrefix);
                Assert.Equal("655", getNsgResponse.NetworkSecurityGroup.SecurityRules[0].SourcePortRange);

                // List NSG
                var listNsgResponse = networkResourceProviderClient.NetworkSecurityGroups.List(resourceGroupName);
                Assert.Equal(HttpStatusCode.OK, listNsgResponse.StatusCode);
                Assert.Equal(1, listNsgResponse.NetworkSecurityGroups.Count);
                Assert.Equal(networkSecurityGroupName, listNsgResponse.NetworkSecurityGroups[0].Name);
                Assert.Equal(6, listNsgResponse.NetworkSecurityGroups[0].DefaultSecurityRules.Count);
                Assert.Equal("AllowVnetInBound", listNsgResponse.NetworkSecurityGroups[0].DefaultSecurityRules[0].Name);
                Assert.Equal("AllowAzureLoadBalancerInBound", listNsgResponse.NetworkSecurityGroups[0].DefaultSecurityRules[1].Name);
                Assert.Equal("DenyAllInBound", listNsgResponse.NetworkSecurityGroups[0].DefaultSecurityRules[2].Name);
                Assert.Equal("AllowVnetOutBound", listNsgResponse.NetworkSecurityGroups[0].DefaultSecurityRules[3].Name);
                Assert.Equal("AllowInternetOutBound", listNsgResponse.NetworkSecurityGroups[0].DefaultSecurityRules[4].Name);
                Assert.Equal("DenyAllOutBound", listNsgResponse.NetworkSecurityGroups[0].DefaultSecurityRules[5].Name);
                Assert.Equal(getNsgResponse.NetworkSecurityGroup.Etag, listNsgResponse.NetworkSecurityGroups[0].Etag);

                // List NSG in a subscription
                var listNsgSubsciptionResponse = networkResourceProviderClient.NetworkSecurityGroups.ListAll();
                Assert.Equal(HttpStatusCode.OK, listNsgSubsciptionResponse.StatusCode);
                Assert.Equal(1, listNsgSubsciptionResponse.NetworkSecurityGroups.Count);
                Assert.Equal(networkSecurityGroupName, listNsgSubsciptionResponse.NetworkSecurityGroups[0].Name);
                Assert.Equal(6, listNsgSubsciptionResponse.NetworkSecurityGroups[0].DefaultSecurityRules.Count);
                Assert.Equal("AllowVnetInBound", listNsgSubsciptionResponse.NetworkSecurityGroups[0].DefaultSecurityRules[0].Name);
                Assert.Equal("AllowAzureLoadBalancerInBound", listNsgSubsciptionResponse.NetworkSecurityGroups[0].DefaultSecurityRules[1].Name);
                Assert.Equal("DenyAllInBound", listNsgSubsciptionResponse.NetworkSecurityGroups[0].DefaultSecurityRules[2].Name);
                Assert.Equal("AllowVnetOutBound", listNsgSubsciptionResponse.NetworkSecurityGroups[0].DefaultSecurityRules[3].Name);
                Assert.Equal("AllowInternetOutBound", listNsgSubsciptionResponse.NetworkSecurityGroups[0].DefaultSecurityRules[4].Name);
                Assert.Equal("DenyAllOutBound", listNsgSubsciptionResponse.NetworkSecurityGroups[0].DefaultSecurityRules[5].Name);
                Assert.Equal(getNsgResponse.NetworkSecurityGroup.Etag, listNsgSubsciptionResponse.NetworkSecurityGroups[0].Etag);

                // Add a new security rule
                var SecurityRule = new SecurityRule()
                                              {
                                                  Name = securityRule2,
                                                  Access = SecurityRuleAccess.Deny,
                                                  Description = "Test outbound security rule",
                                                  DestinationAddressPrefix = "*",
                                                  DestinationPortRange = destinationPortRange,
                                                  Direction = SecurityRuleDirection.Outbound,
                                                  Priority = 501,
                                                  Protocol = SecurityRuleProtocol.Udp,
                                                  SourceAddressPrefix = "*",
                                                  SourcePortRange = "656",
                                              };

                networkSecurityGroup.SecurityRules.Add(SecurityRule);

                putNsgResponse = networkResourceProviderClient.NetworkSecurityGroups.CreateOrUpdate(resourceGroupName, networkSecurityGroupName, networkSecurityGroup);
                Assert.Equal(HttpStatusCode.OK, putNsgResponse.StatusCode);
                Assert.Equal("Succeeded", putNsgResponse.Status);

                // Get NSG
                getNsgResponse = networkResourceProviderClient.NetworkSecurityGroups.Get(resourceGroupName, networkSecurityGroupName);
                Assert.Equal(HttpStatusCode.OK, getNsgResponse.StatusCode);

                // Verify the security rule
                Assert.Equal(SecurityRuleAccess.Deny, getNsgResponse.NetworkSecurityGroup.SecurityRules[1].Access);
                Assert.Equal("Test outbound security rule", getNsgResponse.NetworkSecurityGroup.SecurityRules[1].Description);
                Assert.Equal("*", getNsgResponse.NetworkSecurityGroup.SecurityRules[1].DestinationAddressPrefix);
                Assert.Equal(destinationPortRange, getNsgResponse.NetworkSecurityGroup.SecurityRules[1].DestinationPortRange);
                Assert.Equal(SecurityRuleDirection.Outbound, getNsgResponse.NetworkSecurityGroup.SecurityRules[1].Direction);
                Assert.Equal(501, getNsgResponse.NetworkSecurityGroup.SecurityRules[1].Priority);
                Assert.Equal(SecurityRuleProtocol.Udp, getNsgResponse.NetworkSecurityGroup.SecurityRules[1].Protocol);
                Assert.Equal("Succeeded", getNsgResponse.NetworkSecurityGroup.SecurityRules[1].ProvisioningState);
                Assert.Equal("*", getNsgResponse.NetworkSecurityGroup.SecurityRules[1].SourceAddressPrefix);
                Assert.Equal("656", getNsgResponse.NetworkSecurityGroup.SecurityRules[1].SourcePortRange);

                // Delete NSG
                var deleteResponse = networkResourceProviderClient.NetworkSecurityGroups.Delete(resourceGroupName, networkSecurityGroupName);
                Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);

                // List NSG
                listNsgResponse = networkResourceProviderClient.NetworkSecurityGroups.List(resourceGroupName);
                Assert.Equal(HttpStatusCode.OK, listNsgResponse.StatusCode);
                Assert.Equal(0, listNsgResponse.NetworkSecurityGroups.Count);
            }
        }
    }
}
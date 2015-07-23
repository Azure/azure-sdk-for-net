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
    public class SecurityRuleTests
    {
        [Fact]
        public void SecurityRuleWithRulesApiTest()
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

                // Get SecurityRule
                var getSecurityRuleResponse = networkResourceProviderClient.SecurityRules.Get(resourceGroupName, networkSecurityGroupName, securityRule1);
                Assert.Equal(HttpStatusCode.OK, getSecurityRuleResponse.StatusCode);
                Assert.Equal(securityRule1, getSecurityRuleResponse.SecurityRule.Name);

                this.CompareSecurityRule(getNsgResponse.NetworkSecurityGroup.SecurityRules[0], getSecurityRuleResponse.SecurityRule);

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

                var putSecurityRuleResponse = networkResourceProviderClient.SecurityRules.CreateOrUpdate(resourceGroupName, networkSecurityGroupName, securityRule2, SecurityRule);
                Assert.Equal(HttpStatusCode.OK, putSecurityRuleResponse.StatusCode);
                Assert.Equal("Succeeded", putSecurityRuleResponse.Status);

                // Get NSG
                getNsgResponse = networkResourceProviderClient.NetworkSecurityGroups.Get(resourceGroupName, networkSecurityGroupName);
                Assert.Equal(HttpStatusCode.OK, getNsgResponse.StatusCode);

                // Get the SecurityRule2
                var getSecurityRule2Response = networkResourceProviderClient.SecurityRules.Get(resourceGroupName, networkSecurityGroupName, securityRule2);
                Assert.Equal(HttpStatusCode.OK, getSecurityRule2Response.StatusCode);
                Assert.Equal(securityRule2, getSecurityRule2Response.SecurityRule.Name);

                // Verify the security rule
                Assert.Equal(SecurityRuleAccess.Deny, getSecurityRule2Response.SecurityRule.Access);
                Assert.Equal("Test outbound security rule", getSecurityRule2Response.SecurityRule.Description);
                Assert.Equal("*", getSecurityRule2Response.SecurityRule.DestinationAddressPrefix);
                Assert.Equal(destinationPortRange, getSecurityRule2Response.SecurityRule.DestinationPortRange);
                Assert.Equal(SecurityRuleDirection.Outbound, getSecurityRule2Response.SecurityRule.Direction);
                Assert.Equal(501, getSecurityRule2Response.SecurityRule.Priority);
                Assert.Equal(SecurityRuleProtocol.Udp, getSecurityRule2Response.SecurityRule.Protocol);
                Assert.Equal("Succeeded", getSecurityRule2Response.SecurityRule.ProvisioningState);
                Assert.Equal("*", getSecurityRule2Response.SecurityRule.SourceAddressPrefix);
                Assert.Equal("656", getSecurityRule2Response.SecurityRule.SourcePortRange);

                this.CompareSecurityRule(getNsgResponse.NetworkSecurityGroup.SecurityRules[1], getSecurityRule2Response.SecurityRule);

                // List all SecurityRules
                var getsecurityRules = networkResourceProviderClient.SecurityRules.List(resourceGroupName, networkSecurityGroupName);
                Assert.Equal(HttpStatusCode.OK, getsecurityRules.StatusCode);

                Assert.Equal(2, getsecurityRules.SecurityRules.Count);
                this.CompareSecurityRule(getNsgResponse.NetworkSecurityGroup.SecurityRules[0], getsecurityRules.SecurityRules[0]);
                this.CompareSecurityRule(getNsgResponse.NetworkSecurityGroup.SecurityRules[1], getsecurityRules.SecurityRules[1]);

                // Delete a SecurityRule
                var deleteSecurityRuleResponse = networkResourceProviderClient.SecurityRules.Delete(resourceGroupName, networkSecurityGroupName, securityRule2);
                Assert.Equal(HttpStatusCode.OK, deleteSecurityRuleResponse.StatusCode);

                getsecurityRules = networkResourceProviderClient.SecurityRules.List(resourceGroupName, networkSecurityGroupName);
                Assert.Equal(HttpStatusCode.OK, getsecurityRules.StatusCode);

                Assert.Equal(1, getsecurityRules.SecurityRules.Count);

               // Delete NSG
                var deleteResponse = networkResourceProviderClient.NetworkSecurityGroups.Delete(resourceGroupName, networkSecurityGroupName);
                Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);

                // List NSG
                var listNsgResponse = networkResourceProviderClient.NetworkSecurityGroups.List(resourceGroupName);
                Assert.Equal(HttpStatusCode.OK, listNsgResponse.StatusCode);
                Assert.Equal(0, listNsgResponse.NetworkSecurityGroups.Count);
            }
        }

        private void CompareSecurityRule(SecurityRule rule1, SecurityRule rule2)
        {
            Assert.Equal(rule1.Name, rule2.Name);
            Assert.Equal(rule1.Etag, rule2.Etag);
            Assert.Equal(rule1.Access, rule2.Access);
            Assert.Equal(rule1.Description, rule2.Description);
            Assert.Equal(rule1.DestinationAddressPrefix, rule2.DestinationAddressPrefix);
            Assert.Equal(rule1.DestinationPortRange, rule2.DestinationPortRange);
            Assert.Equal(rule1.Direction, rule2.Direction);
            Assert.Equal(rule1.Protocol, rule2.Protocol);
            Assert.Equal(rule1.ProvisioningState, rule2.ProvisioningState);
            Assert.Equal(rule1.SourceAddressPrefix, rule2.SourceAddressPrefix);
            Assert.Equal(rule1.SourcePortRange, rule2.SourcePortRange);
        }
    }
}
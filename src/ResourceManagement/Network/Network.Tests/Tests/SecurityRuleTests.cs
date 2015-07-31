using System.Collections.Generic;
using System.Net;
using System.Linq;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Networks.Tests
{
    public class SecurityRuleTests
    {
        [Fact(Skip = "TODO: Autorest")]
        public void SecurityRuleWithRulesApiTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start())
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);

                // var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/networkSecurityGroups");
                var location = "west us";

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
                Assert.Equal("Succeeded", putNsgResponse.ProvisioningState);

                // Get NSG
                var getNsgResponse = networkResourceProviderClient.NetworkSecurityGroups.Get(resourceGroupName, networkSecurityGroupName);
                Assert.Equal(networkSecurityGroupName, getNsgResponse.Name);

                // Get SecurityRule
                var getSecurityRuleResponse = networkResourceProviderClient.SecurityRules.Get(resourceGroupName, networkSecurityGroupName, securityRule1);
                Assert.Equal(securityRule1, getSecurityRuleResponse.Name);

                CompareSecurityRule(getNsgResponse.SecurityRules[0], getSecurityRuleResponse);

                // Add a new security rule
                var securityRule = new SecurityRule()
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

                var putSecurityRuleResponse = networkResourceProviderClient.SecurityRules.CreateOrUpdate(resourceGroupName, networkSecurityGroupName, securityRule2, securityRule);
                Assert.Equal("Succeeded", putSecurityRuleResponse.ProvisioningState);

                // Get NSG
                getNsgResponse = networkResourceProviderClient.NetworkSecurityGroups.Get(resourceGroupName, networkSecurityGroupName);

                // Get the SecurityRule2
                var getSecurityRule2Response = networkResourceProviderClient.SecurityRules.Get(resourceGroupName, networkSecurityGroupName, securityRule2);
                Assert.Equal(securityRule2, getSecurityRule2Response.Name);

                // Verify the security rule
                Assert.Equal(SecurityRuleAccess.Deny, getSecurityRule2Response.Access);
                Assert.Equal("Test outbound security rule", getSecurityRule2Response.Description);
                Assert.Equal("*", getSecurityRule2Response.DestinationAddressPrefix);
                Assert.Equal(destinationPortRange, getSecurityRule2Response.DestinationPortRange);
                Assert.Equal(SecurityRuleDirection.Outbound, getSecurityRule2Response.Direction);
                Assert.Equal(501, getSecurityRule2Response.Priority);
                Assert.Equal(SecurityRuleProtocol.Udp, getSecurityRule2Response.Protocol);
                Assert.Equal("Succeeded", getSecurityRule2Response.ProvisioningState);
                Assert.Equal("*", getSecurityRule2Response.SourceAddressPrefix);
                Assert.Equal("656", getSecurityRule2Response.SourcePortRange);

                this.CompareSecurityRule(getNsgResponse.SecurityRules[1], getSecurityRule2Response);

                // List all SecurityRules
                var getsecurityRules = networkResourceProviderClient.SecurityRules.List(resourceGroupName, networkSecurityGroupName);

                Assert.Equal(2, getsecurityRules.Count());
                this.CompareSecurityRule(getNsgResponse.SecurityRules[0], getsecurityRules.First());
                this.CompareSecurityRule(getNsgResponse.SecurityRules[1], getsecurityRules.ToArray()[1]);

                // Delete a SecurityRule
                networkResourceProviderClient.SecurityRules.Delete(resourceGroupName, networkSecurityGroupName, securityRule2);

                getsecurityRules = networkResourceProviderClient.SecurityRules.List(resourceGroupName, networkSecurityGroupName);

                Assert.Equal(1, getsecurityRules.Count());

                // Delete NSG
                networkResourceProviderClient.NetworkSecurityGroups.Delete(resourceGroupName, networkSecurityGroupName);

                // List NSG
                var listNsgResponse = networkResourceProviderClient.NetworkSecurityGroups.List(resourceGroupName);
                Assert.Equal(0, listNsgResponse.Count());
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
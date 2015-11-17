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
    using System.Linq;

    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public class SecurityRuleTests
    {
        [Fact]
        public void SecurityRuleWithRulesApiTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

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
                var putNsgResponse = networkManagementClient.NetworkSecurityGroups.CreateOrUpdate(resourceGroupName, networkSecurityGroupName, networkSecurityGroup);
                Assert.Equal("Succeeded", putNsgResponse.ProvisioningState);

                // Get NSG
                var getNsgResponse = networkManagementClient.NetworkSecurityGroups.Get(resourceGroupName, networkSecurityGroupName);
                Assert.Equal(networkSecurityGroupName, getNsgResponse.Name);

                // Get SecurityRule
                var getSecurityRuleResponse = networkManagementClient.SecurityRules.Get(resourceGroupName, networkSecurityGroupName, securityRule1);
                Assert.Equal(securityRule1, getSecurityRuleResponse.Name);

                this.CompareSecurityRule(getNsgResponse.SecurityRules[0], getSecurityRuleResponse);

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

                var putSecurityRuleResponse = networkManagementClient.SecurityRules.CreateOrUpdate(resourceGroupName, networkSecurityGroupName, securityRule2, SecurityRule);
                Assert.Equal("Succeeded", putSecurityRuleResponse.ProvisioningState);

                // Get NSG
                getNsgResponse = networkManagementClient.NetworkSecurityGroups.Get(resourceGroupName, networkSecurityGroupName);
                
                // Get the SecurityRule2
                var getSecurityRule2Response = networkManagementClient.SecurityRules.Get(resourceGroupName, networkSecurityGroupName, securityRule2);
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
                var getsecurityRules = networkManagementClient.SecurityRules.List(resourceGroupName, networkSecurityGroupName);
                
                Assert.Equal(2, getsecurityRules.Count());
                this.CompareSecurityRule(getNsgResponse.SecurityRules[0], getsecurityRules.ElementAt(0));
                this.CompareSecurityRule(getNsgResponse.SecurityRules[1], getsecurityRules.ElementAt(1));

                // Delete a SecurityRule
                networkManagementClient.SecurityRules.Delete(resourceGroupName, networkSecurityGroupName, securityRule2);
                
                getsecurityRules = networkManagementClient.SecurityRules.List(resourceGroupName, networkSecurityGroupName);
                
                Assert.Equal(1, getsecurityRules.Count());

               // Delete NSG
                networkManagementClient.NetworkSecurityGroups.Delete(resourceGroupName, networkSecurityGroupName);
                
                // List NSG
                var listNsgResponse = networkManagementClient.NetworkSecurityGroups.List(resourceGroupName);
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
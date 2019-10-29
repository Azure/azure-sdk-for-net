using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;

namespace Network.Tests.Tests
{
    using System.Linq;

    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Helpers;

    public class ViewNsgRuleTests
    {
        [Fact(Skip="Disable tests")]
        public void ViewNsgRuleApiTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);
                var computeManagementClient = NetworkManagementTestUtilities.GetComputeManagementClientWithHandler(context, handler3);

                string location = "westcentralus";

                string resourceGroupName = TestUtilities.GenerateName();
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                string virtualMachineName = TestUtilities.GenerateName();
                string networkInterfaceName = TestUtilities.GenerateName();
                string networkSecurityGroupName = virtualMachineName + "-nsg";

                //Deploy VM with template
                Deployments.CreateVm(
                    resourcesClient: resourcesClient,
                    resourceGroupName: resourceGroupName,
                    location: location,
                    virtualMachineName: virtualMachineName,
                    storageAccountName: TestUtilities.GenerateName(),
                    networkInterfaceName: networkInterfaceName,
                    networkSecurityGroupName: networkSecurityGroupName,
                    diagnosticsStorageAccountName: TestUtilities.GenerateName(),
                    deploymentName: TestUtilities.GenerateName()
                    );

                string networkWatcherName = TestUtilities.GenerateName();
                NetworkWatcher properties = new NetworkWatcher();
                properties.Location = location;

                //Create network Watcher
                var createNetworkWatcher = networkManagementClient.NetworkWatchers.CreateOrUpdate(resourceGroupName, networkWatcherName, properties);

                var getVm = computeManagementClient.VirtualMachines.Get(resourceGroupName, virtualMachineName);
                string localIPAddress = networkManagementClient.NetworkInterfaces.Get(resourceGroupName, networkInterfaceName).IpConfigurations.FirstOrDefault().PrivateIPAddress;

                string securityRule1 = TestUtilities.GenerateName();

                // Add a security rule
                var SecurityRule = new SecurityRule()
                {
                    Name = securityRule1,
                    Access = SecurityRuleAccess.Deny,
                    Description = "Test outbound security rule",
                    DestinationAddressPrefix = "*",
                    DestinationPortRange = "80",
                    Direction = SecurityRuleDirection.Outbound,
                    Priority = 501,
                    Protocol = SecurityRuleProtocol.Tcp,
                    SourceAddressPrefix = "*",
                    SourcePortRange = "*",
                };

                var nsg = networkManagementClient.NetworkSecurityGroups.Get(resourceGroupName, networkSecurityGroupName);
                nsg.SecurityRules.Add(SecurityRule);
                networkManagementClient.NetworkSecurityGroups.CreateOrUpdate(resourceGroupName, networkSecurityGroupName, nsg);

                SecurityGroupViewParameters sgvProperties = new SecurityGroupViewParameters()
                {
                    TargetResourceId = getVm.Id
                };

                //Get view security group rules
                var viewNSGRules = networkManagementClient.NetworkWatchers.GetVMSecurityRules(resourceGroupName, networkWatcherName, sgvProperties);

                //Verify effective security rule defined earlier
                var getEffectiveSecurityRule = viewNSGRules.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.EffectiveSecurityRules.Where(x => x.Name == "UserRule_" + securityRule1);
                Assert.Equal("Tcp", getEffectiveSecurityRule.FirstOrDefault().Protocol);
                Assert.Equal(501, getEffectiveSecurityRule.FirstOrDefault().Priority);
                Assert.Equal("Deny", getEffectiveSecurityRule.FirstOrDefault().Access);
                Assert.Equal("Outbound", getEffectiveSecurityRule.FirstOrDefault().Direction);
                Assert.Equal("0.0.0.0/0", getEffectiveSecurityRule.FirstOrDefault().DestinationAddressPrefix);
                Assert.Equal("80-80", getEffectiveSecurityRule.FirstOrDefault().DestinationPortRange);
                Assert.Equal("0.0.0.0/0", getEffectiveSecurityRule.FirstOrDefault().SourceAddressPrefix);
                Assert.Equal("0-65535", getEffectiveSecurityRule.FirstOrDefault().SourcePortRange);

                //Verify 6 default rules
                var getDefaultSecurityRule1 = viewNSGRules.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.DefaultSecurityRules.Where(x => x.Name == "AllowVnetInBound");
               Assert.Equal("*", getDefaultSecurityRule1.FirstOrDefault().Protocol);
               Assert.Equal(65000, getDefaultSecurityRule1.FirstOrDefault().Priority);
               Assert.Equal("Allow", getDefaultSecurityRule1.FirstOrDefault().Access);
               Assert.Equal("Inbound", getDefaultSecurityRule1.FirstOrDefault().Direction);
               Assert.Equal("VirtualNetwork", getDefaultSecurityRule1.FirstOrDefault().DestinationAddressPrefix);
               Assert.Equal("*", getDefaultSecurityRule1.FirstOrDefault().DestinationPortRange);
               Assert.Equal("VirtualNetwork", getDefaultSecurityRule1.FirstOrDefault().SourceAddressPrefix);
               Assert.Equal("*", getDefaultSecurityRule1.FirstOrDefault().SourcePortRange);

               var getDefaultSecurityRule2 = viewNSGRules.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.DefaultSecurityRules.Where(x => x.Name == "AllowAzureLoadBalancerInBound");
               Assert.Equal("*", getDefaultSecurityRule2.FirstOrDefault().Protocol);
               Assert.Equal(65001, getDefaultSecurityRule2.FirstOrDefault().Priority);
               Assert.Equal("Allow", getDefaultSecurityRule2.FirstOrDefault().Access);
               Assert.Equal("Inbound", getDefaultSecurityRule2.FirstOrDefault().Direction);
               Assert.Equal("*", getDefaultSecurityRule2.FirstOrDefault().DestinationAddressPrefix);
               Assert.Equal("*", getDefaultSecurityRule2.FirstOrDefault().DestinationPortRange);
               Assert.Equal("AzureLoadBalancer", getDefaultSecurityRule2.FirstOrDefault().SourceAddressPrefix);
               Assert.Equal("*", getDefaultSecurityRule2.FirstOrDefault().SourcePortRange);

               var getDefaultSecurityRule3 = viewNSGRules.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.DefaultSecurityRules.Where(x => x.Name == "DenyAllInBound");
               Assert.Equal("*", getDefaultSecurityRule3.FirstOrDefault().Protocol);
               Assert.Equal(65500, getDefaultSecurityRule3.FirstOrDefault().Priority);
               Assert.Equal("Deny", getDefaultSecurityRule3.FirstOrDefault().Access);
               Assert.Equal("Inbound", getDefaultSecurityRule3.FirstOrDefault().Direction);
               Assert.Equal("*", getDefaultSecurityRule3.FirstOrDefault().DestinationAddressPrefix);
                Assert.Equal("*", getDefaultSecurityRule3.FirstOrDefault().DestinationPortRange);
                Assert.Equal("*", getDefaultSecurityRule3.FirstOrDefault().SourceAddressPrefix);
                Assert.Equal("*", getDefaultSecurityRule3.FirstOrDefault().SourcePortRange);

                var getDefaultSecurityRule4 = viewNSGRules.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.DefaultSecurityRules.Where(x => x.Name == "AllowVnetOutBound");
                Assert.Equal("*", getDefaultSecurityRule4.FirstOrDefault().Protocol);
                Assert.Equal(65000, getDefaultSecurityRule4.FirstOrDefault().Priority);
                Assert.Equal("Allow", getDefaultSecurityRule4.FirstOrDefault().Access);
                Assert.Equal("Outbound", getDefaultSecurityRule4.FirstOrDefault().Direction);
                Assert.Equal("VirtualNetwork", getDefaultSecurityRule4.FirstOrDefault().DestinationAddressPrefix);
                Assert.Equal("*", getDefaultSecurityRule4.FirstOrDefault().DestinationPortRange);
                Assert.Equal("VirtualNetwork", getDefaultSecurityRule4.FirstOrDefault().SourceAddressPrefix);
                Assert.Equal("*", getDefaultSecurityRule4.FirstOrDefault().SourcePortRange);

                var getDefaultSecurityRule5 = viewNSGRules.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.DefaultSecurityRules.Where(x => x.Name == "AllowInternetOutBound");
                Assert.Equal("*", getDefaultSecurityRule5.FirstOrDefault().Protocol);
                Assert.Equal(65001, getDefaultSecurityRule5.FirstOrDefault().Priority);
                Assert.Equal("Allow", getDefaultSecurityRule5.FirstOrDefault().Access);
                Assert.Equal("Outbound", getDefaultSecurityRule5.FirstOrDefault().Direction);
                Assert.Equal("Internet", getDefaultSecurityRule5.FirstOrDefault().DestinationAddressPrefix);
                Assert.Equal("*", getDefaultSecurityRule5.FirstOrDefault().DestinationPortRange);
                Assert.Equal("*", getDefaultSecurityRule5.FirstOrDefault().SourceAddressPrefix);
                Assert.Equal("*", getDefaultSecurityRule5.FirstOrDefault().SourcePortRange);

                var getDefaultSecurityRule6 = viewNSGRules.NetworkInterfaces.FirstOrDefault().SecurityRuleAssociations.DefaultSecurityRules.Where(x => x.Name == "DenyAllOutBound");
                Assert.Equal("*", getDefaultSecurityRule6.FirstOrDefault().Protocol);
                Assert.Equal(65500, getDefaultSecurityRule6.FirstOrDefault().Priority);
                Assert.Equal("Deny", getDefaultSecurityRule6.FirstOrDefault().Access);
                Assert.Equal("Outbound", getDefaultSecurityRule6.FirstOrDefault().Direction);
                Assert.Equal("*", getDefaultSecurityRule6.FirstOrDefault().DestinationAddressPrefix);
                Assert.Equal("*", getDefaultSecurityRule6.FirstOrDefault().DestinationPortRange);
                Assert.Equal("*", getDefaultSecurityRule6.FirstOrDefault().SourceAddressPrefix);
                Assert.Equal("*", getDefaultSecurityRule6.FirstOrDefault().SourcePortRange);
            }
        }
    }
}


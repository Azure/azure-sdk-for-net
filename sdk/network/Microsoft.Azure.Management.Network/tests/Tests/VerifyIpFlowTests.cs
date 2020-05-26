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

    public class VerifyIpFlowTests
    {
        [Fact(Skip="Disable tests")]
        public void VerifyIpFlowApiTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);
                var computeManagementClient = NetworkManagementTestUtilities.GetComputeManagementClientWithHandler(context, handler3);

                string location = "eastus";

                string resourceGroupName = TestUtilities.GenerateName();
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                string virtualMachineName1 = TestUtilities.GenerateName();
                string networkInterfaceName1 = TestUtilities.GenerateName();
                string networkSecurityGroupName = virtualMachineName1 + "-nsg";

                //Deploy VM with a template
                Deployments.CreateVm(
                    resourcesClient: resourcesClient,
                    resourceGroupName: resourceGroupName,
                    location: location,
                    virtualMachineName: virtualMachineName1,
                    storageAccountName: TestUtilities.GenerateName(),
                    networkInterfaceName: networkInterfaceName1,
                    networkSecurityGroupName: networkSecurityGroupName,
                    diagnosticsStorageAccountName: TestUtilities.GenerateName(),
                    deploymentName: TestUtilities.GenerateName()
                    );

                string networkWatcherName = TestUtilities.GenerateName();
                NetworkWatcher properties = new NetworkWatcher();
                properties.Location = location;

                //Create network Watcher
                var createNetworkWatcher = networkManagementClient.NetworkWatchers.CreateOrUpdate(resourceGroupName, networkWatcherName, properties);

                var getVm1 = computeManagementClient.VirtualMachines.Get(resourceGroupName, virtualMachineName1);
                string localIPAddress = networkManagementClient.NetworkInterfaces.Get(resourceGroupName, networkInterfaceName1).IpConfigurations.FirstOrDefault().PrivateIPAddress;


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

                VerificationIPFlowParameters ipFlowProperties = new VerificationIPFlowParameters()
                {
                    TargetResourceId = getVm1.Id,
                    Direction = "Outbound",
                    Protocol = "TCP",
                    LocalPort = "80",
                    RemotePort = "80",
                    LocalIPAddress = localIPAddress,
                    RemoteIPAddress = "12.11.12.14"
                };

                //Verify IP flow from a VM to a location given the configured  rule
                var verifyIpFlow = networkManagementClient.NetworkWatchers.VerifyIPFlow(resourceGroupName, networkWatcherName, ipFlowProperties);

                //Verify validity of the result
                Assert.Equal("Deny", verifyIpFlow.Access);
                Assert.Equal("securityRules/" + securityRule1, verifyIpFlow.RuleName);
            }
        }
    }
}


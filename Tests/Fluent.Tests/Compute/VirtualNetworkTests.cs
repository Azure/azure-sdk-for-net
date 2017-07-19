// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Fluent.Tests.Common;
using Xunit;

namespace Fluent.Tests.Compute
{
    public class VirtualNetwork
    {
        /**
         * Main entry point.
         * @param args the parameters
         */
        // TODO - ans - Does not look like a test. Check with Author and see.
        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void UnfinishedTest()
        {
            string vnetName1 = SdkContext.RandomResourceName("vnet1", 20);
            string vnetName2 = SdkContext.RandomResourceName("vnet2", 20);
            string vnet1FrontEndSubnetName = "frontend";
            string vnet1BackEndSubnetName = "backend";
            string vnet1FrontEndSubnetNsgName = "frontendnsg";
            string vnet1BackEndSubnetNsgName = "backendnsg";
            string frontEndVMName = SdkContext.RandomResourceName("fevm", 24);
            string backEndVMName = SdkContext.RandomResourceName("bevm", 24);
            string publicIPAddressLeafDNSForFrontEndVM = SdkContext.RandomResourceName("pip1", 24);

            INetworkManager manager = TestHelper.CreateNetworkManager();

            string rgName = SdkContext.RandomResourceName("rgNEMV", 24);
            INetworkSecurityGroup backEndSubnetNsg = manager.NetworkSecurityGroups
                    .Define(vnet1BackEndSubnetNsgName)
                    .WithRegion(Region.USEast)
                    .WithExistingResourceGroup(rgName)
                    .DefineRule("DenyInternetInComing")
                        .DenyInbound()
                        .FromAddress("INTERNET")
                        .FromAnyPort()
                        .ToAnyAddress()
                        .ToAnyPort()
                        .WithAnyProtocol()
                        .Attach()
                    .DefineRule("DenyInternetOutGoing")
                        .DenyOutbound()
                        .FromAnyAddress()
                        .FromAnyPort()
                        .ToAddress("INTERNET")
                        .ToAnyPort()
                        .WithAnyProtocol()
                        .Attach()
                    .Create();

            INetwork virtualNetwork1 = manager.Networks
                    .Define(vnetName1)
                    .WithRegion(Region.USEast)
                    .WithExistingResourceGroup(rgName)
                    .WithAddressSpace("192.168.0.0/16")
                    .WithSubnet(vnet1FrontEndSubnetName, "192.168.1.0/24")
                    .DefineSubnet(vnet1BackEndSubnetName)
                        .WithAddressPrefix("192.168.2.0/24")
                        .WithExistingNetworkSecurityGroup(backEndSubnetNsg)
                        .Attach()
                    .Create();

            INetworkSecurityGroup frontEndSubnetNsg = manager.NetworkSecurityGroups
                    .Define(vnet1FrontEndSubnetNsgName)
                    .WithRegion(Region.USEast)
                    .WithExistingResourceGroup(rgName)
                    .DefineRule("AllowHttpInComing")
                        .AllowInbound()
                        .FromAddress("INTERNET")
                        .FromAnyPort()
                        .ToAnyAddress()
                        .ToPort(80)
                        .WithProtocol(SecurityRuleProtocol.Tcp)
                        .Attach()
                    .DefineRule("DenyInternetOutGoing")
                        .DenyOutbound()
                        .FromAnyAddress()
                        .FromAnyPort()
                        .ToAddress("INTERNET")
                        .ToAnyPort()
                        .WithAnyProtocol()
                        .Attach()
                    .Create();

            virtualNetwork1.Update()
                    .UpdateSubnet(vnet1FrontEndSubnetName)
                        .WithExistingNetworkSecurityGroup(frontEndSubnetNsg)
                        .Parent()
                    .Apply();

            INetwork virtualNetwork2 = manager.Networks
                    .Define(vnetName2)
                    .WithRegion(Region.USEast)
                    .WithNewResourceGroup(rgName)
                    .Create();


            foreach (INetwork virtualNetwork in manager.Networks.ListByResourceGroup(rgName))
            {
            }


            manager.Networks.DeleteById(virtualNetwork2.Id);
        }
    }
}

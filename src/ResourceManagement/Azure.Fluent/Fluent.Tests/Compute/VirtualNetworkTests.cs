// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Fluent.Tests.Common;
using Xunit;

namespace Fluent.Tests.Compute
{
    public class ManageVirtualNetwork
    {
        /**
         * Main entry point.
         * @param args the parameters
         */
        // TODO - ans - Does not look like a test. Check with Author and see.
        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void Test()
        {
            string vnetName1 = SharedSettings.RandomResourceName("vnet1", 20);
            string vnetName2 = SharedSettings.RandomResourceName("vnet2", 20);
            string vnet1FrontEndSubnetName = "frontend";
            string vnet1BackEndSubnetName = "backend";
            string vnet1FrontEndSubnetNsgName = "frontendnsg";
            string vnet1BackEndSubnetNsgName = "backendnsg";
            string frontEndVMName = SharedSettings.RandomResourceName("fevm", 24);
            string backEndVMName = SharedSettings.RandomResourceName("bevm", 24);
            string publicIpAddressLeafDNSForFrontEndVM = SharedSettings.RandomResourceName("pip1", 24);

            INetworkManager manager = TestHelper.CreateNetworkManager();

            string rgName = SharedSettings.RandomResourceName("rgNEMV", 24);
            INetworkSecurityGroup backEndSubnetNsg = manager.NetworkSecurityGroups
                    .Define(vnet1BackEndSubnetNsgName)
                    .WithRegion(Region.US_EAST)
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
                    .WithRegion(Region.US_EAST)
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
                    .WithRegion(Region.US_EAST)
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
                    .WithRegion(Region.US_EAST)
                    .WithNewResourceGroup(rgName)
                    .Create();


            foreach (INetwork virtualNetwork in manager.Networks.ListByGroup(rgName))
            {
            }


            manager.Networks.DeleteById(virtualNetwork2.Id);
        }
    }
}

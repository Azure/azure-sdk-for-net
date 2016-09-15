
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.V2.Network;
using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.V2.Resource.Authentication;
using Microsoft.Azure.Management.V2.Resource.Core;
/**
*
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for license information.
*
*/
namespace Azure.Tests
{

    public class ManageVirtualNetwork {

        /**
         * Main entry point.
         * @param args the parameters
         */
        public void Test() {
            string vnetName1 = ResourceNamer.RandomResourceName("vnet1", 20);
            string vnetName2 = ResourceNamer.RandomResourceName("vnet2", 20);
            string vnet1FrontEndSubnetName = "frontend";
            string vnet1BackEndSubnetName = "backend";
            string vnet1FrontEndSubnetNsgName = "frontendnsg";
            string vnet1BackEndSubnetNsgName = "backendnsg";
            string frontEndVMName = ResourceNamer.RandomResourceName("fevm", 24);
            string backEndVMName = ResourceNamer.RandomResourceName("bevm", 24);
            string publicIpAddressLeafDNSForFrontEndVM = ResourceNamer.RandomResourceName("pip1", 24);

            INetworkManager manager = this.CreateNetworkManager();

            string rgName = ResourceNamer.RandomResourceName("rgNEMV", 24);
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


            foreach (INetwork virtualNetwork in manager.Networks.ListByGroup(rgName)) {
            }


            manager.Networks.Delete(virtualNetwork2.Id);
        }

        public INetworkManager CreateNetworkManager()
        {
            ApplicationTokenCredentials credentials = new ApplicationTokenCredentials(@"C:\my.azureauth");
            return NetworkManager
                .Configure()
                .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);
        }
    }
}
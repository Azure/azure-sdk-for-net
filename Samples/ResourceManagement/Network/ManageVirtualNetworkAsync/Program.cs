// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Threading.Tasks;

namespace ManageVirtualNetworkAsync
{
    public class Program
    {
        private static readonly string VNet1FrontEndSubnetName = "frontend";
        private static readonly string VNet1BackEndSubnetName = "backend";
        private static readonly string VNet1FrontEndSubnetNsgName = "frontendnsg";
        private static readonly string VNet1BackEndSubnetNsgName = "backendnsg";
        private static readonly string UserName = "tirekicker";
        private static readonly string SshKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQCfSPC2K7LZcFKEO+/t3dzmQYtrJFZNxOsbVgOVKietqHyvmYGHEC0J2wPdAqQ/63g/hhAEFRoyehM+rbeDri4txB3YFfnOK58jqdkyXzupWqXzOrlKY4Wz9SKjjN765+dqUITjKRIaAip1Ri137szRg71WnrmdP3SphTRlCx1Bk2nXqWPsclbRDCiZeF8QOTi4JqbmJyK5+0UqhqYRduun8ylAwKKQJ1NJt85sYIHn9f1Rfr6Tq2zS0wZ7DHbZL+zB5rSlAr8QyUdg/GQD+cmSs6LvPJKL78d6hMGk84ARtFo4A79ovwX/Fj01znDQkU6nJildfkaolH2rWFG/qttD azjava@javalib.Com";
        private static readonly string ResourceGroupName = SdkContext.RandomResourceName("rgNEMV", 24);

        /**
        * Azure Network sample for managing virtual networks.
        *  - Create a virtual network with Subnets
        *  - Update a virtual network
        *  - Create virtual machines in the virtual network subnets
        *  - Create another virtual network
        *  - List virtual networks
        */
        public async static Task RunSampleAsync(IAzure azure)
        {
            string vnetName1 = SdkContext.RandomResourceName("vnet1", 20);
            string vnetName2 = SdkContext.RandomResourceName("vnet2", 20);
            string frontEndVmName = SdkContext.RandomResourceName("fevm", 24);
            string backEndVmName = SdkContext.RandomResourceName("bevm", 24);
            string publicIpAddressLeafDnsForFrontEndVm = SdkContext.RandomResourceName("pip1", 24);
            
            try
            {
                //============================================================
                // Create a virtual network with specific address-space and two subnet

                // Creates a network security group for backend subnet

                Utilities.Log("Creating a network security group for virtual network backend subnet...");
                Utilities.Log("Creating a network security group for virtual network frontend subnet...");
                
                var backEndSubnetNsg = await azure.NetworkSecurityGroups
                        .Define(VNet1BackEndSubnetNsgName)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(ResourceGroupName)
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
                        .CreateAsync();
                
                Utilities.Log("Created network security group");
                // Print the network security group
                Utilities.PrintNetworkSecurityGroup(backEndSubnetNsg);

                var frontEndSubnetNsg = await azure.NetworkSecurityGroups.Define(VNet1FrontEndSubnetNsgName)
                    .WithRegion(Region.USEast)
                    .WithExistingResourceGroup(ResourceGroupName)
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
                    .CreateAsync();

                Utilities.Log("Created network security group");
                // Print the network security group
                Utilities.PrintNetworkSecurityGroup(frontEndSubnetNsg);
                
                Utilities.Log("Creating virtual network #1...");

                INetwork virtualNetwork1 = await azure.Networks.Define(vnetName1)
                                .WithRegion(Region.USEast)
                                .WithExistingResourceGroup(ResourceGroupName)
                                .WithAddressSpace("192.168.0.0/16")
                                .WithSubnet(VNet1FrontEndSubnetName, "192.168.1.0/24")
                                .DefineSubnet(VNet1BackEndSubnetName)
                                    .WithAddressPrefix("192.168.2.0/24")
                                    .WithExistingNetworkSecurityGroup(backEndSubnetNsg)
                                    .Attach()
                                .CreateAsync();

                Utilities.Log("Created a virtual network");
                // Print the virtual network details
                Utilities.PrintVirtualNetwork(virtualNetwork1);

                //============================================================
                // Update a virtual network
                
                // Update the virtual network frontend subnet by associating it with network security group
                
                Utilities.Log("Associating network security group rule to frontend subnet");

                await virtualNetwork1.Update()
                        .UpdateSubnet(VNet1FrontEndSubnetName)
                            .WithExistingNetworkSecurityGroup(frontEndSubnetNsg)
                            .Parent()
                        .ApplyAsync();

                Utilities.Log("Network security group rule associated with the frontend subnet");
                // Print the virtual network details
                Utilities.PrintVirtualNetwork(virtualNetwork1);

                //============================================================
                // Create a virtual machine in each subnet

                // Creates the first virtual machine in frontend subnet
                Utilities.Log("Creating a Linux virtual machine in the frontend subnet");
                // Creates the second virtual machine in the backend subnet
                Utilities.Log("Creating a Linux virtual machine in the backend subnet");
                // Create a virtual network with default address-space and one default subnet
                Utilities.Log("Creating virtual network #2...");

                var t1 = DateTime.UtcNow;

                var frontEndVM = await azure.VirtualMachines.Define(frontEndVmName)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(ResourceGroupName)
                        .WithExistingPrimaryNetwork(virtualNetwork1)
                        .WithSubnet(VNet1FrontEndSubnetName)
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithNewPrimaryPublicIPAddress(publicIpAddressLeafDnsForFrontEndVm)
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(UserName)
                        .WithSsh(SshKey)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .CreateAsync();
                var t2 = DateTime.UtcNow;
                Utilities.Log("Created Linux VM: (took "
                    + (t2 - t1).TotalSeconds + " seconds) " + frontEndVM);
                // Print virtual machine details
                Utilities.PrintVirtualMachine(frontEndVM);
                t1 = DateTime.UtcNow;

                var backEndVM = await azure.VirtualMachines.Define(backEndVmName)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(ResourceGroupName)
                        .WithExistingPrimaryNetwork(virtualNetwork1)
                        .WithSubnet(VNet1BackEndSubnetName)
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(UserName)
                        .WithSsh(SshKey)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .CreateAsync();

                var t3 = DateTime.UtcNow;
                Utilities.Log("Created Linux VM: (took "
                        + (t3 - t1).TotalSeconds + " seconds) " + backEndVM.Id);
                // Print virtual machine details
                Utilities.PrintVirtualMachine(backEndVM);

                var virtualNetwork2 = await azure.Networks.Define(vnetName2)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(ResourceGroupName)
                        .CreateAsync();

                Utilities.Log("Created a virtual network");
                // Print the virtual network details
                Utilities.PrintVirtualNetwork(virtualNetwork2);
                
                //============================================================
                // List virtual networks
                
                foreach (var virtualNetwork in await azure.Networks.ListByResourceGroupAsync(ResourceGroupName))
                {
                    Utilities.PrintVirtualNetwork(virtualNetwork);
                }

                //============================================================
                // Delete a virtual network
                Utilities.Log("Deleting the virtual network");
                await azure.Networks.DeleteByIdAsync(virtualNetwork2.Id);
                Utilities.Log("Deleted the virtual network");
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + ResourceGroupName);
                    await azure.ResourceGroups.DeleteByNameAsync(ResourceGroupName);
                    Utilities.Log("Deleted Resource Group: " + ResourceGroupName);
                }
                catch (NullReferenceException)
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
                }
                catch (Exception ex)
                {
                    Utilities.Log(ex);
                }
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                var credentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure.Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Utilities.Log("Selected subscription: " + azure.SubscriptionId);

                RunSampleAsync(azure).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
            }
        }
    }
}
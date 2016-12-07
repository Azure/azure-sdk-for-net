// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManageVirtualNetwork
{
    /**
     * Azure Network sample for managing virtual networks -
     *  - Create a virtual network with Subnets
     *  - Update a virtual network
     *  - Create virtual machines in the virtual network subnets
     *  - Create another virtual network
     *  - List virtual networks
     *  - Delete a virtual network.
     */

    public class Program
    {
        private static readonly string vnetName1 = ResourceNamer.RandomResourceName("vnet1", 20);
        private static readonly string vnetName2 = ResourceNamer.RandomResourceName("vnet2", 20);
        private static readonly string vnet1FrontEndSubnetName = "frontend";
        private static readonly string vnet1BackEndSubnetName = "backend";
        private static readonly string vnet1FrontEndSubnetNsgName = "frontendnsg";
        private static readonly string vnet1BackEndSubnetNsgName = "backendnsg";
        private static readonly string frontEndVmName = ResourceNamer.RandomResourceName("fevm", 24);
        private static readonly string backEndVmName = ResourceNamer.RandomResourceName("bevm", 24);
        private static readonly string publicIpAddressLeafDnsForFrontEndVm = ResourceNamer.RandomResourceName("pip1", 24);
        private static readonly string userName = "tirekicker";
        private static readonly string sshKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQCfSPC2K7LZcFKEO+/t3dzmQYtrJFZNxOsbVgOVKietqHyvmYGHEC0J2wPdAqQ/63g/hhAEFRoyehM+rbeDri4txB3YFfnOK58jqdkyXzupWqXzOrlKY4Wz9SKjjN765+dqUITjKRIaAip1Ri137szRg71WnrmdP3SphTRlCx1Bk2nXqWPsclbRDCiZeF8QOTi4JqbmJyK5+0UqhqYRduun8ylAwKKQJ1NJt85sYIHn9f1Rfr6Tq2zS0wZ7DHbZL+zB5rSlAr8QyUdg/GQD+cmSs6LvPJKL78d6hMGk84ARtFo4A79ovwX/Fj01znDQkU6nJildfkaolH2rWFG/qttD azjava@javalib.Com";
        private static readonly string rgName = ResourceNamer.RandomResourceName("rgNEMV", 24);

        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                var credentials = AzureCredentials.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.BASIC)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Console.WriteLine("Selected subscription: " + azure.SubscriptionId);

                try
                {
                    //============================================================
                    // Create a virtual network with specific address-space and two subnet

                    // Creates a network security group for backend subnet

                    Console.WriteLine("Creating a network security group for virtual network backend subnet...");

                    var backEndSubnetNsg = azure.NetworkSecurityGroups
                            .Define(vnet1BackEndSubnetNsgName)
                            .WithRegion(Region.US_EAST)
                            .WithNewResourceGroup(rgName)
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

                    Console.WriteLine("Created network security group");
                    // Print the network security group
                    Utilities.PrintNetworkSecurityGroup(backEndSubnetNsg);

                    // Create the virtual network with frontend and backend subnets, with
                    // network security group rule applied to backend subnet]

                    Console.WriteLine("Creating virtual network #1...");

                    var virtualNetwork1 = azure.Networks
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

                    Console.WriteLine("Created a virtual network");
                    // Print the virtual network details
                    Utilities.PrintVirtualNetwork(virtualNetwork1);

                    //============================================================
                    // Update a virtual network

                    // Creates a network security group for frontend subnet

                    Console.WriteLine("Creating a network security group for virtual network backend subnet...");

                    var frontEndSubnetNsg = azure.NetworkSecurityGroups
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

                    Console.WriteLine("Created network security group");
                    // Print the network security group
                    Utilities.PrintNetworkSecurityGroup(frontEndSubnetNsg);

                    // Update the virtual network frontend subnet by associating it with network security group

                    Console.WriteLine("Associating network security group rule to frontend subnet");

                    virtualNetwork1.Update()
                            .UpdateSubnet(vnet1FrontEndSubnetName)
                                .WithExistingNetworkSecurityGroup(frontEndSubnetNsg)
                                .Parent()
                            .Apply();

                    Console.WriteLine("Network security group rule associated with the frontend subnet");
                    // Print the virtual network details
                    Utilities.PrintVirtualNetwork(virtualNetwork1);

                    //============================================================
                    // Create a virtual machine in each subnet

                    // Creates the first virtual machine in frontend subnet

                    Console.WriteLine("Creating a Linux virtual machine in the frontend subnet");

                    var t1 = DateTime.UtcNow;

                    var frontEndVM = azure.VirtualMachines.Define(frontEndVmName)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .WithExistingPrimaryNetwork(virtualNetwork1)
                            .WithSubnet(vnet1FrontEndSubnetName)
                            .WithPrimaryPrivateIpAddressDynamic()
                            .WithNewPrimaryPublicIpAddress(publicIpAddressLeafDnsForFrontEndVm)
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_16_04_LTS)
                            .WithRootUsername(userName)
                            .WithSsh(sshKey)
                            .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                            .Create();

                    var t2 = DateTime.UtcNow;
                    Console.WriteLine("Created Linux VM: (took "
                            + (t2 - t1).TotalSeconds + " seconds) " + frontEndVM.Id);
                    // Print virtual machine details
                    Utilities.PrintVirtualMachine(frontEndVM);

                    // Creates the second virtual machine in the backend subnet

                    Console.WriteLine("Creating a Linux virtual machine in the backend subnet");

                    var t3 = DateTime.UtcNow;

                    var backEndVM = azure.VirtualMachines.Define(backEndVmName)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .WithExistingPrimaryNetwork(virtualNetwork1)
                            .WithSubnet(vnet1BackEndSubnetName)
                            .WithPrimaryPrivateIpAddressDynamic()
                            .WithoutPrimaryPublicIpAddress()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_16_04_LTS)
                            .WithRootUsername(userName)
                            .WithSsh(sshKey)
                            .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                            .Create();

                    var t4 = DateTime.UtcNow;
                    Console.WriteLine("Created Linux VM: (took "
                            + (t4 - t3).TotalSeconds + " seconds) " + backEndVM.Id);
                    // Print virtual machine details
                    Utilities.PrintVirtualMachine(backEndVM);

                    //============================================================
                    // Create a virtual network with default address-space and one default subnet

                    Console.WriteLine("Creating virtual network #2...");

                    var virtualNetwork2 = azure.Networks
                            .Define(vnetName2)
                            .WithRegion(Region.US_EAST)
                            .WithNewResourceGroup(rgName)
                            .Create();

                    Console.WriteLine("Created a virtual network");
                    // Print the virtual network details
                    Utilities.PrintVirtualNetwork(virtualNetwork2);

                    //============================================================
                    // List virtual networks

                    foreach (var virtualNetwork in azure.Networks.ListByGroup(rgName))
                    {
                        Utilities.PrintVirtualNetwork(virtualNetwork);
                    }

                    //============================================================
                    // Delete a virtual network
                    Console.WriteLine("Deleting the virtual network");
                    azure.Networks.DeleteById(virtualNetwork2.Id);
                    Console.WriteLine("Deleted the virtual network");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    try
                    {
                        Console.WriteLine("Deleting Resource Group: " + rgName);
                        azure.ResourceGroups.DeleteByName(rgName);
                        Console.WriteLine("Deleted Resource Group: " + rgName);
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("Did not create any resources in Azure. No clean up is necessary");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
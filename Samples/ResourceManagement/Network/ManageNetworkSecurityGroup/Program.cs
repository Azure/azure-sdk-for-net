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

namespace ManageNetworkSecurityGroup
{
    /**
     * Azure Network sample for managing network security groups -
     *  - Create a network security group for the front end of a subnet
     *  - Create a network security group for the back end of a subnet
     *  - Create Linux virtual machines for the front end and back end
     *  -- Apply network security groups
     *  - List network security groups
     *  - Update a network security group.
     */

    public class Program
    {
        private static readonly string frontEndNSGName = ResourceNamer.RandomResourceName("fensg", 24);
        private static readonly string backEndNSGName = ResourceNamer.RandomResourceName("bensg", 24);
        private static readonly string rgName = ResourceNamer.RandomResourceName("rgNEMS", 24);
        private static readonly string vnetName = ResourceNamer.RandomResourceName("vnet", 24);
        private static readonly string networkInterfaceName1 = ResourceNamer.RandomResourceName("nic1", 24);
        private static readonly string networkInterfaceName2 = ResourceNamer.RandomResourceName("nic2", 24);
        private static readonly string publicIpAddressLeafDNS1 = ResourceNamer.RandomResourceName("pip1", 24);
        private static readonly string frontEndVMName = ResourceNamer.RandomResourceName("fevm", 24);
        private static readonly string backEndVMName = ResourceNamer.RandomResourceName("bevm", 24);
        private static readonly string userName = "tirekicker";
        private static readonly string password = "12NewPA$$w0rd!";
        private static readonly string sshKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQCfSPC2K7LZcFKEO+/t3dzmQYtrJFZNxOsbVgOVKietqHyvmYGHEC0J2wPdAqQ/63g/hhAEFRoyehM+rbeDri4txB3YFfnOK58jqdkyXzupWqXzOrlKY4Wz9SKjjN765+dqUITjKRIaAip1Ri137szRg71WnrmdP3SphTRlCx1Bk2nXqWPsclbRDCiZeF8QOTi4JqbmJyK5+0UqhqYRduun8ylAwKKQJ1NJt85sYIHn9f1Rfr6Tq2zS0wZ7DHbZL+zB5rSlAr8QyUdg/GQD+cmSs6LvPJKL78d6hMGk84ARtFo4A79ovwX/Fj01znDQkU6nJildfkaolH2rWFG/qttD azjava@javalib.Com";

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
                    // Define a virtual network for VMs in this availability set

                    Console.WriteLine("Creating a virtual network ...");

                    var network = azure.Networks
                            .Define(vnetName)
                            .WithRegion(Region.US_EAST)
                            .WithNewResourceGroup(rgName)
                            .WithAddressSpace("172.16.0.0/16")
                            .DefineSubnet("Front-end")
                                .WithAddressPrefix("172.16.1.0/24")
                                .Attach()
                            .DefineSubnet("Back-end")
                                .WithAddressPrefix("172.16.2.0/24")
                                .Attach()
                            .Create();

                    Console.WriteLine("Created a virtual network: " + network.Id);
                    Utilities.PrintVirtualNetwork(network);

                    //============================================================
                    // Create a network security group for the front end of a subnet
                    // front end subnet contains two rules
                    // - ALLOW-SSH - allows SSH traffic into the front end subnet
                    // - ALLOW-WEB- allows HTTP traffic into the front end subnet

                    Console.WriteLine("Creating a security group for the front end - allows SSH and HTTP");
                    var frontEndNSG = azure.NetworkSecurityGroups.Define(frontEndNSGName)
                            .WithRegion(Region.US_EAST)
                            .WithNewResourceGroup(rgName)
                            .DefineRule("ALLOW-SSH")
                                .AllowInbound()
                                .FromAnyAddress()
                                .FromAnyPort()
                                .ToAnyAddress()
                                .ToPort(22)
                                .WithProtocol(SecurityRuleProtocol.Tcp)
                                .WithPriority(100)
                                .WithDescription("Allow SSH")
                                .Attach()
                            .DefineRule("ALLOW-HTTP")
                                .AllowInbound()
                                .FromAnyAddress()
                                .FromAnyPort()
                                .ToAnyAddress()
                                .ToPort(80)
                                .WithProtocol(SecurityRuleProtocol.Tcp)
                                .WithPriority(101)
                                .WithDescription("Allow HTTP")
                                .Attach()
                            .Create();

                    Console.WriteLine("Created a security group for the front end: " + frontEndNSG.Id);
                    Utilities.PrintNetworkSecurityGroup(frontEndNSG);

                    //============================================================
                    // Create a network security group for the back end of a subnet
                    // back end subnet contains two rules
                    // - ALLOW-SQL - allows SQL traffic only from the front end subnet
                    // - DENY-WEB - denies all outbound internet traffic from the back end subnet

                    Console.WriteLine("Creating a security group for the front end - allows SSH and "
                            + "denies all outbound internet traffic  ");

                    var backEndNSG = azure.NetworkSecurityGroups.Define(backEndNSGName)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .DefineRule("ALLOW-SQL")
                                .AllowInbound()
                                .FromAddress("172.16.1.0/24")
                                .FromAnyPort()
                                .ToAnyAddress()
                                .ToPort(1433)
                                .WithProtocol(SecurityRuleProtocol.Tcp)
                                .WithPriority(100)
                                .WithDescription("Allow SQL")
                                .Attach()
                            .DefineRule("DENY-WEB")
                                .DenyOutbound()
                                .FromAnyAddress()
                                .FromAnyPort()
                                .ToAnyAddress()
                                .ToAnyPort()
                                .WithAnyProtocol()
                                .WithDescription("Deny Web")
                                .WithPriority(200)
                                .Attach()
                            .Create();

                    Console.WriteLine("Created a security group for the back end: " + backEndNSG.Id);
                    Utilities.PrintNetworkSecurityGroup(backEndNSG);

                    Console.WriteLine("Creating multiple network interfaces");
                    Console.WriteLine("Creating network interface 1");

                    //========================================================
                    // Create a network interface and apply the
                    // front end network security group

                    Console.WriteLine("Creating a network interface for the front end");

                    var networkInterface1 = azure.NetworkInterfaces.Define(networkInterfaceName1)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .WithExistingPrimaryNetwork(network)
                            .WithSubnet("Front-end")
                            .WithPrimaryPrivateIpAddressDynamic()
                            .WithNewPrimaryPublicIpAddress(publicIpAddressLeafDNS1)
                            .WithIpForwarding()
                            .WithExistingNetworkSecurityGroup(frontEndNSG)
                            .Create();

                    Console.WriteLine("Created network interface for the front end");

                    Utilities.PrintNetworkInterface(networkInterface1);

                    //========================================================
                    // Create a network interface and apply the
                    // back end network security group

                    Console.WriteLine("Creating a network interface for the back end");

                    var networkInterface2 = azure.NetworkInterfaces.Define(networkInterfaceName2)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .WithExistingPrimaryNetwork(network)
                            .WithSubnet("Back-end")
                            .WithPrimaryPrivateIpAddressDynamic()
                            .WithExistingNetworkSecurityGroup(backEndNSG)
                            .Create();

                    Utilities.PrintNetworkInterface(networkInterface2);

                    //=============================================================
                    // Create a virtual machine (for the front end)
                    // with the network interface that has the network security group for the front end

                    Console.WriteLine("Creating a Linux virtual machine (for the front end) - "
                            + "with the network interface that has the network security group for the front end");

                    var t1 = DateTime.UtcNow;

                    var frontEndVM = azure.VirtualMachines.Define(frontEndVMName)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .WithExistingPrimaryNetworkInterface(networkInterface1)
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

                    //=============================================================
                    // Create a virtual machine (for the back end)
                    // with the network interface that has the network security group for the back end

                    Console.WriteLine("Creating a Linux virtual machine (for the back end) - "
                            + "with the network interface that has the network security group for the back end");

                    t1 = DateTime.UtcNow;

                    var backEndVM = azure.VirtualMachines.Define(backEndVMName)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .WithExistingPrimaryNetworkInterface(networkInterface2)
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_16_04_LTS)
                            .WithRootUsername(userName)
                            .WithSsh(sshKey)
                            .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                            .Create();

                    t2 = DateTime.UtcNow;
                    Console.WriteLine("Created a Linux VM: (took "
                            + (t2 - t1).TotalSeconds + " seconds) " + backEndVM.Id);
                    Utilities.PrintVirtualMachine(backEndVM);

                    //========================================================
                    // List network security groups

                    Console.WriteLine("Walking through network security groups");
                    var networkSecurityGroups = azure.NetworkSecurityGroups.ListByGroup(rgName);

                    foreach (var networkSecurityGroup in networkSecurityGroups)
                    {
                        Utilities.PrintNetworkSecurityGroup(networkSecurityGroup);
                    }

                    //========================================================
                    // Update a network security group

                    Console.WriteLine("Updating the front end network security group to allow FTP");

                    frontEndNSG.Update()
                            .DefineRule("ALLOW-FTP")
                                .AllowInbound()
                                .FromAnyAddress()
                                .FromAnyPort()
                                .ToAnyAddress()
                                .ToPortRange(20, 21)
                                .WithProtocol(SecurityRuleProtocol.Tcp)
                                .WithDescription("Allow FTP")
                                .WithPriority(200)
                                .Attach()
                            .Apply();

                    Console.WriteLine("Updated the front end network security group");
                    Utilities.PrintNetworkSecurityGroup(frontEndNSG);
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
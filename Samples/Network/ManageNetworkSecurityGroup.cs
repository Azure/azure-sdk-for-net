// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManageNetworkSecurityGroup
{

    public class Program
    {
        private static readonly string UserName = "tirekicker";
        private static readonly string SshKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQCfSPC2K7LZcFKEO+/t3dzmQYtrJFZNxOsbVgOVKietqHyvmYGHEC0J2wPdAqQ/63g/hhAEFRoyehM+rbeDri4txB3YFfnOK58jqdkyXzupWqXzOrlKY4Wz9SKjjN765+dqUITjKRIaAip1Ri137szRg71WnrmdP3SphTRlCx1Bk2nXqWPsclbRDCiZeF8QOTi4JqbmJyK5+0UqhqYRduun8ylAwKKQJ1NJt85sYIHn9f1Rfr6Tq2zS0wZ7DHbZL+zB5rSlAr8QyUdg/GQD+cmSs6LvPJKL78d6hMGk84ARtFo4A79ovwX/Fj01znDQkU6nJildfkaolH2rWFG/qttD azjava@javalib.Com";

        /**
         * Azure Network sample for managing network security groups -
         *  - Create a network security group for the front end of a subnet
         *  - Create a network security group for the back end of a subnet
         *  - Create Linux virtual machines for the front end and back end
         *  -- Apply network security groups
         *  - List network security groups
         *  - Update a network security group.
         */
        public static void RunSample(IAzure azure)
        {
            string frontEndNSGName = SdkContext.RandomResourceName("fensg", 24);
            string backEndNSGName = SdkContext.RandomResourceName("bensg", 24);
            string rgName = SdkContext.RandomResourceName("rgNEMS", 24);
            string vnetName = SdkContext.RandomResourceName("vnet", 24);
            string networkInterfaceName1 = SdkContext.RandomResourceName("nic1", 24);
            string networkInterfaceName2 = SdkContext.RandomResourceName("nic2", 24);
            string publicIPAddressLeafDNS1 = SdkContext.RandomResourceName("pip1", 24);
            string frontEndVMName = SdkContext.RandomResourceName("fevm", 24);
            string backEndVMName = SdkContext.RandomResourceName("bevm", 24);

            try
            {
                // Define a virtual network for VMs in this availability set

                Utilities.Log("Creating a virtual network ...");

                var network = azure.Networks.Define(vnetName)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .WithAddressSpace("172.16.0.0/16")
                        .DefineSubnet("Front-end")
                            .WithAddressPrefix("172.16.1.0/24")
                            .Attach()
                        .DefineSubnet("Back-end")
                            .WithAddressPrefix("172.16.2.0/24")
                            .Attach()
                        .Create();

                Utilities.Log("Created a virtual network: " + network.Id);
                Utilities.PrintVirtualNetwork(network);

                //============================================================
                // Create a network security group for the front end of a subnet
                // front end subnet contains two rules
                // - ALLOW-SSH - allows SSH traffic into the front end subnet
                // - ALLOW-WEB- allows HTTP traffic into the front end subnet

                Utilities.Log("Creating a security group for the front end - allows SSH and HTTP");
                var frontEndNSG = azure.NetworkSecurityGroups.Define(frontEndNSGName)
                        .WithRegion(Region.USEast)
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

                Utilities.Log("Created a security group for the front end: " + frontEndNSG.Id);
                Utilities.PrintNetworkSecurityGroup(frontEndNSG);

                //============================================================
                // Create a network security group for the back end of a subnet
                // back end subnet contains two rules
                // - ALLOW-SQL - allows SQL traffic only from the front end subnet
                // - DENY-WEB - denies all outbound internet traffic from the back end subnet

                Utilities.Log("Creating a security group for the front end - allows SSH and "
                        + "denies all outbound internet traffic  ");

                var backEndNSG = azure.NetworkSecurityGroups.Define(backEndNSGName)
                        .WithRegion(Region.USEast)
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

                Utilities.Log("Created a security group for the back end: " + backEndNSG.Id);
                Utilities.PrintNetworkSecurityGroup(backEndNSG);

                Utilities.Log("Creating multiple network interfaces");
                Utilities.Log("Creating network interface 1");

                //========================================================
                // Create a network interface and apply the
                // front end network security group

                Utilities.Log("Creating a network interface for the front end");

                var networkInterface1 = azure.NetworkInterfaces.Define(networkInterfaceName1)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .WithExistingPrimaryNetwork(network)
                        .WithSubnet("Front-end")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithNewPrimaryPublicIPAddress(publicIPAddressLeafDNS1)
                        .WithIPForwarding()
                        .WithExistingNetworkSecurityGroup(frontEndNSG)
                        .Create();

                Utilities.Log("Created network interface for the front end");

                Utilities.PrintNetworkInterface(networkInterface1);

                //========================================================
                // Create a network interface and apply the
                // back end network security group

                Utilities.Log("Creating a network interface for the back end");

                var networkInterface2 = azure.NetworkInterfaces.Define(networkInterfaceName2)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .WithExistingPrimaryNetwork(network)
                        .WithSubnet("Back-end")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithExistingNetworkSecurityGroup(backEndNSG)
                        .Create();

                Utilities.PrintNetworkInterface(networkInterface2);

                //=============================================================
                // Create a virtual machine (for the front end)
                // with the network interface that has the network security group for the front end

                Utilities.Log("Creating a Linux virtual machine (for the front end) - "
                        + "with the network interface that has the network security group for the front end");

                var t1 = DateTime.UtcNow;

                var frontEndVM = azure.VirtualMachines.Define(frontEndVMName)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .WithExistingPrimaryNetworkInterface(networkInterface1)
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(UserName)
                        .WithSsh(SshKey)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .Create();

                var t2 = DateTime.UtcNow;
                Utilities.Log("Created Linux VM: (took "
                        + (t2 - t1).TotalSeconds + " seconds) " + frontEndVM.Id);
                // Print virtual machine details
                Utilities.PrintVirtualMachine(frontEndVM);

                //=============================================================
                // Create a virtual machine (for the back end)
                // with the network interface that has the network security group for the back end

                Utilities.Log("Creating a Linux virtual machine (for the back end) - "
                        + "with the network interface that has the network security group for the back end");

                t1 = DateTime.UtcNow;

                var backEndVM = azure.VirtualMachines.Define(backEndVMName)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .WithExistingPrimaryNetworkInterface(networkInterface2)
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(UserName)
                        .WithSsh(SshKey)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .Create();

                t2 = DateTime.UtcNow;
                Utilities.Log("Created a Linux VM: (took "
                        + (t2 - t1).TotalSeconds + " seconds) " + backEndVM.Id);
                Utilities.PrintVirtualMachine(backEndVM);

                //========================================================
                // List network security groups

                Utilities.Log("Walking through network security groups");
                var networkSecurityGroups = azure.NetworkSecurityGroups.ListByResourceGroup(rgName);

                foreach (var networkSecurityGroup in networkSecurityGroups)
                {
                    Utilities.PrintNetworkSecurityGroup(networkSecurityGroup);
                }

                //========================================================
                // Update a network security group

                Utilities.Log("Updating the front end network security group to allow FTP");

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

                Utilities.Log("Updated the front end network security group");
                Utilities.PrintNetworkSecurityGroup(frontEndNSG);
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
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

                RunSample(azure);
            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
            }
        }
    }
}
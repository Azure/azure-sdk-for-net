// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManageNetworkInterface
{
    public class Program
    {
        private static readonly string UserName = "tirekicker";
        private static readonly string Password = "12NewPA$$w0rd!";

        /**
         * Azure Network sample for managing network interfaces -
         *  - Create a virtual machine with multiple network interfaces
         *  - Configure a network interface
         *  - List network interfaces
         *  - Delete a network interface.
         */
        public static void RunSample(IAzure azure)
        {
            string vnetName = SdkContext.RandomResourceName("vnet", 24);
            string networkInterfaceName1 = SdkContext.RandomResourceName("nic1", 24);
            string networkInterfaceName2 = SdkContext.RandomResourceName("nic2", 24);
            string networkInterfaceName3 = SdkContext.RandomResourceName("nic3", 24);
            string publicIPAddressLeafDNS1 = SdkContext.RandomResourceName("pip1", 24);
            string publicIPAddressLeafDNS2 = SdkContext.RandomResourceName("pip2", 24);
            // TODO adjust the length of vm name from 8 to 24
            string vmName = SdkContext.RandomResourceName("vm", 8);
            string rgName = SdkContext.RandomResourceName("rgNEMI", 24);

            try
            {
                //============================================================
                // Create a virtual machine with multiple network interfaces

                // Define a virtual network for the VMs in this availability set

                Utilities.Log("Creating a virtual network ...");

                var network = azure.Networks
                        .Define(vnetName)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .WithAddressSpace("172.16.0.0/16")
                        .DefineSubnet("Front-end")
                            .WithAddressPrefix("172.16.1.0/24")
                            .Attach()
                        .DefineSubnet("Mid-tier")
                            .WithAddressPrefix("172.16.2.0/24")
                            .Attach()
                        .DefineSubnet("Back-end")
                            .WithAddressPrefix("172.16.3.0/24")
                            .Attach()
                        .Create();

                Utilities.Log("Created a virtual network: " + network.Id);
                Utilities.PrintVirtualNetwork(network);

                Utilities.Log("Creating multiple network interfaces");
                Utilities.Log("Creating network interface 1");

                var networkInterface1 = azure.NetworkInterfaces.Define(networkInterfaceName1)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .WithExistingPrimaryNetwork(network)
                        .WithSubnet("Front-end")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithNewPrimaryPublicIPAddress(publicIPAddressLeafDNS1)
                        .WithIPForwarding()
                        .Create();

                Utilities.Log("Created network interface 1");
                Utilities.PrintNetworkInterface(networkInterface1);
                Utilities.Log("Creating network interface 2");

                var networkInterface2 = azure.NetworkInterfaces.Define(networkInterfaceName2)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .WithExistingPrimaryNetwork(network)
                        .WithSubnet("Mid-tier")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .Create();

                Utilities.Log("Created network interface 2");
                Utilities.PrintNetworkInterface(networkInterface2);

                Utilities.Log("Creating network interface 3");

                var networkInterface3 = azure.NetworkInterfaces.Define(networkInterfaceName3)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .WithExistingPrimaryNetwork(network)
                        .WithSubnet("Back-end")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .Create();

                Utilities.Log("Created network interface 3");
                Utilities.PrintNetworkInterface(networkInterface3);

                //=============================================================
                // Create a virtual machine with multiple network interfaces

                Utilities.Log("Creating a Windows VM");

                var t1 = DateTime.UtcNow;

                var vm = azure.VirtualMachines.Define(vmName)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .WithExistingPrimaryNetworkInterface(networkInterface1)
                        .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WindowsServer2012R2Datacenter)
                        .WithAdminUsername(UserName)
                        .WithAdminPassword(Password)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .WithExistingSecondaryNetworkInterface(networkInterface2)
                        .WithExistingSecondaryNetworkInterface(networkInterface3)
                        .Create();

                var t2 = DateTime.UtcNow;
                Utilities.Log("Created VM: (took "
                        + (t2 - t1).TotalSeconds + " seconds) " + vm.Id);
                // Print virtual machine details
                Utilities.PrintVirtualMachine(vm);

                // ===========================================================
                // Configure a network interface
                Utilities.Log("Updating the first network interface");
                networkInterface1.Update()
                        .WithNewPrimaryPublicIPAddress(publicIPAddressLeafDNS2)
                        .Apply();

                Utilities.Log("Updated the first network interface");
                Utilities.PrintNetworkInterface(networkInterface1);
                Utilities.Log();

                //============================================================
                // List network interfaces

                Utilities.Log("Walking through network inter4faces in resource group: " + rgName);
                var networkInterfaces = azure.NetworkInterfaces.ListByResourceGroup(rgName);
                foreach (var networkInterface in networkInterfaces)
                {
                    Utilities.PrintNetworkInterface(networkInterface);
                }

                //============================================================
                // Delete a network interface

                Utilities.Log("Deleting a network interface: " + networkInterface2.Id);
                Utilities.Log("First, deleting the vm");
                azure.VirtualMachines.DeleteById(vm.Id);
                Utilities.Log("Second, deleting the network interface");
                azure.NetworkInterfaces.DeleteById(networkInterface2.Id);
                Utilities.Log("Deleted network interface");

                Utilities.Log("============================================================");
                Utilities.Log("Remaining network interfaces are ...");
                networkInterfaces = azure.NetworkInterfaces.ListByResourceGroup(rgName);
                foreach (var networkInterface in networkInterfaces)
                {
                    Utilities.PrintNetworkInterface(networkInterface);
                }
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
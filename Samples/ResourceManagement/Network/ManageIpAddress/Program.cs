// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManageIPAddress
{
    public class Program
    {
        private static readonly string UserName = "tirekicker";
        private static readonly string Password = "12NewPA$$w0rd!";

        /**
         * Azure Network sample for managing IP address -
         *  - Assign a public IP address for a virtual machine during its creation
         *  - Assign a public IP address for a virtual machine through an virtual machine update action
         *  - Get the associated public IP address for a virtual machine
         *  - Get the assigned public IP address for a virtual machine
         *  - Remove a public IP address from a virtual machine.
         */
        public static void RunSample(IAzure azure)
        {
            string publicIPAddressName1 = SdkContext.RandomResourceName("pip1", 20);
            string publicIPAddressName2 = SdkContext.RandomResourceName("pip2", 20);
            string publicIPAddressLeafDNS1 = SdkContext.RandomResourceName("pip1", 20);
            string publicIPAddressLeafDNS2 = SdkContext.RandomResourceName("pip2", 20);
            string vmName = SdkContext.RandomResourceName("vm", 8);
            string rgName = SdkContext.RandomResourceName("rgNEMP", 24);

            try
            {
                //============================================================
                // Assign a public IP address for a VM during its creation

                // Define a public IP address to be used during VM creation time

                Utilities.Log("Creating a public IP address...");

                var publicIPAddress = azure.PublicIPAddresses.Define(publicIPAddressName1)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .WithLeafDomainLabel(publicIPAddressLeafDNS1)
                        .Create();

                Utilities.Log("Created a public IP address");
                // Print public IP address details
                Utilities.PrintIPAddress(publicIPAddress);

                // Use the pre-created public IP for the new VM

                Utilities.Log("Creating a Windows VM");

                var t1 = DateTime.UtcNow;

                var vm = azure.VirtualMachines.Define(vmName)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .WithNewPrimaryNetwork("10.0.0.0/28")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithExistingPrimaryPublicIPAddress(publicIPAddress)
                        .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WindowsServer2012R2Datacenter)
                        .WithAdminUsername(UserName)
                        .WithAdminPassword(Password)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .Create();

                var t2 = DateTime.UtcNow;
                Utilities.Log("Created VM: (took "
                        + (t2 - t1).TotalSeconds + " seconds) " + vm.Id);
                // Print virtual machine details
                Utilities.PrintVirtualMachine(vm);

                //============================================================
                // Gets the public IP address associated with the VM's primary NIC

                Utilities.Log("Public IP address associated with the VM's primary NIC [After create]");
                // Print the public IP address details
                Utilities.PrintIPAddress(vm.GetPrimaryPublicIPAddress());

                //============================================================
                // Assign a new public IP address for the VM

                // Define a new public IP address

                var publicIPAddress2 = azure.PublicIPAddresses.Define(publicIPAddressName2)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .WithLeafDomainLabel(publicIPAddressLeafDNS2)
                        .Create();

                // Update VM's primary NIC to use the new public IP address

                Utilities.Log("Updating the VM's primary NIC with new public IP address");

                var primaryNetworkInterface = vm.GetPrimaryNetworkInterface();
                primaryNetworkInterface.Update()
                        .WithExistingPrimaryPublicIPAddress(publicIPAddress2)
                        .Apply();

                //============================================================
                // Gets the updated public IP address associated with the VM

                // Get the associated public IP address for a virtual machine
                Utilities.Log("Public IP address associated with the VM's primary NIC [After Update]");
                vm.Refresh();
                Utilities.PrintIPAddress(vm.GetPrimaryPublicIPAddress());

                //============================================================
                // Remove public IP associated with the VM

                Utilities.Log("Removing public IP address associated with the VM");
                vm.Refresh();
                primaryNetworkInterface = vm.GetPrimaryNetworkInterface();
                publicIPAddress = primaryNetworkInterface.PrimaryIPConfiguration.GetPublicIPAddress();
                primaryNetworkInterface.Update()
                        .WithoutPrimaryPublicIPAddress()
                        .Apply();

                Utilities.Log("Removed public IP address associated with the VM");

                //============================================================
                // Delete the public ip
                Utilities.Log("Deleting the public IP address");
                azure.PublicIPAddresses.DeleteById(publicIPAddress.Id);
                Utilities.Log("Deleted the public IP address");
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
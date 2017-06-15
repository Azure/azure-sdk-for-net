// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManageAvailabilitySet
{
    public class Program
    {
        private const string UserName = "tirekicker";
        private const string Password = "12NewPA$$w0rd!";
        
        /**
         * Azure Compute sample for managing availability sets -
         *  - Create an availability set
         *  - Create a VM in a new availability set
         *  - Create another VM in the same availability set
         *  - Update the availability set
         *  - Create another availability set
         *  - List availability sets
         *  - Delete an availability set.
         */
        public static void RunSample(IAzure azure)
        {
            string rgName = Utilities.CreateRandomName("rgCOMA");
            string availSetName1 = Utilities.CreateRandomName("av1");
            string availSetName2 = Utilities.CreateRandomName("av2");
            string vm1Name = Utilities.CreateRandomName("vm1");
            string vm2Name = Utilities.CreateRandomName("vm2");
            string vnetName = Utilities.CreateRandomName("vnet");

            try
            {
                //=============================================================
                // Create an availability set

                Utilities.Log("Creating an availability set");

                var availSet1 = azure.AvailabilitySets.Define(availSetName1)
                        .WithRegion(Region.USEast)
                        .WithNewResourceGroup(rgName)
                        .WithFaultDomainCount(2)
                        .WithUpdateDomainCount(4)
                        .WithSku(AvailabilitySetSkuTypes.Managed)
                        .WithTag("cluster", "Windowslinux")
                        .WithTag("tag1", "tag1val")
                        .Create();

                Utilities.Log("Created first availability set: " + availSet1.Id);
                Utilities.PrintAvailabilitySet(availSet1);

                //=============================================================
                // Define a virtual network for the VMs in this availability set
                var network = azure.Networks
                        .Define(vnetName)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .WithAddressSpace("10.0.0.0/28");

                //=============================================================
                // Create a Windows VM in the new availability set

                Utilities.Log("Creating a Windows VM in the availability set");

                var vm1 = azure.VirtualMachines.Define(vm1Name)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .WithNewPrimaryNetwork(network)
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WindowsServer2012R2Datacenter)
                        .WithAdminUsername(UserName)
                        .WithAdminPassword(Password)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .WithExistingAvailabilitySet(availSet1)
                        .Create();

                Utilities.Log("Created first VM:" + vm1.Id);
                Utilities.PrintVirtualMachine(vm1);

                //=============================================================
                // Create a Linux VM in the same availability set

                Utilities.Log("Creating a Linux VM in the availability set");

                var vm2 = azure.VirtualMachines.Define(vm2Name)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .WithNewPrimaryNetwork(network)
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(UserName)
                        .WithRootPassword(Password)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .WithExistingAvailabilitySet(availSet1)
                        .Create();

                Utilities.Log("Created second VM: " + vm2.Id);
                Utilities.PrintVirtualMachine(vm2);

                //=============================================================
                // Update - Tag the availability set

                availSet1 = availSet1.Update()
                        .WithTag("server1", "nginx")
                        .WithTag("server2", "iis")
                        .WithoutTag("tag1")
                        .Apply();

                Utilities.Log("Tagged availability set: " + availSet1.Id);

                //=============================================================
                // Create another availability set

                Utilities.Log("Creating an availability set");

                var availSet2 = azure.AvailabilitySets.Define(availSetName2)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .Create();

                Utilities.Log("Created second availability set: " + availSet2.Id);
                Utilities.PrintAvailabilitySet(availSet2);

                //=============================================================
                // List availability sets

                var resourceGroupName = availSet1.ResourceGroupName;

                Utilities.Log("Printing list of availability sets  =======");

                foreach (var availabilitySet in azure.AvailabilitySets.ListByResourceGroup(resourceGroupName))
                {
                    Utilities.PrintAvailabilitySet(availabilitySet);
                }

                //=============================================================
                // Delete an availability set

                Utilities.Log("Deleting an availability set: " + availSet2.Id);

                azure.AvailabilitySets.DeleteById(availSet2.Id);

                Utilities.Log("Deleted availability set: " + availSet2.Id);
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
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
                //=============================================================
                // Authenticate
                var credentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
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
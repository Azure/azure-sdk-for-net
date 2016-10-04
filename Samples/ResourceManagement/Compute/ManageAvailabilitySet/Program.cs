// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Fluent.Compute;
using Microsoft.Azure.Management.Fluent.Resource.Authentication;
using Microsoft.Azure.Management.Fluent.Resource.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManageAvailabilitySet
{
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

    public class Program
    {
        private static readonly string rgName = Utilities.CreateRandomName("rgCOMA");
        private static readonly string availSetName1 = Utilities.CreateRandomName("av1");
        private static readonly string availSetName2 = Utilities.CreateRandomName("av2");
        private static readonly string vm1Name = Utilities.CreateRandomName("vm1");
        private static readonly string vm2Name = Utilities.CreateRandomName("vm2");
        private static readonly string vnetName = Utilities.CreateRandomName("vnet");

        private static readonly string userName = "tirekicker";
        private static readonly string password = "12NewPA$$w0rd!";

        public static void Main(string[] args)
        {
            try
            {
                //=============================================================
                // Authenticate
                AzureCredentials credentials = AzureCredentials.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.BASIC)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Console.WriteLine("Selected subscription: " + azure.SubscriptionId);

                try
                {
                    //=============================================================
                    // Create an availability set

                    Console.WriteLine("Creating an availability set");

                    var availSet1 = azure.AvailabilitySets.Define(availSetName1)
                            .WithRegion(Region.US_EAST)
                            .WithNewResourceGroup(rgName)
                            .WithFaultDomainCount(2)
                            .WithUpdateDomainCount(4)
                            .WithTag("cluster", "Windowslinux")
                            .WithTag("tag1", "tag1val")
                            .Create();

                    Console.WriteLine("Created first availability set: " + availSet1.Id);
                    Utilities.PrintAvailabilitySet(availSet1);

                    //=============================================================
                    // Define a virtual network for the VMs in this availability set
                    var network = azure.Networks
                            .Define(vnetName)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .WithAddressSpace("10.0.0.0/28");

                    //=============================================================
                    // Create a Windows VM in the new availability set

                    Console.WriteLine("Creating a Windows VM in the availability set");

                    var vm1 = azure.VirtualMachines.Define(vm1Name)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .WithNewPrimaryNetwork(network)
                            .WithPrimaryPrivateIpAddressDynamic()
                            .WithoutPrimaryPublicIpAddress()
                            .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WINDOWS_SERVER_2012_R2_DATACENTER)
                            .WithAdminUserName(userName)
                            .WithPassword(password)
                            .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                            .WithExistingAvailabilitySet(availSet1)
                            .Create();

                    Console.WriteLine("Created first VM:" + vm1.Id);
                    Utilities.PrintVirtualMachine(vm1);

                    //=============================================================
                    // Create a Linux VM in the same availability set

                    Console.WriteLine("Creating a Linux VM in the availability set");

                    var vm2 = azure.VirtualMachines.Define(vm2Name)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .WithNewPrimaryNetwork(network)
                            .WithPrimaryPrivateIpAddressDynamic()
                            .WithoutPrimaryPublicIpAddress()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_16_04_LTS)
                            .WithRootUserName(userName)
                            .WithPassword(password)
                            .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                            .WithExistingAvailabilitySet(availSet1)
                            .Create();

                    Console.WriteLine("Created second VM: " + vm2.Id);
                    Utilities.PrintVirtualMachine(vm2);

                    //=============================================================
                    // Update - Tag the availability set

                    availSet1 = availSet1.Update()
                            .WithTag("server1", "nginx")
                            .WithTag("server2", "iis")
                            .WithoutTag("tag1")
                            .Apply();

                    Console.WriteLine("Tagged availability set: " + availSet1.Id);

                    //=============================================================
                    // Create another availability set

                    Console.WriteLine("Creating an availability set");

                    var availSet2 = azure.AvailabilitySets.Define(availSetName2)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .Create();

                    Console.WriteLine("Created second availability set: " + availSet2.Id);
                    Utilities.PrintAvailabilitySet(availSet2);

                    //=============================================================
                    // List availability sets

                    var resourceGroupName = availSet1.ResourceGroupName;

                    Console.WriteLine("Printing list of availability sets  =======");

                    foreach (var availabilitySet in azure.AvailabilitySets.ListByGroup(resourceGroupName))
                    {
                        Utilities.PrintAvailabilitySet(availabilitySet);
                    }

                    //=============================================================
                    // Delete an availability set

                    Console.WriteLine("Deleting an availability set: " + availSet2.Id);

                    azure.AvailabilitySets.Delete(availSet2.Id);

                    Console.WriteLine("Deleted availability set: " + availSet2.Id);
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
                        azure.ResourceGroups.Delete(rgName);
                        Console.WriteLine("Deleted Resource Group: " + rgName);
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
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
using System;
using System.Collections.Generic;

namespace ManageVirtualMachinesInParallel
{
    /**
     * Azure Compute sample for managing virtual machines -
     *  - Create N virtual machines in parallel
     */

    public class Program
    {
        private static readonly int vmCount = 2;
        private static readonly string rgName = ResourceNamer.RandomResourceName("rgCOPP", 24);
        private static readonly string networkName = ResourceNamer.RandomResourceName("vnetCOMV", 24);
        private static readonly string storageAccountName = ResourceNamer.RandomResourceName("stgCOMV", 20);
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
                    // Create a resource group [Where all resources gets created]
                    IResourceGroup resourceGroup = azure.ResourceGroups
                            .Define(rgName)
                            .WithRegion(Region.US_EAST)
                            .Create();

                    // Prepare Creatable Network definition [Where all the virtual machines get added to]
                    var creatableNetwork = azure.Networks
                            .Define(networkName)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithAddressSpace("172.16.0.0/16");

                    // Prepare Creatable Storage account definition [For storing VMs disk]
                    var creatableStorageAccount = azure.StorageAccounts
                            .Define(storageAccountName)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(resourceGroup);

                    // Prepare a batch of Creatable Virtual Machines definitions
                    List<ICreatable<IVirtualMachine>> creatableVirtualMachines = new List<ICreatable<IVirtualMachine>>();

                    for (int i = 0; i < vmCount; i++)
                    {
                        var creatableVirtualMachine = azure.VirtualMachines
                            .Define("VM-" + i)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithNewPrimaryNetwork(creatableNetwork)
                            .WithPrimaryPrivateIpAddressDynamic()
                            .WithoutPrimaryPublicIpAddress()
                            .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UBUNTU_SERVER_16_04_LTS)
                            .WithRootUsername("tirekicker")
                            .WithRootPassword("12NewPA$$w0rd!")
                            .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                            .WithNewStorageAccount(creatableStorageAccount);
                        creatableVirtualMachines.Add(creatableVirtualMachine);
                    }

                    var startTime = DateTimeOffset.Now.UtcDateTime;
                    Console.WriteLine("Creating the virtual machines");

                    Console.WriteLine("Created virtual machines");

                    var virtualMachines = azure.VirtualMachines.Create(creatableVirtualMachines.ToArray());

                    foreach (var virtualMachine in virtualMachines)
                    {
                        Console.WriteLine(virtualMachine.Id);
                    }

                    var endTime = DateTimeOffset.Now.UtcDateTime;

                    Console.WriteLine($"Created VM: took {(endTime - startTime).TotalSeconds} seconds");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    Console.WriteLine($"Deleting resource group : {rgName}");
                    azure.ResourceGroups.DeleteByName(rgName);
                    Console.WriteLine($"Deleted resource group : {rgName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
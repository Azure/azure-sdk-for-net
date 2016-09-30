// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Microsoft.Azure.Management;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Fluent.Compute;
using Microsoft.Azure.Management.Fluent.Resource;
using Microsoft.Azure.Management.Fluent.Resource.Authentication;
using Microsoft.Azure.Management.Fluent.Resource.Core;
using Microsoft.Azure.Management.Fluent.Resource.Core.ResourceActions;
using System;
using System.Collections.Generic;

namespace ManageVirtualMachinesInParallel
{
    public class Program
    {
        /**
         * Azure Compute sample for managing virtual machines -
         *  - Create N virtual machines in parallel
         */
        readonly static int vmCount = 2;
        readonly static string rgName = ResourceNamer.RandomResourceName("rgCOMV", 24);
        readonly static string networkName = ResourceNamer.RandomResourceName("vnetCOMV", 24);
        readonly static string storageAccountName = ResourceNamer.RandomResourceName("stgCOMV", 20);
        readonly static string userName = "tirekicker";
        readonly static string password = "12NewPA$$w0rd!";

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
                    .WithSubscription(credentials.DefaultSubscriptionId);

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
                            .WithRootUserName("tirekicker")
                            .WithPassword("12NewPA$$w0rd!")
                            .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                            .WithNewStorageAccount(creatableStorageAccount);
                        creatableVirtualMachines.Add(creatableVirtualMachine);
                    }

                    var startTime = DateTimeOffset.Now.UtcDateTime;
                    Console.WriteLine("Creating the virtual machines");

                    var endTime = DateTimeOffset.Now.UtcDateTime;
                    Console.WriteLine("Created virtual machines");

                    var virtualMachines = azure.VirtualMachines.Create(creatableVirtualMachines.ToArray());

                    foreach (var virtualMachine in virtualMachines)
                    {
                        Console.WriteLine(virtualMachine.Id);
                    }

                    Console.WriteLine($"Created VM: took {(endTime - startTime).Seconds} seconds");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    Console.WriteLine($"Deleting resource group : {rgName}");
                    azure.ResourceGroups.Delete(rgName);
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

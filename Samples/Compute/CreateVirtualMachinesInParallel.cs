// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Collections.Generic;

namespace CreateVirtualMachinesInParallel
{
    public class Program
    {
        private const string Username = "tirekicker";
        private const string Password = "12NewPA$$w0rd!";

        /**
         * Azure compute sample for creating multiple virtual machines in parallel.
         *  - Define 1 virtual network per region
         *  - Define 1 storage account per region
         *  - Create 5 virtual machines in 2 regions using defined virtual network and storage account
         *  - Create a traffic manager to route traffic across the virtual machines
         */
        public static void RunSample(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rgCOMV", 10);
            IDictionary<Region, int> virtualMachinesByLocation = new Dictionary<Region, int>();

            virtualMachinesByLocation.Add(Region.USEast, 5);
            virtualMachinesByLocation.Add(Region.USSouthCentral, 5);
            try
            {
                //=============================================================
                // Create a resource group (Where all resources gets created)
                //
                var resourceGroup = azure.ResourceGroups.Define(rgName)
                    .WithRegion(Region.USWest)
                    .Create();

                Utilities.Log($"Created a new resource group - {resourceGroup.Id}");

                var publicIpCreatableKeys = new List<string>();
                // Prepare a batch of Creatable definitions
                //
                var creatableVirtualMachines = new List<ICreatable<IVirtualMachine>>();

                foreach (var entry in virtualMachinesByLocation)
                {
                    var region = entry.Key;
                    var vmCount = entry.Value;

                    //=============================================================
                    // Create 1 network creatable per region
                    // Prepare Creatable Network definition (Where all the virtual machines get added to)
                    //
                    var networkName = SdkContext.RandomResourceName("vnetCOPD-", 20);
                    var networkCreatable = azure.Networks
                            .Define(networkName)
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithAddressSpace("172.16.0.0/16");

                    //=============================================================
                    // Create 1 storage creatable per region (For storing VMs disk)
                    //
                    var storageAccountName = SdkContext.RandomResourceName("stgcopd", 20);
                    var storageAccountCreatable = azure.StorageAccounts
                            .Define(storageAccountName)
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup);

                    var linuxVMNamePrefix = SdkContext.RandomResourceName("vm-", 15);
                    for (int i = 1; i <= vmCount; i++)
                    {
                        //=============================================================
                        // Create 1 public IP address creatable
                        //
                        var publicIpAddressCreatable = azure.PublicIPAddresses
                                .Define($"{linuxVMNamePrefix}-{i}")
                                .WithRegion(region)
                                .WithExistingResourceGroup(resourceGroup)
                                .WithLeafDomainLabel($"{linuxVMNamePrefix}-{i}");

                        publicIpCreatableKeys.Add(publicIpAddressCreatable.Key);

                        //=============================================================
                        // Create 1 virtual machine creatable
                        var virtualMachineCreatable = azure.VirtualMachines
                                .Define($"{linuxVMNamePrefix}-{i}")
                                .WithRegion(region)
                                .WithExistingResourceGroup(resourceGroup)
                                .WithNewPrimaryNetwork(networkCreatable)
                                .WithPrimaryPrivateIPAddressDynamic()
                                .WithNewPrimaryPublicIPAddress(publicIpAddressCreatable)
                                .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                                .WithRootUsername(Username)
                                .WithRootPassword(Password)
                                .WithSize(VirtualMachineSizeTypes.StandardDS3V2)
                                .WithNewStorageAccount(storageAccountCreatable);
                        creatableVirtualMachines.Add(virtualMachineCreatable);
                    }
                }

                //=============================================================
                // Create !!

                var t1 = DateTimeOffset.Now.UtcDateTime;
                Utilities.Log("Creating the virtual machines");

                var virtualMachines = azure.VirtualMachines.Create(creatableVirtualMachines.ToArray());

                var t2 = DateTimeOffset.Now.UtcDateTime;
                Utilities.Log("Created virtual machines");

                foreach (var virtualMachine in virtualMachines)
                {
                    Utilities.Log(virtualMachine.Id);
                }

                Utilities.Log($"Virtual machines create: took {(t2 - t1).TotalSeconds } seconds to create == " + creatableVirtualMachines.Count + " == virtual machines");

                var publicIpResourceIds = new List<string>();
                foreach (string publicIpCreatableKey in publicIpCreatableKeys)
                {
                    var pip = (IPublicIPAddress)virtualMachines.CreatedRelatedResource(publicIpCreatableKey);
                    publicIpResourceIds.Add(pip.Id);
                }

                //=============================================================
                // Create 1 Traffic Manager Profile
                //
                var trafficManagerName = SdkContext.RandomResourceName("tra", 15);
                var profileWithEndpoint = azure.TrafficManagerProfiles.Define(trafficManagerName)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithLeafDomainLabel(trafficManagerName)
                        .WithPerformanceBasedRouting();

                int endpointPriority = 1;
                Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate profileWithCreate = null;
                foreach (var publicIpResourceId in publicIpResourceIds)
                {
                    var endpointName = $"azendpoint-{endpointPriority}";
                    if (endpointPriority == 1)
                    {
                        profileWithCreate = profileWithEndpoint.DefineAzureTargetEndpoint(endpointName)
                                .ToResourceId(publicIpResourceId)
                                .WithRoutingPriority(endpointPriority)
                                .Attach();
                    }
                    else
                    {
                        profileWithCreate = profileWithCreate.DefineAzureTargetEndpoint(endpointName)
                                .ToResourceId(publicIpResourceId)
                                .WithRoutingPriority(endpointPriority)
                                .Attach();
                    }
                    endpointPriority++;
                }

                var trafficManagerProfile = profileWithCreate.Create();
                Utilities.Log("Created a traffic manager profile - " + trafficManagerProfile.Id);
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                catch (Exception)
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
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

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Utilities.Log("Selected subscription: " + azure.SubscriptionId);

                RunSample(azure);
            }
            catch (Exception e)
            {
                Utilities.Log(e);
            }
        }
    }
}

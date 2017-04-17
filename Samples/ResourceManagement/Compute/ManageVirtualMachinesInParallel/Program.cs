// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Collections.Generic;

namespace ManageVirtualMachinesInParallel
{
    public class Program
    {
        private const int vmCount = 2;
        private const string userName = "tirekicker";
        private const string password = "12NewPA$$w0rd!";

        /**
         * Azure Compute sample for managing virtual machines -
         *  - Create N virtual machines in parallel
         */
        public static void RunSample(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rgCOPP", 24);
            string networkName = SdkContext.RandomResourceName("vnetCOMV", 24);
            string storageAccountName = SdkContext.RandomResourceName("stgCOMV", 20);

            try
            {
                // Create a resource group [Where all resources gets created]
                IResourceGroup resourceGroup = azure.ResourceGroups
                        .Define(rgName)
                        .WithRegion(Region.USEast)
                        .Create();

                // Prepare Creatable Network definition [Where all the virtual machines get added to]
                var creatableNetwork = azure.Networks
                        .Define(networkName)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithAddressSpace("172.16.0.0/16");

                // Prepare Creatable Storage account definition [For storing VMs disk]
                var creatableStorageAccount = azure.StorageAccounts
                        .Define(storageAccountName)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(resourceGroup);

                // Prepare a batch of Creatable Virtual Machines definitions
                List<ICreatable<IVirtualMachine>> creatableVirtualMachines = new List<ICreatable<IVirtualMachine>>();

                for (int i = 0; i < vmCount; i++)
                {
                    var creatableVirtualMachine = azure.VirtualMachines
                        .Define("VM-" + i)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithNewPrimaryNetwork(creatableNetwork)
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername("tirekicker")
                        .WithRootPassword("12NewPA$$w0rd!")
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .WithNewStorageAccount(creatableStorageAccount);
                    creatableVirtualMachines.Add(creatableVirtualMachine);
                }

                var startTime = DateTimeOffset.Now.UtcDateTime;
                Utilities.Log("Creating the virtual machines");

                Utilities.Log("Created virtual machines");

                var virtualMachines = azure.VirtualMachines.Create(creatableVirtualMachines.ToArray());

                foreach (var virtualMachine in virtualMachines)
                {
                    Utilities.Log(virtualMachine.Id);
                }

                var endTime = DateTimeOffset.Now.UtcDateTime;

                Utilities.Log($"Created VM: took {(endTime - startTime).TotalSeconds} seconds");
            }
            finally
            {
                Utilities.Log($"Deleting resource group : {rgName}");
                azure.ResourceGroups.DeleteByName(rgName);
                Utilities.Log($"Deleted resource group : {rgName}");
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                //=============================================================
                // Authenticate
                AzureCredentials credentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

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
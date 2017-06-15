// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManageVirtualMachinesInParallelWithNetwork
{
    public class Program
    {
        private const int FrontendVMCount = 10;
        private const int BackendVMCount = 10;
        private const string UserName = "tirekicker";
        private const string Password = "12NewPA$$w0rd!";

        /**
         * Create a virtual network with two Subnets – frontend and backend
         * Frontend allows HTTP in and denies Internet out
         * Backend denies Internet in and Internet out
         * Create m Linux virtual machines in the frontend
         * Create m Windows virtual machines in the backend.
         */
        public static void RunSample(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rgNEPP", 24);
            string frontEndNSGName = SdkContext.RandomResourceName("fensg", 24);
            string backEndNSGName = SdkContext.RandomResourceName("bensg", 24);
            string networkName = SdkContext.RandomResourceName("vnetCOMV", 24);
            string storageAccountName = SdkContext.RandomResourceName("stgCOMV", 20);

            try
            {
                // Create a resource group [Where all resources gets created]
                IResourceGroup resourceGroup = azure.ResourceGroups
                        .Define(rgName)
                        .WithRegion(Region.USEast)
                        .Create();

                //============================================================
                // Define a network security group for the front end of a subnet
                // front end subnet contains two rules
                // - ALLOW-SSH - allows SSH traffic into the front end subnet
                // - ALLOW-WEB- allows HTTP traffic into the front end subnet

                var frontEndNSGCreatable = azure.NetworkSecurityGroups
                        .Define(frontEndNSGName)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(resourceGroup)
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
                        .Attach();

                //============================================================
                // Define a network security group for the back end of a subnet
                // back end subnet contains two rules
                // - ALLOW-SQL - allows SQL traffic only from the front end subnet
                // - DENY-WEB - denies all outbound internet traffic from the back end subnet

                var backEndNSGCreatable = azure.NetworkSecurityGroups
                        .Define(backEndNSGName)
                            .WithRegion(Region.USEast)
                            .WithExistingResourceGroup(resourceGroup)
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
                        .Attach();

                Utilities.Log("Creating a security group for the front ends - allows SSH and HTTP");
                Utilities.Log("Creating a security group for the back ends - allows SSH and denies all outbound internet traffic");

                var networkSecurityGroups = azure.NetworkSecurityGroups
                        .Create(frontEndNSGCreatable, backEndNSGCreatable);

                INetworkSecurityGroup frontendNSG = networkSecurityGroups.First(n => n.Name.Equals(frontEndNSGName, StringComparison.OrdinalIgnoreCase));
                INetworkSecurityGroup backendNSG = networkSecurityGroups.First(n => n.Name.Equals(backEndNSGName, StringComparison.OrdinalIgnoreCase));

                Utilities.Log("Created a security group for the front end: " + frontendNSG.Id);
                Utilities.PrintNetworkSecurityGroup(frontendNSG);

                Utilities.Log("Created a security group for the back end: " + backendNSG.Id);
                Utilities.PrintNetworkSecurityGroup(backendNSG);

                // Create Network [Where all the virtual machines get added to]
                var network = azure.Networks
                        .Define(networkName)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithAddressSpace("172.16.0.0/16")
                        .DefineSubnet("Front-end")
                            .WithAddressPrefix("172.16.1.0/24")
                            .WithExistingNetworkSecurityGroup(frontendNSG)
                        .Attach()
                        .DefineSubnet("Back-end")
                            .WithAddressPrefix("172.16.2.0/24")
                            .WithExistingNetworkSecurityGroup(backendNSG)
                        .Attach()
                        .Create();

                // Prepare Creatable Storage account definition [For storing VMs disk]
                var creatableStorageAccount = azure.StorageAccounts
                        .Define(storageAccountName)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(resourceGroup);

                // Prepare a batch of Creatable Virtual Machines definitions
                List<ICreatable<IVirtualMachine>> frontendCreatableVirtualMachines = new List<ICreatable<IVirtualMachine>>();

                for (int i = 0; i < FrontendVMCount; i++)
                {
                    var creatableVirtualMachine = azure.VirtualMachines
                        .Define("VM-FE-" + i)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithExistingPrimaryNetwork(network)
                        .WithSubnet("Front-end")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(UserName)
                        .WithRootPassword(Password)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .WithNewStorageAccount(creatableStorageAccount);
                    frontendCreatableVirtualMachines.Add(creatableVirtualMachine);
                }

                List<ICreatable<IVirtualMachine>> backendCreatableVirtualMachines = new List<ICreatable<IVirtualMachine>>();

                for (int i = 0; i < BackendVMCount; i++)
                {
                    var creatableVirtualMachine = azure.VirtualMachines
                        .Define("VM-BE-" + i)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithExistingPrimaryNetwork(network)
                        .WithSubnet("Back-end")
                        .WithPrimaryPrivateIPAddressDynamic()
                        .WithoutPrimaryPublicIPAddress()
                        .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                        .WithRootUsername(UserName)
                        .WithRootPassword(Password)
                        .WithSize(VirtualMachineSizeTypes.StandardD3V2)
                        .WithNewStorageAccount(creatableStorageAccount);
                    backendCreatableVirtualMachines.Add(creatableVirtualMachine);
                }

                var startTime = DateTimeOffset.Now.UtcDateTime;
                Utilities.Log("Creating the virtual machines");

                List<ICreatable<IVirtualMachine>> allCreatableVirtualMachines = new List<ICreatable<IVirtualMachine>>();
                allCreatableVirtualMachines.AddRange(frontendCreatableVirtualMachines);
                allCreatableVirtualMachines.AddRange(backendCreatableVirtualMachines);

                var virtualMachines = azure.VirtualMachines.Create(allCreatableVirtualMachines.ToArray());

                var endTime = DateTimeOffset.Now.UtcDateTime;
                Utilities.Log("Created virtual machines");

                foreach (var virtualMachine in virtualMachines)
                {
                    Utilities.Log(virtualMachine.Id);
                }

                Utilities.Log($"Virtual machines create: took {(endTime - startTime).TotalSeconds } seconds");
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
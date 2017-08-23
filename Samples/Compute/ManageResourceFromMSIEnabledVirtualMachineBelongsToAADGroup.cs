// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageResourceFromMSIEnabledVirtualMachineBelongsToAADGroup
{
    public class Program
    {
        /**
        * Azure Compute sample for managing virtual machines -
        *   - Create a AAD security group
        *   - Assign AAD security group Contributor role at a resource group
        *   - Create a virtual machine with MSI enabled
        *   - Add virtual machine MSI service principal to the AAD group
        *   - Set custom script in the virtual machine that
        *          - install az cli in the virtual machine
        *          - uses az cli MSI credentials to create a storage account
        *   - Get storage account created through MSI credentials.
        */
        public static void RunSample(IAzure azure)
        {
            var groupName = Utilities.CreateRandomName("group");
            var roleAssignmentName = SdkContext.RandomGuid();
            var linuxVMName = Utilities.CreateRandomName("VM1");
            var rgName = Utilities.CreateRandomName("rgCOMV");
            var pipName = Utilities.CreateRandomName("pip1");
            var userName = "tirekicker";
            var password = "12NewPA$$w0rd!";
            var region = Region.USWestCentral;

            var installScript = "https://raw.githubusercontent.com/Azure/azure-sdk-for-net/Fluent/Samples/Asset/create_resources_with_msi.sh";
            var installCommand = "bash create_resources_with_msi.sh {subscriptionID} {port} {stgName} {rgName} {location}";
            List<String> fileUris = new List<String>();
            fileUris.Add(installScript);
            try
            {
                //=============================================================
                // Create a AAD security group

                Utilities.Log("Creating a AAD security group");

                IActiveDirectoryGroup activeDirectoryGroup = azure.AccessManagement
                        .ActiveDirectoryGroups
                        .Define(groupName)
                            .WithEmailAlias(groupName)
                            .Create();

                //=============================================================
                // Assign AAD security group Contributor role at a resource group

                IResourceGroup resourceGroup = azure.ResourceGroups
                        .Define(rgName)
                            .WithRegion(region)
                            .Create();

                SdkContext.DelayProvider.Delay(45 * 1000);

                Utilities.Log("Assigning AAD security group Contributor role to the resource group");

                azure.AccessManagement
                        .RoleAssignments
                        .Define(roleAssignmentName)
                            .ForGroup(activeDirectoryGroup)
                            .WithBuiltInRole(BuiltInRole.Contributor)
                            .WithResourceGroupScope(resourceGroup)
                            .Create();

                Utilities.Log("Assigned AAD security group Contributor role to the resource group");

                //=============================================================
                // Create a Linux VM with MSI enabled for contributor access to the current resource group

                Utilities.Log("Creating a Linux VM with MSI enabled");

                var virtualMachine = azure.VirtualMachines
                    .Define(linuxVMName)
                    .WithRegion(region)
                    .WithNewResourceGroup(rgName)
                    .WithNewPrimaryNetwork("10.0.0.0/28")
                    .WithPrimaryPrivateIPAddressDynamic()
                    .WithNewPrimaryPublicIPAddress(pipName)
                    .WithPopularLinuxImage(KnownLinuxVirtualMachineImage.UbuntuServer16_04_Lts)
                    .WithRootUsername(userName)
                    .WithRootPassword(password)
                    .WithSize(VirtualMachineSizeTypes.StandardDS2V2)
                    .WithOSDiskCaching(CachingTypes.ReadWrite)
                    .WithManagedServiceIdentity()
                    .Create();

                Utilities.Log("Created virtual machine with MSI enabled");
                Utilities.PrintVirtualMachine(virtualMachine);

                //=============================================================
                // Add virtual machine MSI service principal to the AAD group

                Utilities.Log("Adding virtual machine MSI service principal to the AAD group");

                activeDirectoryGroup.Update()
                        .WithMember(virtualMachine.ManagedServiceIdentityPrincipalId)
                        .Apply();

                Utilities.Log("Added virtual machine MSI service principal to the AAD group");

                Utilities.Log("Waiting 10 minutes to MSI extension in the VM to refresh the token");

                SdkContext.DelayProvider.Delay(10 * 60 * 1000);

                // Prepare custom script to install az cli that uses MSI to create a storage account
                //
                var stgName = Utilities.CreateRandomName("st44");
                installCommand = installCommand.Replace("{subscriptionID}", azure.SubscriptionId)
                                .Replace("{port}", "50342")
                                .Replace("{stgName}", stgName)
                                .Replace("{rgName}", rgName)
                                .Replace("{location}", region.Name);

                // Update the VM by installing custom script extension.
                //
                Utilities.Log("Installing custom script extension to configure az cli in the virtual machine");
                Utilities.Log("az cli will use MSI credentials to create storage account");

                virtualMachine.Update()
                    .DefineNewExtension("CustomScriptForLinux")
                        .WithPublisher("Microsoft.OSTCExtensions")
                        .WithType("CustomScriptForLinux")
                        .WithVersion("1.4")
                        .WithMinorVersionAutoUpgrade()
                        .WithPublicSetting("fileUris", fileUris)
                        .WithPublicSetting("commandToExecute", installCommand)
                    .Attach()
                    .Apply();

                // Retrieve the storage account created by az cli using MSI credentials
                //
                var storageAccount = azure.StorageAccounts
                        .GetByResourceGroup(rgName, stgName);

                Utilities.Log("Storage account created by az cli using MSI credential");
                Utilities.PrintStorageAccount(storageAccount);
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.BeginDeleteByName(rgName);
                }
                catch (NullReferenceException)
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
                }
                catch (Exception g)
                {
                    Utilities.Log(g);
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

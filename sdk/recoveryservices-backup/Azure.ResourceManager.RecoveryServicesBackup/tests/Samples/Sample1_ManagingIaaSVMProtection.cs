// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Manage_IaaSVM_Protection_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.RecoveryServicesBackup.Models;
#endregion
using NUnit.Framework;

namespace Azure.ResourceManager.RecoveryServicesBackup.Tests.Samples
{
    public class Sample1_ManagingIaaSVMProtection
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DefaultSubscription()
        {
            #region Snippet:Readme_DefaultSubscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = armClient.GetDefaultSubscription();
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task EnableProtection()
        {
            #region Snippet:Manage_IaaSVM_EnableProtection_ARM
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());

            // Define your resource details
            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "MyResourceGroup";
            string vaultName = "MyRecoveryServicesVault";
            string vmResourceGroup = "MyVMResourceGroup";
            string vmName = "MyVM";
            string policyName = "DefaultPolicy";

            // Build the container and protected item names
            // For ARM VMs, the format uses "iaasvmcontainerv2"
            string fabricName = "Azure";
            string containerName = $"IaasVMContainer;iaasvmcontainerv2;{vmResourceGroup};{vmName}";
            string protectedItemName = $"VM;iaasvmcontainerv2;{vmResourceGroup};{vmName}";

            // Get the protection container resource
            ResourceIdentifier containerId = BackupProtectionContainerResource.CreateResourceIdentifier(
                subscriptionId, resourceGroupName, vaultName, fabricName, containerName);
            BackupProtectionContainerResource container = armClient.GetBackupProtectionContainerResource(containerId);

            // Get the protected items collection
            BackupProtectedItemCollection protectedItems = container.GetBackupProtectedItems();

            // Create the protection request using IaasComputeVmProtectedItem (for ARM VMs)
            BackupProtectedItemData data = new BackupProtectedItemData(default)
            {
                Properties = new IaasComputeVmProtectedItem
                {
                    SourceResourceId = new ResourceIdentifier(
                        $"/subscriptions/{subscriptionId}/resourceGroups/{vmResourceGroup}" +
                        $"/providers/Microsoft.Compute/virtualMachines/{vmName}"),
                    PolicyId = new ResourceIdentifier(
                        $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}" +
                        $"/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupPolicies/{policyName}"),
                },
            };

            // Enable protection (this is a long-running operation)
            ArmOperation<BackupProtectedItemResource> operation =
                await protectedItems.CreateOrUpdateAsync(WaitUntil.Completed, protectedItemName, data);

            BackupProtectedItemResource result = operation.Value;
            Console.WriteLine($"Protection enabled. Resource ID: {result.Data.Id}");
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ModifyProtection()
        {
            #region Snippet:Manage_IaaSVM_ModifyProtection
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());

            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "MyResourceGroup";
            string vaultName = "MyRecoveryServicesVault";
            string vmResourceGroup = "MyVMResourceGroup";
            string vmName = "MyVM";
            string newPolicyName = "MyCustomPolicy";

            string fabricName = "Azure";
            string containerName = $"IaasVMContainer;iaasvmcontainerv2;{vmResourceGroup};{vmName}";
            string protectedItemName = $"VM;iaasvmcontainerv2;{vmResourceGroup};{vmName}";

            ResourceIdentifier containerId = BackupProtectionContainerResource.CreateResourceIdentifier(
                subscriptionId, resourceGroupName, vaultName, fabricName, containerName);
            BackupProtectionContainerResource container = armClient.GetBackupProtectionContainerResource(containerId);
            BackupProtectedItemCollection protectedItems = container.GetBackupProtectedItems();

            // Set the new policy ID on the protected item
            BackupProtectedItemData data = new BackupProtectedItemData(default)
            {
                Properties = new IaasComputeVmProtectedItem
                {
                    SourceResourceId = new ResourceIdentifier(
                        $"/subscriptions/{subscriptionId}/resourceGroups/{vmResourceGroup}" +
                        $"/providers/Microsoft.Compute/virtualMachines/{vmName}"),
                    PolicyId = new ResourceIdentifier(
                        $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}" +
                        $"/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupPolicies/{newPolicyName}"),
                },
            };

            ArmOperation<BackupProtectedItemResource> operation =
                await protectedItems.CreateOrUpdateAsync(WaitUntil.Completed, protectedItemName, data);

            Console.WriteLine($"Protection policy updated. Resource ID: {operation.Value.Data.Id}");
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task StopProtection()
        {
            #region Snippet:Manage_IaaSVM_StopProtection
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());

            string subscriptionId = "00000000-0000-0000-0000-000000000000";
            string resourceGroupName = "MyResourceGroup";
            string vaultName = "MyRecoveryServicesVault";
            string vmResourceGroup = "MyVMResourceGroup";
            string vmName = "MyVM";

            string fabricName = "Azure";
            string containerName = $"IaasVMContainer;iaasvmcontainerv2;{vmResourceGroup};{vmName}";
            string protectedItemName = $"VM;iaasvmcontainerv2;{vmResourceGroup};{vmName}";

            ResourceIdentifier containerId = BackupProtectionContainerResource.CreateResourceIdentifier(
                subscriptionId, resourceGroupName, vaultName, fabricName, containerName);
            BackupProtectionContainerResource container = armClient.GetBackupProtectionContainerResource(containerId);
            BackupProtectedItemCollection protectedItems = container.GetBackupProtectedItems();

            BackupProtectedItemData data = new BackupProtectedItemData(default)
            {
                Properties = new IaasComputeVmProtectedItem
                {
                    ProtectionState = BackupProtectionState.ProtectionStopped,
                    SourceResourceId = new ResourceIdentifier(
                        $"/subscriptions/{subscriptionId}/resourceGroups/{vmResourceGroup}" +
                        $"/providers/Microsoft.Compute/virtualMachines/{vmName}"),
                },
            };

            ArmOperation<BackupProtectedItemResource> operation =
                await protectedItems.CreateOrUpdateAsync(WaitUntil.Completed, protectedItemName, data);

            Console.WriteLine($"Protection stopped (data retained). Resource ID: {operation.Value.Data.Id}");
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DoNotUse()
        {
            #region Snippet:Manage_IaaSVM_DoNotUse
            // *** INCORRECT - DO NOT DO THIS ***
            BackupProtectedItemData data = new BackupProtectedItemData(default)
            {
                Properties = new IaasVmProtectedItem  // WRONG! This is the base class.
                {
                    SourceResourceId = new ResourceIdentifier("..."),
                    PolicyId = new ResourceIdentifier("..."),
                },
            };
            // This will result in: 400 BadRequest - "AzureIaaSVMProtectedItem is not in correct format"
            #endregion
        }
    }
}

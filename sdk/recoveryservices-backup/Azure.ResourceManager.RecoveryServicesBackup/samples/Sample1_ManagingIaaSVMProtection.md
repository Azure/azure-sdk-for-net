# Example: Managing IaaS VM Backup Protection

> Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:
```C# Snippet:Manage_IaaSVM_Protection_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.RecoveryServicesBackup.Models;
```

When you first create your ARM client, choose the subscription you're going to work in. You can use the `GetDefaultSubscription`/`GetDefaultSubscriptionAsync` methods to return the default subscription configured for your user:

```C# Snippet:Readme_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = armClient.GetDefaultSubscription();
```

## Understanding IaaS VM Protected Item Types

When enabling backup protection for Azure Virtual Machines, use the `IaasComputeVmProtectedItem` class for ARM (Azure Resource Manager) VMs. This class sets the `protectedItemType` to `"Microsoft.Compute/virtualMachines"`.

> **Important:** 
> - **Classic (ASM) Virtual Machines are no longer supported** by Azure Backup. Only ARM VMs are supported.
> - Do **not** use the base class `IaasVmProtectedItem` directly. It sets `protectedItemType` to `"AzureIaaSVMProtectedItem"` which the service does not accept for the `ConfigureProtection` operation. Using it will result in a `400 BadRequest` error: *"AzureIaaSVMProtectedItem is not in correct format"*.

---

## Enable Protection on an ARM Virtual Machine

This example shows how to enable backup protection on an Azure Resource Manager VM using the `IaasComputeVmProtectedItem` class.

```C# Snippet:Manage_IaaSVM_EnableProtection_ARM
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
```

---

## Modify Protection Policy on an Existing Protected Item

To change the backup policy on a VM that is already protected, use the same `CreateOrUpdate` operation with the new policy ID.

```C# Snippet:Manage_IaaSVM_ModifyProtection
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
```

---

## Stop Protection with Retain Data

To stop protection while retaining existing backup data, set `ProtectionState` to `ProtectionStopped`.

```C# Snippet:Manage_IaaSVM_StopProtection
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
```

---

## Common Mistakes

### Using the base class `IaasVmProtectedItem` directly

```C# Snippet:Manage_IaaSVM_DoNotUse
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
```

**Why?** The base class `IaasVmProtectedItem` sets `protectedItemType` to `"AzureIaaSVMProtectedItem"`. The service expects the specific discriminator `"Microsoft.Compute/virtualMachines"` for ARM VMs. Always use `IaasComputeVmProtectedItem` for ARM virtual machines.

> **Note:** Classic (ASM) Virtual Machines are no longer supported by Azure Backup. If you have existing Classic VMs, they should be migrated to ARM VMs.

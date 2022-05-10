# Example: Managing the Key vaults

>Note: Before getting started with the samples, go through the [prerequisites](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#prerequisites).

Namespaces for this example:

```C# Snippet:Manage_KeyVaults_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.KeyVault.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
```

When you first create your ARM client, choose the subscription you're going to work in. You can use the `GetDefaultSubscription`/`GetDefaultSubscriptionAsync` methods to return the default subscription configured for your user:

```C# Snippet:Readme_DefaultSubscription
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
```

This is a scoped operations object, and any operations you perform will be done under that subscription. From this object, you have access to all children via collection objects. Or you can access individual children by ID.

```C# Snippet:Readme_GetResourceGroupCollection
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
// With the collection, we can create a new resource group with an specific name
string rgName = "myRgName";
AzureLocation location = AzureLocation.WestUS2;
ResourceGroupResource resourceGroup = await rgCollection.CreateOrUpdate(WaitUntil.Completed, rgName, new ResourceGroupData(location)).WaitForCompletionAsync();
```

Now that we have the resource group created, we can manage the Key vault inside this resource group.

***Create a vault***

```C# Snippet:Managing_KeyVaults_CreateAVault
VaultCollection vaultCollection = resourceGroup.GetVaults();

string vaultName = "myVault";
Guid tenantIdGuid = new Guid("Your tenantId");
string objectId = "Your Object Id";
IdentityAccessPermissions permissions = new IdentityAccessPermissions
{
    Keys = { new KeyPermission("all") },
    Secrets = { new SecretPermission("all") },
    Certificates = { new CertificatePermission("all") },
    Storage = { new StoragePermission("all") },
};
AccessPolicyEntry AccessPolicy = new AccessPolicyEntry(tenantIdGuid, objectId, permissions);

VaultProperties VaultProperties = new VaultProperties(tenantIdGuid, new KeyVaultSku(KeyVaultSkuFamily.A, KeyVaultSkuName.Standard));
VaultProperties.EnabledForDeployment = true;
VaultProperties.EnabledForDiskEncryption = true;
VaultProperties.EnabledForTemplateDeployment = true;
VaultProperties.EnableSoftDelete = true;
VaultProperties.VaultUri = new Uri("http://vaulturi.com");
VaultProperties.NetworkAcls = new NetworkRuleSet()
{
    Bypass = "AzureServices",
    DefaultAction = "Allow",
    IPRules =
    {
        new IPRule("1.2.3.4/32"),
        new IPRule("1.0.0.0/25")
    }
};
VaultProperties.AccessPolicies.Add(AccessPolicy);

VaultCreateOrUpdateContent parameters = new VaultCreateOrUpdateContent(AzureLocation.WestUS, VaultProperties);

var rawVault = await vaultCollection.CreateOrUpdateAsync(WaitUntil.Started, vaultName, parameters).ConfigureAwait(false);
VaultResource vault = await rawVault.WaitForCompletionAsync();
```

***List all vaults***

```C# Snippet:Managing_KeyVaults_ListAllVaults
VaultCollection vaultCollection = resourceGroup.GetVaults();

AsyncPageable<VaultResource> response = vaultCollection.GetAllAsync();
await foreach (VaultResource vault in response)
{
    Console.WriteLine(vault.Data.Name);
}
```

***Get a vault***

```C# Snippet:Managing_KeyVaults_GetAVault
VaultCollection vaultCollection = resourceGroup.GetVaults();

VaultResource vault = await vaultCollection.GetAsync("myVault");
Console.WriteLine(vault.Data.Name);
```

***Delete a vault***

```C# Snippet:Managing_KeyVaults_DeleteAVault
VaultCollection vaultCollection = resourceGroup.GetVaults();

VaultResource vault = await vaultCollection.GetAsync("myVault");
await vault.DeleteAsync(WaitUntil.Completed);
```

# Release History

## 1.0.0-beta.5 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.4 (2021-12-07)

### Breaking Changes

- Unified the identification rule of detecting resources, therefore some resources might become non-resources, and vice versa.

### Bugs Fixed

- Fixed problematic internal parameter invocation from the context `Id` property to the corresponding `RestOperations`.

## 1.0.0-beta.3 (2021-10-28)

### Breaking Changes

- Renamed [Resource]Container to [Resource]Collection and added the IEnumerable<T> and IAsyncEnumerable<T> interfaces to them making it easier to iterate over the list in the simple case.

## 1.0.0-beta.2 (2021-09-14)

### Features Added

- Added ArmClient extension methods to support [start from the middle scenario](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#managing-existing-resources-by-id).

## 1.0.0-beta.1 (2021-08-31)

### Breaking Changes

Guidance to migrate from previous version of Azure Management SDK

### General New Features

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing
    - HTTP pipeline with custom policies
    - Better error-handling
    - Support uniform telemetry across all languages

> NOTE: For more information about unified authentication, please refer to [Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet)

#### Package Name
The package name has been changed from `Microsoft.Azure.Management.KeyVault` to `Azure.ResourceManager.KeyVault`

#### Management Client Changes

Example: Create a Key Vault Instance:

Before upgrade:
```C#
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Rest;

var tokenCredentials = new TokenCredentials("YOUR ACCESS TOKEN");
var keyVaultManagementClient = new KeyVaultManagementClient(tokenCredentials);
var vault = await keyVaultManagementClient.Vaults.BeginCreateOrUpdateAsync
                (
                    resourceGroupName,
                    vaultName,
                    parameters
                );
```

After upgrade:
```C# Snippet:Changelog_NewCode
using Azure.Identity;
using Azure.ResourceManager.KeyVault;
using Azure.ResourceManager.KeyVault.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using System;
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync("myRgName");

VaultCollection vaultCollection = resourceGroup.GetVaults();
VaultCreateOrUpdateParameters parameters = new VaultCreateOrUpdateParameters(Location.WestUS2, new VaultProperties(Guid.NewGuid(), new Sku(SkuFamily.A, SkuName.Standard)));

VaultCreateOrUpdateOperation lro = await vaultCollection.CreateOrUpdateAsync("myVaultName", parameters);
Vault vault = lro.Value;
```

#### Object Model Changes

Example: Create a Permissions Model

Before upgrade:
```C#
VaultProperties properties = new VaultProperties(Guid.NewGuid(), new Sku(SkuFamily.A, SkuName.Standard));
VaultCreateOrUpdateParameters parameters = new VaultCreateOrUpdateParameters(Location.WestUS2, properties);
```

After upgrade:
```C# Snippet:Changelog_CreateModel
VaultProperties properties = new VaultProperties(Guid.NewGuid(), new Sku(SkuFamily.A, SkuName.Standard));
VaultCreateOrUpdateParameters parameters = new VaultCreateOrUpdateParameters(Location.WestUS2, properties);
```

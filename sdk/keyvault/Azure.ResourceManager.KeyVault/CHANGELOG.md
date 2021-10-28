# Release History

## 1.0.0-beta.3 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
```csharp
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
```csharp
using Azure.Identity;
using Azure.ResourceManager.KeyVault;
using Azure.ResourceManager.KeyVault.Models;

ArmClient client = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroup resourceGroup = await subscription.GetResourceGroups().GetAsync("myRgName");

VaultContainer vaultContainer = resourceGroup.GetVaults();

VaultCreateOrUpdateOperation lro = await vaultsOperations.CreateOrUpdateAsync(vaultName, parameters);
Vault vault = lro.Value;

```

#### Object Model Changes

Example: Create a Permissions Model

Before upgrade:
```csharp
var permissions = new Permissions
                {
                    Keys = new string[] { "all" },
                    Secrets = new string[] { "all" },
                    Certificates = new string[] { "all" },
                    Storage = new string[] { "all" },
                }
```

After upgrade:
```csharp
var permissions = new Permissions
            {
                Keys = new [] { new KeyPermissions("all") },
                Secrets = new [] { new SecretPermissions("all") },
                Certificates = new [] { new CertificatePermissions("all") },
                Storage = new [] { new StoragePermissions("all") },
            };
```

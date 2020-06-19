# Release History

## 1.0.0-preview.1

This package follows the new Azure SDK guidelines which provide a number of core capabilities that are shared amongst all Azure SDKs, including the intuitive Azure Identity library, an HTTP Pipeline with custom policies, error-handling, distributed tracing, and much more.

This is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

### General New Features

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing
    - HTTP pipeline with custom policies
    - Better error-handling
    - Support uniform telemetry across all languages

> NOTE: For more information about unified authentication, please refer to [Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet)

### Migration from Previous Version of Azure Management SDK

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

var keyVaultManagementClient = new KeyVaultManagementClient(
            subscriptionId,
            new DefaultAzureCredential(),
            new KeyVaultManagementClientOptions());
var vaultsOperations = keyVaultManagementClient.Vaults;

var vault = await vaultsOperations.StartCreateOrUpdateAsync(
            resourceGroupName,
            vaultName,
            parameters
            );
var vaultValue = (await vault.WaitForCompletionAsync()).Value;

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

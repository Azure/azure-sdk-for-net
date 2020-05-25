# Release History

## 1.0.0-preview.1

This is public preview version based on Azure Core. This version uses a next-generation code generator that introduces important new features.

### General New Features

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing
    - Support uniform telemetry across all languages

### Migration from Previous Version of Azure Management SDK

#### Package Name
The package name has been changed from `Microsoft.Azure.Management.KeyVault` to `Azure.Management.KeyVault`

#### Create Key Vault

Before
```csharp
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.KeyVault.Models;

var keyVaultManagementClient = new KeyVaultManagementClient(credentials);
var vault = await keyVaultManagementClient.Vaults.BeginCreateOrUpdateAsync
                (
                    resourceGroupName,
                    vaultName,
                    parameters
                );
```

After
```csharp
using Azure.Identity;
using Azure.Management.KeyVault;
using Azure.Management.KeyVault.Models;

var keyVaultManagementClient = new KeyVaultManagementClient(SubscriptionId,
            new DefaultAzureCredential(),
            new KeyVaultManagementClientOptions());
var vaultsClient = keyVaultManagementClient.GetVaultsClient();

var vault = await vaultsClient.StartCreateOrUpdateAsync(
            resourceGroupName,
            vaultName,
            parameters
            );
var vaultValue = (await vault.WaitForCompletionAsync()).Value;

```

#### Create Model Permissions

Before
```csharp
var permissions = new Permissions
                {
                    Keys = new string[] { "all" },
                    Secrets = new string[] { "all" },
                    Certificates = new string[] { "all" },
                    Storage = new string[] { "all" },
                }
```

After
```csharp
var permissions = new Permissions
            {
                Keys = new KeyPermissions[] { new KeyPermissions("all") },
                Secrets = new SecretPermissions[] { new SecretPermissions("all") },
                Certificates = new CertificatePermissions[] { new CertificatePermissions("all") },
                Storage = new StoragePermissions[] { new StoragePermissions("all") },
            };
```

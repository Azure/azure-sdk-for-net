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

### Bugs Fixed

- Fixed bug when using `GetDeletedAccountsAsync` would cause error.

## 1.0.0-beta.1 (2021-09-01)

This package follows the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html) which provide a number of core capabilities that are shared amongst all Azure SDKs, including the intuitive Azure Identity library, an HTTP Pipeline with custom policies, error-handling, distributed tracing, and much more.

This is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

### General New Features

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing
    - HTTP pipeline with custom policies
    - Better error-handling
    - Support uniform telemetry across all languages

> NOTE: For more information about unified authentication, please refer to [Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet)

#### Package Name
The package name has been changed from `Microsoft.Azure.Management.Storage` to `Azure.ResourceManager.Storage`

#### Management Client Changes

Example: Create a storage account:

Before upgrade:
```csharp
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest;

var credentials = new TokenCredentials("YOUR ACCESS TOKEN");
var storageManagementClient = new StorageManagementClient(credentials);
storageManagementClient.SubscriptionId = subscriptionId;

StorageAccountCreateParameters parameters = new StorageAccountCreateParameters
{
    Location = "westus",
    Tags = new Dictionary<string, string>
            {
                {"key1","value1"},
                {"key2","value2"}
            },
    Sku = new Sku { Name = SkuName.StandardGRS },
    Kind = Kind.Storage,
};
storageManagementClient.StorageAccounts.Create(resourceGroupName, accountName, parameters);
```

After upgrade:
```C# Snippet:Create_Storage_Account
using System.Collections.Generic;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Storage.Models;
string accountName = "myaccount";
string resourceGroupName = "myResourceGroup";
ArmClient client = new ArmClient(new DefaultAzureCredential());
ResourceGroup resourceGroup = client.GetDefaultSubscription().GetResourceGroups().Get(resourceGroupName);
StorageAccountCollection storageAccountCollection = resourceGroup.GetStorageAccounts();
Sku sku = new Sku(SkuName.PremiumLRS);
StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(new Sku(SkuName.StandardGRS), Kind.Storage, Location.WestUS);
parameters.Tags.Add("key1", "value1");
parameters.Tags.Add("key2", "value2");
StorageAccount account = storageAccountCollection.CreateOrUpdate(accountName, parameters).Value;
```

#### Object Model Changes

Example: Create one Encryption Model

Before upgrade:
```csharp
var encryption = new Encryption()
     {
         Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } },
         KeySource = KeySource.MicrosoftStorage
     };
```

After upgrade:
```csharp
var encryption = new Encryption(KeySource.MicrosoftStorage)
    {
        Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } }
    };
```

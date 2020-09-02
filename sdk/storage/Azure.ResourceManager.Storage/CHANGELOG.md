# Release History

## 1.0.0-preview.2 (Unreleased)


## 1.0.0-preview.1

This package follows the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html) which provide a number of core capabilities that are shared amongst all Azure SDKs, including the intuitive Azure Identity library, an HTTP Pipeline with custom policies, error-handling, distributed tracing, and much more.

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
```csharp
using Azure.Identity;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;

var storageManagementClient = new StorageManagementClient(subscriptionId, new DefaultAzureCredential());
var storageAccountsOperations = storageManagementClient.StorageAccounts;

var parameters = new StorageAccountCreateParameters(new Sku(SkuName.StandardGRS), Kind.Storage, "westus")
    {
        Tags = new Dictionary<string, string>
            {
                {"key1","value1"},
                {"key2","value2"}
            }
    };
var accountResponse = await storageAccountsOperations.StartCreateAsync(resourceGroupName, accountName, parameters);
StorageAccount account = await accountResponse.WaitForCompletionAsync();
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

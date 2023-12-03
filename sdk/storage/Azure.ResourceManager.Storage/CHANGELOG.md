# Release History

## 1.3.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.2.0 (2023-11-21)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.2.0-beta.2 (2023-08-14)

### Features Added

- Make `StorageArmClientMockingExtension`, `StorageResourceGroupMockingExtension`, `StorageSubscriptionMockingExtension` public for mocking the extension methods.

## 1.2.0-beta.1 (2023-05-31)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.1.1 (2023-02-14)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.1.0 (2022-12-06)

### Bugs Fixed

- Renamed `ExpiresOn` to `ExpireOn`.

### Other Changes

- Upgraded API version to 2022-09-01

## 1.0.0 (2022-09-08)

This package is the first stable release of the Azure Storage management library.

### Other Changes

- Optimized the implementation of methods related to tag operations.

## 1.0.0-beta.12 (2022-08-18)

This package is the RC release of the Azure Storage management library.

### Breaking Changes

- Various naming changes according to review comments.
- Changed the return type of the method `RestoreBlobRanges` to `StorageAccountRestoreBlobRangesOperation`.

### Other Changes

- Upgraded API version to 2022-05-01

## 1.0.0-beta.11 (2022-07-21)

This package is the RC release of the Azure Storage management library.

### Features Added

- Added Update methods in resource classes.

### Breaking Changes

Polishing since last public beta release:
- Prepended `Storage` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `ResouceType` type properties / parameters.
- Corrected the format of all `ETag` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected the format of all binary type properties / parameters.
- Corrected all acronyms that don't follow [Microsoft .NET Naming Guidelines](https://docs.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected enumeration name by following [Naming Enumerations Rule](https://docs.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the name of interval / duration properties / parameters that end with units.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.2.0
- Upgraded dependent `Azure.Core` to 1.25.0

## 1.0.0-beta.10 (2022-06-24)

### Breaking Changes

- Base type of `BlobContainerData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `FileShareData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `ImmutabilityPolicyData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Type `AzureEntityResource` was removed.

## 1.0.0-beta.9 (2022-05-13)

### Breaking Changes

- Flattened property from a read-only model no longer has setters.
- The type of flattened primitive property changed to its corresponding nullable type.
- Renamed class `PrivateLinkResource` to `StoragePrivateLinkResource`.
- Added an `Update` method using the implementation of `CreateOrUpdate` if the resource previously doesn't have a `Update` method.

## 1.0.0-beta.8 (2022-04-08)

### Breaking Changes

- Simplify `type` property names.
- Normalized the body parameter type names for PUT / POST / PATCH operations if it's only used as input.

### Other Changes

- Upgrade dependency to Azure.ResourceManager 1.0.0

## 1.0.0-beta.7 (2022-03-31)

### Breaking Changes

- Now all the resource classes would have a `Resource` suffix (if it previously doesn't have one).
- Renamed some models to more comprehensive names.
- `bool waitForCompletion` parameter in all long running operations were changed to `WaitUntil waitUntil`.
- All properties of the type `object` were changed to `BinaryData`.
- Removed `GetIfExists` methods from all the resource classes.

## 1.0.0-beta.6 (2022-01-30)

### Features Added

- Bump API version to `2021-08-01`

### Breaking Changes

- `waitForCompletion` is now a required parameter and moved to the first parameter in LRO operations
- Move optional body parameters right after required parameters

## 1.0.0-beta.5 (2021-12-28)

### Features Added

- Added `CreateResourceIdentifier` for each resource class

### Breaking Changes

- Renamed `CheckIfExists` to `Exists` for each resource collection class
- Renamed `Get{Resource}ByName` to `Get{Resource}AsGenericResource` in `SubscriptionExtensions`

### Bugs Fixed

- Fixed comments for `FirstPageFunc` of each pageable resource class
- Fixed `DateTimeOffset` being serialized to local timezone format

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

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.Storage` to `Azure.ResourceManager.Storage`

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

### Management Client Changes

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
```C# Snippet:Create_Storage_Account_Namespaces
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage.Models;
```
```C# Snippet:Create_Storage_Account
string accountName = "myaccount";
string resourceGroupName = "myResourceGroup";
ArmClient client = new ArmClient(new DefaultAzureCredential());
ResourceGroupResource resourceGroup = client.GetDefaultSubscription().GetResourceGroups().Get(resourceGroupName);
StorageAccountCollection storageAccountCollection = resourceGroup.GetStorageAccounts();
StorageSku sku = new StorageSku(StorageSkuName.PremiumLrs);
StorageAccountCreateOrUpdateContent parameters = new StorageAccountCreateOrUpdateContent(sku, StorageKind.Storage, AzureLocation.WestUS)
{
    Tags =
    {
        ["key1"] = "value1",
        ["key2"] = "value2"
    }
};
StorageAccountResource account = storageAccountCollection.CreateOrUpdate(WaitUntil.Completed, accountName, parameters).Value;
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

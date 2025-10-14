# Release History

## 1.3.3 (2025-09-15)

### Features Added
- Upgraded API version to `2025-05-01`.
- Added support for `IpRules` and `ServiceTags` fields introduced in the new API version.

## 1.3.3 (2025-09-15)

### Features Added

- Upgraded API version to `2025-05-01`.
- Added support for `IpRules` and `ServiceTags` fields introduced in the new API version.

## 1.3.2 (2025-03-26)

### Features Added

- Upgraded API version to `2024-11-01`.

## 1.3.1 (2025-03-11)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.3.0 (2024-07-05)

### Features Added

- Upgraded api-version tag from 'package-2023-02' to 'package-2023-07'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/d1296700aa6cd650970e9891dd58eef5698327fd/specification/keyvault/resource-manager/readme.md

### Other Changes

- Upgraded Azure.Core from 1.39.0 to 1.40.0

## 1.2.3 (2024-05-07)

### Bugs Fixed

- Fixed bicep serialization of flattened properties.

## 1.2.2 (2024-04-29)

### Features Added

- Added `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.

## 1.2.1 (2024-03-23)

### Features Added

- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Added experimental Bicep serialization.

## 1.2.0 (2023-11-21)

### Features Added

- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.2.0-beta.2 (2023-05-30)

### Features Added

- Enabled the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.2.0-beta.1 (2023-05-05)

### Features Added

- Added `Secret` operations
- Added some new properties for `ManagedHsmProperties`

### Other Changes

- Upgraded API version to `2023-02-01`.

## 1.1.0 (2023-02-13)

### Bugs Fixed

- Obsolete tags operations on `KeyVaultPrivateEndpointConnectionResource` which do not work.

### Other Changes

- Renamed property name `DeletionOn` to `DeletedOn`.

## 1.0.0 (2022-07-11)

This release is the first stable release of the Key Vault Management client library.

### Features Added

- Added Update methods in resource classes.

### Breaking Changes

Polishing since last public beta release:
- Prepended `KeyVault` / `ManagedHsm` prefix to all single / simple model names.
- Renamed all `Vault` prefix models to `KeyVault` prefix.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `ResouceType` type properties / parameters.
- Corrected the format of all `ETag` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected the format of all binary type properties / parameters.
- Corrected all acronyms that do not follow [.NET Naming Guidelines](https://learn.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected enumeration name by following [Naming Enumerations Rule](https://learn.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the name of interval / duration properties / parameters that end with units.
- Optimized the name of some models and functions.
- Correct inherits
  - Base type of `KeyVaultPrivateEndpointConnectionData` changed to `Azure.ResourceManager.Models.ResourceData`.
  - Base type of `ManagedHsmData` changed to `Azure.ResourceManager.Models.ResourceData`.
  - Base type of `ManagedHsmPrivateEndpointConnectionData` changed to `Azure.ResourceManager.Models.ResourceData`.
  - Type `KeyVaultResourceData` was removed.
  - Base type of `ManagedHsmPrivateLinkResourceData` changed to `Azure.ResourceManager.Models.ResourceData`.
  - Type `ManagedHsmTrackedResourceData` was removed.
  - Base type of `PrivateLinkResourceData` changed to `Azure.ResourceManager.Models.ResourceData`.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.2.0
- Upgraded dependent `Azure.Core` to 1.25.0

## 1.0.0-beta.8 (2022-04-08)

### Breaking Changes

- Simplified `type` property names.
- Normalized the body parameter type names for PUT / POST / PATCH operations if it is only used as input.

### Other Changes

- Upgraded dependency to Azure.ResourceManager 1.0.0

## 1.0.0-beta.7 (2022-03-31)

### Breaking Changes

- Now all the resource classes would have a `Resource` suffix (if it previously does not have one).
- Renamed some models to more comprehensive names.
- `bool waitForCompletion` parameter in all long running operations were changed to `WaitUntil waitUntil`.
- Removed `GetIfExists` methods from all the resource classes.
- All properties of the type `object` were changed to `BinaryData`.

## 1.0.0-beta.6 (2022-01-29)

### Breaking Changes

- waitForCompletion is now a required parameter and moved to the first parameter in LRO operations.
- Removed GetAllAsGenericResources in [Resource]Collections.
- Added Resource constructor to use ArmClient for ClientContext information and removed previous constructors with parameters.
- Couple of renamings.

## 1.0.0-beta.5 (2021-12-28)

### Features Added

- Added `CreateResourceIdentifier` for each resource class

### Breaking Changes

- Renamed `CheckIfExists` to `Exists` for each resource collection class
- Renamed `Get{Resource}ByName` to `Get{Resource}AsGenericResources` in `SubscriptionExtensions`

### Bugs Fixed

- Fixed comments for `FirstPageFunc` of each pageable resource class

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

New design of track 2 initial commit.

#### Package Name

The package name has been changed from `Microsoft.Azure.Management.KeyVault` to `Azure.ResourceManager.KeyVault`。

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

#### Management Client Changes

Example: Create a Key Vault Instance:

Before upgrade:

```C#
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Rest;
```

```C#
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

```C# Snippet:Changelog_Namespaces
using System;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.KeyVault;
using Azure.ResourceManager.KeyVault.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
```

```C# Snippet:Changelog_NewCode
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync("myRgName");

KeyVaultCollection vaultCollection = resourceGroup.GetKeyVaults();
KeyVaultCreateOrUpdateContent parameters = new KeyVaultCreateOrUpdateContent(AzureLocation.WestUS2, new KeyVaultProperties(Guid.NewGuid(), new KeyVaultSku(KeyVaultSkuFamily.A, KeyVaultSkuName.Standard)));

ArmOperation<KeyVaultResource> lro = await vaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, "myVaultName", parameters);
KeyVaultResource vault = lro.Value;
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
KeyVaultProperties properties = new KeyVaultProperties(Guid.NewGuid(), new KeyVaultSku(KeyVaultSkuFamily.A, KeyVaultSkuName.Standard));
KeyVaultCreateOrUpdateContent parameters = new KeyVaultCreateOrUpdateContent(AzureLocation.WestUS2, properties);
```

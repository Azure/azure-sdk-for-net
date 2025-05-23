# Release History

## 1.6.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.5.0 (2024-09-15)

### Features Added

- Upgraded api-version tag from 'package-2024-02' to 'package-2024-07'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/d85634405ec3b905f1b0bfc350e47cb704aedb61/specification/batch/resource-manager/readme.md.
  - Add NetworkSecurityPerimeter support
    - Added `GetNetworkSecurityPerimeterConfigurations` api on `BatchAccountResource` definition.
    - Added `GetNetworkSecurityPerimeterConfiguration` api on `BatchAccountResource` definition.
    - Added `GetAll` api on `NetworkSecurityPerimeterConfigurationCollection` definition.
    - Added `GetAll` api on `NetworkSecurityPerimeterConfigurationCollection` definition.
    - Added `Exists` api on `NetworkSecurityPerimeterConfigurationCollection` definition.
    - Added `GetIfExists` api on `NetworkSecurityPerimeterConfigurationCollection` definition.
    - Added `GetNetworkSecurityPerimeterConfigurationResource` api on `ArmClient` definition.
    - Added `ReconcileConfiguration` api on `NetworkSecurityPerimeterConfigurationResource` definition.

  - Added `SharedGalleryImageId` and `CommunityGalleryImageId` to `BatchImageReference` definition.
  - Added `SecurityProfile`  to `ManagedDisk` definition.
  - Added `SecuredByPerimeter` to `BatchPublicNetworkAccess` enum.
  - Added `ConfidentialVm` to `BatchSecurityType` enum.
  - Added `ContainerHostBatchBindMounts` to `BatchTaskContainerSettings` definition.

- Added `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.
- Exposed `JsonModelWriteCore` for model serialization procedure.

### Other Changes

- Remove CloudService support from Pools
  - Removed `GetBatchSupportedCloudServiceSkus` api.
  - Removed `BatchCloudServiceConfiguration` from `BatchDeploymentConfiguration`.
- Upgraded Azure.Core from 1.38.0 to 1.42.0.
- Upgraded Azure.ResourceManager from 1.10.2 to 1.13.0.

## 1.4.0 (2024-03-01)

### Features Added

- Add `UpgradePolicy` support to Pool Creation
  - Added `UpgradePolicy` definition.
  - Added `AutomaticOSUpgradePolicy` definition.
  - Added `RollingUpgradePolicy` definition.

- Added `BatchSupportEndOfLife` property to `BatchSupportedSku` definition.

## 1.3.0 (2024-01-18)

### Features Added

- Upgraded api-version tag from 'package-2023-05' to 'package-2023-11'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/408db257fe67fc66d8c66c10881be8d414d5e5f3/specification/batch/resource-manager/readme.md.
- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.10.0.

## 1.3.0-beta.1 (2024-01-09)

### Features Added

- Add `ResourceTags` support to Pool Creation
  - Added `resourceTags` property to `BatchAccountPoolData` definition
  - Added `resourceTags` property to `ArmBatchModelFactory` definition

- Add `SecurityProfile` support to Pool Creation
  - Added `serviceArtifactReference` property to `BatchVmConfiguration`definition
  - Added `securityProfile` property to `BatchVmConfiguration` definition

- Add `ServiceArtifactReference` and `OSDisk` support to Pool Creation
  - Added `standardssd_lrs` value to `BatchStorageAccountType` enum
  - Added `caching` property to `BatchNodePlacementPolicyType` definition
  - Added `managedDisk` property to `BatchNodePlacementPolicyType` definition
  - Added `diskSizeGB` property to `BatchNodePlacementPolicyType` definition
  - Added `writeAcceleratorEnabled` property to `BatchNodePlacementPolicyType` definition

## 1.2.1 (2023-11-27)

### Features Added

- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.2.0 (2023-06-16)

### Features Added

- Added boolean property `enableAcceleratedNetworking` to `NetworkConfiguration`.
    -  This property determines whether this pool should enable accelerated networking, with default value as False.
    - Whether this feature can be enabled is also related to whether an operating system/VM instance is supported, which should align with AcceleratedNetworking Policy ([AcceleratedNetworking Limitations and constraints](https://learn.microsoft.com/azure/virtual-network/accelerated-networking-overview?tabs=redhat#limitations-and-constraints)).
- Added boolean property `enableAutomaticUpgrade` to `VMExtension`.
    - This property determines whether the extension should be automatically upgraded by the platform if there is a newer version of the extension available.
- Added new property `Type` to `ContainerConfiguration`, which now supports two values: `DockerCompatible` and `CriCompatible`.

## 1.2.0-beta.1 (2023-05-25)

### Features Added

- Enabled the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).
- Added `BatchAccountCertificateData.ThumbprintString`, `BatchAccountCertificateCreateOrUpdateContent.ThumbprintString` to return the hexadecimal string representation of the SHA-1 hash of the certificate.
  `BatchAccountCertificateData.Thumbprint`, `BatchAccountCertificateCreateOrUpdateContent.Thumbprint` have been hidden but are still available.

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.1.1 (2023-02-15)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.1.0 (2022-11-11)

### Features Added

- Added new custom enum type `NodeCommunicationMode`.
  - This property determines how a pool communicates with the Batch service.
  - Possible values: Default, Classic, Simplified.
- Added properties `CurrentNodeCommunicationMode` and `TargetNodeCommunicationMode` of type `NodeCommunicationMode` to `BatchAccountPoolData`.

### Other Changes

- Updated descriptions of Certificate related apis to indicate that the apis will be deprecated by Feb 2024.

## 1.0.0 (2022-09-19)

This release is the first stable release of the Batch Management client library.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.3.1
- Optimized the implementation of methods related to tag operations.

## 1.0.0-beta.2 (2022-08-29)

Polishing since last public beta release:
- Prepended `Batch` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `ResouceType` type properties / parameters.
- Corrected the format of all `ETag` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected the format of all binary type properties / parameters.
- Corrected all acronyms that not follow [.Net Naming Guidelines](https://learn.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected enumeration name by following [Naming Enumerations Rule](https://learn.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the name of interval / duration properties / parameters that end with units.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.3.0

## 1.0.0-beta.1 (2022-07-12)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.Batch` to `Azure.ResourceManager.Batch`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

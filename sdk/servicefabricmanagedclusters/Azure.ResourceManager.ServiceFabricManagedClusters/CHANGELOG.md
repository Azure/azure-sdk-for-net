# Release History

## 1.3.0-beta.4 (2025-08-22)

### Features Added

- Upgraded to api-version 2025-06-01-preview.

Cluster features
- EnableOutboundOnlyNodeTypes

Nodetype features
- IsOutboundOnly

Service Endpoint
- NetworkIdentifier

## 1.3.0-beta.3 (2025-06-23)

### Features Added

- Upgraded api-version tag from 'package-2024-09-preview' to 'package-2025-03-preview'. Tag details available at https://github.com/Azure/azure-rest-api-specs/blob/57ce30e761ef4d39e81471cfb732f39043f0b278/specification/servicefabricmanagedclusters/resource-manager/readme.md.

Cluster features
- Fault simulation operations
- AllocatedOutboundPorts
- VMImage

Nodetype features
- Fault simulation operations
- New DiskTypes options PremiumV2_LRS, StandardSSD_ZRS, Premium_ZRS
- SecurityEncryptionType
- New actions Deallocate, Start, Redeploy
- ZoneBalance

## 1.3.0-beta.2 (2024-11-21)

### Features Added

- Upgraded api-version tag from 'package-2024-06-preview' to 'package-2024-09-preview'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/f17b769690a46d858134ee68ef0d89635083b560/specification/servicefabricmanagedclusters/resource-manager/readme.md.

## 1.3.0-beta.1 (2024-11-15)

### Features Added

- Upgraded api-version tag from 'package-2024-04' to 'package-2024-06-01-preview'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/e79d9ef3e065f2dcb6bd1db51e29c62a99dff5cb/specification/servicefabricmanagedclusters/resource-manager/readme.md.
- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.2.0 (2024-06-25)

### Features Added

- Upgraded api-version tag from 'package-2023-12-preview' to 'package-2024-04'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/5539bbe1f023b10ffa3b61c9106cb8d34a27038e/specification/servicefabricmanagedclusters/resource-manager/readme.md.
- Added `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.

### Other Changes

- Upgraded Azure.Core from 1.37.0 to 1.40.0
- Upgraded Azure.ResourceManager from 1.10.1 to 1.12.0

## 1.1.0-beta.4 (2024-02-01)

### Features Added

- Upgraded api-version tag from 'package-2023-03-preview' to 'package-2023-12-preview'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/2ce7ebed8b2fbcce991d2839ba0ba712f9a0d12b/specification/servicefabricmanagedclusters/resource-manager/readme.md
- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Other Changes

- Upgraded Azure.Core from 1.36.0 to 1.37.0
- Upgraded Azure.ResourceManager from 1.9.0 to 1.10.1

## 1.1.0-beta.3 (2023-11-30)

### Features Added

- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.1.0-beta.2 (2023-06-21)

### Features Added

Cluster features
- NatGatewayId
- PublicIpPrefix

NodeType features
- VmSharedGalleryImageId
- SecurityType
- SecureBootEnabled
- EnableNodePublicIP
- VmImagePlan

### Other Changes

- Upgraded API version to 2023-03-01-preview.

## 1.1.0-beta.1 (2023-05-31)

### Features Added

- Enabled the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.1 (2023-02-16)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-09-26)

This release is the first stable release of the Service Fabric Managed Clusters Management library.

### Breaking Changes

Polishing since last public beta release:
- Prepended `ServiceFabricManaged` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `ResouceType` type properties / parameters.
- Corrected the format of all `IPAddress` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected the format of all binary type properties / parameters.
- Corrected all acronyms that not follow [.Net Naming Guidelines](https://learn.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected the name of interval / duration properties / parameters that end with units.
- Optimized the name of some models and functions.

### Other Changes

- Updated the API version to 2022-01-01.
- Upgraded dependent Azure.ResourceManager to 1.3.1.
- Optimized the implementation of methods related to tag operations.

## 1.0.0-beta.1 (2022-08-18)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.ServiceFabricManagedClusters` to `Azure.ResourceManager.ServiceFabricManagedClusters`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

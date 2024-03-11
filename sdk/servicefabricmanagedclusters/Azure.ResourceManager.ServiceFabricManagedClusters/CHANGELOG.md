# Release History

## 1.1.0-beta.5 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.0-beta.4 (2024-02-01)

### Features Added

- Upgraded api-version tag from 'package-2023-03-preview' to 'package-2023-12-preview'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/2ce7ebed8b2fbcce991d2839ba0ba712f9a0d12b/specification/servicefabricmanagedclusters/resource-manager/readme.md
- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Other Changes

- Upgraded Azure.Core from 1.36.0 to 1.37.0
- Upgraded Azure.ResourceManager from 1.9.0 to 1.10.1

## 1.1.0-beta.3 (2023-11-30)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

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

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

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
- Corrected all acronyms that not follow [.Net Naming Guidelines](https://docs.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
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

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

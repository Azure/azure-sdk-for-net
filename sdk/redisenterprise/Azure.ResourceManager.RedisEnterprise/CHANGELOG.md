# Release History

## 1.2.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.0 (2024-02-20)

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Upgraded api-version tag from 'package-2022-01' to 'package-2024-02'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/ecc0170a2005f5f38231ae4dbba40594d3c00a04/specification/redisenterprise/resource-manager/readme.md

### Other Changes

- Upgraded Azure.Core from 1.28.0 to 1.37.0
- Upgraded Azure.ResourceManager from 1.4.0 to 1.10.1

## 1.1.0-beta.2 (2023-11-30)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.1.0-beta.1 (2023-05-31)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).
- Updated api-version to `2023-03-01-preview`
- Added operation Flush
- Added operation group SkusOperations
- Model Cluster has a new parameter encryption
- Model Cluster has a new parameter identity
- Model ClusterUpdate has a new parameter encryption
- Model ClusterUpdate has a new parameter identity

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.
- Model Database has a new parameter system_data
- Model PrivateEndpointConnection has a new parameter system_data
- Model PrivateLinkResource has a new parameter system_data
- Model ProxyResource has a new parameter system_data
- Model Resource has a new parameter system_data
- Model TrackedResource has a new parameter system_data
- Model Cluster has a new parameter system_data

## 1.0.1 (2023-02-20)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-09-19)

This release is the first stable release of the Redis Enterprise Management client library.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.3.1
- Optimized the implementation of methods related to tag operations.

## 1.0.0-beta.2 (2022-08-29)

### Breaking Changes

Polishing since last public beta release:
- Prepended `RedisEnterprise` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `ResouceType` type properties / parameters.
- Corrected the format of all `ETag` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected the format of all binary type properties / parameters.
- Corrected all acronyms that not follow [.Net Naming Guidelines](https://docs.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected enumeration name by following [Naming Enumerations Rule](https://docs.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the name of interval / duration properties / parameters that end with units.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.3.0

## 1.0.0-beta.1 (2022-07-12)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.RedisEnterprise` to `Azure.ResourceManager.RedisEnterprise`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

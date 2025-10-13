# Release History

## 1.6.0 (2025-10-13)

### Breaking Changes

- `CognitiveServicesAccountProperties.NetworkInjections` is now a list of `AINetworkInjection` instead of a single `AINetworkInjection` instance.

### Bugs Fixed

- Fixed mismatched property type for `CognitiveServicesAccountProperties.NetworkInjections`.  

## 1.5.1 (2025-07-28)

### Features Added

- Make `Azure.ResourceManager.CognitiveServices` AOT-compatible.

## 1.5.0 (2025-06-15)

### Other Changes

- Modified naming of Project, Connection, and CapabilityHost methods to use plural form
- Modified parameter names in Project, Connection, and CapabilityHost methods to use name of object being managed instead of "body"

## 1.5.0-beta.1 (2025-05-30)

### Features Added

- Added resource management based on the 2025-04-01-preview Management API:
  - Cognitive Services Account Connections
  - Cognitive Services Account Projects
  - Cognitive Services Account Capability Hosts
  - Cognitive Services Project Connections
  - Cognitive Services Project Capability Hosts

## 1.4.0 (2024-11-19)

### Features Added

- Upgraded api-version tag from 'package-2023-05' to 'package-2024-10'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/399cbac2de1bc0acbed4c9a0a864a9c84da3692e/specification/cognitiveservices/resource-manager/readme.md.

## 1.3.4 (2024-10-23)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.3.3 (2024-05-07)

### Features Added

- Added `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.

### Bugs Fixed

- Fixed bicep serialization of flattened properties.

## 1.3.2 (2024-03-23)

### Features Added

- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Added experimental Bicep serialization.

## 1.3.1 (2023-11-27)

### Features Added

- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.3.0 (2023-06-26)

### Other Changes

- Upgraded API version to `2023-05-01`.
- Added API to list models for a subscription in a region.
- Added API to list usages for a subscription in a region.

## 1.3.0-beta.1 (2023-05-29)

### Features Added

- Enabled the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Bugs Fixed

- Reverted the flattening of `KeyVaultProperties` in `ServiceAccountEncryptionProperties` as service side does not support passing empty object for this property.

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.2.1 (2023-02-20)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.2.0 (2023-01-30)

### Features Added

- Added `CognitiveServicesCommitmentPlanResource` and `CommitmentPlanAccountAssociationResource`.

### Other Changes

- Upgraded API version to `2022-12-01`.

## 1.1.0 (2022-11-02)

### Other Changes

- Upgraded API version to 2022-10-01

## 1.0.0 (2022-08-29)

This release is the first stable release of the Cognitive Services Management client library.

### Breaking Changes

Polishing since last public beta release:
- Prepended `CognitiveServices` prefix to all single / simple model names.
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

The package name has been changed from `Microsoft.Azure.Management.CognitiveServices` to `Azure.ResourceManager.CognitiveServices`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

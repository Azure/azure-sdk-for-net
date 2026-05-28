# Release History

## 1.1.0-beta.6 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.0-beta.5 (2025-03-11)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.1.0-beta.4 (2024-06-26)

### Features Added

- Upgraded api-version tag to new 'package-2024-03-01-preview'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/51031c3dc961c33be93afe1f15d35acfe5999861/specification/help/resource-manager/readme.md.

## 1.1.0-beta.3 (2024-05-10)

### Features Added

- Upgraded api-version tag from 'package-2023-09-01-preview' to 'package-2024-03-01-preview'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/b38632bbd56247985cb0493b128ba048e5fee16b/specification/help/resource-manager/readme.md.
- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Other Changes

- Upgraded Azure.Core from 1.36.0 to 1.39.0
- Upgraded Azure.ResourceManager from 1.9.0 to 1.11.1

## 1.1.0-beta.2 (2023-11-30)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.1.0-beta.1 (2023-11-06)

### Features Added

- Discovery
- GUidedTroubleshooter
- Solutions
- Discovery API contract change

## 1.0.0 (2023-06-06)

This release is the first stable release of the Azure Help management library.

### Breaking Changes

Polishing since last public beta release:
- Prepended `SelfHelp` prefix to all single / simple model names.
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

## 1.0.0-beta.1 (2023-05-04)

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

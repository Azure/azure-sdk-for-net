# Release History

## 1.4.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.3.1 (2025-07-28)

### Features Added

- Make `Azure.ResourceManager.OperationalInsights` AOT-compatible

## 1.3.0 (2025-04-24)

### Features Added

- Upgraded api-version tag from 'package-2022-10' to 'package-2025-02-01'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/b713df239eb640a56fb4b4db9648ad4bf1388e3b/specification/operationalinsights/resource-manager/readme.md.

### Other Changes

- Upgraded Azure.Core from 1.39.0 to 1.45.0
- Upgraded Azure.ResourceManager from 1.12.0 to 1.13.0

## 1.3.0-beta.2 (2025-03-18)

### Bugs Fixed

- Fixed issue #48747, add custom serialization and deserialization methods for `KeyVaultUri` in `OperationalInsightsKeyVaultProperties`

## 1.3.0-beta.1 (2024-10-15)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

### Bugs Fixed

- Fixed [BUG] Wrong request during the LRO of OperationaIInsights - Cluster - PUT #40606.

## 1.2.2 (2024-05-07)

### Features Added

- Added `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.

### Bugs Fixed

- Fixed bicep serialization of flattened properties.

## 1.2.1 (2024-03-23)

### Features Added

- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Added experimental Bicep serialization.

### Bugs Fixed

- Added `IsRetentionInDaysAsDefault`,`IsTotalRetentionInDaysAsDefault` to replace the original `RetentionInDaysAsDefault`, `TotalRetentionInDaysAsDefault` to solve the deserialization issue

## 1.2.0 (2023-11-29)

### Features Added

- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.2.0-beta.1 (2023-05-31)

### Features Added

- Enabled the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.1.0 (2023-02-13)

### Bugs Fixed

- Fixed the deserialization of the `LastSkuUpdatedOn` properties to support multiple `DateTimeOffset` formats that the service may return.

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-11-29)

This package is the first stable release of the Microsoft Azure Operational Insights management client library.

### Breaking Changes

Polishing since last public beta release:
- Prepended `OperationalInsights` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected all acronyms that don't follow [.NET Naming Guidelines](https://learn.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the name of interval / duration properties / parameters that end with units.
- Optimized the name of some models and functions.

## 1.0.0-beta.1 (2022-09-22)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.OperationalInsights` to `Azure.ResourceManager.OperationalInsights`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

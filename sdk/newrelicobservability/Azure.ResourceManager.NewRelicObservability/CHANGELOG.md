# Release History

## 1.2.0-beta.1 (2025-11-05)

### Features Added
Updating the api-version to "2025-05-01-preview"

### Other Changes

- Fixed model naming compliance issues by renaming models that violated Azure SDK guidelines:
  - Renamed `SaaSData` to `NewRelicObservabilitySaaSInfo`
  - Renamed `SaaSResourceDetailsResponse` to `NewRelicObservabilitySaaSResourceDetailsResult`
  - Renamed `LatestLinkedSaaSResponse` to `NewRelicObservabilityLatestLinkedSaaSResult`

## 1.1.1 (2025-03-11)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.1.0 (2024-07-05)

### Features Added

- Upgraded api-version tag from 'package-2022-07-01' to 'package-2024-03-01'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/07d286359f828bbc7901e86288a5d62b48ae2052/specification/newrelic/resource-manager/readme.md.
- Added `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.
- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Other Changes

- Upgraded Azure.Core from 1.36.0 to 1.40.0
- Upgraded Azure.ResourceManager from 1.9.0 to 1.12.0

## 1.0.1 (2023-11-29)

### Features Added

- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.0.0 (2023-06-06)

This release is first stable release for the New Relic Observability Management library.

### Features Added

- Upgraded API version to 2022-07-01

### Breaking Changes

Polishing since last public beta release:
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Optimized the name of some models and functions.

## 1.0.0-beta.2 (2023-05-30)

### Features Added

- Enabled the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

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

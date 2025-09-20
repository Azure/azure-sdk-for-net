# Release History

## 1.2.0-beta.1 (2025-09-17)

### Features Added

- Upgraded api-version tag from 'package-2025-03-01' to 'package-2025-09-01'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/520e1f6bc250b4ce51a22eaa7583cc0b24564b71/specification/quota/resource-manager/readme.md.

## 1.1.0 (2025-02-28)

### Features Added

- Upgraded api-version tag from 'package-2024-12-18-preview' to 'package-2025-03-01'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/8abab3c9c1ff7c4f9d393c2ddb00e5f735289b37/specification/quota/resource-manager/readme.md.

### Bugs Fixed

- Fixed an issue where the GroupQuotaLimits and SubscriptionQuotaAllocations operations were erroring out even though the action completed successfully.

## 1.1.0-beta.3 (2025-01-20)

### Features Added

- Upgraded api-version tag from 'package-2023-06-01-preview' to 'package-2024-12-18-preview'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/55c5a0cd6da80b2700333c01e9a9c6067de9cef0/specification/quota/resource-manager/readme.md.
    - Replaces the GroupQuotaLimitRequest and SubscriptionQuotaAllocationRequest PUT paths with a PATCH operation in both GroupQuotaLimits and SubscriptionQuotaAllocations operations. This ensures no issues with checking for action completeness and is better aligned with the REST API design guidelines.

### Bugs Fixed

- Fixed an issue where the GroupQuotaLimits and SubscriptionQuotaAllocations operations were erroring out even though the action completed successfully.

### Other Changes

- Upgraded Azure.Core from 1.41.0 to 1.44.1
- Upgraded Azure.ResourceManager from 1.12.0 to 1.13.0

## 1.1.0-beta.2 (2024-07-23)

### Features Added

- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Added experimental Bicep serialization.
- Upgraded api-version tag from 'package-2023-02-01' to 'package-2023-06-01-preview'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/d1f4d6fcf1bbb2e71a32bb2079de12f17fedf56a/specification/quota/resource-manager/readme.md.

### Other Changes

- Upgraded Azure.Core from 1.36.0 to 1.41.0
- Upgraded Azure.ResourceManager from 1.9.0 to 1.12.0

## 1.1.0-beta.1 (2023-11-29)

### Features Added

- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.0.0 (2023-06-06)

### Breaking Changes

Polishing since last public beta release:
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `TimeSpan` type properties / parameters.
- Optimized the name of some models and functions.

## 1.0.0-beta.3 (2023-05-31)

### Features Added

- Enabled the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).
- Added support for new version 2023-02-01.

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.0-beta.2 (2023-02-17)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0-beta.1 (2022-09-25)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.Quota` to `Azure.ResourceManager.Quota`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

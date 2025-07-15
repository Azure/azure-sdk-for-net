# Release History

## 1.5.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.4.0 (2025-07-11)

### Features Added

- Upgraded api-version tag from 'package-2023-01-31' to 'package-2024-11-30'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/bf90cab9d5f6060ce1f7775ffac88ed8eda785ca/specification/msi/resource-manager/readme.md.
    - Exposed User-Assigned Identity `IsolationScope` property.

## 1.3.0 (2025-06-13)

### Features Added

- Updated dependencies.

## 1.3.0-beta.1 (2024-10-15)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.2.3 (2024-05-07)

### Bugs Fixed

- Fixed bicep serialization of flattened properties.

## 1.2.2 (2024-04-29)

### Features Added

- Add `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.

## 1.2.1 (2024-03-23)

### Features Added

- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Added experimental Bicep serialization.

## 1.2.0 (2023-11-29)

### Features Added

- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.2.0-beta.1 (2023-05-30)

### Features Added

- Enabled the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.1.0 (2023-02-20)

### Features Added

- Upgraded to API version 2023-01-31.
- Create/Update/Delete federated identity credentials.
- `ListAssociatedResources` method available in `1.1.0-beta.1` version is not added to this stable version.

## 1.1.0-beta.1 (2022-10-19)

### Features Added

- Upgraded to API version 2022-01-31-preview.

## 1.0.0 (2022-07-21)

This release is the first stable release of the Azure Managed Service Identity management library.

### Features Added

- Released stable version.

## 1.0.0-beta.1 (2022-07-06)

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

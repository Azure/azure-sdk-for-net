# Release History

## 1.3.0 (Unreleased)

### Features Added

- Upgraded api-version tag from 'package-2024-02' to 'package-2024-04'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/45ed7d13be79760a39301ff85cc0937f017329de/specification/mobilenetwork/resource-manager/readme.md
- Added `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.

### Other Changes

- Upgraded Azure.Core from 1.38.0 to 1.40.0
- Upgraded Azure.ResourceManager from 1.11.0 to 1.12.0

## 1.2.0 (2024-03-22)

### Features Added

- Upgraded api-version tag from 'package-2023-09' to 'package-2024-02'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/812012235b51ef1edf0e99f6ce9741c2c4c9df9a/specification/mobilenetwork/resource-manager/readme.md.
- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Exposed `JsonModelWriteCore` for model serialization procedure.

### Other Changes

- Upgraded Azure.Core from 1.36.0 to 1.38.0
- Upgraded Azure.ResourceManager from 1.9.0 to 1.10.2

## 1.1.1 (2023-11-29)

### Features Added

- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.1.0 (2023-11-01)

### Features Added

- Updated api-version to `2023-09-01`.

## 1.0.0 (2023-09-05)

This package is the first stable release of the Azure Mobile Network management library.

### Features Added

- Updated api-version to `2023-06-01`.

## 1.0.0-beta.2 (2023-05-30)

### Features Added

- Enabled the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.0-beta.1 (2023-02-01)

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

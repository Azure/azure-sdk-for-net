# Release History

## 1.1.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0 (2025-07-15)

### Features Added

- Upgraded API version to 2025-03-31.

## 1.0.0-beta.4 (2024-10-31)

### Breaking Changes

- Removed FipsApprovedMode Property from CloudHsmClusterProperties. 

## 1.0.0-beta.3 (2024-09-09)

### Features Added

- Upgraded api-version tag from 'package-2023-12-preview' to 'package-2024-06-preview'. Tag detail available at https://github.com/emmeliaAra/azure-rest-api-specs/blob/822584e54ef68907e71ff2919b1045acda1e58ff/specification/hardwaresecuritymodules/resource-manager/readme.md.
- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Added `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.
- Added experimental Bicep serialization.
- Exposed JsonModelWriteCore for model serialization procedure.

## 1.0.0-beta.2 (2023-12-30)

### Features Added

- Upgraded API version to `2023-12-10-preview`.
    - Added support for User Assigned Identity in Azure Cloud HSM
    - Added Backup and Restore Properties in Azure Cloud HSM
- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.0.0-beta.1 (2023-10-30)

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

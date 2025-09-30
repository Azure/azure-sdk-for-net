# Release History

## 1.4.0 (2025-09-30)

### Features Added

- Upgraded api-version tag from 'package-2024-03' to 'package-2025-07-01'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/ec0ec094fc9eae3a75ac16b175a3b596a482003b/specification/storagecache/resource-manager/readme.md.

### Other Changes

- Upgraded Azure.Core from 1.47.3 to 1.49.0

## 1.3.2 (2025-08-27)

### Features Added

- Make `Azure.ResourceManager.StorageCache` AOT-compatible

## 1.3.1 (2025-03-11)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.3.0 (2024-06-03)

### Features Added

- Upgraded api-version tag from 'package-2023-05' to 'package-2024-03'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/cb1185d9961b7dabe002fdb4c3a28c07d130e47e/specification/storagecache/resource-manager/readme.md
    - Adding import jobs resource type.

### Other Changes

- Upgraded Azure.Core from 1.36.0 to 1.39.0
- Upgraded Azure.ResourceManager from 1.9.0 to 1.12.0

## 1.3.0-beta.1 (2024-02-01)

### Features Added

- Upgraded api-version tag from 'package-2023-05' to 'package-preview-2023-11'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/907b79c0a6a660826e54dc1f16ea14b831b201d2/specification/storagecache/resource-manager/readme.md.
    - Enabled Root Squash for Azure Managed Lustre FileSystem using REST API requests.
- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Other changes

- Upgraded Azure.Core from 1.36.0 to 1.37.0
- Upgraded Azure.ResourceManager from 1.9.0 to 1.10.1

## 1.2.0 (2023-11-30)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.2.0-beta.2 (2023-06-28)

### Other Changes

- Upgraded api-version to `2023-05-01`

## 1.2.0-beta.1 (2023-05-31)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.1.0 (2023-04-01)

### Other Changes

- Upgraded api-version to `2023-01-01`
- Upgraded dependent `Azure.Core` to `1.30.0`

## 1.0.1 (2023-02-20)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-09-19)

This release is the first stable release of the Storage Cache Management library.

### Breaking Changes

Polishing since last public beta release:
- Prepended `StorageCache` prefix to all single / simple model names.
- Corrected the format of all `IPAddress` type properties / parameters.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent Azure.ResourceManager to 1.3.1.
- Optimized the implementation of methods related to tag operations.

## 1.0.0-beta.1 (2022-08-29)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.StorageCache` to `Azure.ResourceManager.StorageCache`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

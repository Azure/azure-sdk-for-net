# Release History

## 1.2.0-beta.6 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.2.0-beta.5 (2025-10-15)

### Features Added

- Make `Azure.ResourceManager.HDInsight` AOT-compatible

- Upgraded api-version tag from 'package-2024-08-preview' to 'package-2025-01-preview'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/4c0f7731c93696af01bd2bb9927bf28d2afcbc98/specification/hdinsight/resource-manager/readme.md.
    - Support to use Entra User as cluster administrator credential instead of using username/password during HDInsight cluster creation.
    - Support to update Entra User Information in an existing Entra User enabled HDInsight cluster.

### Other Changes

- Upgraded Azure.Core from 1.42.0 to 1.44.1
- Upgraded Azure.ResourceManager from 1.12.0 to 1.13.0


## 1.2.0-beta.4 (2025-03-11)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

### Bugs Fixed

- Fix HDInsight GetHDInsightClustersAsync Exceptipn: Value cannot be an empty string. (Parameter 'resourceId'). Issue link: https://github.com/Azure/azure-sdk-for-net/issues/45709

## 1.2.0-beta.3 (2024-09-09)

### Features Added

- Upgraded api-version tag from 'package-2023-04-preview' to 'package-2024-08-preview'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/1c47c885e90f2df94d6f2a70c9caeaf9d258e485/specification/hdinsight/resource-manager/readme.md.
    - Support to set IP tags when creating HDInsight cluster.
    - Support to update managed identity of cluster.
    - Enabled manage Azure Monitor Agent logs integration on a HDInsight cluster.
- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Added `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.

### Other Changes

- Upgraded Azure.Core from 1.36.0 to 1.42.0
- Upgraded Azure.ResourceManager from 1.9.0 to 1.12.0

## 1.2.0-beta.2 (2023-11-29)

### Features Added

- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.2.0-beta.1 (2023-06-27)

### Features Added

- Added feature to support selecting use secure channel during creation. The paramter would force to true if the cluster created based on a stroage account that secure transfer enabled, no matter it use 'blob' or 'dfs' type.

### Other Changes

- Upgraded API version to 2023-04-15-preview.

## 1.1.0 (2023-06-27)

This release is the stable release of 1.1.0-beta.1.

### Other Changes

- Upgraded dependent Azure.Core to 1.33.0.

## 1.1.0-beta.1 (2023-05-30)

### Features Added

- Enabled the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.1 (2023-02-15)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-09-19)

This release is the first stable release of the HDInsight Management client library.

### Breaking Changes

- Fixed the format of `IPConfiguration.type` to `ResourceType`.
- Renamed the `CreateDate` to `CreatedOn` and changed the format to `DateTimeOffset`.
- Renamed the `LdapsUrls` to `LdapsUris` and changed the format to `Uri`.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.3.1
- Optimized the implementation of methods related to tag operations.

## 1.0.0-beta.2 (2022-08-29)

Polishing since last public beta release:
- Prepended `HDInsight` prefix to all single / simple model names.
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

The package name has been changed from `Microsoft.Azure.Management.HDInsight` to `Azure.ResourceManager.HDInsight`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

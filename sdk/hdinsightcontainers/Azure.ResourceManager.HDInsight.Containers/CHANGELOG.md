# Release History

## 1.0.0-beta.6 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.5 (2025-03-11)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.0.0-beta.4 (2024-08-01)

### Features Added

- Upgraded api-version tag from 'package-preview-2023-11' to 'packagee-preview-2024-05'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/f517936b7f0d1a3049c2afba9392fbbebb8ff3a9/specification/hdinsight/resource-manager/Microsoft.HDInsight/HDInsightOnAks/readme.md.
    - Cluster Pool
        - Enabled get cluster pool upgrade history.
    - Cluster
        - Enabled get cluster upgrade history.
        - Ebabled rollback cluster upgrade.
        - Enabled manage cluster library.
        - Enabled multiple managedIdentity, cluster version is required to be above 1.2.0.
- Added `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.
- Added Bicep serialization.

## 1.0.0-beta.3 (2024-03-23)

### Features Added

- Upgraded api-version tag from 'package-2023-06-preview' to 'package-preview-2023-11'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/a434a5a7ee851abc96218443e66a5ebb57911fee/specification/hdinsight/resource-manager/Microsoft.HDInsight/HDInsightOnAks/readme.md.
    - Cluster Pool
        - Enabled create cluster pool with user network profile.
        - Enabled get cluster pool available upgrade versions.
    - Cluster
        - Enabled create Ranger cluster.
        - Enabled get cluster available upgrade versions.
        - Enabled set internal ingress.
        - Enabled check if the cluster name is available.
        - Enabled upgrade hot fix for cluster.
        - Enabled upgrade node os for cluster.
- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.10.2.

## 1.0.0-beta.2 (2023-11-29)

### Features Added

- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.0.0-beta.1 (2023-08-28)

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

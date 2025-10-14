# Release History

## 1.1.0-beta.1 (2025-06-01)

### Features Added

- Upgraded api-version tag to 'package-2025-06-01'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/3c1ce8207350922f820d20e04547cc4785c758d3/specification/elastic/resource-manager/readme.md.

### Bugs Fixed

- Fixed serialization issue in `ElasticCloudDeployment` where `ElasticsearchServiceUri`, `KibanaServiceUri`, and `KibanaSsoUri` properties would throw `InvalidOperationException` when containing relative URIs. Added custom serialization hooks to handle both absolute and relative URIs by using `OriginalString` for relative URIs instead of `AbsoluteUri`. This resolves issue #50974.

## 1.0.0 (2024-12-26)

This package is the first stable release of the Azure Elastic management library.

### Features Added

- Upgraded api-version tag to 'package-2024-03-01'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/700bd7b4e10d2bd83672ee56fd6aedcf7e195a06/specification/elastic/resource-manager/readme.md.

## 1.0.0-beta.5 (2024-10-01)

### Features Added

- Upgraded api-version tag to 'package-2024-06-15-preview'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/14ac81f2a50ae8dbf5b0fc78c13f809b49ee4375/specification/elastic/resource-manager/readme.md.
- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Added `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.
- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.0.0-beta.4 (2023-11-29)

### Features Added

- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.0.0-beta.3 (2023-05-30)

### Features Added

- Enabled the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.0-beta.2 (2023-02-17)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0-beta.1 (2022-09-22)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.Elastic` to `Azure.ResourceManager.Elastic`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

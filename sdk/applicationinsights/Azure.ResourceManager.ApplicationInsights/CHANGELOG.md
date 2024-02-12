# Release History

## 1.0.0-beta.5 (Unreleased)

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Breaking Changes

### Bugs Fixed

- Fix issue [#38783](https://github.com/Azure/azure-sdk-for-net/issues/38783), change `WorkbookTemplates_ListByResourceGroup` response deserialize type to array.

### Other Changes

## 1.0.0-beta.4 (2023-11-27)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.0.0-beta.3 (2023-05-26)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Breaking Changes

- ComponentLinkedStorageAccountCollection can't be retrieved through ResourceGroupResource any more. Please use ApplicationInsightsComponentResource instead.
- ComponentLinkedStorageAccountResource can't be retrieved through ResourceGroupResource any more. Please use ComponentLinkedStorageAccountCollection instead.
- Resource Name of ApplicationInsightsComponentResource is no longer needed when calling ComponentLinkedStorageAccountCollection's related methods.

### Other Changes

- Upgraded api-version tag from 'package-2020-03-01-preview' to 'package-2022-12-09-only'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/1fea23ac36b111293dc3efc30f725e9ebb790f7f/specification/applicationinsights/resource-manager/readme.md
- Upgraded Azure.Core from 1.28.0 to 1.32.0
- Upgraded Azure.ResourceManager from 1.4.0 to 1.6.0

## 1.0.0-beta.2 (2023-02-16)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0-beta.1 (2022-09-14)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.ApplicationInsights` to `Azure.ResourceManager.ApplicationInsights`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

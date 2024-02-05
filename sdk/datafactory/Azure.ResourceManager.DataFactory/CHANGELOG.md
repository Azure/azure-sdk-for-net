# Release History

## 1.0.0-beta.7 (Unreleased)

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.6 (2024-01-26)

### Features Added

  - Add warehouse linkedService, dataSet
  - Add snowflake v2 linkedService, dataSet
  - Add SalesforceV2 and SalesforceCloudServiceV2 linkedService, dataSet
  - Update MySql & Mariadb LinkedService.json with new properties.

### Bugs Fixed

  - Fix headers and schema definition bug for Azure Function activity and Web Activity.
  - Add metadata Into StoreWriteSettings For Bug Fix.

## 1.0.0-beta.5 (2023-11-16)

### Features Added

- Upgraded API version.
  - Added Some Properties on GoogleAds Connector.
  - Added Support LakeHouse Connector In ADF.
- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

## 1.0.0-beta.4 (2023-09-26)

### Features Added

- Upgraded API version.

### Bugs Fixed

- Fixed an issue that exception throws when `Uri` type field is empty during deserialization of `SelfHostedIntegrationRuntimeStatus`.

## 1.0.0-beta.3 (2023-08-02)

### Features Added

- Supported the new `DataFactoryElement<T>` expression type property.
- Upgraded API version.

### Other Changes

- Upgraded Azure.Core to 1.34.0.
- Upgraded Azure.ResourceManager to 1.7.0.

## 1.0.0-beta.2 (2022-08-29)

### Breaking Changes

Polishing since last public beta release:
- Prepended `DataFactory` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `ResouceType` type properties / parameters.
- Corrected the format of all `ETag` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected the format of all binary type properties / parameters.
- Corrected all acronyms that don't follow [Microsoft .NET Naming Guidelines](https://docs.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected enumeration name by following [Naming Enumerations Rule](https://docs.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the name of interval / duration properties / parameters that end with units.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.3.0

## 1.0.0-beta.1 (2022-07-12)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.DataFactory` to `Azure.ResourceManager.DataFactory`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

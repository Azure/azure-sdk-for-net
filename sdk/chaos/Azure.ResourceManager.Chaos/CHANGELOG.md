# Release History

## 1.2.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.0 (2025-05-22)

### Features Added

 - Update API version to 2025-01-01.

## 1.1.0-beta.3 (2025-05-01)

### Features Added

- Exposed new property in Capability Type resource: "requiredAzureRoleDefinitionIds".

## 1.1.0-beta.2 (2025-03-11)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.1.0-beta.1 (2024-02-27)

### Features Added

 - Update API version to 2024-01-01.
 - Add Tags Support for Experiment resource.

## 1.0.0 (2024-01-17)

This is the first stable release of Chaos client library.

### Features Added

- Update API version to 2023-11-01.
- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.10.0.

## 1.0.0-beta.6 (2023-11-27)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.0.0-beta.5 (2023-09-18)

### Features Added

-   Support for Experiment Query Selectors.

## 1.0.0-beta.4 (2023-05-29)

### Features Added

-   Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

-   Upgraded dependent Azure.Core to 1.32.0.
-   Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.0-beta.3 (2023-02-17)

### Other Changes

-   Upgraded dependent `Azure.Core` to `1.28.0`.
-   Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0-beta.2 (2023-01-05)

### Features Added

-   Added support for scope filtering of targets (currently only supports VMSS availability zones)
-   Added `kind` property to `CapabilityType`

### Bugs Fixed

-   Fixed serialization/deserialization of `TimeSpan` properties to support expected ISO8601 format
-   Fixed parameter mapping in `Capability` resource

## 1.0.0-beta.1 (2022-09-15)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.Chaos` to `Azure.ResourceManager.Chaos`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

# Release History

## 1.2.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.1 (2025-03-11)

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.1.0 (2023-11-30)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.1.0-beta.1 (2023-05-31)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.0 (2023-04-28)

This release is first stable release for the Workloads Management library.

### Breaking Changes
- ACSS: Removed SharedGalleryImageId and ExactVersion from ImageReference.
- Prepended `Sap` to simple model names.
- Optimized the name of some models
- Upgrade dependent `Azure.Core` to `1.30.0`.

## 1.0.0-beta.3 (2023-03-06)

### Features Added

ACSS
  - Child Instances now have instance level Start stop operations.
  - Added support for SAP Trans Fileshare configs
  - Added SAP SID as property for HANA provider
  - Added support for LB and storage details changes
  - Added DiskConfiguration Optional Property
  - Added vmDetails array to SapApplicationServerProperties
  - Modify Output Structure to add disk customization
  - Added resource name customization support

AMS
  - Added operation for SapLandscapeMonitor for Storing SPOG Config.
  - Added sapSid property in os, hana providers
  - Added support for secure communication


### Breaking Changes

  - Removed PhpWorkloads operations and related models.
  - Removed WordPressInstance operations and related models.
  - Removed GetSkus operation and related models.

## 1.0.0-beta.2 (2023-02-16)

### Features Added

- Added operation support to `ArmWorkloadsModelFactory`.

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

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

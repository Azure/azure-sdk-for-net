# Release History

## 1.1.0-beta.1 (Unreleased)

### Features Added

- Added Inctance start/stop support for ASCS and App Instance.
- Added Instance level start/stop support for DB Instance
- Added support for LB and storage details changes.
- Added support for SapLandscapeMonitor.
- Added support for SAP Trans Fileshare configs.
- Added support for secure communication

### Breaking Changes

- Removed PHP Resource Type
- Added `VmDetails` to replace `VirtualMachineId` in SapApplicationServerInstanceData.
- Added `Identity`, `StorageAccountArmId`, `ZoneRedundancyPreference` to SapMonitorData.
- Added a few new states for SapVirtualInstance, for detecting the SAP Software Installation.
- Added SAP SID for HANA provider.
- Added DiskConfiguration Optional property.
- Adding new Endpoint for Storing SPOG Config.

### Bugs Fixed

### Other Changes

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

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

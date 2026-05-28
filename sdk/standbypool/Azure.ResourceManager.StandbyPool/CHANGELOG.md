# Release History

## 1.2.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.0 (2025-05-10)

### Features Added
- Support for Zonal deployments of Container Group Standby Pools.
- Support for Hibernated State in Virtual Machine Standby Pools.
- Exposing StandbyPool Health Status for both Virtual Machine and Container Group Standby Pools in GetRuntimeView API.
- Exposing StandbyPool Prediction Information for both Virtual Machine and Container Group Standby Pools in GetRuntimeView API.

## 1.0.0 (2024-09-10)

### Features Added
- Update the StandbyPool api-version from `package-2023-12-01-preview` to `package-2024-03-01`. This is the first stable API version for Standby Pool RP.
- Added GetRuntimeView for both StandbyVirtualMachinePool and StandbyContainerGroupPool
- Added new properties for StandbyVirtualMachinePool which is Elasticity.MinReadyCapacity.

## 1.0.0-beta.1 (2024-03-27)

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

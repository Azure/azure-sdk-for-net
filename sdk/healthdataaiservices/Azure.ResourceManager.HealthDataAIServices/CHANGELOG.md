# Release History

## 1.1.0-beta.1 (Unreleased)

### Features Added

- Added SKU support for DeidService resources with the following properties:
  - `HealthDataAIServicesSku` model with `Name`, `Tier`, and `Capacity` properties
  - `HealthDataAIServicesSkuTier` enum with `Free`, `Basic`, and `Standard` values
  - `HealthDataAIServicesSkuPatch` model for update operations
- Updated API version to 2026-02-01-preview

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0 (2024-11-11)

### Features Added

This release marks the General Availability (GA) of the package. There are no changes from the previous version, but the API version has been updated.

## 1.0.0-beta.1 (2024-08-15)

### Features Added

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

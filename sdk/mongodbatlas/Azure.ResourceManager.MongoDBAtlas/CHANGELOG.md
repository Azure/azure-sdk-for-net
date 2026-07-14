# Release History

## 1.1.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.0-beta.1 (2026-07-12)

### Features Added

- Added support for API version `2026-03-01-preview`.
- Added `MongoDBAtlasProjectResource`, `MongoDBAtlasProjectCollection`, and related models for managing MongoDB Atlas projects.
- Added `MongoDBAtlasClusterResource`, `MongoDBAtlasClusterCollection`, and related models for managing MongoDB Atlas clusters.
- Added `GetClusterTierRegions` and `TierLimitReached` operations on `MongoDBAtlasProjectResource`.

### Breaking Changes

- Renamed model `ProjectLimitStatus` to `MongoDBAtlasProjectLimitStatus`.
- Renamed model `RegionsByTierResponse` to `MongoDBAtlasRegionsByTierResult`.
- Renamed model `TierLimitReachedResponse` to `MongoDBAtlasTierLimitReachedResult`.
- Renamed model `TierRegions` to `MongoDBAtlasTierRegions`.
- Renamed property `Backups` to `IsBackupsEnabled` in `MongoDBAtlasClusterProperties`.
- Renamed property `FREE` to `Free` in `MongoDBAtlasClusterTier`.
- Renamed property `FLEX` to `Flex` in `MongoDBAtlasClusterTier`.

## 1.0.1 (2026-04-28)

### Other Changes

- Upgraded dependent `Azure.Core` to 1.54.0.
- Upgraded dependent `Azure.ResourceManager` to 1.14.0.

## 1.0.0 (2025-07-03)

### Features Added

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a GA version.

To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

## 1.0.0-beta.1 (2025-05-29)

### Features Added

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

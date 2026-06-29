# Release History

## 1.0.0 (2026-06-15)

### Features Added

- General availability release of the Azure Planetary Computer client library for .NET.
- Full support for STAC API (v1.0.0) operations: collections, items, search, and tiles endpoints.
- Data client with support for rendering data (GetTile, GetPreview, GetStatistics, GetBounds, GetWmtsCapabilities).
- Ingestion client for managing data ingestion workflows.
- Managed Storage Shared Access Signature (SAS) client for secure token generation.
- Full async/await support throughout the SDK.
- Support for .NET 8.0, .NET 10.0, and .NET Standard 2.0.
- Added `PlanetaryComputerProClientSettings` to support creating a `PlanetaryComputerProClient` from `IConfiguration`, including configuration-based credential resolution and dependency injection registration.

### Breaking Changes from Preview

- Method renames to align with GA API specification: All data client methods prefixed with `GetItem*` (e.g., `GetItemBoundsAsync`, `GetItemPreviewAsync`, `GetItemStatisticsAsync`).
- Search operations renamed: `GetMosaics*` → `GetSearch*` methods.
- Parameter type change: `assetBandIndices` changed from `string` to `string[]` in rendering operations.
- Removed static image rendering APIs (`CreateStaticImageAsync`, `GetStaticImageAsync`).
- Collection creation/replacement pattern: Split `CreateOrReplaceCollectionAsync` into separate `CreateCollectionAsync` (with LRO support) and `ReplaceCollectionAsync` methods.

### Removed Features

- Static image rendering endpoints (no longer part of GA API specification).

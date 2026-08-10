# Release History

## 1.0.0 (2026-08-10)

### Features Added

- General availability release of the Azure Planetary Computer client library for .NET.
- Full support for STAC API (v1.0.0) operations: collections, items, search, and tiles endpoints.
- Data client with support for rendering data (GetTile, GetPreview, GetStatistics, GetBounds, GetWmtsCapabilities).
- Ingestion client for managing data ingestion workflows.
- Managed Storage Shared Access Signature (SAS) client for secure token generation.
- Full async/await support throughout the SDK.
- Support for .NET 8.0, .NET 10.0, and .NET Standard 2.0.
- Added `PlanetaryComputerProClientSettings` to support creating a `PlanetaryComputerProClient` from `IConfiguration`, including configuration-based credential resolution and dependency injection registration.
- Data client methods with many parameters use options bag pattern for improved usability (e.g., `GetItemPointAsync(GetItemPointOptions)`).

### Removed Features

- Static image rendering endpoints (no longer part of GA API specification).

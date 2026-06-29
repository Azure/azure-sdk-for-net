# Release History

## 1.1.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0 (2026-06-23)

### Features Added

- Initial GA release of the Azure.ResourceManager.Compute.BulkActions client library, targeting the `Microsoft.Compute` `2026-06-06` stable API version.
- New endpoints were added for the following bulk operations on virtual machines:
    - `BulkStartOperation` / `BulkStartOperationAsync`
    - `BulkDeallocateOperation` / `BulkDeallocateOperationAsync`
    - `BulkHibernateOperation` / `BulkHibernateOperationAsync`
    - `BulkDeleteOperation` / `BulkDeleteOperationAsync`
    - `BulkGetOperationsStatus` / `BulkGetOperationsStatusAsync`
    - `BulkCancelOperations` / `BulkCancelOperationsAsync`

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

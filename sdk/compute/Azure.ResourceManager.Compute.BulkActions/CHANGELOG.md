# Release History

## 1.2.0-beta.1 (Unreleased)

### Features Added

- Added support for the `2026-07-06-preview` API version.
- `Execute*Content` request models now expose an optional `ResourcesWithContext` property, allowing resource ids to be supplied together with per-resource context information. A request supplies exactly one of `Resources` or `ResourcesWithContext`.

### Breaking Changes

- The `Resources` property on the `Execute*Content` request models (`ExecuteStartContent`, `ExecuteDeallocateContent`, `ExecuteHibernateContent`, `ExecuteDeleteContent`) is now optional. The constructor overload that required `resources` (`(BulkActionExecutionParameterDetail executionParameters, UserRequestResources resources)`) has been removed; use the `(BulkActionExecutionParameterDetail executionParameters)` constructor and set `Resources` or `ResourcesWithContext` as needed.

### Bugs Fixed

### Other Changes

## 1.1.0 (2026-07-07)

### Breaking Changes

- The bulk operation methods now require an explicit `AzureLocation` parameter instead of inferring the location from the `ResourceGroupResource`. A resource group's location can differ from the location of the resources it contains, so the location must be supplied by the caller. The following overloads that inferred the location were removed:
    - `BulkStartOperation` / `BulkStartOperationAsync`
    - `BulkDeallocateOperation` / `BulkDeallocateOperationAsync`
    - `BulkHibernateOperation` / `BulkHibernateOperationAsync`
    - `BulkDeleteOperation` / `BulkDeleteOperationAsync`
    - `BulkGetOperationsStatus` / `BulkGetOperationsStatusAsync`
    - `BulkCancelOperations` / `BulkCancelOperationsAsync`

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

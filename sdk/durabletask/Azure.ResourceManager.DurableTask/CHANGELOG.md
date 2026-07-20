# Release History

## 1.2.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.0 (2026-03-12)

### Features Added

This release contains required changes for durable task scheduler private endpoint support. As part of this schedulers can be configured to disable public network access. Additionally, private endpoint connections can be managed and viewed.

- `DurableTaskSchedulerProperties` now includes `PublicNetworkAccess` to enable or disable public network access.
- `DurableTaskSchedulerProperties` now also contain a readonly `PrivateEndpointConnections` collection for any private endpoint connections of this scheduler.
- The `DurableTaskPrivateEndpointConnectionCollection` client allows managing of private endpoint connections, including approving / rejecting connections.

### Other Changes

- Now uses API version `2026-02-01` for all resource management calls.

## 1.0.0 (2025-11-03)

First GA release of the Durable Task Scheduler management SDK

### Other Changes

- Now uses API version `2025-11-01` for all resource manager calls.
- `DurableTaskSchedulerSkuName` now provides constants for the possible Scheduler SKU values.

## 1.0.0-beta.1 (2025-04-24)

Initial release of the Durable Task Scheduler management SDK

### Features Added

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

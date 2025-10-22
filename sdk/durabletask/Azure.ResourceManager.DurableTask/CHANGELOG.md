# Release History

## 1.0.0 (2025-10-13)

First GA release of the Durable Task Scheduler management SDK

### Breaking Changes

- All classes have dropped the `DurableTask` name prefix.
- `DurableTaskHub` classes have been renamed to `SchedulerTaskHub`

### Other Changes

- Now uses API version `2025-11-01` for all resource manager calls.
- `SchedulerSkuName` now provides constants for the possible Sku values.

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

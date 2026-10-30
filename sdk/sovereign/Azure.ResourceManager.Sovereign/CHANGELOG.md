# Release History

## 1.0.0-beta.1 (Unreleased)

### Features Added

This is the first preview release of the Microsoft Azure Sovereign management client library for .NET, generated from TypeSpec with API version `2026-10-31-preview`.

- Added `SovereignViewResource` and `SovereignViewResourceCollection` to manage Sovereign views.
- Added the `CheckNameAvailability` operation, accepting `SovereignCheckNameAvailabilityRequestContent`.

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.
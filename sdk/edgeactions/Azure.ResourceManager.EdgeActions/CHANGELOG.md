# Release History

## 1.0.0 (2026-10-28)

### Features Added

- Initial stable release of the Azure Edge Actions management library for .NET, using service API version `2026-10-01`.
- Supports managing edge actions, versions, code deployments, and execution filters.

## 1.0.0-beta.4 (2026-10-22)

### Features Added

- Updated the default service API version from `2025-12-01-preview` to `2026-10-01`.

### Breaking Changes

- `EdgeActionVersionResource.DeployVersionCode` and `DeployVersionCodeAsync` now return operations with an `EdgeActionVersionResource` result instead of `EdgeActionVersionProperties`. Access the deployed version's properties through `operation.Value.Data.Properties` instead of `operation.Value`.

### Other Changes

- Clarified documentation for PATCH tag replacement and clearing, rejected SKU updates, version deployment-type restrictions, and default-version changes through `SwapDefault`.

## 1.0.0-beta.3 (2026-06-06)

### Other Changes

- Upgraded dependent Azure.Core to 1.58.0.
- Upgraded dependent Azure.ResourceManager to 1.14.0.

## 1.0.0-beta.2 (2026-02-10)

### Features Added

Upgraded to api-version 2025-12-01-preview.

## 1.0.0-beta.1 (2025-12-10)

### Features Added

- Initial preview release of Azure EdgeActions management library for .NET
- Support for managing EdgeAction resources
- Support for managing EdgeActionVersion resources
- Support for managing EdgeActionExecutionFilter resources
- Support for deploying and managing serverless edge functions on Azure Front Door infrastructure

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

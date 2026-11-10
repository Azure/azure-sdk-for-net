# Release History

## 1.1.0-beta.1 (2026-11-10)

### Features Added

- Updated to support API version `2026-06-01`.

### Other Changes

- Retained `ExtensionConfigPropertyType`, `ArmDeploymentExtensionConfigItem.ExtensionConfigPropertyType`, and the existing model factory signature for compatibility with SDK version `1.0.0`, although API version `2026-06-01` no longer defines the extension configuration `type` property.

## 1.0.0 (2026-08-25)

### Features Added

This is the first stable release of ARM deployments library, api-version 2025-04-01.

## 1.0.0-beta.1 (2026-06-30)

This is first release of ARM deployments library.

### Features Added

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

# Release History

## 1.1.0-beta.1 (2025-09-09)

### Other Changes

This package has been deprecated and will no longer be maintained after **March 8, 2026**. Upgrade to the replacement package, **Azure.ResourceManager.Playwright**, to continue receiving updates. Refer to the [migration guide](https://aka.ms/mpt/migration-guidance) for guidance on upgrading. Refer to our [deprecation policy](https://azure.github.io/azure-sdk/policies_support.html) for more details.

## 1.0.0 (2024-12-18)

### Features Added

- Upgraded api-version from '2023-10-01-preview' to '2024-12-01'. Spec detail available at https://github.com/Azure/azure-rest-api-specs/tree/c39acac0b3b7ceeee03b594a7b49c9bad6b8e9f2/specification/playwrighttesting/PlaywrightTesting.Management.
- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.0.0-beta.1 (2024-01-19)

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

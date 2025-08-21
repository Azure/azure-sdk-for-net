# Release History

## 1.0.0-beta.3 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.2 (2025-06-19)

### Features Added

- **Support for Exclusion Filters in Export Operations**:

  - Added `AzureResourcesToExclude` and `TerraformResourcesToExclude` properties to export parameter models,
    these allow users to exclude resources from being exported based on Azure resource ID patterns or Terraform resource types.

- **Authorization Scope Filter Support**:

  - Introduced the `TerraformAuthorizationScopeFilter` struct, enabling fine-grained control over the scope of Azure Resource Graph queries during export.

- **Export Result Enhancements**:
  - The `TerraformExportResult` model now includes an `Import` property, providing Terraform import blocks for exported resources.

- **API Version Updates**:
  - Updated the default API version for Terraform export operations to `2025-06-01-preview` across all relevant classes and REST operations.

## 1.0.0-beta.1 (2024-10-31)

### Features Added

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

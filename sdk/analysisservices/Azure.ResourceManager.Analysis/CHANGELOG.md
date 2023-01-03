# Release History

## 1.0.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.1 (2022-12-05)

### Package Name

The package name has been changed from `Microsoft.Azure.Management.AnalysisServices` to `Azure.ResourceManager.Analysis`

### Breaking Changes

New design of track 2 initial commit.
- Corrected the format of all `uuid` type properties / parameters.
- Corrected the format of all `Uri` type properties / parameters.
- Corrected the format of all `ETag` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected the type of property `ResourceType` of ExistingResourceSkuDetails from `String` to `ResourceType`.
- The value of the int type generates an error when using ToSerialString() for type conversion, so the modelAsString in the corresponding property['x-ms-enum'] is converted to true in the autorest.md
- Corrected all acronyms that don't follow [Microsoft .NET Naming Guidelines](https://docs.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Prepended `AnalysisServices` prefix to all single / simple model names
- Optimized the name of some models and functions.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).


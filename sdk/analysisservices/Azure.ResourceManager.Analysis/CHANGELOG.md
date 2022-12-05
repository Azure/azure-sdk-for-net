# Release History

## 1.0.0-beta.1 (2022-11-29)

### Package Name

The package name has been changed from `Microsoft.Azure.Management.AnalysisServices` to `Azure.ResourceManager.AnalysisServices`

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

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

This package follows the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html) which provide a number of core capabilities that are shared amongst all Azure SDKs, including the intuitive Azure Identity library, an HTTP Pipeline with custom policies, error-handling, distributed tracing, and much more.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

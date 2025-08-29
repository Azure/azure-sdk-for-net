# Release History

## 1.0.0 (2025-09-05)

### Features Added

- Updated versioning for general availability.

## 1.0.0-beta.2 (2024-08-14)

### Breaking Changes

- Adjusted `properties` to be a required parameter in `FabricCapacityData` constructor.
- `FabricExtensions.CheckNameAvailabilityFabricCapacity` renamed to `FabricExtensions.CheckFabricCapacityNameAvailability`.
- The type of `location` parameter in `FabricExtensions.CheckFabricCapacityNameAvailability` changed from `string` to `AzureLocation`.

## 1.0.0-beta.1 (2024-07-25)

### Features Added

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

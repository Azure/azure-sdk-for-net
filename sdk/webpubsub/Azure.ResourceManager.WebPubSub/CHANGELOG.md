# Release History

## 1.0.0-beta.5 (2022-06-28)

### Breaking Changes

- Prepended RP name `WebPubSub` to Private Endpoint related classes.
- Changed `Location` property/parameter type from `string` to `AzureLocation`.
- Changed `TenantId` property type from `string` to `Guid`.

### Features Added

- Added `Update` methods for Resource classes.

### Bugs Fixed

- Fixed serialization/deserialization bugs of `Tags` and `SystemData` properties for models inherited from ResourceData/TrackedResourceData.

## 1.0.0-beta.4 (2022-04-08)

### Breaking Changes

- Simplify `type` property names.
- Normalized the body parameter type names for PUT / POST / PATCH operations if it is only used as input.

### Other Changes

- Upgrade dependency to Azure.ResourceManager 1.0.0

## 1.0.0-beta.3 (2022-03-31)

### Breaking Changes

- The models that are not directly referenced by public API now are internal.
- Now all the resource classes would have a `Resource` suffix (if it previously does not have one)
- waitForCompletion is now a required parameter and moved to the first parameter in LRO operations
- Move optional body parameters right after required parameters
- Location class from `Location` to `AzureLocation`
- Removed `GetIfExists` methods from all the resource classes.

## 1.0.0-beta.2 (2021-12-28)

### Features Added

- Added `CreateResourceIdentifier` for each resource class

### Breaking Changes

- Renamed `CheckIfExists` to `Exists` for each resource collection class
- Renamed `Get{Resource}ByName` to `Get{Resource}AsGenericResources` in `SubscriptionExtensions`

## 1.0.0-beta.1 (2021-12-02)

This package follows the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html) which provide a number of core capabilities that are shared amongst all Azure SDKs, including the intuitive Azure Identity library, an HTTP Pipeline with custom policies, error-handling, distributed tracing, and much more.

This is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

### General New Features

- Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET
- Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing
- HTTP pipeline with custom policies
- Better error-handling
- Support uniform telemetry across all languages

> NOTE: For more information about unified authentication, please refer to [Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet)

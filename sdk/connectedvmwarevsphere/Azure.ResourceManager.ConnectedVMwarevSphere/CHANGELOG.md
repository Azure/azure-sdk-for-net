# Release History

## 1.0.0-beta.3 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.2 (2022-01-29)

- waitForCompletion is now a required parameter and moved to the first parameter in LRO operations.
- Removed GetAllAsGenericResources in [Resource]Collections.
- Added Resource constructor to use ArmClient for ClientContext information and removed previous constructors with parameters.
- Couple of renamings.

## 1.0.0-beta.1 (2022-01-12)

### General New Features

- Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET
- Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing
- HTTP pipeline with custom policies
- Better error-handling
- Support uniform telemetry across all languages

> NOTE: For more information about unified authentication, please refer to [Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet)

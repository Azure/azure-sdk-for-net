# Release History

## 1.0.0 (2022-09-29)

This is the first stable release of the Policy Insights Management library.

### Breaking Changes

Polishing since last public beta release:
- Prepended `Policy` prefix to all single / simple model names.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Optimized the name of some models and functions.
- Corrected the extended types of extension methods related to `PolicyAssignmentResource`, `SubscriptionPolicyDefinitionResource` and `SubscriptionPolicySetDefinitionResource`.

### Other Changes

- Upgraded dependent Azure.ResourceManager to 1.3.1.

## 1.0.0-beta.1 (2022-08-29)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.PolicyInsights` to `Azure.ResourceManager.PolicyInsights`.

### General New Features

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing
    - HTTP pipeline with custom policies
    - Better error-handling
    - Support uniform telemetry across all languages

This package follows the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html) which provide a number of core capabilities that are shared amongst all Azure SDKs, including the intuitive Azure Identity library, an HTTP Pipeline with custom policies, error-handling, distributed tracing, and much more.

This is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

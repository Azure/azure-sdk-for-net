# Release History

## 1.3.0-beta.1 (Unreleased)

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.2.0 (2023-11-29)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Bugs Fixed

- Fixed an issue that `System.UriFormatException` is thrown when `Uri` type field is empty during serialization of `PolicyMetadataData`.
- Fixed an issue that `System.UriFormatException` is thrown when `Uri` type field is empty during serialization of `SlimPolicyMetadata`.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.2.0-beta.1 (2023-05-31)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Bugs Fixed

- Fixed an issue that exception throws when ResourceIdentifier type field is empty during deserialization of PolicyDetails.

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.1.0 (2023-02-16)

### Features Added

- Added two additional fields to Policy Attestations representing `AssessOn` and `Metadata`.

### Other Changes

- Upgraded API version of Policy Attestations to 2022-09-01.
- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-09-29)

This release is the first stable release of the Policy Insights Management library.

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

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).


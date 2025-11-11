# Release History

## 1.3.0-beta.1 (2025-11-12)

### Features Added
- Upgraded api-version tag from 'package-2025-05' to 'package-preview-2025-10'
- Adds new managedDomainList property in DnsSecurityRule to allow users to use managed domain lists such as AzureDnsThreatIntel

### Other Changes
- Domain list is no longer required for a DNS Security rule if managed domain list is being used.

## 1.2.0 (2025-06-10)

### Features Added
- Upgraded api-version tag from 'package-preview-2023-07' to 'package-2025-05'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/8600539fa5ba6c774b4454a401d9cd3cf01a36a7/specification/dnsresolver/resource-manager/readme.md.
- Adds new POST bulk API for large domain list usage.

### Other Changes
- BlockResponseCode has been removed from the DnsSecurityRule Action type in api-version `2025-05-01` from `2023-07-01-preview`.

## 1.2.0-beta.1 (2024-10-24)

### Features Added

- Upgraded api-version tag from 'package-2022-07' to 'package-preview-2023-07'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/b26a190235f162b15d77dad889d104d06871fb4f/specification/dnsresolver/resource-manager/readme.md.
- Add DNS Security Policy functionality for the following resources:
    - DNS Security Policy
    - DNS Security Policy Links
    - Dns Security Rules
    - DNS Resolver Domain Lists
- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Exposed `JsonModelWriteCore` for model serialization procedure.

### Other Changes

- Upgraded Azure.Core from 1.36.0 to 1.44.1
- Upgraded Azure.ResourceManager from 1.9.0 to 1.13.0

## 1.1.0 (2023-11-27)

### Features Added

- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.1.0-beta.1 (2023-05-29)

### Features Added

- Enabled the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.1 (2023-02-14)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-09-23)

This release is the first stable release of the Dns Resolver Management library.

### Breaking Changes

Polishing since last public beta release:
- Prepended `DnsResolver` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `IPAddress` type properties / parameters.
- Corrected the name of all `ETag` type properties / parameters.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded the API version to 2022-07-01.
- Upgraded dependent Azure.ResourceManager to 1.3.1.
- Optimized the implementation of methods related to tag operations.

## 1.0.0-beta.3 (2022-04-08)

### Breaking Changes

- Simplify `type` property names.
- Normalized the body parameter type names for PUT / POST / PATCH operations if it is only used as input.

### Other Changes

- Upgrade dependency to Azure.ResourceManager 1.0.0

## 1.0.0-beta.2 (2022-03-31)

### Breaking Changes

- Now all the resource classes would have a `Resource` suffix (if it previously does not have one).
- Renamed some models to more comprehensive names.
- `bool waitForCompletion` parameter in all long running operations were changed to `WaitUntil waitUntil`.
- All properties of the type `object` were changed to `BinaryData`.
- Removed `GetIfExists` methods from all the resource classes.

## 1.0.0-beta.1 (2022-03-03)

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

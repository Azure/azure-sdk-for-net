# Release History

## 1.1.0-beta.1 (2022-10-14)

### Features Added

- Ability to exclude caller from being an admin on Database create/update.
- EH and IoT hub data connection new property for lookback – start collecting data that was generated a while ago.
- Follower name override/prefix – ability to define either different name for Read-Only-Following DB, or define prefix name for all DBs (in case of full cluster following scenario).
- Enhancing Follower GET-related APIs to improve demonstration of follower-leader linage in Azure portal.

### Breaking Changes

None

### Bugs Fixed

None

### Other Changes

- New API has the following new SKUs: Standard_L8s_v3, Standard_L16s_v3, Standard_L8as_v3, Standard_L16as_v3, Standard_E16s_v5+4TB_PS, Standard_E2d_v4, Standard_E4d_v4, Standard_E8d_v4, Standard_E16d_v4, Standard_E2d_v5, Standard_E4d_v5, Standard_E8d_v5, Standard_E16d_v5.

## 1.0.0 (2022-09-19)

This is the first stable release of the Kusto Management library.

### Breaking Changes

Polishing since last public beta release:
- Prepended `Kusto` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent Azure.ResourceManager to 1.3.1.
- Optimized the implementation of methods related to tag operations.

## 1.0.0-beta.1 (2022-08-18)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.Kusto` to `Azure.ResourceManager.Kusto`.

### General New Features

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing
    - HTTP pipeline with custom policies
    - Better error-handling
    - Support uniform telemetry across all languages

This package follows the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html) which provide a number of core capabilities that are shared amongst all Azure SDKs, including the intuitive Azure Identity library, an HTTP Pipeline with custom policies, error-handling, distributed tracing, and much more.

This is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

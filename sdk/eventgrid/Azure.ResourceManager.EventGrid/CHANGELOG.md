# Release History

## 1.1.0-beta.5 (Unreleased)

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.0-beta.4 (2023-12-12)

### Features Added

- Added support for NSP API's
- Added support for SystemTopic with MonitorDestination.
- Added support for SystemTopic/CustomTopic with NamespaceTopic as destination.
- Added support for Namespace subscription to EventHub.
- Added support for Namespace with deadletter.

## 1.1.0-beta.3 (2023-11-29)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.


## 1.1.0-beta.2 (2023-06-27)

### Features Added

- Added support for Namespace
- Added support for Namespace Topics.
- Added support for Namespace Topic EventSubscriptions.
- Added support for pull events from Namespace topics.
- Added support for Namespace Clients.
- Added support for Namespace ClientGroups.
- Added support for Namespace CaCertificates.
- Added support for Namespace TopicSpaces.
- Added support for Namespace Permission Bindings.

## 1.1.0-beta.1 (2023-05-30)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.1 (2023-02-16)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-11-04)

This package is the first stable release of the Microsoft Azure Event Grid management client library.

### Breaking Changes

Polishing since last public beta release:
- Prepended `EventGrid` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `Uri` type properties / parameters.
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the return type and parameter name of some functions.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent Azure.ResourceManager to 1.3.1.
- Optimized the implementation of methods related to tag operations.

## 1.0.0-beta.1 (2022-08-29)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.EventGrid` to `Azure.ResourceManager.EventGrid`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

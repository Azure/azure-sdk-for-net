# Release History

## 1.2.0-beta.3 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.2.0-beta.2 (2025-09-03)

### Features Added

- Make `Azure.ResourceManager.EventGrid` AOT-compatible

## 1.2.0-beta.1 (2025-06-05)

### Features Added

- Upgraded api-version tag from 'package-2025-02-15' to 'package-2025-04-preview'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/79c3ab8586bd78947815ebf39b66584f67095c2f/specification/eventgrid/resource-manager/readme.md.
    - CustomWebhookAuthentication

### Other Changes

- Upgraded common resource type version from v5 to v6.
- Renamed AAD to Microsoft Entra ID.

## 1.1.0 (2025-03-31)

### Features Added

- Upgraded api-version tag from 'package-2024-06-preview' to 'package-2025-02-15'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/8a059231d92b10d87ffc3f18515516e84dae87cc/specification/eventgrid/resource-manager/readme.md .
   - Namespace resources  (namespace, topic, eventsubscription (Push/Pull) + all mqtt resources (clients, clientgroups, etc)
   - Custom Domains
   - minimumTlsVersion
   - eventTypeInfo
   - RoutingEnrichments
   - MonitorAlert as destination
   - Namespace topic as destination 
   - TopicTypeAdditionalEnforcedPermission

## 1.1.0-beta.6 (2025-03-11)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.1.0-beta.5 (2024-06-05)

### Features Added

- Upgraded api-version tag from 'package-2023-12-preview' to 'package-2024-06-preview'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/82f2cbc667318659fff331022f47b616c01cd2e2/specification/eventgrid/resource-manager/readme.md .
    - Custom domain: put create / post validate / Patch update.
    - Get/POST full URL for namespace topic event subscription.
    - ExpirationTimeUtc for namespace topic eventsubscription
    - Add EventSubscriptionDestination to PushInfo
    - CustomJwtAuthentication
    - One on the NSP properties (subscriptions) returning list of class rather than list of string. 
- Add `ArmOperation.Rehydrate` and `ArmOperation.Rehydrate<T>` static methods to rehydrate a long-running operation.
- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Other Changes

- Upgraded Azure.Core from 1.36.0 to 1.39.0
- Upgraded Azure.ResourceManager from 1.9.0 to 1.12.0

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

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

# Release History

## 1.3.0 (Unreleased)

### Features Added

- Regenerated from the relocated ProviderHub TypeSpec (`specification/providerhub/resource-manager/Microsoft.ProviderHub/ProviderHub`), targeting API version `2025-10-01`.
- Added `ManifestInfo` and `OperationsPutContent` resources, along with the models supporting them.

### Breaking Changes

An upstream compliance review removed a set of internal-only Microsoft identifiers from the public `Microsoft.ProviderHub` specification, so the affected surface is no longer generated. The removals below are described by location and shape rather than by name, because naming them would reintroduce the identifiers this change exists to remove. Compiling against 1.3.0 reports every affected member by name, and the complete list is recorded in the API listings under `api/`.

**Removed: internal service-authentication configuration**

- The configuration model for an internal Microsoft service-authentication system, together with the property that exposed it on `FanoutLinkedNotificationRule`, `ResourceProviderManifestProperties`, `ResourceTypeEndpoint` and `ResourceTypeRegistrationProperties`, and the `ArmProviderHubModelFactory` overloads that accepted it. There is no replacement.

**Removed: internal service-metadata**

- The service-metadata model and its associated readiness enum, together with the collection property that exposed them on `ProviderResourceType`, `ResourceProviderManagement` and `ResourceTypeRegistrationProperties`, and the `ArmProviderHubModelFactory` overloads that accepted them. There is no replacement.

**Removed: new-region frontload release**

A property removed by the change above was required on the request model shared by the write operations, so the request could no longer be constructed and the feature is removed in full:

- `ProviderFrontloadPayload` and `ProviderFrontloadPayloadProperties`.
- `RegistrationNewRegionFrontloadReleaseResource` and `RegistrationNewRegionFrontloadReleaseCollection`.
- `ProviderRegistrationResource.GenerateManifestNewRegionFrontloadRelease`, `GetRegistrationNewRegionFrontloadRelease` and `GetRegistrationNewRegionFrontloadReleases`, plus the corresponding `ArmClient` extension and mocking methods.
- `ResourceTypeEndpointBase`, `ManifestLevelPropertyBag`, `AvailableCheckInManifestEnvironment` and `ServiceFeatureFlagAction`, which were referenced only by the models above.

**Changed: `ResourceAccessPolicy`**

- `ResourceAccessPolicy` is now an extensible enum rather than a closed one, and `NotSpecified` is the only well-known value that remains. Two values naming an internal Microsoft management tool were removed. The type was reopened so that any retired value the service still returns round-trips as a string instead of failing to deserialize.

**Changed: generator migration**

These changes are unrelated to the removals above and come from regenerating on the current management-plane generator:

- `Models.OperationsPutContent` was removed. The put-content operations are now exposed through `OperationsPutContentResource` and `OperationsPutContentData`, reached via `ProviderRegistrationResource.GetOperationsPutContent()`. This replaces `ProviderRegistrationResource.CreateOrUpdate(OperationsPutContent, ...)` and `ProviderRegistrationResource.GetByProviderRegistration()`.
- `ProviderRegistrationResource.Delete` now takes a `WaitUntil` argument and returns `ArmOperation`.
- `ManifestResourceDeletionPolicy` was renamed to `RPaaSResourceDeletionPolicy` and gained the `CascadeDeleteAll` and `CascadeDeleteProxyOnlyChildren` values. `ProviderResourceType.ResourceDeletionPolicy` is now typed `ResourceDeletionPolicy` and is read-only, and `ResourceTypeRegistrationProperties.ResourceDeletionPolicy` is now typed `RPaaSResourceDeletionPolicy`.
- `ResourceTypeRegistrationResourceManagementOptions.BatchProvisioningSupportSupportedOperations` was replaced by `ResourceTypeRegistrationResourceManagementOptions.BatchProvisioningSupport`.
- Removed the remaining `ArmProviderHubModelFactory` overloads that existed only to match the shape of the 1.2.x contract. Use the current overload for each model instead.
- Collection properties on several models, including `ProviderResourceType`, `AsyncOperationPollingRules` and `ResourceProviderCapabilities`, are now typed `IList<T>` rather than `IReadOnlyList<T>`.

### Bugs Fixed

### Other Changes

## 1.2.1 (2026-06-28)

### Other Changes

- Upgraded dependent Azure.Core to 1.59.0.
- Upgraded dependent Azure.ResourceManager to 1.14.0.

## 1.2.0 (2025-10-21)

### Features Added

- Upgraded api-version tag from 'package-2020-11-20' to 'package-2024-09-01'. Tag detail available at https://github.com/Azure/azure-rest-api-specs/blob/247a38a5fea02ac50132f591f3b53fec06e9377b/specification/providerhub/resource-manager/readme.md.
- Make `Azure.ResourceManager.ProviderHub` AOT-compatible.

### Other Changes

- Upgraded Azure.Core from 1.45.0 to 1.49.0
- Upgraded Azure.ResourceManager from 1.13.0 to 1.13.2
- Obsoleted property 'IList<BinaryData> ResourceAccessRoles' in type Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement

## 1.1.1 (2025-03-11)

### Features Added

- Enabled the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.
- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.1.0 (2023-11-29)

### Features Added

- Enabled mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.1.0-beta.1 (2023-05-31)

### Features Added

- Enabled the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.0 (2023-04-07)

This release is the first stable release of the Provider Hub Management library.

### Breaking Changes

Polishing since last public beta release:
- Prepended `ProviderHub` / `Provider` prefix to all single / simple model names.
- Corrected the format of all `Guid` type properties / parameters.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `ResourceType` type properties / parameters.
- Corrected the format of all `ETag` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected the format of all binary type properties / parameters.
- Corrected all acronyms that not follow [.Net Naming Guidelines](https://learn.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected enumeration name by following [Naming Enumerations Rule](https://learn.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the name of interval / duration properties / parameters that end with units.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent `Azure.Core` to `1.30.0`.

## 1.0.0-beta.1 (2022-09-25)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.ProviderHub` to `Azure.ResourceManager.ProviderHub`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

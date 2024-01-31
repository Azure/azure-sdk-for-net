# Release History

## 1.11.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

- Fixed [the issue](https://github.com/Azure/azure-sdk-for-net/issues/38154) that sdk caches wrong subscription provider.

### Other Changes

## 1.10.1 (2024-01-26)

### Bugs Fixed

- Change the private ctor `OperationStatusResult` to protected.

## 1.10.0 (2024-01-12)

### Features Added

- Add `GetEntities` operation.
- Add `CheckResourceName` operation.
- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

## 1.9.0 (2023-11-14)

### Features Added

- Bump api-version of `Lock` to `2020-05-01`.

### Bugs Fixed

- Add the `Default` enum value back to `EnforcementMode`.

### Other Changes

- Refined some customization code to make the library more maintainable.

## 1.8.0 (2023-11-02)

### Features Added

- Add a new method `GetCachedClient` in `ArmClient` class to unify the mocking experience.

## 1.8.0-beta.1 (2023-08-09)

### Features Added

- Add a method `GetCachedClient` in `ArmClient` to enable mocking for extension methods.

## 1.7.0 (2023-07-13)

### Other Changes

- Bump api-version of `Subscription` to `2022-12-01`.
- Bump api-version of `Tenant` to `2022-12-01`.

## 1.6.0 (2023-05-16)

### Features Added

- Add more model factory entries in class `Azure.ResourceManager.Models.ResourceManagerModelFactory` to support more generated models.

### Bugs Fixed

- Fixed [the issue](https://github.com/Azure/azure-sdk-for-net/issues/34796) that tag operations are not properly working.

## 1.5.0 (2023-04-27)

### Bugs Fixed

- Fixed `ManagedServiceIdentity` deserialization when services return empty string for `principalId` or `tenantId`.

### Other Changes

- Bump api-version of `PolicyAssignments` to `2022-06-01`.
- Bump api-version of `PolicyDefinitions` and `PolicySetDefinitions` to `2021-06-01`.
- Introduced new property `TargetResourceGroupId` on `Azure.ResourceManager.Resources.Models.ResourcesMoveContent` to supersede `TargetResourceGroup` to emphasize this is accepting a `ResourceIdentifier` of the target resource group.

## 1.4.0 (2023-02-10)

### Features Added

- Added `SetApiVersionsFromProfile` method in `ArmClientOptions` to support setting resource API versions from an Azure Stack Profile.

### Bugs Fixed

- Fixed the exception in `GenericResource` operations caused by case-sensitive comparison of resource types between user input and service results.

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded resources API version to `2022-09-01`.
  - The `GetAll` methods of `ResourceProviderCollection`, `GetTenantResourceProviders` methods of `ArmClient` removed the `top` parameter as it's never supported by service. We added back overloaded methods with the `top` parameter, but made it with `expand` parameter both as required. It is compatible with most previous method usages but still breaks a few cases such as (take `GetAll` as an example):
    - GetAll(10)
    - GetAll(top: 10)
    - GetAll(top: null)
    - GetAll(10, cancellationToken: token)
    - GetAll(top: 10, cancellationToken: token)
    - GetAll(top: null, cancellationToken: token)
  - The `Update` methods of `TagResource` became LRO and added a `waitUntil` parameter in the beginning. The old methods without the `waitUntil` parameter is kept with obsolete warnings to keep backward-compatibility.

## 1.3.2 (2022-11-11)

### Other Changes

- Minor internal changes.
- Polished the README and CHANGELOG files.

## 1.3.1 (2022-08-18)

### Features Added

- Added CanUseTagResource methods to check if the TagResource API is deployed in the current environment.

## 1.3.0 (2022-08-09)

### Other Changes

- Consolidate `SystemAssignedServiceIdentity` into `ManagedServiceIdentity` and make `SystemAssignedServiceIdentity`, `SystemAssignedServiceIdentityType` obsolete and EditorBrowsableNever.
- Added `ManagedIdentity` property in `PolicyAssignmentData` and obsolete its `Identity` property.

## 1.2.1 (2022-07-26)

### Other Changes

- Changed `OperationStatusResult` serialization constructor from internal to protected.

## 1.2.0 (2022-07-11)

### Other Changes

- Changed `OperationStatusResult` initialization constructor from internal to public.

- Upgraded dependent `Azure.Core` to 1.25.0

## 1.1.2 (2022-07-01)

### Features Added

- Add `ExtendedLocation` to common type.

## 1.1.1 (2022-06-22)

### Features Added

- Add OperationStatusResult to common type.

### Bugs Fixed

- Fixed serialization of a resource that inherits from ResourceData/TrackedResourceData by making Tags and SystemData as optional properties.

### Other Changes

- Hide EncryptionProperties, EncryptionStatus and KeyVaultProperties in common type.

## 1.1.0 (2022-06-08)

### Features Added

- Add Update methods in resource classes.

## 1.0.0 (2022-04-07)
This package is the first stable release of the Azure Resources management core library.

### Breaking Changes

Minor changes since the public beta release:
- All `Tag` methods have been removed from `SubscriptionResource` as the service doesn't support these operations.
- Simplify `type` property names.
- Normalized the body parameter type names for PUT / POST / PATCH operations if it's only used as input.
- Tweaked some properties to right type.

## 1.0.0-beta.9 (2022-03-31)

### Features Added

- New struct `ArmEnvironment`.

### Breaking Changes

- Now all the resource classes would have a `Resource` suffix (if it previously doesn't have one).
- Renamed some models to more comprehensive names.
- Moved class `ManagementGroupResource` (previously `ManagementGroup`), `ManagementGroupCollection` and `ManagementGroupData` from `Azure.ResourceManager.Management` namespace to `Azure.ResourceManager.ManagementGroups`.
- Moved class `ArmResource` and `ArmCollection` from `Azure.ResourceManager.Core` to `Azure.ResourceManager`.
- Removed namespace `Azure.ResourceManager.Core` and `Azure.ResourceManager.Management`.
- Removed class `ErrorDetail` and `ErrorAdditionalInfo`.
- Removed `GetIfExists` methods from all the resource classes.
- Changed `Scope` in `ArmClientOptions` to `ArmEnvironment`.
- The constructor of `ArmClient` no longer accepts a `Uri` parameter, use the `ArmEnvironment` in `ArmClientOptions` instead.
- All properties of the type `object` were changed to `BinaryData`.

## 1.0.0-beta.8 (2022-01-29)

### Features Added

- ManagementGroup: Added GetAvailableLocations methods.
- GenericResourceData: Added a new property ExtendedLocation.
- Support using different api versions for a service.

### Breaking Changes

- waitForCompletion is now a required parameter and moved to the first parameter in LRO operations.
- GenericResourceCollection: Parent changes from Subscription to Tenant.
- GenericResourceCollection: GetAll method replaced by GetGenericResources in Subscription, GetByResourceGroup method replaced by GetGenericResources in ResourceGroup.
- GenericResourceData: Now inherits from TrackedResourceExtended that also has ExtendedLocation and inherits from TrackedResource.
- PredefinedTag: Changed from a resource to a non-resource, that is, removed PredefinedTagCollection, PredefinedTag, renamed PredefinedTagData to PredefinedTag, the methods are moved to its Parent Subscription.
- ResourceLinkCollection: body parameter is unflattened in CreateOrUpdate.
- ManagementLockObject renamed to ManagementLock.
- Removed GenericResourceFilter classes.
- Removed GetAllAsGenericResources in [Resource]Collections.
- Added ArmResource constructor to use ArmClient for ClientContext information and removed previous constructors with parameters.
- Moved ResourceIdentifier and Location into Azure.Core.
- Removed GetGenericResources overload methods that are used to construct GenericResources.
- Removed CheckNameAvailabilityRequest, CheckNameAvailabilityResponse and CheckNameAvailabilityReason in common type.

## 1.0.0-beta.7 (2021-12-23)

### Breaking Changes

- Renamed method name from CheckIfExists to Exists.
- Renamed method name from Get[Resource]ByName to Get[Resources]AsGenericResources.

### Features Added

- Added resources and operations for PolicyAssignment, PolicyDefinition, PolicySetDefinition, DataPolicyManifest, PolicyExemption, ManagementLock and ResourceLink.

### Bugs Fixed

- Fixed the bug in SubscriptionData that the values for SubscriptionGuid and DisplayName are switched.
- Fixed the bug of unknown SkuTier value when exporting resource template by making GenericResourceData use a Sku model with string type Tier.

## 1.0.0-beta.6 (2021-11-30)

### Bugs Fixed

- Fixed error when parsing ID with subscriptions of other resource types.

## 1.0.0-beta.5 (2021-10-28)

### Breaking Changes

- Removed DefaultSubscription property from ArmClient and added GetDefaultSubscription()/GetDefaultSubscriptionAsync() methods. See the [Hello World examples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/Samples.md) of how to use the new methods to get the default subscription.
- Renamed [Resource]Container to [Resource]Collection and added the IEnumerable<T> and IAsyncEnumerable<T> interfaces to them making it easier to iterate over the list in the simple case.

## 1.0.0-beta.4 (2021-09-28)

### Breaking Changes

- Changed SubResource and WritableSubResource from ReferenceType to PropertyReferenceType.

## 1.0.0-beta.3 (2021-09-08)

### Features Added

- Added constructor overload to support [start from the middle scenario](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/resourcemanager/Azure.ResourceManager#managing-existing-resources-by-id)

## 1.0.0-beta.2 (2021-08-30)

### Breaking Changes

- Simplified CreateOrUpdate and Delete methods to no longer have Start variants for LongRunningOperations.
  - CreateOrUpdate and Delete now take an optional parameter `waitForCompletion` that defaults to true and determines whether the method waits for the operation to complete before returning.
  - If `waitForCompletion` is true, you can directly call `Value` on the result
  - If `waitForCompletion` is false, you can control the polling, but must call `WaitForCompletionAsync()` before accessing `Value`.

## 1.0.0-beta.1 (2021-08-26)

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).

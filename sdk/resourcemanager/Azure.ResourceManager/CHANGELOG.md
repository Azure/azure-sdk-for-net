# Release History

## 1.0.0-beta.8 (2022-01-29)

### Features Added

- ManagementGroup: Added GetAvailableLocations methods.
- GenericResourceData: Added a new property ExtendedLocation.
- Support using different api versions for a service.

### Breaking Changes

- waitForCompletion is now a required parameter and moved to the first parameter in LRO operations.
- GenericResourceCollection: Parent changes from Subscription to Tenant.
- GenericResourceCollection: GetAll method replaced by GetGenericResources in Subscription, GetByResourceGroup method replaced by GetGenericResources in ResourceGroup.
- GenericResourceData: Now inherits from TrackedResourceExtended which also has ExtendedLocation and inherits from TrackedResource.
- PredefinedTag: Changed from a resource to a non-resource, i.e. removed PredefinedTagCollection, PredefinedTag, renamed PredefinedTagData to PredefinedTag, the methods are moved to its Parent Subscription.
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

- Fixed error when parsing id with subscriptions of other resource types.

## 1.0.0-beta.5 (2021-10-28)

### Breaking Changes

- Removed DefaultSubscription property from ArmClient and added GetDefaultSubscription()/GetDefaultSubscriptionAsync() methods. See the [Hello World examples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/samples/README.md) of how to use the new methods to get the default subscription.
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
  - CreateOrUpdate and Delete now take an optional parameter `waitForCompletion` which defaults to true and determines whether the method waits for the operation to complete before returning.
  - If `waitForCompletion` is true you can directly call `Value` on the result
  - If `waitForCompletion` is false you can control the polling but must call `WaitForCompletionAsync()` before accessing `Value`.

## 1.0.0-beta.1 (2021-08-26)

### Features Added

- Initial checkin and introduction of object hierarchy in the SDK.

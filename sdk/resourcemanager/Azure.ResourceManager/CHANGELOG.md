# Release History

## 1.0.0-beta.5 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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

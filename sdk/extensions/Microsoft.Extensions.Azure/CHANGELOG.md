# Release History

## 1.3.0-beta.1 (Unreleased)

### Features Added

- Added support for constructing a `ManagedIdentityCredential` from config by specifying a `UserAssignedManagedIdentityResourceId`.

## 1.2.0 (2022-05-10)

### Other Changes

- Added support for GUID constructor parameters to be parsed directly from configuration.

## 1.1.1 (2021-09-07)

### Bugs Fixed

- Improved the diagnostic message when a constructor can't be selected.
- The issue where aggressive parameter validation caused constructor not to be selected.

## 1.1.0 (2021-06-09)

### Changes

#### Breaking changes

- The factory parameters to `AddClient` method were reordered.

## 1.1.0-beta.3 (2021-05-11)

### Changes

#### New Features

- The `AddClient` method that allows registering any Azure SDK client with a custom factory function.

## 1.1.0-beta.2 (2021-02-09)

### Added

- The ability to use `ManagedIdentityCredential` from the configuration using the `"credential": "managedidentity"`

## 1.1.0-beta.1 (2020-11-10)

### Added

- The `AzureComponentFactory` class that allows creating `TokenCredential`, `ClientOptions` and client instances from configuration.
- The `AzureEventSourceLogForwarder` class that allows manual control over the log forwarding.
- The `AddAzureClientsCore` extension method.

## 1.0.0 

- Updated Azure.Identity dependency version

## 1.0.0-preview.3 

- Updated Azure.Identity dependency version

## 1.0.0-preview.2 

- Minor bug fixes and code improvements.

## 1.0.0-preview.1 

- Added TokenCredential support.
- Added client version support.
- Added default client support.

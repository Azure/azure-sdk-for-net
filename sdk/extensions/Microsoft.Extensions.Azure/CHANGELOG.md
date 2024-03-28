# Release History

## 1.8.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.7.2 (2024-02-12)

### Bugs Fixed

- Fix several issues related to ThreadPool starvation for synchronous scenarios

## 1.7.1 (2023-10-27)

### Other Changes

- Updated dependency `Azure.Identity` to version `1.10.3`.

## 1.7.0 (2023-08-08)

### Features Added

- Added support for creating `WorkloadIdentityCredential` objects from the configuration using the `"credential": "workloadidentity"`. Users must provide values for the `tenantId`, `clientId`, and newly added `tokenFilePath` keys in the configuration, or they must set the environment variables `AZURE_TENANT_ID`, `AZURE_CLIENT_ID`, and `AZURE_FEDERATED_TOKEN_FILE`.

### Other Changes

- Updated dependency `Azure.Identity` to version `1.9.0`.

## 1.6.3 (2023-03-10)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.30.0`.

## 1.6.2 (2023-03-07)

### Bugs Fixed

- Added support for clients to be disposed via `IDisposable` or `IAsyncDisposable` when the service factory is disposed.
- Changed tracking for client initialization to ensure that behavior is correct for value types registered as clients.

## 1.6.0 (2022-10-12)

### Features Added

- Support passing a semi-colon delimited list of additional tenants via the `additionallyAllowedTenants` config. See the [Azure.Identity Breaking Changes log](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/BREAKING_CHANGES.md#170) for more information about this setting.

### Bugs Fixed

- The `tenantId`, `clientId`, `managedIdentityResourceId`, and the newly added `additionallyAllowedTenants` will be passed onto the created `DefaultAzureCredential` if no `clientSecret` or `clientCertificate` is provided. Previously, these values would be ignored when falling back to the `DefaultAzureCredential` or the user-provided credential specified via  `AzureClientFactoryBuilder.UseCredential`.

## 1.5.0 (2022-08-24)

### Bugs Fixed

- Hiding the new `AddAzureClientsCore` overload from IntelliSense, as its usage is not intuitive.

## 1.4.0 (2022-08-11)

### Features Added

- Added the `AddAzureClientsCore` method overload that has a parameter to allow enabling log
  forwarding to `ILogger`.

## 1.3.0 (2022-07-12)

### Features Added

- Added support for constructing a `ManagedIdentityCredential` from config by setting the `managedIdentityResourceId` key.

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

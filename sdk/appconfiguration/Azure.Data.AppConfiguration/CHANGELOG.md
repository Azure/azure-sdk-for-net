# Release History

## 1.3.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.3.0-beta.1 (2022-10-10)

### Features Added
- Added DPG methods to `ConfigurationClient` based on [this](https://github.com/Azure/azure-rest-api-specs/blob/e01d8afe9be7633ed36db014af16d47fec01f737/specification/appconfiguration/data-plane/Microsoft.AppConfiguration/stable/1.0/appconfiguration.json) swagger definition.

### Bugs Fixed
- Fixed throwing `NullReferenceException` if the value of a `SecretReferenceConfigurationSetting` is null [(#31588)](https://github.com/Azure/azure-sdk-for-net/pull/31588).

## 1.2.0 (2021-10-05)

### Features Added

- Added a `ConfigurationSetting` constructor parameter to set an `ETag`.

## 1.2.0-beta.1 (2021-08-10)

### Features Added

- Added a `ConfigurationSetting` constructor parameter to set an `ETag`.

## 1.1.0 (2021-07-06)

### Breaking Changes

- The `GetConfigurationSettingAsync` overload that takes an instance of `MatchConditions` temporary removed.

## 1.1.0-beta.3 (2021-06-08)

### Changes

#### New Features
- Added a `GetConfigurationSettingAsync` overload that takes an instance of `MatchConditions`.

#### Key Bug Fixes

- `FeatureFlagFilter` now allows parameter modification.

## 1.0.3 (2021-05-14)

### Changes

- Dependency versions updated.

## 1.1.0-beta.2 (2021-04-06)

### Breaking changes

- The `AddSyncToken` method renamed to `UpdateSyncToken`.

## 1.1.0-beta.1 (2021-03-09)

### Changes

#### New Features

- Added `SecretReferenceConfigurationSetting` type to represent a configuration setting that references a KeyVault Secret. 
- Added `FeatureFlagConfigurationSetting` type to represent a configuration setting that controls a feature flag.
- Added `AddSyncToken` to `ConfigurationClient` to be able to provide external synchronization tokens.

## 1.0.2 (2020-09-10)

- Provide AddConfigurationClient with support for TokenCredential

## 1.0.1 (2020-07-07)

- Update the tag list for the AzConfig package

## 1.0.0 

### Breaking changes

- `Keys` and `Labels` properties in `SettingSelector` are replaced with `KeyFilter` and `LabelFilter` to provide full filtering support.

### Major changes

- Fixed multiple issues with connection string parsing in `ConfigurationClient`.

## 1.0.0-preview.6 

- Bugfixes: [#8920](https://github.com/Azure/azure-sdk-for-net/issues/8920)

## 1.0.0-preview.5 

### Breaking changes

- Pair of methods `SetReadOnly`/`ClearReadOnly` in `ConfigurationClient` are replaced with single method `SetReadOnly` with boolean parameter.
- `SettingSelector.AsOf` property is renamed into `SettingSelector.AcceptDateTime`.

### Major changes

- Added support for AAD. `ConfigurationClient` can be created using endpoint and any type of `TokenCredential`.
- Added new overload for the method `ConfigurationClient.GetRevisions` that accepts key and optional label.
- Added new overload for the method `ConfigurationClient.GetConfigurationSetting` that accepts `ConfigurationSetting` and its datetime stamp.

## 1.0.0-preview.4 

### Breaking changes

- Made `Keys` and `Labels` in `SettingSelector` read-only.
- Removed `SetConfigurationSetting` overload that took `MatchCondition` as a parameter.
- Changed `SettingFields.Locked` to `SettingFields.ReadOnly` in the SDK; the serialized value sent to the service remains the same.
- Renamed `AzureClientBuilderExtensions` to `ConfigurationClientBuilderExtensions` in `Microsoft.Extensions.Azure` namespace.
- Made `ConfigurationClientOptions.Version` property internal.
- Changed client method names `Add`, `Get`, `Set`, `Delete`, and `GetSettings`, as well as their async versions to `AddConfigurationSetting`, `GetConfigurationSetting`, `SetConfigurationSetting`, `DeleteConfigurationSetting`, and `GetConfigurationSettings` respectively.
- Changed `ConfigurationSetting.ReadOnly` to `ConfigurationSetting.IsReadOnly`.
- Changed `Equals` and `GetHashCode` implementations in `ConfigurationSetting` and `SettingSelector` to use implementations inherited from `Object`.

### Major changes

- Fixed a bug causing incorrect request signing on retries.
- Made `ConfigurationSetting` serializable by `System.Text.Json` serializers.
- Updated documentation and samples.

## 1.0.0-preview.3 

- Fixed an issue where special characters were escaped incorrectly.

## 1.0.0-preview.2 

- Enabled conditional requests.
- Added support for setting `x-ms-client-request-id`, `x-ms-correlation-request-id`, and `correlation-context` headers.
- Added `SetReadOnly` and `ClearReadOnly` methods.
- Enabled setting service version.
- Added support for `Sync-Token` headers.
- Updated authorization header format.
- Removed `Update` methods.

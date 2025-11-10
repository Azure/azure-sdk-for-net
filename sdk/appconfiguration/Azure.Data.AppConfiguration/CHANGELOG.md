# Release History

## 1.7.0 (2025-11-07)

### Features Added

- Added internal pipeline policy to normalize (case-insensitive alphabetical) ordering of query parameters for deterministic request URLs.

## 1.6.1 (2025-05-09)

### Features Added

- Added AOT annotations to support AOT compilation.

## 1.6.0 (2025-03-11)

### Features Added

- Added support for specifying the token credential's Microsoft Entra audience when creating a client.

## 1.5.0 (2024-08-06)

### Features Added

- Added support for listing labels.
- Added support for filtering by tags.

## 1.4.1 (2024-04-17)

### Bugs Fixed
- Fixed a bug introduced in version 1.3.0 where the `GetConfigurationSetting` method incorrectly logged 304 responses as failures in distributed tracing.

## 1.4.0 (2024-04-10)

### Features Added

- Added `ConfigurationSettingPageableExtensions` class to support new `Pageable<ConfigurationSetting>.AsPages` and `AsyncPageable<ConfigurationSetting>.AsPages` extension methods. This replaces `SettingSelector.MatchConditions`.

### Breaking Changes

- Removed property `MatchConditions` from `SettingSelector`.

## 1.4.0-beta.1 (2024-03-07)

### Features Added

- Added property `MatchConditions` to `SettingSelector` which allows specifying request conditions to `GetConfigurationSettings` requests.

## 1.3.0 (2023-11-08)

### Features Added

- Added configuration settings snapshot feature which allow users to create a point-in-time snapshot of their configuration store.

### Breaking Changes

- Renamed `key` tag reported on `ConfigurationClient` activities to `az.appconfiguration.key` following OpenTelemetry attribute naming conventions.

### Bugs Fixed

### Other Changes

## 1.3.0-beta.3 (2023-10-09)

### Features Added

- Added a new type, `SnapshotSelector`, to encapsulate parameters like `name`, `fields`, and `status` within the `GetSnapshots` method.

### Bugs Fixed

- Fixed `GetConfigurationSettings(SettingSelector)` not setting `ContentType` and `LastModified` properties [(#38524)](https://github.com/Azure/azure-sdk-for-net/issues/38524).
- `FeatureFlagConfigurationSetting`  will now allow custom attributes under the `conditions` element in the setting value.  Previously, only `client_filters` was recognized and other data would be discarded.

## 1.2.1 (2023-09-13)

### Bugs Fixed

- `FeatureFlagConfigurationSetting` and `SecretReferenceConfigurationSetting` will now retain custom attributes in the setting value.  Previously, only attributes that were defined in the associated JSON schema were allowed and unknown attributes were discarded.
- Added the ability to create `FeatureFlagConfigurationSetting` and `SecretReferenceConfigurationSetting` instances with an ETag, matching `ConfigurationSetting`.  This allows all setting types to use the [GetConfigurationSettingAsync](https://learn.microsoft.com/dotnet/api/azure.data.appconfiguration.configurationclient.getconfigurationsettingasync?view=azure-dotnet#azure-data-appconfiguration-configurationclient-getconfigurationsettingasync(azure-data-appconfiguration-configurationsetting-system-boolean-system-threading-cancellationtoken)) overload that accepts `onlyIfUnchanged.`  Previously, this was not possible for specialized settings types.
- Added the ability to create `FeatureFlagConfigurationSetting` and `SecretReferenceConfigurationSetting` instances for testing purposes using the `ConfigurationModelFactory`. It was previously not possible to populate service-owned fields when testing.
- Marked a constructor overload of `ConfigurationSetting` that was intended for testing purposes as non-visible, as the `ConfigurationModelFactory` should instead be used.
- Fixed a bug where a disposed content stream was used to attempt deserialization in some scenarios, such as using a custom `HttpMessageHandler` that returns `StringContent`.

## 1.3.0-beta.2 (2023-07-11)

### Features Added

- Added configuration settings snapshot feature which allow users to create a point-in-time snapshot of their configuration store.

### Other Changes

- Removed protocol methods from the `ConfigurationClient`.

## 1.3.0-beta.1 (2022-10-10)

### Features Added

- Added protocol methods to `ConfigurationClient` based on [this](https://github.com/Azure/azure-rest-api-specs/blob/e01d8afe9be7633ed36db014af16d47fec01f737/specification/appconfiguration/data-plane/Microsoft.AppConfiguration/stable/1.0/appconfiguration.json) swagger definition.

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

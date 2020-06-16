# Release History

## 1.1.0-preview.1 (Unreleased)


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

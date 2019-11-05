# Release History

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
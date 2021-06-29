# Make a Configuration Setting Read-Only

This sample demonstrates how to make a configuration value read-only and return it back to the read-write state, as well as the exception that is thrown if a user attempts to write to a read-only setting. To get started, you'll need a connection string to the Azure App Configuration. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/appconfiguration/Azure.Data.AppConfiguration/README.md) for links and instructions.

## Create a ConfigurationClient

To interact with Azure App Configuration, you need to instantiate a `ConfigurationClient`. You can use either an endpoint URL and a [`TokenCredential`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#credentials) or a connection string.
 
For the sample below, you can set `connectionString` in an environment variable, a configuration setting, or any way that works for your application. The connection string is available from the App Configuration Access Keys view in the Azure Portal.

```C# Snippet:AzConfigSample3_CreateConfigurationClient
var client = new ConfigurationClient(connectionString);
```

## Create a configuration setting

To illustrate the set and clear read only scenario, create an instance of `ConfigurationSetting` and add the setting to the Configuration Store.

```C# Snippet:AzConfigSample3_SetConfigurationSetting
var setting = new ConfigurationSetting("some_key", "some_value");
client.SetConfigurationSetting(setting);
```

## Make the setting read-only

To prevent a configuration setting from being updated, call `SetReadOnly` with `isReadOnly: true`.

```C# Snippet:AzConfigSample3_SetReadOnly
client.SetReadOnly(setting.Key, true);
```

## Try modify read-only setting

If `SetConfigurationSetting` is called for the modified `setting`, it will throw an exception because the setting is read-only and cannot be updated.

```C# Snippet:AzConfigSample3_SetConfigurationSettingReadOnly
setting.Value = "new_value";

try
{
    client.SetConfigurationSetting(setting);
}
catch (RequestFailedException e)
{
    Console.WriteLine(e.Message);
}
```

## Make the setting read-write

To make the setting editable again, call `SetReadOnly` with `isReadOnly: false`.

```C# Snippet:AzConfigSample3_SetReadWrite
client.SetReadOnly(setting.Key, false);
```

## Modify read-write setting

Try to update to the new value again. `SetConfigurationSetting` should now succeed because the setting is read write.

```C# Snippet:AzConfigSample3_SetConfigurationSettingReadWrite
client.SetConfigurationSetting(setting);
```

## Delete a configuration setting

At the end of the sample, delete the setting, since it is no longer needed.

```C# Snippet:AzConfigSample3_DeleteConfigurationSetting
client.DeleteConfigurationSetting("some_key");
```

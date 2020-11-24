# Read Revision History

This sample demonstrates how to read the revision history of a Configuration Setting in a Configuration Store. To do this, we create a setting, change it twice to create revisions, then read the revision history for that setting using a `SettingSelector` that uniquely identifies the configuration setting by its key name. The sample uses a configuration setting with a timestamp in the key name to ensure the setting hasn't been used before and thereby minimize the size of the revision history.
 
To get started, you'll need a connection string to the Azure App Configuration. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/appconfiguration/Azure.Data.AppConfiguration/README.md) for links and instructions.

## Create a ConfigurationClient

To interact with Azure App Configuration, you need to instantiate a `ConfigurationClient`. You can use either an endpoint URL and a [`TokenCredential`](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md#credentials) or a connection string.
 
For the sample below, you can set `connectionString` in an environment variable, a configuration setting, or any way that works for your application. The connection string is available from the App Configuration Access Keys view in the Azure Portal.

```C# Snippet:AzConfigSample4_CreateConfigurationClient
var client = new ConfigurationClient(connectionString);
```

## Create the configuration setting with several revisions

First, create an initial `ConfigurationSetting` instance and set it in the Configuration Store.

```C# Snippet:AzConfigSample4_SetConfigurationSetting
ConfigurationSetting setting = new ConfigurationSetting($"setting_with_revisions-{DateTime.Now:s}", "v1");
await client.SetConfigurationSettingAsync(setting);
```

Every time `SetConfigurationSettingAsync` succeeds, a new revision is created.

```C# Snippet:AzConfigSample4_AddRevisions
setting.Value = "v2";
await client.SetConfigurationSettingAsync(setting);

setting.Value = "v3";
await client.SetConfigurationSettingAsync(setting);
``` 

## Retrieve revisions of the setting

To asynchronously get all unexpired revisions, call `GetRevisionsAsync` with a setting selector that has `KeyFilter` equal to `settings.Key`.  This will retrieve all revisions of this setting in the store. See App Configuration [REST API](https://docs.microsoft.com/azure/azure-app-configuration/rest-api-revisions#filtering) for more information about filtering.

```C# Snippet:AzConfigSample4_GetRevisions
var selector = new SettingSelector { KeyFilter = setting.Key };

Debug.WriteLine("Revisions of the setting: ");
await foreach (ConfigurationSetting settingVersion in client.GetRevisionsAsync(selector))
{
    Console.WriteLine($"Setting was {settingVersion} at {settingVersion.LastModified}.");
}
```

## Retrieve revisions after deletion

Revisions expire automatically and are available even after setting is deleted.

```C# Snippet:AzConfigSample4_GetRevisionsAfterDeletion
await client.DeleteConfigurationSettingAsync(setting.Key, setting.Label);

await foreach (ConfigurationSetting settingVersion in client.GetRevisionsAsync(selector))
{
    Console.WriteLine($"Setting was {settingVersion} at {settingVersion.LastModified}.");
}
```

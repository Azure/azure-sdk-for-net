# Asynchronously Create, Update and Delete Configuration Setting With Labels

This sample demonstrates how to send requests to the Azure App Configuration service asynchronously. It also shows how to create and retrieve configuration settings with labels, and provides an example scenario where labels are used to group configuration settings for "beta" and "production" application instances.  To get started, you'll need a connection string to Azure App Configuration. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/appconfiguration/Azure.Data.AppConfiguration/README.md) for links and instructions.

 ## Create a ConfigurationClient
 
To interact with Azure App Configuration, you need to instantiate a `ConfigurationClient`. You can use either an endpoint URL and a [`TokenCredential`](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md#credentials) or a connection string.
 
For the sample below, you can set `connectionString` in an environment variable, a configuration setting, or any way that works for your application. The connection string is available from the App Configuration Access Keys view in the Azure Portal.

```C# Snippet:AzConfigSample2_CreateConfigurationClient
var client = new ConfigurationClient(connectionString);
```

## Asynchronously create configuration settings

First, you need to create several instances of `ConfigurationSetting` with different keys, values and labels.

```C# Snippet:AzConfigSample2_CreateConfigurationSettingAsync
var betaEndpoint = new ConfigurationSetting("endpoint", "https://beta.endpoint.com", "beta");
var betaInstances = new ConfigurationSetting("instances", "1", "beta");
var productionEndpoint = new ConfigurationSetting("endpoint", "https://production.endpoint.com", "production");
var productionInstances = new ConfigurationSetting("instances", "1", "production");
```

There are two ways to create a Configuration Setting asynchronously:
- `AddConfigurationSettingAsync` creates a setting only if the setting does not already exist in the store.
- `SetConfigurationSettingAsync` creates a setting if it doesn't exist or overrides an existing setting with the same key and label.

```C# Snippet:AzConfigSample2_AddConfigurationSettingAsync
await client.AddConfigurationSettingAsync(betaEndpoint);
await client.AddConfigurationSettingAsync(betaInstances);
await client.AddConfigurationSettingAsync(productionEndpoint);
await client.AddConfigurationSettingAsync(productionInstances);
```

## Asynchronously update a configuration setting

To retrieve a previously stored configuration setting, call `GetConfigurationSettingAsync`.

```C# Snippet:AzConfigSample2_GetConfigurationSettingAsync
ConfigurationSetting instancesToUpdate = await client.GetConfigurationSettingAsync(productionInstances.Key, productionInstances.Label);
```

To increase production instances from 1 to 5, change the value and use `SetConfigurationSettingAsync` to override existing setting.

```C# Snippet:AzConfigSample2_SetUpdatedConfigurationSettingAsync
instancesToUpdate.Value = "5";
await client.SetConfigurationSettingAsync(instancesToUpdate);
```

## Search by label filter

To gather all the information available for the "production" environment, call `GetConfigurationSettingsAsync` with a setting selector that filters for settings with the "production" label.  This will retrieve all the Configuration Settings in the store that satisfy that condition. See App Configuration [REST API](https://docs.microsoft.com/azure/azure-app-configuration/rest-api-key-value#filtering) for more information about filtering.

```C# Snippet:AzConfigSample2_GetConfigurationSettingsAsync
var selector = new SettingSelector { LabelFilter = "production" };

Debug.WriteLine("Settings for Production environment:");
await foreach (ConfigurationSetting setting in client.GetConfigurationSettingsAsync(selector))
{
    Console.WriteLine(setting);
}
```

## Asynchronously delete configuration settings

To delete configuration settings that are no longer needed you can call `DeleteConfigurationSettingAsync`.

```C# Snippet:AzConfigSample2_DeleteConfigurationSettingAsync
await client.DeleteConfigurationSettingAsync(betaEndpoint.Key, betaEndpoint.Label);
await client.DeleteConfigurationSettingAsync(betaInstances.Key, betaInstances.Label);
await client.DeleteConfigurationSettingAsync(productionEndpoint.Key, productionEndpoint.Label);
await client.DeleteConfigurationSettingAsync(productionInstances.Key, productionInstances.Label);
```

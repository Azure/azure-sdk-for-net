# Get Settings With Tags

This sample demonstrates how to fetch configuration settings from the Azure App Configuration service using tags. To get started, you'll need a connection string to Azure App Configuration. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/appconfiguration/Azure.Data.AppConfiguration/README.md) for links and instructions.

 ## Create a ConfigurationClient

To interact with Azure App Configuration, you need to instantiate a `ConfigurationClient`. You can use either an endpoint URL and a [`TokenCredential`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#credentials), or a connection string.

For the sample below, you can set `connectionString` in an environment variable, a configuration setting, or any way that works for your application. The connection string is available from the App Configuration Access Keys view in the Azure Portal.

```C# Snippet:AzConfigSample12_CreateConfigurationClient
var client = new ConfigurationClient(connectionString);
```

## Create configuration setting with tags

First, create an instance of `ConfigurationSetting` with a key, value, label, and tags.

```C# Snippet:AzConfigSample12_CreateConfigurationSettingAsync
var betaEndpoint = new ConfigurationSetting("endpoint", "https://beta.endpoint.com", "beta")
{
    Tags = { { "someKey", "someValue" } }
};
```

Then add the Configuration Setting.

```C# Snippet:AzConfigSample12_AddConfigurationSettingAsync
await client.AddConfigurationSettingAsync(betaEndpoint);
```

## Search by tags filter

To gather all the information available for settings grouped by a specific tag, call `GetConfigurationSettingsAsync` with a setting selector that filters for settings with the "someKey=someValue" tag.  This will retrieve all the Configuration Settings in the store that satisfy that condition. See App Configuration [REST API](https://learn.microsoft.com/azure/azure-app-configuration/rest-api-key-value#filtering) for more information about filtering.

```C# Snippet:AzConfigSample12_GetConfigurationSettingsAsync
var selector = new SettingSelector();
selector.TagsFilter.Add("someKey=someValue");

Console.WriteLine("Settings for beta filtered by tag:");
await foreach (ConfigurationSetting setting in client.GetConfigurationSettingsAsync(selector))
{
    Console.WriteLine(setting);
}
```

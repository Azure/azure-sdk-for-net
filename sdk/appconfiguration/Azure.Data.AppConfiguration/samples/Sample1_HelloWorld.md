# Create, Retrieve and Delete a Configuration Setting

This sample demonstrates basic operations with two core classes in this library: `ConfigurationClient` and `ConfigurationSetting`. `ConfigurationClient` is used to call the Azure App Configuration service - each method call sends a request to the service's REST API.  `ConfigurationSetting` is the primary entity stored in a Configuration Store and represents a key-value pair you use to configure your application.  The sample walks through the basics of adding, retrieving, and deleting a configuration setting. To get started, you'll need a connection string to the Azure App Configuration. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/appconfiguration/Azure.Data.AppConfiguration/README.md) for links and instructions.

 ## Create a ConfigurationClient
 
To interact with Azure App Configuration, you need to instantiate a `ConfigurationClient`. You can use either an endpoint URL and a [`TokenCredential`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#credentials) or a connection string.
 
For the sample below, you can set `connectionString` in an environment variable, a configuration setting, or any way that works for your application. The connection string is available from the App Configuration Access Keys view in the Azure Portal.

```C# Snippet:AzConfigSample1_CreateConfigurationClient
var client = new ConfigurationClient(connectionString);
```

## Create a configuration setting

First, you need to create an instance of `ConfigurationSetting`. At least, it requires a key/value pair of strings.

```C# Snippet:AzConfigSample1_CreateConfigurationSetting
var setting = new ConfigurationSetting("some_key", "some_value");
```

There are two ways to create a Configuration Setting:
- `AddConfigurationSetting` creates a setting only if the setting does not already exist in the store.
- `SetConfigurationSetting` creates a setting if it doesn't exist or overrides an existing setting with the same key and label.

```C# Snippet:AzConfigSample1_SetConfigurationSetting
client.SetConfigurationSetting(setting);
```

##  Retrieve a configuration setting

Once you've created a configuration setting, you can retrieve it by calling `GetConfigurationSetting`

```C# Snippet:AzConfigSample1_RetrieveConfigurationSetting
ConfigurationSetting retrievedSetting = client.GetConfigurationSetting("some_key");
Console.WriteLine($"The value of the configuration setting is: {retrievedSetting.Value}");
```

## Delete a configuration setting

To delete a configuration setting that is no longer needed you can call `DeleteConfigurationSetting`.

```C# Snippet:AzConfigSample1_DeleteConfigurationSetting
client.DeleteConfigurationSetting("some_key");
```

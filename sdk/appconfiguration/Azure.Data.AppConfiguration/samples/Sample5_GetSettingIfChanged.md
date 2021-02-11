# Get a Configuration Setting If Changed

This sample illustrates how to get a setting from the configuration store only if the version in the configuration store is different from the one held by your client application, as determined by whether the setting ETags match. Getting a configuration setting only if it has changed allows you to avoid downloading a setting if your client application is already holding the latest value, which saves cost and bandwidth. To get started, you'll need a connection string to Azure App Configuration. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/appconfiguration/Azure.Data.AppConfiguration/README.md) for links and instructions.

## Define method `GetConfigurationSettingIfChanged`

When `GetConfigurationSetting` is called with `onlyIfChanged: true`, it adds an `If-None-Match` header to the HTTP request. The response will have an HTTP status code equals to either 200 if the setting value was modified or 304 otherwise. See App Configuration [REST API](https://docs.microsoft.com/azure/azure-app-configuration/rest-api-key-value#get-conditionally) and [Azure API design](https://azure.github.io/azure-sdk/general_design.html#conditional-requests) for more information about conditional requests.

This logic can be encapsulated into a helper method that will return either a setting from the response if it was changed in the configuration store or the current local setting otherwise. The method must check the response's HTTP status code before accessing the response value. If `response.Value` is accessed when no value was returned, an exception will be thrown.

```C# Snippet:AzConfigSample5_GetConfigurationSettingIfChanged
public static ConfigurationSetting GetConfigurationSettingIfChanged(ConfigurationClient client, ConfigurationSetting setting)
{
    Response<ConfigurationSetting> response = client.GetConfigurationSetting(setting, onlyIfChanged: true);
    int httpStatusCode = response.GetRawResponse().Status;
    Console.WriteLine($"Received a response code of {httpStatusCode}");

    return httpStatusCode switch
    {
        200 => response.Value,
        304 => setting,
        _ => throw new InvalidOperationException()
    };
}
```

## Create a ConfigurationClient

To interact with Azure App Configuration, you need to instantiate a `ConfigurationClient`. You can use either an endpoint URL and a [`TokenCredential`](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md#credentials) or a connection string.
 
For the sample below, you can set `connectionString` in an environment variable, a configuration setting, or any way that works for your application. The connection string is available from the App Configuration Access Keys view in the Azure Portal.

```C# Snippet:AzConfigSample5_CreateConfigurationClient
ConfigurationClient client = new ConfigurationClient(connectionString);
```

## Get initial setting with ETag

Get an instance of `ConfigurationSetting` with `ETag` by calling `SetConfigurationSetting`. 

```C# Snippet:AzConfigSample5_SetConfigurationSetting
ConfigurationSetting setting = client.SetConfigurationSetting("some_key", "initial_value");
Console.WriteLine($"setting.ETag is '{setting.ETag}'");
```

## Get latest setting

Now you can use the previously created `GetConfigurationSettingIfChanged` helper method to get the latest version setting.

```C# Snippet:AzConfigSample5_GetLatestConfigurationSetting
ConfigurationSetting latestSetting = GetConfigurationSettingIfChanged(client, setting);
Console.WriteLine($"Latest version of setting is {latestSetting}.");
```

## Delete a configuration setting

At the end of the sample, delete a setting from the Configuration Store that is no longer needed.

```C# Snippet:AzConfigSample5_DeleteConfigurationSetting
client.DeleteConfigurationSetting("some_key");
```

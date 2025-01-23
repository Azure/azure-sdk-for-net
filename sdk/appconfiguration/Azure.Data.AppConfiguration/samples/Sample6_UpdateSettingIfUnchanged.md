# Update a Configuration If Unchanged

This sample illustrates how to update a setting in the configuration store only when the store holds same version it did it was last retrieved from the configuration store, as determined by whether the client and service setting ETags match. This ensures our client will not overwrite updates applied to the setting from other sources.

In a hypothetical scenario, we release several virtual machines from our application's resource pool, and update the `available_vms` configuration setting to reflect this. In this scenario, if another client were to have modified `available_vms` since we last retrieved it, and we updated it unconditionally, our update would overwrite their changes and the resulting value of `available_vms` would be incorrect. We show in the sample how to implement optimistic concurrency to apply the update in a way that doesn't overwrite other clients' changes.

To get started, you'll need a connection string to the Azure App Configuration. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/appconfiguration/Azure.Data.AppConfiguration/README.md) for links and instructions.

## Define method `ReleaseVMs`

This method will be called to release a VM and give it back to the application's shared pool. In a real system, we would count how many VMs were successfully released and return that number.

```C# Snippet:AzConfigSample6_ReleaseVMs
private int ReleaseVMs(int vmsToRelease)
{
    // TODO
    return vmsToRelease;
}
```

## Define method `UpdateAvailableVms`

When `SetConfigurationSetting` is called with `onlyIfUnchanged: true`, it adds optional `If-Match` header to the HTTP request. Response will have HTTP status code equals to either 200 if client setting ETag matched the service one and setting has been successfully updated or 412 otherwise. See App Configuration [REST API](https://learn.microsoft.com/azure/azure-app-configuration/rest-api-key-value#get-conditionally) and [Azure API design](https://azure.github.io/azure-sdk/general_design.html#conditional-requests) for more information about conditional requests.

To increase the number of available VMs, we need to get current number of VMs, add the number of released ones and send this number back to the service. If the `available_vms` setting has been modified since the last time our client retrieved it from the service, we need to catch `RequestFailedException` exception and re-apply our update logic before attempting to set it again on the service. This logic can be encapsulates into a helper method that will return the number of available VMs after the update.

```C# Snippet:AzConfigSample6_UpdateAvailableVms
private static int UpdateAvailableVms(ConfigurationClient client, int releasedVMs)
{
    while (true)
    {
        ConfigurationSetting setting = client.GetConfigurationSetting("available_vms");
        var availableVmsCount = int.Parse(setting.Value);
        setting.Value = (availableVmsCount + releasedVMs).ToString();

        try
        {
            ConfigurationSetting updatedSetting = client.SetConfigurationSetting(setting, onlyIfUnchanged: true);
            return int.Parse(updatedSetting.Value);
        }
        catch (RequestFailedException e) when (e.Status == 412)
        {
        }
    }
}
```

## Create a ConfigurationClient

To interact with Azure App Configuration, you need to instantiate a `ConfigurationClient`. You can use either an endpoint URL and a [`TokenCredential`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#credentials) or a connection string.
 
For the sample below, you can set `connectionString` in an environment variable, a configuration setting, or any way that works for your application. The connection string is available from the App Configuration Access Keys view in the Azure Portal.

```C# Snippet:AzConfigSample6_CreateConfigurationClient
var client = new ConfigurationClient(connectionString);
```

## Set amount of available VMs before update.

For test purposes, we need to specify some initial value for the `available_vms`.

```C# Snippet:AzConfigSample6_SetInitialVMs
client.SetConfigurationSetting("available_vms", "10");
```

## Release VMs

Here we invoke code that releases VMs from our application's pool of resources. 

```C# Snippet:AzConfigSample6_CallReleaseVMs
int releasedVMs = ReleaseVMs(vmsToRelease: 2);
```

Now we can call the `UpdateAvailableVms` to update the total number of available VMs.

```C# Snippet:AzConfigSample6_CallUpdateAvailableVms
var availableVms = UpdateAvailableVms(client, releasedVMs);
Console.WriteLine($"Available VMs after update: {availableVms}");
```

## Delete a configuration setting

At the end of the sample, delete a setting from the Configuration Store that is no longer needed.

```C# Snippet:AzConfigSample6_DeleteConfigurationSetting
client.DeleteConfigurationSetting("available_vms");
```

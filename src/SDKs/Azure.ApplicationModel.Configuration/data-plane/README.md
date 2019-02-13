# Overview 

Azure.ApplicationModel.Configuration is a component of the .NET Azure SDK. 
It provides APIs for storing and retrieving application settings.

# Installing

A NuGet package called Azure.ApplicationModel.Configuration will be avaliable soon.

# Hello World

```c#
public async Task HelloWorld()
{
    // Connection string string from your Azure portal.
    var connectionString = ...

    // Instantiate a client that will be used to call the service.
    var client = new ConfigurationClient(connectionString);

    // Create a setting to be stored by the configuration service.
    var setting = new ConfigurationSetting("some_key", "some_value");

    // SetAsyc adds a new setting to the store or overrides an existing setting.
    // Alternativelly you can call AddAsync which only succeeds if the setting does not already exist in the store.
    // Or you can call UpdateAsync to update a setting that is already present in the store.
    await client.SetAsync(setting);

    // Retrieve a previously stored setting by calling GetAsync.
    ConfigurationSetting gotSetting = await client.GetAsync("some_key");
    Debug.WriteLine(gotSetting.Value);

    // Delete the setting when you don't need it anymore.
    await client.DeleteAsync("some_key");
}
```

# Other Samples
1. [How to access diagnostic logs](https://github.com/Azure/azure-sdk-for-net-lab/blob/master/Configuration/Azure.Configuration.Test/samples/Sample4_Logging.cs)
2. [How to configure retry policy](https://github.com/Azure/azure-sdk-for-net-lab/blob/master/Configuration/Azure.Configuration.Test/samples/Sample6_ConfiguringRetries.cs)
3. [How to configure service requests](https://github.com/Azure/azure-sdk-for-net-lab/blob/master/Configuration/Azure.Configuration.Test/samples/Sample7_ConfiguringPipeline.cs)

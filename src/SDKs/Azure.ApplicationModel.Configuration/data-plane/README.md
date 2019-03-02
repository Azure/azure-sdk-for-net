# Overview 

Azure.ApplicationModel.Configuration is a component of the .NET Azure SDK. 
It provides APIs for Microsoft [Azure's App Configuration Service](https://docs.microsoft.com/en-us/azure/azure-app-configuration/).

Developers can use this SDK to interact with the [Configuration Store](https://docs.microsoft.com/en-us/azure/azure-app-configuration/quickstart-dotnet-core-app#create-an-app-configuration-store) where the configuration settings are stored.
A configuration setting is a resource identified by a unique combination of key + label, where label is optional. Other properties are value, content type, etc.
Actions that can be executed:

- Perform basic reads, writes, updates, and deletes of an application configuration settings.
- Get the history of configuration setting.
- Watch for changes in a specific configuration setting.

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
1. [How to access diagnostic logs](https://github.com/Azure/azure-sdk-for-net/tree/master/src/SDKs/Azure.ApplicationModel.Configuration/data-plane/Azure.Configuration.Tests/samples/Sample4_Logging.cs)
2. [How to configure retry policy](https://github.com/Azure/azure-sdk-for-net/tree/master/src/SDKs/Azure.ApplicationModel.Configuration/data-plane/Azure.Configuration.Tests/samples/Sample6_ConfiguringRetries.cs)
3. [How to configure service requests](https://github.com/Azure/azure-sdk-for-net/tree/master/src/SDKs/Azure.ApplicationModel.Configuration/data-plane/Azure.Configuration.Tests/samples/Sample7_ConfiguringPipeline.cs)

[More...](https://github.com/Azure/azure-sdk-for-net/blob/master/src/SDKs/Azure.ApplicationModel.Configuration/data-plane/Azure.Configuration.Tests/ConfigurationLiveTests.cs)


# Contributing
If the changes you are working on span both Azure.Base and Azure.Configuration then you can set this environment variable before launching Visual Studio. That will use Project To Project references between Azure.Configuration and Azure.Base instead of package references.

This will enable the project to project references:
```
set UseProjectReferenceToAzureBase=true
```

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsrc%2FSDKs%2FAzure.ApplicationModel.Configuration%2Fdata-plane%2FREADME.png)

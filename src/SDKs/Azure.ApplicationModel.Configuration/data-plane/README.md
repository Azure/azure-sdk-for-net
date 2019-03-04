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
1. [How to access diagnostic logs](https://github.com/Azure/azure-sdk-for-net/tree/master/src/SDKs/Azure.ApplicationModel.Configuration/data-plane/Azure.Configuration.Tests/samples/Sample4_Logging.cs)
2. [How to configure retry policy](https://github.com/Azure/azure-sdk-for-net/tree/master/src/SDKs/Azure.ApplicationModel.Configuration/data-plane/Azure.Configuration.Tests/samples/Sample6_ConfiguringRetries.cs)
3. [How to configure service requests](https://github.com/Azure/azure-sdk-for-net/tree/master/src/SDKs/Azure.ApplicationModel.Configuration/data-plane/Azure.Configuration.Tests/samples/Sample7_ConfiguringPipeline.cs)


# Contributing
If the changes you are working on span both Azure.Base and Azure.Configuration then you can set this environment variable before launching Visual Studio. That will use Project To Project references between Azure.Configuration and Azure.Base instead of package references.

This will enable the project to project references:
```
set UseProjectReferenceToAzureBase=true
```

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsrc%2FSDKs%2FAzure.ApplicationModel.Configuration%2Fdata-plane%2FREADME.png)

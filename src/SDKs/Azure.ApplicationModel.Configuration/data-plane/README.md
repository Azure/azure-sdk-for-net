# Overview 

Azure.ApplicationModel.Configuration is a component of the .NET Azure SDK. 
It provides APIs for Microsoft [Azure's Application Configuration Service](https://docs.microsoft.com/en-us/azure/azure-app-configuration/) which is a service that allows to easily store and manage all application settings in one central place that is separated from code.

Developers can use this SDK to interact with the [Configuration Store](https://docs.microsoft.com/en-us/azure/azure-app-configuration/quickstart-dotnet-core-app#create-an-app-configuration-store) where the configuration settings are stored.

Actions that can be executed are:

- Perform basic reads, writes, updates, and deletes of an application configuration settings.
- Get the history of a configuration setting.
- Watch for changes in a specific configuration setting.

# Installing

A NuGet package called Azure.ApplicationModel.Configuration will be avaliable soon.

# Configuration Setting
Is the fundamental resource within a Configuration Store. In its simplest form it is a key and a value. However, there are additional properties such as the modifiable content type and tags fields that allow the value to be interpreted or associated in different ways.

The Label property of a configuration setting provides a way to separate configuration settings into different dimensions. These dimensions are user defined and can take any form. Some common examples of dimensions to use for a label include regions, semantic versions, or environments. Many applications have a required set of configuration keys that have varying values as the application exists across different dimensions.
For example, MaxRequests may be 100 in "NorthAmerica", and 200 in "WestEurope". By creating a configuration setting named MaxRequests with a label of "NorthAmerica" and another, only with a different value, in the "WestEurope" label, a solution can be achieved that allows the application to seamlessly retrieve configuration settings as it runs in these two dimensions.

Properties of a Configuration Setting:

```c#
    string Key { get; set; }

    string Label { get; set; }

    string Value { get; set; }

    string ContentType { get; set; }

    string ETag { get; }

    DateTimeOffset LastModified { get; }

    bool Locked { get; }

    IDictionary<string, string> Tags { get; set; }
```

# Hello World
The following example demonstrates how to initialize a ConfigurationClient and perform a basic operations in the Configuration Store.

To begin using ConfigurationClient, a connection string must be provided which specifies the configuration store endpoint and credentials to use when sending requests. This conneection string can be retrieved by the Azure Portal or by using the [Azure CLI](https://docs.microsoft.com/en-us/azure/azure-app-configuration/cli-samples). From that point, the example uses the client to set, retrieve and delete a configuration setting by its name.

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
1. [How to access diagnostic logs](Azure.ApplicationModel.Configuration.Tests/samples/Sample4_Logging.cs)
2. [How to configure retry policy](Azure.ApplicationModel.Configuration.Tests/samples/Sample6_ConfiguringRetries.cs)
3. [How to configure service requests](Azure.ApplicationModel.Configuration.Tests/samples/Sample7_ConfiguringPipeline.cs)

[More...](Azure.ApplicationModel.Configuration.Tests/ConfigurationLiveTests.cs)

# Contributing
If the changes you are working on span both Azure.Base and Azure.Configuration then you can set this environment variable before launching Visual Studio. That will use Project To Project references between Azure.Configuration and Azure.Base instead of package references.

This will enable the project to project references:
```
set UseProjectReferenceToAzureBase=true
```

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsrc%2FSDKs%2FAzure.ApplicationModel.Configuration%2Fdata-plane%2FREADME.png)

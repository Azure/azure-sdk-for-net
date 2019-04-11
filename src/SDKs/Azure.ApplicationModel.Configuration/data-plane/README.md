# Azure App Configuration client library for .NET
Azure App Configuration is a managed service that helps developers centralize their application configurations simply and securely.

Modern programs, especially programs running in a cloud, generally have many components that are distributed in nature. Spreading configuration settings across these components can lead to hard-to-troubleshoot errors during an application deployment. Use App Configuration to store all the settings for your application and secure their accesses in one place.

Use the client library for App Configuration to:
- Create a Configuration Setting
- Retrieve a Configuration Setting
- Update an existing Configuration Setting
- Delete a Configuration Setting

[Source code]() | [Package (NuGet)][package] | [API reference documentation]() | [Product documentation][azconfig_docs]

## Getting started

### Install the package

Install the Azure App Configuration client library for .NET with [NuGet][nuget]:

```Powershell
Install-Package Azure.ApplicationModel.Configuration -Version 1.0.0-preview.1
```

**Prerequisites**: You must have an [Azure subscription][azure_sub], and a [Configuration Store][configuration_store] to use this package.

To create a Configuration Store, you can use the Azure Portal or [Azure CLI][azure_cli] with the following command:

```Powershell
az appconfig create --name <config-store-name> --resource-group <resource-group-name> --location eastus
```

### Authenticate the client

In order to interact with the App Configuration service, you'll need to create an instance of the [Configuration Client][configuration_client_class] class. To make this possible, you'll need the connection string of the Configuration Store.

#### Get credentials
Use the [Azure CLI][azure_cli] snippet below to get the connection string from the Configuration Store.
```Powershell
az appconfig credential list --name <config-store-name>
```

Alternatively, get the connection string from the Azure Portal.

#### Create client

Once you have the value of the connection string, you can create the ConfigurationClient:

```c#
string connectionString = <connection_string>;
ConfigurationClient client = new ConfigurationClient(connectionString);
```

## Key concepts

### Configuration Setting
Is the fundamental resource within a Configuration Store. In its simplest form it is a key and a value. However, there are additional properties such as the modifiable content type and tags fields that allow the value to be interpreted or associated in different ways.

The Label property of a Configuration Setting provides a way to separate Configuration Settings into different dimensions. These dimensions are user defined and can take any form. Some common examples of dimensions to use for a label include regions, semantic versions, or environments. Many applications have a required set of configuration keys that have varying values as the application exists across different dimensions.
For example, MaxRequests may be 100 in "NorthAmerica", and 200 in "WestEurope". By creating a Configuration Setting named MaxRequests with a label of "NorthAmerica" and another, only with a different value, in the "WestEurope" label, a solution can be achieved that allows the application to seamlessly retrieve Configuration Settings as it runs in these two dimensions.

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

## Examples
The following sections provide several code snippets covering some of the most common Configuration Service tasks, including:
- [Create a Configuration Setting](#create-a-Configuration-Setting)
- [Retrieve a Configuration Setting](#retrieve-a-Configuration-Setting)
- [Update an existing Configuration Setting](#update-an-existing-Configuration-Setting)
- [Delete a Configuration Setting](#delete-a-Configuration-Setting)

### Create a Configuration Setting
Create a Configuration Setting to be stored in the Configuration Store.
There are two (2) ways to store a Configuration Setting:
- AddAsync creates a setting only if the setting does not already exist in the store.
- SetAsync creates a setting if it doesn't exist or overrides an existing setting.

```c#
string connectionString = <connection_string>;
ConfigurationClient client = = new ConfigurationClient(connectionString);
var setting = new ConfigurationSetting("some_key", "some_value");
await client.SetAsync(setting);
```

### Retrieve a Configuration Setting
Retrieves a previously stored Configuration Setting by calling GetAsync

```c#
string connectionString = <connection_string>;
ConfigurationClient client = = new ConfigurationClient(connectionString);
var setting = new ConfigurationSetting("some_key", "some_value");
await client.SetAsync(setting);
ConfigurationSetting setting = await client.GetAsync("some_key");
```

### Update an existing Configuration Setting
Updates an existing Configuration Setting by calling UpdateAsync. If the Configuration Setting does not exist in the store, a `412 - Precondition Failed` error will occur.

```c#
string connectionString = <connection_string>;
ConfigurationClient client = = new ConfigurationClient(connectionString);
var setting = new ConfigurationSetting("some_key", "some_value");
await client.SetAsync(setting);
ConfigurationSetting setting = await client.UpdateAsync("some_key", "new_value");
```

### Delete a Configuration Setting
Deletes an existing Configuration Setting by calling DeleteAsync

```c#
string connectionString = <connection_string>;
ConfigurationClient client = = new ConfigurationClient(connectionString);
var setting = new ConfigurationSetting("some_key", "some_value");
await client.SetAsync(setting);
ConfigurationSetting setting = await client.DeleteAsync("some_key");
```

## Troubleshooting

### General

When you interact with App Configuration using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for [REST API][azconfig_rest] requests.

For example, if you try to retrieve a Configuration Setting that doesn't exist in your Configuration Store, a `404` error is returned, indicating `Not Found`.

```c#
string connectionString = <connection_string>;
ConfigurationClient client = = new ConfigurationClient(connectionString);
ConfigurationSetting setting = await client.GetAsync("some_key");
````

You will notice that additional information is logged, like the Client Request ID of the operation.

```c#
Message: Azure.RequestFailedException : StatusCode: 404, ReasonPhrase: 'Not Found', Version: 1.1, Content: System.Net.Http.NoWriteNoSeekStreamContent, Headers:
{
  Connection: keep-alive
  Date: Thu, 11 Apr 2019 00:16:57 GMT
  Server: nginx/1.13.9
  x-ms-client-request-id: cc49570c-9143-411e-a6c8-3287dd114034
  x-ms-request-id: 2ad025f7-1fe8-4da0-8648-8290e774ed61
  x-ms-correlation-request-id: 2ad025f7-1fe8-4da0-8648-8290e774ed61
  Strict-Transport-Security: max-age=15724800; includeSubDomains;
  Content-Length: 0
}
```

## Next Steps

### More sample code
The App Configuration client library, also includes additional functionality that can be set when creating the Configuration Client.
These samples provide example of those scenarios:

- [How to access diagnostic logs](Azure.ApplicationModel.Configuration.Tests/samples/Sample4_Logging.cs)
- [How to configure retry policy](Azure.ApplicationModel.Configuration.Tests/samples/Sample6_ConfiguringRetries.cs)
- [How to configure service requests](Azure.ApplicationModel.Configuration.Tests/samples/Sample7_ConfiguringPipeline.cs)

# Contributing
If the changes you are working on span both Azure.Base and Azure.Configuration then you can set this environment variable before launching Visual Studio. That will use Project To Project references between Azure.Configuration and Azure.Base instead of package references.

This will enable the project to project references:
```
set UseProjectReferenceToAzureBase=true
```

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsrc%2FSDKs%2FAzure.ApplicationModel.Configuration%2Fdata-plane%2FREADME.png)


<!-- LINKS -->
[azconfig_docs]: https://docs.microsoft.com/en-us/azure/azure-app-configuration/
[azconfig_rest]: https://github.com/Azure/AppConfiguration#rest-api-reference
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[configuration_client_class]: ./Azure.ApplicationModel.Configuration/ConfigurationClient.cs
[configuration_store]: https://docs.microsoft.com/en-us/azure/azure-app-configuration/quickstart-dotnet-core-app#create-an-app-configuration-store
[nuget]: https://www.nuget.org/
[package]: https://www.nuget.org/packages/Azure.ApplicationModel.Configuration/1.0.0-preview.1

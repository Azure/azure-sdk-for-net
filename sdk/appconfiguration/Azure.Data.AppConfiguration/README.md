# Azure App Configuration client library for .NET

Azure App Configuration is a managed service that helps developers centralize their application configurations in one place, simply and securely.

Use the client library for App Configuration to:

* Create centrally stored application configuration settings
* Retrieve settings
* Update settings
* Delete settings

[Package (NuGet)][package] | API reference documentation (coming soon) | [Product documentation][azconfig_docs]

## Getting started

### Install the package

Install the Azure App Configuration client library for .NET with [NuGet][nuget]:

```PowerShell
Install-Package Azure.ApplicationModel.Configuration -Version 1.0.0-preview.2
```

**Prerequisites**: You must have an [Azure subscription][azure_sub], and a [Configuration Store][configuration_store] to use this package.

To create a Configuration Store, you can use the Azure Portal or [Azure CLI][azure_cli].

You need to install the Azure App Configuration CLI extension first by executing the following command:

```PowerShell
az extension add -n appconfig
```

After that, create the Configuration Store:

```PowerShell
az appconfig create --name <config-store-name> --resource-group <resource-group-name> --location eastus
```

### Authenticate the client

In order to interact with the App Configuration service, you'll need to create an instance of the [Configuration Client][configuration_client_class] class. To make this possible, you'll need the connection string of the Configuration Store.

#### Get credentials

Use the [Azure CLI][azure_cli] snippet below to get the connection string from the Configuration Store.

```PowerShell
az appconfig credential list --name <config-store-name>
```

Alternatively, get the connection string from the Azure Portal.

#### Create client

Once you have the value of the connection string, you can create the ConfigurationClient:

```c#
string connectionString = <connection_string>;
var client = new ConfigurationClient(connectionString);
```

## Key concepts

### Configuration setting

A Configuration Setting is the fundamental resource within a Configuration Store. In its simplest form, it is a key and a value. However, there are additional properties such as the modifiable content type and tags fields that allow the value to be interpreted or associated in different ways.

The Label property of a Configuration Setting provides a way to separate Configuration Settings into different dimensions. These dimensions are user defined and can take any form. Some common examples of dimensions to use for a label include regions, semantic versions, or environments. Many applications have a required set of configuration keys that have varying values as the application exists across different dimensions.

For example, MaxRequests may be 100 in "NorthAmerica", and 200 in "WestEurope". By creating a Configuration Setting named MaxRequests with a label of "NorthAmerica" and another, only with a different value, in the "WestEurope" label, an application can seamlessly retrieve Configuration Settings as it runs in these two dimensions.

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

The following sections provide several code snippets covering some of the most common Configuration Service tasks. Note that there are sync and async methods available for both:

- [Create a Configuration Setting](#create-a-configuration-setting)
- [Retrieve a Configuration Setting](#retrieve-a-configuration-setting)
- [Update an existing Configuration Setting](#update-an-existing-configuration-setting)
- [Delete a Configuration Setting](#delete-a-configuration-setting)

### Create a Configuration Setting

Create a Configuration Setting to be stored in the Configuration Store. There are two ways to store a Configuration Setting:

- Add creates a setting only if the setting does not already exist in the store.
- Set creates a setting if it doesn't exist or overrides an existing setting.

```c#
string connectionString = <connection_string>;
var client = new ConfigurationClient(connectionString);
var setting = new ConfigurationSetting("some_key", "some_value");
client.Set(setting);
```

### Retrieve a Configuration Setting

Retrieve a previously stored Configuration Setting by calling Get.

```c#
string connectionString = <connection_string>;
var client = new ConfigurationClient(connectionString);
var setting = new ConfigurationSetting("some_key", "some_value");
client.Set(setting);
ConfigurationSetting setting = client.Get("some_key");
```

### Update an existing Configuration Setting

Update an existing Configuration Setting by calling Update.

```c#
string connectionString = <connection_string>;
var client = new ConfigurationClient(connectionString);
var setting = new ConfigurationSetting("some_key", "some_value");
client.Set(setting);
ConfigurationSetting setting = client.Update("some_key", "new_value");
```

### Delete a Configuration Setting

Delete an existing Configuration Setting by calling Delete.

```c#
string connectionString = <connection_string>;
var client = new ConfigurationClient(connectionString);
var setting = new ConfigurationSetting("some_key", "some_value");
client.Set(setting);
ConfigurationSetting setting = client.Delete("some_key");
```

## Troubleshooting

### General

When you interact with App Configuration using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for [REST API][azconfig_rest] requests.

For example, if you try to retrieve a Configuration Setting that doesn't exist in your Configuration Store, a `404` error is returned, indicating `Not Found`.

```c#
string connectionString = <connection_string>;
var client = new ConfigurationClient(connectionString);
ConfigurationSetting setting = client.Get("some_key");
```

You will notice that additional information is logged, like the Client Request ID of the operation.

```
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

The App Configuration client library includes additional functionality that can be set when creating the Configuration Client. These samples provide example of those scenarios:

- [Hello world](samples/Sample1_HelloWorld.cs)
- [Hello world async extended](samples/Sample2_HelloWorldExtended.cs)
- [How to access diagnostic logs](samples/Sample4_Logging.cs)
- [How to configure retry policy](samples/Sample6_ConfiguringRetries.cs)
- [How to configure service requests](samples/Sample7_ConfiguringPipeline.cs)

### Project-to-project references

If the changes you are working on span both Azure.Core and Azure.Configuration then you can set this environment variable before launching Visual Studio. That will use Project To Project references between Azure.Configuration and Azure.Core instead of package references.

This will enable the project-to-project references:

```Batchfile
set UseProjectReferenceToAzureBase=true
```

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fappconfiguration%2FAzure.ApplicationModel.Configuration%2FREADME.png)

<!-- LINKS -->
[azconfig_docs]: https://docs.microsoft.com/azure/azure-app-configuration/
[azconfig_rest]: https://github.com/Azure/AppConfiguration#rest-api-reference
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[configuration_client_class]: src/ConfigurationClient.cs
[configuration_store]: https://docs.microsoft.com/azure/azure-app-configuration/quickstart-dotnet-core-app#create-an-app-configuration-store
[nuget]: https://www.nuget.org/
[package]: https://www.nuget.org/packages/Azure.ApplicationModel.Configuration/

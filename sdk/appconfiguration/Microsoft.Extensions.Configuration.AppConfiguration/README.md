# Azure App Configuration provider for Microsoft.Extensions.Configuration

The `Microsoft.Extensions.Configuration.AppConfiguration` package allows storing configuration values using Azure App Configuration.

## Getting started

### Install the package

Install the package with NuGet:

```dotnetcli
dotnet add package Microsoft.Extensions.Configuration.AppConfiguration
```

### Prerequisites

You need an [Azure subscription][azure_sub] and an
[App Configuration store][appconfig_doc] to use this package.

To create a new App Configuration store, you can use the [Azure Portal][appconfig_create_portal],
[Azure PowerShell][appconfig_create_ps], or the [Azure CLI][appconfig_create_cli].
Here's an example using the Azure CLI:

```Powershell
az appconfig create --name MyAppConfig --resource-group MyResourceGroup --location westus
az appconfig kv set --name MyAppConfig --key MyKey --value "MyValue"
```

## Key concepts

### Thread safety
We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

To load configuration from Azure App Configuration, first configure an `AppConfiguration` section in your `appsettings.json` that describes the `ConfigurationClient` to use. Settings stored in your App Configuration store — such as retry options — are merged into the configuration so that subsequent calls like `AddClient` can consume them.

For example, your local `appsettings.json` defines the client endpoint and credential, while retry settings like `MyClient:Options:Retry:MaxRetries` live in your App Configuration store:

```json
{
  "AppConfiguration": {
    "Endpoint": "https://myappconfig.azconfig.io",
    "Credential": {
      "CredentialSource": "AzureCliCredential"
    }
  },
  "MyClient": {
    "Endpoint": "https://myservice.example.com",
    "Credential": {
      "CredentialSource": "AzureCliCredential"
    }
  }
}
```

Then call `AddAppConfigurations` on the configuration builder, passing the name of the section that describes the `ConfigurationClient`. When the configuration is built, settings from your App Configuration store are loaded and merged with the local configuration:

```C# Snippet:ConfigurationAddAppConfigurations
HostApplicationBuilder builder = Host.CreateApplicationBuilder();
builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.AddAppConfigurations("AppConfiguration");
builder.AddClient<MyClient, MyClientSettings>("MyClient");

IHost host = builder.Build();
MyClient client = host.Services.GetRequiredService<MyClient>();
```

The [Azure Identity library][identity] provides easy Azure Active Directory support for authentication.

## Next steps

Read more about [configuration in ASP.NET Core][aspnetcore_configuration_doc].

## Contributing

This project welcomes contributions and suggestions. Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact [opencode@microsoft.com][coc_contact] with any
additional questions or comments.

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/appconfiguration/Microsoft.Extensions.Configuration.AppConfiguration/src
[appconfig_create_cli]: https://learn.microsoft.com/azure/azure-app-configuration/quickstart-azure-app-configuration-create?tabs=azure-cli#create-an-app-configuration-store
[appconfig_create_portal]: https://learn.microsoft.com/azure/azure-app-configuration/quickstart-azure-app-configuration-create?tabs=azure-portal#create-an-app-configuration-store
[appconfig_create_ps]: https://learn.microsoft.com/azure/azure-app-configuration/quickstart-azure-app-configuration-create?tabs=azure-powershell#create-an-app-configuration-store
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md
[aspnetcore_configuration_doc]: https://learn.microsoft.com/aspnet/core/fundamentals/configuration/?view=aspnetcore-3.1
[appconfig_doc]: https://learn.microsoft.com/azure/azure-app-configuration/overview
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com

# Azure Communication Alpha ID client library for .NET

This package contains a C# SDK for Azure Communication Services for Alpha IDs.

## Getting started

### Install the package
Install the Azure Communication Alpha ID client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Communication.AlphaIds --prerelease
``` 

### Prerequisites
You need an [Azure subscription][azure_sub], a [Communication Service Resource][communication_resource_docs].

To create these resource, you can use the [Azure Portal][communication_resource_create_portal], the [Azure PowerShell][communication_resource_create_power_shell], or the [.NET management client library][communication_resource_create_net].

### Key concepts
`AlphaIdsClient` provides the functionality to manage the usage of Alpha IDs.

### Authenticate the client
Alpha ID clients can be authenticated using the connection string acquired from an Azure Communication Resource in the [Azure Portal][azure_portal].

```C# Snippet:Azure_Communication_AlphaIds_CreateAlphaIdsClient
var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
AlphaIdsClient client = new AlphaIdsClient(connectionString);
```

Alternatively, Alpha Ids clients can also be authenticated using a valid token credential. With this option,
`AZURE_CLIENT_SECRET`, `AZURE_CLIENT_ID` and `AZURE_TENANT_ID` environment variables need to be set up for authentication. 

```C# Snippet:Azure_Communication_AlphaIds_CreateAlphaIdsClientWithToken
string endpoint = "<endpoint_url>";
TokenCredential tokenCredential = new DefaultAzureCredential();
tokenCredential = new DefaultAzureCredential();
AlphaIdsClient client = new AlphaIdsClient(new Uri(endpoint), tokenCredential);
```
## Examples
### Get configuration
To get the current applied configuration, call the `GetConfiguration` or `GetConfigurationAsync` function from the `AlphaIdsClient`.
```C# Snippet:Azure_Communication_AlphaIds_GetConfiguration
try
{
    AlphaIdConfiguration configuration = await client.GetConfigurationAsync();

    Console.WriteLine($"The usage of Alpha IDs is currently {(configuration.Enabled ? "enabled" : "disabled")}");
}
catch (RequestFailedException ex)
{
    if (ex.Status == 403)
    {
        Console.WriteLine("Resource is not eligible for Alpha ID usage");
    }
}
```

## Troubleshooting
A `RequestFailedException` is thrown as a service response for any unsuccessful requests. The exception contains information about what response code was returned from the service.

## Next steps
- [Read more about Azure Communication Services][communication_resource_docs]

## Contributing
This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[azure_portal]: https://portal.azure.com
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[communication_resource_docs]: https://learn.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_portal]:  https://learn.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_power_shell]: https://learn.microsoft.com/powershell/module/az.communication/new-azcommunicationservice
[communication_resource_create_net]: https://learn.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-net
[nuget]: https://www.nuget.org/

# Azure Communication Administration client library for .NET

> Server Version:

> Phone number administration client: 2020-07-20-preview1

Azure Communication Administration is managing phone numbers for Azure Communication Services.

[Source code]| [Package (NuGet)][package] | [Product documentation][product_docs] | [Samples][source_samples]

## Getting started

### Install the package

Install the Azure Communication Administration client library for .NET with [NuGet][nuget]:

```Powershell
dotnet add package Azure.Communication.Administration --version 1.0.0-beta.3
```

### Prerequisites

You need an [Azure subscription][azure_sub] and a [Communication Service Resource][communication_resource_docs] to use this package.

To create a new Communication Service, you can use the [Azure Portal][communication_resource_create_portal], the [Azure PowerShell][communication_resource_create_power_shell], or the [.NET management client library][communication_resource_create_net].

<!--
Here's an example using the Azure CLI:

```Powershell
[To be ADDED]
```
-->

### Key concepts

Phone plans come in two types; Geographic and Toll-Free. Geographic phone plans are phone plans associated with a location, whose phone numbers' area codes are associated with the area code of a geographic location. Toll-Free phone plans are phone plans not associated location. For example, in the US, toll-free numbers can come with area codes such as 800 or 888.

All geographic phone plans within the same country are grouped into a phone plan group with a Geographic phone number type. All Toll-Free phone plans within the same country are grouped into a phone plan group.

### Authenticate the client

Phone Number Administration clients can be authenticated using connection string acquired from an Azure Communication Resources in the [Azure Portal][azure_portal].

```C# Snippet:CreatePhoneNumbersClient
// Get a connection string to our Azure Communication resource.
var connectionString = "<connection_string>";
var client = new PhoneNumbersClient(connectionString);
```

Phone Number Administration clients also have the option to authenticate with Azure Active Directory Authentication. With this option,
`AZURE_CLIENT_SECRET`, `AZURE_CLIENT_ID` and `AZURE_TENANT_ID` environment variables need to be set up for authentication.

```C# Snippet:CreatePhoneNumbersClientWithTokenCredential
// Get an endpoint to our Azure Communication resource.
var endpoint = new Uri("<endpoint_url>");
TokenCredential tokenCredential = new DefaultAzureCredential();
client = new PhoneNumbersClient(endpoint, tokenCredential);
```

### Reserving and acquiring numbers

Phone numbers reservation can be performed through the reservation creation API by providing a phone plan id, an area code and quantity of phone numbers. The provided quantity of phone numbers will be reserved for ten minutes. This reservation of phone numbers can either be cancelled or purchased. If the reservation is cancelled, then the phone numbers will become available to others. If the reservation is purchased, then the phone numbers are acquired for the Azure resources.

### Configuring / Assigning numbers

Phone numbers can be assigned to a callback URL via the configure number API. As part of the configuration, you will need an acquired phone number, callback URL and application id.

## Examples

## Troubleshooting

## Next steps

[Read more about Communication user access tokens][user_access_token]

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->

[azure_sub]: https://azure.microsoft.com/free/
[azure_portal]: https://portal.azure.com
[source_samples]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/communication/Azure.Communication.Administration/samples
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[package]: https://www.nuget.org/packages/Azure.Communication.Administration
[product_docs]: https://docs.microsoft.com/azure/communication-services/overview
[nuget]: https://www.nuget.org/
[communication_resource_docs]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_portal]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_power_shell]: https://docs.microsoft.com/powershell/module/az.communication/new-azcommunicationservice
[communication_resource_create_net]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-net

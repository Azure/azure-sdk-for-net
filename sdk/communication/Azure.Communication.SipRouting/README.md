# Azure Communication Calling Configuration client library for .NET

> Server Version:

> Calling Configuration client: <!-- todo -->

Azure Communication Calling Configuration is managing PSTN calling configuration settings for Azure Communication Services.

[Source code][source] <!--| [Package (NuGet)][package]--> | [Product documentation][product_docs] | [Samples][source_samples]

## Getting started

### Install the package

Install the Azure Communication Calling Configuration client library for .NET with [NuGet][nuget]:

```Powershell
dotnet add package Azure.Communication.CallingConfiguration --version 1.0.0-beta.1
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


### Authenticate the client

### Getting current configuration

### Upating configuration for resource

## Examples
See [examples][sdk_examples]

## Troubleshooting

## Next steps

[Read more about Communication user access tokens][user_access_token]

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->

[azure_sub]: https://azure.microsoft.com/free/
[azure_portal]: https://portal.azure.com
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[product_docs]: https://docs.microsoft.com/azure/communication-services/overview
[nuget]: https://www.nuget.org/
[communication_resource_docs]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_portal]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_power_shell]: https://docs.microsoft.com/powershell/module/az.communication/new-azcommunicationservice
[communication_resource_create_net]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-net
[user_access_token]:https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/communication/Azure.Communication.Identity/README.md

<!-- [sdk_examples]: https://github.com/Azure/azure-sdk-for-net-pr/blob/feature/communication-calling_config/sdk/communication/Azure.Communication.CallingConfiguration/samples/README.md -->

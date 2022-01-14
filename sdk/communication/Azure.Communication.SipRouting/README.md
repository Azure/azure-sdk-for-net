# Azure Communication SIP routing client library for .NET

This package contains a C# SDK for Azure Communication Services for SIP routing. It is used to configure PSTN related settings for ACS resource.
To get started, you will need to have an Azure Subscription. Once you have this you can go into the Azure portal and create Azure Communication Services resource. The page will give you necessary information to be able to use the sample codes here such as connections string, shared access key, etc.

This client library allows to do following operations:
 - Setup [SipTrunk][telephony] configuration and routing rules for [Sip interface][sip];

[Source code][source] <!--| [Package (NuGet)][package]--> | [Product documentation][product_docs] | [Samples][source_samples]

## Getting started

### Install the package

Install the Azure Communication Sip routing client library for .NET with [NuGet][nuget]:

```Powershell
dotnet add package Azure.Communication.SipRouting --version 1.0.0-beta.1
```

### Prerequisites

You need an [Azure subscription][azure_sub] and a [Communication Service Resource][communication_resource_docs] to use this package.

To create a new Communication Service, you can use the [Azure Portal][communication_resource_create_portal], the [Azure PowerShell][communication_resource_create_power_shell], or the [.NET management client library][communication_resource_create_net].

### Key concepts
Azure Communication SIP package is used to do the following:

- Retrieve SIP configuration
- Update SIP configuration

### Create the client

```csharp
var connectionString = "<connection_string>";
var client = new SipRoutingClient(connectionString);
```

### Getting current configuration
```csharp
SipConfiguration config = client.GetSipConfiguration();
```

### Updating configuration for resource

#### Update full configuration
```csharp
var trunks = new Dictionary<string, SipTrunk> {{ "sbs1.contoso.com", new SipTrunk(1122) }};
var routes = new List<SipTrunkRoute> {
  new SipTrunkRoute( name: "Route", numberPattern : @"\+123[0-9]+", trunks : new List<string>{ "sbs1.contoso.com" })
};
var configuration = new SipConfiguration(trunks, routes);

var response = client.UpdateSipTrunkConfiguration(configuration);
```

#### Update only SIP trunks
```csharp
var trunks = new Dictionary<string, SipTrunk> {{ "sbs1.contoso.com", new SipTrunk(1122) }};
var response = client.UpdateTrunks(trunks);
```

#### Update only SIP routing settings
```csharp
var routes = new List<SipTrunkRoute> {
  new SipTrunkRoute( name: "Route", numberPattern : @"\+123[0-9]+", trunks : new List<string>{ "sbs1.contoso.com" })
};

var response = client.UpdateRoutingSettings(routes);
```

## Examples
For more examples and code samples, see: [examples][source_samples]

## Troubleshooting

The SIP configuration client will raise exceptions defined in [Azure Core][azure_core].

## Next steps

[Read more about Communication user access tokens][user_access_token]

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[azure_core]: https://github.com/Azure/azure-sdk-for-python/blob/master/sdk/core/azure-core/README.md
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
[source]:https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.SipRouting
[source_samples]:https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.SipRouting/samples
[telephony]: https://docs.microsoft.com/azure/communication-services/concepts/telephony-sms/telephony-concept
[sip]: https://docs.microsoft.com/azure/communication-services/concepts/telephony-sms/sip-interface-infrastructure

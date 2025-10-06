# Azure Provisioning WebPubSub client library for .NET

Azure.Provisioning.WebPubSub simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Provisioning.WebPubSub
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Create a Basic Web PubSub Service

This example demonstrates how to create an Azure Web PubSub service for real-time messaging, based on the [Azure quickstart template](https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.web/azure-web-pubsub/main.bicep).

```C# Snippet:WebPubSubBasic
Infrastructure infra = new();

WebPubSubService webpubsub =
    new(nameof(webpubsub), "2021-10-01")
    {
        Sku =
            new BillingInfoSku
            {
                Name = "Free_F1",
                Tier = WebPubSubSkuTier.Free,
                Capacity = 1
            },
        Identity = new ManagedServiceIdentity { ManagedServiceIdentityType = ManagedServiceIdentityType.None },
        IsAadAuthDisabled = false,
        IsLocalAuthDisabled = false,
        LiveTraceConfiguration =
            new LiveTraceConfiguration
            {
                IsEnabled = "false",
                Categories =
                {
                    new LiveTraceCategory { Name = "ConnectivityLogs", IsEnabled = "false" },
                    new LiveTraceCategory { Name = "MessagingLogs", IsEnabled = "false" },
                }
            },
        NetworkAcls =
            new WebPubSubNetworkAcls
            {
                DefaultAction = AclAction.Deny,
                PublicNetwork =
                    new PublicNetworkAcls
                    {
                        Allow =
                        {
                            WebPubSubRequestType.ServerConnection,
                            WebPubSubRequestType.ClientConnection,
                            WebPubSubRequestType.RestApi,
                            WebPubSubRequestType.Trace
                        }
                    }
            },
        PublicNetworkAccess = "Enabled",
        ResourceLogCategories =
        {
            new ResourceLogCategory { Enabled = "true", Name = "ConnectivityLogs" },
            new ResourceLogCategory { Enabled = "true", Name = "MessagingLogs" },
        },
        IsClientCertEnabled = false
    };

infra.Add(webpubsub);
```

## Troubleshooting

-   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
-   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

## Contributing

For details on contributing to this repository, see the [contributing
guide][cg].

This project welcomes contributions and suggestions. Most contributions
require you to agree to a Contributor License Agreement (CLA) declaring
that you have the right to, and actually do, grant us the rights to use
your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine
whether you need to provide a CLA and decorate the PR appropriately
(for example, label, comment). Follow the instructions provided by the
bot. You'll only need to do this action once across all repositories
using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For
more information, see the [Code of Conduct FAQ][coc_faq] or contact
<opencode@microsoft.com> with any other questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/

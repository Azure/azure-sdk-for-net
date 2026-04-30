# Azure Provisioning EventGrid client library for .NET

Azure.Provisioning.EventGrid simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Provisioning.EventGrid
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Create an Event Grid Topic

This example demonstrates how to create an Event Grid topic for event-driven architectures, based on the [Azure quickstart template](https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.eventgrid/event-grid-subscription-and-storage/main.bicep).

```C# Snippet:EventGridBasic
Infrastructure infra = new();

ProvisioningParameter webhookUri = new(nameof(webhookUri), typeof(string));
infra.Add(webhookUri);

StorageAccount storage =
    new(nameof(storage), StorageAccount.ResourceVersions.V2024_01_01)
    {
        Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
        Kind = StorageKind.StorageV2,
        AllowBlobPublicAccess = false,
        AccessTier = StorageAccountAccessTier.Hot,
        EnableHttpsTrafficOnly = true,
    };
infra.Add(storage);

SystemTopic topic =
    new(nameof(topic), SystemTopic.ResourceVersions.V2022_06_15)
    {
        Identity = new ManagedServiceIdentity { ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned },
        Source = storage.Id,
        TopicType = "Microsoft.Storage.StorageAccounts"
    };
infra.Add(topic);

SystemTopicEventSubscription subscription =
    new(nameof(subscription), SystemTopicEventSubscription.ResourceVersions.V2022_06_15)
    {
        Parent = topic,
        Destination = new WebHookEventSubscriptionDestination { Endpoint = webhookUri },
        Filter = new EventSubscriptionFilter
        {
            IncludedEventTypes =
            {
                "Microsoft.Storage.BlobCreated",
                "Microsoft.Storage.BlobDeleted"
            }
        }
    };
infra.Add(subscription);
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

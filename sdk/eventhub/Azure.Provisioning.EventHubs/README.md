# Azure Provisioning EventHubs client library for .NET

Azure.Provisioning.EventHubs simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Provisioning.EventHubs
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Create an Event Hub With Consumer Group

This example demonstrates how to create an Event Hub namespace with an Event Hub and consumer group, based on the [Azure quickstart template](https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.eventhub/event-hubs-create-event-hub-and-consumer-group/main.bicep).

```C# Snippet:EventHubsBasic
Infrastructure infra = new();

ProvisioningParameter hubName = new(nameof(hubName), typeof(string)) { Value = "orders" };
infra.Add(hubName);

ProvisioningParameter groupName = new(nameof(groupName), typeof(string)) { Value = "managers" };
infra.Add(groupName);

EventHubsNamespace ns =
    new(nameof(ns))
    {
        Sku = new EventHubsSku
        {
            Name = EventHubsSkuName.Standard,
            Tier = EventHubsSkuTier.Standard,
            Capacity = 1
        }
    };
infra.Add(ns);

EventHub hub =
    new(nameof(hub))
    {
        Parent = ns,
        Name = hubName
    };
infra.Add(hub);

EventHubsConsumerGroup group =
    new(nameof(group))
    {
        Parent = hub,
        Name = groupName,
        UserMetadata = BinaryData.FromObjectAsJson(new { foo = 1, bar = "hello" }).ToString()
    };
infra.Add(group);
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

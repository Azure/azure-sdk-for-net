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

### Create an Event Hub namespace with Event Hub and consumer group

```csharp
using Azure.Provisioning;
using Azure.Provisioning.EventHubs;

Infrastructure infrastructure = new Infrastructure();

// Create an Event Hub namespace
EventHubsNamespace eventHubNamespace = new EventHubsNamespace("eventHubNamespace")
{
    Sku = new EventHubsSku
    {
        Name = EventHubsSkuName.Standard,
        Tier = EventHubsSkuTier.Standard,
        Capacity = 1
    }
};
infrastructure.Add(eventHubNamespace);

// Create an Event Hub within the namespace
EventHub eventHub = new EventHub("eventHub")
{
    Parent = eventHubNamespace,
    Name = "orders"
};
infrastructure.Add(eventHub);

// Create a consumer group for the Event Hub
EventHubsConsumerGroup consumerGroup = new EventHubsConsumerGroup("consumerGroup")
{
    Parent = eventHub,
    Name = "managers",
    UserMetadata = "{\"department\":\"sales\"}"
};
infrastructure.Add(consumerGroup);

// Generate the Bicep template
string bicep = infrastructure.Compile();
Console.WriteLine(bicep);
```

### Create an Event Hub with retention and partitions

```csharp
using Azure.Provisioning;
using Azure.Provisioning.EventHubs;

Infrastructure infrastructure = new Infrastructure();

// Create namespace with premium tier for more features
EventHubsNamespace eventHubNamespace = new EventHubsNamespace("eventHubNamespace")
{
    Sku = new EventHubsSku
    {
        Name = EventHubsSkuName.Premium,
        Tier = EventHubsSkuTier.Premium,
        Capacity = 1
    }
};
infrastructure.Add(eventHubNamespace);

// Create Event Hub with custom settings
EventHub eventHub = new EventHub("eventHub")
{
    Parent = eventHubNamespace,
    Name = "telemetry",
    MessageRetentionInDays = 7,
    PartitionCount = 4
};
infrastructure.Add(eventHub);

string bicep = infrastructure.Compile();
Console.WriteLine(bicep);
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

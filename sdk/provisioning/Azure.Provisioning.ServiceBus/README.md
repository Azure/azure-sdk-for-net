# Azure.Provisioning.ServiceBus client library for .NET

Azure.Provisioning.ServiceBus simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Provisioning.ServiceBus
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Create a Service Bus namespace with queue

```csharp
using Azure.Provisioning;
using Azure.Provisioning.ServiceBus;

Infrastructure infrastructure = new Infrastructure();

// Create a Service Bus namespace
ServiceBusNamespace serviceBusNamespace = new ServiceBusNamespace("serviceBusNamespace")
{
    Sku = new ServiceBusSku { Name = ServiceBusSkuName.Standard }
};
infrastructure.Add(serviceBusNamespace);

// Create a queue in the namespace
ServiceBusQueue queue = new ServiceBusQueue("queue")
{
    Parent = serviceBusNamespace,
    Name = "orders",
    LockDuration = TimeSpan.FromMinutes(5),
    MaxSizeInMegabytes = 1024,
    RequiresDuplicateDetection = false,
    RequiresSession = false,
    MaxDeliveryCount = 10,
    EnablePartitioning = false
};
infrastructure.Add(queue);

// Generate the Bicep template
string bicep = infrastructure.Compile();
Console.WriteLine(bicep);
```

### Create a Service Bus namespace with topic and subscription

```csharp
using Azure.Provisioning;
using Azure.Provisioning.ServiceBus;

Infrastructure infrastructure = new Infrastructure();

// Create Service Bus namespace with premium tier
ServiceBusNamespace serviceBusNamespace = new ServiceBusNamespace("serviceBusNamespace")
{
    Sku = new ServiceBusSku { Name = ServiceBusSkuName.Premium, Capacity = 1 }
};
infrastructure.Add(serviceBusNamespace);

// Create a topic
ServiceBusTopic topic = new ServiceBusTopic("topic")
{
    Parent = serviceBusNamespace,
    Name = "notifications",
    MaxSizeInMegabytes = 1024,
    EnablePartitioning = true
};
infrastructure.Add(topic);

// Create a subscription for the topic
ServiceBusSubscription subscription = new ServiceBusSubscription("subscription")
{
    Parent = topic,
    Name = "emailSubscription",
    LockDuration = TimeSpan.FromMinutes(1),
    MaxDeliveryCount = 10
};
infrastructure.Add(subscription);

string bicep = infrastructure.Compile();
Console.WriteLine(bicep);
```

For detailed examples and resource-specific configurations, please refer to the test files in the `tests/` directory of this library, which demonstrate practical usage scenarios and configuration patterns.

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

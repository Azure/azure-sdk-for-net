# Azure Provisioning ServiceBus client library for .NET

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

### Create a Service Bus Queue

This example demonstrates how to create a Service Bus namespace with a queue for reliable messaging scenarios.

```C# Snippet:ServiceBusBasic
Infrastructure infra = new();

ProvisioningParameter queueName =
    new(nameof(queueName), typeof(string))
    {
        Value = "orders",
        Description = "The name of the SB queue."
    };
infra.Add(queueName);

ServiceBusNamespace sb =
    new(nameof(sb), ServiceBusNamespace.ResourceVersions.V2021_11_01)
    {
        Sku = new ServiceBusSku { Name = ServiceBusSkuName.Standard },
    };
infra.Add(sb);

ServiceBusQueue queue =
    new(nameof(queue), ServiceBusNamespace.ResourceVersions.V2021_11_01)
    {
        Parent = sb,
        Name = queueName,
        LockDuration = TimeSpan.FromMinutes(5),
        MaxSizeInMegabytes = 1024,
        RequiresDuplicateDetection = false,
        RequiresSession = false,
        DefaultMessageTimeToLive = TimeSpan.MaxValue,
        DeadLetteringOnMessageExpiration = false,
        DuplicateDetectionHistoryTimeWindow = TimeSpan.FromMinutes(10),
        MaxDeliveryCount = 10,
        AutoDeleteOnIdle = TimeSpan.MaxValue,
        EnablePartitioning = false,
        EnableExpress = false
    };
infra.Add(queue);
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

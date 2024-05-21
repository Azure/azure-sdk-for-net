# Azure Provisioning client library for .NET

Azure.Provisioning.OperationalInsights simplifies declarative resource provisioning in .NET for Azure Operational Insights.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Provisioning.OperationalInsights
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure diretly without needing to write or maintain bicep or arm templates.

## Examples

Here is a simple example which creates a KeyVault.

First create your Infrastructure class.

```C# Snippet:SampleInfrastructure
public class SampleInfrastructure : Infrastructure
{
    public SampleInfrastructure() : base(envName: "Sample", tenantId: Guid.Empty, subscriptionId: Guid.Empty, configuration: new Configuration { UseInteractiveMode = true })
    {
    }
}
```

Next add your resources into your infrastructure and then Build.

```C# Snippet:KeyVaultOnly
// Create a new infrastructure
var infrastructure = new SampleInfrastructure();

// Add a new key vault
var keyVault = infrastructure.AddKeyVault();

// You can call Build to convert the infrastructure into bicep files.
infrastructure.Build();
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


# Azure Provisioning client library for .NET

Azure.Provisioning makes it easy to declaratively specify Azure infrastructure natively in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Provisioning
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Create a simple storage account

```csharp
using Azure.Provisioning;
using Azure.Provisioning.Storage;

// Create a new Infrastructure instance
Infrastructure infrastructure = new Infrastructure();

// Define a storage account
StorageAccount storage = new StorageAccount("storage")
{
    Kind = StorageKind.StorageV2,
    Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
    IsHnsEnabled = true,
    AllowBlobPublicAccess = false
};

// Add it to the infrastructure
infrastructure.Add(storage);

// Generate the Bicep template
string bicep = infrastructure.Compile();
Console.WriteLine(bicep);
```

### Create a resource group in a subscription

```csharp
using Azure.Provisioning;
using Azure.Provisioning.Resources;

// Create infrastructure scoped to a subscription
Infrastructure infrastructure = new Infrastructure { TargetScope = DeploymentScope.Subscription };

// Create a resource group
ResourceGroup resourceGroup = new ResourceGroup("rg_test", "2024-03-01");
infrastructure.Add(resourceGroup);

// Generate the Bicep template
string bicep = infrastructure.Compile();
Console.WriteLine(bicep);
```

### Working with outputs

```csharp
using Azure.Provisioning;
using Azure.Provisioning.Storage;

Infrastructure infrastructure = new Infrastructure();

// Create a storage account
StorageAccount storage = new StorageAccount("storage")
{
    Kind = StorageKind.StorageV2,
    Sku = new StorageSku { Name = StorageSkuName.StandardLrs }
};
infrastructure.Add(storage);

// Create an output for the storage endpoint
ProvisioningOutput endpoint = new ProvisioningOutput("storageEndpoint", typeof(string))
{
    Value = storage.PrimaryEndpoints.BlobUri
};
infrastructure.Add(endpoint);

// Generate the Bicep template with outputs
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


# Azure Provisioning client library for .NET

Azure.Provisioning.Storage simplifies declarative resource provisioning in .NET for Azure Storage.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Provisioning.Storage
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Create a storage account with blob services

```csharp
using Azure.Provisioning;
using Azure.Provisioning.Storage;

Infrastructure infrastructure = new Infrastructure();

// Create a storage account
StorageAccount storage = new StorageAccount("storage")
{
    Kind = StorageKind.StorageV2,
    Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
    IsHnsEnabled = true,
    AllowBlobPublicAccess = false
};
infrastructure.Add(storage);

// Add blob services
BlobService blobs = new BlobService("blobs") { Parent = storage };
infrastructure.Add(blobs);

// Generate the Bicep template
string bicep = infrastructure.Compile();
Console.WriteLine(bicep);
```

### Create a storage account with a blob container

```csharp
using Azure.Provisioning;
using Azure.Provisioning.Storage;

Infrastructure infrastructure = new Infrastructure();

// Create storage account
StorageAccount storage = new StorageAccount("storage")
{
    Kind = StorageKind.StorageV2,
    Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
    AccessTier = StorageAccountAccessTier.Hot
};
infrastructure.Add(storage);

// Add blob services
BlobService blobs = new BlobService("blobs") { Parent = storage };
infrastructure.Add(blobs);

// Create a blob container
BlobContainer container = new BlobContainer("container")
{
    Parent = blobs,
    Name = "mycontainer"
};
infrastructure.Add(container);

string bicep = infrastructure.Compile();
Console.WriteLine(bicep);
```

### Create a file share

```csharp
using Azure.Provisioning;
using Azure.Provisioning.Storage;

Infrastructure infrastructure = new Infrastructure();

// Create storage account
StorageAccount storage = new StorageAccount("storage")
{
    Kind = StorageKind.StorageV2,
    Sku = new StorageSku { Name = StorageSkuName.StandardLrs }
};
infrastructure.Add(storage);

// Add file services
FileService files = new FileService("files") { Parent = storage };
infrastructure.Add(files);

// Create a file share
FileShare share = new FileShare("share")
{
    Parent = files,
    Name = "photos"
};
infrastructure.Add(share);

string bicep = infrastructure.Compile();
Console.WriteLine(bicep);
```

### Storage account with role assignment

```csharp
using Azure.Provisioning;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.Storage;

Infrastructure infrastructure = new Infrastructure();

// Create storage account
StorageAccount storage = new StorageAccount("storage")
{
    Kind = StorageKind.StorageV2,
    Sku = new StorageSku { Name = StorageSkuName.StandardLrs }
};
infrastructure.Add(storage);

// Create a managed identity
UserAssignedIdentity identity = new UserAssignedIdentity("identity");
infrastructure.Add(identity);

// Create role assignment for Storage Blob Data Reader
RoleAssignment roleAssignment = storage.CreateRoleAssignment(StorageBuiltInRole.StorageBlobDataReader, identity);
infrastructure.Add(roleAssignment);

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


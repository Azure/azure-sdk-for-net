# Azure Provisioning DataFactory client library for .NET

Azure.Provisioning.DataFactory simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.DataFactory --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Create a Data Factory with a Linked Service

This example demonstrates how to create an Azure Data Factory with system-assigned managed identity and an Azure Blob Storage linked service.

```C# Snippet:DataFactoryBasic
Infrastructure infra = new();

ProvisioningParameter connectionString =
    new(nameof(connectionString), typeof(string))
    {
        Description = "The connection string for the storage account.",
        IsSecure = true
    };
infra.Add(connectionString);

DataFactoryService dataFactory =
    new(nameof(dataFactory), DataFactoryService.ResourceVersions.V2018_06_01)
    {
        Identity = new ManagedServiceIdentity
        {
            ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned
        }
    };
infra.Add(dataFactory);

DataFactoryLinkedService linkedService =
    new(nameof(linkedService), DataFactoryLinkedService.ResourceVersions.V2018_06_01)
    {
        Parent = dataFactory,
        Name = "ArmtemplateStorageLinkedService",
        Properties = new AzureBlobStorageLinkedService
        {
            ConnectionString = connectionString
        }
    };
infra.Add(linkedService);

infra.Add(new ProvisioningOutput("name", typeof(string)) { Value = dataFactory.Name });
infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = dataFactory.Id });
```

### Create a Data Factory with Git Config and Managed Virtual Network

This example demonstrates a more advanced setup with GitHub repository configuration, a managed virtual network, and a managed integration runtime.

```C# Snippet:DataFactoryGitConfigManagedVnet
Infrastructure infra = new();

ProvisioningParameter gitAccountName =
    new(nameof(gitAccountName), typeof(string))
    {
        Description = "Git account name."
    };
infra.Add(gitAccountName);

ProvisioningParameter gitRepositoryName =
    new(nameof(gitRepositoryName), typeof(string))
    {
        Description = "Git repository name."
    };
infra.Add(gitRepositoryName);

DataFactoryService dataFactory =
    new(nameof(dataFactory), DataFactoryService.ResourceVersions.V2018_06_01)
    {
        Identity = new ManagedServiceIdentity
        {
            ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned
        },
        PublicNetworkAccess = DataFactoryPublicNetworkAccess.Disabled,
        RepoConfiguration = new FactoryGitHubConfiguration
        {
            AccountName = gitAccountName,
            RepositoryName = gitRepositoryName,
            CollaborationBranch = "main",
            RootFolder = "/"
        }
    };
infra.Add(dataFactory);

DataFactoryManagedVirtualNetwork managedVnet =
    new(nameof(managedVnet), DataFactoryManagedVirtualNetwork.ResourceVersions.V2018_06_01)
    {
        Parent = dataFactory,
        Name = "default",
        Properties = new DataFactoryManagedVirtualNetworkProperties()
    };
infra.Add(managedVnet);

DataFactoryIntegrationRuntime integrationRuntime =
    new(nameof(integrationRuntime), DataFactoryIntegrationRuntime.ResourceVersions.V2018_06_01)
    {
        Parent = dataFactory,
        Name = "AutoResolveIntegrationRuntime",
        Properties = new ManagedIntegrationRuntime
        {
            ManagedVirtualNetwork = new ManagedVirtualNetworkReference
            {
                ReferenceName = "default",
                ReferenceType = ManagedVirtualNetworkReferenceType.ManagedVirtualNetworkReference
            },
            ComputeProperties = new IntegrationRuntimeComputeProperties
            {
                Location = new AzureLocation("AutoResolve")
            }
        }
    };
infra.Add(integrationRuntime);

infra.Add(new ProvisioningOutput("name", typeof(string)) { Value = dataFactory.Name });
infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = dataFactory.Id });
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
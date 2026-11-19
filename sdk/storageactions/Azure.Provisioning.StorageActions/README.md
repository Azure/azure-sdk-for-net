# Azure Provisioning Storage Actions client library for .NET

Azure.Provisioning.StorageActions simplifies declarative resource provisioning for Azure Storage Actions in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.StorageActions --prerelease
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using .NET. You can then use Azure Developer CLI (`azd`) to deploy your infrastructure to Azure without writing or maintaining Bicep or ARM templates.

Azure Storage Actions storage tasks define conditions and operations to manage blobs across Azure Storage accounts. Assign a task to a storage account to run its operations against matching blobs.

## Examples

### Create a storage task

The following example creates a storage task that moves cool-tier blobs to the hot tier.

```C# Snippet:StorageActionsBasic
Infrastructure infra = new();

StorageTask task =
    new(nameof(task), StorageTask.ResourceVersions.V2023_01_01)
    {
        Identity = new ManagedServiceIdentity
        {
            ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned,
        },
        Properties = new StorageTaskProperties
        {
            Description = "Move cool-tier blobs to the hot tier",
            IsEnabled = true,
            Action = new StorageTaskAction
            {
                If = new StorageTaskIfCondition
                {
                    Condition = "[[equals(AccessTier, 'Cool')]]",
                    Operations =
                    {
                        new StorageTaskOperationInfo
                        {
                            Name = StorageTaskOperationName.SetBlobTier,
                            Parameters = { ["tier"] = "Hot" },
                            OnSuccess = OnSuccessAction.Continue,
                            OnFailure = OnFailureAction.Break,
                        },
                    },
                },
            },
        },
    };
infra.Add(task);

infra.Add(new ProvisioningOutput("taskId", typeof(string)) { Value = task.Id });
```

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
- Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using the Azure and .NET tags.

## Next steps

Learn more about [Azure Storage Actions](https://learn.microsoft.com/azure/storage-actions/).

## Contributing

For details on contributing to this repository, see the [contributing guide][cg].

This project welcomes contributions and suggestions. Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have the
right to, and actually do, grant us the rights to use your contribution. For
details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether
you need to provide a CLA and decorate the PR appropriately. Follow the
instructions provided by the bot. You only need to do this once across all
repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information, see the [Code of Conduct FAQ][coc_faq] or contact
<opencode@microsoft.com> with any additional questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/

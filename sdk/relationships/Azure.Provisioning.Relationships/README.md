# Azure Provisioning Relationships client library for .NET

Azure.Provisioning.Relationships simplifies declarative resource provisioning for Azure resource relationships in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.Relationships --prerelease
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the client

## Key concepts

This library allows you to define relationships between Azure resources declaratively in .NET. Build an `Infrastructure` definition to generate Bicep, then deploy it using Azure Developer CLI or Azure Resource Manager.

Relationships are extension resources scoped to an existing resource. A dependency relationship identifies a target resource on which the scoped resource depends.

## Examples

### Create a dependency relationship

The following example creates two managed identities and defines a dependency between them.

```C# Snippet:RelationshipsBasic
Infrastructure infra = new();

UserAssignedIdentity source = new(nameof(source), "2023-01-31")
{
    Name = "source-identity",
};
infra.Add(source);

UserAssignedIdentity target = new(nameof(target), "2023-01-31")
{
    Name = "target-identity",
};
infra.Add(target);

DependencyOfRelationship relationship =
    new(nameof(relationship), DependencyOfRelationship.ResourceVersions.V2026_08_01)
    {
        Name = "dependency",
        Scope = source,
        Properties = new DependencyOfRelationshipProperties
        {
            TargetId = target.Id,
        },
    };
infra.Add(relationship);
```

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
- Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

See the [Azure.Provisioning documentation](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/provisioning/Azure.Provisioning) for more information about defining and deploying infrastructure.

## Contributing

For details on contributing to this repository, see the [contributing guide][cg].

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately. You will only need to do this once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information, see the [Code of Conduct FAQ][coc_faq] or contact <opencode@microsoft.com> with any additional questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/

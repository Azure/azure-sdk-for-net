# Azure Provisioning ServiceGroups client library for .NET

Azure.Provisioning.ServiceGroups simplifies declarative resource provisioning in .NET.
Service groups organize resources, resource groups, subscriptions, and other service groups into a hierarchy.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.ServiceGroups --prerelease
```

### Prerequisites

You need an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and
permissions to create service groups and deploy resources at tenant scope.

### Authenticate the client

Defining infrastructure and compiling it to Bicep does not require authentication.
Deploying the resulting template requires an authenticated Azure identity with
the appropriate tenant-level permissions.

## Key concepts

This library lets you describe infrastructure declaratively in .NET and compile
it into Bicep for deployment. Service groups are tenant-scoped resources, so set
`Infrastructure.TargetScope` to `DeploymentScope.Tenant`. They do not require a location.

## Examples

### Create a service group

```C# Snippet:ServiceGroupsBasic
Infrastructure infra = new()
{
    TargetScope = DeploymentScope.Tenant,
};

ServiceGroup group =
    new(nameof(group), ServiceGroup.ResourceVersions.V2026_08_01)
    {
        Name = "sample-service-group",
        Properties = new ServiceGroupProperties
        {
            DisplayName = "Sample service group",
            AttributesCriticality = 2,
        },
        Tags = { ["environment"] = "test" },
    };
infra.Add(group);
```

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
- For deployment authorization failures, verify that your identity has the required tenant-level permissions.

## Next steps

See the [Azure.Provisioning documentation](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/provisioning/Azure.Provisioning)
for details about compiling and deploying infrastructure.

## Contributing

For details on contributing to this repository, see the [contributing guide][cg].

This project welcomes contributions and suggestions. Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution.
For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether
you need to provide a CLA and decorate the PR appropriately. Follow the
instructions provided by the bot. You will only need to do this once across
all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information, see the [Code of Conduct FAQ][coc_faq] or contact
<opencode@microsoft.com> with any additional questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/

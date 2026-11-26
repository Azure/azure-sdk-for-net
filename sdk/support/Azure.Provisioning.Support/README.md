# Azure Provisioning Support client library for .NET

Azure.Provisioning.Support simplifies declarative resource provisioning for Azure Support in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.Support --prerelease
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the client

Defining infrastructure and generating Bicep does not require authentication.
Deploying the generated template requires an authenticated Azure deployment tool,
such as the Azure CLI or Azure Developer CLI, and permissions to manage the resources.

## Key concepts

This library lets you define Azure Support resources declaratively in .NET and
generate Bicep templates without writing the templates by hand. It includes
support tickets, communications, file workspaces, and related resource models
using the `2024-04-01` and `2025-06-01-preview` API versions. Resources default
to `2025-06-01-preview`; pass an explicit resource version to use a stable API.

Support resources can be scoped to a subscription or tenant. Set the
infrastructure's target scope to match the resources you are provisioning.
Use `FromExisting` to reference a resource without creating it.

## Examples

### Create a subscription-scoped file workspace

A file workspace holds attachments for Azure Support. This example defines a
subscription-scoped workspace using the stable `2024-04-01` API and outputs its
resource identifier.

```C# Snippet:SupportFileWorkspaceBasic
Infrastructure infra = new() { TargetScope = DeploymentScope.Subscription };

FileWorkspaceDetail workspace = new(nameof(workspace), FileWorkspaceDetail.ResourceVersions.V2024_04_01)
{
    Name = "supportfiles",
};
infra.Add(workspace);

infra.Add(new ProvisioningOutput("workspaceId", typeof(string)) { Value = workspace.Id });
```

Build the infrastructure into a provisioning plan and save the generated Bicep
with `infra.Build().Save(outputDirectory)`. Deploy the template at subscription
scope with your Azure deployment tool.

## Troubleshooting

File issues through [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
For deployment failures, check that the deployment scope and permissions match
the Support resource being provisioned.

## Next steps

Learn more about [Azure Support](https://learn.microsoft.com/azure/azure-portal/supportability/how-to-create-azure-support-request)
and [Azure.Provisioning](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/provisioning/Azure.Provisioning).

## Contributing

For details on contributing to this repository, see the [contributing guide][cg].

This project welcomes contributions and suggestions. Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution.
For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether
you need to provide a CLA and decorate the PR appropriately. You only need to
do this once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information, see the [Code of Conduct FAQ][coc_faq] or contact
<opencode@microsoft.com> with questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/

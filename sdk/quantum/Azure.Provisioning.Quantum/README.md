# Azure Provisioning Quantum client library for .NET

Azure.Provisioning.Quantum simplifies declarative resource provisioning for Azure Quantum in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.Quantum --prerelease
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) to deploy resources.

## Key concepts

This library allows you to define Azure Quantum workspaces declaratively in .NET.
Build an `Infrastructure` containing your resources and compile it to Bicep for deployment to Azure.
See the [Azure.Provisioning documentation](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/provisioning/Azure.Provisioning) for deployment guidance.

## Examples

### Create a Quantum workspace

The following example defines a V2 Quantum workspace with a system-assigned managed identity and API key authentication disabled.
The example uses a preview resource API version; suppress the `AZPROVISION001` diagnostic in your project to opt in to preview APIs.

```C# Snippet:QuantumWorkspaceBasic
Infrastructure infra = new();

QuantumWorkspace workspace =
    new(nameof(workspace), QuantumWorkspace.ResourceVersions.V2026_06_15_PREVIEW)
    {
        Name = "quantum-workspace",
        Identity = new ManagedServiceIdentity
        {
            ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned,
        },
        Properties = new QuantumWorkspaceProperties
        {
            WorkspaceKind = QuantumWorkspaceKind.V2,
            IsApiKeyEnabled = false,
        },
        Tags = { ["environment"] = "test" },
    };
infra.Add(workspace);

infra.Add(new ProvisioningOutput("workspaceId", typeof(string)) { Value = workspace.Id });
```

## Troubleshooting

File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).

## Next steps

Explore the [Azure Quantum documentation](https://learn.microsoft.com/azure/quantum/).

## Contributing

For details on contributing to this repository, see the [contributing guide](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md).

This project welcomes contributions and suggestions. Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide a
CLA and decorate the PR appropriately. You will only need to do this once across all repositories
using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information, see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/)
or contact <opencode@microsoft.com> with any additional questions or comments.

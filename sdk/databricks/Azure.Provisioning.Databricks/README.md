# Azure Provisioning Databricks client library for .NET

Azure.Provisioning.Databricks simplifies declarative resource provisioning for Azure Databricks in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.Databricks --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library lets you define Azure Databricks infrastructure declaratively in .NET and deploy it with Azure Developer CLI.

## Examples

### Create an Azure Databricks workspace

```C# Snippet:DatabricksWorkspaceBasic
Infrastructure infra = new();

DatabricksWorkspace workspace =
    new(nameof(workspace), DatabricksWorkspace.ResourceVersions.V2026_01_01)
    {
        Location = new AzureLocation("eastus"),
        Sku = new DatabricksSku { Name = "premium" },
        ComputeMode = DatabricksComputeMode.Serverless,
    };
infra.Add(workspace);
```

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).

## Next steps

## Contributing

For details on contributing to this repository, see the [contributing guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md).

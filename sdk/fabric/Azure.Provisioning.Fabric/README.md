# Azure Provisioning Fabric client library for .NET

Azure.Provisioning.Fabric simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.Fabric --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to define Microsoft Fabric infrastructure declaratively in .NET and deploy it with Azure Developer CLI.

## Examples

### Reference an existing Fabric capacity

```C# Snippet:FabricBasic
Infrastructure infra = new();

FabricCapacity capacity = FabricCapacity.FromExisting(nameof(capacity), FabricCapacity.ResourceVersions.V2026_09_01_PREVIEW);
capacity.Name = "existingCapacity";
infra.Add(capacity);
```

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).

## Next steps

## Contributing

For details on contributing to this repository, see the [contributing guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md).

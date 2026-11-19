# Azure Provisioning ApiCenter client library for .NET

Azure.Provisioning.ApiCenter simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.ApiCenter --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using .NET. You can then use azd to deploy your infrastructure to Azure without needing to write or maintain Bicep or ARM templates.

## Examples

### Create an API Center service and workspace

This example demonstrates how to create an API Center service and workspace.

```C# Snippet:ApiCenterBasic
Infrastructure infra = new();

ApiCenterService service =
    new(nameof(service), ApiCenterService.ResourceVersions.V2024_06_01_PREVIEW)
    {
        Tags = { ["environment"] = "test" },
    };
infra.Add(service);

ApiCenterWorkspace workspace =
    new(nameof(workspace), ApiCenterWorkspace.ResourceVersions.V2024_06_01_PREVIEW)
    {
        Parent = service,
    };
infra.Add(workspace);
```

## Next steps

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
- Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Contributing

For details on contributing to the Azure SDK for .NET, see the [contributing guide](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md).

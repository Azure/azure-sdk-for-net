# Azure Provisioning DataBox client library for .NET

Azure.Provisioning.DataBox simplifies declarative provisioning for Azure Data Box in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.DataBox --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library lets you define Azure Data Box infrastructure declaratively in .NET and deploy it with Azure Developer CLI.

## Examples

### Create a Data Box job

```C# Snippet:DataBoxJobBasic
Infrastructure infra = new();

DataBoxJob dataBoxJob = new(nameof(dataBoxJob), DataBoxJob.ResourceVersions.V2025_07_01)
{
    Name = "databox-job",
    Location = new AzureLocation("eastus"),
    Details = new DataBoxBasicJobDetails(),
    Sku = new DataBoxSku()
};
infra.Add(dataBoxJob);
```

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).

## Next steps

## Contributing

For details on contributing to this repository, see the [contributing guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md).

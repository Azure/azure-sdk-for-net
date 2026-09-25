# Azure Provisioning AppNetwork client library for .NET

Azure.Provisioning.AppNetwork simplifies declarative provisioning for Azure App Network in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.AppNetwork --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library lets you define Azure App Network infrastructure declaratively in .NET and deploy it with Azure Developer CLI.

## Examples

### Create an App Network

```C# Snippet:AppLinkBasic
Infrastructure infra = new();

AppLink appLink = new(nameof(appLink), AppLink.ResourceVersions.V2026_08_01_PREVIEW)
{
    Name = "app-link",
    Location = new AzureLocation("eastus")
};
infra.Add(appLink);
```

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).

## Next steps

## Contributing

For details on contributing to this repository, see the [contributing guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md).

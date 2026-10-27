# Azure Provisioning Agriculture Platform client library for .NET

Azure.Provisioning.AgriculturePlatform simplifies declarative resource provisioning for Azure Agriculture Platform in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.AgriculturePlatform --prerelease
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) to deploy resources.

### Authenticate the client

This library defines infrastructure and generates Bicep without making service calls. Deployment requires an authenticated Azure environment, such as Azure Developer CLI (`azd`) or Azure CLI.

## Key concepts

Use `Infrastructure` to describe Azure resources in a declarative style with .NET. Add an `AgricultureService` to define an AgriService resource, configure its properties, and expose values with `ProvisioningOutput`. The resulting infrastructure compiles to Bicep for deployment without maintaining handwritten Bicep or ARM templates.

This initial release supports the `2024-06-01-preview` API version. Use `AgricultureService.FromExisting` to reference an AgriService resource that has already been deployed.

## Examples

### Create an Agriculture Service

The following example defines an AgriService resource with tags and outputs its name and resource ID.

```C# Snippet:AgriculturePlatformBasic
Infrastructure infra = new();

AgricultureService service =
    new(nameof(service), AgricultureService.ResourceVersions.V2024_06_01_PREVIEW)
    {
        Tags = { ["environment"] = "test" },
    };
infra.Add(service);

infra.Add(new ProvisioningOutput("serviceName", typeof(string)) { Value = service.Name });
infra.Add(new ProvisioningOutput("serviceId", typeof(string)) { Value = service.Id });
```

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
- Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) on Stack Overflow using the Azure and .NET tags.

## Next steps

Learn more about [Azure Data Manager for Agriculture](https://learn.microsoft.com/azure/data-manager-for-agri/) and [Azure provisioning libraries](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/provisioning).

## Contributing

For details on contributing to this repository, see the [contributing guide][cg].

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately. Follow the instructions provided by the bot. You will only need to do this once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information, see the [Code of Conduct FAQ][coc_faq] or contact <opencode@microsoft.com> with any other questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/

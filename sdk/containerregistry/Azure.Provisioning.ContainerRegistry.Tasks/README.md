# Azure Provisioning Container Registry Tasks client library for .NET

Azure.Provisioning.ContainerRegistry.Tasks simplifies declarative provisioning of Azure Container Registry Tasks resources in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.ContainerRegistry.Tasks --prerelease
dotnet add package Azure.Provisioning.ContainerRegistry --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the client

## Key concepts

This library allows you to specify Container Registry Tasks infrastructure declaratively in .NET. You can then use `azd` to deploy the generated Bicep without writing or maintaining ARM templates directly.

## Examples

### Create a Container Registry Docker build task

```C# Snippet:ContainerRegistryTaskBasic
Infrastructure infra = new();

ContainerRegistryService registry =
    new(nameof(registry), ContainerRegistryService.ResourceVersions.V2023_07_01)
    {
        Name = BicepFunction.Take(BicepFunction.Interpolate($"registry{BicepFunction.GetUniqueString(BicepFunction.GetResourceGroup().Id)}"), 50),
        Sku = new ContainerRegistrySku { Name = ContainerRegistrySkuName.Standard },
    };
infra.Add(registry);

ContainerRegistryTask task =
    new(nameof(task), ContainerRegistryTask.ResourceVersions.V2025_03_01_PREVIEW)
    {
        Name = BicepFunction.Interpolate($"{registry.Name}/build"),
        Status = ContainerRegistryTaskStatus.Enabled,
        Platform = new ContainerRegistryTaskPlatformProperties
        {
            OS = ContainerRegistryTaskOS.Linux,
        },
        Step = new DockerBuildStep
        {
            ContextPath = "https://github.com/Azure-Samples/acr-tasks.git",
            DockerFilePath = "Dockerfile",
            ImageNames = { "sample:{{.Run.ID}}" },
            IsPushEnabled = true,
        },
    };
infra.Add(task);
```

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
- Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

## Contributing

For details on contributing to this repository, see the [contributing guide][cg].

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately. Follow the instructions provided by the bot. You only need to do this once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information, see the [Code of Conduct FAQ][coc_faq] or contact <opencode@microsoft.com> with any other questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/

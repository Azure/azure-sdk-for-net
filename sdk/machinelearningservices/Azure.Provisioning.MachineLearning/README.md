# Azure Provisioning Machine Learning client library for .NET

Azure.Provisioning.MachineLearning simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.MachineLearning --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using .NET. You can then use `azd` to deploy your infrastructure to Azure without needing to write or maintain Bicep or ARM templates.

## Examples

### Create a Machine Learning workspace with required dependencies

This example creates an Azure Machine Learning workspace with Azure Storage, Azure Key Vault, Application Insights, and Azure Container Registry, based on the [Azure quickstart template](https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.machinelearningservices/machine-learning-workspace/main.bicep).

```C# Snippet:MachineLearningWorkspaceBasic
Infrastructure infra = new();

ProvisioningVariable tenantId =
    new(nameof(tenantId), typeof(string))
    {
        Value = BicepFunction.GetSubscription().TenantId
    };
infra.Add(tenantId);

StorageAccount storage =
    new(nameof(storage), StorageAccount.ResourceVersions.V2022_05_01)
    {
        Kind = StorageKind.StorageV2,
        Sku = new StorageSku { Name = StorageSkuName.StandardRagrs },
        AllowBlobPublicAccess = false,
        EnableHttpsTrafficOnly = true,
        Encryption =
            new StorageAccountEncryption
            {
                Services =
                    new StorageAccountEncryptionServices
                    {
                        Blob = new StorageEncryptionService { IsEnabled = true },
                        File = new StorageEncryptionService { IsEnabled = true },
                    },
                KeySource = StorageAccountKeySource.Storage,
            },
        MinimumTlsVersion = StorageMinimumTlsVersion.Tls1_2,
        NetworkRuleSet =
            new StorageAccountNetworkRuleSet
            {
                DefaultAction = StorageNetworkDefaultAction.Deny,
            },
    };
infra.Add(storage);

KeyVaultService vault =
    new(nameof(vault), KeyVaultService.ResourceVersions.V2022_07_01)
    {
        Properties =
            new Azure.Provisioning.KeyVault.KeyVaultProperties
            {
                TenantId = tenantId,
                Sku = new KeyVaultSku
                {
                    Family = KeyVaultSkuFamily.A,
                    Name = KeyVaultSkuName.Standard,
                },
                AccessPolicies = new BicepList<KeyVaultAccessPolicy>([]),
                EnableSoftDelete = true,
            },
    };
infra.Add(vault);

ApplicationInsightsComponent applicationInsight =
    new(nameof(applicationInsight), ApplicationInsightsComponent.ResourceVersions.V2020_02_02)
    {
        Kind = "web",
        ApplicationType = ApplicationInsightsApplicationType.Web,
    };
infra.Add(applicationInsight);

ContainerRegistryService registry =
    new(nameof(registry), ContainerRegistryService.ResourceVersions.V2022_12_01)
    {
        Sku = new ContainerRegistrySku { Name = ContainerRegistrySkuName.Standard },
        IsAdminUserEnabled = false,
    };
infra.Add(registry);

MachineLearningWorkspace workspace =
    new(nameof(workspace), MachineLearningWorkspace.ResourceVersions.V2026_05_01)
    {
        ApplicationInsights = applicationInsight.Id,
        ContainerRegistry = registry.Id,
        FriendlyName = "Machine Learning workspace",
        Identity = new ManagedServiceIdentity
        {
            ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned
        },
        KeyVault = vault.Id,
        StorageAccount = storage.Id,
    };
infra.Add(workspace);
```

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
- Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

## Contributing

For details on contributing to this repository, see the [contributing guide][cg].

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (for example, label, comment). Follow the instructions provided by the bot. You'll only need to do this action once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information, see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any other questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/

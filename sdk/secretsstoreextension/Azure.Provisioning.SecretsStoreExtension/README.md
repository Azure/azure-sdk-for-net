# Azure Provisioning Secrets Store Extension client library for .NET

Azure.Provisioning.SecretsStoreExtension simplifies declarative resource provisioning for Azure Secrets Store Extension in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.SecretsStoreExtension --prerelease
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).
Deploying these resources requires a Kubernetes cluster with the Secrets Store Extension and an Azure Arc custom location.

### Authenticate the Client

## Key concepts

This library allows you to define Secrets Store Extension resources declaratively in .NET and compile them into Bicep templates.
Key Vault secret provider classes describe how to access secrets in Azure Key Vault, and secret sync resources map those secrets to Kubernetes secrets.

## Examples

### Create a Key Vault secret provider class and secret sync

The following example defines a secret provider class and secret sync for an existing Azure Key Vault and custom location.
Supply the client ID of a managed identity with access to the vault and its Microsoft Entra tenant ID when deploying the template.

```C# Snippet:SecretsStoreExtensionBasic
Infrastructure infra = new();

ProvisioningParameter keyVaultName = new(nameof(keyVaultName), typeof(string));
ProvisioningParameter clientId = new(nameof(clientId), typeof(Guid));
ProvisioningParameter tenantId = new(nameof(tenantId), typeof(Guid));
ProvisioningParameter customLocationId = new(nameof(customLocationId), typeof(string));
infra.Add(keyVaultName);
infra.Add(clientId);
infra.Add(tenantId);
infra.Add(customLocationId);

KeyVaultSecretProviderClass provider = new(nameof(provider))
{
    Name = "key-vault-provider",
    ExtendedLocation = new ExtendedAzureLocation
    {
        Name = customLocationId,
        // The shared enum does not yet include CustomLocation.
        ExtendedLocationType = new StringLiteralExpression("CustomLocation"),
    },
    Properties = new KeyVaultSecretProviderClassProperties
    {
        KeyvaultName = keyVaultName,
        ClientId = clientId,
        TenantId = tenantId,
        CloudName = AzureCloudName.AzurePublicCloud,
        Objects = "array:\n  - |\n    objectName: application-secret\n    objectType: secret",
    },
};
infra.Add(provider);

SecretSync sync = new(nameof(sync))
{
    Name = "secret-sync",
    ExtendedLocation = new ExtendedAzureLocation
    {
        Name = customLocationId,
        ExtendedLocationType = new StringLiteralExpression("CustomLocation"),
    },
    Properties = new SecretSyncProperties
    {
        SecretProviderClassName = provider.Name,
        ServiceAccountName = "secret-sync-account",
        KubernetesSecretType = KubernetesSecretType.Opaque,
        ObjectSecretMapping =
        {
            new KubernetesSecretObjectMapping
            {
                SourcePath = "application-secret",
                TargetKey = "password",
            },
        },
    },
};
sync.DependsOn.Add(provider);
infra.Add(sync);
```

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
- Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

Learn more about [Azure Arc-enabled Kubernetes](https://learn.microsoft.com/azure/azure-arc/kubernetes/overview).

## Contributing

For details on contributing to this repository, see the [contributing guide][cg].

This project welcomes contributions and suggestions. Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately. Follow the instructions provided by the bot.
You'll only need to do this once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information, see the [Code of Conduct FAQ][coc_faq] or contact
<opencode@microsoft.com> with any additional questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/

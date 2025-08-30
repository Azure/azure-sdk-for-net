# Azure Provisioning KeyVault client library for .NET

Azure.Provisioning.KeyVault simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Provisioning.KeyVault
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Create a Basic Key Vault With Secret

This example demonstrates how to create a Key Vault and store a secret, based on the [Azure quickstart template](https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.keyvault/key-vault-create/main.bicep).

```C# Snippet:KeyVaultBasic
Infrastructure infra = new();

ProvisioningParameter skuName =
    new(nameof(skuName), typeof(string))
    {
        Value = KeyVaultSkuName.Standard,
        Description = "Vault type"
    };
infra.Add(skuName);

ProvisioningParameter secretValue =
    new(nameof(secretValue), typeof(string))
    {
        Description = "Specifies the value of the secret that you want to create.",
        IsSecure = true
    };
infra.Add(secretValue);

ProvisioningParameter objectId =
    new(nameof(objectId), typeof(string))
    {
        Description = "Specifies the object ID of a user, service principal or security group in the Azure Active Directory tenant for the vault."
    };
infra.Add(objectId);

ProvisioningVariable tenantId =
    new(nameof(tenantId), typeof(string))
    {
        Value = BicepFunction.GetSubscription().TenantId
    };
infra.Add(tenantId);

KeyVaultService kv =
    new(nameof(kv), KeyVaultService.ResourceVersions.V2023_07_01)
    {
        Properties =
            new KeyVaultProperties
            {
                Sku = new KeyVaultSku { Name = skuName, Family = KeyVaultSkuFamily.A, },
                TenantId = tenantId,
                EnableSoftDelete = true,
                SoftDeleteRetentionInDays = 90,
                AccessPolicies =
                {
                    new KeyVaultAccessPolicy
                    {
                        ObjectId = objectId,
                        TenantId = tenantId,
                        Permissions =
                            new IdentityAccessPermissions
                            {
                                Keys = { IdentityAccessKeyPermission.List },
                                Secrets = { IdentityAccessSecretPermission.List }
                            }
                    }
                },
                NetworkRuleSet =
                    new KeyVaultNetworkRuleSet
                    {
                        DefaultAction = KeyVaultNetworkRuleAction.Allow,
                        Bypass = KeyVaultNetworkRuleBypassOption.AzureServices
                    }
            }
    };
infra.Add(kv);

KeyVaultSecret secret =
    new(nameof(secret), KeyVaultSecret.ResourceVersions.V2023_07_01)
    {
        Parent = kv,
        Name = "myDarkNecessities",
        Properties = new SecretProperties { Value = secretValue }
    };
infra.Add(secret);

infra.Add(new ProvisioningOutput("name", typeof(string)) { Value = kv.Name });
infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = kv.Id });
infra.Add(new ProvisioningOutput("vaultUri", typeof(string)) { Value = kv.Properties.VaultUri });
```

## Troubleshooting

-   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
-   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

## Contributing

For details on contributing to this repository, see the [contributing
guide][cg].

This project welcomes contributions and suggestions. Most contributions
require you to agree to a Contributor License Agreement (CLA) declaring
that you have the right to, and actually do, grant us the rights to use
your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine
whether you need to provide a CLA and decorate the PR appropriately
(for example, label, comment). Follow the instructions provided by the
bot. You'll only need to do this action once across all repositories
using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For
more information, see the [Code of Conduct FAQ][coc_faq] or contact
<opencode@microsoft.com> with any other questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/

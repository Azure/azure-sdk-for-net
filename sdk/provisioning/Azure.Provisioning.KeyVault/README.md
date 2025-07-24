# Azure.Provisioning.KeyVault client library for .NET

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

### Create a Key Vault with access policies

```csharp
using Azure.Provisioning;
using Azure.Provisioning.KeyVault;

Infrastructure infrastructure = new Infrastructure();

// Define parameters for Key Vault configuration
ProvisioningParameter objectId = new ProvisioningParameter("objectId", typeof(string))
{
    Description = "Specifies the object ID of a user, service principal or security group in the Azure Active Directory tenant for the vault."
};
infrastructure.Add(objectId);

// Create the Key Vault
KeyVaultService keyVault = new KeyVaultService("keyVault")
{
    Properties = new KeyVaultProperties
    {
        Sku = new KeyVaultSku 
        { 
            Name = KeyVaultSkuName.Standard, 
            Family = KeyVaultSkuFamily.A 
        },
        TenantId = BicepFunction.GetSubscription().TenantId,
        EnableSoftDelete = true,
        SoftDeleteRetentionInDays = 90,
        AccessPolicies =
        {
            new KeyVaultAccessPolicy
            {
                ObjectId = objectId,
                TenantId = BicepFunction.GetSubscription().TenantId,
                Permissions = new IdentityAccessPermissions
                {
                    Keys = { IdentityAccessKeyPermission.List },
                    Secrets = { IdentityAccessSecretPermission.List, IdentityAccessSecretPermission.Get }
                }
            }
        },
        NetworkRuleSet = new KeyVaultNetworkRuleSet
        {
            DefaultAction = KeyVaultNetworkRuleAction.Allow,
            Bypass = KeyVaultNetworkRuleBypassOption.AzureServices
        }
    }
};
infrastructure.Add(keyVault);

// Generate the Bicep template
string bicep = infrastructure.Compile();
Console.WriteLine(bicep);
```

### Create a Key Vault with secrets

```csharp
using Azure.Provisioning;
using Azure.Provisioning.KeyVault;

Infrastructure infrastructure = new Infrastructure();

// Create secure parameters for secrets
ProvisioningParameter secretValue = new ProvisioningParameter("secretValue", typeof(string))
{
    Description = "Specifies the value of the secret that you want to create.",
    IsSecure = true
};
infrastructure.Add(secretValue);

// Create the Key Vault
KeyVaultService keyVault = new KeyVaultService("keyVault")
{
    Properties = new KeyVaultProperties
    {
        Sku = new KeyVaultSku { Name = KeyVaultSkuName.Standard, Family = KeyVaultSkuFamily.A },
        TenantId = BicepFunction.GetSubscription().TenantId,
        EnableSoftDelete = true
    }
};
infrastructure.Add(keyVault);

// Create a secret in the vault
KeyVaultSecret secret = new KeyVaultSecret("mySecret")
{
    Parent = keyVault,
    Name = "connectionString",
    Properties = new SecretProperties { Value = secretValue }
};
infrastructure.Add(secret);

// Output the vault URI
ProvisioningOutput vaultUri = new ProvisioningOutput("vaultUri", typeof(string))
{
    Value = keyVault.Properties.VaultUri
};
infrastructure.Add(vaultUri);

string bicep = infrastructure.Compile();
Console.WriteLine(bicep);
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

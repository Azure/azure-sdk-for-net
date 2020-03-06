# Azure KeyVault Key Encryptor for Microsoft.AspNetCore.DataProtection

The `Azure.AspNetCore.DataProtection.Keys` package allows protecting keys at rest using Azure KeyVault Key Encryption/Wrapping feature.

## Getting started

### Install the package

Install the package with [NuGet][nuget]:

```Powershell
dotnet add package Azure.AspNetCore.DataProtection.Keys -v 1.0.0-preview.1
```

### Prerequisites

You need an [Azure subscription][azure_sub],
[KeyVault Vault][keyvault_doc] and a Key to use this package.

To create a new KeyVault, you can use the [Azure Portal][keyvault_create_portal],
[Azure PowerShell][keyvault_create_ps], or the [Azure CLI][keyvault_create_cli].
Here's an example using the Azure CLI:

```Powershell
az keyvault create --name MyVault --resource-group MyResourceGroup --location westus
az keyvault key create --name MyKey --vault-name MyVault
```

## Examples

To protect keys using Azure Key Vault Key, configure the system with `ProtectKeysWithAzureKeyVault` when configuring the services:

```C# Snippet:ProtectKeysWithAzureKeyVault
public void ConfigureServices(IServiceCollection services)
{
    services
        .AddDataProtection()
        .ProtectKeysWithAzureKeyVault("<Key-ID>", new DefaultAzureCredential());
}
```

The [Azure Identity library][identity] provides easy Azure Active Directory support for authentication.

## Next steps

Read more about [DataProtection in ASP.NET Core](aspnetcore_dataprotection_doc).

## Contributing

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact [opencode@microsoft.com][coc_contact] with any
additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fextensions%2FAzure.AspNetCore.DataProtection.Keys%2FREADME.png)

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/extensions/Azure.AspNetCore.DataProtection.Keys/src
[package]: https://www.nuget.org/packages/Azure.AspNetCore.DataProtection.Keys/
[docs]: https://docs.microsoft.com/dotnet/api/Azure.AspNetCore.DataProtection.Keys
[nuget]: https://www.nuget.org/storage-quickstart-create-account?tabs=azure-powershell
[keyvault_create_cli]: https://docs.microsoft.com/en-us/azure/key-vault/quick-create-cli#create-a-key-vault
[keyvault_create_portal]: https://docs.microsoft.com/en-us/azure/key-vault/quick-create-portal#create-a-vault
[keyvault_create_ps]: https://docs.microsoft.com/en-us/azure/key-vault/quick-create-powershell#create-a-key-vault
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[identity]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity/README.md
[aspnetcore_dataprotection_doc]: https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/using-data-protection
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/core/Azure.Core/src/RequestFailedException.cs
[error_codes]: https://docs.microsoft.com/rest/api/storageservices/blob-service-error-codes
[samples]: samples/
[storage_contrib]: ../CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
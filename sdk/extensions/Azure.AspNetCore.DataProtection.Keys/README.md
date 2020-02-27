# Azure Storage Blob Key Store for Microsoft.AspNetCore.DataProtection

The `Azure.AspNetCore.DataProtection.Keys` package allows protecting keys at rest using Azure KeyVault 

## Getting started

### Install the package

Install the package with [NuGet][nuget]:

```Powershell
dotnet add package Azure.AspNetCore.DataProtection.Keys -v 1.0.0-preview.1
```

### Prerequisites

You need an [Azure subscription][azure_sub],
[KeyVault][storage_account_docs] and [Storage Container][storage_container_docs] to use this package.

To create a new Storage Account, you can use the [Azure Portal][storage_account_create_portal],
[Azure PowerShell][storage_account_create_ps], or the [Azure CLI][storage_account_create_cli].
Here's an example using the Azure CLI:

```Powershell
az storage account create --name MyStorageAccount --resource-group MyResourceGroup --location westus --sku Standard_LRS
az storage container create --account-name MyStorageAccount -n mycontainer
```

## Examples

To store keys in Azure Key Vault, configure the system with ProtectKeysWithAzureKeyVault in the Startup class:

```C# Snippet:IdentityAuth
public void ConfigureServices(IServiceCollection services)
{
    services
        .AddDataProtection()
        .ProtectKeysWithAzureKeyVault("<Key-ID>", new DefaultAzureCredential());
}
```

The [Azure Identity library][identity] provides easy Azure Active Directory support for authentication.

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
[nuget]: https://www.nuget.org/
[storage_account_docs]: https://docs.microsoft.com/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-powershell
[storage_account_create_cli]: https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-cli
[storage_account_create_portal]: https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-portal
[storage_container_docs]: https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blobs-introduction#containers
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[identity]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity/README.md
[storage_ad]: https://docs.microsoft.com/azure/storage/common/storage-auth-aad
[storage_ad_sample]: samples/Sample02c_Auth_ActiveDirectory.cs
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/core/Azure.Core/src/RequestFailedException.cs
[error_codes]: https://docs.microsoft.com/rest/api/storageservices/blob-service-error-codes
[samples]: samples/
[storage_contrib]: ../CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
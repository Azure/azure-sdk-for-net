# Azure Key Vault Key Encryptor for Microsoft.AspNetCore.DataProtection

The `Azure.Extensions.AspNetCore.DataProtection.Keys` package allows protecting keys at rest using Azure Key Vault Key Encryption/Wrapping feature.

## Getting started

### Install the package

Install the package with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Extensions.AspNetCore.DataProtection.Keys
```

### Prerequisites

You need an [Azure subscription][azure_sub],
[Key Vault][keyvault_doc] and a Key to use this package.

To create a new Key Vault, you can use the [Azure Portal][keyvault_create_portal],
[Azure PowerShell][keyvault_create_ps], or the [Azure CLI][keyvault_create_cli].
Here's an example using the Azure CLI:

```Powershell
az keyvault create --name MyVault --resource-group MyResourceGroup --location westus
az keyvault key create --name MyKey --vault-name MyVault

# give write access to a service principal (application)
az keyvault set-policy -n MyVault --object-id <application_id> --key-permissions get unwrapKey wrapKey
```

## Key concepts

### Thread safety
We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

To protect keys using Azure Key Vault Key, configure the system with `ProtectKeysWithAzureKeyVault` when configuring the services:

```C# Snippet:ProtectKeysWithAzureKeyVault
public void ConfigureServices(IServiceCollection services)
{
    services.AddDataProtection()
            .ProtectKeysWithAzureKeyVault(new Uri("<Key-ID>"), new DefaultAzureCredential());
}
```

The [Azure Identity library][identity] provides easy Azure Active Directory support for authentication.

## Next steps

Read more about [DataProtection in ASP.NET Core][aspnetcore_dataprotection_doc].

## Contributing

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact [opencode@microsoft.com][coc_contact] with any
additional questions or comments.

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/extensions/Azure.Extensions.AspNetCore.DataProtection.Keys/src
[package]: https://www.nuget.org/packages/Azure.Extensions.AspNetCore.DataProtection.Keys/
[docs]: https://learn.microsoft.com/dotnet/api/Azure.Extensions.AspNetCore.DataProtection.Keys
[nuget]: https://www.nuget.org/packages/Azure.Extensions.AspNetCore.DataProtection.Keys
[keyvault_doc]: https://learn.microsoft.com/azure/key-vault/general/overview
[keyvault_create_cli]: https://learn.microsoft.com/azure/key-vault/quick-create-cli#create-a-key-vault
[keyvault_create_portal]: https://learn.microsoft.com/azure/key-vault/quick-create-portal#create-a-vault
[keyvault_create_ps]: https://learn.microsoft.com/azure/key-vault/quick-create-powershell#create-a-key-vault
[azure_cli]: https://learn.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md
[aspnetcore_dataprotection_doc]: https://learn.microsoft.com/aspnet/core/security/data-protection/introduction?view=aspnetcore-3.1
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/src/RequestFailedException.cs
[error_codes]: https://learn.microsoft.com/rest/api/storageservices/blob-service-error-codes
[samples]: samples/
[storage_contrib]: ../CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com

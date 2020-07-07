# Azure Key Vault Secrets configuration provider for Microsoft.Extensions.Configuration

The `Azure.Extensions.AspNetCore.Configuration.Secrets` package allows storing configuration values using Azure Key Vault Secrets.

## Getting started

### Install the package

Install the package with [NuGet][nuget]:

```Powershell
dotnet add package Azure.Extensions.AspNetCore.Configuration.Secrets
```

### Prerequisites

You need an [Azure subscription][azure_sub] and
[Azure Key Vault][keyvault_doc] to use this package.

To create a new Key Vault, you can use the [Azure Portal][keyvault_create_portal],
[Azure PowerShell][keyvault_create_ps], or the [Azure CLI][keyvault_create_cli].
Here's an example using the Azure CLI:

```Powershell
az keyvault create --name MyVault --resource-group MyResourceGroup --location westus
az keyvault secret set --vault-name MyVault --name MySecret --value "hVFkk965BuUv"
```

## Examples

To load initialize configuration from Azure Key Vault secrets call the `AddAzureKeyVault` on `ConfigurationBuilder`:

```C# Snippet:ConfigurationAddAzureKeyVault
ConfigurationBuilder builder = new ConfigurationBuilder();
builder.AddAzureKeyVault(new Uri("<Vault URI>"), new DefaultAzureCredential());

IConfiguration configuration = builder.Build();
Console.WriteLine(configuration["MySecret"]);
```

The [Azure Identity library][identity] provides easy Azure Active Directory support for authentication.

## Next steps

Read more about [configuration in ASP.NET Core][aspnetcore_configuration_doc].

## Contributing

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact [opencode@microsoft.com][coc_contact] with any
additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fextensions%2FAzure.Extensions.AspNetCore.Configuration.Secrets%2FREADME.png)

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/extensions/Azure.Extensions.AspNetCore.Configuration.Secrets/src
[package]: https://www.nuget.org/packages/Azure.Extensions.AspNetCore.Configuration.Secrets/
[docs]: https://docs.microsoft.com/dotnet/api/Azure.Extensions.AspNetCore.Configuration.Secrets
[nuget]: https://www.nuget.org/packages/Azure.Extensions.AspNetCore.Configuration.Secrets
[keyvault_create_cli]: https://docs.microsoft.com/en-us/azure/key-vault/quick-create-cli#create-a-key-vault
[keyvault_create_portal]: https://docs.microsoft.com/en-us/azure/key-vault/quick-create-portal#create-a-vault
[keyvault_create_ps]: https://docs.microsoft.com/en-us/azure/key-vault/quick-create-powershell#create-a-key-vault
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[identity]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity/README.md
[aspnetcore_configuration_doc]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-3.1
[error_codes]: https://docs.microsoft.com/rest/api/storageservices/blob-service-error-codes
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com

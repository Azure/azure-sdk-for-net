# Azure Key Vault configuration provider for Microsoft.Extensions.Configuration

The `Microsoft.Extensions.Configuration.KeyVault` package allows storing configuration values using Azure Key Vault Secrets.

## Getting started

### Install the package

Install the package with [NuGet][nuget]:

```dotnetcli
dotnet add package Microsoft.Extensions.Configuration.KeyVault
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

#### Azure role-based access control

When using [azure role-based access control](https://learn.microsoft.com/azure/key-vault/general/rbac-guide), the identity you are authenticating has to have the "Key Vault Reader" and "Key Vault Secrets User" roles.

```powershell
az role assignment create --role "Key Vault Reader" --assignee {i.e user@microsoft.com} --scope /subscriptions/{subscriptionid}/resourcegroups/{resource-group-name}
az role assignment create --role "Key Vault Secrets User" --assignee {i.e user@microsoft.com} --scope /subscriptions/{subscriptionid}/resourcegroups/{resource-group-name}
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

To load configuration from Azure Key Vault secrets, first configure a `KeyVault` section in your `appsettings.json` that describes the `SecretClient` to use. Additional clients can reference secrets stored in the vault. For example, the `Key` for `MyClient` below is loaded from a Key Vault secret named `MyClient--Credential--Key`:

```json
{
  "KeyVault": {
    "VaultUri": "https://myvault.vault.azure.net/",
    "Credential": {
      "CredentialSource": "AzureCliCredential"
    }
  },
  "MyClient": {
    "Endpoint": "https://myservice.example.com",
    "Credential": {
      "CredentialSource": "ApiKey"
    }
  }
}
```

Then call `AddKeyVaultSecrets` on the configuration builder, passing the name of the section that describes the `SecretClient`. When the configuration is built the secrets are loaded and merged so that subsequent calls like `AddClient` can consume them:

```C# Snippet:ConfigurationAddKeyVaultSecrets
HostApplicationBuilder builder = Host.CreateApplicationBuilder();
builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.AddKeyVaultSecrets("KeyVault");
builder.AddClient<MyClient, MyClientSettings>("MyClient");

IHost host = builder.Build();
MyClient client = host.Services.GetRequiredService<MyClient>();
```

The [Azure Identity library][identity] provides easy Azure Active Directory support for authentication.

## Next steps

Read more about [configuration in ASP.NET Core][aspnetcore_configuration_doc].

## Contributing

This project welcomes contributions and suggestions. Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact [opencode@microsoft.com][coc_contact] with any
additional questions or comments.

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/keyvault/Microsoft.Extensions.Configuration.KeyVault/src
[package]: https://www.nuget.org/packages/Microsoft.Extensions.Configuration.KeyVault/
[nuget]: https://www.nuget.org/packages/Microsoft.Extensions.Configuration.KeyVault
[keyvault_create_cli]: https://learn.microsoft.com/azure/key-vault/quick-create-cli#create-a-key-vault
[keyvault_create_portal]: https://learn.microsoft.com/azure/key-vault/quick-create-portal#create-a-vault
[keyvault_create_ps]: https://learn.microsoft.com/azure/key-vault/quick-create-powershell#create-a-key-vault
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md
[aspnetcore_configuration_doc]: https://learn.microsoft.com/aspnet/core/fundamentals/configuration/?view=aspnetcore-3.1
[keyvault_doc]: https://learn.microsoft.com/azure/key-vault/general/overview
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com

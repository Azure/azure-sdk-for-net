# Azure Storage Blob Key Store for Microsoft.AspNetCore.DataProtection

The `Azure.Extensions.AspNetCore.DataProtection.Blobs` package allows storing ASP.NET Core DataProtection keys in Azure Blob Storage. Keys can be shared across several instances of a web app. Apps can share authentication cookies or CSRF protection across multiple servers.

## Getting started

### Install the package

Install the package with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Extensions.AspNetCore.DataProtection.Blobs
```

### Prerequisites

You need an [Azure subscription][azure_sub],
[Storage Account][storage_account_docs] and [Storage Container][storage_container_docs] to use this package.

To create a new Storage Account, you can use the [Azure Portal][storage_account_create_portal],
[Azure PowerShell][storage_account_create_ps], or the [Azure CLI][storage_account_create_cli].
Here's an example using the Azure CLI:

```Powershell
az storage account create --name <storage-account> --resource-group <resource-group> --location westus --sku Standard_LRS
az storage container create --account-name <storage-account> -n <container>

# Give write access to a user
az role assignment create --role "Storage Blob Data Contributor" --assignee <your_email> --scope "/subscriptions/<subscription>/resourceGroups/<resource-group>/providers/Microsoft.Storage/storageAccounts/<storage-account>/blobServices/default/containers/<container>"

# OR give write access to a service principal (application)
az role assignment create --role "Storage Blob Data Contributor" --assignee-object-id <application_id> --scope "/subscriptions/<subscription>/resourceGroups/<resource-group>/providers/Microsoft.Storage/storageAccounts/<storage-account>/blobServices/default/containers/<container>"

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

To enable persisting keys to Azure Blob Storage call the `PersistKeysToAzureBlobStorage` method. The `Uri` provided has to be a blob URI in the following form `https://{storage_account}.blob.core.windows.net/{container}/{blob}`.

```C# Snippet:IdentityAuth
public void ConfigureServices(IServiceCollection services)
{
    services
        .AddDataProtection()
        .PersistKeysToAzureBlobStorage(new Uri("<full-blob-URI>"), new DefaultAzureCredential());
}
```

The [Azure Identity library][identity] provides easy Azure Active Directory support for authentication.

### Authenticating using a connection string

```C# Snippet:ConnectionString
public void ConfigureServices(IServiceCollection services)
{
    services
        .AddDataProtection()
        .PersistKeysToAzureBlobStorage("<connection string>", "<container name>", "<blob name>");
}
```

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
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/extensions/Azure.Extensions.AspNetCore.DataProtection.Blobs/src
[package]: https://www.nuget.org/packages/Azure.Extensions.AspNetCore.DataProtection.Blobs/
[docs]: https://learn.microsoft.com/dotnet/api/Azure.Extensions.AspNetCore.DataProtection.Blobs
[nuget]: https://www.nuget.org/packages/Azure.Extensions.AspNetCore.DataProtection.Blobs
[storage_account_docs]: https://learn.microsoft.com/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-powershell
[storage_account_create_cli]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-cli
[storage_account_create_portal]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-portal
[storage_container_docs]: https://learn.microsoft.com/azure/storage/blobs/storage-blobs-introduction#containers
[azure_cli]: https://learn.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md
[aspnetcore_dataprotection_doc]: https://learn.microsoft.com/aspnet/core/security/data-protection/introduction
[samples]: samples/
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com

# Azure WebJobs Storage Common client library for .NET

This package provides infrastruture shared by the other Azure WebJobs Storage libraries.

## Getting started

### Install the package

Install the common library with [NuGet][nuget]:

```Powershell
dotnet add package Azure.WebJobs.Extensions.Storage.Common
```

### Prerequisites

You need an [Azure subscription][azure_sub] and a
[Storage Account][storage_account_docs] to use this package.

To create a new Storage Account, you can use the [Azure Portal][storage_account_create_portal],
[Azure PowerShell][storage_account_create_ps], or the [Azure CLI][storage_account_create_cli].
Here's an example using the Azure CLI:

```Powershell
az storage account create --name <your-resource-name> --resource-group <your-resource-group-name> --location westus --sku Standard_LRS
```

### Authenticate the client

In order for the extensions to access Storage, you will need the connection string which can be found in the [Azure Portal](https://portal.azure.com/) or by using the [Azure CLI](https://docs.microsoft.com/cli/azure) snippet below.

```bash
az storage account show-connection-string -g <your-resource-group-name> -n <your-resource-name>
```

The connection string can be supplied through [AzureWebJobsStorage app setting](https://docs.microsoft.com/azure/azure-functions/functions-app-settings).

## Key concepts

## Examples

## Troubleshooting

Please refer to [Monitor Azure Functions](https://docs.microsoft.com/azure/azure-functions/functions-monitoring) for troubleshooting guidance.

## Next steps

Read the [introduction to Azure Function](https://docs.microsoft.com/azure/azure-functions/functions-overview) or [creating an Azure Function guide](https://docs.microsoft.com/azure/azure-functions/functions-create-first-azure-function).

## Contributing

See the [Storage CONTRIBUTING.md][storage_contrib] for details on building,
testing, and contributing to this library.

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact [opencode@microsoft.com][coc_contact] with any
additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fstorage%2FAzure.Storage.Webjobs.Extensions.Blobs%2FREADME.png)

<!-- LINKS -->
[nuget]: https://www.nuget.org/
[storage_account_docs]: https://docs.microsoft.com/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-powershell
[storage_account_create_cli]: https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-cli
[storage_account_create_portal]: https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-portal
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/src/RequestFailedException.cs
[storage_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com

# Azure WebJobs Tables client library for .NET

This extension provides functionality for accessing Azure Tables in Azure Functions.

## Getting started

### Install the package

Install the Tables extension with [NuGet][nuget]:

```dotnetcli
dotnet add package Microsoft.Azure.WebJobs.Extensions.Tables
```

### Prerequisites

You need an [Azure subscription][azure_sub] and a
[Storage Account][storage_account_docs] or [Cosmos Tables Account][cosmos_tables_account_docs] to use this package.

#### Using Storage Tables

To create a new Storage Account, you can use the [Azure Portal][storage_account_create_portal],
[Azure PowerShell][storage_account_create_ps], or the [Azure CLI][storage_account_create_cli].
Here's an example using the Azure CLI:

```Powershell
az storage account create --name <your-resource-name> --resource-group <your-resource-group-name> --location westus --sku Standard_LRS
```

#### Using Cosmos Tables

To create a new Cosmos Tables , you can use the [Azure Portal][storage_account_create_portal],
[Azure PowerShell][storage_account_create_ps], or the [Azure CLI][storage_account_create_cli].

### Authenticate the client

Connection represents a set of information required to connect to a table service. It can contain a connection string, an endpoint, token credential or a shared key.

The `Connection` property of `TableAttribute` defines which connection is used for the Table Service access. For example, `[Tables(Connection="MyTableService")]` is going to use `MyTableService` connection.

The connection information can be set in [`local.settings.json`][local_settings_json] or [application settings in Azure portal][appsettings_portal].

When adding a setting to *local.settings.json* place it under the `Values` property:

```json
{
  "IsEncrypted": false,
  "Values": {
    "MyTableService": "..."
  }
}
```

When adding a setting to application settings in Azure portal use the provided name directly:

`MyTableService = ...`

Tables extension uses the `AzureWebJobsStorage` connection name by default.

#### Connection string

To use connection strings authentication assign connection string value directly to the connection setting.

`<ConnectionName>` = `DefaultEndpointsProtocol=https;AccountName=...;AccountKey=...;EndpointSuffix=core.windows.net`

#### Using endpoint and token credential

**NOTE:** token credential authentication is supported only for storage tables.

`<ConnectionName>__endpoint` = `https://...table.core.windows.net`

If no credential information is provided the [`DefaultAzureCredential`][identity_dac] is used.

When using user-assigned manageed identity the `clientId` and `credential` settings need to be provided:

`<ConnectionName>__credential` = `managedidentity`

`<ConnectionName>__clientId` = `<user-assigned client id>`

#### Using shared key credential

When using [shared key authentication](https://learn.microsoft.com/rest/api/storageservices/authorize-with-shared-key) the `endpoint`, `accountKey` and `accountName` need to be provided.

`<ConnectionName>__endpoint` = `https://...table.core.windows.net`

`<ConnectionName>__credential__accountName` = `<account name>`

`<ConnectionName>__credential__accountKey` = `<account key>`

## Key concepts

The input binding allows you to read table as input to an Azure Function. The output binding allows you to modify and delete table rows in an Azure Function.

Please follow the [input binding tutorial](https://learn.microsoft.com/azure/azure-functions/functions-bindings-storage-table-input?tabs=csharp) and [output binding tutorial](https://learn.microsoft.com/azure/azure-functions/functions-bindings-storage-table-output?tabs=csharp) to learn about using this extension for accessing table service.

## Examples

Tables extensions provides only bindings. Bindings by themselves can't trigger a function. It can only read or write entries to the table.

In the following example we use [HTTP trigger](https://learn.microsoft.com/azure/azure-functions/functions-bindings-http-webhook-trigger?tabs=csharp) to invoke the function.

### Binding to a single entity

```C# Snippet:InputSingle
public class InputSingle
{
    [FunctionName("InputSingle")]
    public static void Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "GET")] HttpRequest request,
        [Table("MyTable", "<PartitionKey>", "<RowKey>")] TableEntity entity, ILogger log)
    {
        log.LogInformation($"PK={entity.PartitionKey}, RK={entity.RowKey}, Text={entity["Text"]}");
    }
}
```

### Binding to a single entity using model type

```C# Snippet:MyEntity
public class MyEntity
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public string Text { get; set; }
}
```
```C# Snippet:InputSingleModel
public class InputSingleModel
{
    [FunctionName("InputSingleModel")]
    public static void Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "GET")] HttpRequest request,
        [Table("MyTable", "<PartitionKey>", "<RowKey>")] MyEntity entity, ILogger log)
    {
        log.LogInformation($"PK={entity.PartitionKey}, RK={entity.RowKey}, Text={entity.Text}");
    }
}
```

### Binding to multiple entities with filter

```C# Snippet:InputMultipleEntitiesFilter
public class InputMultipleEntitiesFilter
{
    [FunctionName("InputMultipleEntitiesFilter")]
    public static void Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "GET")] HttpRequest request,
        [Table("MyTable", "<PartitionKey>", Filter = "Text ne ''")] IEnumerable<TableEntity> entities, ILogger log)
    {
        foreach (var entity in entities)
        {
            log.LogInformation($"PK={entity.PartitionKey}, RK={entity.RowKey}, Text={entity["Text"]}");
        }
    }
}
```

### Creating a single entity

```C# Snippet:OutputSingle
public class OutputSingle
{
    [FunctionName("OutputSingle")]
    public static void Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "GET")] HttpRequest request,
        [Table("MyTable")] out TableEntity entity)
    {
        entity = new TableEntity("<PartitionKey>", "<RowKey>")
        {
            ["Text"] = "Hello"
        };
    }
}
```

### Creating a single entity using model

```C# Snippet:MyEntity
public class MyEntity
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public string Text { get; set; }
}
```
```C# Snippet:OutputSingleModel
public class OutputSingleModel
{
    [FunctionName("OutputSingleModel")]
    public static void Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "GET")] HttpRequest request,
        [Table("MyTable")] out MyEntity entity)
    {
        entity = new MyEntity()
        {
            PartitionKey = "<PartitionKey>",
            RowKey = "<RowKey>",
            Text = "Hello"
        };
    }
}
```

### Creating multiple entities

```C# Snippet:OutputMultiple
public class OutputMultiple
{
    [FunctionName("OutputMultiple")]
    public static void Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "POST")] HttpRequest request,
        [Table("MyTable")] IAsyncCollector<TableEntity> collector)
    {
        for (int i = 0; i < 10; i++)
        {
            collector.AddAsync(new TableEntity("<PartitionKey>", i.ToString())
            {
                ["Text"] = i.ToString()
            });
        }
    }
}
```

### Creating multiple entities using model

```C# Snippet:MyEntity
public class MyEntity
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public string Text { get; set; }
}
```
```C# Snippet:OutputMultipleModel
public class OutputMultipleModel
{
    [FunctionName("OutputMultipleModel")]
    public static void Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "POST")] HttpRequest request,
        [Table("MyTable")] IAsyncCollector<MyEntity> collector)
    {
        for (int i = 0; i < 10; i++)
        {
            collector.AddAsync(new MyEntity()
            {
                PartitionKey = "<PartitionKey>",
                RowKey = i.ToString(),
                Text = i.ToString()
            });
        }
    }
}
```

### Binding to SDK TableClient type

Use a TableClient method parameter to access the table by using the Azure Tables SDK.

```C# Snippet:InputTableClient
public class BindTableClient
{
    [FunctionName("BindTableClient")]
    public static async Task Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "POST")] HttpRequest request,
        [Table("MyTable")] TableClient client)
    {
        await client.AddEntityAsync(new TableEntity("<PartitionKey>", "<RowKey>")
        {
            ["Text"] = request.GetEncodedPathAndQuery()
        });
    }
}
```

## Troubleshooting

Please refer to [Monitor Azure Functions](https://learn.microsoft.com/azure/azure-functions/functions-monitoring) for troubleshooting guidance.

## Next steps

Read the [introduction to Azure Function](https://learn.microsoft.com/azure/azure-functions/functions-overview) or [creating an Azure Function guide](https://learn.microsoft.com/azure/azure-functions/functions-create-first-azure-function).

## Contributing

See the [CONTRIBUTING.md][contrib] for details on building,
testing, and contributing to this library.

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact [opencode@microsoft.com][coc_contact] with any
additional questions or comments.

<!-- LINKS -->
[nuget]: https://www.nuget.org/
[storage_account_docs]: https://learn.microsoft.com/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-powershell
[storage_account_create_cli]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-cli
[storage_account_create_portal]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-portal

[cosmos_tables_account_docs]: https://learn.microsoft.com/azure/cosmos-db/table/introduction
[cosmos_tables_create_ps]: https://learn.microsoft.com/azure/cosmos-db/scripts/powershell/table/create
[cosmos_tables_create_cli]: https://learn.microsoft.com/azure/cosmos-db/scripts/cli/table/create
[cosmos_tables_create_portal]: https://learn.microsoft.com/azure/cosmos-db/table/how-to-create-container

[identity_dac]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential

[appsettings_portal]: https://learn.microsoft.com/azure/azure-functions/functions-how-to-use-azure-function-app-settings?tabs=portal
[local_settings_json]: https://learn.microsoft.com/azure/azure-functions/functions-host-json#override-hostjson-values

[azure_sub]: https://azure.microsoft.com/free/dotnet/
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/src/RequestFailedException.cs
[contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md

[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com

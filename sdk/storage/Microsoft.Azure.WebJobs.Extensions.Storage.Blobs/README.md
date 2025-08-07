# Azure WebJobs Storage Blobs client library for .NET

This extension provides functionality for accessing Azure Storage Blobs in Azure Functions within the process.

## Getting started

### Install the package

Install the Storage Blobs extension with [NuGet][nuget]:

```dotnetcli
dotnet add package Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
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

In order for the extension to access Blobs, you will need the connection string which can be found in the [Azure Portal](https://portal.azure.com/) or by using the [Azure CLI](https://learn.microsoft.com/cli/azure) snippet below.

```bash
az storage account show-connection-string -g <your-resource-group-name> -n <your-resource-name>
```

The connection string can be supplied through [AzureWebJobsStorage app setting](https://learn.microsoft.com/azure/azure-functions/functions-app-settings).

## Key concepts

### Using Blob trigger

The Blob storage trigger starts a function when a new or updated blob is detected. The blob contents are provided as input to the function.

Please follow the [tutorial](https://learn.microsoft.com/azure/azure-functions/functions-bindings-storage-blob-trigger?tabs=csharp) to learn about triggering an Azure Function when a blob is modified.

#### Listening strategies

Blob trigger offers handful of strategies when it comes to listening to blob creation and modification. The strategy can be customized by specifying `Source` property of the `BlobTrigger` (see examples below).

#### Default strategy

By default blob trigger uses [polling](https://learn.microsoft.com/azure/azure-functions/functions-bindings-storage-blob-trigger?tabs=csharp#polling) which works as a hybrid between inspecting [Azure Storage analytics logging](https://learn.microsoft.com/azure/storage/common/storage-analytics-logging?tabs=dotnet) and running periodic container scans.
Blobs are scanned in groups of 10,000 at a time with a continuation token used between intervals.

[Azure Storage analytics logging](https://learn.microsoft.com/azure/storage/common/storage-analytics-logging?tabs=dotnet) is not enabled by default, see [Azure Storage analytics logging](https://learn.microsoft.com/azure/storage/common/storage-analytics-logging?tabs=dotnet) for how to enable it.

This strategy is not recommended for high-scale applications or scenarios that require low latency.

#### Event grid

[Blob storage events](https://learn.microsoft.com/azure/storage/blobs/storage-blob-event-overview) can be used to listen for changes. This strategy requires [additional setup](https://learn.microsoft.com/azure/event-grid/blob-event-quickstart-portal?toc=/azure/storage/blobs/toc.json).

This strategy is recommended for high-scale applications.

### Using Blob binding

The input binding allows you to read blob storage data as input to an Azure Function. The output binding allows you to modify and delete blob storage data in an Azure Function.

Please follow the [input binding tutorial](https://learn.microsoft.com/azure/azure-functions/functions-bindings-storage-blob-input?tabs=csharp) and [output binding tutorial](https://learn.microsoft.com/azure/azure-functions/functions-bindings-storage-blob-output?tabs=csharp) to learn about using this extension for accessing Blobs.

## Examples

### Reacting to blob change

#### Default strategy

```C# Snippet:BlobFunction_ReactToBlobChange
public static class BlobFunction_ReactToBlobChange
{
    [FunctionName("BlobFunction")]
    public static void Run(
        [BlobTrigger("sample-container/sample-blob")] Stream blobStream,
        ILogger logger)
    {
        using var blobStreamReader = new StreamReader(blobStream);
        logger.LogInformation("Blob sample-container/sample-blob has been updated with content: {content}", blobStreamReader.ReadToEnd());
    }
}
```

#### Event Grid strategy

```C# Snippet:BlobFunction_ReactToBlobChange_EventGrid
public static class BlobFunction_ReactToBlobChange_EventGrid
{
    [FunctionName("BlobFunction")]
    public static void Run(
        [BlobTrigger("sample-container/sample-blob", Source = BlobTriggerSource.EventGrid)] Stream blobStream,
        ILogger logger)
    {
        using var blobStreamReader = new StreamReader(blobStream);
        logger.LogInformation("Blob sample-container/sample-blob has been updated with content: {content}", blobStreamReader.ReadToEnd());
    }
}
```

### Reading from stream

```C# Snippet:BlobFunction_ReadStream
public static class BlobFunction_ReadStream
{
    [FunctionName("BlobFunction")]
    public static void Run(
        [BlobTrigger("sample-container/sample-blob-1")] Stream blobStream1,
        [Blob("sample-container/sample-blob-2", FileAccess.Read)] Stream blobStream2,
        ILogger logger)
    {
        using var blobStreamReader1 = new StreamReader(blobStream1);
        logger.LogInformation("Blob sample-container/sample-blob-1 has been updated with content: {content}", blobStreamReader1.ReadToEnd());
        using var blobStreamReader2 = new StreamReader(blobStream2);
        logger.LogInformation("Blob sample-container/sample-blob-2 has content: {content}", blobStreamReader2.ReadToEnd());
    }
}
```

### Writing to stream

```C# Snippet:BlobFunction_WriteStream
public static class BlobFunction_WriteStream
{
    [FunctionName("BlobFunction")]
    public static async Task Run(
        [BlobTrigger("sample-container/sample-blob-1")] Stream blobStream1,
        [Blob("sample-container/sample-blob-2", FileAccess.Write)] Stream blobStream2,
        ILogger logger)
    {
        await blobStream1.CopyToAsync(blobStream2);
        logger.LogInformation("Blob sample-container/sample-blob-1 has been copied to sample-container/sample-blob-2");
    }
}
```

### Binding to string

```C# Snippet:BlobFunction_String
public static class BlobFunction_String
{
    [FunctionName("BlobFunction")]
    public static void Run(
        [BlobTrigger("sample-container/sample-blob-1")] string blobContent1,
        [Blob("sample-container/sample-blob-2")] string blobContent2,
        ILogger logger)
    {
        logger.LogInformation("Blob sample-container/sample-blob-1 has been updated with content: {content}", blobContent1);
        logger.LogInformation("Blob sample-container/sample-blob-2 has content: {content}", blobContent2);
    }
}
```

### Writing string to blob

```C# Snippet:BlobFunction_String_Write
public static class BlobFunction_String_Write
{
    [FunctionName("BlobFunction")]
    public static void Run(
        [BlobTrigger("sample-container/sample-blob-1")] string blobContent1,
        [Blob("sample-container/sample-blob-2")] out string blobContent2,
        ILogger logger)
    {
        logger.LogInformation("Blob sample-container/sample-blob-1 has been updated with content: {content}", blobContent1);
        blobContent2 = blobContent1;
        logger.LogInformation("Blob sample-container/sample-blob-1 has been copied to sample-container/sample-blob-2");
    }
}
```

### Binding to byte array

```C# Snippet:BlobFunction_ByteArray
public static class BlobFunction_ByteArray
{
    [FunctionName("BlobFunction")]
    public static void Run(
        [BlobTrigger("sample-container/sample-blob-1")] byte[] blobContent1,
        [Blob("sample-container/sample-blob-2")] byte[] blobContent2,
        ILogger logger)
    {
        logger.LogInformation("Blob sample-container/sample-blob-1 has been updated with content: {content}", Encoding.UTF8.GetString(blobContent1));
        logger.LogInformation("Blob sample-container/sample-blob-2 has content: {content}", Encoding.UTF8.GetString(blobContent2));
    }
}
```

### Writing byte array to blob

```C# Snippet:BlobFunction_ByteArray_Write
public static class BlobFunction_ByteArray_Write
{
    [FunctionName("BlobFunction")]
    public static void Run(
        [BlobTrigger("sample-container/sample-blob-1")] byte[] blobContent1,
        [Blob("sample-container/sample-blob-2")] out byte[] blobContent2,
        ILogger logger)
    {
        logger.LogInformation("Blob sample-container/sample-blob-1 has been updated with content: {content}", Encoding.UTF8.GetString(blobContent1));
        blobContent2 = blobContent1;
        logger.LogInformation("Blob sample-container/sample-blob-1 has been copied to sample-container/sample-blob-2");
    }
}
```

### Binding to TextReader and TextWriter

```C# Snippet:BlobFunction_TextReader_TextWriter
public static class BlobFunction_TextReader_TextWriter
{
    [FunctionName("BlobFunction")]
    public static async Task Run(
        [BlobTrigger("sample-container/sample-blob-1")] TextReader blobContentReader1,
        [Blob("sample-container/sample-blob-2")] TextWriter blobContentWriter2,
        ILogger logger)
    {
        while (blobContentReader1.Peek() >= 0)
        {
            await blobContentWriter2.WriteLineAsync(await blobContentReader1.ReadLineAsync());
        }
        logger.LogInformation("Blob sample-container/sample-blob-1 has been copied to sample-container/sample-blob-2");
    }
}
```

### Binding to Azure Storage Blob SDK types

```C# Snippet:BlobFunction_BlobClient
public static class BlobFunction_BlobClient
{
    [FunctionName("BlobFunction")]
    public static async Task Run(
        [BlobTrigger("sample-container/sample-blob-1")] BlobClient blobClient1,
        [Blob("sample-container/sample-blob-2")] BlobClient blobClient2,
        ILogger logger)
    {
        BlobProperties blobProperties1 = await blobClient1.GetPropertiesAsync();
        logger.LogInformation("Blob sample-container/sample-blob-1 has been updated on: {datetime}", blobProperties1.LastModified);
        BlobProperties blobProperties2 = await blobClient2.GetPropertiesAsync();
        logger.LogInformation("Blob sample-container/sample-blob-2 has been updated on: {datetime}", blobProperties2.LastModified);
    }
}
```

### Accessing Blob container

```C# Snippet:BlobFunction_AccessContainer
public static class BlobFunction_AccessContainer
{
    [FunctionName("BlobFunction")]
    public static async Task Run(
        [BlobTrigger("sample-container/sample-blob")] Stream blobStream,
        [Blob("sample-container")] BlobContainerClient blobContainerClient,
        ILogger logger)
    {
        logger.LogInformation("Blobs within container:");
        await foreach (BlobItem blobItem in blobContainerClient.GetBlobsAsync())
        {
            logger.LogInformation(blobItem.Name);
        }
    }
}
```

### Enumerating blobs in container

```C# Snippet:BlobFunction_EnumerateBlobs_Stream
public static class BlobFunction_EnumerateBlobs_Stream
{
    [FunctionName("BlobFunction")]
    public static async Task Run(
        [BlobTrigger("sample-container/sample-blob")] Stream blobStream,
        [Blob("sample-container")] IEnumerable<Stream> blobs,
        ILogger logger)
    {
        logger.LogInformation("Blobs contents within container:");
        foreach (Stream content in blobs)
        {
            using var blobStreamReader = new StreamReader(content);
            logger.LogInformation(await blobStreamReader.ReadToEndAsync());
        }
    }
}
```

```C# Snippet:BlobFunction_EnumerateBlobs_BlobClient
public static class BlobFunction_EnumerateBlobs_BlobClient
{
    [FunctionName("BlobFunction")]
    public static void Run(
        [BlobTrigger("sample-container/sample-blob")] Stream blobStream,
        [Blob("sample-container")] IEnumerable<BlobClient> blobs,
        ILogger logger)
    {
        logger.LogInformation("Blobs within container:");
        foreach (BlobClient blob in blobs)
        {
            logger.LogInformation(blob.Name);
        }
    }
}
```

### Configuring the extension

Please refer to [sample functions app](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/samples/functionapp).

## Troubleshooting

Please refer to [Monitor Azure Functions](https://learn.microsoft.com/azure/azure-functions/functions-monitoring) for troubleshooting guidance.

## Next steps

Read the [introduction to Azure Function](https://learn.microsoft.com/azure/azure-functions/functions-overview) or [creating an Azure Function guide](https://learn.microsoft.com/azure/azure-functions/functions-create-first-azure-function).

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

<!-- LINKS -->
[nuget]: https://www.nuget.org/
[storage_account_docs]: https://learn.microsoft.com/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-powershell
[storage_account_create_cli]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-cli
[storage_account_create_portal]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-portal
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/src/RequestFailedException.cs
[storage_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com

# Azure WebJobs Storage Blobs client library for .NET

TODO

## Getting started

### Install the package


### Prerequisites


### Authenticate the client


## Key concepts

TODO

## Examples

```C# Snippet:BlobFunction_String
public static class BlobFunction_String
{
    [FunctionName("BlobFunction")]
    public static void Run(
        [BlobTrigger("sample-container/sample-blob-1")] string blobTriggerContent,
        [Blob("sample-container/sample-blob-2")] string blobContent,
        ILogger logger)
    {
        logger.LogInformation("Blob sample-container/sample-blob-1 has been updated with content: {content}", blobTriggerContent);
        logger.LogInformation("Blob sample-container/sample-blob-2 has content: {content}", blobContent);
    }
}
```

```C# Snippet:BlobFunction_ReadStream
public static class BlobFunction_ReadStream
{
    [FunctionName("BlobFunction")]
    public static void Run(
        [BlobTrigger("sample-container/sample-blob-1")] Stream blobTriggerStream,
        [Blob("sample-container/sample-blob-2", FileAccess.Read)] Stream blobStream,
        ILogger logger)
    {
        using var blobTriggerStreamReader = new StreamReader(blobTriggerStream);
        logger.LogInformation("Blob sample-container/sample-blob-1 has been updated with content: {content}", blobTriggerStreamReader.ReadToEnd());
        using var blobStreamReader = new StreamReader(blobStream);
        logger.LogInformation("Blob sample-container/sample-blob-2 has content: {content}", blobStreamReader.ReadToEnd());
    }
}
```

```C# Snippet:BlobFunction_WriteStream
public static class BlobFunction_WriteStream
{
    [FunctionName("BlobFunction")]
    public static async Task Run(
        [BlobTrigger("sample-container/sample-blob-1")] Stream blobTriggerStream,
        [Blob("sample-container/sample-blob-2", FileAccess.Write)] Stream blobStream,
        ILogger logger)
    {
        await blobTriggerStream.CopyToAsync(blobStream);
        logger.LogInformation("Blob sample-container/sample-blob-1 has been copied to sample-container/sample-blob-2");
    }
}
```

```C# Snippet:BlobFunction_BlobBaseClient
public static class BlobFunction_BlobBaseClient
{
    [FunctionName("BlobFunction")]
    public static async Task Run(
        [BlobTrigger("sample-container/sample-blob-1")] BlobBaseClient blobTriggerClient,
        [Blob("sample-container/sample-blob-2")] BlobBaseClient blobClient,
        ILogger logger)
    {
        BlobProperties blobTriggerProperties = await blobTriggerClient.GetPropertiesAsync();
        logger.LogInformation("Blob sample-container/sample-blob-1 has been updated on: {datetime}", blobTriggerProperties.LastModified);
        BlobProperties blobProperties = await blobClient.GetPropertiesAsync();
        logger.LogInformation("Blob sample-container/sample-blob-2 has been updated on: {datetime}", blobProperties.LastModified);
    }
}
```

## Troubleshooting

TODO

## Next steps

TODO

## Contributing

TODO

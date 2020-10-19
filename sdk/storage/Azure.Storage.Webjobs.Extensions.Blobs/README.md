# Azure WebJobs Storage Blobs client library for .NET

TODO

## Getting started

### Install the package


### Prerequisites


### Authenticate the client


## Key concepts

TODO

## Examples

### Functions that use Blob Trigger

```C# Snippet:BlobTriggerFunction_String
public static class BlobTriggerFunction_String
{
    [FunctionName("BlobTriggerFunction")]
    public static void Run([BlobTrigger("sample-container/sample-blob.txt")] string blobContent, ILogger logger)
    {
        logger.LogInformation("Blob has been updated with content: {content}", blobContent);
    }
}
```

```C# Snippet:BlobTriggerFunction_Stream
public static class BlobTriggerFunction_Stream
{
    [FunctionName("BlobTriggerFunction")]
    public static void Run([BlobTrigger("sample-container/sample-blob.txt")] Stream streamContent, ILogger logger)
    {
        using var streamReader = new StreamReader(streamContent);
        logger.LogInformation("Blob has been updated with content: {content}", streamReader.ReadToEnd());
    }
}
```

## Troubleshooting

TODO

## Next steps

TODO

## Contributing

TODO

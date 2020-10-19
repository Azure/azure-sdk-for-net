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

```C# Snippet:BlobTriggerBindingFunction_String
public static class BlobTriggerBindingFunction
{
    [FunctionName("BlobTriggerBindingFunction")]
    public static void Run([BlobTrigger("sample-container/sample-blob.txt")] string blobContent, ILogger logger)
    {
        logger.LogInformation("Blob has been updated with content: {content}", blobContent);
    }
}
```

## Troubleshooting

TODO

## Next steps

TODO

## Contributing

TODO

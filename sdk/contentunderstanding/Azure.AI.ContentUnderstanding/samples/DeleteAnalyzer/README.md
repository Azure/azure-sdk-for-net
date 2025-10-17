# Delete Analyzer Sample

This sample demonstrates how to delete a custom analyzer using the Azure AI Content Understanding SDK for .NET.

## What This Sample Does

This sample shows how to:

1. **Authenticate** with Azure AI Content Understanding using either an API key or DefaultAzureCredential
2. **Create a custom analyzer** (for demonstration purposes)
3. **Delete the analyzer** using the Delete API
4. **Verify the deletion** by confirming the analyzer is no longer available

## Prerequisites

- .NET 8.0 SDK or later
- Azure AI Content Understanding resource

## Configuration

### Option 1: Using appsettings.json

Create or update `appsettings.json` in the parent `samples` directory:

```json
{
  "AzureContentUnderstanding": {
    "Endpoint": "https://your-resource.services.ai.azure.com/",
    "Key": "your-api-key-here"
  }
}
```

### Option 2: Using Environment Variables

Set the following environment variables:

```bash
export AZURE_CONTENT_UNDERSTANDING_ENDPOINT="https://your-resource.services.ai.azure.com/"
export AZURE_CONTENT_UNDERSTANDING_KEY="your-api-key-here"  # Optional - will use DefaultAzureCredential if not set
```

**Note:** Environment variables take precedence over appsettings.json values.

## Running the Sample

1. Navigate to the sample directory:
   ```bash
   cd samples/DeleteAnalyzer
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Run the sample:
   ```bash
   dotnet run
   ```

## Expected Output

```
🔧 Creating analyzer 'sdk-sample-analyzer-to-delete-1729123456' for deletion demo...
✅ Analyzer 'sdk-sample-analyzer-to-delete-1729123456' created successfully!
🗑️  Deleting analyzer 'sdk-sample-analyzer-to-delete-1729123456'...
✅ Analyzer 'sdk-sample-analyzer-to-delete-1729123456' deleted successfully!

💡 Next steps:
   - To create an analyzer: see CreateOrReplaceAnalyzer sample
   - To retrieve an analyzer: see GetAnalyzer sample
   - To list all analyzers: see ListAnalyzers sample
```

## Key Concepts

### Delete API

The delete operation is a simple, immediate operation that doesn't return a result:

```csharp
await client.GetContentAnalyzersClient().DeleteAsync(analyzerId);
```

### Long-Running Operations (LRO)

Creating an analyzer is a long-running operation. The SDK handles this using the `Operation<T>` pattern:

```csharp
var operation = await client.GetContentAnalyzersClient()
    .CreateOrReplaceAsync(
        waitUntil: WaitUntil.Completed,
        analyzerId: analyzerId,
        resource: customAnalyzer);
```

### Async Pattern

This sample uses C#'s async/await pattern for non-blocking operations:

```csharp
await client.GetContentAnalyzersClient().DeleteAsync(analyzerId);
```

## Related Samples

- **CreateOrReplaceAnalyzer** - Create or replace a custom analyzer
- **GetAnalyzer** - Retrieve details of an existing analyzer
- **ListAnalyzers** - List all available analyzers
- **UpdateAnalyzer** - Update analyzer properties

## Troubleshooting

### Authentication Errors

If you see authentication errors:
- Verify your endpoint URL is correct
- Check that your API key is valid (if using key-based authentication)
- Ensure you're logged in with `az login` (if using DefaultAzureCredential)

### Analyzer Not Found

If the delete operation fails with "not found":
- Verify the analyzer ID is correct
- Check that the analyzer hasn't already been deleted
- Ensure you have permissions to delete the analyzer

### Permission Denied

If you see permission errors:
- Verify your credentials have the necessary permissions
- Check that you're using the correct Azure subscription
- Ensure the analyzer is in your resource

## Additional Resources

- [Azure AI Content Understanding Documentation](https://learn.microsoft.com/azure/ai-services/content-understanding/)
- [.NET SDK Documentation](https://learn.microsoft.com/dotnet/api/overview/azure/ai.contentunderstanding-readme)






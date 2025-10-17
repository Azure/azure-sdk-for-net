# Get Analyzer Sample

This sample demonstrates how to retrieve an analyzer using the Azure AI Content Understanding SDK for .NET.

## What This Sample Does

This sample shows how to:

1. **Authenticate** with Azure AI Content Understanding using either an API key or DefaultAzureCredential
2. **Create a custom analyzer** (for demonstration purposes)
3. **Retrieve the analyzer** using the Get API
4. **Display analyzer details** including description, status, creation time, and field schema
5. **Clean up resources** by deleting the created analyzer

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
   cd samples/GetAnalyzer
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
🔧 Creating analyzer 'sdk-sample-analyzer-to-retrieve-1729123456' for retrieval demo...
✅ Analyzer 'sdk-sample-analyzer-to-retrieve-1729123456' created successfully!
📋 Retrieving analyzer 'sdk-sample-analyzer-to-retrieve-1729123456'...
✅ Analyzer 'sdk-sample-analyzer-to-retrieve-1729123456' retrieved successfully!
   Description: Custom analyzer for retrieval demo
   Status: Succeeded
   Created at: 2025-10-16 15:30:45 UTC
   Base Analyzer: prebuilt-documentAnalyzer

📋 Field Schema: retrieval_schema
   Schema for retrieval demo
   Fields:
      - demo_field: String (Extract)
        Demo field for retrieval

🗑️  Deleting analyzer 'sdk-sample-analyzer-to-retrieve-1729123456' (demo cleanup)...
✅ Analyzer 'sdk-sample-analyzer-to-retrieve-1729123456' deleted successfully!

💡 Next steps:
   - To create an analyzer: see CreateOrReplaceAnalyzer sample
   - To list all analyzers: see ListAnalyzers sample
   - To update an analyzer: see UpdateAnalyzer sample
```

## Key Concepts

### Get API

The Get operation retrieves detailed information about a specific analyzer:

```csharp
Response<ContentAnalyzer> response = await client.GetContentAnalyzersClient()
    .GetAsync(analyzerId);

ContentAnalyzer retrievedAnalyzer = response.Value;
```

### Analyzer Properties

The returned `ContentAnalyzer` object contains:

```csharp
retrievedAnalyzer.AnalyzerId      // Unique identifier
retrievedAnalyzer.Description      // Human-readable description
retrievedAnalyzer.Status          // Current status (e.g., "Succeeded")
retrievedAnalyzer.CreatedAt       // Creation timestamp
retrievedAnalyzer.BaseAnalyzerId  // Base analyzer used
retrievedAnalyzer.FieldSchema     // Field extraction schema
retrievedAnalyzer.Config          // Analyzer configuration
retrievedAnalyzer.Tags           // Custom tags
```

### Async Pattern

This sample uses C#'s async/await pattern for non-blocking operations:

```csharp
var response = await client.GetContentAnalyzersClient().GetAsync(analyzerId);
```

## Related Samples

- **CreateOrReplaceAnalyzer** - Create or replace a custom analyzer
- **DeleteAnalyzer** - Delete a custom analyzer
- **ListAnalyzers** - List all available analyzers
- **UpdateAnalyzer** - Update analyzer properties

## Troubleshooting

### Authentication Errors

If you see authentication errors:
- Verify your endpoint URL is correct
- Check that your API key is valid (if using key-based authentication)
- Ensure you're logged in with `az login` (if using DefaultAzureCredential)

### Analyzer Not Found

If the get operation fails with "not found":
- Verify the analyzer ID is correct
- Check that the analyzer exists (use the List API to see all analyzers)
- Ensure you have permissions to access the analyzer

### Permission Denied

If you see permission errors:
- Verify your credentials have the necessary permissions
- Check that you're using the correct Azure subscription
- Ensure the analyzer is in your resource

## Additional Resources

- [Azure AI Content Understanding Documentation](https://learn.microsoft.com/azure/ai-services/content-understanding/)
- [.NET SDK Documentation](https://learn.microsoft.com/dotnet/api/overview/azure/ai.contentunderstanding-readme)







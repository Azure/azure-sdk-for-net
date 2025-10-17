# List Analyzers Sample

This sample demonstrates how to list all available analyzers using the Azure AI Content Understanding SDK for .NET.

## What This Sample Does

This sample shows how to:

1. **Authenticate** with Azure AI Content Understanding using either an API key or DefaultAzureCredential
2. **List all available analyzers** using the List API
3. **Display detailed information** about each analyzer
4. **Distinguish between prebuilt and custom analyzers**
5. **Show summary statistics** about available analyzers

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
   cd samples/ListAnalyzers
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
📋 Listing all available analyzers...
✅ Found 5 analyzers

🔍 Analyzer 1:
   ID: prebuilt-documentAnalyzer
   Description: Prebuilt analyzer for document analysis
   Status: Succeeded
   Created at: 2024-01-01 00:00:00 UTC
   Type: Prebuilt analyzer

🔍 Analyzer 2:
   ID: prebuilt-videoAnalyzer
   Description: Prebuilt analyzer for video analysis
   Status: Succeeded
   Created at: 2024-01-01 00:00:00 UTC
   Type: Prebuilt analyzer

🔍 Analyzer 3:
   ID: my-custom-invoice-analyzer
   Description: Custom analyzer for invoice processing
   Status: Succeeded
   Created at: 2025-10-15 14:23:12 UTC
   Type: Custom analyzer
   Tags:
      - category: invoice
      - version: v1

   ✅ prebuilt-documentAnalyzer is available
   ✅ prebuilt-videoAnalyzer is available

💡 Next steps:
   - To create an analyzer: see CreateOrReplaceAnalyzer sample
   - To get a specific analyzer: see GetAnalyzer sample
   - To update an analyzer: see UpdateAnalyzer sample
```

## Key Concepts

### List API

The List operation returns an async enumerable of all available analyzers:

```csharp
var analyzers = new List<ContentAnalyzer>();
await foreach (var analyzer in client.GetContentAnalyzersClient().GetAllAsync())
{
    analyzers.Add(analyzer);
}
```

### Async Enumerable Pattern

The List API uses `IAsyncEnumerable<T>` for efficient pagination:

```csharp
await foreach (var analyzer in client.GetContentAnalyzersClient().GetAllAsync())
{
    Console.WriteLine($"Analyzer: {analyzer.AnalyzerId}");
}
```

### Analyzer Types

Analyzers can be categorized as:

1. **Prebuilt Analyzers** - Start with "prebuilt-" prefix
   - `prebuilt-documentAnalyzer` - General document analysis
   - `prebuilt-videoAnalyzer` - Video content analysis

2. **Custom Analyzers** - User-created analyzers with custom field schemas

### Analyzer Properties

Each analyzer in the list includes:

```csharp
analyzer.AnalyzerId      // Unique identifier
analyzer.Description      // Human-readable description
analyzer.Status          // Current status (e.g., "Succeeded")
analyzer.CreatedAt       // Creation timestamp
analyzer.Tags           // Custom tags (if any)
```

### Filtering Analyzers

You can filter analyzers using LINQ:

```csharp
// Get only prebuilt analyzers
var prebuiltAnalyzers = analyzers
    .Where(a => a.AnalyzerId?.StartsWith("prebuilt-") == true)
    .ToList();

// Get only custom analyzers
var customAnalyzers = analyzers
    .Where(a => !a.AnalyzerId?.StartsWith("prebuilt-") == true)
    .ToList();
```

## Related Samples

- **CreateOrReplaceAnalyzer** - Create or replace a custom analyzer
- **GetAnalyzer** - Retrieve details of a specific analyzer
- **DeleteAnalyzer** - Delete a custom analyzer
- **UpdateAnalyzer** - Update analyzer properties

## Troubleshooting

### Authentication Errors

If you see authentication errors:
- Verify your endpoint URL is correct
- Check that your API key is valid (if using key-based authentication)
- Ensure you're logged in with `az login` (if using DefaultAzureCredential)

### Empty List

If no analyzers are returned:
- Verify you have the correct endpoint
- Check that your resource is properly provisioned
- Ensure you have permissions to list analyzers

### Pagination Issues

If you have many analyzers, the API automatically handles pagination:
```csharp
int count = 0;
await foreach (var analyzer in client.GetContentAnalyzersClient().GetAllAsync())
{
    count++;
    Console.WriteLine($"Analyzer {count}: {analyzer.AnalyzerId}");
}
```

## Additional Resources

- [Azure AI Content Understanding Documentation](https://learn.microsoft.com/azure/ai-services/content-understanding/)
- [.NET SDK Documentation](https://learn.microsoft.com/dotnet/api/overview/azure/ai.contentunderstanding-readme)


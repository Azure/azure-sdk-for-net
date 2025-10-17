# Update Analyzer Sample

This sample demonstrates how to update an analyzer's properties using the Azure AI Content Understanding SDK for .NET.

## What This Sample Does

This sample shows how to:

1. **Authenticate** with Azure AI Content Understanding using either an API key or DefaultAzureCredential
2. **Create an initial analyzer** with specific description and tags
3. **Retrieve the analyzer** to verify initial state
4. **Update the analyzer** with new description and tags
5. **Verify the changes** by retrieving the analyzer again
6. **Clean up resources** by deleting the created analyzer

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
   cd samples/UpdateAnalyzer
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
🔧 Creating initial analyzer 'sdk-sample-analyzer-for-update-1729123456'...
⏳ Waiting for analyzer creation to complete...
✅ Analyzer 'sdk-sample-analyzer-for-update-1729123456' created successfully!
📋 Getting analyzer 'sdk-sample-analyzer-for-update-1729123456' before update...
✅ Initial analyzer state verified:
   Description: Initial description
   Tags: {'tag1': 'tag1_initial_value', 'tag2': 'tag2_initial_value'}
🔄 Creating updated analyzer configuration...
📝 Updating analyzer 'sdk-sample-analyzer-for-update-1729123456' with new description and tags...
✅ Analyzer updated successfully!
📋 Getting analyzer 'sdk-sample-analyzer-for-update-1729123456' after update...
✅ Updated analyzer state verified:
   Description: Updated description
   Tags: {'tag1': 'tag1_updated_value', 'tag3': 'tag3_value'}
🗑️  Deleting analyzer 'sdk-sample-analyzer-for-update-1729123456' (demo cleanup)...
✅ Analyzer 'sdk-sample-analyzer-for-update-1729123456' deleted successfully!

💡 Next steps:
   - To create an analyzer: see CreateOrReplaceAnalyzer sample
   - To retrieve an analyzer: see GetAnalyzer sample
   - To list all analyzers: see ListAnalyzers sample
```

## Key Concepts

### Update API

The Update operation allows you to modify specific properties of an analyzer:

```csharp
var updatedAnalyzer = new ContentAnalyzer
{
    Description = "Updated description"
};

// Modify tags - update tag1, remove tag2 (set to empty), add tag3
updatedAnalyzer.Tags["tag1"] = "new_value";
updatedAnalyzer.Tags["tag2"] = "";  // Remove tag2 by setting to empty string
updatedAnalyzer.Tags["tag3"] = "tag3_value";  // Add new tag

await client.GetContentAnalyzersClient().UpdateAsync(
    analyzerId: analyzerId,
    content: updatedAnalyzer);
```

### Updatable Properties

Only certain properties can be updated:

1. **Description** - Human-readable description of the analyzer
2. **Tags** - Dictionary of custom tags

**Note:** The following properties cannot be updated and require creating a new analyzer:
- Base analyzer ID
- Field schema
- Configuration settings
- Processing mode
- Processing location

### Tag Management

Tags can be updated in three ways:

1. **Update a tag value**:
   ```csharp
   updatedAnalyzer.Tags["tag1"] = "new_value";
   ```

2. **Remove a tag** (set to empty string):
   ```csharp
   updatedAnalyzer.Tags["tag2"] = "";
   ```

3. **Add a new tag**:
   ```csharp
   updatedAnalyzer.Tags["tag3"] = "tag3_value";
   ```

### Verification Pattern

It's good practice to verify changes after updating:

```csharp
// Before update
var beforeResponse = await client.GetContentAnalyzersClient().GetAsync(analyzerId);
var analyzerBefore = beforeResponse.Value;
Console.WriteLine($"Before: {analyzerBefore.Description}");

// Update
await client.GetContentAnalyzersClient().UpdateAsync(analyzerId, content: updatedAnalyzer);

// After update
var afterResponse = await client.GetContentAnalyzersClient().GetAsync(analyzerId);
var analyzerAfter = afterResponse.Value;
Console.WriteLine($"After: {analyzerAfter.Description}");
```

## Related Samples

- **CreateOrReplaceAnalyzer** - Create or replace a custom analyzer
- **GetAnalyzer** - Retrieve details of an existing analyzer
- **DeleteAnalyzer** - Delete a custom analyzer
- **ListAnalyzers** - List all available analyzers

## Troubleshooting

### Authentication Errors

If you see authentication errors:
- Verify your endpoint URL is correct
- Check that your API key is valid (if using key-based authentication)
- Ensure you're logged in with `az login` (if using DefaultAzureCredential)

### Update Fails

If the update operation fails:
- Verify the analyzer ID is correct
- Check that you're only updating allowed properties (description and tags)
- Ensure you have permissions to update the analyzer
- Verify the analyzer isn't in a transitional state

### Property Not Updated

If a property doesn't change after update:
- Verify you're using the correct property name
- Check that the property is updatable (only description and tags can be updated)
- For immutable properties, you need to create a new analyzer with `CreateOrReplaceAsync`

### Permission Denied

If you see permission errors:
- Verify your credentials have the necessary permissions
- Check that you're using the correct Azure subscription
- Ensure the analyzer is in your resource

## Additional Resources

- [Azure AI Content Understanding Documentation](https://learn.microsoft.com/azure/ai-services/content-understanding/)
- [.NET SDK Documentation](https://learn.microsoft.com/dotnet/api/overview/azure/ai.contentunderstanding-readme)


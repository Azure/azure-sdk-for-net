# Create or Replace Custom Analyzer Sample

This sample demonstrates how to create a custom analyzer using the Azure AI Content Understanding SDK for .NET.

## What This Sample Does

This sample shows how to:

1. **Authenticate** with Azure AI Content Understanding using either an API key or DefaultAzureCredential
2. **Create a custom analyzer** with a field schema using the object model approach
3. **Configure analyzer settings** including OCR, layout analysis, and formula detection
4. **Define a field schema** to extract specific fields (company name, total amount)
5. **Wait for the operation** to complete using the long-running operation (LRO) pattern
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
   cd samples/CreateOrReplaceAnalyzer
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
🔧 Creating custom analyzer 'sdk-sample-custom-analyzer-1234567890'...
✅ Analyzer 'sdk-sample-custom-analyzer-1234567890' created successfully!
   Status: Succeeded
   Created At: 2025-10-16 15:30:45 UTC
   Base Analyzer: prebuilt-documentAnalyzer
   Description: Custom analyzer for extracting company information

📋 Field Schema: company_schema
   Schema for extracting company information
   Fields:
      - company_name: String (Extract)
        Name of the company
      - total_amount: Number (Extract)
        Total amount on the document

🗑️  Deleting analyzer 'sdk-sample-custom-analyzer-1234567890' (demo cleanup)...
✅ Analyzer 'sdk-sample-custom-analyzer-1234567890' deleted successfully!

💡 Next steps:
   - To retrieve an analyzer: see GetAnalyzer sample
   - To use the analyzer for analysis: see AnalyzeBinary sample
   - To delete an analyzer: see DeleteAnalyzer sample
```

## Key Concepts

### Long-Running Operations (LRO)

Creating an analyzer is a long-running operation. The SDK handles this using the `Operation<T>` pattern:

```csharp
var operation = await client.GetContentAnalyzersClient()
    .CreateOrReplaceAsync(
        waitUntil: WaitUntil.Completed,  // Wait for completion
        analyzerId: analyzerId,
        resource: customAnalyzer);

ContentAnalyzer result = operation.Value;
```

### Field Schema Definition

The field schema defines what data to extract from documents:

```csharp
FieldSchema = new ContentFieldSchema(
    fields: new Dictionary<string, ContentFieldDefinition>
    {
        ["company_name"] = new ContentFieldDefinition
        {
            Type = ContentFieldType.String,
            Method = GenerationMethod.Extract,
            Description = "Name of the company"
        }
    })
```

**Field Types:**
- `String` - Plain text
- `Number` - Floating point number
- `Integer` - 64-bit signed integer
- `Date` - ISO 8601 date (YYYY-MM-DD)
- `Time` - ISO 8601 time (hh:mm:ss)
- `Boolean` - True/false value
- `Array` - List of subfields
- `Object` - Named list of subfields

**Generation Methods:**
- `Extract` - Values extracted as they appear in content
- `Generate` - Values generated freely based on content
- `Classify` - Values classified against predefined categories

### Analyzer Configuration

The `ContentAnalyzerConfig` allows fine-tuning of analyzer behavior:

```csharp
Config = new ContentAnalyzerConfig
{
    EnableFormula = true,     // Detect mathematical formulas
    EnableLayout = true,      // Analyze document layout
    EnableOcr = true,         // Optical character recognition
    EstimateFieldSourceAndConfidence = true,  // Return confidence scores
    ReturnDetails = true      // Include detailed analysis results
}
```

## Related Samples

- **AnalyzeUrl** - Use a custom analyzer to analyze content from a URL
- **AnalyzeBinary** - Use a custom analyzer to analyze local files
- **GetAnalyzer** - Retrieve details of an existing analyzer
- **DeleteAnalyzer** - Delete a custom analyzer

## Troubleshooting

### Authentication Errors

If you see authentication errors:
- Verify your endpoint URL is correct
- Check that your API key is valid (if using key-based authentication)
- Ensure you're logged in with `az login` (if using DefaultAzureCredential)

### Analyzer Creation Fails

If analyzer creation fails:
- Check that the base analyzer ID is valid (e.g., "prebuilt-documentAnalyzer")
- Verify your field schema is correctly defined
- Review any warnings returned in the result

## Additional Resources

- [Azure AI Content Understanding Documentation](https://learn.microsoft.com/azure/ai-services/content-understanding/)
- [.NET SDK Documentation](https://learn.microsoft.com/dotnet/api/overview/azure/ai.contentunderstanding-readme)



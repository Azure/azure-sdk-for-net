# Analyze Binary File Sample

This sample demonstrates how to analyze a local PDF file using Azure AI Content Understanding's binary content analysis API.

## What This Sample Does

1. **Reads a local PDF file** from the `sample_files/` directory
2. **Sends binary content** to the `prebuilt-documentAnalyzer` analyzer
3. **Extracts and displays**:
   - Markdown representation of the document
   - Document information (page numbers, dimensions)
   - Table information (row/column counts)

## Prerequisites

- .NET 8.0 or later
- Azure AI Content Understanding resource
- Configuration set up (see main samples README)

## Running the Sample

### From the AnalyzeBinary directory:

```bash
dotnet run
```

### From the repository root:

```bash
dotnet run --project sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/AnalyzeBinary
```

## Configuration

This sample uses the shared configuration system. You can configure it in two ways:

### Option 1: Shared appsettings.json (Recommended)

Edit `samples/appsettings.json`:
```json
{
  "AzureContentUnderstanding": {
    "Endpoint": "https://your-resource-name.services.ai.azure.com/",
    "Key": "your-key-here"
  }
}
```

### Option 2: Environment Variables

```bash
export AZURE_CONTENT_UNDERSTANDING_ENDPOINT="https://your-resource-name.services.ai.azure.com/"
export AZURE_CONTENT_UNDERSTANDING_KEY="your-key-here"  # Optional if using DefaultAzureCredential
```

## Sample Output

```
🔍 Analyzing ../sample_files/sample_invoice.pdf with prebuilt-documentAnalyzer...

📄 Markdown Content:
==================================================
CONTOSO LTD.

# INVOICE
...
==================================================

📚 Document Information:
Start page: 1
End page: 1
Total pages: 1

📄 Pages (1):
  Page 1: 8.5 x 11 inch

📊 Tables (3):
  Table 1: 2 rows x 6 columns
  Table 2: 4 rows x 8 columns
  Table 3: 5 rows x 2 columns

✅ Analysis complete!
```

## Key Differences from URL Analysis

- Uses **binary content** (`BinaryData`) instead of URL
- Reads file from disk using `File.ReadAllBytesAsync()`
- Specifies `contentType` parameter (`"application/pdf"`)
- Good for analyzing local files or files from non-public sources

## Related Samples

- **AnalyzeUrl**: Analyze documents from public URLs
- **AnalyzeInvoice**: Extract structured invoice fields

## Learn More

- [Azure AI Content Understanding Documentation](https://learn.microsoft.com/azure/ai-services/content-understanding/)
- [.NET SDK Reference](https://learn.microsoft.com/dotnet/api/azure.ai.contentunderstanding)



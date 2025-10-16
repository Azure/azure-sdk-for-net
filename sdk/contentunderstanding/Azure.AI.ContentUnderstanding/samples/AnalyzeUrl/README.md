# Analyze Document from URL Sample

This sample demonstrates how to analyze a document from a remote URL using Azure AI Content Understanding's prebuilt-documentAnalyzer.

## What This Sample Does

1. Authenticates with Azure AI Content Understanding service
2. Analyzes a document from a remote URL using the `prebuilt-documentAnalyzer`
3. Extracts and displays:
   - Markdown content
   - Document information (page numbers, dimensions)
   - Table information

## Prerequisites

- .NET 8.0 SDK or later
- Azure Content Understanding resource ([Create one](https://learn.microsoft.com/azure/ai-services/content-understanding/quickstart/use-rest-api?tabs=document#prerequisites))
- Azure CLI (optional, for DefaultAzureCredential) - [Install](https://docs.microsoft.com/cli/azure/install-azure-cli)

## Configuration

This sample uses the standard .NET configuration system (`Microsoft.Extensions.Configuration`). You can configure it using environment variables or configuration files:

### Option 1: Environment Variables (Recommended)

```bash
export AZURE_CONTENT_UNDERSTANDING_ENDPOINT="https://your-resource-name.services.ai.azure.com/"
export AZURE_CONTENT_UNDERSTANDING_KEY="your-key-here"  # Optional - leave empty to use DefaultAzureCredential
```

### Option 2: Configuration Files

You can create either a shared or sample-specific configuration file:

**Shared (for all samples):**
```bash
cd ../  # Navigate to samples/ directory
cp appsettings.json.sample appsettings.json
# Edit appsettings.json with your values
```

**Sample-specific (only for this sample):**
```bash
cp appsettings.json.sample appsettings.json
# Edit appsettings.json with your values
```

**Configuration Priority** (later overrides earlier):
1. `samples/appsettings.json` (shared)
2. `samples/AnalyzeUrl/appsettings.json` (sample-specific)
3. Environment variables (highest priority)

## Authentication

This sample supports two authentication methods:

1. **DefaultAzureCredential (Recommended)**: Leave `Key` empty and use `az login`
2. **API Key**: Set the `Key` value (for testing only)

## Running the Sample

```bash
# Navigate to the sample directory
cd samples/AnalyzeUrl

# Restore dependencies
dotnet restore

# Run the sample
dotnet run
```

## Expected Output

```
🔍 Analyzing remote document from https://github.com/Azure-Samples/azure-ai-content-understanding-python/raw/refs/heads/main/data/invoice.pdf with prebuilt-documentAnalyzer...

📄 Markdown Content:
==================================================
[Document content in markdown format...]
==================================================

📚 Document Information:
Start page: 1
End page: 1
Total pages: 1

📄 Pages (1):
  Page 1: 612.0 x 792.0 pt

📊 Tables (1):
  Table 1: 5 rows x 4 columns

✅ Analysis complete!
```

## Learn More

- [Azure AI Content Understanding Documentation](https://learn.microsoft.com/azure/ai-services/content-understanding/)
- [.NET SDK Reference](https://learn.microsoft.com/dotnet/api/overview/azure/ai.contentunderstanding-readme)


---
page_type: sample
languages:
- csharp
products:
- azure
- azure-ai-services
name: Azure.AI.ContentUnderstanding samples for .NET
description: Samples for the Azure.AI.ContentUnderstanding client library.
---

# Azure.AI.ContentUnderstanding Samples for .NET

These samples demonstrate how to use the Azure AI Content Understanding SDK for .NET to analyze documents and extract content from various file types.

## Prerequisites

- **Azure subscription**: [Create one for free](https://azure.microsoft.com/free/)
- **Azure Content Understanding resource**: Create a Content Understanding resource in the [Azure Portal](https://portal.azure.com)
- **.NET 8.0 SDK or later**: [Download here](https://dotnet.microsoft.com/download/dotnet/8.0)

## Setup

### 1. Create an Azure Content Understanding Resource

1. Navigate to the [Azure Portal](https://portal.azure.com)
2. Click "Create a resource" and search for "Content Understanding"
3. Create the resource and note the **endpoint** and **API key** from the "Keys and Endpoint" section

### 2. Configure Authentication

**Recommended**: Copy `appsettings.json.sample` to `appsettings.json` in the samples root directory. This allows you to configure your endpoint and authentication settings once, and all samples will automatically use them when you run `dotnet run` from any sample directory.

```bash
cd samples
cp appsettings.json.sample appsettings.json
```

The `appsettings.json` file is optional - if it doesn't exist, samples will still build and run, but you'll need to provide configuration via environment variables. However, creating `appsettings.json` from the sample file is recommended for easier development.

**Note**: The `appsettings.json` file is automatically copied to each sample's output directory during build, so you only need to create it once in the samples root directory to use it across all samples.

All samples support two authentication methods:

#### Option A: API Key Authentication (Recommended for getting started)

1. Copy the template configuration file (if you haven't already):
   ```bash
   cp appsettings.json.sample appsettings.json
   ```

2. Edit `appsettings.json` and add your credentials:
   ```json
   {
     "AZURE_CONTENT_UNDERSTANDING_ENDPOINT": "https://your-resource-name.cognitiveservices.azure.com/",
     "AZURE_CONTENT_UNDERSTANDING_KEY": "your-api-key-here"
   }
   ```

#### Option B: DefaultAzureCredential (Recommended for production)

1. Copy the template configuration file (if you haven't already):
   ```bash
   cp appsettings.json.sample appsettings.json
   ```

2. Edit `appsettings.json` and add only your endpoint:
   ```json
   {
     "AZURE_CONTENT_UNDERSTANDING_ENDPOINT": "https://your-resource-name.cognitiveservices.azure.com/",
     "AZURE_CONTENT_UNDERSTANDING_KEY": ""
   }
   ```

3. Authenticate using one of these methods:
   - **Azure CLI**: Run `az login`
   - **Visual Studio**: Sign in through Tools → Options → Azure Service Authentication
   - **Environment Variables**: Set `AZURE_TENANT_ID`, `AZURE_CLIENT_ID`, `AZURE_CLIENT_SECRET`
   - **Managed Identity**: Automatically works when deployed to Azure services

#### Option C: Environment Variables

Set the following environment variables (no `appsettings.json` needed):

**Linux/macOS:**
```bash
export AZURE_CONTENT_UNDERSTANDING_ENDPOINT="https://your-resource-name.cognitiveservices.azure.com/"
export AZURE_CONTENT_UNDERSTANDING_KEY="your-api-key-here"  # Optional
```

**Windows (PowerShell):**
```powershell
$env:AZURE_CONTENT_UNDERSTANDING_ENDPOINT="https://your-resource-name.cognitiveservices.azure.com/"
$env:AZURE_CONTENT_UNDERSTANDING_KEY="your-api-key-here"  # Optional
```

**Note**: Environment variables take precedence over `appsettings.json` values.


## Available Samples

| Sample | Description | Key Features |
|--------|-------------|--------------|
| [ListAnalyzers](./ListAnalyzers) | List all available content analyzers | Basic client usage, authentication, pagination |
| [AnalyzeUrl](./AnalyzeUrl) | Analyze a document from a URL | Document analysis from remote URL, markdown extraction, table and page information |
| [AnalyzeBinary](./AnalyzeBinary) | Analyze a PDF file from disk | Binary file input, object model usage, document properties |
| [AnalyzeUrlPrebuiltInvoice](./AnalyzeUrlPrebuiltInvoice) | Extract invoice fields from a URL using prebuilt-invoice | Structured field extraction, nested objects, currency fields, array handling |
| [CreateOrReplaceAnalyzer](./CreateOrReplaceAnalyzer) | Create a custom analyzer with field schema and use it | Custom analyzer creation, field schema definition, LRO operations, using custom analyzers |
| [UpdateAnalyzer](./UpdateAnalyzer) | Update analyzer properties (description and tags) | Analyzer updates, PATCH operations, tag management |
| [DeleteAnalyzer](./DeleteAnalyzer) | Delete a custom analyzer | Analyzer lifecycle management, cleanup operations |
| [GetResultFile](./GetResultFile) | Get result files (keyframes) from video analysis | Video analysis, keyframe extraction, GetResultFile API, operation ID handling |
| [AnalyzeBinaryRawJson](./AnalyzeBinaryRawJson) | Analyze a PDF file and save raw JSON response | Binary file upload, protocol method usage, raw JSON response access |

## Running a Sample

1. Navigate to the sample directory:
   ```bash
   cd ListAnalyzers
   ```

2. Build and run the sample:
   ```bash
   dotnet run
   ```

   Or build first, then run:
   ```bash
   dotnet build
   dotnet run
   ```

## Project Structure

```
samples/
├── .gitignore                  # Ignores appsettings.json and sample_output
├── appsettings.json.sample     # Template configuration file (committed)
├── appsettings.json            # Your credentials (NOT committed, create from .sample)
├── README.md                   # This file
├── sample_files/               # Sample files for testing
│   └── sample_invoice.pdf
├── ListAnalyzers/              # Sample: List all analyzers
│   ├── ListAnalyzers.csproj
│   └── Program.cs
├── AnalyzeUrl/                 # Sample: Analyze document from URL
│   ├── AnalyzeUrl.csproj
│   └── Program.cs
├── AnalyzeBinary/              # Sample: Analyze PDF from disk
│   ├── AnalyzeBinary.csproj
│   └── Program.cs
├── AnalyzeUrlPrebuiltInvoice/  # Sample: Extract invoice fields
│   ├── AnalyzeUrlPrebuiltInvoice.csproj
│   └── Program.cs
├── CreateOrReplaceAnalyzer/    # Sample: Create and use custom analyzer
│   ├── CreateOrReplaceAnalyzer.csproj
│   └── Program.cs
├── UpdateAnalyzer/             # Sample: Update analyzer properties
│   ├── UpdateAnalyzer.csproj
│   └── Program.cs
├── DeleteAnalyzer/             # Sample: Delete custom analyzer
│   ├── DeleteAnalyzer.csproj
│   └── Program.cs
├── GetResultFile/              # Sample: Get result files from video analysis
│   ├── GetResultFile.csproj
│   └── Program.cs
├── AnalyzeBinaryRawJson/       # Sample: Analyze binary and save raw JSON
│   ├── AnalyzeBinaryRawJson.csproj
│   └── Program.cs
└── [Other samples...]
```

## Configuration Priority

Configuration values are loaded in the following priority order (highest to lowest):

1. **Environment Variables** - Highest priority
2. **appsettings.json** - Lower priority (loaded from the sample's output directory, which is automatically copied from the samples root during build)

This allows you to:
- Use `appsettings.json` for local development (create it once in the samples root, and it will be reused across all samples)
- Override with environment variables in production or for specific runs
- Skip `appsettings.json` entirely and use only environment variables if preferred

**Tip**: Creating `appsettings.json` from `appsettings.json.sample` in the samples root directory is the easiest way to configure all samples at once. The file is automatically copied to each sample's output directory when you run `dotnet build` or `dotnet run`.

## Common Issues and Troubleshooting

### Authentication Failed (401 Error)

**Symptom**: Error message "Authentication failed" or HTTP 401 status code.

**Solutions**:
- Verify your endpoint URL is correct (should end with `.cognitiveservices.azure.com/`)
- If using API key: Check that the key is copied correctly from Azure Portal
- If using DefaultAzureCredential: Ensure you're logged in via `az login` or Visual Studio
- Check that your Azure Content Understanding resource is active and not paused

### Endpoint Not Found

**Symptom**: Error message "AZURE_CONTENT_UNDERSTANDING_ENDPOINT is required."

**Solutions**:
- **Recommended**: Create `appsettings.json` in the samples root directory by copying from `appsettings.json.sample`:
  ```bash
  cd samples
  cp appsettings.json.sample appsettings.json
  ```
  Then edit `appsettings.json` and add your endpoint and API key.
- Alternatively, set the `AZURE_CONTENT_UNDERSTANDING_ENDPOINT` environment variable
- Verify the endpoint value is not empty in `appsettings.json` (if using that method)
- The `appsettings.json` file is automatically copied to each sample's output directory during build, so you only need to create it once in the samples root

### Build Errors

**Symptom**: Build fails with missing package references.

**Solutions**:
- Ensure you have .NET 8.0 SDK or later: `dotnet --version`
- Clean and rebuild: `dotnet clean && dotnet build`
- Restore packages explicitly: `dotnet restore`

### File Not Found: appsettings.json

**Symptom**: Runtime error about missing `appsettings.json` or configuration not found.

**Solutions**:
- **Note**: `appsettings.json` is optional - samples will build and run without it if you use environment variables
- **Recommended**: Create `appsettings.json` in the samples root directory for easier configuration:
  ```bash
  cd samples
  cp appsettings.json.sample appsettings.json
  ```
  Then edit it with your endpoint and API key. This file will be automatically copied to each sample's output directory during build.
- If you prefer not to use `appsettings.json`, ensure you've set the required environment variables (`AZURE_CONTENT_UNDERSTANDING_ENDPOINT` and optionally `AZURE_CONTENT_UNDERSTANDING_KEY`)
- The file should be in the samples root directory (not in individual sample subdirectories) - it will be automatically copied to each sample's output directory during build

## Additional Resources

- [Azure AI Content Understanding Documentation](https://learn.microsoft.com/azure/ai-services/content-understanding/)
- [Azure SDK for .NET Documentation](https://learn.microsoft.com/dotnet/azure/)
- [Azure.Identity Documentation](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme)
- [DefaultAzureCredential Documentation](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential)

## Feedback and Support

If you encounter issues or have suggestions:
- [File an issue](https://github.com/Azure/azure-sdk-for-net/issues)
- [Read the FAQ](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/README.md)

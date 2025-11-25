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
- **Microsoft Foundry resource**: Create a Microsoft Foundry resource in the [Azure Portal](https://portal.azure.com)
- **.NET 8.0 SDK or later**: [Download here](https://dotnet.microsoft.com/download/dotnet/8.0)

## Setup

### 1. Create a Microsoft Foundry Resource

1. Navigate to the [Azure Portal](https://portal.azure.com)
2. Click "Create a resource" and search for "Microsoft Foundry" or "Azure AI Foundry"
3. Create the resource and note the **endpoint** from the "Keys and Endpoint" section

### 2. Configure Authentication
**Reminder:** Environment variables will take precedence over values in `appsettings.json`. If both are set, the sample will use the environment variable value.

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
     "AZURE_CONTENT_UNDERSTANDING_ENDPOINT": "https://your-resource-name.services.ai.azure.com/",
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
     "AZURE_CONTENT_UNDERSTANDING_ENDPOINT": "https://your-resource-name.services.ai.azure.com/",
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
export AZURE_CONTENT_UNDERSTANDING_ENDPOINT="https://your-resource-name.services.ai.azure.com/"
export AZURE_CONTENT_UNDERSTANDING_KEY="your-api-key-here"  # Optional
```

**Windows (PowerShell):**
```powershell
$env:AZURE_CONTENT_UNDERSTANDING_ENDPOINT="https://your-resource-name.services.ai.azure.com/"
$env:AZURE_CONTENT_UNDERSTANDING_KEY="your-api-key-here"  # Optional
```

**Note**: Environment variables take precedence over `appsettings.json` values.

### 3. Configure Model Deployments (Required for Prebuilt Analyzers)

**⚠️ IMPORTANT**: Before using prebuilt analyzers, you MUST configure model deployments for your Microsoft Foundry resource. This is a **one-time setup per resource** that maps your deployed GPT models to the models required by the prebuilt analyzers.

See [Sample 00: Configure model deployment defaults][sample00] for detailed instructions on configuring model deployments.

## Available Samples

The samples are organized sequentially and build upon each other. Start with Sample 00 to configure your resource, then explore the samples based on your needs.

| Sample | Description | Key Features |
|--------|-------------|--------------|
| [Sample 00: Configure model deployment defaults][sample00] | Configure default model deployments for prebuilt analyzers | One-time resource setup, model deployment configuration |
| [Sample 01: Analyze a document from binary data][sample01] | Analyze a PDF file from disk | Binary file input, markdown extraction, document properties |
| [Sample 02: Analyze a document from URL][sample02] | Analyze a document from a remote URL | URL-based analysis, markdown extraction, table and page information |
| [Sample 03: Analyze an invoice using prebuilt analyzer][sample03] | Extract structured fields from invoices | Prebuilt-invoice analyzer, field extraction, nested objects, arrays |
| [Sample 04: Create a custom analyzer][sample04] | Create and use a custom analyzer with field schema | Custom analyzer creation, field schema definition, LRO operations |
| [Sample 05: Create and use a classifier][sample05] | Create classifiers to categorize documents | Content categories, document classification, segmentation |
| [Sample 06: Get analyzer information][sample06] | Retrieve details about a specific analyzer | Get analyzer API, analyzer properties, model mappings |
| [Sample 07: List all analyzers][sample07] | List all available analyzers in your resource | List analyzers, pagination, prebuilt and custom analyzers |
| [Sample 08: Update analyzer][sample08] | Update analyzer properties (description and tags) | Analyzer updates, PATCH operations, tag management |
| [Sample 09: Delete analyzer][sample09] | Delete a custom analyzer | Analyzer lifecycle management, cleanup operations |
| [Sample 10: Analyze documents with configs][sample10] | Extract charts, hyperlinks, formulas, and annotations | Advanced document features, figure extraction, formula detection |
| [Sample 11: Analyze and return raw JSON][sample11] | Analyze a document and access raw JSON response | Protocol methods, raw JSON access, JSON parsing |
| [Sample 12: Get result file][sample12] | Get result files (keyframes) from video analysis | Video analysis, keyframe extraction, GetResultFile API |
| [Sample 13: Delete result][sample13] | Delete analysis results from storage | Result lifecycle management, cleanup operations |
| [Sample 14: Copy analyzer][sample14] | Copy an analyzer within the same resource | Same-resource copying, analyzer duplication |
| [Sample 15: Grant copy authorization and copy analyzer][sample15] | Copy an analyzer between different resources | Cross-resource copying, authorization grants |

## Running a Sample

Each sample has two components:
1. **Markdown documentation** (`SampleXX_Name.md`) - Detailed documentation with code snippets
2. **Runnable sample** (`SampleXX_Name/`) - Standalone executable project

### Running from the Sample Directory

1. Navigate to the sample directory:
   ```bash
   cd Sample01_AnalyzeBinary
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

### Viewing Documentation

Each sample has a markdown file with detailed documentation:
- `Sample01_AnalyzeBinary.md` - Documentation for the binary analysis sample
- `Sample02_AnalyzeUrl.md` - Documentation for the URL analysis sample
- And so on...

Open these files in your markdown viewer or editor to see detailed explanations, code snippets, and usage examples.

## Project Structure

```
samples/
├── .gitignore                  # Ignores appsettings.json and sample_output
├── appsettings.json.sample     # Template configuration file (committed)
├── appsettings.json            # Your credentials (NOT committed, create from .sample)
├── README.md                   # This file
├── sample_files/               # Sample files for testing
│   ├── sample_invoice.pdf
│   ├── sample_document_features.pdf
│   └── sample_bank_statement.pdf
├── Sample00_ConfigureDefaults/     # Sample: Configure model deployments
│   ├── Sample00_ConfigureDefaults.csproj
│   ├── Program.cs
│   └── README.md
├── Sample00_ConfigureDefaults.md   # Documentation for Sample 00
├── Sample01_AnalyzeBinary/          # Sample: Analyze PDF from disk
│   ├── Sample01_AnalyzeBinary.csproj
│   ├── Program.cs
│   └── README.md
├── Sample01_AnalyzeBinary.md       # Documentation for Sample 01
├── Sample02_AnalyzeUrl/             # Sample: Analyze document from URL
│   ├── Sample02_AnalyzeUrl.csproj
│   ├── Program.cs
│   └── README.md
├── Sample02_AnalyzeUrl.md          # Documentation for Sample 02
├── ... (additional samples follow the same pattern)
└── Sample15_GrantCopyAuth/         # Sample: Cross-resource copying
    ├── Sample15_GrantCopyAuth.csproj
    ├── Program.cs
    └── README.md
```

## Sample Organization

Samples are numbered sequentially (00-15) and are designed to build upon each other:

- **Samples 00-02**: Basic setup and document analysis
- **Samples 03-05**: Prebuilt analyzers and custom analyzers
- **Samples 06-09**: Analyzer management (get, list, update, delete)
- **Samples 10-13**: Advanced features (configs, raw JSON, result files)
- **Samples 14-15**: Analyzer copying (same-resource and cross-resource)

Each sample includes:
- A **markdown file** (`SampleXX_Name.md`) with detailed documentation
- A **runnable directory** (`SampleXX_Name/`) with a standalone executable project
- A **README.md** in each sample directory with quick start instructions

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
- Verify your endpoint URL is correct (should end with `.services.ai.azure.com/`)
- If using API key: Check that the key is copied correctly from Azure Portal
- If using DefaultAzureCredential: Ensure you're logged in via `az login` or Visual Studio
- Check that your Microsoft Foundry resource is active and not paused

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

### Model Deployment Not Configured

**Symptom**: Error when using prebuilt analyzers about missing model deployments.

**Solutions**:
- Run [Sample 00: Configure model deployment defaults][sample00] first
- Ensure you have deployed the required models (GPT-4.1, GPT-4.1-mini, text-embedding-3-large) in your Microsoft Foundry resource
- Verify the deployment names match what you configured in Sample 00

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

<!-- Sample links -->
[sample00]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_ConfigureDefaults.md
[sample01]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
[sample02]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample02_AnalyzeUrl.md
[sample03]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample03_AnalyzeInvoice.md
[sample04]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample04_CreateAnalyzer.md
[sample05]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample05_CreateClassifier.md
[sample06]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample06_GetAnalyzer.md
[sample07]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample07_ListAnalyzers.md
[sample08]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample08_UpdateAnalyzer.md
[sample09]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample09_DeleteAnalyzer.md
[sample10]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample10_AnalyzeConfigs.md
[sample11]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample11_AnalyzeReturnRawJson.md
[sample12]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample12_GetResultFile.md
[sample13]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample13_DeleteResult.md
[sample14]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample14_CopyAnalyzer.md
[sample15]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample15_GrantCopyAuth.md

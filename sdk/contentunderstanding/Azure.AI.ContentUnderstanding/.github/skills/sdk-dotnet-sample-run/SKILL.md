---
name: sdk-dotnet-sample-run
description: Run a specific sample for the Azure AI Content Understanding .NET SDK. Extracts code from sample markdown files, builds a standalone console project, and runs it against live Azure services. Use when users want to run a particular sample like Sample01_AnalyzeBinary or Sample02_AnalyzeUrl.
---

# Run a Specific .NET SDK Sample

Run a specific sample from the Azure AI Content Understanding .NET SDK.

## What This Skill Does

1. **Auto-detects and installs** the .NET SDK (10.0, matching the repo's `global.json`)
2. Lists or locates the specified sample markdown file in `samples/`
3. Extracts all C# code blocks from the markdown into a runnable console application
4. **Builds the local SDK from source** (`src/`) and references the DLL directly; falls back to NuGet if the build fails
5. Creates a sample-specific .NET console project in `.sample_runner/<SampleName>/` with all required scaffolding created at runtime
6. Reads credentials from `appsettings.json` in the package root (or environment variables)
7. Executes the sample and reports results

## Prerequisites

- An Azure subscription with a **Microsoft Foundry resource**
- Model deployments configured (run `Sample00_UpdateDefaults` first)
- Credentials configured in `appsettings.json` (see below)

> **Note:** The .NET SDK is **automatically installed** by the script if not already present. .NET 10.0 (matching the repo's `global.json`) is installed to `~/.dotnet/`.

## Package Directory

```
sdk/contentunderstanding/Azure.AI.ContentUnderstanding
```

## Credential Setup

Create an `appsettings.json` file in the package directory (`sdk/contentunderstanding/Azure.AI.ContentUnderstanding/`):

```json
{
  "CONTENTUNDERSTANDING_ENDPOINT": "https://your-foundry.services.ai.azure.com/",
  "CONTENTUNDERSTANDING_API_KEY": "",

  "CONTENTUNDERSTANDING_GPT41_DEPLOYMENT": "gpt-4.1",
  "CONTENTUNDERSTANDING_GPT41_MINI_DEPLOYMENT": "gpt-4.1-mini",
  "CONTENTUNDERSTANDING_EMBEDDING_DEPLOYMENT": "text-embedding-3-large",

  "CONTENTUNDERSTANDING_SOURCE_ENDPOINT": "",
  "CONTENTUNDERSTANDING_SOURCE_RESOURCE_ID": "",
  "CONTENTUNDERSTANDING_SOURCE_REGION": "",
  "CONTENTUNDERSTANDING_TARGET_ENDPOINT": "",
  "CONTENTUNDERSTANDING_TARGET_RESOURCE_ID": "",
  "CONTENTUNDERSTANDING_TARGET_REGION": ""
}
```

### Settings by sample

| Setting | Required By | Description |
|---------|-------------|-------------|
| `CONTENTUNDERSTANDING_ENDPOINT` | **All samples** | Your Microsoft Foundry resource endpoint URL |
| `CONTENTUNDERSTANDING_API_KEY` | All samples (optional) | API key for key-based auth. If empty, `DefaultAzureCredential` is used (recommended — run `az login` first) |
| `CONTENTUNDERSTANDING_GPT41_DEPLOYMENT` | Sample00 | Deployment name for gpt-4.1 model (default: `gpt-4.1`) |
| `CONTENTUNDERSTANDING_GPT41_MINI_DEPLOYMENT` | Sample00 | Deployment name for gpt-4.1-mini model (default: `gpt-4.1-mini`) |
| `CONTENTUNDERSTANDING_EMBEDDING_DEPLOYMENT` | Sample00 | Deployment name for text-embedding-3-large model (default: `text-embedding-3-large`) |
| `CONTENTUNDERSTANDING_SOURCE_ENDPOINT` | Sample15 | Source Foundry resource endpoint for cross-resource copy |
| `CONTENTUNDERSTANDING_SOURCE_RESOURCE_ID` | Sample15 | Source ARM resource ID for cross-resource copy |
| `CONTENTUNDERSTANDING_SOURCE_REGION` | Sample15 | Source region (e.g., `eastus`) for cross-resource copy |
| `CONTENTUNDERSTANDING_TARGET_ENDPOINT` | Sample15 | Target Foundry resource endpoint for cross-resource copy |
| `CONTENTUNDERSTANDING_TARGET_RESOURCE_ID` | Sample15 | Target ARM resource ID for cross-resource copy |
| `CONTENTUNDERSTANDING_TARGET_REGION` | Sample15 | Target region (e.g., `westus`) for cross-resource copy |

### Samples that need a local file

Samples **01, 05, 10, 11** require a local document file. The script auto-downloads a test PDF if no file is provided. To use your own file:

```bash
.github/skills/sdk-dotnet-sample-run/scripts/run-sample.sh Sample01_AnalyzeBinary --file /path/to/your/document.pdf
```

You can also set these as environment variables instead of using `appsettings.json`.

## Available Samples

### Getting Started (Run These First)

#### `Sample00_UpdateDefaults` ⭐ Required First!
**One-time setup** - Configures model deployment mappings (GPT-4.1, GPT-4.1-mini, text-embedding-3-large) for your Microsoft Foundry resource. Must run before using prebuilt analyzers.

#### `Sample01_AnalyzeBinary` ⭐ Start Here!
Analyzes a local PDF/image file using `prebuilt-documentSearch`.
- Key concepts: Binary input, local file reading, markdown extraction, page properties

#### `Sample02_AnalyzeUrl`
Analyzes content from URLs across all modalities: documents, images, audio, and video using prebuilt RAG analyzers.
- Key concepts: URL input, multi-modal content (`prebuilt-documentSearch`, `prebuilt-imageSearch`, `prebuilt-audioSearch`, `prebuilt-videoSearch`)

### Document Analysis

#### `Sample03_AnalyzeInvoice`
Extracts structured fields from invoices using `prebuilt-invoice`.
- Key concepts: Field extraction (customer name, totals, dates, line items), confidence scores, array fields

#### `Sample10_AnalyzeConfigs`
Extracts advanced features: charts, hyperlinks, formulas, annotations.
- Key concepts: Chart.js output, LaTeX formulas, PDF annotations, enhanced analysis options

#### `Sample11_AnalyzeReturnRawJson`
Gets raw JSON response for custom processing.
- Key concepts: Raw response access, saving to file, debugging

### Custom Analyzers

#### `Sample04_CreateAnalyzer`
Creates custom analyzer with field schema for domain-specific extraction.
- Key concepts: Field types (string, number, date, object, array), extraction methods (extract, generate, classify)

#### `Sample05_CreateClassifier`
Creates classifier to categorize documents (Loan_Application, Invoice, Bank_Statement).
- Key concepts: Content categories, segmentation, document routing

### Analyzer Management

#### `Sample06_GetAnalyzer`
Retrieves analyzer details and configuration.

#### `Sample07_ListAnalyzers`
Lists all available analyzers (prebuilt and custom).

#### `Sample08_UpdateAnalyzer`
Updates analyzer description and tags.

#### `Sample09_DeleteAnalyzer`
Deletes a custom analyzer.

#### `Sample14_CopyAnalyzer`
Copies analyzer within the same resource.

#### `Sample15_GrantCopyAuth`
Cross-resource copying between different Azure resources/regions.
- Requires additional settings: `CONTENTUNDERSTANDING_SOURCE_ENDPOINT`, `CONTENTUNDERSTANDING_SOURCE_RESOURCE_ID`, `CONTENTUNDERSTANDING_SOURCE_REGION`, `CONTENTUNDERSTANDING_TARGET_ENDPOINT`, `CONTENTUNDERSTANDING_TARGET_RESOURCE_ID`, `CONTENTUNDERSTANDING_TARGET_REGION`

### Setting up Sample15 cross-resource environment

Sample15 requires **two separate Microsoft Foundry resources** (source and target). Add the following to your `appsettings.json`:

```json
{
  "CONTENTUNDERSTANDING_ENDPOINT": "https://your-source-foundry.services.ai.azure.com/",
  "CONTENTUNDERSTANDING_SOURCE_ENDPOINT": "https://your-source-foundry.services.ai.azure.com/",
  "CONTENTUNDERSTANDING_SOURCE_RESOURCE_ID": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.CognitiveServices/accounts/{sourceAccountName}",
  "CONTENTUNDERSTANDING_SOURCE_REGION": "eastus",
  "CONTENTUNDERSTANDING_TARGET_ENDPOINT": "https://your-target-foundry.services.ai.azure.com/",
  "CONTENTUNDERSTANDING_TARGET_RESOURCE_ID": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.CognitiveServices/accounts/{targetAccountName}",
  "CONTENTUNDERSTANDING_TARGET_REGION": "swedencentral"
}
```

**How to find these values:**

1. **Endpoint**: Go to Azure Portal → your Foundry resource → Overview → "Endpoint" field
2. **Resource ID**: Azure Portal → your Foundry resource → Properties → "Resource ID"
3. **Region**: Azure Portal → your Foundry resource → Overview → "Location" (use the programmatic name, e.g., `eastus`, `swedencentral`, not the display name)

**Prerequisites for cross-resource copy:**
- Both resources must have the **Cognitive Services User** role assigned to your credential (user, service principal, or managed identity)
- Both resources must have model deployments configured (run `Sample00_UpdateDefaults` on each)
- Cross-resource copy requires `DefaultAzureCredential` (API keys cannot be used)
- The test infrastructure (`test-resources.bicep`) can automatically provision both resources via `New-TestResources.ps1`

### Result Management

#### `Sample12_GetResultFile`
Retrieves keyframe images from video analysis.
- Key concepts: Operation IDs, extracting generated files

#### `Sample13_DeleteResult`
Deletes analysis results for data cleanup.
- Key concepts: Result retention (24-hour auto-deletion), compliance

## Workflow

### Step 1: Navigate to Package Directory

```bash
cd sdk/contentunderstanding/Azure.AI.ContentUnderstanding
```

### Step 2: Configure Credentials

```bash
# Create appsettings.json (if not already done)
cat > appsettings.json << 'EOF'
{
  "CONTENTUNDERSTANDING_ENDPOINT": "https://your-foundry.services.ai.azure.com/",
  "CONTENTUNDERSTANDING_API_KEY": "",
  "CONTENTUNDERSTANDING_GPT41_DEPLOYMENT": "gpt-4.1",
  "CONTENTUNDERSTANDING_GPT41_MINI_DEPLOYMENT": "gpt-4.1-mini",
  "CONTENTUNDERSTANDING_EMBEDDING_DEPLOYMENT": "text-embedding-3-large"
}
EOF
```

Or set environment variables:

```bash
export CONTENTUNDERSTANDING_ENDPOINT="https://your-foundry.services.ai.azure.com/"
# Optional: export CONTENTUNDERSTANDING_API_KEY="your-key"
```

### Step 3: Run the Sample

**Using the script (recommended):**

```bash
# Linux/macOS
.github/skills/sdk-dotnet-sample-run/scripts/run-sample.sh Sample02_AnalyzeUrl

# Windows (PowerShell)
.github\skills\sdk-dotnet-sample-run\scripts\run-sample.ps1 -SampleName Sample02_AnalyzeUrl
```

**Examples:**

```bash
# Run update defaults (one-time setup)
.github/skills/sdk-dotnet-sample-run/scripts/run-sample.sh Sample00_UpdateDefaults

# Analyze a document from binary data
.github/skills/sdk-dotnet-sample-run/scripts/run-sample.sh Sample01_AnalyzeBinary

# Analyze content from URLs
.github/skills/sdk-dotnet-sample-run/scripts/run-sample.sh Sample02_AnalyzeUrl

# Extract invoice fields
.github/skills/sdk-dotnet-sample-run/scripts/run-sample.sh Sample03_AnalyzeInvoice

# List available samples
.github/skills/sdk-dotnet-sample-run/scripts/run-sample.sh --list
```

## Quick Reference

### Most Common Samples for New Users

1. **First-time setup** (run once per Foundry resource):
   ```bash
   .github/skills/sdk-dotnet-sample-run/scripts/run-sample.sh Sample00_UpdateDefaults
   ```

2. **Analyze a document from binary data:**
   ```bash
   .github/skills/sdk-dotnet-sample-run/scripts/run-sample.sh Sample01_AnalyzeBinary
   ```

3. **Analyze content from URL:**
   ```bash
   .github/skills/sdk-dotnet-sample-run/scripts/run-sample.sh Sample02_AnalyzeUrl
   ```

4. **Extract invoice fields:**
   ```bash
   .github/skills/sdk-dotnet-sample-run/scripts/run-sample.sh Sample03_AnalyzeInvoice
   ```

### List Available Samples

```bash
.github/skills/sdk-dotnet-sample-run/scripts/run-sample.sh --list
```

## How It Works

The script:
1. **Ensures .NET SDK availability** — checks for `dotnet`, installs .NET 10.0 (or whatever the repo's `global.json` requires) automatically via the official install script
2. **Creates `.sample_runner/` scaffolding at runtime** — generates `global.json`, `Directory.Build.props`, `Directory.Build.targets`, `Directory.Packages.props`, and `NuGet.Config` to isolate the sample project from the mono-repo's MSBuild/NuGet infrastructure
3. **Builds the local SDK from source** — runs `dotnet build` on `src/Azure.AI.ContentUnderstanding.csproj` and locates the output DLL in `artifacts/bin/`. If the build fails, falls back to the NuGet package (`Azure.AI.ContentUnderstanding 1.0.0-*`)
4. Reads the sample markdown file (e.g., `samples/Sample01_AnalyzeBinary.md`)
5. Extracts all `C# Snippet:*` code blocks from the markdown
6. Creates a temporary .NET 10.0 console project in `.sample_runner/<SampleName>/`
7. Generates a `Program.cs` that:
   - Loads settings from `appsettings.json` (copied from package root) or environment variables
   - Replaces all sample-specific placeholders (`<endpoint>`, `<apiKey>`, `<your-gpt-4.1-deployment-name>`, `<localDocumentFilePath>`, `<file_path>`, cross-resource endpoints/regions, etc.) with actual config values
   - Detects duplicate variable declarations across snippets; if found (e.g., `uriSource`, `result` in Sample02), wraps each snippet in its own `{ }` scope block to avoid collisions. Sequential snippets that share variables (e.g., Sample01) are left unwrapped.
   - Combines all extracted code snippets into a runnable program
8. Builds and runs the project using `dotnet run`

> **The `.sample_runner/` directory is assumed to start clean** — all scaffolding files are created at runtime. You can safely delete it to reset the environment.

## Troubleshooting

| Error | Solution |
|-------|----------|
| `dotnet: command not found` | Should be auto-installed by the script. If it fails, install manually: https://dotnet.microsoft.com/download |
| `No appsettings.json found` | Create `appsettings.json` in the package root directory or set environment variables |
| `Access denied` or authorization errors | Ensure **Cognitive Services User** role is assigned; check API key or run `az login` |
| `Model deployment not found` | Run `Sample00_UpdateDefaults` first to configure model mappings |
| `File not found` for binary samples | Some samples need a local file path; the script provides a default test file URL |
| Local SDK build fails | The script falls back to NuGet automatically. Check `dotnet --list-sdks` for installed versions |
| NuGet restore errors | The `.sample_runner/` isolation files should prevent repo NuGet feed issues. Delete `.sample_runner/` and re-run |
| `.sample_runner/` issues | Delete the entire `.sample_runner/` directory — it will be recreated from scratch on next run |

## Related Skills

- `sdk-py-sample-run` - Run Python SDK samples

## Additional Resources

- [SDK README](../../../README.md) - Full SDK documentation
- [Samples directory](../../../samples/) - Sample markdown files
- [Product Documentation](https://learn.microsoft.com/azure/ai-services/content-understanding/)

---
name: cu-sdk-dotnet-sample-run
description: Build a runnable sample project for the Azure AI Content Understanding .NET SDK. Extracts code from sample markdown files and builds a standalone console project. By default, the script builds the project and prints instructions for the user to run it with `dotnet run`. Use `--run` flag to also execute the sample directly.
---

# Build and Run a .NET SDK Sample

Build (and optionally run) a specific sample from the Azure AI Content Understanding .NET SDK.

> **[COPILOT INTERACTION MODEL]:** This skill is designed to be interactive. At each step marked with **[ASK USER]**, pause execution and prompt the user for input or confirmation before proceeding. Do NOT silently skip these prompts. Use the `ask_questions` tool when available.

## What This Skill Does

1. **Auto-detects and installs** the .NET SDK (10.0, matching the repo's `global.json`)
2. Lists or locates the specified sample markdown file in `samples/`
3. Extracts all C# code blocks from the markdown into a runnable console application
4. **Installs the SDK from public NuGet** (`Azure.AI.ContentUnderstanding 1.0.0-*`); falls back to building from local source (`src/`) if the NuGet package is not available
5. Creates a sample-specific .NET console project in `.sample_runner/<SampleName>/` with all required scaffolding created at runtime
6. Reads credentials from `appsettings.json` in the package root (or environment variables)
7. **Builds the project** and directs the user to run the sample via `dotnet run`
8. Optionally runs the sample directly if `--run` flag is provided

## Prerequisites

- An Azure subscription with a **Microsoft Foundry resource**
- Model deployments configured (run `Sample00_UpdateDefaults` first)
- Credentials configured in `appsettings.json` (see below)

> **Note:** The .NET SDK is **automatically installed** by the script if not already present. .NET 10.0 (matching the repo's `global.json`) is installed to `~/.dotnet/`.

> **[ASK USER] Prerequisites check:**
> Before proceeding, verify the user's environment:
> 1. "Have you already run the **setup check** (`cu-sdk-setup-check` skill)?" — If no, recommend running it first to validate endpoint, auth, and model deployments.
> 2. "Have you configured your `appsettings.json` with your endpoint and credentials?" — If no, guide them through the Credential Setup section below.
> 3. "Have you run `Sample00_UpdateDefaults` to configure model defaults?" — If no and they want to use prebuilt analyzers, guide them to run it first.

## Package Directory

```
sdk/contentunderstanding/Azure.AI.ContentUnderstanding
```

## Credential Setup

> **[ASK USER] Existing configuration:**
> Ask the user: "Do you already have an `appsettings.json` configured in the package directory?"
> - If yes: "Would you like to keep your existing configuration, or start fresh?"
> - If no: Proceed to collect endpoint and credentials below.

> **[ASK USER] Provide endpoint:**
> Ask the user: "Please provide your **Microsoft Foundry endpoint URL**."
> - It should look like: `https://<your-resource-name>.services.ai.azure.com/`
> - It should NOT include `api-version` or other query parameters.
> - If the user does not know where to find it: direct them to Azure Portal → Their Foundry resource → Keys and Endpoint.

> **[ASK USER] Authentication method:**
> Ask the user: "How would you like to **authenticate** with Azure?"
> - **Option A: DefaultAzureCredential (recommended)** — Uses `az login` or managed identity. No API key needed. Make sure you have run `az login`.
> - **Option B: API Key** — Provide your `AZURE_CONTENT_UNDERSTANDING_KEY` from the Azure Portal → Keys and Endpoint → Key1 or Key2.

Create an `appsettings.json` file in the package directory (`sdk/contentunderstanding/Azure.AI.ContentUnderstanding/`):

```json
{
  "CONTENTUNDERSTANDING_ENDPOINT": "https://your-foundry.services.ai.azure.com/",
  "AZURE_CONTENT_UNDERSTANDING_KEY": "",

  "GPT_4_1_DEPLOYMENT": "gpt-4.1",
  "GPT_4_1_MINI_DEPLOYMENT": "gpt-4.1-mini",
  "TEXT_EMBEDDING_3_LARGE_DEPLOYMENT": "text-embedding-3-large",

  "CONTENTUNDERSTANDING_SOURCE_ENDPOINT": "",
  "AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID": "",
  "AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION": "",
  "CONTENTUNDERSTANDING_TARGET_ENDPOINT": "",
  "AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID": "",
  "AZURE_CONTENT_UNDERSTANDING_TARGET_REGION": ""
}
```

> **[ASK USER] Confirm appsettings.json:**
> After writing the file, summarize the configuration values (masking any API key) and ask: "Does this configuration look correct?" Wait for confirmation before proceeding.

### Settings by sample

| Setting | Required By | Description |
|---------|-------------|-------------|
| `CONTENTUNDERSTANDING_ENDPOINT` | **All samples** | Your Microsoft Foundry resource endpoint URL |
| `AZURE_CONTENT_UNDERSTANDING_KEY` | All samples (optional) | API key for key-based auth. If empty, `DefaultAzureCredential` is used (recommended — run `az login` first) |
| `AZURE_CONTENT_UNDERSTANDING_KEY` | All samples (optional) | API key for key-based auth. If empty, `DefaultAzureCredential` is used (recommended — run `az login` first) |
| `GPT_4_1_DEPLOYMENT` | Sample00 | Deployment name for gpt-4.1 model (default: `gpt-4.1`) |
| `GPT_4_1_MINI_DEPLOYMENT` | Sample00 | Deployment name for gpt-4.1-mini model (default: `gpt-4.1-mini`) |
| `TEXT_EMBEDDING_3_LARGE_DEPLOYMENT` | Sample00 | Deployment name for text-embedding-3-large model (default: `text-embedding-3-large`) |
| `CONTENTUNDERSTANDING_SOURCE_ENDPOINT` | Sample15 | Source Foundry resource endpoint for cross-resource copy |
| `AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID` | Sample15 | Source ARM resource ID for cross-resource copy |
| `AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION` | Sample15 | Source region (e.g., `eastus`) for cross-resource copy |
| `CONTENTUNDERSTANDING_TARGET_ENDPOINT` | Sample15 | Target Foundry resource endpoint for cross-resource copy |
| `AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID` | Sample15 | Target ARM resource ID for cross-resource copy |
| `AZURE_CONTENT_UNDERSTANDING_TARGET_REGION` | Sample15 | Target region (e.g., `westus`) for cross-resource copy |

### Samples that need a local file

Samples **01, 05, 10, 11** require a local document file. The script auto-downloads a test PDF if no file is provided. To use your own file:

```bash
.github/skills/cu-sdk-dotnet-sample-run/scripts/run-sample.sh Sample01_AnalyzeBinary --file /path/to/your/document.pdf
```

> **[ASK USER] Local file (if applicable):**
> If the user chose a sample that requires a local file (Sample01, Sample05, Sample10, Sample11), ask:
> "This sample requires a local document file. Would you like to:"
> - **Use the default test PDF** — The script will auto-download one for you.
> - **Provide your own file** — Please provide the full path to your document (PDF, image, etc.).

You can also set these as environment variables instead of using `appsettings.json`.

## Available Samples

> **[ASK USER] Which sample?:**
> Ask the user: "Which sample would you like to run?" with options:
> - `Sample00_UpdateDefaults` — Configure model defaults (one-time setup, required first)
> - `Sample01_AnalyzeBinary` — Analyze a local PDF/image file (recommended start)
> - `Sample02_AnalyzeUrl` — Analyze content from URLs (documents, images, audio, video)
> - `Sample03_AnalyzeInvoice` — Extract structured invoice fields
> - `Sample04_CreateAnalyzer` — Create a custom analyzer
> - Other — Let me see the full list
>
> If the user picks "Other", show the full Available Samples list below or run:
> `.github/skills/cu-sdk-dotnet-sample-run/scripts/run-sample.sh --list`

### Getting Started (Run These First)

#### `Sample00_UpdateDefaults` — Required First!
**One-time setup** - Configures model deployment mappings (GPT-4.1, GPT-4.1-mini, text-embedding-3-large) for your Microsoft Foundry resource. Must run before using prebuilt analyzers.

#### `Sample01_AnalyzeBinary` — Start Here!
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
- Requires additional settings: `CONTENTUNDERSTANDING_SOURCE_ENDPOINT`, `AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID`, `AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION`, `CONTENTUNDERSTANDING_TARGET_ENDPOINT`, `AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID`, `AZURE_CONTENT_UNDERSTANDING_TARGET_REGION`

### Setting up Sample15 cross-resource environment

Sample15 requires **two separate Microsoft Foundry resources** (source and target).

> **[ASK USER] Cross-resource setup (Sample15 only):**
> If the user chose Sample15, ask:
> 1. "Do you have **two separate Microsoft Foundry resources** (source and target) set up?" — If no, guide them to create a second resource.
> 2. "Please provide the following for your **source** resource:"
>    - Source endpoint URL
>    - Source ARM Resource ID (found in Azure Portal → Properties → Resource ID)
>    - Source region (programmatic name, e.g., `eastus`)
> 3. "Please provide the following for your **target** resource:"
>    - Target endpoint URL
>    - Target ARM Resource ID
>    - Target region
> 4. Confirm: "Cross-resource copy requires `DefaultAzureCredential` (API keys cannot be used) and both resources must have the **Cognitive Services User** role assigned. Is this configured?"

Add the following to your `appsettings.json`:

```json
{
  "CONTENTUNDERSTANDING_ENDPOINT": "https://your-source-foundry.services.ai.azure.com/",
  "CONTENTUNDERSTANDING_SOURCE_ENDPOINT": "https://your-source-foundry.services.ai.azure.com/",
  "AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.CognitiveServices/accounts/{sourceAccountName}",
  "AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION": "eastus",
  "CONTENTUNDERSTANDING_TARGET_ENDPOINT": "https://your-target-foundry.services.ai.azure.com/",
  "AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.CognitiveServices/accounts/{targetAccountName}",
  "AZURE_CONTENT_UNDERSTANDING_TARGET_REGION": "swedencentral"
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

> **[ASK USER] Configuration check:**
> Ask the user: "Do you already have `appsettings.json` configured with your endpoint and credentials?"
> - If yes: Skip to Step 3.
> - If no: Guide them through the Credential Setup section above, collecting endpoint, auth method, and model deployment names interactively.

```bash
# Create appsettings.json (if not already done)
cat > appsettings.json << 'EOF'
{
  "CONTENTUNDERSTANDING_ENDPOINT": "https://your-foundry.services.ai.azure.com/",
  "AZURE_CONTENT_UNDERSTANDING_KEY": "",
  "GPT_4_1_DEPLOYMENT": "gpt-4.1",
  "GPT_4_1_MINI_DEPLOYMENT": "gpt-4.1-mini",
  "TEXT_EMBEDDING_3_LARGE_DEPLOYMENT": "text-embedding-3-large"
}
EOF
```

Or set environment variables:

```bash
export CONTENTUNDERSTANDING_ENDPOINT="https://your-foundry.services.ai.azure.com/"
# Optional: export AZURE_CONTENT_UNDERSTANDING_KEY="your-key"
```

### Step 3: Determine Platform

> **[ASK USER] Platform:**
> Ask the user: "Which **platform** are you on?" with options:
> - Linux/macOS (use bash commands)
> - Windows PowerShell
>
> Use their answer to show the correct script command below.

### Step 4: Build the Sample Project

> **[ASK USER] Ready to build:**
> Ask the user: "Ready to build the sample project? This will create a runnable .NET project from the sample code. (Yes / Not yet)"
> If "Not yet", ask what they still need to configure and help them resolve it.

**Bash (Linux/macOS):**

```bash
.github/skills/cu-sdk-dotnet-sample-run/scripts/run-sample.sh <SampleName>
```

**PowerShell (Windows):**

```powershell
.github\skills\cu-sdk-dotnet-sample-run\scripts\run-sample.ps1 -SampleName <SampleName>
```

**Examples:**

```bash
# Build the update defaults sample (one-time setup)
.github/skills/cu-sdk-dotnet-sample-run/scripts/run-sample.sh Sample00_UpdateDefaults

# Build the analyze binary sample
.github/skills/cu-sdk-dotnet-sample-run/scripts/run-sample.sh Sample01_AnalyzeBinary

# Build and run in one step (using --run flag)
.github/skills/cu-sdk-dotnet-sample-run/scripts/run-sample.sh Sample02_AnalyzeUrl --run

# List available samples
.github/skills/cu-sdk-dotnet-sample-run/scripts/run-sample.sh --list
```

### Step 5: Run the Sample

After the script builds successfully, it prints the project location and the command to run. Execute the sample using `dotnet run`:

```bash
cd .sample_runner/<SampleName>
dotnet run --project <SampleName>.csproj
```

For example:

```bash
cd .sample_runner/Sample01_AnalyzeBinary
dotnet run --project Sample01_AnalyzeBinary.csproj
```

Alternatively, you can use the `--run` flag to build and run in one step:

**Bash:**
```bash
.github/skills/cu-sdk-dotnet-sample-run/scripts/run-sample.sh Sample01_AnalyzeBinary --run
```

**PowerShell:**
```powershell
.github\skills\cu-sdk-dotnet-sample-run\scripts\run-sample.ps1 -SampleName Sample01_AnalyzeBinary -Run
```

### Step 6: Review Results

> **[ASK USER] Sample result:**
> After running the sample, ask: "Did the sample run successfully?"
> - If yes:
>   - Show the terminal command to re-run this sample directly (e.g., `cd .sample_runner/Sample02_AnalyzeUrl && dotnet run --project Sample02_AnalyzeUrl.csproj`)
>   - Briefly explain the key code concepts demonstrated in this sample (e.g., client creation, analyzer selection, result processing, content type casting)
>   - Then ask: "Would you like to run another sample, or are you all set?"
> - If no: Help troubleshoot using the Troubleshooting section below. Common issues include missing `appsettings.json`, model defaults not configured, or authorization errors.

> **[ASK USER] Run another?:**
> If the user wants to run another sample, loop back to the "Which sample?" prompt in the Available Samples section above.

## Quick Reference

### Most Common Samples for New Users

1. **First-time setup** (run once per Foundry resource):
   ```bash
   # Build
   .github/skills/cu-sdk-dotnet-sample-run/scripts/run-sample.sh Sample00_UpdateDefaults
   # Run
   cd .sample_runner/Sample00_UpdateDefaults && dotnet run --project Sample00_UpdateDefaults.csproj
   ```

2. **Analyze a document from binary data:**
   ```bash
   # Build
   .github/skills/cu-sdk-dotnet-sample-run/scripts/run-sample.sh Sample01_AnalyzeBinary
   # Run
   cd .sample_runner/Sample01_AnalyzeBinary && dotnet run --project Sample01_AnalyzeBinary.csproj
   ```

3. **Analyze content from URL:**
   ```bash
   # Build
   .github/skills/cu-sdk-dotnet-sample-run/scripts/run-sample.sh Sample02_AnalyzeUrl
   # Run
   cd .sample_runner/Sample02_AnalyzeUrl && dotnet run --project Sample02_AnalyzeUrl.csproj
   ```

4. **Extract invoice fields:**
   ```bash
   # Build
   .github/skills/cu-sdk-dotnet-sample-run/scripts/run-sample.sh Sample03_AnalyzeInvoice
   # Run
   cd .sample_runner/Sample03_AnalyzeInvoice && dotnet run --project Sample03_AnalyzeInvoice.csproj
   ```

### List Available Samples

```bash
.github/skills/cu-sdk-dotnet-sample-run/scripts/run-sample.sh --list
```

## How It Works

The script:
1. **Ensures .NET SDK availability** — checks for `dotnet`, installs .NET 10.0 (or whatever the repo's `global.json` requires) automatically via the official install script
2. **Creates `.sample_runner/` scaffolding at runtime** — generates `global.json`, `Directory.Build.props`, `Directory.Build.targets`, `Directory.Packages.props`, and `NuGet.Config` to isolate the sample project from the mono-repo's MSBuild/NuGet infrastructure
3. **Installs the SDK from public NuGet** — uses the `Azure.AI.ContentUnderstanding 1.0.0-*` package from nuget.org. If the NuGet package is not available, falls back to building from local source (`src/Azure.AI.ContentUnderstanding.csproj`) and referencing the output DLL from `artifacts/bin/`
4. Reads the sample markdown file (e.g., `samples/Sample01_AnalyzeBinary.md`)
5. Extracts all `C# Snippet:*` code blocks from the markdown
6. Creates a temporary .NET 10.0 console project in `.sample_runner/<SampleName>/`
7. Generates a `Program.cs` that:
   - Loads settings from `appsettings.json` (copied from package root) or environment variables
   - Replaces all sample-specific placeholders (`<endpoint>`, `<apiKey>`, `<your-gpt-4.1-deployment-name>`, `<localDocumentFilePath>`, `<file_path>`, cross-resource endpoints/regions, etc.) with actual config values
   - Detects duplicate variable declarations across snippets; if found (e.g., `uriSource`, `result` in Sample02), wraps each snippet in its own `{ }` scope block to avoid collisions. Sequential snippets that share variables (e.g., Sample01) are left unwrapped.
   - Combines all extracted code snippets into a runnable program
8. **Builds** the project using `dotnet build`
9. Prints the project path and `dotnet run` command for the user to execute
10. Optionally runs the project directly if `--run` flag is provided

> **The `.sample_runner/` directory is assumed to start clean** — all scaffolding files are created at runtime. You can safely delete it to reset the environment.

## Troubleshooting

| Error | Solution |
|-------|----------|
| `dotnet: command not found` | Should be auto-installed by the script. If it fails, install manually: https://dotnet.microsoft.com/download |
| `No appsettings.json found` | Create `appsettings.json` in the package root directory or set environment variables |
| `Access denied` or authorization errors | Ensure **Cognitive Services User** role is assigned; check API key or run `az login` |
| `Model deployment not found` | Run `Sample00_UpdateDefaults` first to configure model mappings |
| `File not found` for binary samples | Some samples need a local file path; the script provides a default test file URL |
| NuGet package not found | The script falls back to building from local source automatically. Check `dotnet --list-sdks` for installed versions |
| NuGet restore errors | The `.sample_runner/` isolation files should prevent repo NuGet feed issues. Delete `.sample_runner/` and re-run |
| `.sample_runner/` issues | Delete the entire `.sample_runner/` directory — it will be recreated from scratch on next run |

## Related Skills

- `sdk-py-sample-run` - Run Python SDK samples

## Additional Resources

- [SDK README](../../../README.md) - Full SDK documentation
- [Samples directory](../../../samples/) - Sample markdown files
- [Product Documentation](https://learn.microsoft.com/azure/ai-services/content-understanding/)

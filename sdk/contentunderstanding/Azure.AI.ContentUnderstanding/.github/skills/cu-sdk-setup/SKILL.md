---
name: cu-sdk-setup
description: Guide SDK users through setting up their .NET environment for Azure AI Content Understanding. Use this skill when users need help installing the SDK, configuring Azure resources, deploying required models, configuring appsettings.json, and verifying their setup before running samples.
---

# SDK User Environment Setup for Azure AI Content Understanding (.NET)

Set up your .NET environment to use the Azure AI Content Understanding SDK and run samples. This skill walks you through installing prerequisites, creating/verifying Azure Foundry resources, deploying required models, configuring `appsettings.json`, running a one-time model defaults setup, and verifying everything with a built-in check script.

> **[COPILOT INTERACTION MODEL]:** This skill is designed to be interactive. At each step marked with **[ASK USER]**, pause execution and prompt the user for input or confirmation before proceeding. Do NOT silently skip these prompts. Use the `ask_questions` tool when available.

## Prerequisites

Before starting, ensure you have:

- **.NET 10 SDK** or later installed ([download](https://dotnet.microsoft.com/download))
- An **Azure subscription** ([create one for free](https://azure.microsoft.com/free/))
- A **Microsoft Foundry resource** in a [supported region](https://learn.microsoft.com/azure/ai-services/content-understanding/language-region-support)

> **[ASK USER] Prerequisites Check:**
> Before proceeding, ask the user to confirm their prerequisites:
> 1. "Do you have the **.NET 10 SDK** installed?" — If no, guide them to install it from https://dotnet.microsoft.com/download. Verify with `dotnet --version`.
> 2. "Do you already have a **Microsoft Foundry resource** set up in Azure?" — If no, jump to **Step 5** (Azure Resource Setup) first, then return here.
> 3. "Have you already deployed the required **AI models** (gpt-4.1, gpt-4.1-mini, text-embedding-3-large) in Microsoft Foundry?" — If no, include Step 5.3 and Step 6 in the workflow.

## Package Directory

```
sdk/contentunderstanding/Azure.AI.ContentUnderstanding
```

## Workflow

### Step 1: Navigate to Package Directory

```bash
cd sdk/contentunderstanding/Azure.AI.ContentUnderstanding
```

### Step 2: Determine Platform

> **[ASK USER] Platform:**
> Ask the user: "Which **platform** are you on?" with options:
> - Linux/macOS (use bash commands)
> - Windows PowerShell
>
> Use their answer to show the correct commands throughout the rest of the setup.

### Step 3: Verify .NET SDK and Install the Package

> **[ASK USER] Installation mode:**
> Ask the user: "How would you like to use the SDK?"
> - **Option A: NuGet install (recommended)** — For running samples and building Content Understanding-based solutions. The `cu-sdk-sample-run` skill will add the NuGet package to a generated trial project automatically; no manual install is needed.
> - **Option B: Local source build (for SDK contribution)** — Use this only when you are contributing to the Content Understanding SDK itself.

**Verify the .NET SDK is available:**

```bash
dotnet --version
```

You should see `10.x.x` or later. If not, install the SDK from https://dotnet.microsoft.com/download and re-open your shell.

**Option A: NuGet install (recommended)**

No action needed in this step. When you run a sample via the `cu-sdk-sample-run` skill, it generates a trial `.csproj` that references:

```xml
<PackageReference Include="Azure.AI.ContentUnderstanding" Version="*" />
```

**Option B: Local source build (for SDK contribution)**

```bash
dotnet build
```

The `cu-sdk-sample-run` skill can be pointed at the locally built assembly for contribution scenarios.

> **[ASK USER] Tooling check:**
> After the user runs `dotnet --version`, ask: "Did it print `10.x.x` (or higher)?" If the user reports errors (command not found, older version), help troubleshoot before continuing.

### Step 4: Configure Credentials

The .NET samples read configuration from three sources (in priority order):

1. **Command-line flags** (`--endpoint`, `--api-key`) — only when using `cu-sdk-sample-run`
2. **Environment variables** (`CONTENTUNDERSTANDING_ENDPOINT`, `CONTENTUNDERSTANDING_KEY`)
3. **`appsettings.json`** in the package root directory (recommended for local development)

#### 4.1 Detect Existing Environment Variables and `appsettings.json`

> **[ASK USER] Detect existing state FIRST:**
> Before asking the user to configure anything, detect two things:
>
> **(a) Environment variables** — If `CONTENTUNDERSTANDING_ENDPOINT` or `CONTENTUNDERSTANDING_KEY` is set, it will silently **override** `appsettings.json`. Check both session scope and User/Machine scope on Windows.
>
> **Linux/macOS:**
> ```bash
> echo "CONTENTUNDERSTANDING_ENDPOINT=${CONTENTUNDERSTANDING_ENDPOINT:-(unset)}"
> echo "CONTENTUNDERSTANDING_KEY present=${CONTENTUNDERSTANDING_KEY:+yes}"
> ```
>
> **Windows PowerShell** (also checks persistent User/Machine scope):
> ```powershell
> Write-Host "Session ENDPOINT: '$env:CONTENTUNDERSTANDING_ENDPOINT'"
> Write-Host "Session KEY present: $([bool]$env:CONTENTUNDERSTANDING_KEY)"
> Write-Host "User ENDPOINT: '$([Environment]::GetEnvironmentVariable('CONTENTUNDERSTANDING_ENDPOINT','User'))'"
> Write-Host "Machine ENDPOINT: '$([Environment]::GetEnvironmentVariable('CONTENTUNDERSTANDING_ENDPOINT','Machine'))'"
> ```
>
> If either is set, ask: "Env vars are already set and will override `appsettings.json`. Keep them, or clear?"
> - **Keep env vars** — Skip to Step 5/6/7; `appsettings.json` edits are unnecessary.
> - **Clear and use `appsettings.json`** — Unset them:
>   - Bash: `unset CONTENTUNDERSTANDING_ENDPOINT CONTENTUNDERSTANDING_KEY`
>   - PowerShell (session only): `Remove-Item Env:CONTENTUNDERSTANDING_ENDPOINT, Env:CONTENTUNDERSTANDING_KEY -ErrorAction SilentlyContinue`
>   - PowerShell (User scope persistent): `[Environment]::SetEnvironmentVariable('CONTENTUNDERSTANDING_ENDPOINT',$null,'User'); [Environment]::SetEnvironmentVariable('CONTENTUNDERSTANDING_KEY',$null,'User')`
>
> **(b) Existing `appsettings.json`** — If the file already exists in the package root, do NOT overwrite it silently.
>
> ```bash
> test -f appsettings.json && echo "exists" || echo "absent"
> ```
>
> If it exists, ask: "An `appsettings.json` already exists. **Keep** the existing values, **show** them for review, or **replace** from scratch?"

#### 4.2 Provide Endpoint and Authentication

> **[ASK USER] Authentication method:**
> Ask the user: "How would you like to **authenticate** with Azure?"
> - **Option A: DefaultAzureCredential (recommended)** — Uses `az login` or managed identity. No API key needed.
> - **Option B: API Key** — You'll need your `CONTENTUNDERSTANDING_KEY` from the Azure Portal.

> **[ASK USER] Provide endpoint:**
> Ask the user: "Please provide your **Microsoft Foundry endpoint URL**."
> - It should look like: `https://<your-resource-name>.services.ai.azure.com/`
> - Validate: it should NOT include `api-version` or other query parameters.
> - If the user does not know where to find it: direct them to Azure Portal → Their Foundry resource → Keys and Endpoint.

> **[ASK USER] Provide API key (only if Option B was selected above):**
> Do NOT ask this question if the user selected DefaultAzureCredential.
> If the user chose API Key authentication, ask: "Please provide your **API key** (`CONTENTUNDERSTANDING_KEY`)."
> - Found at: Azure Portal → Your Foundry resource → Keys and Endpoint → Key1 or Key2.
>
> If the user chose DefaultAzureCredential, remind them: "Make sure you have run `az login` to authenticate."

> **[ASK USER] Model deployment names:**
> Ask the user: "Do you want to configure **model deployment names** now? These are needed for `Sample00_UpdateDefaults` (one-time setup)."
> - If yes, ask for each deployment name one by one with sensible defaults:
>   - "What is your **gpt-4.1** deployment name?" (default: `gpt-4.1`)
>   - "What is your **gpt-4.1-mini** deployment name?" (default: `gpt-4.1-mini`)
>   - "What is your **text-embedding-3-large** deployment name?" (default: `text-embedding-3-large`)
> - If no, let them know they can configure these later before running `Sample00_UpdateDefaults`.

#### 4.3 Choose Persistence Method and Validate

> **[ASK USER] Configuration method:**
> Ask the user: "How would you like to persist the endpoint and credentials?"
> - **Option A: appsettings.json (recommended)** — Persisted in a file so you do not need to re-enter values. The file is gitignored.
> - **Option B: Environment variables** — Set in the current shell session.

**Option A: `appsettings.json`**

Create or edit `appsettings.json` in the package root directory (`sdk/contentunderstanding/Azure.AI.ContentUnderstanding/`):

```json
{
  "CONTENTUNDERSTANDING_ENDPOINT": "https://<your-resource-name>.services.ai.azure.com/",
  "CONTENTUNDERSTANDING_KEY": "<your-api-key-if-not-using-DefaultAzureCredential>",
  "GPT_4_1_DEPLOYMENT": "gpt-4.1",
  "GPT_4_1_MINI_DEPLOYMENT": "gpt-4.1-mini",
  "TEXT_EMBEDDING_3_LARGE_DEPLOYMENT": "text-embedding-3-large"
}
```

| Variable | Description |
|----------|-------------|
| `CONTENTUNDERSTANDING_ENDPOINT` | Your Microsoft Foundry endpoint URL |
| `CONTENTUNDERSTANDING_KEY` | API key (omit when using DefaultAzureCredential) |
| `GPT_4_1_DEPLOYMENT` | Your gpt-4.1 deployment name |
| `GPT_4_1_MINI_DEPLOYMENT` | Your gpt-4.1-mini deployment name |
| `TEXT_EMBEDDING_3_LARGE_DEPLOYMENT` | Your text-embedding-3-large deployment name |

**Option B: Environment variables**

**Linux/macOS (bash):**
```bash
export CONTENTUNDERSTANDING_ENDPOINT="https://<your-resource-name>.services.ai.azure.com/"
export CONTENTUNDERSTANDING_KEY="<your-api-key>"  # omit if using DefaultAzureCredential
```

**Windows PowerShell:**
```powershell
$env:CONTENTUNDERSTANDING_ENDPOINT = "https://<your-resource-name>.services.ai.azure.com/"
$env:CONTENTUNDERSTANDING_KEY = "<your-api-key>"  # omit if using DefaultAzureCredential
```

> **[ASK USER] Validate configuration:**
> After the user has provided all values, summarize the configuration and ask them to confirm:
> ```
> Here's your configuration:
>   CONTENTUNDERSTANDING_ENDPOINT = <value>
>   Authentication: DefaultAzureCredential / API Key
>   GPT_4_1_DEPLOYMENT = <value>
>   GPT_4_1_MINI_DEPLOYMENT = <value>
>   TEXT_EMBEDDING_3_LARGE_DEPLOYMENT = <value>
>
> Does this look correct? (Yes / No — let me fix something)
> ```
> Only write to `appsettings.json` after the user confirms. Mask the API key in display.

### Step 5: Azure Resource Setup (if not done)

> **[NOTE]:** Only guide the user through this step if they indicated during the prerequisites check that they do NOT yet have a Microsoft Foundry resource or have not deployed the required models. Otherwise, skip to Step 6.

#### 5.1 Create Microsoft Foundry Resource

1. Go to [Azure Portal](https://portal.azure.com/)
2. Create a **Microsoft Foundry resource** in a [supported region](https://learn.microsoft.com/azure/ai-services/content-understanding/language-region-support)
3. Navigate to **Resource Management** → **Keys and Endpoint**
4. Copy the **Endpoint** URL and optionally a **Key**

> **[ASK USER] Resource created:**
> After guiding the user to create the resource, ask: "Have you created the Microsoft Foundry resource? Please share the **endpoint URL** so we can continue with configuration."

#### 5.2 Grant Cognitive Services User Role

This role is required even if you own the resource:

1. In your Foundry resource, go to **Access Control (IAM)**
2. Click **Add** → **Add role assignment**
3. Select **Cognitive Services User** role
4. Assign it to yourself (or the identity you will use)

> **[ASK USER] Role assigned:**
> Ask: "Have you assigned the **Cognitive Services User** role to yourself? This is required even if you own the resource."

#### 5.3 Deploy Required Models

| Analyzer Type | Required Models |
|--------------|-----------------|
| `prebuilt-documentSearch`, `prebuilt-imageSearch`, `prebuilt-audioSearch`, `prebuilt-videoSearch` | gpt-4.1-mini, text-embedding-3-large |
| Other prebuilt analyzers (invoice, receipt, etc.) | gpt-4.1, text-embedding-3-large |

**To deploy a model:**
1. In Microsoft Foundry → **Deployments** → **Deploy model** → **Deploy base model**
2. Search and deploy: `gpt-4.1`, `gpt-4.1-mini`, `text-embedding-3-large`
3. Note deployment names (recommendation: use model name as deployment name)

> **[ASK USER] Models deployed:**
> Ask: "Have you deployed the required models? Please provide the **deployment names** you used for each:"
> - gpt-4.1 deployment name
> - gpt-4.1-mini deployment name
> - text-embedding-3-large deployment name
>
> Use these names to populate `appsettings.json` in Step 4.

### Step 6: Configure Model Defaults (One-Time Setup)

> **[ASK USER] Run model defaults?:**
> Ask: "Would you like to run `Sample00_UpdateDefaults` now to configure model defaults? This is a **one-time setup** per Microsoft Foundry resource. (Yes / Skip for now)"
> - If yes, ensure deployment-name values are set in `appsettings.json`, then delegate to the `cu-sdk-sample-run` skill.
> - If no, let them know they'll need to run it before using prebuilt analyzers.

Delegate to the `cu-sdk-sample-run` skill to execute the sample:

```bash
# Bash
.github/skills/cu-sdk-sample-run/scripts/run-sample.sh Sample00_UpdateDefaults
```

```powershell
# PowerShell
.github\skills\cu-sdk-sample-run\scripts\run-sample.ps1 Sample00_UpdateDefaults
```

This is a **one-time setup per Microsoft Foundry resource**.

### Step 7: Verify Setup

Run the built-in verification script to confirm everything works end-to-end. It runs 5 checks and reports pass/fail with actionable fix instructions.

| # | Check | What it verifies |
|---|-------|-----------------|
| 1 | **Credentials** | `CONTENTUNDERSTANDING_ENDPOINT` is configured (via `appsettings.json` or env var) |
| 2 | **Authentication** | Can authenticate using `DefaultAzureCredential` or API key |
| 3 | **Endpoint reachable** | `GET /contentunderstanding/defaults` returns HTTP 200 |
| 4 | **Model deployments** | Required models (`gpt-4.1`, `gpt-4.1-mini`, `text-embedding-3-large`) are mapped |
| 5 | **Prebuilt analyzers** | `GET /contentunderstanding/analyzers` succeeds and lists prebuilt analyzers |

> **[ASK USER] Ready to verify:**
> Ask: "Ready to run the verification? (Yes / Not yet)"
> If "Not yet", ask what they still need to configure and help them resolve it.

**Bash (Linux/macOS):**

```bash
.github/skills/cu-sdk-setup/scripts/setup.sh
```

**PowerShell (Windows):**

```powershell
.github\skills\cu-sdk-setup\scripts\setup.ps1
```

**With command-line overrides:**

```bash
.github/skills/cu-sdk-setup/scripts/setup.sh \
  --endpoint "https://<your-resource-name>.services.ai.azure.com/" \
  --api-key "<your-api-key>"
```

**Script options:**

| Option | Description |
|--------|-------------|
| `--help`, `-h` | Show help |
| `--endpoint URL` | Override endpoint (instead of reading from appsettings.json / env) |
| `--api-key KEY` | Override API key |
| `--verbose` | Show full HTTP responses |

> **[ASK USER] Review results:**
> After running the script, present the results to the user and ask:
> - If all checks passed: "All checks passed. Your environment is ready. Would you like to run a sample next using the `cu-sdk-sample-run` skill?"
> - If any checks failed: "Some checks failed. Would you like me to help you fix the issues?" Then walk them through the relevant items in the Troubleshooting section below.

### Step 8: Run Samples

> **[ASK USER] Which samples?:**
> Ask: "Which sample would you like to run first?" with options:
> - `Sample02_AnalyzeUrl` — Analyze content from a URL (recommended start)
> - `Sample01_AnalyzeBinary` — Analyze a local file
> - `Sample03_AnalyzeInvoice` — Extract invoice fields
>
> Then delegate to the `cu-sdk-sample-run` skill to build and run the chosen sample.

## Troubleshooting

Common verification failures and how to fix them:

**Check 1 failure (no endpoint):**
The endpoint is not configured. Set `CONTENTUNDERSTANDING_ENDPOINT` in `appsettings.json` or as an environment variable (see Step 4).

**Check 2 failure (authentication):**
- If using DefaultAzureCredential: run `az login` and try again.
- If using API Key: verify the key is correct in Azure Portal → Your Foundry resource → Keys and Endpoint.
- Also verify the **Cognitive Services User** role is assigned to your identity on the Foundry resource (Step 5.2).

**Check 3 failure (endpoint unreachable):**
- Confirm the URL matches Azure Portal → Keys and Endpoint exactly (no trailing `api-version` or query parameters).
- If HTTP 404: Content Understanding may not be available in your region. See [region support](https://learn.microsoft.com/azure/ai-services/content-understanding/language-region-support).

**Check 4 failure (model deployments):**
- Deploy the required models in Microsoft Foundry (Step 5.3).
- Run `Sample00_UpdateDefaults` via `cu-sdk-sample-run` to map your deployments to the defaults (Step 6).

**Check 5 failure (no analyzers):**
No prebuilt analyzers returned. Re-verify endpoint and region support; then re-run verification.

| Error | Solution |
|-------|----------|
| `dotnet: command not found` | Install .NET 10 SDK from https://dotnet.microsoft.com/download and re-open your shell. |
| `Access denied due to invalid subscription key` | Verify `CONTENTUNDERSTANDING_ENDPOINT` is correct. Check API key or run `az login`. |
| `Model deployment not found` | Deploy required models in Microsoft Foundry. Run `Sample00_UpdateDefaults` via `cu-sdk-sample-run`. |
| `Cognitive Services User role not assigned` | Add the role in Azure Portal → Your resource → Access Control (IAM). |

> **[ASK USER] Re-run verification:**
> After fixing issues, ask: "Would you like to re-run the verification to confirm everything is working now?"

## Related Skills

- `cu-sdk-sample-run` — Build and run individual samples (used by this skill for `Sample00_UpdateDefaults` in Step 6 and any sample in Step 8)
- `cu-sdk-common-knowledge` — Domain knowledge reference for Content Understanding concepts, analyzers, and SDK usage

## Additional Resources

- [SDK README](../../../README.md) - Full documentation
- [Samples directory](../../../samples) - Sample markdown files
- [Product Documentation](https://learn.microsoft.com/azure/ai-services/content-understanding/)
- [Prebuilt Analyzers](https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/prebuilt-analyzers)

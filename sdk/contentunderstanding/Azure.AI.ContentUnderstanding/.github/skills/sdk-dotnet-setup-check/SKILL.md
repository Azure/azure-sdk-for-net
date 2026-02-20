---
name: sdk-dotnet-setup-check
description: Validate your Azure AI Content Understanding environment and diagnose configuration issues — checks credentials, endpoint connectivity, authentication, model deployments, and prebuilt analyzer availability. Run this before using any other skills to ensure your setup is ready.
---

# Setup Check

Validates your Azure AI Content Understanding environment and guides you through fixing any issues.

> **[COPILOT INTERACTION MODEL]:** This skill is designed to be interactive. At each step marked with **[ASK USER]**, pause execution and prompt the user for input or confirmation before proceeding. Do NOT silently skip these prompts. Use the `ask_questions` tool when available.

## What This Skill Does

Runs a checklist against your Microsoft Foundry resource:

| # | Check | What it verifies |
|---|-------|-----------------|
| 1 | **Credentials** | `CONTENTUNDERSTANDING_ENDPOINT` is configured (via `appsettings.json` or env var) |
| 2 | **Authentication** | Can authenticate using `DefaultAzureCredential` or API key |
| 3 | **Endpoint reachable** | `GET /contentunderstanding/defaults` returns HTTP 200 |
| 4 | **Model deployments** | Required models (`gpt-4.1`, `gpt-4.1-mini`, `text-embedding-3-large`) are mapped |
| 5 | **Prebuilt analyzers** | `GET /contentunderstanding/analyzers` succeeds and lists prebuilt analyzers |

Each check reports pass / fail with actionable fix instructions.

## Prerequisites

- .NET SDK (auto-detected from `$HOME/.dotnet` if not on PATH)
- An Azure subscription with a Microsoft Foundry resource
- Credentials:
  - **Recommended:** Run `az login` for `DefaultAzureCredential`
  - **Alternative:** Set `AZURE_CONTENT_UNDERSTANDING_KEY` in `appsettings.json` or env var

> **[ASK USER] Prerequisites Check:**
> Before proceeding, ask the user to confirm their prerequisites:
> 1. "Do you have the **.NET SDK** installed?" — If no, guide them to install it first from https://dotnet.microsoft.com/download.
> 2. "Do you already have a **Microsoft Foundry resource** set up in Azure?" — If no, direct them to create one in a [supported region](https://learn.microsoft.com/azure/ai-services/content-understanding/language-region-support) before continuing.
> 3. "How are you **authenticating**?" with options:
>    - **DefaultAzureCredential (recommended)** — Have they run `az login`?
>    - **API Key** — Do they have `AZURE_CONTENT_UNDERSTANDING_KEY` ready?

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
> Use their answer to show the correct script command in Step 3.

### Step 3: Configure Endpoint and Credentials

The setup check script reads configuration from three sources (in priority order):

1. **Command-line flags** (`--endpoint`, `--api-key`)
2. **Environment variables** (`CONTENTUNDERSTANDING_ENDPOINT`, `AZURE_CONTENT_UNDERSTANDING_KEY`)
3. **`appsettings.json`** in the package root directory

> **[ASK USER] Provide endpoint:**
> Ask the user: "Please provide your **Microsoft Foundry endpoint URL**."
> - It should look like: `https://<your-resource-name>.services.ai.azure.com/`
> - It should NOT include `api-version` or other query parameters.
> - If the user does not know where to find it: direct them to Azure Portal → Their Foundry resource → Keys and Endpoint.

> **[ASK USER] Provide API key (if applicable):**
> If the user chose API Key authentication in the prerequisites check, ask: "Please provide your **API key** (`AZURE_CONTENT_UNDERSTANDING_KEY`)."
> - Found at: Azure Portal → Your Foundry resource → Keys and Endpoint → Key1 or Key2.
>
> If the user chose DefaultAzureCredential, remind them: "Make sure you have run `az login` to authenticate."

> **[ASK USER] Configuration method:**
> Ask the user: "How would you like to provide the endpoint and credentials?"
> - **Option A: appsettings.json (recommended)** — Persisted in a file so you do not need to re-enter values.
> - **Option B: Environment variables** — Set in the current shell session.
> - **Option C: Command-line flags** — Pass directly when running the script (one-time use).

**Option A: appsettings.json**

Create or edit `appsettings.json` in the package root directory:

```json
{
  "CONTENTUNDERSTANDING_ENDPOINT": "https://<your-resource-name>.services.ai.azure.com/",
  "AZURE_CONTENT_UNDERSTANDING_KEY": "<your-api-key-if-not-using-DefaultAzureCredential>"
}
```

> **[ASK USER] Confirm appsettings.json:**
> After writing the file, ask: "I have created/updated `appsettings.json` with your endpoint and credentials. Does this look correct?"
> Display the values (masking the API key) and wait for confirmation before proceeding.

**Option B: Environment variables**

```bash
export CONTENTUNDERSTANDING_ENDPOINT="https://<your-resource-name>.services.ai.azure.com/"
export AZURE_CONTENT_UNDERSTANDING_KEY="<your-api-key>"  # omit if using DefaultAzureCredential
```

**Option C: Command-line flags**

Pass `--endpoint` and optionally `--api-key` when running the script (shown in Step 4).

### Step 4: Run the Setup Check

> **[ASK USER] Ready to run:**
> Ask the user: "Ready to run the setup check? This will verify your endpoint, authentication, model deployments, and prebuilt analyzers. (Yes / Not yet)"
> If "Not yet", ask what they still need to configure and help them resolve it.

**Bash (Linux/macOS):**

```bash
.github/skills/sdk-dotnet-setup-check/scripts/setup-check.sh
```

**PowerShell (Windows):**

```powershell
.github\skills\sdk-dotnet-setup-check\scripts\setup-check.ps1
```

**With command-line overrides:**

```bash
.github/skills/sdk-dotnet-setup-check/scripts/setup-check.sh \
  --endpoint "https://<your-resource-name>.services.ai.azure.com/" \
  --api-key "<your-api-key>"
```

### Options

| Option | Description |
|--------|-------------|
| `--help`, `-h` | Show help |
| `--endpoint URL` | Override endpoint (instead of reading from appsettings.json / env) |
| `--api-key KEY` | Override API key |
| `--verbose` | Show full HTTP responses |

### Step 5: Review Results

> **[ASK USER] Review results:**
> After running the script, present the results to the user and ask:
> - If all checks passed: "All checks passed. Your environment is ready. Would you like to run a sample next using the `sdk-dotnet-sample-run` skill?"
> - If any checks failed: "Some checks failed. Would you like me to help you fix the issues?" Then guide them through the relevant troubleshooting steps below based on which checks failed.

#### Handling Failures

> **[ASK USER] Fix failures interactively:**
> For each failed check, walk the user through the fix:
>
> **Check 1 failure (no endpoint):**
> Ask: "It looks like the endpoint is not configured. Can you provide your **Microsoft Foundry endpoint URL**?"
> Then help them set it in appsettings.json or as an environment variable.
>
> **Check 2 failure (authentication):**
> Ask: "Authentication failed. Which method are you using?"
> - If DefaultAzureCredential: "Please run `az login` and try again."
> - If API Key: "Please verify your API key is correct. You can find it in Azure Portal → Your Foundry resource → Keys and Endpoint."
> - Also check: "Have you assigned the **Cognitive Services User** role to yourself on the Foundry resource?"
>
> **Check 3 failure (endpoint unreachable):**
> Ask: "The endpoint could not be reached. Can you confirm the URL is correct? It should match what is shown in Azure Portal → Keys and Endpoint."
> If 404: "Content Understanding may not be available in your region. See [region support](https://learn.microsoft.com/azure/ai-services/content-understanding/language-region-support)."
>
> **Check 4 failure (model deployments):**
> Ask: "Model deployments are not configured. Have you deployed the required models (gpt-4.1, gpt-4.1-mini, text-embedding-3-large) in Microsoft Foundry?"
> - If no: Guide them to deploy models in Microsoft Foundry → Deployments → Deploy model → Deploy base model.
> - If yes: "Would you like to run `Sample00_UpdateDefaults` to configure the default model mappings?"
>   Then use the `sdk-dotnet-sample-run` skill to run it:
>   `.github/skills/sdk-dotnet-sample-run/scripts/run-sample.sh Sample00_UpdateDefaults`
>
> **Check 5 failure (no analyzers):**
> Ask: "No prebuilt analyzers were found. This may indicate a service issue or incorrect endpoint/region. Would you like to re-check your endpoint configuration?"

> **[ASK USER] Re-run check:**
> After fixing issues, ask: "Would you like to re-run the setup check to verify everything is working now?"
> If yes, run the script again.

## Example Output

```
=== Azure AI Content Understanding — Setup Check ===

[1/5] Credentials
  PASS  Endpoint: https://my-foundry.services.ai.azure.com/
  PASS  Auth method: DefaultAzureCredential

[2/5] Endpoint reachable
  PASS  GET /contentunderstanding/defaults → 200 OK (238ms)

[3/5] Model deployments
  PASS  gpt-4.1 → gpt-4.1
  PASS  gpt-4.1-mini → gpt-4.1-mini
  PASS  text-embedding-3-large → text-embedding-3-large

[4/5] Prebuilt analyzers
  PASS  14 analyzers found (prebuilt-documentSearch, prebuilt-invoice, ...)

[5/5] Quick smoke test
  PASS  prebuilt-read analyzer exists

Result: 5/5 checks passed
Your environment is ready!
```

### Failure example

```
[3/5] Model deployments
  FAIL  No model deployments configured!
    Fix: Run Sample00_UpdateDefaults to configure model mappings:
      .github/skills/sdk-dotnet-sample-run/scripts/run-sample.sh Sample00_UpdateDefaults
```

## Troubleshooting

| Symptom | Likely cause | Fix |
|---------|-------------|-----|
| Check 1 fails — no endpoint | Missing config | Create `appsettings.json` with `CONTENTUNDERSTANDING_ENDPOINT` or export the env var |
| Check 2 fails — 401 / 403 | Bad credentials | Run `az login`, or verify API key, or assign **Cognitive Services User** role |
| Check 3 fails — connection refused | Wrong endpoint URL | Verify the endpoint matches your Foundry resource (Azure Portal → Keys and Endpoint) |
| Check 3 fails — 404 | Wrong region | Content Understanding not available in this region — see [region support](https://learn.microsoft.com/azure/ai-services/content-understanding/language-region-support) |
| Check 4 fails — empty deployments | Models not mapped | Run `Sample00_UpdateDefaults` to configure default model mappings |
| Check 4 fails — missing model | Model not deployed | Deploy the missing model in Microsoft Foundry portal → Deployments |
| Check 5 fails — no analyzers | Service issue | Check Azure service status or re-check endpoint/region |

## Cross-Language Reference

| Language | Setup check command |
|----------|-------------------|
| .NET | `.github/skills/sdk-dotnet-setup-check/scripts/setup-check.sh` |
| Python | `.github/skills/sdk-py-setup-check/scripts/setup-check.sh` (if available) |

## Related Skills

- `sdk-dotnet-sample-run` — Run individual samples (includes Sample00 for model deployment setup)

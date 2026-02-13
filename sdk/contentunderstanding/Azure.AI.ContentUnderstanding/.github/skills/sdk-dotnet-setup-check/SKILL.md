---
name: sdk-dotnet-setup-check
description: Validate Azure AI Content Understanding setup — checks endpoint connectivity, authentication, model deployments, and default model mappings. Run this before using prebuilt analyzers or custom analyzers to quickly diagnose configuration issues.
---

# Setup Check

Validates your Azure AI Content Understanding environment in one command.

## What This Skill Does

Runs a checklist against your Microsoft Foundry resource:

| # | Check | What it verifies |
|---|-------|-----------------|
| 1 | **Credentials** | `CONTENTUNDERSTANDING_ENDPOINT` is configured (via `appsettings.json` or env var) |
| 2 | **Authentication** | Can authenticate using `DefaultAzureCredential` or API key |
| 3 | **Endpoint reachable** | `GET /contentunderstanding/defaults` returns HTTP 200 |
| 4 | **Model deployments** | Required models (`gpt-4.1`, `gpt-4.1-mini`, `text-embedding-3-large`) are mapped |
| 5 | **Prebuilt analyzers** | `GET /contentunderstanding/analyzers` succeeds and lists prebuilt analyzers |

Each check reports ✓ pass / ✗ fail with actionable fix instructions.

## Prerequisites

- .NET SDK (auto-detected from `$HOME/.dotnet` if not on PATH)
- An Azure subscription with a Microsoft Foundry resource
- Credentials:
  - **Recommended:** Run `az login` for `DefaultAzureCredential`
  - **Alternative:** Set `CONTENTUNDERSTANDING_API_KEY` in `appsettings.json` or env var

## Usage

### Bash (Linux/macOS)

```bash
cd sdk/contentunderstanding/Azure.AI.ContentUnderstanding
.github/skills/sdk-dotnet-setup-check/scripts/setup-check.sh
```

### PowerShell (Windows)

```powershell
cd sdk\contentunderstanding\Azure.AI.ContentUnderstanding
.github\skills\sdk-dotnet-setup-check\scripts\setup-check.ps1
```

### Options

| Option | Description |
|--------|-------------|
| `--help`, `-h` | Show help |
| `--endpoint URL` | Override endpoint (instead of reading from appsettings.json / env) |
| `--api-key KEY` | Override API key |
| `--verbose` | Show full HTTP responses |

## Configuration

The skill reads from the same sources as `sdk-dotnet-sample-run`:

1. **`appsettings.json`** in the package root directory
2. **Environment variables** (`CONTENTUNDERSTANDING_ENDPOINT`, `CONTENTUNDERSTANDING_API_KEY`)
3. **Command-line flags** (`--endpoint`, `--api-key`)

Priority: command-line > environment variables > appsettings.json

## Example Output

```
=== Azure AI Content Understanding — Setup Check ===

[1/5] Credentials
  ✓ Endpoint: https://my-foundry.services.ai.azure.com/
  ✓ Auth method: DefaultAzureCredential

[2/5] Endpoint reachable
  ✓ GET /contentunderstanding/defaults → 200 OK (238ms)

[3/5] Model deployments
  ✓ gpt-4.1 → gpt-4.1
  ✓ gpt-4.1-mini → gpt-4.1-mini
  ✓ text-embedding-3-large → text-embedding-3-large

[4/5] Prebuilt analyzers
  ✓ 14 analyzers found (prebuilt-documentSearch, prebuilt-invoice, ...)

[5/5] Quick smoke test
  ✓ prebuilt-read analyzer exists

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
Result: 5/5 checks passed ✓
Your environment is ready!
```

### Failure example

```
[3/5] Model deployments
  ✗ No model deployments configured!
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
- `sdkinternal-dotnet-test-run` — Run SDK tests (internal, for SDK contributors)

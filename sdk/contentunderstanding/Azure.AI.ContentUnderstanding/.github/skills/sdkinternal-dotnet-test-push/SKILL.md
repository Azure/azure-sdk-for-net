```skill
---
name: sdkinternal-dotnet-test-push
description: Push test session recordings to Azure SDK Assets repository, with optional record-and-push workflow. Push recordings only, or run a complete workflow that records tests against live services, pushes recordings, and verifies with playback. Combines push-recordings and record-push workflow into a single skill.
---

# SDK Test Push

This skill pushes test session recordings to the Azure SDK Assets repository. It can also run a complete record-then-push workflow.

## What This Skill Does

### Push Only (default)
1. Validates local recordings and `assets.json` exist
2. Pushes recordings to Azure SDK Assets repo via `test-proxy`
3. Updates `assets.json` with new recording tag
4. Verifies push was successful

### Full Workflow (`--workflow`)
1. **Setup**: Load environment variables from `.env`
2. **Compile**: Build SDK to ensure no compilation errors
3. **Record**: Run tests in RECORD mode against live Azure services
4. **Push**: Push new recordings to Azure SDK Assets repo
5. **Verify**: Run tests in PLAYBACK mode to confirm recordings work

## Pre-requisites

- [ ] `assets.json` file present in module directory
- [ ] Git credentials configured for Azure/azure-sdk-assets
- [ ] `test-proxy` or `Azure.Sdk.Tools.TestProxy` command available
  - Install: `pwsh eng/common/testproxy/install-test-proxy.ps1 -Version <version> -InstallDirectory <dir>`
  - Version in: `eng/common/testproxy/target_version.txt`
- [ ] For workflow: Azure credentials configured, live service access

## Usage

### Bash (Linux/macOS)

```bash
cd sdk/contentunderstanding/Azure.AI.ContentUnderstanding

# Push recordings only (after recording separately)
.github/skills/sdkinternal-dotnet-test-push/scripts/test-push.sh

# Dry run — preview what would be pushed
.github/skills/sdkinternal-dotnet-test-push/scripts/test-push.sh --dry-run

# Full workflow: record → push → verify
.github/skills/sdkinternal-dotnet-test-push/scripts/test-push.sh --workflow

# Workflow with options
.github/skills/sdkinternal-dotnet-test-push/scripts/test-push.sh --workflow --skip-compile --filter "Sample01"

# Workflow without playback verification
.github/skills/sdkinternal-dotnet-test-push/scripts/test-push.sh --workflow --skip-verify
```

### PowerShell (Windows)

```powershell
cd sdk\contentunderstanding\Azure.AI.ContentUnderstanding

# Push recordings only
.github\skills\sdkinternal-dotnet-test-push\scripts\test-push.ps1

# Dry run
.github\skills\sdkinternal-dotnet-test-push\scripts\test-push.ps1 -DryRun

# Full workflow: record → push → verify
.github\skills\sdkinternal-dotnet-test-push\scripts\test-push.ps1 -Workflow

# Workflow with options
.github\skills\sdkinternal-dotnet-test-push\scripts\test-push.ps1 -Workflow -SkipCompile -Filter "Sample01"
```

## Options

| Option | Bash | PowerShell | Description |
|--------|------|------------|-------------|
| Dry Run | `--dry-run` | `-DryRun` | Preview without pushing |
| Workflow | `--workflow` | `-Workflow` | Run full record → push → verify workflow |
| Skip Compile | `--skip-compile` | `-SkipCompile` | Skip compilation step (workflow) |
| Skip Verify | `--skip-verify` | `-SkipVerify` | Skip playback verification (workflow) |
| Filter | `-f "TestName"` | `-Filter "TestName"` | Filter tests by name (workflow) |
| Framework | `--framework net8.0` | `-Framework net8.0` | Target framework (default: net10.0) |

## Workflow Steps Detail

### Step 1: Setup Environment
Loads environment variables from `.env` file via `load-env.sh`/`load-env.ps1`.

### Step 2: Compile SDK
Builds the SDK to catch compilation errors early. Skip with `--skip-compile`.

### Step 3: Record Tests
Sets `AZURE_TEST_MODE=Record` and runs tests against live Azure services to capture HTTP sessions.

### Step 4: Push Recordings
Pushes captured recordings to `Azure/azure-sdk-assets` via `test-proxy push`.

### Step 5: Verify Playback
Sets `AZURE_TEST_MODE=Playback` and reruns tests to confirm recordings work. Skip with `--skip-verify`.

## Important Notes

### Git Credentials Required

Push requires write access to `Azure/azure-sdk-assets` repository.

### After Pushing

Don't forget to:
1. Review the updated `assets.json`
2. Commit your changes (including `assets.json`)
3. Create a pull request

### Assets Repository

Recordings are stored in: `https://github.com/Azure/azure-sdk-assets`

## Cross-Language Command

All languages use the same test-proxy command:

```bash
# Binary may be named test-proxy or Azure.Sdk.Tools.TestProxy
test-proxy push -a assets.json
```

### Installing test-proxy

```powershell
# Read version from repo
$version = Get-Content eng/common/testproxy/target_version.txt

# Install standalone binary
./eng/common/testproxy/install-test-proxy.ps1 -Version $version -InstallDirectory /tmp/test-proxy

# Add to PATH (the binary is named Azure.Sdk.Tools.TestProxy)
export PATH="/tmp/test-proxy:$PATH"
```
```

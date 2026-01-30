---
name: sdkinternal-dotnet-workflow-record-push
description: Complete workflow to record tests and push recordings to Azure SDK Assets. Combines setup environment, compile SDK, run tests in RECORD mode, push recordings to assets repo, and verify with PLAYBACK mode. Requires Azure credentials and git push access.
---

# SDK Workflow: Record and Push

This workflow skill combines recording tests and pushing to the Azure SDK Assets repository.

## What This Workflow Does

1. **Setup**: Load environment variables from `.env`
2. **Compile**: Build SDK to ensure no compilation errors
3. **Record**: Run tests in RECORD mode against live Azure services
4. **Push**: Push new recordings to Azure SDK Assets repo
5. **Verify**: Run tests in PLAYBACK mode to confirm recordings work

## Pre-requisites

- [ ] `.env` file configured with Azure credentials
- [ ] Git credentials for Azure/azure-sdk-assets
- [ ] Live Azure service access
- [ ] `test-proxy` tool installed

## Usage

### PowerShell (Windows)

```powershell
cd sdk\contentunderstanding\Azure.AI.ContentUnderstanding

# Run complete workflow
.github\skills\sdk-workflow-record-push\scripts\run-workflow.ps1
```

### Bash (Linux/macOS)

```bash
cd sdk/contentunderstanding/Azure.AI.ContentUnderstanding

# Run complete workflow
.github/skills/sdk-workflow-record-push/scripts/run-workflow.sh
```

## Options

### Skip Steps

```powershell
# Skip compilation (if already built)
.github\skills\sdk-workflow-record-push\scripts\run-workflow.ps1 -SkipCompile

# Skip playback verification
.github\skills\sdk-workflow-record-push\scripts\run-workflow.ps1 -SkipVerify
```

### Filter Tests

```powershell
# Only record specific tests
.github\skills\sdk-workflow-record-push\scripts\run-workflow.ps1 -Filter "Sample01"
```

## Workflow Steps Detail

### Step 1: Setup Environment
```powershell
. .github\skills\sdk-setup-env\scripts\load-env.ps1
```

### Step 2: Compile SDK
```powershell
.github\skills\sdk-compile\scripts\compile.ps1
```

### Step 3: Record Tests
```powershell
$env:AZURE_TEST_MODE = "Record"
dotnet test -f net462
```

### Step 4: Push Recordings
```powershell
test-proxy push -a assets.json
```

### Step 5: Verify Playback
```powershell
$env:AZURE_TEST_MODE = "Playback"
dotnet test -f net462
```

## 🔄 After Workflow

Don't forget to:
1. Commit the updated `assets.json`
2. Create a pull request with your changes

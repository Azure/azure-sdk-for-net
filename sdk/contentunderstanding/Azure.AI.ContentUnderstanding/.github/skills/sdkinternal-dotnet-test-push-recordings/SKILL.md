---
name: sdkinternal-dotnet-test-push-recordings
description: Push test session recordings to Azure SDK Assets repository. Push newly recorded test sessions to the assets repo, update assets.json with new recording tag, and verify recordings before pushing. Requires git credentials with push access to Azure/azure-sdk-assets.
---

# SDK Push Recordings

This skill pushes test session recordings to the Azure SDK Assets repository.

## 🎯 What This Skill Does

1. Validates local recordings exist
2. Pushes recordings to Azure SDK Assets repo
3. Updates `assets.json` with new recording tag
4. Verifies push was successful

## 📋 Pre-requisites

- [ ] Test recordings generated (via `sdk-test-record`)
- [ ] `assets.json` file present in module directory
- [ ] Git credentials configured for Azure/azure-sdk-assets
- [ ] `test-proxy` command available

## 🔧 Usage

### PowerShell (Windows)

```powershell
cd sdk\contentunderstanding\Azure.AI.ContentUnderstanding

# Push recordings to assets repo
.github\skills\sdk-push-recordings\scripts\push-recordings.ps1
```

### Bash (Linux/macOS)

```bash
cd sdk/contentunderstanding/Azure.AI.ContentUnderstanding

# Push recordings to assets repo
.github/skills/sdk-push-recordings/scripts/push-recordings.sh
```

## 📦 Options

### Dry Run (Preview)

```powershell
# Preview what would be pushed without actually pushing
.github\skills\sdk-push-recordings\scripts\push-recordings.ps1 -DryRun
```

## ⚠️ Important Notes

### Git Credentials Required

Push requires write access to `Azure/azure-sdk-assets` repository.

### Recording Workflow

1. Run tests in RECORD mode (`sdk-test-record`)
2. Verify tests pass in PLAYBACK mode (`sdk-test-playback`)
3. Push recordings (`sdk-push-recordings`)
4. Commit updated `assets.json`

### Assets Repository

Recordings are stored in: `https://github.com/Azure/azure-sdk-assets`

## 🌐 Cross-Language Command

All languages use the same test-proxy command:

```bash
test-proxy push -a assets.json
```

---
name: sdkinternal-dotnet-test-playback
description: Run Azure SDK tests in PLAYBACK mode using recorded API responses. Run tests without live Azure service access, validate SDK functionality using recorded sessions, and execute tests in CI/CD pipelines. No Azure credentials required.
---

# SDK Test Playback

This skill runs Azure SDK tests in PLAYBACK mode using previously recorded API responses.

## What This Skill Does

1. Sets `AZURE_TEST_MODE=Playback` environment variable
2. Restores session recordings from assets repo
3. Runs tests using recorded HTTP responses
4. Validates SDK behavior without live Azure access

## Pre-requisites

- [ ] Session recordings available (via `test-proxy restore`)
- [ ] `assets.json` file present in module directory
- [ ] Test proxy installed (`test-proxy` command available)

## Usage

### PowerShell (Windows)

```powershell
cd sdk\contentunderstanding\Azure.AI.ContentUnderstanding

# Run tests in PLAYBACK mode
.github\skills\sdk-test-playback\scripts\test-playback.ps1
```

### Bash (Linux/macOS)

```bash
cd sdk/contentunderstanding/Azure.AI.ContentUnderstanding

# Run tests in PLAYBACK mode
.github/skills/sdk-test-playback/scripts/test-playback.sh
```

## Test Options

### Run Specific Test

```powershell
# Filter by test name
.github\skills\sdk-test-playback\scripts\test-playback.ps1 -Filter "AnalyzeBinaryAsync"
```

### Target Framework

```powershell
# Use specific framework (default: net462)
.github\skills\sdk-test-playback\scripts\test-playback.ps1 -Framework net8.0
```

## Important Notes

### No Azure Credentials Required

PLAYBACK mode uses recorded responses - no live Azure access needed.

### Restore Recordings First

If recordings are missing:
```powershell
test-proxy restore -a assets.json
```

### Recording Mismatch

If tests fail due to API changes, re-record with `sdk-test-record`.

## Cross-Language Test Mode

| Language | Environment Variable | Command Flag |
|----------|---------------------|--------------|
| .NET | `AZURE_TEST_MODE=Playback` | Environment variable |
| Java | `AZURE_TEST_MODE=PLAYBACK` | `-DAZURE_TEST_MODE=PLAYBACK` |
| Python | `AZURE_TEST_MODE=PLAYBACK` | `--azure-test-mode=playback` |
| JavaScript | `AZURE_TEST_MODE=playback` | `--test-mode=playback` |

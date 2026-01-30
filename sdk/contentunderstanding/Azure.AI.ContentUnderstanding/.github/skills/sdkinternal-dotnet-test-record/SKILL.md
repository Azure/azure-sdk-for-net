---
name: sdkinternal-dotnet-test-record
description: Run Azure SDK tests in RECORD mode to capture live API responses. Records new test sessions with live Azure services, updates existing recordings when APIs change, and generates session record files for playback testing. Requires Azure credentials and live service access.
---

# SDK Test Record

This skill runs Azure SDK tests in RECORD mode to capture live API responses for playback testing.

## What This Skill Does

1. Sets `AZURE_TEST_MODE=Record` environment variable
2. Runs tests against live Azure services
3. Captures HTTP request/response pairs via test-proxy
4. Saves session records to `.assets` directory

## Pre-requisites

- [ ] Azure credentials configured (via `.env` or environment)
- [ ] Test proxy installed (`test-proxy` command available)
- [ ] `assets.json` file present in module directory
- [ ] Live Azure service endpoint accessible
- [ ] Environment variables loaded (`sdk-setup-env`)

## Usage

### PowerShell (Windows)

```powershell
cd sdk\contentunderstanding\Azure.AI.ContentUnderstanding

# Load environment first
. .github\skills\sdk-setup-env\scripts\load-env.ps1

# Run tests in RECORD mode
.github\skills\sdk-test-record\scripts\test-record.ps1
```

### Bash (Linux/macOS)

```bash
cd sdk/contentunderstanding/Azure.AI.ContentUnderstanding

# Load environment first
source .github/skills/sdk-setup-env/scripts/load-env.sh

# Run tests in RECORD mode
.github/skills/sdk-test-record/scripts/test-record.sh
```

## Test Options

### Run Specific Test

```powershell
# Filter by test name
.github\skills\sdk-test-record\scripts\test-record.ps1 -Filter "AnalyzeBinaryAsync"
```

### Target Framework

```powershell
# Use specific framework (default: net462)
.github\skills\sdk-test-record\scripts\test-record.ps1 -Framework net8.0
```

## Important Notes

### Recording Requirements

- Valid `CONTENTUNDERSTANDING_ENDPOINT` environment variable
- Azure credentials (CLI auth or service principal)
- Network access to Azure services

### Session Records Location

Records are stored via test-proxy in `.assets` directory, referenced by `assets.json`.

### After Recording

Push recordings to assets repo:
```powershell
test-proxy push -a assets.json
```

## Cross-Language Test Mode

| Language | Environment Variable | Command Flag |
|----------|---------------------|--------------|
| .NET | `AZURE_TEST_MODE=Record` | Environment variable |
| Java | `AZURE_TEST_MODE=RECORD` | `-DAZURE_TEST_MODE=RECORD` |
| Python | `AZURE_TEST_MODE=RECORD` | `--azure-test-mode=record` |
| JavaScript | `AZURE_TEST_MODE=record` | `--test-mode=record` |

---
name: sdkinternal-dotnet-sample-run-all-samples
description: Run all Azure SDK samples to verify complete functionality. Execute all sample files at once, validate SDK features comprehensively, and generate sample execution report. Samples run in PLAYBACK mode by default. Set AZURE_TEST_MODE=Live to run against live services.
---

# SDK Run All Samples

This skill runs all Azure SDK samples to verify complete functionality.

## What This Skill Does

1. Discovers all sample files in the tests/samples directory
2. Sets up test environment (PLAYBACK mode by default)
3. Executes all samples sequentially
4. Reports overall results with summary

## Pre-requisites

- [ ] SDK compiled successfully (`sdk-compile`)
- [ ] Sample files exist in `tests/samples/` directory
- [ ] For LIVE mode: Azure credentials configured

## Usage

### PowerShell (Windows)

```powershell
cd sdk\contentunderstanding\Azure.AI.ContentUnderstanding

# Run all samples
.github\skills\sdk-run-all-samples\scripts\run-all-samples.ps1
```

### Bash (Linux/macOS)

```bash
cd sdk/contentunderstanding/Azure.AI.ContentUnderstanding

# Run all samples
.github/skills/sdk-run-all-samples/scripts/run-all-samples.sh
```

## Options

### Run in Live Mode

```powershell
# Requires Azure credentials
.github\skills\sdk-run-all-samples\scripts\run-all-samples.ps1 -Live
```

### Continue on Failure

```powershell
# Don't stop if one sample fails
.github\skills\sdk-run-all-samples\scripts\run-all-samples.ps1 -ContinueOnError
```

## Important Notes

### Execution Order

Samples are executed in filename order (Sample01, Sample02, etc.).

### PLAYBACK vs LIVE Mode

- **PLAYBACK** (default): Uses recorded responses, no Azure access needed
- **LIVE**: Requires Azure credentials and service access

### Performance

Running all samples may take several minutes depending on the number of samples.

## Cross-Language Sample Patterns

| Language | Run All Command |
|----------|----------------|
| .NET | `dotnet test --filter "Sample"` |
| Java | `mvn test -Dtest=*Sample*` |
| Python | `pytest samples/` |
| JavaScript | `npm run samples` |

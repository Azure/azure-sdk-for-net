---
name: sdkinternal-dotnet-sample-run
description: Run a single Azure SDK sample to verify functionality. Execute individual sample files, test SDK features in isolation, and debug sample code. Samples run in PLAYBACK mode by default. Set AZURE_TEST_MODE=Live to run against live services.
---

# SDK Run Sample

This skill runs a single Azure SDK sample to verify functionality.

## 🎯 What This Skill Does

1. Locates the specified sample file
2. Sets up test environment (PLAYBACK mode by default)
3. Executes the sample as a test
4. Reports results with output

## 📋 Pre-requisites

- [ ] SDK compiled successfully (`sdk-compile`)
- [ ] Sample file exists in `tests/samples/` directory
- [ ] For LIVE mode: Azure credentials configured

## 🔧 Usage

### PowerShell (Windows)

```powershell
cd sdk\contentunderstanding\Azure.AI.ContentUnderstanding

# Run specific sample
.github\skills\sdk-run-sample\scripts\run-sample.ps1 -SampleName "Sample01_AnalyzeBinary"
```

### Bash (Linux/macOS)

```bash
cd sdk/contentunderstanding/Azure.AI.ContentUnderstanding

# Run specific sample
.github/skills/sdk-run-sample/scripts/run-sample.sh -s "Sample01_AnalyzeBinary"
```

## 📦 Options

### Run in Live Mode

```powershell
# Requires Azure credentials
.github\skills\sdk-run-sample\scripts\run-sample.ps1 -SampleName "Sample01_AnalyzeBinary" -Live
```

### List Available Samples

```powershell
.github\skills\sdk-run-sample\scripts\run-sample.ps1 -List
```

## ⚠️ Important Notes

### Sample Location

Samples are located in `tests/samples/` directory as recorded tests.

### PLAYBACK vs LIVE Mode

- **PLAYBACK** (default): Uses recorded responses, no Azure access needed
- **LIVE**: Requires Azure credentials and service access

### Sample Naming

Samples follow the pattern: `Sample{NN}_{Description}.cs`
- Example: `Sample01_AnalyzeBinary.cs`

## 🌐 Cross-Language Sample Patterns

| Language | Sample Location | Run Command |
|----------|----------------|-------------|
| .NET | `tests/samples/` | `dotnet test --filter` |
| Java | `src/samples/` | `mvn exec:java` |
| Python | `samples/` | `python sample.py` |
| JavaScript | `samples/` | `node sample.js` |

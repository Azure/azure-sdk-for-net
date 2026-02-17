---
name: sdkinternal-dotnet-test-run
description: Unified Azure SDK test runner. Run tests in different modes (Playback/Record/Live), run samples (single or all), and collect code coverage. Combines playback testing, record testing, live testing, sample execution, and coverage collection into a single skill.
---

# SDK Test Run

This skill is a unified test runner for Azure SDK tests. It supports multiple test modes, sample execution, and code coverage collection.

## What This Skill Does

1. Runs tests in **Playback** mode (default) — no Azure credentials needed
2. Runs tests in **Record** mode — captures live API responses for playback
3. Runs tests in **Live** mode — runs directly against Azure services
4. Runs a **single sample** by name
5. Runs **all samples** at once
6. Collects **code coverage** with Coverlet and generates reports

## Pre-requisites

- [ ] SDK compiled successfully (`sdk-compile`)
- [ ] For Playback: Session recordings available (via `test-proxy restore`)
- [ ] For Record/Live: Azure credentials configured, `.env` loaded, `CONTENTUNDERSTANDING_ENDPOINT` set
- [ ] For Coverage: Coverlet package referenced (auto-added by Azure SDK build system)

## Important: dotnet PATH

The scripts auto-detect `dotnet` at `$HOME/.dotnet/dotnet` if not on PATH. If dotnet is installed elsewhere, add it to PATH before running.

## Usage

### Bash (Linux/macOS)

```bash
cd sdk/contentunderstanding/Azure.AI.ContentUnderstanding

# Run tests in PLAYBACK mode (default)
.github/skills/sdkinternal-dotnet-test-run/scripts/test-run.sh

# Run tests in RECORD mode
.github/skills/sdkinternal-dotnet-test-run/scripts/test-run.sh --mode record

# Run tests in LIVE mode
.github/skills/sdkinternal-dotnet-test-run/scripts/test-run.sh --mode live

# Run a single sample
.github/skills/sdkinternal-dotnet-test-run/scripts/test-run.sh --sample "AnalyzeBinaryAsync"

# Run all samples
.github/skills/sdkinternal-dotnet-test-run/scripts/test-run.sh --samples

# Run tests with code coverage
.github/skills/sdkinternal-dotnet-test-run/scripts/test-run.sh --coverage

# List available samples
.github/skills/sdkinternal-dotnet-test-run/scripts/test-run.sh --list-samples
```

### PowerShell (Windows)

```powershell
cd sdk\contentunderstanding\Azure.AI.ContentUnderstanding

# Run tests in PLAYBACK mode (default)
.github\skills\sdkinternal-dotnet-test-run\scripts\test-run.ps1

# Run tests in RECORD mode
.github\skills\sdkinternal-dotnet-test-run\scripts\test-run.ps1 -Mode Record

# Run tests in LIVE mode
.github\skills\sdkinternal-dotnet-test-run\scripts\test-run.ps1 -Mode Live

# Run a single sample
.github\skills\sdkinternal-dotnet-test-run\scripts\test-run.ps1 -Sample "AnalyzeBinaryAsync"

# Run all samples
.github\skills\sdkinternal-dotnet-test-run\scripts\test-run.ps1 -Samples

# Run tests with code coverage
.github\skills\sdkinternal-dotnet-test-run\scripts\test-run.ps1 -Coverage

# List available samples
.github\skills\sdkinternal-dotnet-test-run\scripts\test-run.ps1 -ListSamples
```

## Options

| Option | Bash | PowerShell | Description |
|--------|------|------------|-------------|
| Mode | `--mode playback\|record\|live` | `-Mode Playback\|Record\|Live` | Test mode (default: Playback) |
| Filter | `-f "TestName"` | `-Filter "TestName"` | Filter tests by name |
| Sample | `--sample "Name"` | `-Sample "Name"` | Run a single sample by name |
| All Samples | `--samples` | `-Samples` | Run all samples |
| List Samples | `--list-samples` | `-ListSamples` | List available sample methods |
| Coverage | `--coverage` | `-Coverage` | Collect code coverage (Playback mode) |
| Custom Only | `--custom-only` | `-CustomCodeOnly` | Show coverage for custom code only |
| Report Only | `--report-only` | `-ReportOnly` | Only generate HTML coverage report |
| Framework | `-t net8.0` | `-Framework net8.0` | Target framework (default: net10.0) |
| Continue | `--continue-on-error` | `-ContinueOnError` | Don't stop on sample failures |
| No Build | `--no-build` | `-NoBuild` | Skip build step (coverage mode) |

## Test Modes

### Playback (Default)

Uses recorded HTTP responses. No Azure credentials required. Ideal for CI/CD and local development.

### Record

Runs tests against live Azure services and captures HTTP request/response pairs via test-proxy. Requires Azure credentials and `CONTENTUNDERSTANDING_ENDPOINT`. After recording, push with `sdkinternal-dotnet-test-push`.

### Live

Runs tests directly against live Azure services without recording. Requires Azure credentials.

## Coverage Reports

When using `--coverage`:

| Report Type | Location |
|------------|----------|
| Cobertura XML | `tests/TestResults/*/coverage.cobertura.xml` |
| HTML Report | `tests/CoverageReport/index.html` |

### Coverage Targets

| Code Type | Target | Notes |
|-----------|--------|-------|
| Custom Client Code | ≥80% | High priority |
| Extension Methods | ≥70% | User-facing APIs |
| Generated Models | N/A | Covered through integration tests |

## Important Notes

### Sample Naming

Samples follow the pattern: `Sample{NN}_{Description}.cs` in `tests/samples/` directory.

### After Recording

Push recordings to assets repo with `sdkinternal-dotnet-test-push`.

### Recording Mismatch

If playback tests fail due to API changes, re-record with `--mode record`.

## Cross-Language Reference

| Language | Test Command | Mode Variable |
|----------|-------------|---------------|
| .NET | `dotnet test --filter` | `AZURE_TEST_MODE` |
| Java | `mvn test` | `-DAZURE_TEST_MODE` |
| Python | `pytest` | `AZURE_TEST_MODE` |
| JavaScript | `npm test` | `AZURE_TEST_MODE` |

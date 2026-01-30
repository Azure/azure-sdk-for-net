````skill
---
name: sdkinternal-dotnet-test-coverage
description: Run Azure SDK tests with code coverage collection using Coverlet. Generate coverage reports in Cobertura XML format and HTML. Analyze custom code coverage excluding auto-generated code.
---

# SDK Test Coverage

This skill runs Azure SDK tests with code coverage collection using Coverlet.

## What This Skill Does

1. Sets `AZURE_TEST_MODE=Playback` environment variable
2. Runs tests with `/p:CollectCoverage=true` flag
3. Generates Cobertura XML coverage report
4. Generates HTML coverage report using ReportGenerator
5. Calculates custom code coverage (excluding generated code)

## Pre-requisites

- [ ] Session recordings available (via `test-proxy restore`)
- [ ] `assets.json` file present in module directory
- [ ] Coverlet package referenced in test project (auto-added by Azure SDK build system)
- [ ] ReportGenerator tool available (`dotnet tool install -g dotnet-reportgenerator-globaltool`)

## Usage

### PowerShell (Windows)

```powershell
cd sdk\contentunderstanding\Azure.AI.ContentUnderstanding

# Run tests with coverage collection
.github\skills\sdkinternal-dotnet-test-coverage\scripts\test-coverage.ps1
```

### Manual Commands

```powershell
# Set playback mode and run tests with coverage
$env:AZURE_TEST_MODE = "Playback"
dotnet test tests\Azure.AI.ContentUnderstanding.Tests.csproj -f net8.0 /p:CollectCoverage=true
```

## Coverage Options

### Run Specific Test with Coverage

```powershell
.github\skills\sdkinternal-dotnet-test-coverage\scripts\test-coverage.ps1 -Filter "ContentFieldDictionaryExtensionsTest"
```

### Target Framework

```powershell
.github\skills\sdkinternal-dotnet-test-coverage\scripts\test-coverage.ps1 -Framework net8.0
```

### Generate HTML Report Only

```powershell
.github\skills\sdkinternal-dotnet-test-coverage\scripts\test-coverage.ps1 -ReportOnly
```

### Show Custom Code Coverage Only

```powershell
.github\skills\sdkinternal-dotnet-test-coverage\scripts\test-coverage.ps1 -CustomCodeOnly
```

## Coverage Reports

### Output Locations

| Report Type | Location |
|------------|----------|
| Cobertura XML | `tests/TestResults/*/coverage.cobertura.xml` |
| HTML Report | `tests/CoverageReport/index.html` |

### Coverage Metrics

- **Line Coverage**: Percentage of code lines executed
- **Branch Coverage**: Percentage of code branches executed

## Custom Code vs Generated Code

The SDK contains both custom code and auto-generated code:

### Custom Code (Focus Areas)
- `*.Customizations.cs` - Custom client implementations
- `*.Extensions.cs` - Extension methods for user convenience

### Generated Code (Lower Priority)
- `*.g.cs` - Auto-generated model classes
- `*_Builder.g.cs` - Serialization builders

Use `-CustomCodeOnly` flag to see coverage for custom code only.

## Coverage Targets

| Code Type | Target | Notes |
|-----------|--------|-------|
| Custom Client Code | ≥80% | High priority |
| Extension Methods | ≥70% | User-facing APIs |
| Generated Models | N/A | Covered through integration tests |

## Troubleshooting

### Coverlet Not Found

```powershell
# Rebuild project to ensure Coverlet package is restored
dotnet build tests\Azure.AI.ContentUnderstanding.Tests.csproj
```

### ReportGenerator Not Found

```powershell
# Install ReportGenerator globally
dotnet tool install -g dotnet-reportgenerator-globaltool

# Or use dotnet tool run
dotnet tool run reportgenerator -- -reports:coverage.cobertura.xml -targetdir:CoverageReport -reporttypes:Html
```

### File Lock Errors

If you see "file being used by another process" errors:
```powershell
# Stop any running test processes
Get-Process testhost -ErrorAction SilentlyContinue | Stop-Process -Force
```

## Integration with CI/CD

Coverage results are automatically uploaded to Azure Pipelines when running in CI:
- Coverage data is collected via `coverlet.collector`
- Results are published as pipeline artifacts
- HTML reports are available for download

````

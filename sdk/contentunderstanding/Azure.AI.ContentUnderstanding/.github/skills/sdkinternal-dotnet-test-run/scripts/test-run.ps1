<# 
.SYNOPSIS
    Unified Azure SDK Test Runner

.DESCRIPTION
    Supports: Playback, Record, Live modes; single/all samples; code coverage.

.PARAMETER Mode
    Test mode: Playback (default), Record, Live

.PARAMETER Filter
    Filter tests by name

.PARAMETER Sample
    Run a single sample by method name

.PARAMETER Samples
    Run all samples

.PARAMETER ListSamples
    List available sample methods

.PARAMETER Coverage
    Collect code coverage (Playback mode)

.PARAMETER CustomCodeOnly
    Show coverage for custom code only

.PARAMETER ReportOnly
    Only generate HTML coverage report (no test run)

.PARAMETER Framework
    Target framework (default: net10.0)

.PARAMETER ContinueOnError
    Don't stop on sample failures

.PARAMETER NoBuild
    Skip build step (coverage mode)
#>

param(
    [ValidateSet("Playback", "Record", "Live")]
    [string]$Mode = "Playback",

    [string]$Filter = "",
    [string]$Sample = "",
    [switch]$Samples,
    [switch]$ListSamples,
    [switch]$Coverage,
    [switch]$CustomCodeOnly,
    [switch]$ReportOnly,
    [string]$Framework = "",
    [switch]$ContinueOnError,
    [switch]$NoBuild
)

$ErrorActionPreference = "Stop"

# ── Ensure dotnet is on PATH ──────────────────────────────────────────────────
if (-not (Get-Command "dotnet" -ErrorAction SilentlyContinue)) {
    $dotnetHome = Join-Path $env:HOME ".dotnet"
    $dotnetUser = Join-Path $env:USERPROFILE ".dotnet"
    if (Test-Path (Join-Path $dotnetHome "dotnet")) {
        $env:PATH = "$dotnetHome" + [System.IO.Path]::PathSeparator + $env:PATH
    } elseif (Test-Path (Join-Path $dotnetUser "dotnet.exe")) {
        $env:PATH = "$dotnetUser" + [System.IO.Path]::PathSeparator + $env:PATH
    } else {
        Write-Host "Error: dotnet command not found" -ForegroundColor Red
        Write-Host "Install .NET SDK: https://dot.net/download" -ForegroundColor Yellow
        exit 1
    }
}

# ── Resolve framework default ────────────────────────────────────────────────
if ([string]::IsNullOrEmpty($Framework)) {
    $Framework = "net10.0"
}

# ── Locate project ───────────────────────────────────────────────────────────
$SdkDir = Get-Location
$SamplesDir = Join-Path $SdkDir "tests/samples"
$TestsDir = Join-Path $SdkDir "tests"
$TestResultsDir = Join-Path $TestsDir "TestResults"
$CoverageReportDir = Join-Path $TestsDir "CoverageReport"
$AssetsFile = Join-Path $SdkDir "assets.json"
$TestsProject = Get-ChildItem -Path "$TestsDir/*.csproj" -ErrorAction SilentlyContinue | Select-Object -First 1

if (-not $TestsProject) {
    Write-Host "Error: No test project found in tests/ directory" -ForegroundColor Red
    exit 1
}

# ── Helper: find latest coverage file ────────────────────────────────────────
function Find-CoverageFile {
    Get-ChildItem -Path $TestResultsDir -Filter "coverage.cobertura.xml" -Recurse -ErrorAction SilentlyContinue |
        Sort-Object LastWriteTime -Descending |
        Select-Object -First 1 -ExpandProperty FullName
}

# ══════════════════════════════════════════════════════════════════════════════
#  List Samples
# ══════════════════════════════════════════════════════════════════════════════
if ($ListSamples) {
    if (-not (Test-Path $SamplesDir)) {
        Write-Host "Error: Samples directory not found at tests/samples/" -ForegroundColor Red
        exit 1
    }

    Write-Host "Available sample methods:" -ForegroundColor Yellow
    Write-Host "(Use these names with -Sample)" -ForegroundColor DarkGray

    Get-ChildItem -Path $SamplesDir -Filter "Sample*.cs" | ForEach-Object {
        $filename = $_.BaseName
        $content = Get-Content $_.FullName -Raw
        $matches = [regex]::Matches($content, '\[(RecordedTest|Test)\][^\{]*public\s+async\s+Task\s+(\w+)\s*\(')
        foreach ($match in $matches) {
            $method = $match.Groups[2].Value
            Write-Host "  $method" -ForegroundColor Cyan -NoNewline
            Write-Host " ($filename)" -ForegroundColor DarkGray
        }
    }
    exit 0
}

# ══════════════════════════════════════════════════════════════════════════════
#  Report-Only Mode (coverage)
# ══════════════════════════════════════════════════════════════════════════════
if ($ReportOnly) {
    $CoverageFile = Find-CoverageFile
    if (-not $CoverageFile) {
        Write-Host "Error: No coverage file found. Run tests with -Coverage first." -ForegroundColor Red
        exit 1
    }
    Write-Host "Generating HTML report from: $CoverageFile" -ForegroundColor Yellow
    dotnet tool run reportgenerator -- "-reports:$CoverageFile" "-targetdir:$CoverageReportDir" -reporttypes:Html
    Write-Host "HTML report generated: $CoverageReportDir/index.html" -ForegroundColor Green
    exit 0
}

# ══════════════════════════════════════════════════════════════════════════════
#  Set Test Mode
# ══════════════════════════════════════════════════════════════════════════════
# Override to Playback for coverage
if ($Coverage) {
    $env:AZURE_TEST_MODE = "Playback"
} else {
    $env:AZURE_TEST_MODE = $Mode
}

# ── Header ────────────────────────────────────────────────────────────────────
Write-Host "═══════════════════════════════════════════════════════════"
Write-Host "  Azure SDK Test Runner"
Write-Host "═══════════════════════════════════════════════════════════"
Write-Host ""
Write-Host "Test Project: $($TestsProject.Name)" -ForegroundColor Cyan
Write-Host "Framework:    $Framework" -ForegroundColor Cyan
Write-Host "Test Mode:    $env:AZURE_TEST_MODE" -ForegroundColor Cyan

if ($Sample) {
    Write-Host "Sample:       $Sample" -ForegroundColor Cyan
} elseif ($Samples) {
    Write-Host "Target:       All Samples" -ForegroundColor Cyan
}

if ($Coverage) {
    Write-Host "Coverage:     Enabled" -ForegroundColor Cyan
}
Write-Host ""

# ══════════════════════════════════════════════════════════════════════════════
#  Single Sample Run
# ══════════════════════════════════════════════════════════════════════════════
if ($Sample) {
    if (-not (Test-Path $SamplesDir)) {
        Write-Host "Error: Samples directory not found at tests/samples/" -ForegroundColor Red
        exit 1
    }

    Write-Host "Running sample: $Sample" -ForegroundColor Yellow
    $TestFilter = "FullyQualifiedName~$Sample"

    dotnet test $TestsProject.FullName -f $Framework -v n --filter $TestFilter
    $exitCode = $LASTEXITCODE

    if ($exitCode -eq 0) {
        Write-Host "`nSample executed successfully!" -ForegroundColor Green
    } else {
        Write-Host "`nSample failed with exit code: $exitCode" -ForegroundColor Red
    }
    exit $exitCode
}

# ══════════════════════════════════════════════════════════════════════════════
#  All Samples Run
# ══════════════════════════════════════════════════════════════════════════════
if ($Samples) {
    if (-not (Test-Path $SamplesDir)) {
        Write-Host "Error: Samples directory not found at tests/samples/" -ForegroundColor Red
        exit 1
    }

    $sampleCount = (Get-ChildItem -Path $SamplesDir -Filter "Sample*.cs").Count
    Write-Host "Found $sampleCount sample files. Running all samples..." -ForegroundColor Yellow

    $TestFilter = "FullyQualifiedName~Samples"
    dotnet test $TestsProject.FullName -f $Framework -v n --filter $TestFilter
    $exitCode = $LASTEXITCODE

    if ($exitCode -eq 0) {
        Write-Host "`nAll samples executed successfully!" -ForegroundColor Green
    } else {
        Write-Host "`nSome samples failed (exit code: $exitCode)" -ForegroundColor Red
        if (-not $ContinueOnError) {
            exit $exitCode
        }
    }
    exit $exitCode
}

# ══════════════════════════════════════════════════════════════════════════════
#  Coverage Test Run
# ══════════════════════════════════════════════════════════════════════════════
if ($Coverage) {
    $testArgs = @("test", $TestsProject.FullName, "-f", $Framework, "/p:CollectCoverage=true")

    if ($NoBuild) {
        $testArgs += "--no-build"
    }

    if ($Filter) {
        $testArgs += @("--filter", $Filter)
        Write-Host "Filter: $Filter" -ForegroundColor Cyan
    }

    Write-Host "Running tests with coverage collection..." -ForegroundColor Yellow
    Write-Host ""

    dotnet @testArgs

    # Find and report coverage
    $CoverageFile = Find-CoverageFile
    if (-not $CoverageFile) {
        Write-Host "Warning: No coverage file found" -ForegroundColor Yellow
        exit 0
    }

    Write-Host ""
    Write-Host "Coverage data: $CoverageFile" -ForegroundColor Cyan

    # Generate HTML report
    Write-Host "Generating HTML report..." -ForegroundColor Yellow
    try {
        dotnet tool run reportgenerator -- "-reports:$CoverageFile" "-targetdir:$CoverageReportDir" -reporttypes:Html
    } catch {
        Write-Host "Note: ReportGenerator not available. Install with: dotnet tool install -g dotnet-reportgenerator-globaltool" -ForegroundColor Yellow
    }

    Write-Host "HTML report: $CoverageReportDir/index.html" -ForegroundColor Cyan

    Write-Host ""
    Write-Host "═══════════════════════════════════════════════════════════"
    Write-Host "  Coverage collection complete!" -ForegroundColor Green
    Write-Host "═══════════════════════════════════════════════════════════"
    exit 0
}

# ══════════════════════════════════════════════════════════════════════════════
#  Standard Test Run (Playback / Record / Live)
# ══════════════════════════════════════════════════════════════════════════════
$testArgs = @("test", $TestsProject.FullName, "-f", $Framework, "-v", "n")

if ($Filter) {
    $testArgs += @("--filter", "FullyQualifiedName~$Filter")
    Write-Host "Filter: $Filter" -ForegroundColor Cyan
}

Write-Host "Starting test execution..." -ForegroundColor Yellow

dotnet @testArgs
$exitCode = $LASTEXITCODE

if ($exitCode -eq 0) {
    Write-Host "`nAll tests passed in $($env:AZURE_TEST_MODE) mode!" -ForegroundColor Green

    if ($Mode -eq "Record") {
        Write-Host "Next step: Push recordings with 'sdkinternal-dotnet-test-push' or 'test-proxy push -a assets.json'" -ForegroundColor Yellow
    }
} else {
    Write-Host "`nTests failed with exit code: $exitCode" -ForegroundColor Red

    if ($Mode -eq "Playback") {
        Write-Host "If recordings are outdated, re-record with: test-run.ps1 -Mode Record" -ForegroundColor Yellow
    }
}

exit $exitCode

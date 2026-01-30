<#
.SYNOPSIS
    Run Azure SDK tests with code coverage collection.

.DESCRIPTION
    This script runs Azure SDK tests in PLAYBACK mode with Coverlet code coverage
    collection. It generates Cobertura XML and HTML coverage reports.

.PARAMETER Filter
    Optional test filter expression (e.g., "FullyQualifiedName~MyTest")

.PARAMETER Framework
    Target framework to test against (default: net8.0)

.PARAMETER ReportOnly
    Only generate HTML report from existing coverage data

.PARAMETER CustomCodeOnly
    Show coverage for custom code only (Customizations & Extensions)

.PARAMETER NoBuild
    Skip build step

.EXAMPLE
    .\test-coverage.ps1
    Run all tests with coverage

.EXAMPLE
    .\test-coverage.ps1 -Filter "ContentFieldDictionaryExtensionsTest"
    Run specific tests with coverage

.EXAMPLE
    .\test-coverage.ps1 -CustomCodeOnly
    Show custom code coverage summary
#>

param(
    [string]$Filter = "",
    [string]$Framework = "net8.0",
    [switch]$ReportOnly,
    [switch]$CustomCodeOnly,
    [switch]$NoBuild
)

$ErrorActionPreference = "Stop"

# Get script and project directories
$ScriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$SkillDir = Split-Path -Parent $ScriptDir
$ModuleDir = Split-Path -Parent (Split-Path -Parent (Split-Path -Parent $SkillDir))
$TestsDir = Join-Path $ModuleDir "tests"
$TestProject = Join-Path $TestsDir "Azure.AI.ContentUnderstanding.Tests.csproj"
$TestResultsDir = Join-Path $TestsDir "TestResults"
$CoverageReportDir = Join-Path $TestsDir "CoverageReport"

Write-Host "═══════════════════════════════════════════════════════════" -ForegroundColor Cyan
Write-Host "  Azure.AI.ContentUnderstanding Test Coverage" -ForegroundColor Yellow
Write-Host "═══════════════════════════════════════════════════════════" -ForegroundColor Cyan
Write-Host ""

# Function to find latest coverage file
function Get-LatestCoverageFile {
    $coverageFiles = Get-ChildItem -Path $TestResultsDir -Recurse -Filter "coverage.cobertura.xml" -ErrorAction SilentlyContinue
    if ($coverageFiles) {
        return $coverageFiles | Sort-Object LastWriteTime -Descending | Select-Object -First 1
    }
    return $null
}

# Function to show custom code coverage
function Show-CustomCodeCoverage {
    param([string]$CoverageFile)
    
    [xml]$coverage = Get-Content $CoverageFile
    
    Write-Host ""
    Write-Host "═══════════════════════════════════════════════════════════" -ForegroundColor Cyan
    Write-Host "  Custom Code Coverage (Customizations & Extensions)" -ForegroundColor Yellow
    Write-Host "═══════════════════════════════════════════════════════════" -ForegroundColor Cyan
    Write-Host ""
    
    $coverage.coverage.packages.package.classes.class | 
        Where-Object { 
            $_.filename -like "*ContentUnderstanding\src*" -and 
            ($_.filename -like "*Customizations*" -or $_.filename -like "*Extensions*") 
        } | 
        Group-Object { Split-Path $_.filename -Leaf } | 
        ForEach-Object { 
            $file = $_.Name
            $classes = $_.Group
            $avgRate = [math]::Round(($classes | ForEach-Object { [double]$_.'line-rate' } | Measure-Object -Average).Average * 100, 1)
            $color = if ($avgRate -ge 70) { "Green" } elseif ($avgRate -ge 50) { "Yellow" } else { "Red" }
            Write-Host "  $file`: " -NoNewline
            Write-Host "$avgRate%" -ForegroundColor $color
        }
    
    Write-Host ""
}

# Function to show overall coverage summary
function Show-CoverageSummary {
    param([string]$CoverageFile)
    
    [xml]$coverage = Get-Content $CoverageFile
    
    $lineRate = [math]::Round([double]$coverage.coverage.'line-rate' * 100, 2)
    $branchRate = [math]::Round([double]$coverage.coverage.'branch-rate' * 100, 2)
    
    Write-Host ""
    Write-Host "═══════════════════════════════════════════════════════════" -ForegroundColor Cyan
    Write-Host "  Overall Coverage Summary" -ForegroundColor Yellow
    Write-Host "═══════════════════════════════════════════════════════════" -ForegroundColor Cyan
    Write-Host ""
    Write-Host "  Line Coverage:   $lineRate%"
    Write-Host "  Branch Coverage: $branchRate%"
    Write-Host ""
}

# Generate HTML report only
if ($ReportOnly) {
    $coverageFile = Get-LatestCoverageFile
    if (-not $coverageFile) {
        Write-Host "Error: No coverage file found. Run tests first." -ForegroundColor Red
        exit 1
    }
    
    Write-Host "Generating HTML report from: $($coverageFile.FullName)" -ForegroundColor Cyan
    
    dotnet tool run reportgenerator -- `
        "-reports:$($coverageFile.FullName)" `
        "-targetdir:$CoverageReportDir" `
        -reporttypes:Html
    
    Write-Host ""
    Write-Host "HTML report generated: $CoverageReportDir\index.html" -ForegroundColor Green
    
    if ($CustomCodeOnly) {
        Show-CustomCodeCoverage -CoverageFile $coverageFile.FullName
    } else {
        Show-CoverageSummary -CoverageFile $coverageFile.FullName
    }
    
    exit 0
}

# Set PLAYBACK mode
$env:AZURE_TEST_MODE = "Playback"
Write-Host "Test Mode: PLAYBACK" -ForegroundColor Green

# Build test command
$testArgs = @(
    "test"
    $TestProject
    "-f", $Framework
    "/p:CollectCoverage=true"
)

if ($NoBuild) {
    $testArgs += "--no-build"
}

if ($Filter) {
    $testArgs += "--filter", $Filter
    Write-Host "Filter: $Filter" -ForegroundColor Cyan
}

Write-Host "Framework: $Framework" -ForegroundColor Cyan
Write-Host ""

# Run tests with coverage
Write-Host "Running tests with coverage collection..." -ForegroundColor Cyan
Write-Host ""

& dotnet @testArgs

if ($LASTEXITCODE -ne 0) {
    Write-Host ""
    Write-Host "Tests failed with exit code $LASTEXITCODE" -ForegroundColor Red
    exit $LASTEXITCODE
}

# Find coverage file
$coverageFile = Get-LatestCoverageFile
if (-not $coverageFile) {
    Write-Host ""
    Write-Host "Warning: No coverage file found" -ForegroundColor Yellow
    exit 0
}

Write-Host ""
Write-Host "Coverage data: $($coverageFile.FullName)" -ForegroundColor Cyan

# Generate HTML report
Write-Host ""
Write-Host "Generating HTML report..." -ForegroundColor Cyan

try {
    dotnet tool run reportgenerator -- `
        "-reports:$($coverageFile.FullName)" `
        "-targetdir:$CoverageReportDir" `
        -reporttypes:Html 2>$null
    
    Write-Host "HTML report: $CoverageReportDir\index.html" -ForegroundColor Green
} catch {
    Write-Host "Note: ReportGenerator not available. Install with: dotnet tool install -g dotnet-reportgenerator-globaltool" -ForegroundColor Yellow
}

# Show coverage summary
if ($CustomCodeOnly) {
    Show-CustomCodeCoverage -CoverageFile $coverageFile.FullName
} else {
    Show-CoverageSummary -CoverageFile $coverageFile.FullName
    Show-CustomCodeCoverage -CoverageFile $coverageFile.FullName
}

Write-Host "═══════════════════════════════════════════════════════════" -ForegroundColor Cyan
Write-Host "  Coverage collection complete!" -ForegroundColor Green
Write-Host "═══════════════════════════════════════════════════════════" -ForegroundColor Cyan

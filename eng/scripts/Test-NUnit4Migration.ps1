<#
.SYNOPSIS
Builds and tests a service directory after NUnit 4 migration

.DESCRIPTION
This script runs after migrating to NUnit 4 and adding version overrides.
It builds all solution files and runs tests, reporting any failures.

.PARAMETER ServiceDirectory
The service directory to test (e.g., "core", "storage", "keyvault")

.EXAMPLE
.\Test-NUnit4Migration.ps1 -ServiceDirectory core
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory=$true)]
    [string]$ServiceDirectory
)

$ErrorActionPreference = 'Continue'
$repoRoot = Resolve-Path "$PSScriptRoot/../.."
$sdkPath = Join-Path $repoRoot "sdk" $ServiceDirectory

if (-not (Test-Path $sdkPath)) {
    Write-Error "Service directory not found: $sdkPath"
    exit 1
}

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Testing NUnit 4 Migration: $ServiceDirectory" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Service path: $sdkPath" -ForegroundColor Gray
Write-Host ""

# Find all solution files
$solutionFiles = Get-ChildItem -Path $sdkPath -Filter "*.sln" -Recurse
Write-Host "Found $($solutionFiles.Count) solution files" -ForegroundColor Gray
Write-Host ""

if ($solutionFiles.Count -eq 0) {
    Write-Warning "No solution files found in $sdkPath"
    exit 0
}

$buildResults = @()
$testResults = @()
$totalBuildErrors = 0
$totalTestFailures = 0

# Step 1: Build all solutions
Write-Host "Step 1: Building solutions..." -ForegroundColor Cyan
Write-Host ""

foreach ($sln in $solutionFiles) {
    $slnName = Split-Path $sln.FullName -Leaf
    Write-Host "  Building: $slnName" -ForegroundColor White
    
    $buildOutput = dotnet build $sln.FullName --no-incremental 2>&1
    
    if ($LASTEXITCODE -eq 0) {
        Write-Host "    ✓ Build succeeded" -ForegroundColor Green
        $buildResults += [PSCustomObject]@{
            Solution = $slnName
            Success = $true
            ErrorCount = 0
        }
    } else {
        $errorCount = ($buildOutput | Select-String -Pattern "^\s+\d+\sError\(s\)" | Select-Object -First 1) -replace '\s+(\d+)\sError\(s\).*','$1'
        if (-not $errorCount) { $errorCount = "Unknown" }
        
        Write-Host "    ✗ Build failed with $errorCount error(s)" -ForegroundColor Red
        $totalBuildErrors++
        
        $buildResults += [PSCustomObject]@{
            Solution = $slnName
            Success = $false
            ErrorCount = $errorCount
        }
    }
}

Write-Host ""

# Step 2: Test solutions that built successfully
Write-Host "Step 2: Running tests on successful builds..." -ForegroundColor Cyan
Write-Host ""

$successfulBuilds = $buildResults | Where-Object { $_.Success }

if ($successfulBuilds.Count -eq 0) {
    Write-Warning "No solutions built successfully. Skipping tests."
} else {
    foreach ($buildResult in $successfulBuilds) {
        $sln = $solutionFiles | Where-Object { (Split-Path $_.FullName -Leaf) -eq $buildResult.Solution }
        $slnName = $buildResult.Solution
        
        Write-Host "  Testing: $slnName" -ForegroundColor White
        
        # Run tests with verbose output to capture failures
        $testOutput = dotnet test $sln.FullName --no-build --verbosity normal 2>&1 | Out-String
        
        if ($LASTEXITCODE -eq 0) {
            Write-Host "    ✓ All tests passed" -ForegroundColor Green
        } else {
            Write-Host "    ✗ Tests failed" -ForegroundColor Red
            
            # Parse test failures from output
            $lines = $testOutput -split "`n"
            $inFailureSection = $false
            $currentTest = $null
            
            for ($i = 0; $i -lt $lines.Count; $i++) {
                $line = $lines[$i]
                
                # Detect test failure
                if ($line -match '^\s*Failed\s+(.+)\s+\[') {
                    $currentTest = $matches[1].Trim()
                    $inFailureSection = $true
                }
                # Capture error message
                elseif ($inFailureSection -and $line -match '^\s*Error Message:') {
                    $errorMsg = ""
                    $j = $i + 1
                    # Collect error message lines
                    while ($j -lt $lines.Count -and $lines[$j] -notmatch '^\s*(Stack Trace:|Expected:|Actual:|Failed)') {
                        $errorMsg += $lines[$j].Trim() + " "
                        $j++
                    }
                    
                    # Try to find the test file location
                    $testFile = ""
                    for ($k = $i; $k -lt [Math]::Min($i + 20, $lines.Count); $k++) {
                        if ($lines[$k] -match 'at\s+.+\sin\s+(.+\.cs):line\s+(\d+)') {
                            $testFile = "$($matches[1]):$($matches[2])"
                            break
                        }
                    }
                    
                    $testResults += [PSCustomObject]@{
                        Solution = $slnName
                        TestName = $currentTest
                        File = $testFile
                        Error = $errorMsg.Trim()
                    }
                    
                    $totalTestFailures++
                    $inFailureSection = $false
                    $i = $j - 1
                }
            }
        }
    }
}

Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Summary" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Build summary
Write-Host "Build Results:" -ForegroundColor White
foreach ($result in $buildResults) {
    if ($result.Success) {
        Write-Host "  ✓ $($result.Solution)" -ForegroundColor Green
    } else {
        Write-Host "  ✗ $($result.Solution) - $($result.ErrorCount) error(s)" -ForegroundColor Red
    }
}

Write-Host ""

# Test failure details
if ($testResults.Count -gt 0) {
    Write-Host "Test Failures ($totalTestFailures):" -ForegroundColor Red
    Write-Host ""
    
    foreach ($failure in $testResults) {
        Write-Host "  Test: $($failure.TestName)" -ForegroundColor Yellow
        if ($failure.File) {
            Write-Host "  File: $($failure.File)" -ForegroundColor Gray
        }
        Write-Host "  Error: $($failure.Error)" -ForegroundColor Gray
        Write-Host "  Solution: $($failure.Solution)" -ForegroundColor Gray
        Write-Host ""
    }
} else {
    Write-Host "✓ All tests passed!" -ForegroundColor Green
}

Write-Host ""
Write-Host "Total build errors: $totalBuildErrors" -ForegroundColor $(if ($totalBuildErrors -gt 0) { 'Red' } else { 'Green' })
Write-Host "Total test failures: $totalTestFailures" -ForegroundColor $(if ($totalTestFailures -gt 0) { 'Red' } else { 'Green' })
Write-Host ""

# Exit with error code if there were failures
if ($totalBuildErrors -gt 0 -or $totalTestFailures -gt 0) {
    exit 1
} else {
    exit 0
}

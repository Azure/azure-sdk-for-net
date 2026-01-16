<#
.SYNOPSIS
    Tests NUnit migration by building all solution files and reporting failures.

.DESCRIPTION
    This script builds all .sln files in the repository and generates a detailed
    markdown report of any build failures, including error messages and counts.
    
    The report includes:
    - Summary statistics (total, passed, failed)
    - List of failed solutions with error counts
    - Detailed error messages for each failure
    
.PARAMETER RepoRoot
    The root directory of the azure-sdk-for-net repository. Defaults to current directory.

.PARAMETER OutputFile
    Path to the output markdown file. Defaults to 'Build-Report.md' in the current directory.

.PARAMETER Configuration
    Build configuration to use. Defaults to 'Debug'.

.PARAMETER IncludeWarnings
    If specified, includes warnings in the report (not just errors).

.PARAMETER MaxParallel
    Maximum number of parallel builds. Defaults to 1 (serial) to avoid conflicts.

.EXAMPLE
    .\Test-NUnitMigration.ps1
    Builds all solutions and creates Build-Report.md in current directory.

.EXAMPLE
    .\Test-NUnitMigration.ps1 -RepoRoot "C:\repos\azure-sdk-for-net" -OutputFile "C:\reports\nunit-migration.md"
    Builds with custom paths.

.EXAMPLE
    .\Test-NUnitMigration.ps1 -Configuration Release -IncludeWarnings
    Builds in Release mode and includes warnings in the report.
#>

[CmdletBinding()]
param(
    [Parameter()]
    [string]$RepoRoot = ".",
    
    [Parameter()]
    [string]$OutputFile = "Build-Report.md",
    
    [Parameter()]
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Debug",
    
    [Parameter()]
    [switch]$IncludeWarnings,
    
    [Parameter()]
    [int]$MaxParallel = 1
)

$ErrorActionPreference = "Stop"

# Convert to absolute paths
$RepoRoot = Resolve-Path $RepoRoot -ErrorAction Stop
if (-not [System.IO.Path]::IsPathRooted($OutputFile)) {
    $OutputFile = Join-Path (Get-Location) $OutputFile
}

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "NUnit Migration Build Test" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Repository: $RepoRoot" -ForegroundColor Yellow
Write-Host "Output: $OutputFile" -ForegroundColor Yellow
Write-Host "Configuration: $Configuration" -ForegroundColor Yellow
Write-Host ""

# Validate we're in the azure-sdk-for-net repo
if (-not (Test-Path (Join-Path $RepoRoot "sdk"))) {
    Write-Error "The specified directory does not appear to be the azure-sdk-for-net repository root. 'sdk' folder not found."
    exit 1
}

# Find all solution files
$sdkDir = Join-Path $RepoRoot "sdk"
Write-Host "Scanning for solution files..." -ForegroundColor Cyan
$solutions = Get-ChildItem -Path $sdkDir -Filter "*.sln" -Recurse | Sort-Object FullName

Write-Host "Found $($solutions.Count) solution files" -ForegroundColor Yellow
Write-Host ""

# Build tracking
$buildResults = [System.Collections.ArrayList]::new()
$totalBuilds = $solutions.Count
$currentBuild = 0
$stopwatch = [System.Diagnostics.Stopwatch]::StartNew()

# Build each solution
Write-Host "Building solutions..." -ForegroundColor Cyan
Write-Host ""

foreach ($sln in $solutions) {
    $currentBuild++
    $slnPath = $sln.FullName
    $relativePath = $slnPath.Substring($RepoRoot.Length + 1)
    
    Write-Host "[$currentBuild/$totalBuilds] Building: $relativePath" -ForegroundColor Gray
    
    # Capture build output
    $buildOutput = & dotnet build "$slnPath" --configuration $Configuration --no-restore --verbosity minimal 2>&1 | Out-String
    $exitCode = $LASTEXITCODE
    
    # Parse errors and warnings
    $errors = @()
    $warnings = @()
    
    $lines = $buildOutput -split "`r?`n"
    foreach ($line in $lines) {
        # Match error pattern: path(line,col): error CODE: message
        if ($line -match ':\s*error\s+[A-Z0-9]+:') {
            $errors += $line.Trim()
        }
        # Match warning pattern
        elseif ($IncludeWarnings -and $line -match ':\s*warning\s+[A-Z0-9]+:') {
            $warnings += $line.Trim()
        }
    }
    
    # Extract summary counts from build output
    $errorCount = 0
    $warningCount = 0
    if ($buildOutput -match '(\d+) Error\(s\)') {
        $errorCount = [int]$Matches[1]
    }
    if ($buildOutput -match '(\d+) Warning\(s\)') {
        $warningCount = [int]$Matches[1]
    }
    
    $result = [PSCustomObject]@{
        Solution = $relativePath
        Success = ($exitCode -eq 0)
        ExitCode = $exitCode
        ErrorCount = $errorCount
        WarningCount = $warningCount
        Errors = $errors
        Warnings = $warnings
        FullOutput = $buildOutput
    }
    
    [void]$buildResults.Add($result)
    
    if ($result.Success) {
        Write-Host "  [OK] Success" -ForegroundColor Green
    }
    else {
        Write-Host ("  [FAIL] Failed (" + $errorCount + " errors, " + $warningCount + " warnings)") -ForegroundColor Red
    }
}

$stopwatch.Stop()

# Calculate statistics
$successCount = ($buildResults | Where-Object { $_.Success -eq $true }).Count
$failureCount = ($buildResults | Where-Object { $_.Success -eq $false }).Count
$totalErrors = ($buildResults | Measure-Object -Property ErrorCount -Sum).Sum
$totalWarnings = ($buildResults | Measure-Object -Property WarningCount -Sum).Sum

Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Build Summary" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Total: $totalBuilds" -ForegroundColor White
Write-Host "Passed: $successCount" -ForegroundColor Green
Write-Host "Failed: $failureCount" -ForegroundColor $(if ($failureCount -gt 0) { "Red" } else { "Green" })
Write-Host "Total Errors: $totalErrors" -ForegroundColor $(if ($totalErrors -gt 0) { "Red" } else { "Green" })
Write-Host "Total Warnings: $totalWarnings" -ForegroundColor Yellow
Write-Host "Time: $($stopwatch.Elapsed.ToString('hh\:mm\:ss'))" -ForegroundColor White
Write-Host ""

# Generate Markdown Report
Write-Host "Generating markdown report: $OutputFile" -ForegroundColor Cyan

$backtick = [char]96
$codeBlockMarker = @($backtick, $backtick, $backtick) -join ''
$markdown = [System.Text.StringBuilder]::new()
[void]$markdown.AppendLine("# NUnit Migration Build Report")
[void]$markdown.AppendLine()
[void]$markdown.AppendLine("**Generated:** $(Get-Date -Format 'yyyy-MM-dd HH:mm:ss')")
[void]$markdown.AppendLine("**Configuration:** $Configuration")
[void]$markdown.AppendLine("**Repository:** $RepoRoot")
[void]$markdown.AppendLine()

# Summary section
[void]$markdown.AppendLine("## Summary")
[void]$markdown.AppendLine()
[void]$markdown.AppendLine('| Metric | Count |')
[void]$markdown.AppendLine('|--------|-------|')
[void]$markdown.AppendLine("| Total Solutions | $totalBuilds |")
[void]$markdown.AppendLine("| Passed | $successCount |")
[void]$markdown.AppendLine("| Failed | $failureCount |")
[void]$markdown.AppendLine("| Total Errors | $totalErrors |")
[void]$markdown.AppendLine("| Total Warnings | $totalWarnings |")
[void]$markdown.AppendLine("| Build Time | $($stopwatch.Elapsed.ToString('hh\:mm\:ss')) |")
[void]$markdown.AppendLine()

if ($failureCount -eq 0) {
    [void]$markdown.AppendLine("## All Builds Passed!")
    [void]$markdown.AppendLine()
    [void]$markdown.AppendLine("No build failures detected. The NUnit migration appears successful.")
}
else {
    # Failed builds overview
    [void]$markdown.AppendLine("## Failed Builds Overview")
    [void]$markdown.AppendLine()
    [void]$markdown.AppendLine('| Solution | Errors | Warnings |')
    [void]$markdown.AppendLine('|----------|--------|----------|')
    
    $failedBuilds = $buildResults | Where-Object { $_.Success -eq $false } | Sort-Object -Property ErrorCount -Descending
    foreach ($failed in $failedBuilds) {
        [void]$markdown.AppendLine("| $($failed.Solution) | $($failed.ErrorCount) | $($failed.WarningCount) |")
    }
    [void]$markdown.AppendLine()
    
    # Detailed error section
    [void]$markdown.AppendLine("## Detailed Errors")
    [void]$markdown.AppendLine()
    
    foreach ($failed in $failedBuilds) {
        [void]$markdown.AppendLine("### $($failed.Solution)")
        [void]$markdown.AppendLine()
        [void]$markdown.AppendLine("**Exit Code:** $($failed.ExitCode)")
        [void]$markdown.AppendLine("**Errors:** $($failed.ErrorCount)")
        [void]$markdown.AppendLine("**Warnings:** $($failed.WarningCount)")
        [void]$markdown.AppendLine()
        
        if ($failed.Errors.Count -gt 0) {
            [void]$markdown.AppendLine("#### Errors")
            [void]$markdown.AppendLine()
            [void]$markdown.AppendLine($codeBlockMarker)
            foreach ($error in $failed.Errors) {
                [void]$markdown.AppendLine($error)
            }
            [void]$markdown.AppendLine($codeBlockMarker)
            [void]$markdown.AppendLine()
        }
        
        if ($IncludeWarnings -and $failed.Warnings.Count -gt 0) {
            [void]$markdown.AppendLine("#### Warnings")
            [void]$markdown.AppendLine()
            [void]$markdown.AppendLine($codeBlockMarker)
            foreach ($warning in $failed.Warnings) {
                [void]$markdown.AppendLine($warning)
            }
            [void]$markdown.AppendLine($codeBlockMarker)
            [void]$markdown.AppendLine()
        }
        
        # Optionally include full output in a collapsible section
        [void]$markdown.AppendLine("<details>")
        [void]$markdown.AppendLine("<summary>Full Build Output</summary>")
        [void]$markdown.AppendLine()
        [void]$markdown.AppendLine($codeBlockMarker)
        [void]$markdown.AppendLine($failed.FullOutput)
        [void]$markdown.AppendLine($codeBlockMarker)
        [void]$markdown.AppendLine()
        [void]$markdown.AppendLine("</details>")
        [void]$markdown.AppendLine()
        [void]$markdown.AppendLine("---")
        [void]$markdown.AppendLine()
    }
}

# Successful builds section (optional, for completeness)
if ($successCount -gt 0) {
    [void]$markdown.AppendLine("## Successful Builds")
    [void]$markdown.AppendLine()
    [void]$markdown.AppendLine("<details>")
    [void]$markdown.AppendLine("<summary>Show $successCount successful builds</summary>")
    [void]$markdown.AppendLine()
    
    $successfulBuilds = $buildResults | Where-Object { $_.Success -eq $true } | Sort-Object Solution
    foreach ($success in $successfulBuilds) {
        [void]$markdown.AppendLine("- $($success.Solution)")
    }
    
    [void]$markdown.AppendLine()
    [void]$markdown.AppendLine("</details>")
    [void]$markdown.AppendLine()
}

# Write to file
$markdown.ToString() | Set-Content -Path $OutputFile -Encoding UTF8

Write-Host "Report generated successfully!" -ForegroundColor Green
Write-Host ""
Write-Host "Next steps:" -ForegroundColor Yellow
Write-Host "1. Review the report: $OutputFile" -ForegroundColor White
Write-Host "2. Fix build errors in failing solutions" -ForegroundColor White
Write-Host "3. Re-run this script to verify fixes" -ForegroundColor White
Write-Host ""

# Return exit code based on build results
exit $(if ($failureCount -gt 0) { 1 } else { 0 })

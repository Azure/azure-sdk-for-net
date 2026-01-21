<#
.SYNOPSIS
Migrates test projects from NUnit 3 to NUnit 4 using NUnit.Analyzers

.DESCRIPTION
This script automates code changes required for NUnit 4 migration based on:
https://docs.nunit.org/articles/nunit/release-notes/Nunit4.0-MigrationGuide.html

The script:
1. Adds NUnit.Analyzers package reference to data plane test projects
2. Runs dotnet format with NUnit.Analyzers fixers to automatically migrate code
3. Reverts csproj files with only whitespace changes

.PARAMETER ServiceDirectory
The service directory to migrate (e.g., "core", "storage", "keyvault")

.EXAMPLE
.\Migrate-NUnit4.ps1 -ServiceDirectory core

.NOTES
You must manually update central package versions after running this script.
Do NOT commit changes until you've added the NUnit 4.x version override.
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory=$true)]
    [string]$ServiceDirectory
)

$ErrorActionPreference = 'Stop'
$repoRoot = Resolve-Path "$PSScriptRoot/../.."
$sdkPath = Join-Path $repoRoot "sdk" $ServiceDirectory

if (-not (Test-Path $sdkPath)) {
    Write-Error "Service directory not found: $sdkPath"
    exit 1
}

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "NUnit 4 Migration for: $ServiceDirectory" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Service path: $sdkPath" -ForegroundColor Gray
Write-Host ""

# Find all test projects
$testProjects = Get-ChildItem -Path $sdkPath -Filter "*.Tests.csproj" -Recurse
Write-Host "Found $($testProjects.Count) test projects" -ForegroundColor Gray
Write-Host ""

if ($testProjects.Count -eq 0) {
    Write-Warning "No test projects found in $sdkPath"
    exit 0
}

# Step 1: Add NUnit.Analyzers to data plane test projects
Write-Host "Step 1: Adding NUnit.Analyzers package reference..." -ForegroundColor Cyan
$modifiedCsprojFiles = @()

foreach ($project in $testProjects) {
    $csprojContent = Get-Content -Path $project.FullName -Raw
    
    # Check if has NUnit but not NUnit.Analyzers
    if (($csprojContent -match '<PackageReference\s+Include="NUnit"') -and 
        ($csprojContent -notmatch '<PackageReference\s+Include="NUnit\.Analyzers"')) {
        
        $pattern = '(<PackageReference\s+Include="NUnit"[^/]*/?>)'
        $replacement = "`$1`n    <PackageReference Include=`"NUnit.Analyzers`" />"
        $csprojContent = $csprojContent -replace $pattern, $replacement
        
        Set-Content -Path $project.FullName -Value $csprojContent -NoNewline
        $modifiedCsprojFiles += $project.FullName
        Write-Host "  ✓ Added to: $($project.Name)" -ForegroundColor Green
    }
}

Write-Host ""

# Step 2: Run dotnet format with NUnit.Analyzers fixers
Write-Host "Step 2: Running dotnet format with NUnit.Analyzers fixers..." -ForegroundColor Cyan
Write-Host "This will automatically fix NUnit 3 to NUnit 4 code issues" -ForegroundColor Gray
Write-Host ""

# Safe diagnostic IDs - classic assertion conversions
$DiagnosticIds = @(
    "NUnit2001", "NUnit2002", "NUnit2003", "NUnit2004", "NUnit2005", "NUnit2006", "NUnit2007",
    "NUnit2010",
    "NUnit2015", "NUnit2016", "NUnit2017", "NUnit2018", "NUnit2019",
    "NUnit2021", "NUnit2023", "NUnit2024", "NUnit2025",
    "NUnit2027", "NUnit2028", "NUnit2029", "NUnit2030", "NUnit2031", "NUnit2032", "NUnit2033",
    "NUnit2034", "NUnit2035", "NUnit2036", "NUnit2037", "NUnit2038", "NUnit2039",
    "NUnit2048", "NUnit2049", "NUnit2050"
)

$editorConfigPath = Join-Path $sdkPath ".editorconfig"

foreach ($diagnosticId in $DiagnosticIds) {
    Write-Host "  Processing diagnostic: $diagnosticId" -ForegroundColor White
    
    # Create .editorconfig for this diagnostic
    $editorConfigContent = @"
[*.cs]

dotnet_diagnostic.$diagnosticId.severity = warning
"@
    Set-Content -Path $editorConfigPath -Value $editorConfigContent
    
    # Run dotnet format for each project
    foreach ($project in $testProjects) {
        $formatArgs = @(
            "format",
            $project.FullName,
            "--diagnostics", $diagnosticId,
            "--severity", "info",
            "--verbosity", "quiet"
        )
        
        $output = & dotnet @formatArgs 2>&1 | Out-Null
    }
    
    # Remove .editorconfig
    Remove-Item $editorConfigPath -ErrorAction SilentlyContinue
}

Write-Host "  ✓ Completed all diagnostics" -ForegroundColor Green

Write-Host ""

# Step 3: Revert modified csproj files
Write-Host "Step 3: Reverting modified csproj files..." -ForegroundColor Cyan

if ($modifiedCsprojFiles.Count -gt 0) {
    foreach ($csprojFile in $modifiedCsprojFiles) {
        git checkout origin/main $csprojFile 2>&1 | Out-Null
        Write-Host "  ↺ Reverted: $(Split-Path $csprojFile -Leaf)" -ForegroundColor Yellow
    }
} else {
    Write-Host "  No csproj files to revert" -ForegroundColor Gray
}

Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Migration Complete!" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "Next steps:" -ForegroundColor White
Write-Host "  1. Review changes with: git diff" -ForegroundColor Gray
Write-Host "  2. Create sdk/$ServiceDirectory/Directory.Packages.props with NUnit 4.4.0 override" -ForegroundColor Gray
Write-Host "  3. Build the projects: dotnet build" -ForegroundColor Gray
Write-Host "  4. Run tests: dotnet test" -ForegroundColor Gray
Write-Host "  5. Address any remaining build errors or test failures" -ForegroundColor Gray
Write-Host ""

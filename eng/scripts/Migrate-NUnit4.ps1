<#
.SYNOPSIS
Migrates test projects from NUnit 3 to NUnit 4 using NUnit.Analyzers

.DESCRIPTION
This script automates code changes required for NUnit 4 migration based on:
https://docs.nunit.org/articles/nunit/release-notes/Nunit4.0-MigrationGuide.html

The script:
1. Finds ALL test projects (any csproj with NUnit reference) across all specified services
2. Adds NUnit.Analyzers package reference to data plane test projects
3. Runs dotnet format with NUnit.Analyzers fixers to automatically migrate code
4. Reverts csproj files with only whitespace changes

.PARAMETER ServiceDirectories
Array of service directories to migrate (e.g., @("core", "storage", "keyvault"))

.EXAMPLE
.\Migrate-NUnit4.ps1 -ServiceDirectories @("core", "storage")

.EXAMPLE
.\Migrate-NUnit4.ps1 -ServiceDirectories @("core", "template", "storage", "keyvault", "identity")

.NOTES
You must manually update central package versions after running this script.
Do NOT commit changes until you've added the NUnit 4.x version override.
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory=$true)]
    [string[]]$ServiceDirectories
)

$ErrorActionPreference = 'Stop'
$repoRoot = Resolve-Path "$PSScriptRoot/../.."

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "NUnit 4 Migration" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Services: $($ServiceDirectories -join ', ')" -ForegroundColor White
Write-Host ""

# Find all test projects across all service directories
Write-Host "Scanning for test projects..." -ForegroundColor Gray
$allTestProjects = @()
$invalidDirs = @()

foreach ($serviceDir in $ServiceDirectories) {
    $sdkPath = Join-Path $repoRoot "sdk" $serviceDir
    
    if (-not (Test-Path $sdkPath)) {
        $invalidDirs += $serviceDir
        continue
    }
    
    # Find ALL csproj files and check if they reference NUnit
    $csprojFiles = Get-ChildItem -Path $sdkPath -Filter "*.csproj" -Recurse
    foreach ($csproj in $csprojFiles) {
        $content = Get-Content -Path $csproj.FullName -Raw
        if ($content -match '<PackageReference\s+Include="NUnit"') {
            $allTestProjects += $csproj
        }
    }
}

if ($invalidDirs.Count -gt 0) {
    Write-Warning "Service directories not found: $($invalidDirs -join ', ')"
}

Write-Host "Found $($allTestProjects.Count) test projects across all services" -ForegroundColor Green
if ($allTestProjects.Count -gt 0) {
    Write-Host ""
    Write-Host "Test projects:" -ForegroundColor Gray
    foreach ($proj in $allTestProjects) {
        $relativePath = $proj.FullName.Substring($repoRoot.Path.Length + 1)
        Write-Host "  - $relativePath" -ForegroundColor DarkGray
    }
}
Write-Host ""

if ($allTestProjects.Count -eq 0) {
    Write-Warning "No test projects found"
    exit 0
}

# Step 1: Add NUnit.Analyzers to data plane test projects
Write-Host "Step 1: Adding NUnit.Analyzers package reference..." -ForegroundColor Cyan
$modifiedCsprojFiles = @()

foreach ($project in $allTestProjects) {
    $csprojContent = Get-Content -Path $project.FullName -Raw
    
    # Check if has NUnit but not NUnit.Analyzers
    if (($csprojContent -match '<PackageReference\s+Include="NUnit"') -and 
        ($csprojContent -notmatch '<PackageReference\s+Include="NUnit\.Analyzers"')) {
        
        $pattern = '(<PackageReference\s+Include="NUnit"[^/]*/?>)'
        $replacement = "`$1`n    <PackageReference Include=`"NUnit.Analyzers`" />"
        $csprojContent = $csprojContent -replace $pattern, $replacement
        
        Set-Content -Path $project.FullName -Value $csprojContent -NoNewline
        $modifiedCsprojFiles += $project.FullName
        
        $relativePath = $project.FullName.Substring($repoRoot.Path.Length + 1)
        Write-Host "  ✓ $relativePath" -ForegroundColor Green
    }
}

Write-Host "Modified $($modifiedCsprojFiles.Count) projects" -ForegroundColor Gray
Write-Host ""

# Step 2: Run dotnet format with NUnit.Analyzers fixers
Write-Host "Step 2: Running dotnet format with NUnit.Analyzers fixers..." -ForegroundColor Cyan
Write-Host "Processing $($allTestProjects.Count) projects with NUnit migration diagnostics" -ForegroundColor Gray
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

# Create temporary .editorconfig files for each service directory
$editorConfigs = @()
foreach ($serviceDir in $ServiceDirectories) {
    $sdkPath = Join-Path $repoRoot "sdk" $serviceDir
    if (Test-Path $sdkPath) {
        $editorConfigs += $sdkPath
    }
}

$progressCounter = 0
$totalOperations = $DiagnosticIds.Count

foreach ($diagnosticId in $DiagnosticIds) {
    $progressCounter++
    Write-Host "  [$progressCounter/$totalOperations] Processing diagnostic: $diagnosticId" -ForegroundColor White
    
    # Create .editorconfig for each service directory
    foreach ($configPath in $editorConfigs) {
        $editorConfigFile = Join-Path $configPath ".editorconfig"
        $editorConfigContent = @"
[*.cs]

dotnet_diagnostic.$diagnosticId.severity = warning
"@
        Set-Content -Path $editorConfigFile -Value $editorConfigContent
    }
    
    # Run dotnet format for all projects in parallel
    $allTestProjects | ForEach-Object -Parallel {
        $project = $_
        $diagnosticId = $using:diagnosticId
        
        $formatArgs = @(
            "format",
            $project.FullName,
            "--diagnostics", $diagnosticId,
            "--severity", "info",
            "--verbosity", "quiet"
        )
        
        & dotnet @formatArgs 2>&1 | Out-Null
    } -ThrottleLimit 20
    
    # Remove .editorconfig files
    foreach ($configPath in $editorConfigs) {
        $editorConfigFile = Join-Path $configPath ".editorconfig"
        Remove-Item $editorConfigFile -ErrorAction SilentlyContinue
    }
}

Write-Host "  ✓ Completed all diagnostics for all projects" -ForegroundColor Green
Write-Host ""

# Step 3: Revert modified csproj files
Write-Host "Migrated $($allTestProjects.Count) test projects across services:" -ForegroundColor White
Write-Host "  $($ServiceDirectories -join ', ')" -ForegroundColor Gray
Write-Host ""
Write-Host "Next steps:" -ForegroundColor White
Write-Host "  1. Review changes with: git diff" -ForegroundColor Gray
Write-Host "  2. Update eng/Packages.Data.props with NUnit 4.4.0 override for these services
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

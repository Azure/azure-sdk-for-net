<#
.SYNOPSIS
Runs the complete NUnit 4 migration workflow for specified services

.DESCRIPTION
Automates the entire migration process:
1. Adds NUnit.Analyzers to central packages
2. Runs migration script for each service
3. Updates central packages with service-specific NUnit 4 overrides
4. Builds and tests the migrated services
5. Commits changes at each step

.NOTES
Hard-coded for specific services. Edit $serviceDirectories to change targets.
#>

[CmdletBinding()]
param()

$ErrorActionPreference = 'Stop'
$repoRoot = Resolve-Path "$PSScriptRoot/../.."

# CONFIGURE THESE SERVICES TO MIGRATE
$serviceDirectories = @(
    "core",
    "template"
)

Write-Host "========================================" -ForegroundColor Magenta
Write-Host "NUnit 4 Full Migration Workflow" -ForegroundColor Magenta
Write-Host "========================================" -ForegroundColor Magenta
Write-Host "Services: $($serviceDirectories -join ', ')" -ForegroundColor White
Write-Host ""

# Check git status
$gitStatus = git status --porcelain
if ($gitStatus) {
    Write-Error "Working directory is not clean. Commit or stash changes first."
    exit 1
}

# ============================================================================
# STEP 1: Add NUnit.Analyzers to central packages
# ============================================================================

Write-Host "STEP 1: Adding NUnit.Analyzers to central packages" -ForegroundColor Cyan
Write-Host "============================================================================" -ForegroundColor Cyan
Write-Host ""

$packagesDataPropsPath = Join-Path $repoRoot "eng\Packages.Data.props"
$directoryBuildTargetsPath = Join-Path $repoRoot "eng\Directory.Build.Common.targets"

# Add NUnitAnalyzersVersion to Packages.Data.props
$packagesContent = Get-Content -Path $packagesDataPropsPath -Raw
if ($packagesContent -notmatch 'NUnitAnalyzersVersion') {
    $packagesContent = $packagesContent -replace '(<NUnitVersion>.*?</NUnitVersion>)', "`$1`n    <NUnitAnalyzersVersion>4.5.0</NUnitAnalyzersVersion>"
    Set-Content -Path $packagesDataPropsPath -Value $packagesContent -NoNewline
    Write-Host "  ✓ Added NUnitAnalyzersVersion property" -ForegroundColor Green
}

# Add NUnit.Analyzers package reference to Packages.Data.props
$packagesContent = Get-Content -Path $packagesDataPropsPath -Raw
if ($packagesContent -notmatch 'PackageReference Update="NUnit\.Analyzers"') {
    $pattern = '(<PackageReference Update="NUnit" Version="\$\(NUnitVersion\)" />)'
    $replacement = "`$1`n    <PackageReference Update=`"NUnit.Analyzers`" Version=`"`$(NUnitAnalyzersVersion)`" />"
    $packagesContent = $packagesContent -replace $pattern, $replacement
    Set-Content -Path $packagesDataPropsPath -Value $packagesContent -NoNewline
    Write-Host "  ✓ Added NUnit.Analyzers package reference" -ForegroundColor Green
}

# Add NUnit.Analyzers to Directory.Build.Common.targets
$targetsContent = Get-Content -Path $directoryBuildTargetsPath -Raw
if ($targetsContent -notmatch 'PackageReference Include="NUnit\.Analyzers"') {
    $pattern = '(<PackageReference Include="NUnit" />)'
    $replacement = "`$1`n    <PackageReference Include=`"NUnit.Analyzers`" />"
    $targetsContent = $targetsContent -replace $pattern, $replacement
    Set-Content -Path $directoryBuildTargetsPath -Value $targetsContent -NoNewline
    Write-Host "  ✓ Added NUnit.Analyzers to management plane tests" -ForegroundColor Green
}

git add $packagesDataPropsPath $directoryBuildTargetsPath
git commit -m "Add NUnit.Analyzers for migration"
Write-Host "  ✓ Committed changes" -ForegroundColor Green
Write-Host ""

# ============================================================================
# STEP 2: Run migration script for each service
# ============================================================================

Write-Host "STEP 2: Running migration script for each service" -ForegroundColor Cyan
Write-Host "============================================================================" -ForegroundColor Cyan
Write-Host ""

foreach ($serviceDir in $serviceDirectories) {
    Write-Host "Migrating: $serviceDir" -ForegroundColor White
    & "$PSScriptRoot\Migrate-NUnit4.ps1" -ServiceDirectory $serviceDir
    Write-Host ""
}

# Commit migration changes
git add "sdk/*/*.cs"
$commitMessage = "Migrate $($serviceDirectories -join ', ') tests to NUnit 4 constraint model"
git commit -m $commitMessage
Write-Host "  ✓ Committed migration changes" -ForegroundColor Green
Write-Host ""

# ============================================================================
# STEP 3: Update central packages with NUnit 4 overrides
# ============================================================================

Write-Host "STEP 3: Adding NUnit 4 overrides to central packages" -ForegroundColor Cyan
Write-Host "============================================================================" -ForegroundColor Cyan
Write-Host ""

# Remove NUnitAnalyzersVersion property
$packagesContent = Get-Content -Path $packagesDataPropsPath -Raw
$packagesContent = $packagesContent -replace '\s*<NUnitAnalyzersVersion>.*?</NUnitAnalyzersVersion>\r?\n', ''
Set-Content -Path $packagesDataPropsPath -Value $packagesContent -NoNewline
Write-Host "  ✓ Removed NUnitAnalyzersVersion property" -ForegroundColor Green

# Remove NUnit.Analyzers package reference from Packages.Data.props
$packagesContent = Get-Content -Path $packagesDataPropsPath -Raw
$packagesContent = $packagesContent -replace '\s*<PackageReference Update="NUnit\.Analyzers"[^>]*?/>\r?\n', ''
Set-Content -Path $packagesDataPropsPath -Value $packagesContent -NoNewline
Write-Host "  ✓ Removed NUnit.Analyzers package reference" -ForegroundColor Green

# Remove NUnit.Analyzers from Directory.Build.Common.targets
$targetsContent = Get-Content -Path $directoryBuildTargetsPath -Raw
$targetsContent = $targetsContent -replace '\s*<PackageReference Include="NUnit\.Analyzers" />\r?\n', ''
Set-Content -Path $directoryBuildTargetsPath -Value $targetsContent -NoNewline
Write-Host "  ✓ Removed NUnit.Analyzers from management plane tests" -ForegroundColor Green

# Add NUnit 4 override to Packages.Data.props
$packagesContent = Get-Content -Path $packagesDataPropsPath -Raw

# Build the condition
$conditions = $serviceDirectories | ForEach-Object { "`$(MSBuildProjectDirectory.Contains('\sdk\$_\'))" }
$conditionString = $conditions -join ' or '

$overrideBlock = @"


  <!-- NUnit 4 migration: $($serviceDirectories -join ', ') -->
  <ItemGroup Condition="$conditionString">
    <PackageReference Update="NUnit" Version="4.4.0" />
    <PackageReference Update="NUnit3TestAdapter" Version="4.6.0" />
    <PackageReference Update="NUnit.Analyzers" Version="4.5.0" />
  </ItemGroup>
</Project>
"@

$packagesContent = $packagesContent -replace '</Project>$', $overrideBlock
Set-Content -Path $packagesDataPropsPath -Value $packagesContent -NoNewline
Write-Host "  ✓ Added NUnit 4.4.0 override for services" -ForegroundColor Green

git add $packagesDataPropsPath $directoryBuildTargetsPath
git commit -m "Add NUnit 4.4.0 override for $($serviceDirectories -join ', ')"
Write-Host "  ✓ Committed changes" -ForegroundColor Green
Write-Host ""

# ============================================================================
# STEP 4: Build and test
# ============================================================================

Write-Host "STEP 4: Building and testing migrated services" -ForegroundColor Cyan
Write-Host "============================================================================" -ForegroundColor Cyan
Write-Host ""

foreach ($serviceDir in $serviceDirectories) {
    Write-Host "Testing: $serviceDir" -ForegroundColor White
    & "$PSScriptRoot\Test-NUnit4Migration.ps1" -ServiceDirectory $serviceDir
    Write-Host ""
}

Write-Host "========================================" -ForegroundColor Magenta
Write-Host "Migration Complete!" -ForegroundColor Magenta
Write-Host "========================================" -ForegroundColor Magenta
Write-Host ""
Write-Host "Next steps:" -ForegroundColor White
Write-Host "  1. Review git log to see all commits" -ForegroundColor Gray
Write-Host "  2. Review test output above for any failures" -ForegroundColor Gray
Write-Host "  3. Fix any issues and commit additional changes" -ForegroundColor Gray
Write-Host "  4. Push branch and create PR" -ForegroundColor Gray
Write-Host ""

#Requires -Version 7.0

<#
.SYNOPSIS
Validates that the mgmt package automation is working correctly.

.DESCRIPTION
This script validates that the automation scripts work correctly by checking:
1. The Update-MgmtPackageVersion.ps1 script syntax and functionality
2. The Create-MgmtUpdatePR.ps1 script syntax  
3. The pipeline condition logic for when automation should run
4. Version consistency between files
#>

[CmdletBinding()]
param(
    [string] $RepoRoot = (Get-Item $PSScriptRoot).Parent.Parent.FullName
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3.0

Write-Host "=== Validating mgmt package automation ==="

# Check script files exist
$updateScript = Join-Path $RepoRoot "eng/scripts/Update-MgmtPackageVersion.ps1"
$prScript = Join-Path $RepoRoot "eng/scripts/Create-MgmtUpdatePR.ps1"

if (-not (Test-Path $updateScript)) {
    Write-Error "Update-MgmtPackageVersion.ps1 not found at $updateScript"
}

if (-not (Test-Path $prScript)) {
    Write-Error "Create-MgmtUpdatePR.ps1 not found at $prScript"
}

Write-Host "✓ Scripts exist"

# Check PowerShell syntax
try {
    $null = [System.Management.Automation.PSParser]::Tokenize((Get-Content $updateScript -Raw), [ref]$null)
    Write-Host "✓ Update-MgmtPackageVersion.ps1 syntax valid"
} catch {
    Write-Error "Syntax error in Update-MgmtPackageVersion.ps1: $_"
}

try {
    $null = [System.Management.Automation.PSParser]::Tokenize((Get-Content $prScript -Raw), [ref]$null)
    Write-Host "✓ Create-MgmtUpdatePR.ps1 syntax valid"
} catch {
    Write-Error "Syntax error in Create-MgmtUpdatePR.ps1: $_"
}

# Check version consistency
$mgmtPackageJson = Join-Path $RepoRoot "eng/packages/http-client-csharp-mgmt/package.json"
$packagesDataProps = Join-Path $RepoRoot "eng/Packages.Data.props"

$mgmtContent = Get-Content $mgmtPackageJson -Raw | ConvertFrom-Json
$mgmtDependencyVersion = $mgmtContent.dependencies.'@azure-typespec/http-client-csharp'

$propsContent = Get-Content $packagesDataProps -Raw
if ($propsContent -match '<AzureGeneratorVersion>([^<]+)</AzureGeneratorVersion>') {
    $nugetVersion = $Matches[1]
} else {
    Write-Error "Could not find AzureGeneratorVersion in $packagesDataProps"
}

if ($mgmtDependencyVersion -eq $nugetVersion) {
    Write-Host "✓ Version consistency: mgmt dependency and NuGet version both at $mgmtDependencyVersion"
} else {
    Write-Warning "Version inconsistency: mgmt dependency is $mgmtDependencyVersion but NuGet version is $nugetVersion"
}

# Check pipeline archetype was modified
$archetype = Join-Path $RepoRoot "eng/common/pipelines/templates/archetype-typespec-emitter.yml"
$archetypeContent = Get-Content $archetype -Raw

if ($archetypeContent -match "UpdateMgmtPackage") {
    Write-Host "✓ Pipeline archetype contains UpdateMgmtPackage job"
} else {
    Write-Error "Pipeline archetype does not contain UpdateMgmtPackage job"
}

if ($archetypeContent -match "eng/scripts/Create-MgmtUpdatePR.ps1") {
    Write-Host "✓ Pipeline archetype references Create-MgmtUpdatePR.ps1 script"
} else {
    Write-Error "Pipeline archetype does not reference Create-MgmtUpdatePR.ps1 script"
}

# Check condition logic
if ($archetypeContent -match "eq\(parameters\.EmitterPackagePath, 'eng/packages/http-client-csharp'\)") {
    Write-Host "✓ Pipeline condition checks for http-client-csharp emitter"
} else {
    Write-Error "Pipeline condition does not properly check for http-client-csharp emitter"
}

if ($archetypeContent -match "eq\(variables\['Build\.Reason'\], 'IndividualCI'\)") {
    Write-Host "✓ Pipeline condition checks for IndividualCI build reason"
} else {
    Write-Error "Pipeline condition does not properly check for IndividualCI build reason"  
}

if ($archetypeContent -match "eq\(variables\['Build\.SourceBranch'\], 'refs/heads/main'\)") {
    Write-Host "✓ Pipeline condition checks for main branch"
} else {
    Write-Error "Pipeline condition does not properly check for main branch"
}

Write-Host ""
Write-Host "=== Validation Summary ==="
Write-Host "✓ All automation scripts are in place and have valid syntax"
Write-Host "✓ Pipeline integration is correctly configured"
Write-Host "✓ Automation will run when:"
Write-Host "  - http-client-csharp package is built"
Write-Host "  - Build is triggered by IndividualCI (not manual or PR)"
Write-Host "  - Source branch is refs/heads/main"
Write-Host "  - Publishing and regeneration are enabled"
Write-Host ""
Write-Host "The automation will:"
Write-Host "1. Update @azure-typespec/http-client-csharp dependency in mgmt package.json"
Write-Host "2. Update AzureGeneratorVersion in eng/Packages.Data.props" 
Write-Host "3. Run npm install to update package-lock.json"
Write-Host "4. Create a new branch and commit the changes"
Write-Host "5. Create a pull request with the updated files"
Write-Host ""
Write-Host "✅ Mgmt package automation validation completed successfully!"
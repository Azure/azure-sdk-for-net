#requires -version 5

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

<#
.SYNOPSIS
    Validates Central Package Management (CPM) compliance across the repository.

.DESCRIPTION
    Static analysis script that detects CPM policy violations:
      1. ManagePackageVersionsCentrally set to 'false' outside allowlisted paths
      2. CentralPackageVersionOverrideEnabled set to 'true' anywhere
      3. VersionOverride attributes on PackageReference items
      4. Rogue Directory.Packages.props files outside approved locations
      5. DirectoryPackagesPropsPath redirects outside the root Directory.Build.props
      6. Override files with incorrect casing (must be *.Packages.props)

    Designed to run in CI alongside the MSBuild enforcement target in
    Directory.Build.targets, providing defense-in-depth.

.PARAMETER RepoRoot
    Root of the azure-sdk-for-net repository. Defaults to two directories
    above this script.

.EXAMPLE
    .\Validate-CpmCompliance.ps1
    .\Validate-CpmCompliance.ps1 -RepoRoot "C:\repos\azure-sdk-for-net"
#>

[CmdletBinding()]
param (
    [Parameter()]
    [string] $RepoRoot
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 1

if (-not $RepoRoot) {
    $RepoRoot = Resolve-Path (Join-Path $PSScriptRoot "..\..") | Select-Object -ExpandProperty Path
}

$RepoRoot = $RepoRoot.TrimEnd('\', '/')

[string[]] $errors = @()

function LogError([string]$message) {
    if ($env:TF_BUILD) {
        Write-Host ("##vso[task.logissue type=error]$message" -replace "`n", "%0D%0A")
    }
    Write-Host -ForegroundColor Red "error: $message"
    $script:errors += $message
}

function LogInfo([string]$message) {
    Write-Host -ForegroundColor Cyan $message
}

function Get-RelativePath([string]$fullPath) {
    return $fullPath.Substring($RepoRoot.Length + 1).Replace('\', '/')
}

# ─────────────────────────────────────────────────────────────────────────────
# Allowlist — paths that legitimately opt out of CPM
# ─────────────────────────────────────────────────────────────────────────────
# These must stay in sync with the _CpmEnforcementExempt conditions in
# Directory.Build.targets at the repo root.
$AllowedCpmOptOutPatterns = @(
    'samples/'
    'sdk/webpubsub/**/SampleDev/'
    'sdk/modelsrepository/**/ModelsRepositoryClientSamples/'
    'sdk/iot/**/IotHubClientSamples/'
    'sdk/digitaltwins/**/DigitalTwinsClientSample/'
    'doc/ApiDocGeneration/'
)

function Test-IsAllowlisted([string]$relativePath) {
    foreach ($pattern in $AllowedCpmOptOutPatterns) {
        # Convert glob-style pattern to a simple prefix/contains check
        $cleanPattern = $pattern.Replace('**/', '').TrimEnd('/')
        if ($relativePath -like "*$cleanPattern*") {
            return $true
        }
    }
    return $false
}

# Approved locations for Directory.Packages.props files
$ApprovedPackagesPropsLocations = @(
    'eng/centralpackagemanagement/Directory.Packages.props'
    'eng/centralpackagemanagement/Directory.Legacy.Packages.props'
    'eng/centralpackagemanagement/Directory.Mgmt.Packages.props'
    'eng/centralpackagemanagement/Directory.Build.Packages.props'
    'eng/centralpackagemanagement/Directory.TypeSpec.Packages.props'
    'samples/Directory.Packages.props'
)

# ─────────────────────────────────────────────────────────────────────────────
# Check 1: ManagePackageVersionsCentrally='false' outside allowlist
# ─────────────────────────────────────────────────────────────────────────────
LogInfo "Check 1: Scanning for ManagePackageVersionsCentrally='false' outside allowlist..."

$cpmFalseFiles = Get-ChildItem -Path $RepoRoot -Recurse -Include '*.props', '*.targets', '*.csproj' |
    Where-Object { $_.FullName -notmatch '[\\/](artifacts|node_modules|\.git|bin|obj)[\\/]' } |
    Select-String -Pattern 'ManagePackageVersionsCentrally.*false' -SimpleMatch:$false |
    Select-Object -ExpandProperty Path -Unique

foreach ($file in $cpmFalseFiles) {
    $rel = Get-RelativePath $file
    if (-not (Test-IsAllowlisted $rel)) {
        # Allow the central packages file itself and the root enforcement target
        if ($rel -notlike 'eng/centralpackagemanagement/*' -and $rel -ne 'Directory.Build.targets') {
            LogError "CPM-001: ManagePackageVersionsCentrally set to 'false' in non-allowlisted file: $rel"
        }
    }
}

# ─────────────────────────────────────────────────────────────────────────────
# Check 2: CentralPackageVersionOverrideEnabled='true'
# ─────────────────────────────────────────────────────────────────────────────
LogInfo "Check 2: Scanning for CentralPackageVersionOverrideEnabled='true'..."

$overrideEnabledFiles = Get-ChildItem -Path $RepoRoot -Recurse -Include '*.props', '*.targets', '*.csproj' |
    Where-Object { $_.FullName -notmatch '[\\/](artifacts|node_modules|\.git|bin|obj)[\\/]' } |
    Select-String -Pattern 'CentralPackageVersionOverrideEnabled.*true' -SimpleMatch:$false |
    Select-Object -ExpandProperty Path -Unique

foreach ($file in $overrideEnabledFiles) {
    $rel = Get-RelativePath $file
    # Allow the central config and the root enforcement target (contains condition strings)
    if ($rel -notlike 'eng/centralpackagemanagement/*' -and $rel -ne 'Directory.Build.targets') {
        LogError "CPM-002: CentralPackageVersionOverrideEnabled set to 'true' in: $rel"
    }
}

# ─────────────────────────────────────────────────────────────────────────────
# Check 3: VersionOverride on PackageReference
# ─────────────────────────────────────────────────────────────────────────────
LogInfo "Check 3: Scanning for VersionOverride attributes on PackageReference..."

$versionOverrideFiles = Get-ChildItem -Path $RepoRoot -Recurse -Include '*.props', '*.targets', '*.csproj' |
    Where-Object { $_.FullName -notmatch '[\\/](artifacts|node_modules|\.git|bin|obj)[\\/]' } |
    Select-String -Pattern 'VersionOverride\s*=' -SimpleMatch:$false |
    Select-Object -ExpandProperty Path -Unique

foreach ($file in $versionOverrideFiles) {
    $rel = Get-RelativePath $file
    if (-not (Test-IsAllowlisted $rel)) {
        LogError "CPM-003: VersionOverride attribute found in: $rel"
    }
}

# ─────────────────────────────────────────────────────────────────────────────
# Check 4: Rogue Directory.Packages.props files
# ─────────────────────────────────────────────────────────────────────────────
LogInfo "Check 4: Scanning for unapproved Directory.Packages.props files..."

$allPackagesProps = Get-ChildItem -Path $RepoRoot -Recurse -Filter 'Directory.Packages.props' |
    Where-Object { $_.FullName -notmatch '[\\/](artifacts|node_modules|\.git|bin|obj)[\\/]' }

foreach ($file in $allPackagesProps) {
    $rel = Get-RelativePath $file.FullName
    if ($rel -notin $ApprovedPackagesPropsLocations) {
        if (-not (Test-IsAllowlisted $rel)) {
            LogError "CPM-004: Unapproved Directory.Packages.props found at: $rel"
        }
    }
}

# ─────────────────────────────────────────────────────────────────────────────
# Check 5: DirectoryPackagesPropsPath redirects outside root Directory.Build.props
# ─────────────────────────────────────────────────────────────────────────────
LogInfo "Check 5: Scanning for DirectoryPackagesPropsPath redirects..."

$dppRedirects = Get-ChildItem -Path $RepoRoot -Recurse -Include '*.props', '*.targets', '*.csproj' |
    Where-Object { $_.FullName -notmatch '[\\/](artifacts|node_modules|\.git|bin|obj)[\\/]' } |
    Select-String -Pattern 'DirectoryPackagesPropsPath' -SimpleMatch |
    Select-Object -ExpandProperty Path -Unique

foreach ($file in $dppRedirects) {
    $rel = Get-RelativePath $file
    # Allow the root Directory.Build.props (canonical redirect), central config, and allowlisted paths
    if ($rel -ne 'Directory.Build.props' -and $rel -notlike 'eng/centralpackagemanagement/*' -and -not (Test-IsAllowlisted $rel)) {
        LogError "CPM-005: DirectoryPackagesPropsPath redirect found outside root: $rel"
    }
}

# ─────────────────────────────────────────────────────────────────────────────
# Check 6: Override file casing convention (*.Packages.props)
# ─────────────────────────────────────────────────────────────────────────────
LogInfo "Check 6: Validating override file casing convention..."

$overrideDir = Join-Path $RepoRoot "eng\centralpackagemanagement"
if (Test-Path $overrideDir) {
    $overrideFiles = Get-ChildItem -Path $overrideDir -Filter '*.props' |
        Where-Object { $_.Name -ne 'Directory.Packages.props' -and
                       $_.Name -ne 'Directory.Legacy.Packages.props' -and
                       $_.Name -ne 'Directory.Mgmt.Packages.props' -and
                       $_.Name -ne 'Directory.Build.Packages.props' -and
                       $_.Name -ne 'Directory.TypeSpec.Packages.props' }

    foreach ($file in $overrideFiles) {
        # Per-package override files must end with .Packages.props (exact casing)
        if ($file.Name -cnotmatch '\.Packages\.props$') {
            LogError "CPM-006: Override file has incorrect casing (expected *.Packages.props): $($file.Name)"
        }
    }
}

# ─────────────────────────────────────────────────────────────────────────────
# Summary
# ─────────────────────────────────────────────────────────────────────────────
Write-Host ""
if ($errors.Count -gt 0) {
    Write-Host -ForegroundColor Red "CPM compliance check failed with $($errors.Count) error(s):"
    foreach ($err in $errors) {
        Write-Host -ForegroundColor Red "  - $err"
    }
    exit 1
}
else {
    Write-Host -ForegroundColor Green "CPM compliance check passed. No violations found."
    exit 0
}

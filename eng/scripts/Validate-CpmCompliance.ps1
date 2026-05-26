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

    Requires either -ServiceDirectory or -PackagePath to scope the scan.
#>

[CmdletBinding()]
param (
    [Parameter(Position=0)]
    [string] $ServiceDirectory,

    [Parameter()]
    [string] $PackagePath
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 1

$RepoRoot = (Resolve-Path (Join-Path $PSScriptRoot "..\..")).Path.TrimEnd('\', '/')

if (-not $PackagePath -and -not $ServiceDirectory) {
    Write-Host -ForegroundColor Red "Either -ServiceDirectory or -PackagePath must be specified."
    exit 1
}

if ($PackagePath) {
    $ScanPath = Join-Path $RepoRoot $PackagePath
    if (-not (Test-Path $ScanPath)) {
        Write-Host -ForegroundColor Red "Package path not found: $ScanPath"
        exit 1
    }
    Write-Host "Running checks on package: $PackagePath"
}
else {
    $ScanPath = Join-Path $RepoRoot "sdk" $ServiceDirectory
    if (-not (Test-Path $ScanPath)) {
        Write-Host -ForegroundColor Red "Service directory not found: $ScanPath"
        exit 1
    }
    Write-Host "Running checks on service directory: $ServiceDirectory"
}

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

$AllowedCpmOptOutPatterns = @(
    'samples/'
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

$allFiles = Get-ChildItem -Path $ScanPath -Recurse -Include '*.props', '*.targets', '*.csproj' |
    Where-Object { $_.FullName -notmatch '[\\\\|/](artifacts|node_modules|\.git|bin|obj)[\\|/]' }
LogInfo "Found $($allFiles.Count) files to scan."

# ─────────────────────────────────────────────────────────────────────────────
# Check 1: ManagePackageVersionsCentrally='false'
# ─────────────────────────────────────────────────────────────────────────────
LogInfo "Checking for ManagePackageVersionsCentrally='false'"

$cpmFalseFiles = $allFiles |
    Select-String -Pattern 'ManagePackageVersionsCentrally.*false' |
    Select-Object -ExpandProperty Path -Unique

foreach ($file in $cpmFalseFiles) {
    $rel = Get-RelativePath $file
    if (-not (Test-IsAllowlisted $rel)) {
        # Allow the central packages file itself and the enforcement target (contains condition strings)
        if ($rel -notlike 'eng/centralpackagemanagement/*' -and $rel -ne 'eng/Directory.Build.Common.targets') {
            LogError "CPM-001: ManagePackageVersionsCentrally set to 'false' in non-allowlisted file: $rel"
        }
    }
}

# ─────────────────────────────────────────────────────────────────────────────
# Check 2: CentralPackageVersionOverrideEnabled='true'
# ─────────────────────────────────────────────────────────────────────────────
LogInfo "Checking for CentralPackageVersionOverrideEnabled='true'"
$overrideEnabledFiles = $allFiles |
    Select-String -Pattern 'CentralPackageVersionOverrideEnabled.*true' |
    Select-Object -ExpandProperty Path -Unique

foreach ($file in $overrideEnabledFiles) {
    $rel = Get-RelativePath $file
    # Allow the central config and the enforcement target (contains condition strings)
    if ($rel -notlike 'eng/centralpackagemanagement/*' -and $rel -ne 'eng/Directory.Build.Common.targets') {
        LogError "CPM-002: CentralPackageVersionOverrideEnabled set to 'true' in: $rel"
    }
}

# ─────────────────────────────────────────────────────────────────────────────
# Check 3: VersionOverride on PackageReference
# ─────────────────────────────────────────────────────────────────────────────
LogInfo "Checking for VersionOverride attributes on PackageReference"

$versionOverrideFiles = $allFiles |
    Select-String -Pattern 'VersionOverride\s*=' |
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
LogInfo "Checking for rogue Directory.Packages.props files"

$allPackagesProps = $allFiles | Where-Object { $_.Name -eq 'Directory.Packages.props' }

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
LogInfo "Checking for DirectoryPackagesPropsPath redirects"

$dppRedirects = $allFiles |
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
LogInfo "Checking for override file casing convention"

$overrideDir = Join-Path $RepoRoot "eng\centralpackagemanagement\overrides"
if (Test-Path $overrideDir) {
    $overrideFiles = Get-ChildItem -Path $overrideDir -Recurse -Filter '*.props'

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

#Requires -Version 7.0
<#
.SYNOPSIS
    Generates the emitter version dependency dashboard (doc/GeneratorVersions/Emitter_Version_Dashboard.md).

.DESCRIPTION
    Reads version information from the emitter package.json files and queries the npm
    registry for the latest published versions, to produce a checked-in Markdown
    dashboard showing the dependency chain across all C# TypeSpec emitters.

    Run this script whenever emitter dependency versions change to keep the dashboard
    up to date. Requires network access to query the npm registry.

.EXAMPLE
    ./doc/GeneratorVersions/Emitter_Version_Dashboard.ps1
#>

param(
    [string]$RepoRoot = (Resolve-Path (Join-Path $PSScriptRoot ".." "..")).Path,
    [string]$OutputPath
)

if (-not $OutputPath) {
    $OutputPath = Join-Path $RepoRoot "doc" "GeneratorVersions" "Emitter_Version_Dashboard.md"
}

# --- Helpers ---

function Get-NpmDependencyVersion([string]$PackageJsonPath, [string]$PackageName) {
    $json = Get-Content $PackageJsonPath -Raw | ConvertFrom-Json
    $version = $json.dependencies.$PackageName
    if (-not $version) {
        $version = $json.peerDependencies.$PackageName
    }
    return $version
}

function Get-PackageJsonVersion([string]$PackageJsonPath) {
    $json = Get-Content $PackageJsonPath -Raw | ConvertFrom-Json
    return $json.version
}

function Get-NpmLatestVersion([string]$PackageName) {
    try {
        $result = npm view $PackageName dist-tags.latest 2>&1
        if ($LASTEXITCODE -eq 0 -and $result) {
            return ($result | Out-String).Trim()
        }
    } catch {}
    return "unavailable"
}

function Get-NpmVersionLink([string]$PackageName, [string]$Version) {
    return "https://www.npmjs.com/package/$PackageName/v/$Version"
}

function Get-ShortVersion([string]$Version) {
    if ($Version -match 'alpha\.(\d{4})(\d{2})(\d{2})\.(\d+)$') {
        return "alpha.$($Matches[1])$($Matches[2])$($Matches[3]).$($Matches[4])"
    }
    return $Version
}

# --- Gather emitter (npm) versions ---

$azureEmitterPkg   = Join-Path $RepoRoot "eng" "packages" "http-client-csharp" "package.json"
$mgmtEmitterPkg    = Join-Path $RepoRoot "eng" "packages" "http-client-csharp-mgmt" "package.json"
$provEmitterPkg    = Join-Path $RepoRoot "eng" "packages" "http-client-csharp-provisioning" "package.json"

$azureEmitterVersion   = Get-PackageJsonVersion $azureEmitterPkg
$mgmtEmitterVersion    = Get-PackageJsonVersion $mgmtEmitterPkg
$provEmitterVersion    = Get-PackageJsonVersion $provEmitterPkg

$baseDep_azure   = Get-NpmDependencyVersion $azureEmitterPkg "@typespec/http-client-csharp"
$azureDep_mgmt   = Get-NpmDependencyVersion $mgmtEmitterPkg "@azure-typespec/http-client-csharp"
$mgmtDep_prov    = Get-NpmDependencyVersion $provEmitterPkg "@azure-typespec/http-client-csharp-mgmt"

# --- Query npm registry for latest published versions ---

Write-Host "Querying npm registry for latest published versions..."
$latestBase  = Get-NpmLatestVersion "@typespec/http-client-csharp"
$latestAzure = Get-NpmLatestVersion "@azure-typespec/http-client-csharp"
$latestMgmt  = Get-NpmLatestVersion "@azure-typespec/http-client-csharp-mgmt"
$latestProv  = Get-NpmLatestVersion "@azure-typespec/http-client-csharp-provisioning"

# --- Build version links ---

$linkBaseDep    = Get-NpmVersionLink "@typespec/http-client-csharp" $baseDep_azure
$linkAzureDep   = Get-NpmVersionLink "@azure-typespec/http-client-csharp" $azureDep_mgmt
$linkMgmtDep    = Get-NpmVersionLink "@azure-typespec/http-client-csharp-mgmt" $mgmtDep_prov

$linkLatestBase  = Get-NpmVersionLink "@typespec/http-client-csharp" $latestBase
$linkLatestAzure = Get-NpmVersionLink "@azure-typespec/http-client-csharp" $latestAzure
$linkLatestMgmt  = Get-NpmVersionLink "@azure-typespec/http-client-csharp-mgmt" $latestMgmt
$linkLatestProv  = Get-NpmVersionLink "@azure-typespec/http-client-csharp-provisioning" $latestProv

# --- Resolve the git commit that corresponds to each dependency version ---
# We query the npm registry for the exact publish timestamp of each dependency
# version, then find the last commit to the source directory before that time.
# This is more accurate than deriving a date from the version string, because
# the version date can differ from the actual publish date and end-of-day
# timestamps could pick up commits made after the CI build.

Write-Host "Resolving git commits for dependency versions..."

function Get-NpmPublishTime([string]$PackageName, [string]$Version) {
    try {
        $encodedName = $PackageName -replace '/', '%2F'
        $response = Invoke-RestMethod -Uri "https://registry.npmjs.org/$encodedName" -Method Get -ErrorAction Stop
        $publishTime = $response.time.$Version
        if ($publishTime) {
            if ($publishTime -is [DateTime]) {
                return $publishTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")
            }
            return $publishTime
        }
    } catch {}
    return $null
}

function Get-VersionTimestamp([string]$PackageName, [string]$Version) {
    # Prefer the exact publish timestamp from npm
    if ($PackageName) {
        $publishTime = Get-NpmPublishTime $PackageName $Version
        if ($publishTime) { return $publishTime }
    }
    # Fall back to end-of-day derived from the version string
    if ($Version -match '(\d{4})(\d{2})(\d{2})\.\d+$') {
        return "$($Matches[1])-$($Matches[2])-$($Matches[3])T23:59:59Z"
    }
    return $null
}

function Get-CommitForVersion([string]$RepoRoot, [string]$RelativePath, [string]$Version,
    [string]$PackageName, [string]$GitHubOwner, [string]$GitHubRepo) {
    $until = Get-VersionTimestamp $PackageName $Version
    if (-not $until) { return @{ Hash = $null; Short = "unknown" } }
    # Try local git log first (works with full clones)
    $hash = git -C $RepoRoot log --until="$until" -1 --format="%H" -- $RelativePath 2>$null
    # Fall back to GitHub API when local history is unavailable (e.g. shallow clones)
    if (-not $hash -and $GitHubOwner -and $GitHubRepo) {
        return Get-CommitForVersionGitHub $GitHubOwner $GitHubRepo $RelativePath $until
    }
    $shortHash = if ($hash) { $hash.Substring(0, 7) } else { "unknown" }
    return @{ Hash = $hash; Short = $shortHash }
}

function Get-CommitForVersionGitHub([string]$Owner, [string]$Repo, [string]$Path, [string]$Until) {
    if (-not $Until) { return @{ Hash = $null; Short = "unknown" } }
    try {
        $encodedPath = [System.Uri]::EscapeDataString($Path)
        $hash = gh api "repos/$Owner/$Repo/commits?path=$encodedPath&until=$Until&per_page=1" --jq ".[0].sha" 2>$null
        if (-not $hash -or $hash -eq "null") {
            return @{ Hash = $null; Short = "unknown" }
        }
        $shortHash = $hash.Substring(0, 7)
        return @{ Hash = $hash; Short = $shortHash }
    } catch {
        return @{ Hash = $null; Short = "unknown" }
    }
}

# @typespec/http-client-csharp is from microsoft/typespec
$untilBase = Get-VersionTimestamp "@typespec/http-client-csharp" $baseDep_azure
$commitBase = Get-CommitForVersionGitHub "microsoft" "typespec" "packages/http-client-csharp" $untilBase
$commitBaseLink = if ($commitBase.Hash) { "https://github.com/microsoft/typespec/commit/$($commitBase.Hash)" } else { $null }

# Azure packages are from this repo
$commitAzure = Get-CommitForVersion $RepoRoot "eng/packages/http-client-csharp" $azureDep_mgmt "@azure-typespec/http-client-csharp" "Azure" "azure-sdk-for-net"
$commitMgmt  = Get-CommitForVersion $RepoRoot "eng/packages/http-client-csharp-mgmt" $mgmtDep_prov "@azure-typespec/http-client-csharp-mgmt" "Azure" "azure-sdk-for-net"

# Always link to the canonical Azure SDK for .NET repository
$gitBaseUrl = "https://github.com/Azure/azure-sdk-for-net"

$commitLinkAzure = if ($commitAzure.Hash) { "$gitBaseUrl/commit/$($commitAzure.Hash)" } else { $null }
$commitLinkMgmt  = if ($commitMgmt.Hash)  { "$gitBaseUrl/commit/$($commitMgmt.Hash)" } else { $null }

# --- Build Markdown ---

$timestamp = Get-Date -Format "yyyy-MM-dd HH:mm:ss UTC" -AsUTC

$md = @"
# Emitter Version Dashboard

> **Auto-generated** by ``Emitter_Version_Dashboard`` on $timestamp.
> Run that script to refresh this file after dependency version changes.

## Dependency Chain

``````
@typespec/http-client-csharp ($(Get-ShortVersion $latestBase))
  └─ @azure-typespec/http-client-csharp ($(Get-ShortVersion $latestAzure))
       └─ @azure-typespec/http-client-csharp-mgmt ($(Get-ShortVersion $latestMgmt))
            └─ @azure-typespec/http-client-csharp-provisioning ($(Get-ShortVersion $latestProv))
``````

## Emitter Versions

| Emitter | Depends On | Dependency Version | Latest on npm | Dependency Commit |
|---|---|---|---|---|
| ``@azure-typespec/http-client-csharp`` | ``@typespec/http-client-csharp`` | [$baseDep_azure]($linkBaseDep) | [$latestBase]($linkLatestBase) | $(if ($commitBaseLink) { "[$($commitBase.Short)]($commitBaseLink)" } else { $commitBase.Short }) |
| ``@azure-typespec/http-client-csharp-mgmt`` | ``@azure-typespec/http-client-csharp`` | [$azureDep_mgmt]($linkAzureDep) | [$latestAzure]($linkLatestAzure) | $(if ($commitLinkAzure) { "[$($commitAzure.Short)]($commitLinkAzure)" } else { $commitAzure.Short }) |
| ``@azure-typespec/http-client-csharp-provisioning`` | ``@azure-typespec/http-client-csharp-mgmt`` | [$mgmtDep_prov]($linkMgmtDep) | [$latestMgmt]($linkLatestMgmt) | $(if ($commitLinkMgmt) { "[$($commitMgmt.Short)]($commitLinkMgmt)" } else { $commitMgmt.Short }) |

## Source Files

These are the files where versions are defined:

| File | What it controls |
|---|---|
| [eng/packages/http-client-csharp/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/package.json) | Azure emitter's dependency on ``@typespec/http-client-csharp`` |
| [eng/packages/http-client-csharp-mgmt/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/package.json) | Mgmt emitter's dependency on ``@azure-typespec/http-client-csharp`` |
| [eng/packages/http-client-csharp-provisioning/package.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-provisioning/package.json) | Provisioning emitter's dependency on ``@azure-typespec/http-client-csharp-mgmt`` |
| [eng/centralpackagemanagement/Directory.Generation.Packages.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/Directory.Generation.Packages.props) | NuGet versions for generator packages |
"@

$md | Out-File -FilePath $OutputPath -Encoding utf8NoBOM -Force
Write-Host "Dashboard written to: $OutputPath"

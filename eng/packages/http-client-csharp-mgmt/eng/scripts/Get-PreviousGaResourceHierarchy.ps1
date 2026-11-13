#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Extracts the resource hierarchy of the *previous GA* version of an
    Azure.ResourceManager.* package by reflecting over its restored DLL.

.DESCRIPTION
    The SDK project's own NuGet restore already downloads the previous GA
    package — ApiCompat declares it via <PackageDownload> based on
    <ApiCompatVersion> in the .csproj. This script:

      1. Reads <PackageId> + <ApiCompatVersion> from the SDK .csproj.
      2. Runs `dotnet restore` on the SDK project to ensure the previous GA
         package is available in the NuGet cache.
      3. Resolves the GA DLL out of the NuGet cache.
      4. Invokes the .NET 10 ResourceHierarchyTool directly with that DLL.
         The tool ships with Azure.ResourceManager + Azure.Core in its bin
         folder and runs on a .NET 10 host, so it can load the latest
         transitive dependencies (e.g. System.Text.Json v10) that the
         PowerShell host runtime cannot.

    No throwaway publish project required.

.PARAMETER ProjectPath
    Path to the SDK project — either the .csproj or the directory containing
    it (typically sdk/<service>/Azure.ResourceManager.<Service>/src).

.PARAMETER OutFile
    Optional path to write the hierarchy JSON. Defaults to stdout.

.PARAMETER PreferTfm
    Optional override for the target framework folder under lib/ for the
    GA DLL. Defaults to ['net8.0', 'net6.0', 'netstandard2.0'] in priority
    order.

.EXAMPLE
    pwsh Get-PreviousGaResourceHierarchy.ps1 `
        -ProjectPath sdk/foo/Azure.ResourceManager.Foo/src `
        -OutFile     ga-hierarchy.json
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true, Position = 0)]
    [string] $ProjectPath,

    [Parameter()]
    [string] $OutFile,

    [Parameter()]
    [string[]] $PreferTfm = @('net8.0', 'net6.0', 'netstandard2.0')
)

$ErrorActionPreference = 'Stop'

function Resolve-CsprojFile {
    param([string] $Path)
    if (-not (Test-Path -LiteralPath $Path)) { throw "Path not found: $Path" }
    $item = Get-Item -LiteralPath $Path
    if (-not $item.PSIsContainer) {
        if ($item.Extension -ne '.csproj') { throw "Expected a .csproj file: $Path" }
        return $item.FullName
    }
    $csproj = @(Get-ChildItem -Path $item.FullName -Filter '*.csproj' -File -ErrorAction SilentlyContinue)
    if ($csproj.Count -eq 0) {
        $srcDir = Join-Path $item.FullName 'src'
        if (Test-Path -LiteralPath $srcDir) {
            $csproj = @(Get-ChildItem -Path $srcDir -Filter '*.csproj' -File -ErrorAction SilentlyContinue)
        }
    }
    if ($csproj.Count -ne 1) {
        throw "Could not unambiguously locate a single .csproj under: $Path (found $($csproj.Count))"
    }
    return $csproj[0].FullName
}

# --- Read package id + ApiCompatVersion -----------------------------------------

$csprojPath = Resolve-CsprojFile -Path $ProjectPath
[Console]::Error.WriteLine("Project: $csprojPath")

[xml] $csprojXml = Get-Content -LiteralPath $csprojPath -Raw

$packageId = $null
$apiCompatVersion = $null
foreach ($pg in $csprojXml.Project.PropertyGroup) {
    if ($null -eq $pg) { continue }
    if (-not $packageId -and $pg.PackageId) { $packageId = [string]$pg.PackageId }
    if (-not $packageId -and $pg.AssemblyName) { $packageId = [string]$pg.AssemblyName }
    if (-not $apiCompatVersion -and $pg.ApiCompatVersion) { $apiCompatVersion = [string]$pg.ApiCompatVersion }
}
if (-not $packageId) {
    $packageId = [System.IO.Path]::GetFileNameWithoutExtension($csprojPath)
}
if (-not $apiCompatVersion) {
    throw "Could not find <ApiCompatVersion> in $csprojPath. The previous GA version is needed to compare the hierarchy."
}
[Console]::Error.WriteLine("Package: $packageId v$apiCompatVersion")

# --- Restore the SDK project so both the GA package and the current dep ---------
# --- closure land in the NuGet cache. -------------------------------------------

[Console]::Error.WriteLine("Restoring $csprojPath ...")
& dotnet restore $csprojPath --verbosity quiet | Out-Null
if ($LASTEXITCODE -ne 0) { throw "dotnet restore failed (exit $LASTEXITCODE)" }

# Find the NuGet cache root used by this project. project.assets.json's
# packageFolders is the authoritative source (honours NUGET_PACKAGES env,
# restorePackagesPath in nuget.config, etc.).
$assetsFile = (& dotnet msbuild $csprojPath '-getProperty:ProjectAssetsFile' -nologo -v:q).Trim()
if (-not $assetsFile -or -not (Test-Path -LiteralPath $assetsFile)) {
    throw "Could not locate project.assets.json (msbuild returned: '$assetsFile')"
}
$assets = Get-Content -LiteralPath $assetsFile -Raw | ConvertFrom-Json
$packageFolders = @($assets.packageFolders.PSObject.Properties.Name)
if ($packageFolders.Count -eq 0) { throw "No packageFolders in project.assets.json" }

$lowerPkg = $packageId.ToLowerInvariant()
$gaDll = $null
foreach ($folder in $packageFolders) {
    foreach ($tfm in $PreferTfm) {
        $candidate = Join-Path $folder "$lowerPkg/$apiCompatVersion/lib/$tfm/$packageId.dll"
        if (Test-Path -LiteralPath $candidate) { $gaDll = $candidate; break }
    }
    if ($gaDll) { break }
}
if (-not $gaDll) {
    throw "Could not find GA DLL for $packageId v$apiCompatVersion under any packageFolder. Expected sub-path: $lowerPkg/$apiCompatVersion/lib/<tfm>/$packageId.dll"
}
[Console]::Error.WriteLine("GA DLL:  $gaDll")

# --- Invoke the .NET 10 reflection tool ------------------------------------------
# Azure.ResourceManager + Azure.Core (and their transitive closure) ship beside
# the tool via PackageReferences in ResourceHierarchyTool.csproj, so no
# probe-dir surgery is required for typical Azure.ResourceManager.<RP>.dll inputs.

$thisDir  = Split-Path -Parent $PSCommandPath
$toolProj = Join-Path $thisDir 'ResourceHierarchyTool/ResourceHierarchyTool.csproj'
$toolDll  = Join-Path $thisDir 'ResourceHierarchyTool/bin/Release/net10.0/ResourceHierarchyTool.dll'
if (-not (Test-Path -LiteralPath $toolDll)) {
    [Console]::Error.WriteLine("Building ResourceHierarchyTool ...")
    & dotnet build $toolProj -c Release --nologo --verbosity quiet | Out-Null
    if ($LASTEXITCODE -ne 0) { throw "dotnet build of ResourceHierarchyTool failed (exit $LASTEXITCODE)" }
}

$jsonOutput = & dotnet exec $toolDll --dll $gaDll
if ($LASTEXITCODE -ne 0) { throw "ResourceHierarchyTool failed (exit $LASTEXITCODE)" }

if ($OutFile) {
    $jsonOutput | Set-Content -LiteralPath $OutFile -Encoding UTF8
    [Console]::Error.WriteLine("Wrote: $OutFile")
}
else {
    $jsonOutput
}

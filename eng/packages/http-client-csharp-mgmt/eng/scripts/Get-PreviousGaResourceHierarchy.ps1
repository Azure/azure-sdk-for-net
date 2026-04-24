#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Extracts the resource hierarchy of the *previous GA* version of an
    Azure.ResourceManager.* package by reflecting over its restored DLL.

.DESCRIPTION
    Reads <ApiCompatVersion> from the SDK project's .csproj, scaffolds a tiny
    throwaway console project that references that exact GA NuGet version,
    runs `dotnet publish` to materialize the full dependency closure, and
    then invokes Get-ResourceHierarchy.ps1 against the published GA DLL.

    Why a throwaway project (instead of just restoring the SDK project)?
    The reflection script runs in the host PowerShell's .NET runtime
    (typically .NET 8/9). Restoring the *current* SDK project resolves
    `Azure.ResourceManager` to its *latest* version, which depends on
    `System.Text.Json` v10 — newer than what the host runtime can load,
    causing `FileLoadException` during reflection. Pinning the throwaway
    project to the GA NuGet version makes NuGet resolve the GA-era deps
    (e.g. Azure.ResourceManager 1.13.x, System.Text.Json v8) which are
    loadable by the host.

.PARAMETER ProjectPath
    Path to the SDK project — either the .csproj or the directory containing
    it (typically sdk/<service>/Azure.ResourceManager.<Service>/src).

.PARAMETER OutFile
    Optional path to write the hierarchy JSON. Defaults to stdout.

.PARAMETER TargetFramework
    Optional TFM for the throwaway publish project. Defaults to net8.0.

.PARAMETER WorkDir
    Optional working directory for the scaffolded project + publish output.
    Defaults to a fresh folder under TEMP, which is removed on exit.

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
    [string] $TargetFramework = 'net8.0',

    [Parameter()]
    [string] $WorkDir
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

# --- Scaffold + publish ---------------------------------------------------------

$cleanupWorkDir = $false
if (-not $WorkDir) {
    $WorkDir = Join-Path ([System.IO.Path]::GetTempPath()) ("ga-hierarchy-" + [System.Guid]::NewGuid().ToString('N'))
    $cleanupWorkDir = $true
}
if (-not (Test-Path -LiteralPath $WorkDir)) {
    New-Item -ItemType Directory -Path $WorkDir | Out-Null
}

try {
    $projDir  = Join-Path $WorkDir 'shim'
    $publishDir = Join-Path $WorkDir 'publish'
    New-Item -ItemType Directory -Path $projDir -Force | Out-Null

    # Minimal csproj. ResolveAssemblyReference + publish gives us the full
    # closure of binaries next to the GA DLL.
    $projXml = @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Library</OutputType>
    <TargetFramework>$TargetFramework</TargetFramework>
    <RootNamespace>GaHierarchyShim</RootNamespace>
    <AssemblyName>GaHierarchyShim</AssemblyName>
    <ImportDirectoryBuildProps>false</ImportDirectoryBuildProps>
    <ImportDirectoryBuildTargets>false</ImportDirectoryBuildTargets>
    <ImportDirectoryPackagesProps>false</ImportDirectoryPackagesProps>
    <ManagePackageVersionsCentrally>false</ManagePackageVersionsCentrally>
    <CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>
    <NoWarn>`$(NoWarn);NU1701;NU1603;NU1605</NoWarn>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="$packageId" Version="$apiCompatVersion" />
  </ItemGroup>
</Project>
"@
    $projFile = Join-Path $projDir 'GaHierarchyShim.csproj'
    Set-Content -LiteralPath $projFile -Value $projXml -Encoding UTF8

    # Drop a no-op Directory.Build.props/targets/Packages.props so the
    # scaffolded project does not pick up repo-level conventions.
    foreach ($empty in 'Directory.Build.props', 'Directory.Build.targets', 'Directory.Packages.props') {
        Set-Content -LiteralPath (Join-Path $projDir $empty) `
            -Value "<Project></Project>" -Encoding UTF8
    }
    # Empty source so the compiler is happy.
    Set-Content -LiteralPath (Join-Path $projDir 'Empty.cs') `
        -Value "namespace GaHierarchyShim { internal static class _ { } }" -Encoding UTF8

    [Console]::Error.WriteLine("Publishing $packageId v$apiCompatVersion to $publishDir ...")
    & dotnet publish $projFile -c Release -f $TargetFramework -o $publishDir --nologo --verbosity quiet 2>&1 | ForEach-Object { [Console]::Error.WriteLine($_) }
    if ($LASTEXITCODE -ne 0) { throw "dotnet publish failed (exit $LASTEXITCODE)" }

    $gaDll = Join-Path $publishDir "$packageId.dll"
    if (-not (Test-Path -LiteralPath $gaDll)) {
        throw "Expected published DLL not found: $gaDll"
    }

    # Invoke the existing reflection script.
    $thisDir = Split-Path -Parent $PSCommandPath
    $hierarchyScript = Join-Path $thisDir 'Get-ResourceHierarchy.ps1'
    if (-not (Test-Path -LiteralPath $hierarchyScript)) {
        throw "Sibling script not found: $hierarchyScript"
    }

    $jsonOutput = & pwsh -NoProfile -File $hierarchyScript $gaDll
    if ($LASTEXITCODE -ne 0) { throw "Get-ResourceHierarchy.ps1 failed (exit $LASTEXITCODE)" }

    if ($OutFile) {
        $jsonOutput | Set-Content -LiteralPath $OutFile -Encoding UTF8
        [Console]::Error.WriteLine("Wrote: $OutFile")
    }
    else {
        $jsonOutput
    }
}
finally {
    if ($cleanupWorkDir -and (Test-Path -LiteralPath $WorkDir)) {
        Remove-Item -LiteralPath $WorkDir -Recurse -Force -ErrorAction SilentlyContinue
    }
}

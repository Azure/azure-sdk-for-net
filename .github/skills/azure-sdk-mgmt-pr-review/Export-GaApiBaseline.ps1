#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Exports the public API surface from a released NuGet assembly.

.DESCRIPTION
    Downloads the exact package version configured by ApiCompatVersion and runs GenAPI
    over the released DLL. Package code is never loaded or executed; only assembly
    metadata is read. Use the output to verify disputed parameter signatures before
    reporting a management SDK compatibility finding.
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string]$PackageName,

    [Parameter(Mandatory = $true)]
    [string]$Version,

    [Parameter(Mandatory = $true)]
    [string]$OutputPath,

    [string]$TargetFramework,

    [string]$GenApiVersion = '5.0.0-beta.19552.1'
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

if ($PackageName -notmatch '^[A-Za-z0-9_.-]+$') {
    throw "Invalid package name: $PackageName"
}
if ($Version -notmatch '^[0-9A-Za-z.+-]+$') {
    throw "Invalid package version: $Version"
}
if ($TargetFramework -and $TargetFramework -notmatch '^[A-Za-z0-9.-]+$') {
    throw "Invalid target framework: $TargetFramework"
}

$tempDirectory = Join-Path ([System.IO.Path]::GetTempPath()) ("ga-api-" + [guid]::NewGuid().ToString('N'))
New-Item -ItemType Directory -Path $tempDirectory | Out-Null
$azureSdkFeed = 'https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json'

try {
    $packageId = $PackageName.ToLowerInvariant()
    $packageVersion = $Version.ToLowerInvariant()
    $packageArchive = Join-Path $tempDirectory "$packageId.$packageVersion.nupkg"
    $packageDirectory = Join-Path $tempDirectory 'package'
    $packageUrl = "https://api.nuget.org/v3-flatcontainer/$packageId/$packageVersion/$packageId.$packageVersion.nupkg"
    Invoke-WebRequest -Uri $packageUrl -OutFile $packageArchive
    [System.IO.Compression.ZipFile]::ExtractToDirectory($packageArchive, $packageDirectory)

    $libDirectory = Join-Path $packageDirectory 'lib'
    if (-not (Test-Path $libDirectory)) {
        throw "Released package $PackageName $Version does not contain a lib directory."
    }

    if ($TargetFramework) {
        $frameworkDirectory = Join-Path $libDirectory $TargetFramework
        if (-not (Test-Path $frameworkDirectory)) {
            throw "Released package $PackageName $Version does not contain lib/$TargetFramework."
        }
    } else {
        $availableFrameworks = @(Get-ChildItem -Path $libDirectory -Directory)
        $preferredFrameworks = @('net10.0', 'net9.0', 'net8.0', 'netstandard2.1', 'netstandard2.0')
        $frameworkDirectory = $null
        foreach ($preferredFramework in $preferredFrameworks) {
            $match = $availableFrameworks | Where-Object { $_.Name -eq $preferredFramework } | Select-Object -First 1
            if ($match) {
                $frameworkDirectory = $match.FullName
                break
            }
        }
        if (-not $frameworkDirectory) {
            $frameworkDirectory = $availableFrameworks | Sort-Object Name | Select-Object -First 1 -ExpandProperty FullName
        }
        $TargetFramework = Split-Path $frameworkDirectory -Leaf
    }

    $assemblyPath = Join-Path $frameworkDirectory "$PackageName.dll"
    if (-not (Test-Path $assemblyPath)) {
        throw "Released assembly not found: $assemblyPath"
    }

    $genApiPackageVersion = $GenApiVersion.ToLowerInvariant()
    $nugetPackages = if ($env:NUGET_PACKAGES) {
        $env:NUGET_PACKAGES
    } else {
        Join-Path $HOME '.nuget/packages'
    }
    $genApiPackageDirectory = Join-Path $nugetPackages "microsoft.dotnet.genapi/$genApiPackageVersion"
    if (-not (Test-Path $genApiPackageDirectory)) {
        $restoreProject = Join-Path $tempDirectory 'restore.csproj'
        @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup><TargetFramework>net8.0</TargetFramework></PropertyGroup>
  <ItemGroup><PackageReference Include="Microsoft.DotNet.GenAPI" Version="$GenApiVersion" /></ItemGroup>
</Project>
"@ | Set-Content -Path $restoreProject
        # This repository's approved feed has NuGet.org configured as an upstream source.
        & dotnet restore $restoreProject --source $azureSdkFeed
        if ($LASTEXITCODE -ne 0) {
            throw "Failed to restore Microsoft.DotNet.GenAPI $GenApiVersion."
        }
    }

    $genApiDll = Get-ChildItem -Path (Join-Path $genApiPackageDirectory 'tools') -Recurse -Filter 'Microsoft.DotNet.GenAPI.dll' |
        Where-Object { $_.FullName -match 'netcoreapp' } |
        Sort-Object FullName -Descending |
        Select-Object -First 1 -ExpandProperty FullName
    if (-not $genApiDll) {
        throw "Microsoft.DotNet.GenAPI.dll was not found in package version $GenApiVersion."
    }

    $dependencyProject = Join-Path $tempDirectory 'dependencies.csproj'
    @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup><TargetFramework>$TargetFramework</TargetFramework></PropertyGroup>
  <ItemGroup><PackageReference Include="$PackageName" Version="$Version" /></ItemGroup>
</Project>
"@ | Set-Content -Path $dependencyProject
    & dotnet restore $dependencyProject --source $azureSdkFeed
    if ($LASTEXITCODE -ne 0) {
        throw "Failed to restore the dependency closure for $PackageName $Version."
    }

    $assetsPath = Join-Path $tempDirectory 'obj/project.assets.json'
    $assets = Get-Content -Raw $assetsPath | ConvertFrom-Json -Depth 100
    $packageFolder = $assets.packageFolders.PSObject.Properties |
        Select-Object -First 1 -ExpandProperty Name
    $framework = $assets.project.frameworks.PSObject.Properties |
        Where-Object { $_.Value.targetAlias -eq $TargetFramework } |
        Select-Object -First 1
    $targetNames = [System.Collections.Generic.List[string]]::new()
    $targetNames.Add($TargetFramework)
    if ($framework) {
        $targetNames.Add($framework.Name)
    }
    if ($TargetFramework -match '^netstandard(?<version>\d+\.\d+)$') {
        $targetNames.Add(".NETStandard,Version=v$($Matches['version'])")
    } elseif ($TargetFramework -match '^netcoreapp(?<version>\d+\.\d+)$') {
        $targetNames.Add(".NETCoreApp,Version=v$($Matches['version'])")
    }
    $target = $assets.targets.PSObject.Properties |
        Where-Object {
            $targetProperty = $_
            @($targetNames | Where-Object { $targetProperty.Name -like "$_*" }).Count -gt 0
        } |
        Select-Object -First 1 -ExpandProperty Value
    if (-not $target) {
        throw "Could not resolve restored target '$TargetFramework' in $assetsPath."
    }
    $libraryDirectories = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::OrdinalIgnoreCase)
    foreach ($library in $target.PSObject.Properties) {
        foreach ($assetGroupName in @('compile', 'runtime')) {
            $assetGroup = $library.Value.$assetGroupName
            if (-not $assetGroup) {
                continue
            }
            foreach ($asset in $assetGroup.PSObject.Properties) {
                if ($asset.Name.EndsWith('.dll')) {
                    $assetPath = Join-Path $packageFolder (Join-Path $library.Name.ToLowerInvariant() $asset.Name)
                    if (Test-Path $assetPath) {
                        $libraryDirectories.Add((Split-Path $assetPath -Parent)) | Out-Null
                    }
                }
            }
        }
    }
    $dotnetExecutable = (Get-Command dotnet).Source
    $dotnetTarget = (Get-Item $dotnetExecutable).Target
    $dotnetRoot = if ($env:DOTNET_ROOT) {
        $env:DOTNET_ROOT
    } elseif ($dotnetTarget) {
        Split-Path $dotnetTarget -Parent
    } else {
        Split-Path $dotnetExecutable -Parent
    }
    $packsDirectory = Join-Path $dotnetRoot 'packs'
    foreach ($packDirectory in (Get-ChildItem -Path $packsDirectory -Directory -ErrorAction SilentlyContinue)) {
        $referenceDirectory = Get-ChildItem -Path $packDirectory.FullName -Directory |
            Sort-Object { [version]$_.Name } -Descending |
            ForEach-Object { Join-Path $_.FullName "ref/$TargetFramework" } |
            Where-Object { Test-Path $_ } |
            Select-Object -First 1
        if ($referenceDirectory) {
            $libraryDirectories.Add($referenceDirectory) | Out-Null
        }
    }
    $libraryDirectories.Add($PSHOME) | Out-Null

    $resolvedOutputPath = [System.IO.Path]::GetFullPath($OutputPath)
    $outputDirectory = Split-Path $resolvedOutputPath -Parent
    New-Item -ItemType Directory -Force -Path $outputDirectory | Out-Null

    $genApiOutput = & dotnet $genApiDll $assemblyPath --api-only --lib-path ($libraryDirectories -join ';') --out $resolvedOutputPath 2>&1
    $genApiOutput | Write-Host
    if ($LASTEXITCODE -ne 0 -or -not (Test-Path $resolvedOutputPath) -or
        (Get-Item $resolvedOutputPath).Length -eq 0) {
        throw "GenAPI failed to export $PackageName $Version."
    }
    if ($genApiOutput -match 'Unable to resolve assembly') {
        throw "GenAPI could not resolve the full dependency closure for $PackageName $Version."
    }

    Write-Host "Exported $PackageName $Version ($([System.IO.Path]::GetFileName($frameworkDirectory))) to $resolvedOutputPath"
} finally {
    if (Test-Path $tempDirectory) {
        Remove-Item -Recurse -Force $tempDirectory
    }
}

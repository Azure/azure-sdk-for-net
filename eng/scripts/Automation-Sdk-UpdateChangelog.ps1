# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

<#
.SYNOPSIS
    Updates CHANGELOG.md for an Azure Resource Manager SDK package.

.DESCRIPTION
    This script:
    1. Reads the package project to determine the package name and release version
    2. Determines the service directory from the package path
    3. Calls Gen-Mgmt-Changelog.ps1 to generate and update CHANGELOG.md

.PARAMETER PackagePath
    Absolute path to the root folder of the local SDK package.

.PARAMETER SdkRepoPath
    Absolute path to the root folder of the local SDK repository.

.EXAMPLE
    .\Automation-Sdk-UpdateChangelog.ps1 `
        -PackagePath "C:\repos\azure-sdk-for-net\sdk\apicenter\Azure.ResourceManager.ApiCenter" `
        -SdkRepoPath "C:\repos\azure-sdk-for-net"
#>

param(
    [Parameter(Mandatory = $true)]
    [ValidateScript({ Test-Path $_ -PathType Container })]
    [string]$PackagePath,

    [Parameter(Mandatory = $true)]
    [ValidateScript({ Test-Path $_ -PathType Container })]
    [string]$SdkRepoPath
)

$ErrorActionPreference = "Stop"
$PSNativeCommandUseErrorActionPreference = $true

try {
    $packagePath = (Resolve-Path $PackagePath).Path
    $sdkRepoPath = (Resolve-Path $SdkRepoPath).Path
    $relativePackagePath = [IO.Path]::GetRelativePath($sdkRepoPath, $packagePath)
    if ($relativePackagePath -eq ".." -or $relativePackagePath.StartsWith("..$([IO.Path]::DirectorySeparatorChar)")) {
        throw "Package path '$packagePath' is not under SDK repository '$sdkRepoPath'."
    }

    $projectFiles = @(Get-ChildItem -Path (Join-Path $packagePath "src") -Filter "*.csproj" -File)
    if ($projectFiles.Count -ne 1) {
        throw "Expected one project under '$packagePath/src', found $($projectFiles.Count)."
    }

    [xml]$project = Get-Content $projectFiles[0].FullName
    $packageName = [string]$project.Project.PropertyGroup.PackageId
    if ([string]::IsNullOrWhiteSpace($packageName)) {
        $packageName = $projectFiles[0].BaseName
    }
    if (-not $packageName.StartsWith("Azure.ResourceManager.")) {
        throw "Package '$packageName' is not an Azure Resource Manager package."
    }

    $releaseVersion = [string]$project.Project.PropertyGroup.Version
    if ([string]::IsNullOrWhiteSpace($releaseVersion)) {
        throw "No package version found in '$($projectFiles[0].FullName)'."
    }

    $serviceName = Split-Path (Split-Path $packagePath -Parent) -Leaf
    $releaseDate = [DateTime]::UtcNow.ToString("yyyy-MM-dd")

    Write-Host "Generating changelog for package '$packageName', service '$serviceName', version '$releaseVersion'."
    & (Join-Path $PSScriptRoot "Gen-Mgmt-Changelog.ps1") `
        -ServiceName $serviceName `
        -ReleaseVersion $releaseVersion `
        -ReleaseDate $releaseDate

    if (-not $?) {
        throw "Gen-Mgmt-Changelog.ps1 failed for package '$packageName'."
    }

    Write-Host "CHANGELOG.md updated successfully for '$packageName'."
    exit 0
}
catch {
    Write-Error "Failed to update management package changelog: $_"
    Write-Error "Stack trace: $($_.ScriptStackTrace)"
    exit 1
}
#Requires -Version 7.0
<#
.SYNOPSIS
Compares existing SDK assemblies with the latest stable NuGet release, without building the SDK.
.DESCRIPTION
PackagePath can identify a package directory, its src directory, or its source project.
All paths must be absolute. Build the current package with portable/embedded PDBs before invoking this script.
The PowerShell host runtime must support the selected .NET SDK's MSBuild diagnostic reader.
Compatibility violations are a successful extraction; tool, reference, and stale-artifact errors are not.
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string]$PackagePath,

    [Parameter(Mandatory = $true)]
    [string]$SdkRepoPath,

    [Parameter(Mandatory = $true)]
    [string]$OutputJsonFile
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3
. (Join-Path $PSScriptRoot 'Get-SdkChanges.Helpers.ps1')

Invoke-SdkChangeExtraction -PackagePath $PackagePath -SdkRepoPath $SdkRepoPath -OutputJsonFile $OutputJsonFile

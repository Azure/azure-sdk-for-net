#!/usr/bin/env pwsh

#Requires -Version 6.0

<#
.SYNOPSIS
Non-interactive wrapper for Prepare-Release.ps1 that can be run by automation agents without user prompts.

.DESCRIPTION
This script wraps eng/common/scripts/Prepare-Release.ps1 to enable fully non-interactive execution.
All four parameters (PackageName, ServiceDirectory, Version, ReleaseDate) are required, and the script
will run end-to-end without prompting for any user input.

It works by overriding the Read-Host cmdlet with a function that returns pre-programmed answers based
on the prompt text. Any unexpected prompt will cause the script to fail immediately with an error,
ensuring nothing is silently answered incorrectly.

.PARAMETER PackageName
The full package name of the package you want to prepare for release (e.g. "Azure.Core").

.PARAMETER ServiceDirectory
The exact directory name where the package resides under the 'sdk' folder (e.g. "core").

.PARAMETER Version
The version to release. Must follow standard SemVer rules (e.g. "1.42.0", "1.0.0-beta.1").

.PARAMETER ReleaseDate
The planned release date in MM/dd/yyyy format (e.g. "03/19/2026").

.PARAMETER ReleaseTrackingOnly
Optional: If passed, only updates DevOps release tracking items without modifying local version or changelog files.

.PARAMETER GroupId
Optional: The group ID for Java packages. Defaults to "com.azure" if not provided.

.EXAMPLE
PS> ./eng/scripts/Prepare-Release-NonInteractive.ps1 -PackageName "Azure.Core" -ServiceDirectory "core" -Version "1.42.0" -ReleaseDate "03/19/2026"

Runs the full release preparation for Azure.Core version 1.42.0 without any interactive prompts.

.EXAMPLE
PS> ./eng/scripts/Prepare-Release-NonInteractive.ps1 -PackageName "Azure.Core" -ServiceDirectory "core" -Version "1.42.0" -ReleaseDate "03/19/2026" -ReleaseTrackingOnly

Only updates DevOps release tracking items without modifying local files.
#>
[CmdletBinding()]
param(
  [Parameter(Mandatory = $true)]
  [string]$PackageName,
  [Parameter(Mandatory = $true)]
  [string]$ServiceDirectory,
  [Parameter(Mandatory = $true)]
  [string]$Version,
  [Parameter(Mandatory = $true)]
  [string]$ReleaseDate,
  [switch]$ReleaseTrackingOnly = $false,
  [string]$GroupId
)

# Override Read-Host to provide automatic answers based on prompt text.
# In PowerShell, functions take precedence over cmdlets in name resolution,
# so this shadows Microsoft.PowerShell.Utility\Read-Host for the entire
# dot-sourced scope (including helper scripts).
function Read-Host {
  [CmdletBinding()]
  param(
    [Parameter(Position = 0)]
    [object]$Prompt,
    [switch]$AsSecureString,
    [switch]$MaskInput
  )

  $promptStr = if ($Prompt) { "$Prompt" } else { "" }

  if ($promptStr -match "Input the new version") {
    Write-Host "${promptStr}: $Version (non-interactive)"
    return $Version
  }
  elseif ($promptStr -match "replace the latest entry title") {
    Write-Host "${promptStr}: y (non-interactive)"
    return "y"
  }
  elseif ($promptStr -match "group id") {
    if ($GroupId) {
      Write-Host "${promptStr}: $GroupId (non-interactive)"
      return $GroupId
    }
    else {
      Write-Host "${promptStr}: <default> (non-interactive - using Prepare-Release.ps1 default)"
      return ""
    }
  }
  elseif ($promptStr -match "Input the display name") {
    Write-Error "Display name prompt encountered in non-interactive mode. The package may not have release tracking metadata configured."
    exit 1
  }
  elseif ($promptStr -match "Input the service name") {
    Write-Error "Service name prompt encountered in non-interactive mode. The package may not have release tracking metadata configured."
    exit 1
  }
  else {
    Write-Error "Unexpected interactive prompt in non-interactive mode: '$promptStr'"
    exit 1
  }
}

Write-Host "Running Prepare-Release in non-interactive mode" -ForegroundColor Cyan
Write-Host "  PackageName: $PackageName" -ForegroundColor Cyan
Write-Host "  ServiceDirectory: $ServiceDirectory" -ForegroundColor Cyan
Write-Host "  Version: $Version" -ForegroundColor Cyan
Write-Host "  ReleaseDate: $ReleaseDate" -ForegroundColor Cyan
if ($ReleaseTrackingOnly) {
  Write-Host "  ReleaseTrackingOnly: true" -ForegroundColor Cyan
}

$prepareReleaseScript = Join-Path $PSScriptRoot ".." "common" "scripts" "Prepare-Release.ps1"

$params = @{
  PackageName      = $PackageName
  ServiceDirectory = $ServiceDirectory
  ReleaseDate      = $ReleaseDate
  ReleaseTrackingOnly = $ReleaseTrackingOnly
}

if ($GroupId) {
  $params["GroupId"] = $GroupId
}

. $prepareReleaseScript @params

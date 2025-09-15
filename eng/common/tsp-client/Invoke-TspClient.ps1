#!/usr/bin/env pwsh

<#
.SYNOPSIS
Invokes tsp-client using dependencies defined in adjacent ./package*.json

.PARAMETER TspClientOptions
Options to pass to the tsp-client command as a single string.

.PARAMETER PackageInstallCache
Location of a working directory. If no location is provided a folder will be
created in the temp folder, package*.json files will be placed in that folder.

.PARAMETER LeavePackageInstallCache
If set the PackageInstallCache will not be deleted. Use if there are multiple
calls to Invoke-TspClient.ps1 to prevent creating multiple working directories and
redundant calls `npm ci`.

.EXAMPLE
./eng/common/tsp-client/Invoke-TspClient.ps1 -TspClientOptions "--help"

This will run tsp-client --help

.EXAMPLE
./eng/common/tsp-client/Invoke-TspClient.ps1 -TspClientOptions "generate --output-dir ./generated"

This will run tsp-client generate --output-dir ./generated

.EXAMPLE
./eng/common/tsp-client/Invoke-TspClient.ps1 -TspClientOptions "version"

This will run tsp-client version

#>
[CmdletBinding()]
param(
  [Parameter(Mandatory = $true)]
  [string] $TspClientOptions,

  [Parameter()]
  [string] $PackageInstallCache = (Join-Path ([System.IO.Path]::GetTempPath()) "tsp-client-tool-path"),

  [Parameter()]
  [switch] $LeavePackageInstallCache
)

Set-StrictMode -Version 3.0

if (!(Get-Command npm -ErrorAction SilentlyContinue)) {
  Write-Error "Could not locate npm. Install NodeJS (includes npm) https://nodejs.org/en/download/"
  exit 1
}

if ([string]::IsNullOrWhiteSpace($TspClientOptions)) {
  Write-Error "TspClientOptions parameter is required and cannot be empty"
  exit 1
}

# Prepare the working directory if it does not already have requirements in
# place.
if (!(Test-Path $PackageInstallCache)) {
  New-Item -ItemType Directory -Path $PackageInstallCache | Out-Null
}

if (!(Test-Path "$PackageInstallCache/package.json")) {
  Copy-Item "$PSScriptRoot/package.json" $PackageInstallCache
}

if (!(Test-Path "$PackageInstallCache/package-lock.json")) {
  Copy-Item "$PSScriptRoot/package-lock.json" $PackageInstallCache
}

$originalLocation = Get-Location

try {
  Set-Location $PackageInstallCache
  Write-Host "Installing dependencies in $PackageInstallCache"
  npm ci | Write-Host

  # Use the tsp-client with the provided options
  $command = "npm exec --no -- tsp-client $TspClientOptions"
  Write-Host "Running: $command"
  $tspClientArgs = $TspClientOptions.Split(' ', [StringSplitOptions]::RemoveEmptyEntries)
  $tspClientOutput = npm exec `
    --no `
    -- `
    tsp-client `
    @tspClientArgs
  
} finally {
  Set-Location $originalLocation

  if (!$LeavePackageInstallCache) {
    Write-Host "Cleaning up package install cache at $PackageInstallCache"
    Remove-Item -Path $PackageInstallCache -Recurse -Force -ErrorAction SilentlyContinue
  }
}

return $tspClientOutput

#!/usr/bin/env pwsh

<#
.SYNOPSIS
Invokes cspell using dependencies defined in adjacent ./package*.json

.PARAMETER JobType
Maps to cspell command (e.g. `lint`, `trace`, etc.). Default is `lint`

.PARAMETER FileList
List of file paths to be scanned. This is piped into cspell via stdin.

.PARAMETER CSpellConfigPath
Location of cspell.json file to use when scanning. Defaults to
`.vscode/cspell.json` at the root of the repo.

.PARAMETER SpellCheckRoot
Location of root folder for generating readable relative file paths. Defaults to
the root of the repo relative to the script.

.PARAMETER PackageInstallCache
Location of a working directory. If no location is provided a folder will be
created in the temp folder, package*.json files will be placed in that folder.

.PARAMETER LeavePackageInstallCache
If set the PackageInstallCache will not be deleted. Use if there are multiple
calls to Invoke-Cspell.ps1 to prevent creating multiple working directories and
redundant calls `npm ci`.

.EXAMPLE
./eng/common/scripts/Invoke-Cspell.ps1 -FileList @('./README.md', 'file2.txt')

.EXAMPLE
git diff main --name-only | ./eng/common/spelling/Invoke-Cspell.ps1

#>
[CmdletBinding()]
param(
  [Parameter()]
  [string] $JobType = 'lint',

  [Parameter(ValueFromPipeline)]
  [array]$FileList,

  [Parameter()]
  [string] $CSpellConfigPath = (Resolve-Path "$PSScriptRoot/../../../.vscode/cspell.json"),

  [Parameter()]
  [string] $SpellCheckRoot = (Resolve-Path "$PSScriptRoot/../../.."),

  [Parameter()]
  [string] $PackageInstallCache = (Join-Path ([System.IO.Path]::GetTempPath()) "cspell-tool-path"),

  [Parameter()]
  [switch] $LeavePackageInstallCache
)

begin {
  Set-StrictMode -Version 3.0

  if (!(Get-Command npm -ErrorAction SilentlyContinue)) {
    LogError "Could not locate npm. Install NodeJS (includes npm) https://nodejs.org/en/download/"
    exit 1
  }

  if (!(Test-Path $CSpellConfigPath)) {
    LogError "Could not locate config file $CSpellConfigPath"
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


  $filesToCheck = @()
 }
process {
  $filesToCheck += $FileList
 }
end {
  npm --prefix $PackageInstallCache ci | Write-Host

  $command = "npm --prefix $PackageInstallCache exec --no -- cspell $JobType --config $CSpellConfigPath --no-must-find-files --root $SpellCheckRoot --file-list stdin"
  Write-Host $command
  $cspellOutput = $filesToCheck | npm '--prefix' $PackageInstallCache `
    exec  `
    '--no' `
    '--' `
    cspell `
    $JobType `
    '--config' $CSpellConfigPath `
    '--no-must-find-files' `
    '--root' $SpellCheckRoot `
    '--file-list' stdin

  if (!$LeavePackageInstallCache) {
    Write-Host "Cleaning up package install cache at $PackageInstallCache"
    Remove-Item -Path $PackageInstallCache -Recurse -Force | Out-Null
  }

  return $cspellOutput
}

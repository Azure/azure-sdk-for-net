[CmdLetBinding()]
param(
  [Parameter(Mandatory)]
  [string]$PackageDirectoriesFile
)

. $PSScriptRoot/common.ps1
. $PSScriptRoot/Helpers/CommandInvocation-Helpers.ps1

$ErrorActionPreference = 'Stop'

if (Test-Path "Function:$UpdateGeneratedSdksFn") {
    &$UpdateGeneratedSdksFn $PackageDirectoriesFile
} else {
    Write-Error "Function $UpdateGeneratedSdksFn not implemented in Language-Settings.ps1"
}

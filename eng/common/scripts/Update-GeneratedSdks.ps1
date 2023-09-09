[CmdLetBinding()]
param(
  [Parameter(Mandatory)]
  [string]$PackageFoldersFile
)

. $PSScriptRoot/common.ps1
. $PSScriptRoot/Helpers/CommandInvocation-Helpers.ps1

$ErrorActionPreference = 'Stop'

if (Test-Path "Function:$UpdateGeneratedSdksFn") {
    &$UpdateGeneratedSdksFn $PackageFoldersFile
} else {
    Write-Error "Function $UpdateGeneratedSdksFn not implemented in Language-Settings.ps1"
}

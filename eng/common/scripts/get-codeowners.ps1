<#
.SYNOPSIS
Please see the comment on Get-Codeowners defined in ./get-codeowners.lib.ps1 
#>
param (
  [string] $TargetPath = $null,
  [string] $TargetDirectory = $null,
  [string] $CodeownersFileLocation = $null
)

. $PSScriptRoot/get-codeowners.lib.ps1

return Get-Codeowners `
  -TargetPath $TargetPath `
  -TargetDirectory $TargetDirectory
  -CodeownersFileLocation $CodeownersFileLocation
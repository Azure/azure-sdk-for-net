<#
.SYNOPSIS
Please see the comment on Get-Codeowners defined in ./get-codeowners.lib.ps1 
#>
param (
  [string] $TargetPath = "",
  [string] $TargetDirectory = "",
  [string] $CodeownersFileLocation = "",
  [switch] $IncludeNonUserAliases
)

. $PSScriptRoot/get-codeowners.lib.ps1

return Get-Codeowners `
  -TargetPath $TargetPath `
  -TargetDirectory $TargetDirectory `
  -CodeownersFileLocation $CodeownersFileLocation `
  -IncludeNonUserAliases:$IncludeNonUserAliases
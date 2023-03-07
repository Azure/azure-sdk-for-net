<#
.SYNOPSIS
Please see synopsis of Get-Codeowners defined in ./get-codeowners-functions.ps1 
#>
param (
  [string]$TargetPath = "",
  [string]$TargetDirectory = ""
)

. $PSScriptRoot/get-codeowners-functions.ps1

return Get-Codeowners `
  -TargetPath $TargetPath `
  -TargetDirectory $TargetDirectory


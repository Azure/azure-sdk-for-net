<#
.SYNOPSIS
Please see synopsis of Get-Codeowners defined in ./get-codeowners-functions.ps1 
#>
param (
  [string]$TargetPath = $null,
  [string]$TargetDirectory = $null,
  [string]$CodeownersFileLocation = $null
)

. $PSScriptRoot/get-codeowners-functions.ps1

return Get-Codeowners `
  -TargetPath $TargetPath `
  -TargetDirectory $TargetDirectory
  -CodeownersFileLocation $CodeownersFileLocation
# kja need to restore param: https://github.com/Azure/azure-sdk-for-cpp/blob/2850c5d32c8a86491b49e801433b8f186fa81745/eng/pipelines/templates/stages/archetype-cpp-release.yml#L196
# kja need to fix paths, move back to /eng/common/scripts/, because that is the end goal, and the path would be broken here: https://github.com/Azure/azure-sdk-for-cpp/blob/2850c5d32c8a86491b49e801433b8f186fa81745/eng/pipelines/templates/stages/archetype-cpp-release.yml#L196

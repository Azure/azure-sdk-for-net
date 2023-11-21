
[CmdletBinding()]
param(
  [Parameter(Mandatory=$true)]
  [string]$language,
  [Parameter(Mandatory=$true)]
  [string]$packageName,
  [Parameter(Mandatory=$true)]
  [string]$version,
  [string]$plannedDate,
  [string]$serviceName = $null,
  [string]$packageDisplayName = $null,
  [string]$packageRepoPath = "NA",
  [string]$packageType = "client",
  [string]$relatedWorkItemId = $null,
  [string]$tag = $null,
  [string]$devops_pat = $env:DEVOPS_PAT
)
#Requires -Version 6.0
Set-StrictMode -Version 3

if (!(Get-Command az -ErrorAction SilentlyContinue)) {
  Write-Error 'You must have the Azure CLI installed: https://aka.ms/azure-cli'
  exit 1
}

. ${PSScriptRoot}\common.ps1
. (Join-Path $PSScriptRoot SemVer.ps1)
. (Join-Path $PSScriptRoot Helpers DevOps-WorkItem-Helpers.ps1)

&$EngCommonScriptsDir/Update-DevOps-Release-WorkItem.ps1 `
  -language $language `
  -packageName $packageName `
  -version $version `
  -plannedDate $plannedDate `
  -serviceName $serviceName `
  -packageDisplayName $packageDisplayName `
  -packageRepoPath $packageRepoPath `
  -packageType $packageType `
  -relatedWorkItemId $relatedWorkItemId `
  -tag $tag `
  -devops_pat $devops_pat

if ($LASTEXITCODE -ne 0) {
  Write-Error "Updating of the Devops Release WorkItem failed."
  exit 1
}
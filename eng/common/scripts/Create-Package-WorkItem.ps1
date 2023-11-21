
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

Write-Host "Connecting to Azure Devops"
LoginToAzureDevops $devops_pat
echo $devops_pat | az devops login
Write-Host "Install or update azure devops cli extension"
az extension show -n azure-devops *> $null
if (!$?){
  Write-Host 'Installing azure-devops extension'
  az extension add --name azure-devops
} else {
  # Force update the extension to the latest version if it was already installed
  # this is needed to ensure we have the authentication issue fixed from earlier versions
  az extension update -n azure-devops *> $null
}
Write-Host "Checking Devops access"
CheckDevOpsAccess
Write-Host "Create package work item"
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
  -tag $tag

if ($LASTEXITCODE -ne 0) {
  Write-Error "Updating of the Devops Release WorkItem failed."
  exit 1
}
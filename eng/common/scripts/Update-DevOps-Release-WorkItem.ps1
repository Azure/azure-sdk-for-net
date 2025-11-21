
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
  [string]$packageNewLibrary = "true",
  [string]$relatedWorkItemId = $null,
  [string]$tag = $null,
  [bool]$inRelease = $true,
  [string]$specProjectPath = ""
)
#Requires -Version 6.0
Set-StrictMode -Version 3

if (!(Get-Command az -ErrorAction SilentlyContinue)) {
  Write-Error 'You must have the Azure CLI installed: https://aka.ms/azure-cli'
  exit 1
}

. (Join-Path $PSScriptRoot SemVer.ps1)
. (Join-Path $PSScriptRoot Helpers DevOps-WorkItem-Helpers.ps1)

az account show *> $null
if (!$?) {
  Write-Host 'Running az login...'
  az login *> $null
}

az extension show -n azure-devops *> $null
if (!$?){
  az extension add --name azure-devops
} else {
  # Force update the extension to the latest version if it was already installed
  # this is needed to ensure we have the authentication issue fixed from earlier versions
  az extension update -n azure-devops *> $null
}

CheckDevOpsAccess

$parsedNewVersion = [AzureEngSemanticVersion]::new($version)
$state = "In Release"
$releaseType = $parsedNewVersion.VersionType
$versionMajorMinor = "" + $parsedNewVersion.Major + "." + $parsedNewVersion.Minor

$packageInfo = [PSCustomObject][ordered]@{
  Package = $packageName
  DisplayName = $packageDisplayName
  ServiceName = $serviceName
  RepoPath = $packageRepoPath
  Type = $packageType
  New = $packageNewLibrary
  SpecProjectPath = $specProjectPath
};

if (!$plannedDate) {
  $plannedDate = Get-Date -Format "MM/dd/yyyy"
}

$plannedVersions = @(
  [PSCustomObject][ordered]@{
    Type = $releaseType
    Version = $version
    Date = $plannedDate
  }
)
$ignoreReleasePlannerTests = $true
if ($tag -and  $tag.Contains("Release Planner App Test")) {
  $ignoreReleasePlannerTests = $false
}

$workItem = FindOrCreateClonePackageWorkItem $language $packageInfo $versionMajorMinor -allowPrompt $true -outputCommand $false -relatedId $relatedWorkItemId -tag $tag -ignoreReleasePlannerTests $ignoreReleasePlannerTests

if (!$workItem) {
  Write-Host "Something failed as we don't have a work-item so exiting."
  exit 1
}

Write-Host "Updated or created a release work item for a package release with the following properties:"
Write-Host "  Lanuage: $($workItem.fields['Custom.Language'])"
Write-Host "  Version: $($workItem.fields['Custom.PackageVersionMajorMinor'])"
Write-Host "  Package: $($workItem.fields['Custom.Package'])"
if ($workItem.fields['System.AssignedTo']) {
  Write-Host "  AssignedTo: $($workItem.fields['System.AssignedTo']["uniqueName"])"
}
else {
  Write-Host "  AssignedTo: unassigned"
}
Write-Host "  PackageDisplayName: $($workItem.fields['Custom.PackageDisplayName'])"
Write-Host "  ServiceName: $($workItem.fields['Custom.ServiceName'])"
Write-Host "  PackageType: $($workItem.fields['Custom.PackageType'])"
Write-Host ""
if ($inRelease)
{
  Write-Host "Marking item [$($workItem.id)]$($workItem.fields['System.Title']) as '$state' for '$releaseType'"
  $updatedWI = UpdatePackageWorkItemReleaseState -id $workItem.id -state "In Release" -releaseType $releaseType -outputCommand $false
}
$updatedWI = UpdatePackageVersions $workItem -plannedVersions $plannedVersions

Write-Host "Release tracking item is at https://dev.azure.com/azure-sdk/Release/_workitems/edit/$($updatedWI.id)/"

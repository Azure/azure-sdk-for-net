
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
  [string]$packageNewLibrary = "true"
)
Set-StrictMode -Version 3

if (!(Get-Command az)) {
  Write-Host 'You must have the Azure CLI installed: https://aka.ms/azure-cli'
  exit 1
}

az extension show -n azure-devops > $null
if (!$?){
  Write-Host 'You must have the azure-devops extension run `az extension add --name azure-devops`'
  exit 1
}

. (Join-Path $PSScriptRoot SemVer.ps1)
. (Join-Path $PSScriptRoot Helpers DevOps-WorkItem-Helpers.ps1)

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

$workItem = FindPackageWorkItem -lang $language -packageName $packageName -version $versionMajorMinor -includeClosed $true -outputCommand $false

if (!$workItem) {
  $latestVersionItem = FindLatestPackageWorkItem -lang $language -packageName $packageName -outputCommand $false
  $assignedTo = "me"
  if ($latestVersionItem) {
    Write-Host "Copying data from latest matching [$($latestVersionItem.id)] with version $($latestVersionItem.fields["Custom.PackageVersionMajorMinor"])"
    if ($latestVersionItem.fields["System.AssignedTo"]) {
      $assignedTo = $latestVersionItem.fields["System.AssignedTo"]["uniqueName"]
    }
    $packageInfo.DisplayName = $latestVersionItem.fields["Custom.PackageDisplayName"]
    $packageInfo.ServiceName = $latestVersionItem.fields["Custom.ServiceName"]
    if (!$packageInfo.RepoPath -and $packageInfo.RepoPath -ne "NA" -and $packageInfo.fields["Custom.PackageRepoPath"]) {
      $packageInfo.RepoPath = $packageInfo.fields["Custom.PackageRepoPath"]
    }
  }

  Write-Host "Creating a release work item for a package release with the following properties:"
  Write-Host "  Lanuage: $language"
  Write-Host "  Version: $versionMajorMinor"
  Write-Host "  Package: $packageName"
  Write-Host "  AssignedTo: $assignedTo"

  if (!$packageInfo.DisplayName) {
    Write-Host "We need a package display name to be used in various places and it should be consistent across languages for similar packages."
    while (($readInput = Read-Host -Prompt "Input the display name") -eq "") { }
    $packageInfo.DisplayName = $readInput
  }
  Write-Host "  PackageDisplayName: $($packageInfo.DisplayName)"

  if (!$packageInfo.ServiceName) {
    Write-Host "We need a package service name to be used in various places and it should be consistent across languages for similar packages."
    while (($readInput = Read-Host -Prompt "Input the service name") -eq "") { }
    $packageInfo.ServiceName = $readInput 
  }
  Write-Host "  ServiceName: $($packageInfo.ServiceName)"
  Write-Host "  PackageType: $packageType"

  $workItem = CreateOrUpdatePackageWorkItem -lang $language -pkg $packageInfo -verMajorMinor $versionMajorMinor -assignedTo $assignedTo -outputCommand $false
}

if (!$workItem) {
  Write-Host "Something failed as we don't have a work-item so exiting."
  exit 1
}
Write-Host "Marking item [$($workItem.id)]$($workItem.fields['System.Title']) as '$state' for '$releaseType'"
$updatedWI = UpdatePackageWorkItemReleaseState -id $workItem.id -state "In Release" -releaseType $releaseType -outputCommand $false
UpdatePackageVersions $workItem -plannedVersions $plannedVersions
Write-Host "https://dev.azure.com/azure-sdk/Release/_workitems/edit/$($updatedWI.id)/"

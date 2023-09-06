<#
.SYNOPSIS
The script is to generate service level readme if it is missing. 
For exist ones, we do 2 things here:
1. Generate the client but not import to the existing service level readme.
2. Update the metadata of service level readme

.DESCRIPTION
Given a doc repo location, and the credential for fetching the ms.author. 
Generate missing service level readme and updating metadata of the existing ones.

.PARAMETER DocRepoLocation
Location of the documentation repo. This repo may be sparsely checked out
depending on the requirements for the domain

.PARAMETER TenantId
The aad tenant id/object id for ms.author.

.PARAMETER ClientId
The add client id/application id for ms.author.

.PARAMETER ClientSecret
The client secret of add app for ms.author.

.PARAMETER ReadmeFolderRoot
The readme folder root path, use default value here for backward compability. E.g. docs-ref-services in Java, JS, Python, api/overview/azure
#>

param(
  [Parameter(Mandatory = $true)]
  [string] $DocRepoLocation,

  [Parameter(Mandatory = $false)]
  [string]$TenantId,

  [Parameter(Mandatory = $false)]
  [string]$ClientId,

  [Parameter(Mandatory = $false)]
  [string]$ClientSecret,

  [Parameter(Mandatory = $false)]
  [string]$ReadmeFolderRoot = "docs-ref-services"
)
. $PSScriptRoot/common.ps1
. $PSScriptRoot/Helpers/Service-Level-Readme-Automation-Helpers.ps1
. $PSScriptRoot/Helpers/Metadata-Helpers.ps1
. $PSScriptRoot/Helpers/Package-Helpers.ps1

Set-StrictMode -Version 3

$fullMetadata = Get-CSVMetadata
$monikers = @("latest", "preview")
foreach($moniker in $monikers) {
  # The onboarded packages return is key-value pair, which key is the package index, and value is the package info from {metadata}.json
  # E.g. 
  # Key as: @azure/storage-blob
  # Value as: 
  # {
  #   "Name": "@azure/storage-blob",
  #   "Version": "12.10.0-beta.1",
  #   "DevVersion": null,
  #   "DirectoryPath": "sdk/storage/storage-blob",
  #   "ServiceDirectory": "storage",
  #   "ReadMePath": "sdk/storage/storage-blob/README.md",
  #   "ChangeLogPath": "sdk/storage/storage-blob/CHANGELOG.md",
  #   "Group": null,
  #   "SdkType": "client",
  #   "IsNewSdk": true,
  #   "ArtifactName": "azure-storage-blob",
  #   "ReleaseStatus": "2022-04-19"
  # }
  $onboardedPackages = &$GetOnboardedDocsMsPackagesForMonikerFn `
    -DocRepoLocation $DocRepoLocation -moniker $moniker
  $csvMetadata = @()
  foreach($metadataEntry in $fullMetadata) {
    if ($metadataEntry.Package -and $metadataEntry.Hide -ne 'true') {
      $pkgKey = GetPackageKey $metadataEntry
      if($onboardedPackages.ContainsKey($pkgKey)) {
        if ($onboardedPackages[$pkgKey] -and $onboardedPackages[$pkgKey].DirectoryPath) {
          if (!($metadataEntry.PSObject.Members.Name -contains "DirectoryPath")) {
            Add-Member -InputObject $metadataEntry `
              -MemberType NoteProperty `
              -Name DirectoryPath `
              -Value $onboardedPackages[$pkgKey].DirectoryPath
          }
        }
        $csvMetadata += $metadataEntry
      }
    }
  }
  $packagesForService = @{}
  $allPackages = GetPackageLookup $csvMetadata
  foreach ($metadataKey in $allPackages.Keys) {
    $metadataEntry = $allPackages[$metadataKey]
    if (!$metadataEntry.ServiceName) {
      LogWarning "Empty ServiceName for package `"$metadataKey`". Skipping."
      continue
    }
    $packagesForService[$metadataKey] = $metadataEntry
  }
  $services = @{}
  foreach ($package in $packagesForService.Values) {
    if ($package.ServiceName -eq 'Other') {
      # Skip packages under the service category "Other". Those will be handled
      # later
      continue
    }
    if (!$services.ContainsKey($package.ServiceName)) {
      $services[$package.ServiceName] = $true
    }
  }
  foreach ($service in $services.Keys) {
    Write-Host "Building service: $service"
    $servicePackages = $packagesForService.Values.Where({ $_.ServiceName -eq $service })
    $serviceReadmeBaseName = ServiceLevelReadmeNameStyle -serviceName $service
    # Github url for source code: e.g. https://github.com/Azure/azure-sdk-for-js
    $serviceBaseName = ServiceLevelReadmeNameStyle $service
    $author = GetPrimaryCodeOwner -TargetDirectory "/sdk/$serviceBaseName/"
    $msauthor = ""
    if (!$author) {
      LogError "Cannot fetch the author from CODEOWNER file."
      $author = ""
    }
    elseif ($TenantId -and $ClientId -and $ClientSecret) {
      $msauthor = GetMsAliasFromGithub -TenantId $tenantId -ClientId $clientId -ClientSecret $clientSecret -GithubUser $author
    }
    # Default value
    if (!$msauthor) {
      LogError "No ms.author found for $author. "
      $msauthor = $author
    }
    # Add ability to override
    # Fetch the service readme name
    $msService = GetDocsMsService -packageInfo $servicePackages[0] -serviceName $service
    generate-service-level-readme -docRepoLocation $DocRepoLocation -readmeBaseName $serviceReadmeBaseName -pathPrefix $ReadmeFolderRoot `
      -packageInfos $servicePackages -serviceName $service -moniker $moniker -author $author -msAuthor $msauthor -msService $msService
  }
}

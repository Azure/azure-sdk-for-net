<#
.SYNOPSIS
Update unified ToC file for publishing reference docs on docs.microsoft.com

.DESCRIPTION
Given a doc repo location and a location to output the ToC generate a Unified
Table of Contents:

* Get list of packages onboarded to docs.microsoft.com (domain specific)
* Get metadata for onboarded packages from metadata CSV
* Build a sorted list of services
* Add ToC nodes for the service
* Add "Core" packages to the bottom of the ToC under "Other"

ToC node layout:
* Service (service level overview page)
  * Client Package 1 (package level overview page)
  * Client Package 2 (package level overview page)
  ...
  * Management
    * Management Package 1
    * Management Package 2
    ...

.PARAMETER DocRepoLocation
Location of the documentation repo. This repo may be sparsely checked out
depending on the requirements for the domain

.PARAMETER TenantId
The aad tenant id/object id for ms.author.

.PARAMETER ClientId
The add client id/application id for ms.author.

.PARAMETER ClientSecret
The client secret of add app for ms.author.
#>

param(
  [Parameter(Mandatory = $true)]
  [string] $DocRepoLocation,

  [Parameter(Mandatory = $false)]
  [string]$TenantId,

  [Parameter(Mandatory = $false)]
  [string]$ClientId,

  [Parameter(Mandatory = $false)]
  [string]$ClientSecret
)
. $PSScriptRoot/common.ps1
. $PSScriptRoot/Helpers/Metadata-Helpers.ps1

Set-StrictMode -Version 3

function GetClientPackageNode($clientPackage) {
  $packageInfo = &$GetDocsMsTocDataFn `
    -packageMetadata $clientPackage `
    -docRepoLocation $DocRepoLocation

  return [PSCustomObject]@{
    name     = $packageInfo.PackageTocHeader
    href     = $packageInfo.PackageLevelReadmeHref
    # This is always one package and it must be an array
    children = $packageInfo.TocChildren
  };
}

function GetPackageKey($pkg) {
  $pkgKey = $pkg.Package
  $groupId = $null

  if ($pkg.PSObject.Members.Name -contains "GroupId") {
    $groupId = $pkg.GroupId
  }

  if ($groupId) {
    $pkgKey = "${groupId}:${pkgKey}"
  }

  return $pkgKey
}

function GetPackageLookup($packageList) {
  $packageLookup = @{}

  foreach ($pkg in $packageList) {
    $pkgKey = GetPackageKey $pkg

    # We want to prefer updating non-hidden packages but if there is only
    # a hidden entry then we will return that
    if (!$packageLookup.ContainsKey($pkgKey) -or $packageLookup[$pkgKey].Hide -eq "true") {
      $packageLookup[$pkgKey] = $pkg
    }
    else {
      # Warn if there are more then one non-hidden package
      if ($pkg.Hide -ne "true") {
        Write-Host "Found more than one package entry for $($pkg.Package) selecting the first non-hidden one."
      }
    }
  }

  return $packageLookup
}

function create-metadata-table($readmeFolder, $readmeName, $moniker, $msService, $clientTableLink, $mgmtTableLink, $serviceName)
{
  $readmePath = Join-Path $readmeFolder -ChildPath $readmeName
  $null = New-Item -Path $readmePath -Force
  $lang = $LanguageDisplayName
  $langTitle = "Azure $serviceName SDK for $lang"
  $header = GenerateDocsMsMetadata -language $lang -langTitle $langTitle -serviceName $serviceName `
    -tenantId $TenantId -clientId $ClientId -clientSecret $ClientSecret `
    -msService $msService
  Add-Content -Path $readmePath -Value $header

  # Add tables, seperate client and mgmt.
  $readmeHeader = "# $langTitle - $moniker"
  Add-Content -Path $readmePath -Value $readmeHeader
  if (Test-Path (Join-Path $readmeFolder -ChildPath $clientTableLink)) {
    $clientTable = "## Client packages - $moniker`r`n"
    $clientTable += "[!INCLUDE [client-packages]($clientTableLink)]`r`n"
    Add-Content -Path $readmePath -Value $clientTable
  }
  if (Test-Path (Join-Path $readmeFolder -ChildPath $mgmtTableLink)) {
    $mgmtTable = "## Management packages - $moniker`r`n"
    $mgmtTable += "[!INCLUDE [mgmt-packages]($mgmtTableLink)]`r`n"
    Add-Content -Path $readmePath -Value $mgmtTable -NoNewline
  }
}

# Update the metadata table on attributes: author, ms.author, ms.service
function update-metadata-table($readmeFolder, $readmeName, $serviceName, $msService)
{
  $readmePath = Join-Path $readmeFolder -ChildPath $readmeName
  $readmeContent = Get-Content -Path $readmePath -Raw
  $null = $readmeContent -match "---`n*(?<metadata>(.*`n)*)---`n*(?<content>(.*`n)*)"
  $restContent = $Matches["content"]

  $lang = $LanguageDisplayName
  $metadataString = GenerateDocsMsMetadata -language $lang -serviceName $serviceName `
    -tenantId $TenantId -clientId $ClientId -clientSecret $ClientSecret `
    -msService $msService
  Set-Content -Path $readmePath -Value "$metadataString`n$restContent" -NoNewline
}

function generate-markdown-table($readmeFolder, $readmeName, $packageInfo, $moniker) {
  $tableHeader = "| Reference | Package | Source |`r`n|---|---|---|`r`n" 
  $tableContent = ""
  # Here is the table, the versioned value will
  foreach ($pkg in $packageInfo) {
    $repositoryLink = $RepositoryUri
    $packageLevelReadme = &$GetPackageLevelReadmeFn -packageMetadata $pkg
    $referenceLink = "[$($pkg.DisplayName)]($packageLevelReadme-readme.md)"
    if (!(Test-Path (Join-Path $readmeFolder -ChildPath "$packageLevelReadme-readme.md"))) {
      $referenceLink = $pkg.DisplayName
    }
    $githubLink = $GithubUri
    if ($pkg.PSObject.Members.Name -contains "FileMetadata") {
      $githubLink = "$GithubUri/blob/main/$($pkg.FileMetadata.DirectoryPath)"
    }
    $line = "|$referenceLink|[$($pkg.Package)]($repositoryLink/$($pkg.Package))|[Github]($githubLink)|`r`n"
    $tableContent += $line
  }
  $readmePath = Join-Path $readmeFolder -ChildPath $readmeName
  if($tableContent) {
    $null = New-Item -Path $readmePath -ItemType File -Force
    Add-Content -Path $readmePath -Value $tableHeader -NoNewline
    Add-Content -Path $readmePath -Value $tableContent -NoNewline
  }
}

function generate-service-level-readme($readmeBaseName, $pathPrefix, $packageInfos, $serviceName, $moniker) {
  # Add ability to override
  # Fetch the service readme name
  $msService = GetDocsMsService -packageInfo $packageInfos[0] -serviceName $serviceName

  $readmeFolder = "$DocRepoLocation/$pathPrefix/$moniker/"
  $serviceReadme = "$readmeBaseName.md"
  $clientIndexReadme  = "$readmeBaseName-client-index.md"
  $mgmtIndexReadme  = "$readmeBaseName-mgmt-index.md"
  $clientPackageInfo = $packageInfos.Where({ 'client' -eq $_.Type }) | Sort-Object -Property Package
  if ($clientPackageInfo) {
    generate-markdown-table -readmeFolder $readmeFolder -readmeName "$clientIndexReadme" -packageInfo $clientPackageInfo -moniker $moniker
  }
  $mgmtPackageInfo = $packageInfos.Where({ 'mgmt' -eq $_.Type }) | Sort-Object -Property Package
  if ($mgmtPackageInfo) {
    generate-markdown-table -readmeFolder $readmeFolder -readmeName "$mgmtIndexReadme" -packageInfo $mgmtPackageInfo -moniker $moniker
  }
  if (!(Test-Path (Join-Path $readmeFolder -ChildPath $serviceReadme))) {
    create-metadata-table -readmeFolder $readmeFolder -readmeName $serviceReadme -moniker $moniker -msService $msService `
      -clientTableLink $clientIndexReadme -mgmtTableLink $mgmtIndexReadme `
      -serviceName $serviceName
  }
  else {
    update-metadata-table -readmeFolder $readmeFolder -readmeName $serviceReadme -serviceName $serviceName -msService $msService
  }
}

# This criteria is different from criteria used in `Update-DocsMsPackages.ps1`
# because we need to generate ToCs for packages which are not necessarily "New"
# in the metadata AND onboard legacy packages (which `Update-DocsMsPackages.ps1`
# does not do)
$fullMetadata = Get-CSVMetadata
$monikers = @("latest", "preview")
foreach($moniker in $monikers) {
  $metadata = &$GetOnboardedDocsMsPackagesForMonikerFn `
    -DocRepoLocation $DocRepoLocation -moniker $moniker
  $csvMetadata = @()
  foreach($metadataEntry in $fullMetadata) {
    if ($metadataEntry.Package -and $metadataEntry.Hide -ne 'true') {
      $pkgKey = GetPackageKey $metadataEntry
      if($metadata.ContainsKey($pkgKey)) {
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
  # Get unique service names and sort alphabetically to act as the service nodes
  # in the ToC
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
    # Client packages get individual entries
    $servicePackages = $packagesForService.Values.Where({ $_.ServiceName -eq $service })
  
  
    $serviceReadmeBaseName = $service.ToLower().Replace(' ', '-').Replace('/', '-')
    $hrefPrefix = "docs-ref-services"
  
    generate-service-level-readme -readmeBaseName $serviceReadmeBaseName -pathPrefix $hrefPrefix `
      -packageInfos $servicePackages -serviceName $service -moniker $moniker
  }
}


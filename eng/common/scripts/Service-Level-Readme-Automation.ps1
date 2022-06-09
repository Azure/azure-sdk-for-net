<#
.SYNOPSIS
The script is to generate service level readme if it is missing. 
For exist ones, we do 2 things here:
1. Generate the client and mgmt table but not import to the existing service level readme.
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
. $PSScriptRoot/Helpers/Package-Helpers.ps1

Set-StrictMode -Version 3

function create-metadata-table($readmeFolder, $readmeName, $moniker, $msService, $clientTableLink, $mgmtTableLink, $serviceName)
{
  $readmePath = Join-Path $readmeFolder -ChildPath $readmeName
  $content = ""  
  if (Test-Path (Join-Path $readmeFolder -ChildPath $clientTableLink)) {
    $content = "## Client packages - $moniker`r`n"
    $content += "[!INCLUDE [client-packages]($clientTableLink)]`r`n"
  }
  if (Test-Path (Join-Path $readmeFolder -ChildPath $mgmtTableLink)) {
    $content = "## Management packages - $moniker`r`n"
    $content += "[!INCLUDE [mgmt-packages]($mgmtTableLink)]`r`n"
  }
  if (!$content) {
    return
  }
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
  Add-Content -Path $readmePath -Value $content
}

function CompareAndMergeMetadata ($original, $updated) {
  $originalTable = ConvertFrom-StringData -StringData $original -Delimiter ":"
  $updatedTable = ConvertFrom-StringData -StringData $updated -Delimiter ":"
  foreach ($key in $originalTable.Keys) {
    if (!($updatedTable.ContainsKey($key))) {
      Write-Warning "New metadata missed the entry: $key. Adding back."
      $updatedTable[$key] = $originalTable[$key]
    }
  }
  return $updated
}

# Update the metadata table.
function update-metadata-table($readmeFolder, $readmeName, $serviceName, $msService)
{
  $readmePath = Join-Path $readmeFolder -ChildPath $readmeName
  $readmeContent = Get-Content -Path $readmePath -Raw
  $null = $readmeContent -match "---`n*(?<metadata>(.*`n)*)---`n*(?<content>(.*`n)*)"
  $restContent = $Matches["content"]
  $lang = $LanguageDisplayName
  $orignalMetadata = $Matches["metadata"]
  $metadataString = GenerateDocsMsMetadata -language $lang -serviceName $serviceName `
    -tenantId $TenantId -clientId $ClientId -clientSecret $ClientSecret `
    -msService $msService
  $null = $metadataString -match "---`n*(?<metadata>(.*`n)*)---"
  $mergedMetadata = CompareAndMergeMetadata -original $orignalMetadata -updated $Matches["metadata"]
  Set-Content -Path $readmePath -Value "---`n$mergedMetadata---`n$restContent" -NoNewline
}

function generate-markdown-table($readmeFolder, $readmeName, $packageInfo, $moniker) {
  $tableHeader = "| Reference | Package | Source |`r`n|---|---|---|`r`n" 
  $tableContent = ""
  # Here is the table, the versioned value will
  foreach ($pkg in $packageInfo) {
    $repositoryLink = $RepositoryUri
    $packageLevelReadme = ""
    if (Test-Path "Function:$GetPackageLevelReadmeFn") {
      $packageLevelReadme = &$GetPackageLevelReadmeFn -packageMetadata $pkg
    }
    
    $referenceLink = "[$($pkg.DisplayName)]($packageLevelReadme-readme.md)"
    if (!(Test-Path (Join-Path $readmeFolder -ChildPath "$packageLevelReadme-readme.md"))) {
      $referenceLink = $pkg.DisplayName
    }
    $githubLink = $GithubUri
    if ($pkg.PSObject.Members.Name -contains "DirectoryPath") {
      $githubLink = "$GithubUri/blob/main/$($pkg.DirectoryPath)"
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
  # TODO: we currently do not have the right decision on how we display mgmt packages. Will track the mgmt work in issue. 
  # https://github.com/Azure/azure-sdk-tools/issues/3422
  # $mgmtPackageInfo = $packageInfos.Where({ 'mgmt' -eq $_.Type }) | Sort-Object -Property Package
  # if ($mgmtPackageInfo) {
  #   generate-markdown-table -readmeFolder $readmeFolder -readmeName "$mgmtIndexReadme" -packageInfo $mgmtPackageInfo -moniker $moniker
  # }
  if (!(Test-Path (Join-Path $readmeFolder -ChildPath $serviceReadme))) {
    create-metadata-table -readmeFolder $readmeFolder -readmeName $serviceReadme -moniker $moniker -msService $msService `
      -clientTableLink $clientIndexReadme -mgmtTableLink $mgmtIndexReadme `
      -serviceName $serviceName
  }
  else {
    update-metadata-table -readmeFolder $readmeFolder -readmeName $serviceReadme -serviceName $serviceName -msService $msService
  }
}

$fullMetadata = Get-CSVMetadata
$monikers = @("latest", "preview")
foreach($moniker in $monikers) {
  $onboardedPackages = &$GetOnboardedDocsMsPackagesForMonikerFn `
    -DocRepoLocation $DocRepoLocation -moniker $moniker
  $csvMetadata = @()
  foreach($metadataEntry in $fullMetadata) {
    if ($metadataEntry.Package -and $metadataEntry.Hide -ne 'true') {
      $pkgKey = GetPackageKey $metadataEntry
      if($onboardedPackages.ContainsKey($pkgKey)) {
        $jsonFileName = $pkgKey.Replace('@azure/', 'azure-')
        $jsonFilePath = "$DocRepoLocation/metadata/$moniker/$jsonFileName.json"
        if(!(Test-Path $jsonFilePath)){
          $csvMetadata += $metadataEntry
          continue
        }
        if (!($metadataEntry.PSObject.Members.Name -contains "DirectoryPath")) {
          $metadataJsonFile = Get-Content $jsonFilePath -Raw | ConvertFrom-Json
          Add-Member -InputObject $metadataEntry `
          -MemberType NoteProperty `
          -Name DirectoryPath `
          -Value $metadataJsonFile.DirectoryPath
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
  
  
    $serviceReadmeBaseName = $service.ToLower().Replace(' ', '-').Replace('/', '-')
    $hrefPrefix = "docs-ref-services"
  
    generate-service-level-readme -readmeBaseName $serviceReadmeBaseName -pathPrefix $hrefPrefix `
      -packageInfos $servicePackages -serviceName $service -moniker $moniker
  }
}


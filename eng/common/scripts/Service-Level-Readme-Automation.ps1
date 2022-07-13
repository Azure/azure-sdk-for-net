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
    $content += "## Management packages - $moniker`r`n"
    $content += "[!INCLUDE [mgmt-packages]($mgmtTableLink)]`r`n"
  }
  if (!$content) {
    return
  }
  # Generate the front-matter for docs needs
  # $Language, $LanguageDisplayName are the variables globally defined in Language-Settings.ps1
  $metadataString = GenerateDocsMsMetadata -language $Language -languageDisplayName $LanguageDisplayName -serviceName $serviceName `
    -tenantId $TenantId -clientId $ClientId -clientSecret $ClientSecret `
    -msService $msService
  Add-Content -Path $readmePath -Value $metadataString -NoNewline

  # Add tables, seperate client and mgmt.
  $readmeHeader = "# Azure $serviceName SDK for $languageDisplayName - $moniker`r`n"
  Add-Content -Path $readmePath -Value $readmeHeader
  Add-Content -Path $readmePath -Value $content -NoNewline
}

# Update the metadata table.
function update-metadata-table($readmeFolder, $readmeName, $serviceName, $msService)
{
  $readmePath = Join-Path $readmeFolder -ChildPath $readmeName
  $readmeContent = Get-Content -Path $readmePath -Raw
  $match = $readmeContent -match "^---\n*(?<metadata>(.*\n?)*?)---\n*(?<content>(.*\n?)*)"
  if (!$match) {
    # $Language, $LanguageDisplayName are the variables globally defined in Language-Settings.ps1
    $metadataString = GenerateDocsMsMetadata -language $Language -languageDisplayName $LanguageDisplayName -serviceName $serviceName `
      -tenantId $TenantId -clientId $ClientId -clientSecret $ClientSecret `
      -msService $msService
    Set-Content -Path $readmePath -Value "$metadataString$readmeContent" -NoNewline
    return
  }
  $restContent = $Matches["content"].trim()
  $metadata = $Matches["metadata"].trim()
  # $Language, $LanguageDisplayName are the variables globally defined in Language-Settings.ps1
  $metadataString = GenerateDocsMsMetadata -originalMetadata $metadata -language $Language -languageDisplayName $LanguageDisplayName -serviceName $serviceName `
    -tenantId $TenantId -clientId $ClientId -clientSecret $ClientSecret `
    -msService $msService
  Set-Content -Path $readmePath -Value "$metadataString$restContent" -NoNewline
}

function generate-markdown-table($readmeFolder, $readmeName, $packageInfo, $moniker) {
  $tableHeader = "| Reference | Package | Source |`r`n|---|---|---|`r`n" 
  $tableContent = ""
  # Here is the table, the versioned value will
  foreach ($pkg in $packageInfo) {
    $repositoryLink = "$RepositoryUri/$($pkg.Package)"
    if (Test-Path "Function:$GetRepositoryLinkFn") {
      $repositoryLink = &$GetRepositoryLinkFn -packageInfo $pkg
    }
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
    $line = "|$referenceLink|[$($pkg.Package)]($repositoryLink)|[Github]($githubLink)|`r`n"
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
    generate-markdown-table -readmeFolder $readmeFolder -readmeName $clientIndexReadme -packageInfo $clientPackageInfo -moniker $moniker
  }

  $mgmtPackageInfo = $packageInfos.Where({ 'mgmt' -eq $_.Type }) | Sort-Object -Property Package
  if ($mgmtPackageInfo) {
    generate-markdown-table -readmeFolder $readmeFolder -readmeName $mgmtIndexReadme -packageInfo $mgmtPackageInfo -moniker $moniker
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
    $hrefPrefix = "docs-ref-services"
  
    generate-service-level-readme -readmeBaseName $serviceReadmeBaseName -pathPrefix $hrefPrefix `
      -packageInfos $servicePackages -serviceName $service -moniker $moniker
  }
}

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
    * Management Package 1 (package level overview page)
    * Management Package 2 (package level overview page)
    ...

.PARAMETER DocRepoLocation
Location of the documentation repo. This repo may be sparsely checked out
depending on the requirements for the domain

.PARAMETER OutputLocation
Output location for unified reference yml file

.PARAMETER ReadmeFolderRoot
The readme folder root path, use default value here for backward compability. E.g. docs-ref-services in Java, JS, Python, api/overview/azure

.PARAMETER PackageSourceOverride
Optional parameter to supply a different package source (useful for daily dev
docs generation from pacakges which are not published to the default feed). This
variable is meant to be used in the domain-specific business logic in
&$GetDocsMsTocDataFn
#>

param(
  [Parameter(Mandatory = $true)]
  [string] $DocRepoLocation,

  [Parameter(Mandatory = $true)]
  [string] $OutputLocation,

  [Parameter(Mandatory = $false)]
  [string] $ReadmeFolderRoot = 'docs-ref-services',

  [Parameter(Mandatory = $false)]
  [string] $PackageSourceOverride
)
. $PSScriptRoot/common.ps1
. $PSScriptRoot/Helpers/PSModule-Helpers.ps1

Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module

Set-StrictMode -Version 3

function GetPackageNode($package) {
  $packageInfo = &$GetDocsMsTocDataFn `
    -packageMetadata $package `
    -docRepoLocation $DocRepoLocation `
    -PackageSourceOverride $PackageSourceOverride

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

$onboardedPackages = &$GetOnboardedDocsMsPackagesFn `
  -DocRepoLocation $DocRepoLocation

# This criteria is different from criteria used in `Update-DocsMsPackages.ps1`
# because we need to generate ToCs for packages which are not necessarily "New"
# in the metadata AND onboard legacy packages (which `Update-DocsMsPackages.ps1`
# does not do)
$fullMetadata = Get-CSVMetadata
$metadata = @()
foreach($metadataEntry in $fullMetadata) {
  if ($metadataEntry.Package -and $metadataEntry.Hide -ne 'true') {
    $pkgKey = GetPackageKey $metadataEntry
    if($onboardedPackages.ContainsKey($pkgKey)) {
      $metadata += $metadataEntry
    }
  }
}

$fileMetadata = @()
foreach ($metadataFile in Get-ChildItem "$DocRepoLocation/metadata/*/*.json" -Recurse) {
  $fileContent = Get-Content $metadataFile -Raw
  $metadataEntry = ConvertFrom-Json $fileContent

  if ($metadataEntry) {
    $fileMetadata += $metadataEntry
  }
}

# Add file metadata information to package metadata from metadata CSV. Because
# metadata can exist for packages in both preview and GA there may be more than
# one file metadata entry. If that is the case keep the first entry found. We
# only use the `DirectoryPath` property from the json file metadata at this time
for ($i = 0; $i -lt $metadata.Count; $i++) {
  foreach ($fileEntry in $fileMetadata) {
    if ($fileEntry.Name -eq $metadata[$i].Package) {
      if ($metadata[$i].PSObject.Members.Name -contains "FileMetadata") {
        Write-Host "File metadata already added for $($metadata[$i].Package). Keeping the first entry found."
        continue
      }
      if (!($metadata[$i].PSObject.Members.Name -contains "GroupId") -or ($fileEntry.Group -eq $metadata[$i].GroupId)) {
        Add-Member `
          -InputObject $metadata[$i] `
          -MemberType NoteProperty `
          -Name FileMetadata `
          -Value $fileEntry
      }
    }
  }
}

$packagesForToc = @{}
$allPackages = GetPackageLookup $metadata
foreach ($metadataKey in $allPackages.Keys) {
  $metadataEntry = $allPackages[$metadataKey]
  if (!$metadataEntry.ServiceName) {
    LogWarning "Empty ServiceName for package `"$metadataKey`". Skipping."
    continue
  }
  $packagesForToc[$metadataKey] = $metadataEntry
}

# Get unique service names and sort alphabetically to act as the service nodes
# in the ToC
$services = @{}
foreach ($package in $packagesForToc.Values) {
  if ($package.ServiceName -eq 'Other') {
    # Skip packages under the service category "Other". Those will be handled
    # later
    continue
  }
  if (!$services.ContainsKey($package.ServiceName)) {
    $services[$package.ServiceName] = $true
  }
}
$serviceNameList = $services.Keys | Sort-Object

$toc = @()
foreach ($service in $serviceNameList) {
  Write-Host "Building service: $service"

  $packageItems = @()

  # Client packages get individual entries
  $clientPackages = $packagesForToc.Values.Where({ $_.ServiceName -eq $service -and ('client' -eq $_.Type) })
  $clientPackages = $clientPackages | Sort-Object -Property Package
  foreach ($clientPackage in $clientPackages) {
    $packageItems += GetPackageNode -package $clientPackage
  }

  # All management packages go under a single `Management` header in the ToC
  $mgmtPackages = $packagesForToc.Values.Where({ $_.ServiceName -eq $service -and ('mgmt' -eq $_.Type) })
  $mgmtPackages = $mgmtPackages | Sort-Object -Property Package
  $mgmtItems = @()
  foreach ($pkg in $mgmtPackages) {
    $mgmtItems += GetPackageNode -package $pkg
  }
  if ($mgmtItems) {
    $packageItems += [PSCustomObject]@{
      name     = 'Management'
      items    = $mgmtItems
    }
  }

  $uncategorizedPackages = $packagesForToc.Values.Where({ $_.ServiceName -eq $service -and !(@('client', 'mgmt') -contains $_.Type) })
  if ($uncategorizedPackages) {
    foreach ($package in $uncategorizedPackages) {
      LogWarning "Uncategorized package for service: $service - $($package.Package). Package not onboarded."
    }
  }

  $serviceReadmeBaseName = $service.ToLower().Replace(' ', '-').Replace('/', '-')
  $serviceTocEntry = [PSCustomObject]@{
    name            = $service;
    href            = "~/$ReadmeFolderRoot/{moniker}/$serviceReadmeBaseName.md"
    landingPageType = 'Service'
    items           = @($packageItems)
  }
  $toc += $serviceTocEntry
}

# Core packages belong under the "Other" node in the ToC
$otherPackageItems = New-Object -TypeName System.Collections.Generic.List[PSCustomObject]
$otherPackages = $packagesForToc.Values.Where({ $_.ServiceName -eq 'Other' })
$otherPackages = $otherPackages | Sort-Object -Property DisplayName

if ($otherPackages) {
  foreach ($otherPackage in $otherPackages) {
    $segments = $otherPackage.DisplayName.Split('-').ForEach({ $_.Trim() })


    if ($segments.Count -gt 1) {
      $currentNode = $otherPackageItems

      # Iterate up to the penultimate item in the array so that the final item
      # in the array can be added as a leaf node. Since the array always has at
      # least two elements this iteration will cover at least the first element.
      # e.g. @(0, 1)[0..0] => 0
      foreach ($segment in $segments[0..($segments.Count - 2)]) {
        $matchingNode = $currentNode.Where({ $_.name -eq $segment })

        # ToC nodes can be "branches" which contain 0 or more branch
        # or leaf nodes in an "items" field OR they can be leaf nodes which have
        # a "children" field which can only contain package names or namespaces.
        # A node cannot contain both "items" and "children". If a node already
        # has a "children" field then it is a leaf node and cannot take
        # additional branch nodes.
        # Children are added using the `GetClientPackageNode` function
        if ($matchingNode -and $matchingNode.PSObject.Members.Name -contains "children") {
          LogWarning "Cannot create nested entry for package $($otherPackage.Package) because Segment `"$segment`" in the DisplayName $($otherPackage.DisplayName) is already a leaf node. Excluding package: $($otherPackage.Package)"
          $currentNode = $null
          break
        }

        if ($matchingNode) {
          $currentNode = $matchingNode[0].items
        }
        else {
          $newNode = [PSCustomObject]@{
            name            = $segment
            landingPageType = 'Service'
            items           = New-Object -TypeName System.Collections.Generic.List[PSCustomObject]
          }
          $currentNode.Add($newNode)
          $currentNode = $newNode.items
        }
      }

      if ($null -ne $currentNode) {
        $otherPackage.DisplayName = $segments[$segments.Count - 1]
        $currentNode.Add((GetPackageNode $otherPackage))
      }

    }
    else {
      $otherPackageItems.Add((GetPackageNode $otherPackage))
    }
  }
}
$toc += [PSCustomObject]@{
  name            = 'Other';
  landingPageType = 'Service';
  items           = $otherPackageItems + @(
    [PSCustomObject]@{
      name            = "Uncategorized Packages";
      landingPageType = 'Service';
      # All onboarded packages which have not been placed in the ToC will be
      # handled by the docs system here. In this case the list would consist of
      # packages whose ServiceName field is empty in the metadata.
      children        = @('**');
    }
  )
}

$output = @([PSCustomObject]@{
    name            = 'Reference';
    landingPageType = 'Root';
    expanded        = $false;
    items           = $toc
  })

if (Test-Path "Function:$UpdateDocsMsTocFn") {
  $output = &$UpdateDocsMsTocFn -toc $output
}

$outputYaml = ConvertTo-Yaml $output
Set-Content -Path $OutputLocation -Value $outputYaml
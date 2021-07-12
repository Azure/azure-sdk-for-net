$Language = "dotnet"
$LanguageShort = "net"
$LanguageDisplayName = ".NET"
$PackageRepository = "Nuget"
$packagePattern = "*.nupkg"
$MetadataUri = "https://raw.githubusercontent.com/Azure/azure-sdk/main/_data/releases/latest/dotnet-packages.csv"
$BlobStorageUrl = "https://azuresdkdocs.blob.core.windows.net/%24web?restype=container&comp=list&prefix=dotnet%2F&delimiter=%2F"

function Get-AllPackageInfoFromRepo($serviceDirectory)
{
  $allPackageProps = @()
  $msbuildOutput = dotnet msbuild /nologo /t:GetPackageInfo $EngDir/service.proj /p:ServiceDirectory=$serviceDirectory

  foreach ($projectOutput in $msbuildOutput)
  {
    if (!$projectOutput) { continue }

    $pkgPath, $serviceDirectory, $pkgName, $pkgVersion, $sdkType, $isNewSdk = $projectOutput.Split(' ',[System.StringSplitOptions]::RemoveEmptyEntries).Trim("'")

    $pkgProp = [PackageProps]::new($pkgName, $pkgVersion, $pkgPath, $serviceDirectory)
    $pkgProp.SdkType = $sdkType
    $pkgProp.IsNewSdk = ($isNewSdk -eq 'true')
    $pkgProp.ArtifactName = $pkgName

    $allPackageProps += $pkgProp
  }

  return $allPackageProps
}

# Returns the nuget publish status of a package id and version.
function IsNugetPackageVersionPublished ($pkgId, $pkgVersion)
{
  $nugetUri = "https://api.nuget.org/v3-flatcontainer/$($pkgId.ToLowerInvariant())/index.json"

  try
  {
    $nugetVersions = Invoke-RestMethod -MaximumRetryCount 3 -RetryIntervalSec 10 -uri $nugetUri -Method "GET"
    return $nugetVersions.versions.Contains($pkgVersion)
  }
  catch
  {
    $statusCode = $_.Exception.Response.StatusCode.value__
    $statusDescription = $_.Exception.Response.StatusDescription

    # if this is 404ing, then this pkg has never been published before
    if ($statusCode -eq 404) {
      return $False
    }

    Write-Host "Nuget Invocation failed:"
    Write-Host "StatusCode:" $statusCode
    Write-Host "StatusDescription:" $statusDescription
    exit(1)
  }
}

# Parse out package publishing information given a nupkg ZIP format.
function Get-dotnet-PackageInfoFromPackageFile ($pkg, $workingDirectory)
{
  $workFolder = "$workingDirectory$($pkg.Basename)"
  $origFolder = Get-Location
  $zipFileLocation = "$workFolder/$($pkg.Basename).zip"
  $releaseNotes = ""
  $readmeContent = ""

  New-Item -ItemType Directory -Force -Path $workFolder

  Copy-Item -Path $pkg -Destination $zipFileLocation
  Expand-Archive -Path $zipFileLocation -DestinationPath $workFolder
  [xml] $packageXML = Get-ChildItem -Path "$workFolder/*.nuspec" | Get-Content
  $pkgId = $packageXML.package.metadata.id
  $docsReadMeName = $pkgId -replace "^Azure." , ""
  $pkgVersion = $packageXML.package.metadata.version

  $changeLogLoc = @(Get-ChildItem -Path $workFolder -Recurse -Include "CHANGELOG.md")[0]
  if ($changeLogLoc)
  {
    $releaseNotes = Get-ChangeLogEntryAsString -ChangeLogLocation $changeLogLoc -VersionString $pkgVersion
  }

  $readmeContentLoc = @(Get-ChildItem -Path $workFolder -Recurse -Include "README.md")[0]
  if ($readmeContentLoc)
  {
    $readmeContent = Get-Content -Raw $readmeContentLoc
  }

  Remove-Item $workFolder -Force  -Recurse -ErrorAction SilentlyContinue

  return New-Object PSObject -Property @{
    PackageId      = $pkgId
    PackageVersion = $pkgVersion
    ReleaseTag     = "$($pkgId)_$($pkgVersion)"
    Deployable     = $forceCreate -or !(IsNugetPackageVersionPublished -pkgId $pkgId -pkgVersion $pkgVersion)
    ReleaseNotes   = $releaseNotes
    ReadmeContent  = $readmeContent
    DocsReadMeName = $docsReadMeName
  }
}

# Return list of nupkg artifacts
function Get-dotnet-Package-Artifacts ($Location)
{
  $pkgs = Get-ChildItem "${Location}" -Recurse | Where-Object -FilterScript {$_.Name.EndsWith(".nupkg") -and -not $_.Name.EndsWith(".symbols.nupkg")}
  if (!$pkgs)
  {
    Write-Host "$($Location) does not have any package"
    return $null
  }
  elseif ($pkgs.Count -ne 1)
  {
    Write-Host "$($Location) should contain only one (1) published package"
    Write-Host "No of Packages $($pkgs.Count)"
    return $null
  }
  return $pkgs[0]
}

# Stage and Upload Docs to blob Storage
function Publish-dotnet-GithubIODocs ($DocLocation, $PublicArtifactLocation)
{
  $PublishedPkg = Get-dotnet-Package-Artifacts $DocLocation
  if (!$PublishedPkg)
  {
    Write-Host "Package is not available in artifact path $($DocLocation)"
    exit 1
  }

  $PublishedDocs = Get-ChildItem "${DocLocation}" | Where-Object -FilterScript {$_.Name.EndsWith("docs.zip")}

  if ($PublishedDoc.Count -gt 1)
  {
      Write-Host "$($DocLocation) should contain only one (1) published package and docs"
      Write-Host "No of Docs $($PublishedDoc.Count)"
      exit 1
  }

  $DocsStagingDir = "$WorkingDirectory/docstaging"
  $TempDir = "$WorkingDirectory/temp"

  New-Item -ItemType directory -Path $DocsStagingDir
  New-Item -ItemType directory -Path $TempDir

  Expand-Archive -LiteralPath $PublishedDocs[0].FullName -DestinationPath $DocsStagingDir
  $pkgProperties = Get-dotnet-PackageInfoFromPackageFile -pkg $PublishedPkg.FullName -workingDirectory $TempDir

  Write-Host "Start Upload for $($pkgProperties.ReleaseTag)"
  Write-Host "DocDir $($DocsStagingDir)"
  Write-Host "PkgName $($pkgProperties.PackageId)"
  Write-Host "DocVersion $($pkgProperties.PackageVersion)"
  Upload-Blobs -DocDir "$($DocsStagingDir)" -PkgName $pkgProperties.PackageId -DocVersion $pkgProperties.PackageVersion -ReleaseTag $pkgProperties.ReleaseTag
}

function Get-dotnet-GithubIoDocIndex()
{
  # Update the main.js and docfx.json language content
  UpdateDocIndexFiles -appTitleLang $LanguageDisplayName
  # Fetch out all package metadata from csv file.
  $metadata = Get-CSVMetadata -MetadataUri $MetadataUri
  # Get the artifacts name from blob storage
  $artifacts =  Get-BlobStorage-Artifacts -blobStorageUrl $BlobStorageUrl -blobDirectoryRegex "^dotnet/(.*)/$" -blobArtifactsReplacement '$1'
  # Build up the artifact to service name mapping for GithubIo toc.
  $tocContent = Get-TocMapping -metadata $metadata -artifacts $artifacts
  # Generate yml/md toc files and build site.
  GenerateDocfxTocContent -tocContent $tocContent -lang $LanguageDisplayName
}

# details on CSV schema can be found here
# https://review.docs.microsoft.com/en-us/help/onboard/admin/reference/dotnet/documenting-nuget?branch=master#set-up-the-ci-job
function Update-dotnet-CIConfig($pkgs, $ciRepo, $locationInDocRepo, $monikerId=$null)
{
  $csvLoc = (Join-Path -Path $ciRepo -ChildPath $locationInDocRepo)

  if (-not (Test-Path $csvLoc)) {
    Write-Error "Unable to locate package csv at location $csvLoc, exiting."
    exit(1)
  }

  $allCSVRows = Get-Content $csvLoc
  $visibleInCI = @{}

  # first pull what's already available
  for ($i=0; $i -lt $allCSVRows.Length; $i++) {
    $pkgDef = $allCSVRows[$i]

    # get rid of the modifiers to get just the package id
    $id = $pkgDef.split(",")[1] -replace "\[.*?\]", ""

    $visibleInCI[$id] = $i
  }

  foreach ($releasingPkg in $pkgs) {
    $installModifiers = "tfm=netstandard2.0"
    if ($releasingPkg.IsPrerelease) {
      $installModifiers += ";isPrerelease=true"
    }
    $lineId = $releasingPkg.PackageId.Replace(".","").ToLower()

    if ($visibleInCI.ContainsKey($releasingPkg.PackageId)) {
      $packagesIndex = $visibleInCI[$releasingPkg.PackageId]
      $allCSVRows[$packagesIndex] = "$($lineId),[$installModifiers]$($releasingPkg.PackageId)"
    }
    else {
      $newItem = "$($lineId),[$installModifiers]$($releasingPkg.PackageId)"
      $allCSVRows += ($newItem)
    }
  }

  Set-Content -Path $csvLoc -Value $allCSVRows
}

# function is used to auto generate API View
function Find-dotnet-Artifacts-For-Apireview($artifactDir, $packageName)
{
  # Find all nupkg files in given artifact directory
  $PackageArtifactPath = Join-Path $artifactDir $packageName
  $pkg = Get-dotnet-Package-Artifacts $PackageArtifactPath
  if (!$pkg)
  {
    Write-Host "Package is not available in artifact path $($PackageArtifactPath)"
    return $null
  }
  $packages = @{ $pkg.Name = $pkg.FullName }
  return $packages
}

function SetPackageVersion ($PackageName, $Version, $ServiceDirectory, $ReleaseDate)
{
  if($null -eq $ReleaseDate)
  {
    $ReleaseDate = Get-Date -Format "yyyy-MM-dd"
  }
  & "$EngDir/scripts/Update-PkgVersion.ps1" -ServiceDirectory $ServiceDirectory -PackageName $PackageName `
  -NewVersionString $Version -ReleaseDate $ReleaseDate
}

function GetExistingPackageVersions ($PackageName, $GroupId=$null)
{
  try {
    $existingVersion = Invoke-RestMethod -Method GET -Uri "https://api.nuget.org/v3-flatcontainer/${PackageName}/index.json"
    return $existingVersion.versions
  }
  catch {
    LogError "Failed to retrieve package versions. `n$_"
    return $null
  }
}

function Get-dotnet-DocsMsMetadataForPackage($PackageInfo) {
  $suffix = ''
  $parsedVersion = [AzureEngSemanticVersion]::ParseVersionString($PackageInfo.Version)
  if ($parsedVersion.IsPrerelease) { 
    $suffix = '-pre'
  }

  New-Object PSObject -Property @{ 
    DocsMsReadMeName = $PackageInfo.Name.ToLower() -replace "." , ""
    LatestReadMeLocation = 'api/overview/azure'
    PreviewReadMeLocation = 'api/overview/azure'
    Suffix = $suffix
  }
}


# Details on CSV schema:
# https://review.docs.microsoft.com/en-us/help/onboard/admin/reference/dotnet/documenting-nuget?branch=master#set-up-the-ci-job
# 
# PowerShell's included Import-Csv cmdlet is not sufficient for parsing this 
# format because it does not easily handle rows whose number of columns is 
# greater than the number of columns in the first row. We must manually parse
# this CSV file.
function Get-DocsCiConfig($configPath) {
  Write-Host "Loading csv from $configPath"
  $output = @()
  foreach ($row in Get-Content $configPath) {
      # CSV format: 
      # {package_moniker_base_string},{package_ID},{version_1},{version_2},...,{version_N}
      #
      # The {package_ID} field can contain optional properties denoted by square
      # brackets of the format: [key=value;key=value;...]

      # Split the rows by the comma
      $fields = $row.Split(',')

      # If the {package_ID} field contains optional properties inside square
      # brackets, parse those properties into key value pairs. In the case of 
      # duplicate keys, the last one wins.
      $rawProperties = ''
      $packageProperties = [ordered]@{}
      if ($fields[1] -match '\[(.*)\]') { 
          $rawProperties = $Matches[1] 
          foreach ($propertyExpression in $rawProperties.Split(';')) {
              $propertyParts = $propertyExpression.Split('=')
              $packageProperties[$propertyParts[0]] = $propertyParts[1]
          }
      }

      # Matches the "Package.Name" from the {package_ID} field. Possible
      # formats:
      # [key=value;key=value]Package.Name
      # Package.Name
      $packageName = ''
      if ($fields[1] -match '(\[.*\])?(.*)') { 
          $packageName = $Matches[2] 
      } else { 
          Write-Error "Could not find package id in row: $row" 
      }

      # Remaining entries in the row are versions, add them to the package 
      # properties
      $outputVersions = @()
      if ($fields[2]) {
        $outputVersions = $fields[2..($fields.Count - 1)]
      }

      # Example row: 
      # packagemoniker,[key1=value1;key2=value2]Package.Name,1.0.0,1.2.3-beta.1
      $output += [PSCustomObject]@{
          Id = $fields[0];                  # packagemoniker
          Name = $packageName;              # Package.Name
          Properties = $packageProperties;  # @{key1='value1'; key2='value2'}
          Versions = $outputVersions        # @('1.0.0', '1.2.3-beta.1')
      }
  }

  return $output
}

function Get-DocsCiLine ($item) { 
  $line = ''
  if ($item.Properties.Count) {
    $propertyPairs = @()
    foreach ($key in $item.Properties.Keys) { 
      $propertyPairs += "$key=$($item.Properties[$key])"
    }
    $packageProperties = $propertyPairs -join ';'

    $line = "$($item.Id),[$packageProperties]$($item.Name)"
  } else { 
    $line = "$($item.Id),$($item.Name)"
  }

  if ($item.Versions) {
    $joinedVersions = $item.Versions -join ','
    $line += ",$joinedVersions"
  }

  return $line
}

function Update-dotnet-DocsMsPackages($DocsRepoLocation, $DocsMetadata) {
  UpdateDocsMsPackages `
    (Join-Path $DocsRepoLocation 'bundlepackages/azure-dotnet-preview.csv') `
    'preview' `
    $DocsMetadata 

  UpdateDocsMsPackages `
    (Join-Path $DocsRepoLocation 'bundlepackages/azure-dotnet.csv') `
    'latest' `
    $DocsMetadata
}

function UpdateDocsMsPackages($DocConfigFile, $Mode, $DocsMetadata) {
  Write-Host "Updating configuration: $DocConfigFile with mode: $Mode"
  $packageConfig = Get-DocsCiConfig $DocConfigFile

  $outputPackages = @()
  foreach ($package in $packageConfig) {
    # Do not filter by GA/Preview status because we want differentiate between
    # tracked and non-tracked packages
    $matchingPublishedPackageArray = $DocsMetadata.Where({ $_.Package -eq $package.Name })

    # If this package does not match any published packages keep it in the list.
    # This handles packages which are not tracked in metadata but still need to
    # be built in Docs CI.
    if ($matchingPublishedPackageArray.Count -eq 0) {
      Write-Host "Keep non-tracked preview package: $($package.Name)"
      $outputPackages += $package
      continue
    }

    if ($matchingPublishedPackageArray.Count -gt 1) { 
      LogWarning "Found more than one matching published package in metadata for $($package.Name); only updating first entry"
    }
    $matchingPublishedPackage = $matchingPublishedPackageArray[0]

    if ($Mode -eq 'preview' -and !$matchingPublishedPackage.VersionPreview.Trim()) { 
      # If we are in preview mode and the package does not have a superseding
      # preview version, remove the package from the list. 
      Write-Host "Remove superseded preview package: $($package.Name)"
      continue
    }

    Write-Host "Keep tracked package: $($package.Name)"
    $package.Versions = @($matchingPublishedPackage.VersionGA.Trim())
    if ($Mode -eq 'preview') {
      $package.Versions = @($matchingPublishedPackage.VersionPreview.Trim())
    }
    $outputPackages += $package
  }

  $outputPackagesHash = @{}
  foreach ($package in $outputPackages) {
    $outputPackagesHash[$package.Name] = $true
  }

  $remainingPackages = @() 
  if ($Mode -eq 'preview') { 
    $remainingPackages = $DocsMetadata.Where({ 
      $_.VersionPreview.Trim() -and !$outputPackagesHash.ContainsKey($_.Package)
    })
  } else { 
    $remainingPackages = $DocsMetadata.Where({ 
      $_.VersionGA.Trim() -and !$outputPackagesHash.ContainsKey($_.Package)
    })
  }

  # Add packages that exist in the metadata but are not onboarded in docs config
  # TODO: tfm='netstandard2.0' is a temporary workaround for 
  # https://github.com/Azure/azure-sdk-for-net/issues/22494
  $newPackageProperties = [ordered]@{ tfm = 'netstandard2.0' }
  if ($Mode -eq 'preview') {
    $newPackageProperties['isPrerelease'] = 'true'
  }

  foreach ($package in $remainingPackages) {
    Write-Host "Add new package from metadata: $($package.Package)"
    $versions = @($package.VersionGA.Trim())
    if ($Mode -eq 'preview') {
      $versions = @($package.VersionPreview.Trim())
    }
    $outputPackages += [PSCustomObject]@{
      Id = $package.Package.Replace('.', '').ToLower();
      Name = $package.Package;
      Properties = $newPackageProperties;
      Versions = $versions
    }
  }

  $outputLines = @() 
  foreach ($package in $outputPackages) { 
    $outputLines += Get-DocsCiLine $package
  }
  Set-Content -Path $DocConfigFile -Value $outputLines
}

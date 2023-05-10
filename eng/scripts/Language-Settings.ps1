$Language = "dotnet"
$LanguageShort = "net"
$LanguageDisplayName = ".NET"
$PackageRepository = "Nuget"
$packagePattern = "*.nupkg"
$MetadataUri = "https://raw.githubusercontent.com/Azure/azure-sdk/main/_data/releases/latest/dotnet-packages.csv"
$BlobStorageUrl = "https://azuresdkdocs.blob.core.windows.net/%24web?restype=container&comp=list&prefix=dotnet%2F&delimiter=%2F"
$GithubUri = "https://github.com/Azure/azure-sdk-for-net"
$PackageRepositoryUri = "https://www.nuget.org/packages"

. "$PSScriptRoot/docs/Docs-ToC.ps1"

function Get-AllPackageInfoFromRepo($serviceDirectory)
{
  $allPackageProps = @()
  # $addDevVersion is a global variable set by a parameter in
  # Save-Package-Properties.ps1
  $shouldAddDevVersion = Get-Variable -Name 'addDevVersion' -ValueOnly -ErrorAction 'Ignore'
  $msbuildOutput = dotnet msbuild `
    /nologo `
    /t:GetPackageInfo `
    $EngDir/service.proj `
    /p:ServiceDirectory=$serviceDirectory `
    /p:AddDevVersion=$shouldAddDevVersion

  foreach ($projectOutput in $msbuildOutput)
  {
    if (!$projectOutput) { continue }

    $pkgPath, $serviceDirectory, $pkgName, $pkgVersion, $sdkType, $isNewSdk, $dllFolder = $projectOutput.Split(' ',[System.StringSplitOptions]::RemoveEmptyEntries).Trim("'")
    if(!(Test-Path $pkgPath)) {
      Write-Host "Parsed package path `$pkgPath` does not exist so skipping the package line '$projectOutput'."
      continue
    }

    # Add a step to extract namespaces
    $namespaces = @()
    # The namespaces currently only use for docs.ms toc, which is necessary for internal release.
    if (Test-Path "$dllFolder/Release/netstandard2.0/") {
      $defaultDll = Get-ChildItem "$dllFolder/Release/netstandard2.0/*" -Filter "$pkgName.dll" -Recurse
      if ($defaultDll -and (Test-Path $defaultDll)) {
        Write-Verbose "Here is the dll file path: $($defaultDll.FullName)"
        $namespaces = @(Get-NamespacesFromDll $defaultDll.FullName)
      }
    }
    $pkgProp = [PackageProps]::new($pkgName, $pkgVersion, $pkgPath, $serviceDirectory)
    $pkgProp.SdkType = $sdkType
    $pkgProp.IsNewSdk = ($isNewSdk -eq 'true')
    $pkgProp.ArtifactName = $pkgName
    if ($namespaces) {
      $pkgProp = $pkgProp | Add-Member -MemberType NoteProperty -Name Namespaces -Value $namespaces -PassThru
      Write-Verbose "Here are the namespaces: $($pkgProp.Namespaces)"
    }

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
    $statusDescription = $_.Exception.Response.ReasonPhrase

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
  $pkgs = @(Get-ChildItem $Location -Recurse | Where-Object -FilterScript {$_.Name.EndsWith(".nupkg") -and -not $_.Name.EndsWith(".symbols.nupkg")})
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
  GenerateDocfxTocContent -tocContent $tocContent -lang $LanguageDisplayName -campaignId "UA-62780441-41"
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

function SetPackageVersion ($PackageName, $Version, $ServiceDirectory, $ReleaseDate, $ReplaceLatestEntryTitle=$true)
{
  if($null -eq $ReleaseDate)
  {
    $ReleaseDate = Get-Date -Format "yyyy-MM-dd"
  }
  & "$EngDir/scripts/Update-PkgVersion.ps1" -ServiceDirectory $ServiceDirectory -PackageName $PackageName `
  -NewVersionString $Version -ReleaseDate $ReleaseDate -ReplaceLatestEntryTitle $ReplaceLatestEntryTitle
}

function GetExistingPackageVersions ($PackageName, $GroupId=$null)
{
  try {
    $PackageName = $PackageName.ToLower()
    $existingVersion = Invoke-RestMethod -Method GET -Uri "https://api.nuget.org/v3-flatcontainer/${PackageName}/index.json"
    return $existingVersion.versions
  }
  catch {
    if ($_.Exception.Response.StatusCode -ne 404)
    {
      LogError "Failed to retrieve package versions for ${PackageName}. $($_.Exception.Message)"
    }
    return $null
  }
}

function Get-dotnet-DocsMsMetadataForPackage($PackageInfo) {
  $readmeName = $PackageInfo.Name.ToLower()

  # Readme names (which are used in the URL) should not include redundant terms
  # when viewed in URL form. For example:
  # https://docs.microsoft.com/en-us/dotnet/api/overview/azure/storage.blobs-readme
  # Note how the end of the URL doesn't look like:
  # ".../azure/azure.storage.blobs-readme"

  # This logic eliminates a preceeding "azure." in the readme filename.
  # "azure.storage.blobs" -> "storage.blobs"
  if ($readmeName.StartsWith('azure.')) {
    $readmeName = $readmeName.Substring(6)
  }

  New-Object PSObject -Property @{
    DocsMsReadMeName = $readmeName
    LatestReadMeLocation = 'api/overview/azure/latest'
    PreviewReadMeLocation = 'api/overview/azure/preview'
    Suffix = ''
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

      if (!$fields -or $fields.Count -lt 2) {
        LogError "Please check the csv entry: $configPath."
        LogError "Do include the package name for each of the csv entry."
      }
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
      if ($fields.Count -gt 2 -and $fields[2]) {
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

function EnsureCustomSource($package) {
  # $PackageSourceOverride is a global variable provided in
  # Update-DocsMsPackages.ps1. Its value can set a "customSource" property.
  # If it is empty then the property is not overridden.
  $customPackageSource = Get-Variable -Name 'PackageSourceOverride' -ValueOnly -ErrorAction 'Ignore'
  if (!$customPackageSource) {
    return $package
  }

  if (!(Get-PackageSource -Name CustomPackageSource -ErrorAction Ignore)) {
    Write-Host "Registering custom package source $customPackageSource"
    Register-PackageSource `
      -Name CustomPackageSource `
      -Location $customPackageSource `
      -ProviderName NuGet `
      -Force
  }

  Write-Host "Checking custom package source for $($package.Name)"
  try {
    $existingVersions = Find-Package `
      -Name $package.Name `
      -Source CustomPackageSource `
      -AllVersions `
      -AllowPrereleaseVersions

      if (!$? -or !$existingVersions) { 
        Write-Host "Failed to find package $($package.Name) in custom source $customPackageSource"
        return $package
      }
  }
  catch {
    Write-Error $_ -ErrorAction Continue
    return $package
  }

  # Matches package version against output:
  # "Azure.Security.KeyVault.Secrets 4.3.0-alpha.20210915.3"
  $matchedVersion = $existingVersions.Where({$_.Version -eq $package.Versions})

  if (!$matchedVersion) {
    return $package
  }

  $package.Properties['customSource'] = $customPackageSource
  return $package
}

$PackageExclusions = @{
}

function Update-dotnet-DocsMsPackages($DocsRepoLocation, $DocsMetadata) {

  Write-Host "Excluded packages:"
  foreach ($excludedPackage in $PackageExclusions.Keys) {
    Write-Host "  $excludedPackage - $($PackageExclusions[$excludedPackage])"
  }

  $FilteredMetadata = $DocsMetadata.Where({ !($PackageExclusions.ContainsKey($_.Package)) })

  UpdateDocsMsPackages `
    (Join-Path $DocsRepoLocation 'bundlepackages/azure-dotnet-preview.csv') `
    'preview' `
    $FilteredMetadata

  UpdateDocsMsPackages `
    (Join-Path $DocsRepoLocation 'bundlepackages/azure-dotnet.csv') `
    'latest' `
    $FilteredMetadata
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

    if ($matchingPublishedPackage.Support -eq 'deprecated') { 
      if ($Mode -eq 'legacy') { 

        # Select the GA version, if none use the preview version
        $updatedVersion = $matchingPublishedPackage.VersionGA.Trim()
        if (!$updatedVersion) { 
          $updatedVersion = $matchingPublishedPackage.VersionPreview.Trim()
        }
        $package.Versions = @($updatedVersion)

        Write-Host "Add deprecated package to legacy moniker: $($package.Name)"
        $outputPackages += $package
      } else { 
        Write-Host "Removing deprecated package: $($package.Name)"
      }

      continue
    }

    $updatedVersion = $matchingPublishedPackage.VersionGA.Trim()
    if ($Mode -eq 'preview') {
      $updatedVersion = $matchingPublishedPackage.VersionPreview.Trim()
    }

    if ($updatedVersion -ne $package.Versions[0]) {
      Write-Host "Update tracked package: $($package.Name) to version $updatedVersion"
      $package.Versions = @($updatedVersion)
      $package = EnsureCustomSource $package
    } else {
      Write-Host "Keep tracked package: $($package.Name)"
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

    $newPackage = [PSCustomObject]@{
      Id = $package.Package.Replace('.', '').ToLower();
      Name = $package.Package;
      Properties = $newPackageProperties;
      Versions = $versions
    }
    $newPackage = EnsureCustomSource $newPackage

    $outputPackages += $newPackage
  }

  $outputLines = @()
  foreach ($package in $outputPackages) {
    $outputLines += Get-DocsCiLine $package
  }
  Set-Content -Path $DocConfigFile -Value $outputLines
}

function Get-dotnet-EmitterName() {
  return "@azure-tools/typespec-csharp"
}

function Get-dotnet-EmitterAdditionalOptions([string]$projectDirectory) {
  return "--option @azure-tools/typespec-csharp.emitter-output-dir=$projectDirectory/src"
}

$Language = "dotnet"
$LanguageShort = "net"
$LanguageDisplayName = ".NET"
$PackageRepository = "Nuget"
$packagePattern = "*.nupkg"
$MetadataUri = "https://raw.githubusercontent.com/Azure/azure-sdk/master/_data/releases/latest/dotnet-packages.csv"
$BlobStorageUrl = "https://azuresdkdocs.blob.core.windows.net/%24web?restype=container&comp=list&prefix=dotnet%2F&delimiter=%2F"

function Get-dotnet-PackageInfoFromRepo ($pkgPath, $serviceDirectory)
{
  $projDirPath = (Join-Path $pkgPath "src")

  if (!(Test-Path $projDirPath))
  {
    return $null
  }

  $projectPaths = @(Resolve-Path (Join-Path $projDirPath "*.csproj"))
  
  if ($projectpaths.Count -ge 1) {
    $projectPath = $projectPaths[0].path
    if ($projectPaths.Count -gt 1) {
      LogWarning "There is more than on csproj file in the projectpath/src directory. First project picked."
    }
  }
  else {
    return $null
  }

  if ($projectPath -and (Test-Path $projectPath))
  {
    $pkgName = Split-Path -Path $projectPath -LeafBase 
    $projectData = New-Object -TypeName XML
    $projectData.load($projectPath)
    $pkgVersion = Select-XML -Xml $projectData -XPath '/Project/PropertyGroup/Version'
    $sdkType = "client"
    if ($pkgName -match "\.ResourceManager\." -or $pkgName -match "\.Management\.")
    {
      $sdkType = "mgmt"
    }
    $pkgProp = [PackageProps]::new($pkgName, $pkgVersion, $pkgPath, $serviceDirectory)
    $pkgProp.SdkType = $sdkType
    $pkgProp.IsNewSdk = $pkgName.StartsWith("Azure")
    $pkgProp.ArtifactName = $pkgName
    return $pkgProp
  }

  return $null
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

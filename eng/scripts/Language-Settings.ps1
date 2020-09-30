$Language = "dotnet"
$LanguageShort = "net"
$PackageRepository = "Nuget"
$packagePattern = "*.nupkg"
$MetadataUri = "https://raw.githubusercontent.com/Azure/azure-sdk/master/_data/releases/latest/dotnet-packages.csv"

function Get-dotnet-PackageInfoFromRepo ($pkgPath, $serviceDirectory, $pkgName)
{
  $projectPath = Join-Path $pkgPath "src" "$pkgName.csproj"
  if (Test-Path $projectPath)
  {
    $projectData = New-Object -TypeName XML
    $projectData.load($projectPath)
    $pkgVersion = Select-XML -Xml $projectData -XPath '/Project/PropertyGroup/Version'
    return [PackageProps]::new($pkgName, $pkgVersion, $pkgPath, $serviceDirectory)
  }
  else
  {
    return $null
  }
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
    Deployable     = $forceCreate -or !(IsNugetPackageVersionPublished -pkgId $pkgId -pkgVersion $pkgVersion)
    ReleaseNotes   = $releaseNotes
    ReadmeContent  = $readmeContent
  }
}

# Stage and Upload Docs to blob Storage
function Publish-dotnet-GithubIODocs ($DocLocation, $PublicArtifactLocation)
{
  $PublishedPkgs = Get-ChildItem "$($DocLocation)" | Where-Object -FilterScript {$_.Name.EndsWith(".nupkg") -and -not $_.Name.EndsWith(".symbols.nupkg")}
  $PublishedDocs = Get-ChildItem "$($DocLocation)" | Where-Object -FilterScript {$_.Name.EndsWith("docs.zip")}

  if (($PublishedPkgs.Count -gt 1) -or ($PublishedDoc.Count -gt 1))
  {
      Write-Host "$($DocLocation) should contain only one (1) published package and docs"
      Write-Host "No of Packages $($PublishedPkgs.Count)"
      Write-Host "No of Docs $($PublishedDoc.Count)"
      exit 1
  }

  $DocsStagingDir = "$WorkingDirectory/docstaging"
  $TempDir = "$WorkingDirectory/temp"

  New-Item -ItemType directory -Path $DocsStagingDir
  New-Item -ItemType directory -Path $TempDir

  Expand-Archive -LiteralPath $PublishedDocs[0].FullName -DestinationPath $DocsStagingDir
  $pkgProperties = ParseNugetPackage -pkg $PublishedPkgs[0].FullName -workingDirectory $TempDir

  Write-Host "Start Upload for $($pkgProperties.Tag)"
  Write-Host "DocDir $($DocsStagingDir)"
  Write-Host "PkgName $($pkgProperties.PackageId)"
  Write-Host "DocVersion $($pkgProperties.PackageVersion)"
  Upload-Blobs -DocDir "$($DocsStagingDir)" -PkgName $pkgProperties.PackageId -DocVersion $pkgProperties.PackageVersion -ReleaseTag $pkgProperties.Tag
}
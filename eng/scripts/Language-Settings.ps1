$Language = "dotnet"
$Lang = "net"
$PackageRepository = "Nuget"
$packagePattern = "*.nupkg"
$MetadataUri = "https://raw.githubusercontent.com/Azure/azure-sdk/master/_data/releases/latest/dotnet-packages.csv"

function Extract-dotnet-PkgProperties ($pkgPath, $serviceName, $pkgName)
{
  $projectPath = Join-Path $pkgPath "src" "$pkgName.csproj"
  if (Test-Path $projectPath)
  {
    $projectData = New-Object -TypeName XML
    $projectData.load($projectPath)
    $pkgVersion = Select-XML -Xml $projectData -XPath '/Project/PropertyGroup/Version'
    return [PackageProps]::new($pkgName, $pkgVersion, $pkgPath, $serviceName)
  }
  else
  {
    return $null
  }
}

# Returns the nuget publish status of a package id and version.
function IsNugetPackageVersionPublished($pkgId, $pkgVersion) 
{
  $nugetUri = "https://api.nuget.org/v3-flatcontainer/$($pkgId.ToLowerInvariant())/index.json"

  try
  {
    $nugetVersions = Invoke-RestMethod -MaximumRetryCount 3 -uri $nugetUri -Method "GET"
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
function Parse-dotnet-Package($pkg, $workingDirectory) 
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
function StageAndUpload-dotnet-Docs ()
{
  $PublishedPkgs = Get-ChildItem "$($DocLocation)/packages" | Where-Object -FilterScript {$_.Name.EndsWith(".nupkg") -and -not $_.Name.EndsWith(".symbols.nupkg")}
  $PublishedDocs = Get-ChildItem "$($DocLocation)" | Where-Object -FilterScript {$_.Name.StartsWith("Docs.")}

  foreach ($Item in $PublishedDocs)
  {
    $PkgName = $Item.Name.Remove(0, 5)
    $PkgFullName = $PublishedPkgs | Where-Object -FilterScript {$_.Name -match "$($PkgName).\d"}

    if (($PkgFullName | Measure-Object).count -eq 1)
    {
      $DocVersion = $PkgFullName[0].BaseName.Remove(0, $PkgName.Length + 1)

      Write-Host "Start Upload for $($PkgName)/$($DocVersion)"
      Write-Host "DocDir $($Item)"
      Write-Host "PkgName $($PkgName)"
      Write-Host "DocVersion $($DocVersion)"
      Upload-Blobs -DocDir "$($Item)" -PkgName $PkgName -DocVersion $DocVersion
    }
    else
    {
      Write-Host "Package with the same name Exists. Upload Skipped"
      continue
    }
  }
}
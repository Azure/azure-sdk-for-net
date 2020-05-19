. (Join-Path $PSScriptRoot SemVer.ps1)

$SDIST_PACKAGE_REGEX = "^(?<package>.*)\-(?<versionstring>$([AzureEngSemanticVersion]::SEMVER_REGEX))"

# Posts a github release for each item of the pkgList variable. SilentlyContinue
function CreateReleases($pkgList, $releaseApiUrl, $releaseSha) {
  foreach ($pkgInfo in $pkgList) {
    Write-Host "Creating release $($pkgInfo.Tag)"

    $releaseNotes = ""
    if ($pkgInfo.ReleaseNotes[$pkgInfo.PackageVersion].ReleaseContent -ne $null) {
      $releaseNotes = $pkgInfo.ReleaseNotes[$pkgInfo.PackageVersion].ReleaseContent
    }

    $isPrerelease = $False

    $parsedSemver = [AzureEngSemanticVersion]::ParseVersionString($pkgInfo.PackageVersion)

    if ($parsedSemver) {
      $isPrerelease = $parsedSemver.IsPrerelease
    }

    $url = $releaseApiUrl
    $body = ConvertTo-Json @{
      tag_name         = $pkgInfo.Tag
      target_commitish = $releaseSha
      name             = $pkgInfo.Tag
      draft            = $False
      prerelease       = $isPrerelease
      body             = $releaseNotes
    }

    $headers = @{
      "Content-Type"  = "application/json"
      "Authorization" = "token $($env:GH_TOKEN)"
    }

    Invoke-WebRequest-WithHandling -url $url -body $body -headers $headers -method "Post"
  }
}

function Invoke-WebRequest-WithHandling($url, $method, $body = $null, $headers = $null) {
  $attempts = 1

  while ($attempts -le 3) {
    try {
      return Invoke-RestMethod -Method $method -Uri $url -Body $body -Headers $headers
    }
    catch {
      $response = $_.Exception.Response

      $statusCode = $response.StatusCode.value__
      $statusDescription = $response.StatusDescription

      if ($statusCode) {
        Write-Host "API request attempt number $attempts to $url failed with statuscode $statusCode"
        Write-Host $statusDescription

        Write-Host "Rate Limit Details:"
        Write-Host "Total: $($response.Headers.GetValues("X-RateLimit-Limit"))"
        Write-Host "Remaining: $($response.Headers.GetValues("X-RateLimit-Remaining"))"
        Write-Host "Reset Epoch: $($response.Headers.GetValues("X-RateLimit-Reset"))"
      }
      else {
        Write-Host "API request attempt number $attempts to $url failed with no statuscode present, exception follows:"
        Write-Host $_.Exception.Response
        Write-Host $_.Exception
      }

      if ($attempts -ge 3) {
        Write-Host "Abandoning Request $url after 3 attempts."
        exit(1)
      }

      Start-Sleep -s 10
    }

    $attempts += 1
  }
}

# Parse out package publishing information given a maven POM file
function ParseMavenPackage($pkg, $workingDirectory) {
  [xml]$contentXML = Get-Content $pkg

  $pkgId = $contentXML.project.artifactId
  $pkgVersion = $contentXML.project.version
  $groupId = if ($contentXML.project.groupId -eq $null) { $contentXML.project.parent.groupId } else { $contentXML.project.groupId }

  # if it's a snapshot. return $null (as we don't want to create tags for this, but we also don't want to fail)
  if ($pkgVersion.Contains("SNAPSHOT")) {
    return $null
  }

  $releaseNotes = &"${PSScriptRoot}/../Extract-ReleaseNotes.ps1" -ChangeLogLocation @(Get-ChildItem -Path $pkg.DirectoryName -Recurse -Include "$($pkg.Basename)-changelog.md")[0]

  $readmeContentLoc = @(Get-ChildItem -Path $pkg.DirectoryName -Recurse -Include "$($pkg.Basename)-readme.md")[0]
  if (Test-Path -Path $readmeContentLoc) {
    $readmeContent = Get-Content -Raw $readmeContentLoc
  }

  return New-Object PSObject -Property @{
    PackageId      = $pkgId
    PackageVersion = $pkgVersion
    Deployable     = $forceCreate -or !(IsMavenPackageVersionPublished -pkgId $pkgId -pkgVersion $pkgVersion -groupId $groupId.Replace(".", "/"))
    ReleaseNotes   = $releaseNotes
    ReadmeContent  = $readmeContent
  }
}

# Returns the maven (really sonatype) publish status of a package id and version.
function IsMavenPackageVersionPublished($pkgId, $pkgVersion, $groupId) {
  try {

    $uri = "https://oss.sonatype.org/content/repositories/releases/$groupId/$pkgId/$pkgVersion/$pkgId-$pkgVersion.pom"
    $pomContent = Invoke-RestMethod -MaximumRetryCount 3 -Method "GET" -uri $uri

    if ($pomContent -ne $null -or $pomContent.Length -eq 0) {
      return $true
    }
    else {
      return $false
    }
  }
  catch {
    $statusCode = $_.Exception.Response.StatusCode.value__
    $statusDescription = $_.Exception.Response.StatusDescription

    # if this is 404ing, then this pkg has never been published before
    if ($statusCode -eq 404) {
      return $false
    }

    Write-Host "VersionCheck to maven for packageId $pkgId failed with statuscode $statusCode"
    Write-Host $statusDescription
    exit(1)
  }
}

# make certain to always take the package json closest to the top
function ResolvePkgJson($workFolder) {
  $pathsWithComplexity = @()
  foreach ($file in (Get-ChildItem -Path $workFolder -Recurse -Include "package.json")) {
    $complexity = ($file.FullName -Split { $_ -eq "/" -or $_ -eq "\" }).Length
    $pathsWithComplexity += New-Object PSObject -Property @{
      Path       = $file
      Complexity = $complexity
    }
  }

  return ($pathsWithComplexity | Sort-Object -Property Complexity)[0].Path
}

# Parse out package publishing information given a .tgz npm artifact
function ParseNPMPackage($pkg, $workingDirectory) {
  $workFolder = "$workingDirectory$($pkg.Basename)"
  $origFolder = Get-Location
  New-Item -ItemType Directory -Force -Path $workFolder
  cd $workFolder

  tar -xzf $pkg

  $packageJSON = ResolvePkgJson -workFolder $workFolder | Get-Content | ConvertFrom-Json
  $releaseNotes = &"${PSScriptRoot}/../Extract-ReleaseNotes.ps1" -ChangeLogLocation @(Get-ChildItem -Path $workFolder -Recurse -Include "CHANGELOG.md")[0]
  $readmeContentLoc = @(Get-ChildItem -Path $workFolder -Recurse -Include "README.md")[0]
  if (Test-Path -Path $readmeContentLoc) {
    $readmeContent = Get-Content -Raw $readmeContentLoc
  }

  cd $origFolder
  Remove-Item $workFolder -Force  -Recurse -ErrorAction SilentlyContinue

  $pkgId = $packageJSON.name
  $pkgVersion = $packageJSON.version

  $resultObj = New-Object PSObject -Property @{
    PackageId      = $pkgId
    PackageVersion = $pkgVersion
    Deployable     = $forceCreate -or !(IsNPMPackageVersionPublished -pkgId $pkgId -pkgVersion $pkgVersion)
    ReleaseNotes   = $releaseNotes
    ReadmeContent  = $readmeContent
  }

  return $resultObj
}

# Returns the npm publish status of a package id and version.
function IsNPMPackageVersionPublished($pkgId, $pkgVersion) {
  $npmVersions = (npm show $pkgId versions)

  if ($LastExitCode -ne 0) {
    npm ping

    if ($LastExitCode -eq 0) {
      return $False
    }

    Write-Host "Could not find a deployed version of $pkgId, and NPM connectivity check failed."
    exit(1)
  }

  $npmVersionList = $npmVersions.split(",") | % { return $_.replace("[", "").replace("]", "").Trim() }
  return $npmVersionList.Contains($pkgVersion)
}

# Parse out package publishing information given a nupkg ZIP format.
function ParseNugetPackage($pkg, $workingDirectory) {
  $workFolder = "$workingDirectory$($pkg.Basename)"
  $origFolder = Get-Location
  $zipFileLocation = "$workFolder/$($pkg.Basename).zip"
  New-Item -ItemType Directory -Force -Path $workFolder

  Copy-Item -Path $pkg -Destination $zipFileLocation
  Expand-Archive -Path $zipFileLocation -DestinationPath $workFolder
  [xml] $packageXML = Get-ChildItem -Path "$workFolder/*.nuspec" | Get-Content
  $releaseNotes = &"${PSScriptRoot}/../Extract-ReleaseNotes.ps1" -ChangeLogLocation @(Get-ChildItem -Path $workFolder -Recurse -Include "CHANGELOG.md")[0]

  $readmeContentLoc = @(Get-ChildItem -Path $workFolder -Recurse -Include "README.md")[0]
  if (Test-Path -Path $readmeContentLoc) {
    $readmeContent = Get-Content -Raw $readmeContentLoc
  }

  Remove-Item $workFolder -Force  -Recurse -ErrorAction SilentlyContinue
  $pkgId = $packageXML.package.metadata.id
  $pkgVersion = $packageXML.package.metadata.version

  return New-Object PSObject -Property @{
    PackageId      = $pkgId
    PackageVersion = $pkgVersion
    Deployable     = $forceCreate -or !(IsNugetPackageVersionPublished -pkgId $pkgId -pkgVersion $pkgVersion)
    ReleaseNotes   = $releaseNotes
    ReadmeContent  = $readmeContent
  }
}

# Returns the nuget publish status of a package id and version.
function IsNugetPackageVersionPublished($pkgId, $pkgVersion) {

  $nugetUri = "https://api.nuget.org/v3-flatcontainer/$($pkgId.ToLowerInvariant())/index.json"

  try {
    $nugetVersions = Invoke-RestMethod -MaximumRetryCount 3 -uri $nugetUri -Method "GET"

    return $nugetVersions.versions.Contains($pkgVersion)
  }
  catch {
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

# Parse out package publishing information given a python sdist of ZIP format.
function ParsePyPIPackage($pkg, $workingDirectory) {
  $pkg.Basename -match $SDIST_PACKAGE_REGEX | Out-Null

  $pkgId = $matches["package"]
  $pkgVersion = $matches["versionstring"]

  $workFolder = "$workingDirectory$($pkg.Basename)"
  $origFolder = Get-Location
  New-Item -ItemType Directory -Force -Path $workFolder

  Expand-Archive -Path $pkg -DestinationPath $workFolder
  $releaseNotes = &"${PSScriptRoot}/../Extract-ReleaseNotes.ps1" -ChangeLogLocation @(Get-ChildItem -Path $workFolder -Recurse -Include "CHANGELOG.md")[0]
  $readmeContentLoc = @(Get-ChildItem -Path $workFolder -Recurse -Include "README.md")[0]
  if (Test-Path -Path $readmeContentLoc) {
    $readmeContent = Get-Content -Raw $readmeContentLoc
  }
  Remove-Item $workFolder -Force  -Recurse -ErrorAction SilentlyContinue

  return New-Object PSObject -Property @{
    PackageId      = $pkgId
    PackageVersion = $pkgVersion
    Deployable     = $forceCreate -or !(IsPythonPackageVersionPublished -pkgId $pkgId -pkgVersion $pkgVersion)
    ReleaseNotes   = $releaseNotes
    ReadmeContent  = $readmeContent
  }
}

function ParseCArtifact($pkg, $workingDirectory) {
  $packageInfo = Get-Content -Raw -Path $pkg | ConvertFrom-JSON
  $packageArtifactLocation = (Get-ItemProperty $pkg).Directory.FullName

  $releaseNotes = ExtractReleaseNotes -changeLogLocation @(Get-ChildItem -Path $packageArtifactLocation -Recurse -Include "CHANGELOG.md")[0]

  $readmeContentLoc = @(Get-ChildItem -Path $packageArtifactLocation -Recurse -Include "README.md")[0]
  if (Test-Path -Path $readmeContentLoc) {
    $readmeContent = Get-Content -Raw $readmeContentLoc
  }

  return New-Object PSObject -Property @{
    PackageId      = $packageInfo.name
    PackageVersion = $packageInfo.version
    # Artifact info is always considered deployable for C becasue it is not
    # deployed anywhere. Dealing with duplicate tags happens downstream in
    # CheckArtifactShaAgainstTagsList
    Deployable     = $true
    ReleaseNotes   = $releaseNotes
    ReadmeContent  = $readmeContent
  }
}

# Returns the pypi publish status of a package id and version.
function IsPythonPackageVersionPublished($pkgId, $pkgVersion) {
  try {
    $existingVersion = (Invoke-RestMethod -MaximumRetryCount 3 -Method "Get" -uri "https://pypi.org/pypi/$pkgId/$pkgVersion/json").info.version

    # if existingVersion exists, then it's already been published
    return $True
  }
  catch {
    $statusCode = $_.Exception.Response.StatusCode.value__
    $statusDescription = $_.Exception.Response.StatusDescription

    # if this is 404ing, then this pkg has never been published before
    if ($statusCode -eq 404) {
      return $False
    }

    Write-Host "PyPI Invocation failed:"
    Write-Host "StatusCode:" $statusCode
    Write-Host "StatusDescription:" $statusDescription
    exit(1)
  }
}

# Retrieves the list of all tags that exist on the target repository
function GetExistingTags($apiUrl) {
  try {
    return (Invoke-WebRequest-WithHandling -Method "GET" -url "$apiUrl/git/refs/tags"  ) | % { $_.ref.Replace("refs/tags/", "") }
  }
  catch {
    $statusCode = $_.Exception.Response.StatusCode.value__
    $statusDescription = $_.Exception.Response.StatusDescription

    Write-Host "Failed to retrieve tags from repository."
    Write-Host "StatusCode:" $statusCode
    Write-Host "StatusDescription:" $statusDescription

    # Return an empty list if there are no tags in the repo
    if ($statusCode -eq 404) {
      return @()
    }

    exit(1)
  }
}

# Walk across all build artifacts, check them against the appropriate repository, return a list of tags/releases
function VerifyPackages($pkgRepository, $artifactLocation, $workingDirectory, $apiUrl, $releaseSha,  $continueOnError = $false) {
  $pkgList = [array]@()
  $ParsePkgInfoFn = ""
  $packagePattern = ""

  switch ($pkgRepository) {
    "Maven" {
      $ParsePkgInfoFn = "ParseMavenPackage"
      $packagePattern = "*.pom"
      break
    }
    "Nuget" {
      $ParsePkgInfoFn = "ParseNugetPackage"
      $packagePattern = "*.nupkg"
      break
    }
    "NPM" {
      $ParsePkgInfoFn = "ParseNPMPackage"
      $packagePattern = "*.tgz"
      break
    }
    "PyPI" {
      $ParsePkgInfoFn = "ParsePyPIPackage"
      $packagePattern = "*.zip"
      break
    }
    "C" {
      $ParsePkgInfoFn = "ParseCArtifact"
      $packagePattern = "*.json"
    }
    default {
      Write-Host "Unrecognized Language: $language"
      exit(1)
    }
  }

  $pkgs = (Get-ChildItem -Path $artifactLocation -Include $packagePattern -Recurse -File)

  foreach ($pkg in $pkgs) {
    try {
      $parsedPackage = &$ParsePkgInfoFn -pkg $pkg -workingDirectory $workingDirectory

      if ($parsedPackage -eq $null) {
        continue
      }

      if ($parsedPackage.Deployable -ne $True -and !$continueOnError) {
        Write-Host "Package $($parsedPackage.PackageId) is marked with version $($parsedPackage.PackageVersion), the version $($parsedPackage.PackageVersion) has already been deployed to the target repository."
        Write-Host "Maybe a pkg version wasn't updated properly?"
        exit(1)
      }

      $pkgList += New-Object PSObject -Property @{
        PackageId      = $parsedPackage.PackageId
        PackageVersion = $parsedPackage.PackageVersion
        Tag            = ($parsedPackage.PackageId + "_" + $parsedPackage.PackageVersion)
        ReleaseNotes   = $parsedPackage.ReleaseNotes
        ReadmeContent  = $parsedPackage.ReadmeContent
      }
    }
    catch {
      Write-Host $_.Exception.Message
      exit(1)
    }
  }

  $results = @([array]$pkgList | Sort-Object -Property Tag -uniq)

  $existingTags = GetExistingTags($apiUrl)
  
  $intersect = $results | % { $_.Tag } | ? { $existingTags -contains $_ }

  if ($intersect.Length -gt 0 -and !$continueOnError) {
    CheckArtifactShaAgainstTagsList -priorExistingTagList $intersect -releaseSha $releaseSha -apiUrl $apiUrl -continueOnError $continueOnError

    # all the tags are clean. remove them from the list of releases we will publish.
    $results = $results | ? { -not ($intersect -contains $_.Tag ) }
  }

  return $results
}

# given a set of tags that we want to release, we need to ensure that if they already DO exist.
# if they DO exist, quietly exit if the commit sha of the artifact matches that of the tag
# if the commit sha does not match, exit with error and report both problem shas
function CheckArtifactShaAgainstTagsList($priorExistingTagList, $releaseSha, $apiUrl, $continueOnError) {
  $headers = @{
    "Content-Type"  = "application/json"
    "Authorization" = "token $($env:GH_TOKEN)"
  }

  $unmatchedTags = @()

  foreach ($tag in $priorExistingTagList) {
    $tagSha = (Invoke-WebRequest-WithHandling -Method "Get" -Url "$apiUrl/git/refs/tags/$tag" -Headers $headers)."object".sha

    if ($tagSha -eq $releaseSha) {
      Write-Host "This package has already been released. The existing tag commit SHA $releaseSha matches the artifact SHA being processed. Skipping release step for this tag."
    }
    else {
      Write-Host "The artifact SHA $releaseSha does not match that of the currently existing tag."
      Write-Host "Tag with issues is $tag with commit SHA $tagSha"

      $unmatchedTags += $tag
    }
  }

  if ($unmatchedTags.Length -gt 0 -and !$continueOnError) {
    Write-Host "Tags already existing with different SHA versions. Exiting."
    exit(1)
  }
}
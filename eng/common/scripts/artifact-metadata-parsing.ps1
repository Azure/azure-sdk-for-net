. (Resolve-Path "${PSScriptRoot}/common.ps1")

$SDIST_PACKAGE_REGEX = "^(?<package>.*)\-(?<versionstring>$([AzureEngSemanticVersion]::SEMVER_REGEX))"

# Posts a github release for each item of the pkgList variable. SilentlyContinue
function CreateReleases($pkgList, $releaseApiUrl, $releaseSha) {
  foreach ($pkgInfo in $pkgList) {
    Write-Host "Creating release $($pkgInfo.Tag)"

    $releaseNotes = ""
    if ($pkgInfo.ReleaseNotes -ne $null) {
      $releaseNotes = $pkgInfo.ReleaseNotes
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
function VerifyPackages($artifactLocation, $workingDirectory, $apiUrl, $releaseSha,  $continueOnError = $false) {
  $pkgList = [array]@()

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

      $tag = if ($parsedPackage.packageId) {
        "$($parsedPackage.packageId)_$($parsedPackage.PackageVersion)"
      } else {
        $parsedPackage.PackageVersion
      }

      $pkgList += New-Object PSObject -Property @{
        PackageId      = $parsedPackage.PackageId
        PackageVersion = $parsedPackage.PackageVersion
        Tag            = $tag
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
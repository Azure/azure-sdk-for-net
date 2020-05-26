# Note, due to how `Expand-Archive` is leveraged in this script,
# powershell core is a requirement for successful execution.
param (
  # arguments leveraged to parse and identify artifacts
  $ArtifactLocation, # the root of the artifact folder. DevOps $(System.ArtifactsDirectory)
  $WorkDirectory, # a clean folder that we can work in
  $ReleaseSHA, # the SHA for the artifacts. DevOps: $(Release.Artifacts.<artifactAlias>.SourceVersion) or $(Build.SourceVersion)
  $RepoId, # full repo id. EG azure/azure-sdk-for-net  DevOps: $(Build.Repository.Id). Used as a part of VerifyPackages
  $Repository, # EG: "Maven", "PyPI", "NPM"

  # arguments necessary to power the docs release
  $DocRepoLocation, # the location on disk where we have cloned the documentation repository
  $Language, # EG: js, java, dotnet. Used in language for the embedded readme.
  $DocRepoContentLocation = "docs-ref-services/" # within the doc repo, where does our readme go?
)

Write-Host "> $PSCommandPath $args"


# import artifact parsing and semver handling
. (Join-Path $PSScriptRoot artifact-metadata-parsing.ps1)
. (Join-Path $PSScriptRoot SemVer.ps1)

function GetMetaData($lang){
  switch ($lang) {
    "java" {
      $metadataUri = "https://raw.githubusercontent.com/Azure/azure-sdk/master/_data/releases/latest/java-packages.csv"
      break
    }
    ".net" {
      $metadataUri = "https://raw.githubusercontent.com/Azure/azure-sdk/master/_data/releases/latest/dotnet-packages.csv"
      break
    }
    "python" {
      $metadataUri = "https://raw.githubusercontent.com/Azure/azure-sdk/master/_data/releases/latest/python-packages.csv"
      break
    }
    "javascript" {
      $metadataUri = "https://raw.githubusercontent.com/Azure/azure-sdk/master/_data/releases/latest/js-packages.csv"
      break
    }
    default {
      Write-Host "Unrecognized Language: $language"
      exit(1)
    }
  }

  $metadataResponse = Invoke-WebRequest-WithHandling -url $metadataUri -method "GET" | ConvertFrom-Csv
}

function GetAdjustedReadmeContent($pkgInfo, $lang){
    $date = Get-Date -Format "MM/dd/yyyy"
    $service = ""

    # the namespace is not expected to be present for js.
    $pkgId = $pkgInfo.PackageId.Replace("@azure/", "")

    try {
      $metadata = GetMetaData -lang $lang 
      $service = $metadata | ? { $_.Package -eq $pkgId }

      if ($service) {
        $service = "$service,"
      }
    }
    catch {
      Write-Host $_
      Write-Host "Unable to retrieve service metadata for packageId $($pkgInfo.PackageId)"
    }

    $headerContentMatch = (Select-String -InputObject $pkgInfo.ReadmeContent -Pattern 'Azure .+? (client|plugin|shared) library for (JavaScript|Java|Python|\.NET|C)').Matches[0]

    if ($headerContentMatch){
      $header = "---`r`ntitle: $headerContentMatch`r`nkeywords: Azure, $lang, SDK, API, $service $($pkgInfo.PackageId)`r`nauthor: maggiepint`r`nms.author: magpint`r`nms.date: $date`r`nms.topic: article`r`nms.prod: azure`r`nms.technology: azure`r`nms.devlang: $lang`r`nms.service: $service`r`n---`r`n"
      $fileContent = $pkgInfo.ReadmeContent -replace $headerContentMatch, "$headerContentMatch - Version $($pkgInfo.PackageVersion) `r`n"
      return "$header $fileContent"
    }
    else {
      return ""
    }
}

$apiUrl = "https://api.github.com/repos/$repoId"
$pkgs = VerifyPackages -pkgRepository $Repository `
  -artifactLocation $ArtifactLocation `
  -workingDirectory $WorkDirectory `
  -apiUrl $apiUrl `
  -releaseSha $ReleaseSHA `
  -continueOnError $True

if ($pkgs) {
  Write-Host "Given the visible artifacts, readmes will be copied for the following packages"
  Write-Host ($pkgs | % { $_.PackageId }) 

  foreach ($packageInfo in $pkgs) {
    # sync the doc repo
    $semVer = [AzureEngSemanticVersion]::ParseVersionString($packageInfo.PackageVersion)
    $rdSuffix = ""
    if ($semVer.IsPreRelease) {
      $rdSuffix = "-pre"
    }

    $readmeName = "$($packageInfo.PackageId.Replace('azure-','').Replace('Azure.', '').Replace('@azure/', '').ToLower())-readme$rdSuffix.md"
    $readmeLocation = Join-Path $DocRepoLocation $DocRepoContentLocation $readmeName
    $adjustedContent = GetAdjustedReadmeContent -pkgInfo $packageInfo -lang $Language

    if ($adjustedContent) {
      try {
        Push-Location $DocRepoLocation
        Set-Content -Path $readmeLocation -Value $adjustedContent -Force

        Write-Host "Updated readme for $readmeName."
      } catch {
        Write-Host $_
      } finally {
        Pop-Location
      }
    } else {
      Write-Host "Unable to parse a header out of the readmecontent for PackageId $($packageInfo.PackageId)"
    }
  }
}
else {
  Write-Host "No readmes discovered for doc release under folder $ArtifactLocation."
}
